using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.WorldStanding
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Classification
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("rider")]
        public Rider Rider { get; set; }

        [JsonPropertyName("team")]
        public Team Team { get; set; }

        [JsonPropertyName("constructor")]
        public Constructor Constructor { get; set; }

        [JsonPropertyName("session")]
        public string Session { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }
    }
}