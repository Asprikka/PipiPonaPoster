using System.Net.Mail;
using System.Collections.Concurrent;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public class MailPosterGeneric : MailPoster
    {
        public MailPosterGeneric(
            ConcurrentQueue<RecipientData> recipients, byte[] memoryStreamData, int recipientsEnumerator, int accountsEnumerator
            ) : base(recipients, memoryStreamData, recipientsEnumerator, accountsEnumerator)
        { }

        protected override string GetEmailHtml(RecipientData recipient, LinkedResource firstImage, LinkedResource logoImage)
        {
            string htmlBodyFirst = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tbody>" +
                    $"<tr><td style=\"font-family:{Program.mailOptions.FontStyle}; font-size:{Program.mailOptions.FontSize}px; color: black\">" +
                    $"<p>{Program.mailOptions.FirstMailText}</p></td></tr>" +
                    $"<tr><td style=\"display:block;\"><img src=\"cid:{firstImage.ContentId}\" alt=\"Изображение\" width=\"600\" align=\"middle\"/></td></tr>";

            string htmlBodyLast = $"<tr><td style=\"font-family:{Program.mailOptions.FontStyle}; font-size:{Program.mailOptions.FontSize}px; color: black\">" +
                $"<p>{Program.mailOptions.SecondMailText}</p></td></tr>" +
                $"<tr><td style=\"display:block;\"><img src=\"cid:{logoImage.ContentId}\" alt=\"Логотип\" width=\"200\"/></td></tr></tbody></table>";

            string allHtmlBody = htmlBodyFirst + htmlBodyLast;
            allHtmlBody = allHtmlBody.Replace("\n", "<br>");

            return allHtmlBody;
        }
    }
}
