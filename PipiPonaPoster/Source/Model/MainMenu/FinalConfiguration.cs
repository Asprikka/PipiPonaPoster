using System;

using Newtonsoft.Json;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class FinalConfiguration
    {
        public string Id { get; set; }
        public string UrlConfig { get; set; }
        public bool JsonUpdate { get; set; }

        public FinalConfiguration()
        { }
    }
}
