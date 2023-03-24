using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Season
{
    public class SeasonBase
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("current")]
        public bool Current { get; set; }
    }
}
