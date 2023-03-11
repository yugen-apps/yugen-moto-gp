using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Asset
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("quality")]
        public string Quality { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("mimetype")]
        public string Mimetype { get; set; }
    }
}