using System;

namespace PipiPonaPoster.Source.View.MainMenu
{
    [Serializable]
    public class MailedRecipientsCount
    {
        public DateTime LogDate { get; set; }
        public int Count { get; set; }

        public void ResetToCurrentDay()
        {
            LogDate = DateTime.Now;
            Count = 0;
        }
    }
}
