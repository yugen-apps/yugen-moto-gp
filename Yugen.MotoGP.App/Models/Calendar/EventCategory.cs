using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class EventCategory
    {
        [JsonPropertyName("category_id")]
        public string CategoryId { get; set; }

        [JsonPropertyName("category_timing_id")]
        public int CategoryTimingId { get; set; }

        [JsonPropertyName("timing_id")]
        public int TimingId { get; set; }

        [JsonPropertyName("sequence")]
        public int Sequence { get; set; }

        [JsonPropertyName("distance")]
        public Distance Distance { get; set; }

        [JsonPropertyName("num_laps")]
        public int? NumLaps { get; set; }
    }
}