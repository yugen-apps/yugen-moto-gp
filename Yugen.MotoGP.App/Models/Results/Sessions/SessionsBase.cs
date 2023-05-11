using System;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Sessions
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);

    public class SessionsBase
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("number")]
        public int? Number { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("session_files")]
        public SessionFiles SessionFiles { get; set; }

        [JsonPropertyName("circuit")]
        public string Circuit { get; set; }
    }
}