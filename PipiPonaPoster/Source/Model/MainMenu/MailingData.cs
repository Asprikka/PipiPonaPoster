using System.Net.Mail;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public struct MailingData
    {
        public MailMessage Mail { get; private set; }
        public SmtpClient SmtpClient { get; private set; }
        public RecipientData Recipient { get; private set; }
        public string SenderEmail { get; private set; }

        public MailingData(MailMessage mail, SmtpClient smtp, RecipientData recipient, string senderEmail)
        {
            Mail = mail;
            SmtpClient = smtp;
            Recipient = recipient;
            SenderEmail = senderEmail;
        }
    }
}
