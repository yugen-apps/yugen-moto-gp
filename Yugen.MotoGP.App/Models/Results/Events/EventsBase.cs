using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Events
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);

    public class EventsBase
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sponsored_name")]
        public string SponsoredName { get; set; }

        [JsonPropertyName("date_start")]
        public DateTime DateStart { get; set; }

        [JsonPropertyName("date_end")]
        public DateTime DateEnd { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("legacy_id")]
        public List<LegacyId> LegacyId { get; set; }

        [JsonPropertyName("circuit")]
        public Circuit Circuit { get; set; }

        [JsonPropertyName("event_files")]
        public EventFiles EventFiles { get; set; }

        [JsonPropertyName("test")]
        public bool Test { get; set; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }
    }


}
