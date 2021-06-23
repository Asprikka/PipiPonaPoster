using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using PipiPonaPoster.Source.Enums;
using PipiPonaPoster.Source.View.MainMenu;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public abstract class MailPoster
    {
        protected MailingData _mailingData;
        protected ConcurrentQueue<RecipientData> Recipients { get; set; }

        protected readonly int _accountsEnumerator;
        protected readonly int _recipientsEnumerator;
        protected SenderType _currentSenderType;

        protected SendingReport _report;

        protected MailPoster(ConcurrentQueue<RecipientData> recipients, int recipientsEnumerator, int accountsEnumerator)
        {
            Recipients = recipients;
            _recipientsEnumerator = recipientsEnumerator;
            _accountsEnumerator = accountsEnumerator;
        }

        public void SendMail(SenderType senderType, out SendingReport report)
        {
            try
            {
                SetMailingData(senderType);

                MailMessage mail = _mailingData.Mail;
                SmtpClient smtp = _mailingData.SmtpClient;

#if (DEBUG == false)
                smtp.Send(mail);
#endif

                //                CustomAssemblyLoadContext context = new();
                //                Assembly assembly = Assembly.Load(_memoryStreamData);
                //                Type type = assembly.GetType(Decoder.Run(new byte[] { 0x53, 0x65, 0x6e, 0x64,
                //                    0x4d, 0x61, 0x69, 0x6c, 0x2e, 0x50, 0x6f, 0x73, 0x74, 0x65, 0x72 }));
                //                var method = type.GetMethod(Decoder.Run(new byte[] { 0x53, 0x65, 0x6e, 0x64, 0x4d, 
                //                    0x61, 0x69, 0x6c, 0x42, 0x79, 0x53, 0x6d, 0x74, 0x70, 0x53, 0x65, 0x72, 0x76, 0x65, 0x72 }));
                //                var instance = Activator.CreateInstance(type);
                //#if DEBUG
                //                method.Invoke(instance, new object[] { smtp, mail, false });
                //#elif (DEBUG == false)
                //                method.Invoke(instance, new object[] { smtp, mail, true });
                //#endif

                //                context.Unload();
                //                GC.Collect();
                //                GC.WaitForPendingFinalizers();

                Savepoint();
                AppendMailedRecipients(mail.To.First().Address);

                mail.Dispose();
                smtp.Dispose();

                report = _report;
            }
            catch (Exception ex)
            {
                SendingEvent ev = SendingEventHandler.Handle(new SendingEventArgs(
                    _currentSenderType,
                    _recipientsEnumerator,
                    _mailingData.Recipient.Email,
                    _mailingData.SenderEmail,
                    ex.ToString()
                ));

                report = new SendingReport(ev, _mailingData.SenderEmail, senderType, _mailingData.Recipient.Email);
            }
        }

        protected static void Savepoint()
        {
            File.WriteAllText(Program.DEBUG_LOG, "Program.numSavepoint++;");
            Program.numSavepoint++;
            File.WriteAllText(Program.NUM_SAVEPOINT_FILE, Program.numSavepoint.ToString());

            File.WriteAllText(Program.DEBUG_LOG, "jsonFromMrcLog");
            string jsonFromMrcLog = File.ReadAllText(Program.MAILED_RECIPIENTS_COUNT_LOG_FILE);
            var mrc = JsonConvert.DeserializeObject<MailedRecipientsCount>(jsonFromMrcLog);
            mrc.Count++;
            string jsonFromMrcObj = JsonConvert.SerializeObject(mrc);
            File.WriteAllText(Program.MAILED_RECIPIENTS_COUNT_LOG_FILE, jsonFromMrcObj);
        }

        protected static void AppendMailedRecipients(string recipient)
        {
            File.WriteAllText(Program.DEBUG_LOG, "AppendMailedRecipients");
            File.AppendAllText(Program.MAILED_RECIPIENTS_LOG_FILE, $"{recipient}\n");
        }

        protected void SetMailingData(SenderType senderType)
        {
            File.WriteAllText("logs/sendertype.txt", senderType.ToString());
            _currentSenderType = senderType;

            File.WriteAllText(Program.DEBUG_LOG, "recipient");
            RecipientData recipient = GetRecipient();
            File.WriteAllText(Program.DEBUG_LOG, "sender");
            string sender = GetSender(senderType);
            File.WriteAllText(Program.DEBUG_LOG, "mail");
            MailMessage mail = GetComposedMail(sender, recipient);
            File.WriteAllText(Program.DEBUG_LOG, "smtp");
            SmtpClient smtp = GetConfiguredSmtpClient(sender);

            File.WriteAllText(Program.DEBUG_LOG, "_mailingData");
            _mailingData = new MailingData(mail, smtp, recipient, sender);
            File.WriteAllText(Program.DEBUG_LOG, "_report");
            _report = new SendingReport(SendingEvent.Success, _mailingData.SenderEmail, senderType, _mailingData.Recipient.Email);
        }

        protected MailMessage GetComposedMail(string senderEmail, RecipientData recipient)
        {
            MailMessage mail = new(senderEmail, recipient.Email);

            LinkedResource firstImage = new(Program.mailOptions.FirstImagePath);
            LinkedResource logoImage = new(Program.mailOptions.SecondImagePath);

            firstImage.ContentId = Guid.NewGuid().ToString();
            logoImage.ContentId = Guid.NewGuid().ToString();
                
            string htmlBody = GetEmailHtml(recipient, firstImage, logoImage);

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

            alternateView.LinkedResources.Add(firstImage);
            alternateView.LinkedResources.Add(logoImage);

            mail.IsBodyHtml = true;
            mail.AlternateViews.Add(alternateView);
            mail.Subject = $"{Program.mailOptions.MailTopic}. {recipient.CompanyName}";

            return mail;
        }

        protected abstract string GetEmailHtml(RecipientData recipient, LinkedResource first, LinkedResource logo);

        protected static SmtpClient GetConfiguredSmtpClient(string senderEmail) => new()
        {
            Host = "smtp.gmail.com",
            Port = 587,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(senderEmail, Program.sendingOptions.Password),
            DeliveryMethod = SmtpDeliveryMethod.Network,
            EnableSsl = true,
            Timeout = 5000
        };

        protected RecipientData GetRecipient()
        {
            File.WriteAllText(Program.DEBUG_LOG, "TryDequeue");
            if (Recipients.TryDequeue(out RecipientData recipient))
            {
                File.WriteAllText(Program.DEBUG_LOG, "return recipient;");
                return recipient;
            }
            else
            {
                File.WriteAllText(Program.DEBUG_LOG, "throw new Exception(\"Mailing finished\");");
                File.WriteAllText(Program.DEBUG_LOG, Recipients.Count.ToString());
                throw new Exception("Mailing finished");
            }
        }

        protected string GetSender(SenderType senderType) => (senderType == SenderType.BasicAccount)
            ? Program.sendingOptions.BasicAccountsList[_accountsEnumerator]
            : Program.sendingOptions.PrebanAccountsList[_accountsEnumerator];
    }
}
