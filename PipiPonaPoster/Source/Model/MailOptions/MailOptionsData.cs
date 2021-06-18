using System;

using Newtonsoft.Json;

namespace PipiPonaPoster.Source.Model.MailOptions
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public record MailOptionsData
    {
        public int FontSize { get; init; }
        public string FontStyle { get; init; }
        public string MailTopic { get; init; }
        public string FirstImagePath { get; init; }
        public string SecondImagePath { get; init; }
        public string FirstMailText { get; init; }
        public string SecondMailText { get; init; }
    }
}
