using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.WorldStanding
{
    public class Constructor
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("legacy_id")]
        public int LegacyId { get; set; }
    }
}