using System.Threading;

using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public struct TimerConstructorData
    {
        public TimerCallback CallbackMethod { get; set; }
        public SenderType SenderType { get; set; }
        public long DueTime { get; set; }
        public long InvokePeriod { get; set; }

        public TimerConstructorData(TimerCallback callback, SenderType senderType, long period, long dueTime = 0)
        {
            CallbackMethod = callback;
            SenderType = senderType;
            InvokePeriod = period;
            DueTime = dueTime;
        }
    }
}
