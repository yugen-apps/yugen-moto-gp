using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.WorldStanding
{
    public class Rider
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("legacy_id")]
        public int LegacyId { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }
    }
}