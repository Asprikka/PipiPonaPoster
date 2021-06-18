using System;
using System.Threading;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public class TimerMailingData
    {
        public Timer Timer { get; private set; }
        public DateTime LastInvokeTime { get; set; }

        public TimerConstructorData timerConstrData;

        public TimerMailingData(TimerConstructorData timerConstrData)
        {
            this.timerConstrData = timerConstrData;
            LastInvokeTime = DateTime.Now;
        }

        public void RunTimer()
        {
            var tcd = timerConstrData;
            Timer = new Timer(tcd.CallbackMethod, tcd.SenderType, tcd.DueTime, tcd.InvokePeriod);
        }
    }
}
