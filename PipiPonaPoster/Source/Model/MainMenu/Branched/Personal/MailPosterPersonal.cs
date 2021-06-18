using System;
using System.IO;
using System.Net.Mail;
using System.Collections.Concurrent;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    class MailPosterPersonal : MailPoster
    {
        public MailPosterPersonal(
               ConcurrentQueue<RecipientData> recipients, byte[] memoryStreamData, int recipientsEnumerator, int accountsEnumerator
               ) : base(recipients, memoryStreamData, recipientsEnumerator, accountsEnumerator)
        { }

        protected int counterX = 0;

        protected override string GetEmailHtml(RecipientData recipient, LinkedResource firstImage, LinkedResource logoImage)
        {
            const int ADD_WEEK = 7;
            const int ADD_MONTH = 31;
            const int DAYS_IN_YEAR = 365;
            const int PERCENTS = 100;


            string htmlBody1 = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tbody>" +
                    $"<tr><td style=\"font-family:{Program.mailOptions.FontStyle}; font-size:{Program.mailOptions.FontSize}px; color: black\">" +
                    $"<p>{Program.mailOptions.FirstMailText}</p></td></tr>";


            ///// personal part
            int totalDays = (int)(recipient.TermOfPerformance.AddDays(ADD_MONTH) - Program.sendingOptions.SelectedDate.AddDays(ADD_WEEK)).TotalDays;

            DateTime expireDate = recipient.TermOfPerformance.AddDays(ADD_MONTH);
            decimal commission = (decimal)(Program.sendingOptions.InterestRate / PERCENTS / DAYS_IN_YEAR * totalDays * recipient.BankGuarantee);
            commission = commission >= 1000 ? commission : 1000m; // комиссия меньше 1000 не предоставляется

            string personalText = $"<b>№ лота:</b> {recipient.LotNumber}<br><b>Срок до:</b> {expireDate:dd.MM.yyyy}<br>" +
                $"<b>Комиссия составит:</b> {string.Format("{0:N}", commission)} руб.";

            //Log(expireDate, commission, recipient);

            string htmlBodyPersonal = $"<tr><td style=\"font-family:{Program.mailOptions.FontStyle}; " +
                $"font-size:{Program.mailOptions.FontSize}px; color: black\"><p>{personalText}</p></td></tr>";
            /////


            string htmlBody2 = $"<tr><td style=\"display:block;\"><img src=\"cid:{firstImage.ContentId}\" " +
                $"alt=\"Изображение\" width=\"600\" align=\"middle\"/></td></tr><tr><td style=\"font-family:{Program.mailOptions.FontStyle}; " +
                $"font-size:{Program.mailOptions.FontSize}px; color: black\"><p>{Program.mailOptions.SecondMailText}</p></td></tr>" +
                $"<tr><td style=\"display:block;\"><img src=\"cid:{logoImage.ContentId}\" alt=\"Логотип\" width=\"200\"/></td></tr></tbody></table>";


            string allHtmlBody = htmlBody1 + htmlBodyPersonal + htmlBody2;
            allHtmlBody = allHtmlBody.Replace("\n", "<br>");

            return allHtmlBody;
        }

        //protected static void Log(DateTime expireDate, decimal commission, RecipientData recipient)
        //{
        //    const string file = "logs/calc.txt";

        //    if (!File.Exists(file))
        //        using (File.Create(file)) { }

        //    string text = $"БГ:{recipient.BankGuarantee}\nСрок исполнения:{recipient.TermOfPerformance:dd.MM.yyyy}" +
        //        $"\nСрок до:{expireDate:dd.MM.yyyy}\nКомиссия:{commission:.##}\n\n\n";

        //    File.AppendAllText(file, text);
        //}
    }
}

/*
 тоталдейс = c5 - c4. c4 = b1 + 7. c5 = termofper + 30
 totaldays = (termofper + 30) - (selecteddate + 7);
 */