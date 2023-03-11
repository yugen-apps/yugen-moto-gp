using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class Broadcast
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("shortname")]
        public string Shortname { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        // TODO: parse date
        [JsonPropertyName("date_start")]
        public string DateStart { get; set; }

        // TODO: parse date
        [JsonPropertyName("date_end")]
        public string DateEnd { get; set; }

        [JsonPropertyName("remain")]
        public int Remain { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("progressive")]
        public int Progressive { get; set; }

        [JsonPropertyName("has_timing")]
        public bool HasTiming { get; set; }

        [JsonPropertyName("has_live")]
        public bool HasLive { get; set; }

        [JsonPropertyName("has_report")]
        public bool HasReport { get; set; }

        [JsonPropertyName("has_results")]
        public bool HasResults { get; set; }

        [JsonPropertyName("has_on_demand")]
        public bool HasOnDemand { get; set; }

        [JsonPropertyName("is_live")]
        public bool IsLive { get; set; }

        [JsonPropertyName("is_live_timing")]
        public bool IsLiveTiming { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("gp_day")]
        public int GpDay { get; set; }

        [JsonPropertyName("timing_id")]
        public int TimingId { get; set; }

        [JsonPropertyName("num_laps")]
        public int? NumLaps { get; set; }
    }
}