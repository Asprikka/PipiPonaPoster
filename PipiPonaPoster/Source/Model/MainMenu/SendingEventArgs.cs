using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public record SendingEventArgs(
        SenderType SenderType,
        int Counter,
        string Recipient,
        string Sender,
        string ExceptionText
    );
}
