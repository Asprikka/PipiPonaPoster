using System;
using System.Linq;
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Windows.Forms;

using PipiPonaPoster.Source.Model.MainMenu;
using PipiPonaPoster.Source.Enums;
using PipiPonaPoster.Source.Model.MainMenu.CustomExceptions;

#region pragma
#pragma warning disable CS8524
#endregion

namespace PipiPonaPoster.Source.Model
{
    public class MainMenuService : IMainMenuService
    {
        private MailingManager _mailingManager;
        private Thread _mailingThread;

        private static readonly object locker = new();
        private ConfirmationState _runMailingConfirmation = ConfirmationState.None;
        private MailingLaunchInstruction _mailingLaunchInstruction = MailingLaunchInstruction.StartNew;

        public event Action<OnlineStatsArgs> OnlineStatsChanged;
        public event Action<TimeSpan> TimeLeftUntilEndChanged;
        public event Action<string> OutputTerminalUpdated;
        public event Action<int> ProgressBarUpdated;
        public event Action MailingFinished;
        public event Action MailingTerminated;
        public event Action PreparingFinished;

        public event Func<string, Task> OutputTerminalUpdatedAsync;
        public event Func<int, Task> ProgressBarUpdatedAsync;


        public async Task StartNewMailingAsync() => await ExecutePreparingAsync();

        public async Task ContinueMailingAsync(ContinueMode mode)
        {
            if (mode == ContinueMode.Old)
            {
                _mailingLaunchInstruction = MailingLaunchInstruction.ContinueOld;
                await ExecutePreparingAsync();
            }
            else if (mode == ContinueMode.Current)
                _mailingManager.Continue();
        }

        public void PauseMailing() => _mailingManager.Pause();

        public void TerminateMailing()
        {
            _mailingManager.Terminate();
            _mailingManager = null;
            MailingTerminated.Invoke();
        }

        public void OnRunMailingConfirmation(ConfirmationState confirm)
        {
            lock (locker)
            {
                _runMailingConfirmation = confirm;
            }
        }


        private async Task ExecutePreparingAsync()
        {
            try
            {
                ExcelDatabaseReader reader = Program.sendingOptions.MailingMode switch
                {
                    MailingMode.Generic => new ExcelDatabaseReaderGeneric(),
                    MailingMode.Personal => new ExcelDatabaseReaderPersonal()
                };

                reader.OutputTerminalUpdatedAsync += Reader_OutputTerminalUpdatedAsync;
                reader.ProgressBarUpdatedAsync += Reader_ProgressBarUpdatedAsync;

                if (ExcelDatabaseReader.ValidateOptions())
                {
                    ConcurrentQueue<RecipientData> recipients = await reader.GetSortedDataOrNullAsync();

                    if (recipients == null)
                    {
                        MessageBox.Show("Перезапустите рассылку заново!\nПроизошла ошибка обработки данных экселя",
                            "Неизвестная ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MailingTerminated.Invoke();
                        return;
                    }

                    PreparingFinished.Invoke();

                    if (WaitConfirmation())
                    {
                        _mailingThread = new(new ParameterizedThreadStart(RunMailingManager));
                        _mailingThread.Start(recipients);
                    }
                    else
                    {
                        MailingTerminated.Invoke();
                        return;
                    }
                }
                else throw new EmptyOptionsException();
            }
            catch (EmptyOptionsException)
            {
                throw new EmptyOptionsException();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Перезапустите рассылку заново!\n\n" + ex.ToString(), "Неизвестная ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool WaitConfirmation()
        {
            bool loop = true;
            while (loop)
            {
                lock (locker)
                {
                    if (_runMailingConfirmation != ConfirmationState.None)
                    {
                        loop = false;
                        return _runMailingConfirmation == ConfirmationState.Confirmed;
                    }

                    Thread.Sleep(100);
                }
            }

            return false;
        }

        private void RunMailingManager(object arg)
        {
            var recipients = arg as ConcurrentQueue<RecipientData>;

            if (_mailingLaunchInstruction == MailingLaunchInstruction.ContinueOld)
                ApplySavepointToQueue(ref recipients); // mutates recipients queue

            _mailingManager = new MailingManager(recipients);

            _mailingManager.TimeLeftUntilEndChanged += (TimeSpan e) => TimeLeftUntilEndChanged.Invoke(e);
            _mailingManager.OnlineStatsChanged += (OnlineStatsArgs e) => OnlineStatsChanged.Invoke(e);
            _mailingManager.OutputTerminalUpdated += (string e) => OutputTerminalUpdated.Invoke(e);
            _mailingManager.ProgressBarUpdated += (int step) => ProgressBarUpdated.Invoke(step);
            _mailingManager.MailingFinished += () => MailingFinished.Invoke();

            _mailingManager.Run();
        }

        private static void ApplySavepointToQueue(ref ConcurrentQueue<RecipientData> recipientsQueue)
        {
            var recipientsList = recipientsQueue.ToList();
            recipientsList.RemoveRange(0, Program.numSavepoint);

            recipientsQueue = new ConcurrentQueue<RecipientData>(recipientsList);
        }


        private async Task Reader_ProgressBarUpdatedAsync(int step) => await ProgressBarUpdatedAsync.Invoke(step);

        private async Task Reader_OutputTerminalUpdatedAsync(string e) => await OutputTerminalUpdatedAsync.Invoke(e);
    }
}

#pragma warning restore CS8524 
// Выражение switch не обрабатывает некоторые типы входных значений, в том числе неименованное значение перечисления (не является исчерпывающим).