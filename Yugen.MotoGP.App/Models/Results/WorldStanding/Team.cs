using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.WorldStanding
{
    public class Team
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("legacy_id")]
        public int LegacyId { get; set; }

        [JsonPropertyName("season")]
        public Season Season { get; set; }
    }
}