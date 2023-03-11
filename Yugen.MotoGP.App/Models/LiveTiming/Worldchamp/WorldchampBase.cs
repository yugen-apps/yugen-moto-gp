using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.LiveTiming.Worldchamp
{
    public class WorldchampBase
    {
        [JsonPropertyName("head")]
        public Head Head { get; set; }

        [JsonPropertyName("rider")]
        public List<Rider> Rider { get; set; }
    }
}