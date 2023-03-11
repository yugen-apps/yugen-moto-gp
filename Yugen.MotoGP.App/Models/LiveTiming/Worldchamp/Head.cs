using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.LiveTiming.Worldchamp
{
    public class Head
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("session_type")]
        public string SessionType { get; set; }

        [JsonPropertyName("session_name")]
        public string SessionName { get; set; }

        [JsonPropertyName("lap")]
        public string Lap { get; set; }

        [JsonPropertyName("champid")]
        public string Champid { get; set; }

        [JsonPropertyName("last_update_parsed")]
        public string LastUpdateParsed { get; set; }

        [JsonPropertyName("last_update")]
        public string LastUpdate { get; set; }
    }
}