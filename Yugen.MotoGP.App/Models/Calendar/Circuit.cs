using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class Circuit
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("iso_code")]
        public string IsoCode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("lat")]
        public string Lat { get; set; }

        [JsonPropertyName("lng")]
        public string Lng { get; set; }

        [JsonPropertyName("place_id")]
        public string PlaceId { get; set; }

        [JsonPropertyName("constructed")]
        public int Constructed { get; set; }

        [JsonPropertyName("designer")]
        public string Designer { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("timing_ids")]
        public IList<TimingId> TimingIds { get; set; }

        [JsonPropertyName("track")]
        public Track Track { get; set; }

        [JsonPropertyName("circuit_descriptions")]
        public IList<CircuitDescription> CircuitDescriptions { get; set; }

        [JsonPropertyName("modified")]
        public int? Modified { get; set; }

        [JsonPropertyName("capacity")]
        public int? Capacity { get; set; }
    }
}