using System;
using System.Collections.Concurrent;
using System.Threading;

using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public sealed class TimerManager : IDisposable
    {
        private readonly TimerMailingData _basic;
        private readonly TimerMailingData _preban;

        private ConcurrentQueue<RecipientData> Recipients { get; }

        public Timer TimerUpdateTimeLeftUntilEnd { get; set; }
        public DateTime InterruptTime { get; set; }

        public event Action<TimeSpan> TimeLeftUntilEndChanged;

        // all in milliseconds
        private readonly long basic_sleeptimer = HOUR_IN_MILLISECONDS / Program.sendingOptions.SendingSpeedForBasicAccounts;
        private readonly long preban_sleeptimer = HOUR_IN_MILLISECONDS / Program.sendingOptions.SendingSpeedForPrebanAccounts;

        //
        private const int _100_MILLISECONDS = 500;
        private const int HALF_SECOND_IN_MILLISECONDS = 500;
        private const int HOUR_IN_MILLISECONDS = 1000 * 60 * 60;
        private const int MILLISECOND_IN_TIMESPAN_TICKS = 10000;
        private const int AVERAGE_ONE_MAIL_SENDING_TIME_IN_MILLISECONDS = 4000;

        public TimerManager(TimerMailingData basic, TimerMailingData preban, ConcurrentQueue<RecipientData> Recipients)
        {
            this.Recipients = Recipients;

            _basic = basic;
            _preban = preban;
        }

        public void Dispose()
        {
            _basic.Timer.Dispose();
            _preban.Timer.Dispose();

            TimerUpdateTimeLeftUntilEnd.Dispose();
        }

        public void Run()
        {
            _basic.RunTimer();
            _preban.RunTimer();

            TimerUpdateTimeLeftUntilEnd = new Timer(UpdateTimeLeftUntilEnd, null, _100_MILLISECONDS, HALF_SECOND_IN_MILLISECONDS);
        }

        public void Continue()
        {
            ContinueBasic();
            ContinuePreban();

            TimerUpdateTimeLeftUntilEnd = new Timer(UpdateTimeLeftUntilEnd, null, _100_MILLISECONDS, HALF_SECOND_IN_MILLISECONDS);
        }

        // in milliseconds
        private void ContinueBasic()
        {
            DateTime lastInvokeTime_basic = _basic.LastInvokeTime;

            long dueTime = basic_sleeptimer - (long)(InterruptTime - lastInvokeTime_basic).TotalMilliseconds;

            _basic.timerConstrData = new TimerConstructorData(
                _basic.timerConstrData.CallbackMethod,
                _basic.timerConstrData.SenderType,
                _basic.timerConstrData.InvokePeriod,
                dueTime: dueTime
            );

            _basic.RunTimer();
        }

        // in milliseconds
        private void ContinuePreban()
        {
            DateTime lastInvokeTime_preban = _preban.LastInvokeTime;

            long dueTime = preban_sleeptimer - (long)(InterruptTime - lastInvokeTime_preban).TotalMilliseconds;

            _preban.timerConstrData = new TimerConstructorData(
                _preban.timerConstrData.CallbackMethod,
                _preban.timerConstrData.SenderType,
                _preban.timerConstrData.InvokePeriod,
                dueTime: dueTime
            );

            _preban.RunTimer();
        }

        public TimerMailingData GetTimerMailingData(SenderType senderType) => senderType == SenderType.BasicAccount ? _basic : _preban;

        private void UpdateTimeLeftUntilEnd(object e) => TimeLeftUntilEndChanged.Invoke(GetActualFinishTimeSpan());

        // time values are in milliseconds
        private TimeSpan GetActualFinishTimeSpan()
        {
            double onlyBasicFinTime = 0;

            if (Recipients.Count > Program.sendingOptions.BasicAccountsList.Count)
            {
                double timeElapsedBetweenMailingTimerInvokes = (DateTime.Now - _basic.LastInvokeTime).TotalMilliseconds;

                if (Program.sendingOptions.BasicAccountsList.Count > 0)
                    onlyBasicFinTime = (Recipients.Count / Program.sendingOptions.BasicAccountsList.Count * basic_sleeptimer)
                        + AVERAGE_ONE_MAIL_SENDING_TIME_IN_MILLISECONDS * Recipients.Count - timeElapsedBetweenMailingTimerInvokes;
            }
            else onlyBasicFinTime = basic_sleeptimer;

            //
            double onlyPrebanFinTime = 0;

            if (Recipients.Count > Program.sendingOptions.PrebanAccountsList.Count)
            {
                double timeElapsedBetweenMailingTimerInvokes = (DateTime.Now - _preban.LastInvokeTime).TotalMilliseconds;

                if (Program.sendingOptions.PrebanAccountsList.Count > 0)
                    onlyPrebanFinTime = (Recipients.Count / Program.sendingOptions.PrebanAccountsList.Count * preban_sleeptimer)
                        + AVERAGE_ONE_MAIL_SENDING_TIME_IN_MILLISECONDS * Recipients.Count - timeElapsedBetweenMailingTimerInvokes;
            }
            else onlyPrebanFinTime = preban_sleeptimer;

            //
            double totalEfficiency;

            if (onlyBasicFinTime > 0 && onlyPrebanFinTime > 0)
                totalEfficiency = (onlyBasicFinTime + onlyPrebanFinTime) / (onlyBasicFinTime * onlyPrebanFinTime);
            else if (onlyPrebanFinTime == 0)
                totalEfficiency = Math.Pow(onlyBasicFinTime, -1);
            else if (onlyBasicFinTime == 0)
                totalEfficiency = Math.Pow(onlyPrebanFinTime, -1);
            else
                throw new Exception("onlyBasicFinTime < 0 && onlyPrebanFinTime < 0");

            long totalFinTime = (long)Math.Pow(totalEfficiency, -1);
            TimeSpan result = new(totalFinTime * MILLISECOND_IN_TIMESPAN_TICKS);

            return result;
        }
    }
}
