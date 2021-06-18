using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public record SendingReport(
        SendingEvent SendingEvent, 
        string Sender, 
        SenderType SenderType, 
        string Recipient
    );
}
