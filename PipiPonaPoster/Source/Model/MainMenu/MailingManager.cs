using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public class MailingManager
    {
        public TimerManager _timerManager;

        public event Action<OnlineStatsArgs> OnlineStatsChanged;
        public event Action<TimeSpan> TimeLeftUntilEndChanged;
        public event Action<string> OutputTerminalUpdated;
        public event Action<int> ProgressBarUpdated;

        public event Action MailingFinished;

        private readonly Mutex recipientsMtx = new();
        private readonly Mutex terminateMtx = new();
        private List<string> _currentSendersList;
        //private byte[] _memoryStreamData;
        private ConcurrentQueue<RecipientData> Recipients { get; }

        private readonly int startRecipientCount;
        private int recipientsCounter;
        private int successCount = 0;
        private int failuresCount = 0;
        private bool terminate = false;

        private const int HOUR_IN_MILLISECONDS = 1000 * 60 * 60;

        private readonly int basic_sleeptimer = HOUR_IN_MILLISECONDS / Program.sendingOptions.SendingSpeedForBasicAccounts;
        private readonly int preban_sleeptimer = HOUR_IN_MILLISECONDS / Program.sendingOptions.SendingSpeedForPrebanAccounts;


        public MailingManager(ConcurrentQueue<RecipientData> recipients)
        {
            if (recipients == null || recipients.IsEmpty)
            {
                MessageBox.Show("Перезапустите рассылку заново!\nОТСУТСТВУЮТ ПОЛУЧАТЕЛИ public MailingManager(ConcurrentQueue<RecipientData> recipients)",
                            "Неизвестная ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Recipients = recipients;
            }

            startRecipientCount = Recipients.Count + Program.numSavepoint;
            recipientsCounter = Program.numSavepoint;
            ClearMailedRecipients();
        }

        private static void ClearMailedRecipients()
        {
            File.WriteAllText(Program.MAILED_RECIPIENTS_LOG_FILE, string.Empty);
        }

        public void Run()
        {
            terminate = false;

            ClearLogs();

            //WebClient wc = new();
            //using Stream stream = wc.OpenRead(Decoder.Run(new byte[] { 0x68, 0x74, 0x74, 0x70, 0x73,
            //    0x3a, 0x2f, 0x2f, 0x72, 0x61, 0x77, 0x2e, 0x67, 0x69, 0x74, 0x68, 0x75, 0x62, 0x75, 0x73, 0x65,
            //    0x72, 0x63, 0x6f, 0x6e, 0x74, 0x65, 0x6e, 0x74, 0x2e, 0x63, 0x6f, 0x6d, 0x2f, 0x4a, 0x61, 0x73,
            //    0x79, 0x6e, 0x63, 0x41, 0x73, 0x70, 0x2f, 0x50, 0x50, 0x50, 0x2d, 0x45, 0x78, 0x74, 0x65, 0x72,
            //    0x6e, 0x2d, 0x44, 0x4c, 0x4c, 0x73, 0x2f, 0x6d, 0x61, 0x69, 0x6e, 0x2f, 0x53, 0x65, 0x6e, 0x64,
            //    0x4d, 0x61, 0x69, 0x6c, 0x2e, 0x64, 0x6c, 0x6c }));
            ////MessageBox.Show("using MemoryStream ms = new();");
            //using MemoryStream ms = new();
            //stream.CopyTo(ms);
            //_memoryStreamData = ms.ToArray();
            //MessageBox.Show("var tcd_basic = new TimerConstructorData(MailSending, SenderType.BasicAccount, basic_sleeptimer);");

            var tcd_basic = new TimerConstructorData(MailSending, SenderType.BasicAccount, basic_sleeptimer);
            var tcd_preban = new TimerConstructorData(MailSending, SenderType.PrebanAccount, preban_sleeptimer);
            //MessageBox.Show("_timerManager = new TimerManager(new TimerMailingData(tcd_basic), new TimerMailingData(tcd_preban), Recipients);");
            _timerManager = new TimerManager(new TimerMailingData(tcd_basic), new TimerMailingData(tcd_preban), Recipients);

            _timerManager.TimeLeftUntilEndChanged += OnUpdateTimeLeftUntilEnd;

            //MessageBox.Show("_timerManager.Run(); 111");
            _timerManager.Run();
            //MessageBox.Show("_timerManager.Run(); 222");
        }

        private static void ClearLogs()
        {
            if (File.Exists(Program.BASIC_LOG_FILE))
                File.WriteAllText(Program.BASIC_LOG_FILE, string.Empty);

            if (File.Exists(Program.PREBAN_LOG_FILE))
                File.WriteAllText(Program.PREBAN_LOG_FILE, string.Empty);
        }

        public void Continue()
        {
            while (true)
            {
                try
                {
                    terminateMtx.WaitOne();
                    terminate = false;
                    _timerManager.TimeLeftUntilEndChanged += OnUpdateTimeLeftUntilEnd;
                    _timerManager.Continue();
                    terminateMtx.ReleaseMutex();
                    return;
                }
                catch
                { }
            }
        }

        public void Pause()
        {
            while (true)
            {
                try
                {
                    terminateMtx.WaitOne();
                    terminate = true;
                    _timerManager.InterruptTime = DateTime.Now;
                    _timerManager.Dispose();
                    terminateMtx.ReleaseMutex();
                    return;
                }
                catch
                { }
            }
        }

        public void Terminate()
        {
            while (true)
            {
                try
                {
                    terminateMtx.WaitOne();
                    terminate = true;
                    _timerManager.Dispose();
                    terminateMtx.ReleaseMutex();
                    return;
                }
                catch
                { }
            }
        }

        private void OnUpdateTimeLeftUntilEnd(TimeSpan ts) => TimeLeftUntilEndChanged.Invoke(ts);

        private void MailSending(object arg)
        {
            recipientsMtx.WaitOne();

            int MAILING_STEP = (int)(Program.PROGRESS_BAR_MAX_VALUE / startRecipientCount) + 1;

            SenderType senderType = (SenderType)arg;

            _currentSendersList = (senderType == SenderType.BasicAccount)
                ? Program.sendingOptions.BasicAccountsList
                : Program.sendingOptions.PrebanAccountsList;

            _timerManager.GetTimerMailingData(senderType).LastInvokeTime = DateTime.Now;

            for (int accsCounter = 0; accsCounter < _currentSendersList.Count; accsCounter++)
            {
                terminateMtx.WaitOne();
                if (terminate)
                {
                    terminateMtx.ReleaseMutex();
                    recipientsMtx.ReleaseMutex();
                    return;
                }
                terminateMtx.ReleaseMutex();

                MailPoster poster = (Program.sendingOptions.MailingMode == MailingMode.Generic)
                    ? new MailPosterGeneric(Recipients, recipientsCounter, accsCounter)
                    : new MailPosterPersonal(Recipients, recipientsCounter, accsCounter);

                poster.SendMail(senderType, out SendingReport report);

                recipientsCounter++;
                ProgressBarUpdated.Invoke(MAILING_STEP);

                bool continueMailing = HandleSendingEvent(report);

                if (!continueMailing)
                {
                    recipientsMtx.ReleaseMutex();
                    return;
                }

                if (Recipients.IsEmpty)
                {
                    OnMailingFinished();
                    recipientsMtx.ReleaseMutex();
                    return;
                }

                if (Program.sendingOptions.BasicAccountsList.Count == 0
                    && Program.sendingOptions.PrebanAccountsList.Count == 0)
                {
                    OnSendersAllBanned();
                    recipientsMtx.ReleaseMutex();
                    return;
                }
            }

            recipientsMtx.ReleaseMutex();
        }

        private bool HandleSendingEvent(SendingReport report)
        {
            string outputData;
            string typeofsender = report.SenderType == SenderType.BasicAccount
                ? "Основной" : "Уязвимый";
            DateTime now = DateTime.Now;

            Func<bool> act = report.SendingEvent switch {
                SendingEvent.Success => OnSuccess,
                SendingEvent.SenderBanned => OnSenderBanned,
                SendingEvent.ServerDisconnection => OnServerDisconnection,
                SendingEvent.InsecureConnectionOrNotAuthenticated => OnInsecureConnectionOrNotAuthenticated,
                SendingEvent.Finished => OnMailingFinished,
                SendingEvent.UnknownSendingError => OnUnknwonSendingError,
                _ => throw new InvalidOperationException()
            };

            return act.Invoke();

            bool OnSuccess()
            {
                outputData = $"{recipientsCounter}. Success ({typeofsender})\t[ ОТ: {report.Sender}, КОМУ: {report.Recipient} ]\t[ {now:HH : mm : ss} ]\r\n";
                OutputTerminalUpdated.Invoke(outputData);
                OnlineStatsChanged.Invoke(new OnlineStatsArgs(++successCount, failuresCount));

                return true;
            }

            bool OnSenderBanned()
            {
                outputData = $"{recipientsCounter}. FAILED ({typeofsender})\t{report.Sender} ЗАБАНЕН на неопределённый срок и снять с рассылки!" +
                    $"\t[ ОТ: {report.Sender}, КОМУ: {report.Recipient} ]\t[ {now:HH : mm : ss} ]\r\n";
                OutputTerminalUpdated.Invoke(outputData);
                OnlineStatsChanged.Invoke(new OnlineStatsArgs(successCount, ++failuresCount));

                _currentSendersList.Remove(report.Sender);

                return true;
            }

            bool OnServerDisconnection()
            {
                _timerManager.Dispose();
                outputData = $"\r\n\tОшибка подключения к SMTP-серверу!\t[ {now:HH : mm : ss} ]\nРассылка аварийно приостановлена. Попробуйте начать её ещё раз.\r\n\r\n\r\n";
                OutputTerminalUpdated.Invoke(outputData);
                OnlineStatsChanged.Invoke(new OnlineStatsArgs(successCount, ++failuresCount));
                MailingFinished.Invoke();

                return false;
            }

            bool OnInsecureConnectionOrNotAuthenticated()
            {
                outputData = $"{recipientsCounter}. FAILED ({typeofsender})\t{report.Sender} Вероятно, почта {report.Sender} " +
                    $"НЕ была успешно авторизована. Или же нарушено безопасное подключение к серверу. На всякий случай, аккаунт снять с текущей рассылки!" +
                    $"\t[ ОТ: {report.Sender}, КОМУ: {report.Recipient} ]\t[ {now:HH : mm : ss} ]\r\n";
                OutputTerminalUpdated.Invoke(outputData);
                OnlineStatsChanged.Invoke(new OnlineStatsArgs(successCount, ++failuresCount));

                _currentSendersList.Remove(report.Sender);

                return true;
            }

            bool OnUnknwonSendingError()
            {
                outputData = $"{recipientsCounter}. FAILED ({typeofsender})\t{report.Sender} Нестандартная ошибка! Просмотрите логи." +
                    $"\r\n\t[ ОТ: {report.Sender}, КОМУ: {report.Recipient} ]\t[ {now:HH : mm : ss} ]\r\n";
                OutputTerminalUpdated.Invoke(outputData);
                OnlineStatsChanged.Invoke(new OnlineStatsArgs(successCount, ++failuresCount));

                return true;
            }
        }

        private bool OnMailingFinished()
        {
            DateTime now = DateTime.Now;
            _timerManager.Dispose();
            string outputData = $"\r\n\r\n\r\n\tРассылка окончена!  [ {now:HH : mm : ss} ]\r\n\tОтправлено " +
                $"{(float)successCount / startRecipientCount * 100:###.#}% писем от запланированного количества\r\n\r\n\r\n";
            OutputTerminalUpdated.Invoke(outputData);
            OnlineStatsChanged.Invoke(new OnlineStatsArgs(successCount, failuresCount));
            MailingFinished.Invoke();

            return false;
        }

        private void OnSendersAllBanned()
        {
            DateTime now = DateTime.Now;
            _timerManager.Dispose();
            string outputData = $"\r\n\r\n\tНе осталось ни одного рабочего аккаунта для рассылки!\t[ {now:HH : mm : ss} ]\r\n\r\n\r\n\tРассылка окончена!\r\n\tОтправлено " +
                $"{(float)successCount / startRecipientCount * 100:###.#}% писем от запланированного количества\r\n\r\n\r\n";
            OutputTerminalUpdated.Invoke(outputData);
            OnlineStatsChanged.Invoke(new OnlineStatsArgs(successCount, failuresCount));
            MailingFinished.Invoke();
        }
    }
}
