using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.WorldStanding
{
    public class WorldStandingBase
    {
        [JsonPropertyName("classification")]
        public IList<Classification> Classification { get; set; }

        [JsonPropertyName("file")]
        public string File { get; set; }

        [JsonPropertyName("xmlFile")]
        public string XmlFile { get; set; }
    }
}