namespace PipiPonaPoster.Source.Model.MailOptions
{
    public record MailOptionsDataString
    {
        public string FontSize { get; init; }
        public string FontStyle { get; init; }
        public string MailTopic { get; init; }
        public string FirstImagePath { get; init; }
        public string SecondImagePath { get; init; }
        public string FirstMailText { get; init; }
        public string SecondMailText { get; init; }
    }
}
