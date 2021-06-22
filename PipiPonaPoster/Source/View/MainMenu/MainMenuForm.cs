using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

using Newtonsoft.Json;

using PipiPonaPoster.Source.Enums;
using PipiPonaPoster.Source.Model.SendingOptions;
using PipiPonaPoster.Source.Model.MailOptions;
using PipiPonaPoster.Source.Model.MainMenu;
using PipiPonaPoster.Source.Presentor;
using PipiPonaPoster.Source.View.MainMenu;

namespace PipiPonaPoster.Source.View
{
    public partial class MainMenuForm : Form, IMainMenuView
    {
        private ISendingOptionsPresentor _sendingOptionsPresentor;
        private IMailOptionsPresentor _mailOptionsPresentor;

        public event Func<Task> StartNewMailing_OnClick;
        public event Func<ContinueMode, Task> ContinueMailing_OnClick;
        public event Action PauseMailing_OnClick;
        public event Action TerminateMailing_OnClick;
        public event Action<ConfirmationState> RunMailingConfirmation;

        private bool _terminateAfterPreparing = false;
        private bool _preparingFinished = false;


        public MainMenuForm()
        {
            InitializeComponent();
            OptionsInit();
            LogsInit();
            SavepointInit();
            TempSavepointInit();
        }

        private static void OptionsInit()
        {
            bool done = false;
            while (!done)
            {
                try
                {
                    if (!Directory.Exists(Program.OPTIONS_DIR))
                        Directory.CreateDirectory(Program.OPTIONS_DIR);

                    if (!File.Exists(Program.SENDING_OPTIONS_FILE))
                        File.Create(Program.SENDING_OPTIONS_FILE).Dispose();
                    else
                        Program.sendingOptions = JsonConvert.DeserializeObject<SendingOptionsData>(
                            File.ReadAllText(Program.SENDING_OPTIONS_FILE)
                        );

                    if (!File.Exists(Program.MAIL_OPTIONS_FILE))
                        File.Create(Program.MAIL_OPTIONS_FILE).Dispose();
                    else
                        Program.mailOptions = JsonConvert.DeserializeObject<MailOptionsData>(
                            File.ReadAllText(Program.MAIL_OPTIONS_FILE)
                        );

                    done = true;
                }
                catch
                { }
            }
        }

        private static void LogsInit()
        {
            bool done = false;
            while (!done)
            {
                try
                {
                    if (!Directory.Exists(Program.LOG_DIR))
                        Directory.CreateDirectory(Program.LOG_DIR);

                    if (!File.Exists(Program.BASIC_LOG_FILE))
                        File.Create(Program.BASIC_LOG_FILE).Dispose();

                    if (!File.Exists(Program.PREBAN_LOG_FILE))
                        File.Create(Program.PREBAN_LOG_FILE).Dispose();

                    if (!File.Exists(Program.MAILED_RECIPIENTS_LOG_FILE))
                        File.Create(Program.MAILED_RECIPIENTS_LOG_FILE).Dispose();

                    done = true;
                }
                catch
                { }
            }
        }

        private void SavepointInit()
        {
            MakeAndFillSavepointDir();

            if (IsSavepointPermissible(isFirstCall: true, out int numsp) && numsp != 0)
            {
                if (InvokeRequired)
                    Invoke(new Action(() => ApplySavepoint()));
                else
                    ApplySavepoint();

                void ApplySavepoint()
                {
                    Program.numSavepoint = numsp;
                    buttonContinueMailing.Enabled = true;
                }
            }
        }

        private static void TempSavepointInit()
        {
            bool done = false;
            while (!done)
            {
                try
                {
                    if (!Directory.Exists(Program.TEMP_SAVEPOINT_DIR))
                        Directory.CreateDirectory(Program.TEMP_SAVEPOINT_DIR);

                    if (!File.Exists(Program.TEMP_NUM_SAVEPOINT_FILE))
                        File.Create(Program.TEMP_NUM_SAVEPOINT_FILE).Dispose();

                    done = true;
                }
                catch
                { }
            }
        }

        private static void MakeAndFillSavepointDir()
        {
            bool done = false;
            while (!done)
            {
                try
                {
                    if (!Directory.Exists(Program.SAVEPOINT_DIR))
                        Directory.CreateDirectory(Program.SAVEPOINT_DIR);

                    if (!File.Exists(Program.NUM_SAVEPOINT_FILE))
                        File.Create(Program.NUM_SAVEPOINT_FILE).Dispose();

                    done = true;
                }
                catch
                { }
            }
        }

        private static bool IsSavepointPermissible(bool isFirstCall, out int numsp)
        {
            numsp = 0;

            while (true)
            {
                try
                {
                    if (isFirstCall)
                    {
                        bool innerValueValid = int.TryParse(File.ReadAllText(Program.NUM_SAVEPOINT_FILE), out numsp);

                        bool sendingOptionsMatches = false;
                        if (File.Exists(Program.SAVEPOINT_SENDING_OPTIONS_FILE))
                        {
                            string oldSendingOptionsJson = File.ReadAllText(Program.SAVEPOINT_SENDING_OPTIONS_FILE);
                            var oldSendingOptions =
                                JsonConvert.DeserializeObject<SendingOptionsData>(oldSendingOptionsJson);
                            sendingOptionsMatches = oldSendingOptions == null ||
                                                    oldSendingOptions.Equals(Program.sendingOptions);
                        }

                        bool mailOptionsMatches = false;
                        if (File.Exists(Program.SAVEPOINT_MAIL_OPTIONS_FILE))
                        {
                            string oldMailOptionsJson = File.ReadAllText(Program.SAVEPOINT_MAIL_OPTIONS_FILE);
                            var oldMailOptions = JsonConvert.DeserializeObject<MailOptionsData>(oldMailOptionsJson);
                            mailOptionsMatches = oldMailOptions == null || oldMailOptions == Program.mailOptions;
                        }

                        return innerValueValid && sendingOptionsMatches && mailOptionsMatches;
                    }
                    else
                    {

                        bool innerValueValid = true;

                        bool sendingOptionsMatches = false;
                        if (File.Exists(Program.SAVEPOINT_SENDING_OPTIONS_FILE))
                        {
                            string oldSendingOptionsJson =
                                File.ReadAllText(Program.TEMP_SAVEPOINT_SENDING_OPTIONS_FILE);
                            var oldSendingOptions =
                                JsonConvert.DeserializeObject<SendingOptionsData>(oldSendingOptionsJson);
                            sendingOptionsMatches = oldSendingOptions == null ||
                                                    oldSendingOptions.Equals(Program.sendingOptions);
                        }

                        bool mailOptionsMatches = false;
                        if (File.Exists(Program.SAVEPOINT_MAIL_OPTIONS_FILE))
                        {
                            string oldMailOptionsJson = File.ReadAllText(Program.TEMP_SAVEPOINT_MAIL_OPTIONS_FILE);
                            var oldMailOptions = JsonConvert.DeserializeObject<MailOptionsData>(oldMailOptionsJson);
                            mailOptionsMatches = oldMailOptions == null || oldMailOptions == Program.mailOptions;
                        }

                        return innerValueValid && sendingOptionsMatches && mailOptionsMatches;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        public void Open()
        {
            Application.Run(this);
        }

        public void OnPreparingFinished()
        {
            if (_terminateAfterPreparing)
                RunMailingConfirmation.Invoke(ConfirmationState.Denied);
            else
                RunMailingConfirmation.Invoke(ConfirmationState.Confirmed);

            _preparingFinished = true;
            Invoke(new Action(() => buttonPauseMailing.Enabled = true));
        }

        public void OnMailingFinished() => Invoke(new Action(() => {

            _terminateAfterPreparing = false;
            _preparingFinished = false;
            Program.numSavepoint = 0;

            progressBarCurrentProcess.Value = 0;
            groupBoxCurrentProcessState.Enabled = false;
            groupBoxMailingInfo.Enabled = false;
            buttonContinueMailing.Enabled = false;
            buttonPauseMailing.Enabled = false;
            buttonTerminateMailing.Enabled = false;

            buttonSendingOptions.Enabled = true;
            buttonMailOptions.Enabled = true;
            buttonStartNewMailing.Enabled = true;

            labelTimeLeftUntilEnd.Text = "00 : 00 : 00";
        }));

        public void OnMailingTerminated() => Invoke(new Action(() => {

            _terminateAfterPreparing = false;
            _preparingFinished = false;
            Program.numSavepoint = 0;

            progressBarCurrentProcess.Value = 0;
            groupBoxCurrentProcessState.Enabled = false;
            groupBoxMailingInfo.Enabled = false;
            buttonContinueMailing.Enabled = false;
            buttonPauseMailing.Enabled = false;
            buttonTerminateMailing.Enabled = false;

            buttonSendingOptions.Enabled = true;
            buttonMailOptions.Enabled = true;
            buttonStartNewMailing.Enabled = true;

            textBoxOutputDataTerminal.AppendText("\r\n\r\n\r\n\t### ##### РАССЫЛКА ОТМЕНЕНА!!! ##### ###");

            labelTimeLeftUntilEnd.Text = "00 : 00 : 00";
        }));

        public void OnOptionsChanged()
        {
            if (!IsSavepointPermissible(isFirstCall: false, out int numsp))
            {
                if (InvokeRequired)
                    Invoke(new Action(() => RestrictSavepoint()));
                else
                    RestrictSavepoint();

                void RestrictSavepoint()
                {
                    Program.numSavepoint = 0;
                    buttonContinueMailing.Enabled = false;

                    textBoxOutputDataTerminal.Text = string.Empty;

                    groupBoxCurrentProcessState.Enabled = false;
                    groupBoxMailingInfo.Enabled = false;
                    
                    buttonContinueMailing.Enabled = false;
                    buttonPauseMailing.Enabled = false;
                    buttonStartNewMailing.Enabled = true;
                    buttonTerminateMailing.Enabled = false;

                    buttonSendingOptions.Enabled = true;
                    buttonMailOptions.Enabled = true;

                    labelRecipientsCount.Text = 0.ToString();
                    labelSendersCount.Text = 0.ToString();

                    progressBarCurrentProcess.Value = 0;

                    Program.mailingStartTime = default;
                    labelMailingStartTime.Text = "00 : 00";
                }
            }
        }

        public void UpdateTimeLeftUntilEndLabel(TimeSpan e)
        {
            try
            {
                Invoke(new Action(() =>
                    labelTimeLeftUntilEnd.Text = new DateTime(e.Ticks).ToString("HH : mm : ss")
                ));
            }
            catch (ObjectDisposedException)
            { }
        }

        public void UpdateOnlineStats(OnlineStatsArgs e)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    labelSuccessCount.Text = e.SuccessCount.ToString();
                    labelFailuresCount.Text = e.FailuresCount.ToString();
                }));
            }
            catch (ObjectDisposedException) { }
        }

        public void UpdateOutputTerminal(string e)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    textBoxOutputDataTerminal.AppendText(e);
                }));
            }
            catch (ObjectDisposedException) { }
        }

        public async Task UpdateOutputTerminalAsync(string e)
        {
            try
            {
                await Task.Run(() =>
                {
                    Invoke(new Action(() =>
                    {
                        textBoxOutputDataTerminal.AppendText(e);
                    }));
                });
            }
            catch (ObjectDisposedException) { }
        }

        public void UpdateProgressBar(int step)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    if (step != Program.CLEAR_PROGRESS_BAR)
                    {
                        progressBarCurrentProcess.Step = step;
                        progressBarCurrentProcess.PerformStep();
                    }
                    else
                    {
                        progressBarCurrentProcess.Value = 0;
                    }
                }));
            }
            catch (ObjectDisposedException) { }
        }

        public async Task UpdateProgressBarAsync(int step)
        {
            try
            {
                await Task.Run(() =>
                {
                    Invoke(new Action(() =>
                    {
                        if (step != Program.CLEAR_PROGRESS_BAR)
                        {
                            progressBarCurrentProcess.Step = step;
                            progressBarCurrentProcess.PerformStep();
                        }
                        else
                        {
                            progressBarCurrentProcess.Value = 0;
                        }
                    }));
                });
            }
            catch (ObjectDisposedException) { }
        }


        private void ButtonSendingOptions_Click(object sender, EventArgs e)
        {
            _sendingOptionsPresentor = new SendingOptionsPresentor();
            _sendingOptionsPresentor.OptionsChanged += () => OnOptionsChanged();

            this.Hide();
            _sendingOptionsPresentor.Run();
            this.Show();
        }

        private void ButtonMailOptions_Click(object sender, EventArgs e)
        {
            _mailOptionsPresentor = new MailOptionsPresentor();
            _mailOptionsPresentor.OptionsChanged += () => OnOptionsChanged();

            this.Hide();
            _mailOptionsPresentor.Run();
            this.Show();
        }

        private void ButtonStartNewMailing_Click(object sender, EventArgs e)
        {
            if (CheckOptionsOnNull() == false)
                return;

            //
            textBoxOutputDataTerminal.Text = "Инициализируем рассылку...\r\n\r\n";

            groupBoxCurrentProcessState.Enabled = true;
            groupBoxMailingInfo.Enabled = true;

            buttonContinueMailing.Enabled = false;
            buttonPauseMailing.Enabled = false;
            buttonStartNewMailing.Enabled = false;
            buttonTerminateMailing.Enabled = true;

            buttonSendingOptions.Enabled = false;
            buttonMailOptions.Enabled = false;

            labelRecipientsCount.Text = Program.sendingOptions.RecipientsCount.ToString();
            labelSendersCount.Text = (Program.sendingOptions.BasicAccountsList.Count + Program.sendingOptions.PrebanAccountsList.Count).ToString();

            progressBarCurrentProcess.Value = 0;

            Program.numSavepoint = 0;
            Program.mailingStartTime = DateTime.Now;
            labelMailingStartTime.Text = Program.mailingStartTime.ToString("HH : mm");
            //

            StartNewMailing_OnClick.Invoke();
        }

        private static bool CheckOptionsOnNull()
        {
            if (Program.sendingOptions == null)
            {
                MessageBox.Show("Рассылка не настроена!");
                return false;
            }

            if (Program.mailOptions == null)
            {
                MessageBox.Show("Параметры письма не настроены!");
                return false;
            }

            return true;
        }

        private void ButtonContinueMailing_Click(object sender, EventArgs e)
        {
            // Если терминал вывода данных пуст, то мы запустили программу заново
            // Если он заполнен каким-то текстом, то рассылка просто поставлена на паузу
            bool continueOldMailing = string.IsNullOrEmpty(textBoxOutputDataTerminal.Text)
                || string.IsNullOrWhiteSpace(textBoxOutputDataTerminal.Text);

            ContinueMode mode = continueOldMailing
                ? ContinueMode.Old
                : ContinueMode.Current;

            //
            string text = !continueOldMailing
                ? "\r\n\r\nИнициализируем рассылку... На повторный запуск уйдёт некоторое время " +
                "(в зависимости от указанной скорости рассылки)\r\n\r\n"
                : string.Empty;
            textBoxOutputDataTerminal.AppendText(text);

            groupBoxCurrentProcessState.Enabled = true;
            groupBoxMailingInfo.Enabled = true;

            buttonPauseMailing.Enabled = !continueOldMailing;

            labelRecipientsCount.Text = Program.sendingOptions.RecipientsCount.ToString();
            labelSendersCount.Text = (Program.sendingOptions.BasicAccountsList.Count + Program.sendingOptions.PrebanAccountsList.Count).ToString();

            buttonContinueMailing.Enabled = false;
            buttonStartNewMailing.Enabled = false;
            buttonTerminateMailing.Enabled = true;

            Program.mailingStartTime = DateTime.Now;
            labelMailingStartTime.Text = Program.mailingStartTime.ToString("HH : mm");
            //

            ContinueMailing_OnClick.Invoke(mode);
        }

        private void ButtonPauseMailing_Click(object sender, EventArgs e)
        {
            //
            groupBoxCurrentProcessState.Enabled = true;
            groupBoxMailingInfo.Enabled = true;

            buttonContinueMailing.Enabled = true;
            buttonPauseMailing.Enabled = false;
            buttonStartNewMailing.Enabled = true;
            buttonTerminateMailing.Enabled = true;

            buttonSendingOptions.Enabled = true;
            buttonMailOptions.Enabled = true;
            //

            PauseMailing_OnClick.Invoke();
        }

        private void ButtonTerminateMailing_Click(object sender, EventArgs e)
        {
            if (!_preparingFinished)
                _terminateAfterPreparing = true;
            else
                TerminateMailing_OnClick.Invoke();

            buttonTerminateMailing.Enabled = false;
            buttonPauseMailing.Enabled = false;
        }

        private void ButtonSaveMailedRecipients_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Program.MAILED_RECIPIENTS_LOG_FILE))
            {
                MessageBox.Show("Файл с данными об истории рассылки НЕ найден!", 
                    "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mainLogText = File.ReadAllText(Program.MAILED_RECIPIENTS_LOG_FILE);
            if (string.IsNullOrEmpty(mainLogText))
            {
                MessageBox.Show("Операция недоступна!\nФайл с данными об истории рассылки ПУСТ!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string newLogFileName = $"logs/mailed_recipients({DateTime.Now:dd-MM-yyyy_HH-mm-ss}).txt";
                if (!File.Exists(newLogFileName))
                {
                    File.Copy(Program.MAILED_RECIPIENTS_LOG_FILE, newLogFileName);
                    MessageBox.Show($"История рассылки успешна записана в файл{newLogFileName}",
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    File.WriteAllText(newLogFileName, mainLogText);
                    MessageBox.Show($"История рассылки успешна записана в файл{newLogFileName}",
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Операция прошла НЕ успешно!\nПопробуйте ещё раз.\n\nПодробная информация разработчику по ошибке:{ex}",
                    "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonOpenLogs_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Program.LOG_DIR))
                Process.Start("explorer.exe", Program.LOG_DIR);
            else
                MessageBox.Show(string.Format("\'{0}\' directory does not exist!", Program.LOG_DIR));
        }

        private void ButtonCalculators_Click(object sender, EventArgs e)
        {
            new CalculatorsForm().Show();
        }

        private void ButtonGetTodaySentMails_Click(object sender, EventArgs e)
        {
            const string LOG_FILE_PATH = Program.MAILED_RECIPIENTS_COUNT_LOG_FILE;

            if (!File.Exists(LOG_FILE_PATH))
            {
                MailedRecipientsCount newMrc = new();
                newMrc.ResetToCurrentDay();

                string jsonFromMrc = JsonConvert.SerializeObject(newMrc);
                File.WriteAllText(LOG_FILE_PATH, jsonFromMrc);
            }

            string jsonFromLog = File.ReadAllText(LOG_FILE_PATH);
            if (string.IsNullOrEmpty(jsonFromLog))
                throw new InvalidOperationException("MAILED_RECIPIENTS_COUNT_LOG_FILE is unexpectedly empty or null!");

            var mrc = JsonConvert.DeserializeObject<MailedRecipientsCount>(jsonFromLog);

            if (mrc.LogDate.DayOfWeek != DateTime.Now.DayOfWeek)
            {
                mrc.ResetToCurrentDay();

                string jsonFromMrc = JsonConvert.SerializeObject(mrc);
                File.WriteAllText(LOG_FILE_PATH, jsonFromMrc);
            }

            MessageBox.Show($"За сегодня было разослано {mrc.Count} писем.",
                "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LinkLabelMe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => new Process
        {
            StartInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "cmd",
                Arguments = $"/c start https://github.com/Kaprikka/"
            }
        }.Start();

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateSavepoint();
            WriteTemporarySavepoint();
        }

        private static void UpdateSavepoint()
        {
            if (Directory.Exists(Program.SAVEPOINT_DIR))
                Directory.Delete(Program.SAVEPOINT_DIR, recursive: true);

            Directory.CreateDirectory(Program.SAVEPOINT_DIR);

            File.WriteAllText(Program.NUM_SAVEPOINT_FILE, Program.numSavepoint.ToString());

            if (!Directory.Exists(Program.OPTIONS_DIR))
                throw new Exception("\'options\' directory were not found!");

            File.Copy(Program.SENDING_OPTIONS_FILE, Program.SAVEPOINT_SENDING_OPTIONS_FILE);
            File.Copy(Program.MAIL_OPTIONS_FILE, Program.SAVEPOINT_MAIL_OPTIONS_FILE);
        }

        private static void WriteTemporarySavepoint()
        {
            if (!Directory.Exists(Program.OPTIONS_DIR))
                throw new Exception("\'options\' directory were not found!");

            if (!Directory.Exists(Program.TEMP_SAVEPOINT_DIR))
                throw new Exception("\'temp savepoint\' directory were not found!");

            if (!Directory.Exists(Program.SAVEPOINT_DIR))
                throw new Exception("\'savepoint\' directory were not found!");

            if (File.Exists(Program.TEMP_SAVEPOINT_SENDING_OPTIONS_FILE))
                File.Delete(Program.TEMP_SAVEPOINT_SENDING_OPTIONS_FILE);
            File.Copy(Program.SAVEPOINT_SENDING_OPTIONS_FILE, Program.TEMP_SAVEPOINT_SENDING_OPTIONS_FILE);

            if (File.Exists(Program.TEMP_SAVEPOINT_MAIL_OPTIONS_FILE))
                File.Delete(Program.TEMP_SAVEPOINT_MAIL_OPTIONS_FILE);
            File.Copy(Program.SAVEPOINT_MAIL_OPTIONS_FILE, Program.TEMP_SAVEPOINT_MAIL_OPTIONS_FILE);

            if (File.Exists(Program.TEMP_NUM_SAVEPOINT_FILE))
                File.Delete(Program.TEMP_NUM_SAVEPOINT_FILE);
            File.Copy(Program.NUM_SAVEPOINT_FILE, Program.TEMP_NUM_SAVEPOINT_FILE);

        }
    }
}
