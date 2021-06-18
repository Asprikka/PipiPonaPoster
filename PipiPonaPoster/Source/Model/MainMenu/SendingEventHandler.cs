using System;
using System.IO;

using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public static class SendingEventHandler
    {
        public static SendingEvent Handle(SendingEventArgs args)
        {
            string logfile = args.SenderType == SenderType.BasicAccount
                ? Program.BASIC_LOG_FILE : Program.PREBAN_LOG_FILE ;

            // забанили акк во время рассылки
            if (args.ExceptionText.ToLower().Contains("mailbox unavailable"))
            {
                string logtext = $"\t{args.Counter}:\tFAILED [{DateTime.Now}]\n\t{args.Sender} HAS BEEN BANNED!";
                File.AppendAllText(logfile, logtext);

                return SendingEvent.SenderBanned;
            }
            // ошибка подключения с смтп-сервером
            else if (args.ExceptionText.Contains("System.Net.Sockets.SocketException (11001)"))
            {
                return SendingEvent.ServerDisconnection;
            }
            else if (args.ExceptionText.ToLower().Contains("was not authenticated"))
            {
                return SendingEvent.InsecureConnectionOrNotAuthenticated;
            }
            // событие окончания рассылки
            else if (args.ExceptionText.Contains("Mailing finished"))
            {
                return SendingEvent.Finished;
            }
            // ошибка отправления письма
            else
            {
                string logtext = $"{args.Counter}.\tFAILED [{DateTime.Now}]\n\tSender: " + 
                    $"{args.Sender}\n\tRecipient: {args.Recipient}\n\tException: {args.ExceptionText}\n\n";
                File.AppendAllText(logfile, logtext);

                return SendingEvent.UnknownSendingError;
            }
        }
    }
}
