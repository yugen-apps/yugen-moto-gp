using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.LiveTiming
{
    public class Lt
    {
        [JsonPropertyName("head")]
        public Head Head { get; set; }

        [JsonPropertyName("rider")]
        public Rider Rider { get; set; }
    }
}