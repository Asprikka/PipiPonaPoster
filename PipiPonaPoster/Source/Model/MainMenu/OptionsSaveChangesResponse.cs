using System.Collections.Generic;

namespace PipiPonaPoster.Source.Model
{
    public record OptionsSaveChangesResponse
    {
        public bool HasErrors { get; init; }
        public bool HasWarning { get; init; }
        public List<string> InvalidFields { get; init; }
    }
}
