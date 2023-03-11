using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.LiveTiming
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class RiderDetails
    {
        [JsonPropertyName("rider_id")]
        public string RiderId { get; set; }

        [JsonPropertyName("pos")]
        public string Pos { get; set; }

        [JsonPropertyName("rider_number")]
        public string RiderNumber { get; set; }

        [JsonPropertyName("rider_name")]
        public string RiderName { get; set; }

        [JsonPropertyName("rider_surname")]
        public string RiderSurname { get; set; }

        [JsonPropertyName("team_name")]
        public string TeamName { get; set; }

        [JsonPropertyName("status_id")]
        public string StatusId { get; set; }

        [JsonPropertyName("status_name")]
        public string StatusName { get; set; }

        [JsonPropertyName("lap_time")]
        public string LapTime { get; set; }

        [JsonPropertyName("num_lap")]
        public string NumLap { get; set; }

        [JsonPropertyName("last_lap")]
        public string LastLap { get; set; }

        [JsonPropertyName("last_lap_time")]
        public string LastLapTime { get; set; }

        [JsonPropertyName("gap_first")]
        public string GapFirst { get; set; }

        [JsonPropertyName("gap_prev")]
        public string GapPrev { get; set; }

        [JsonPropertyName("trac_status")]
        public string TracStatus { get; set; }

        [JsonPropertyName("rider_url")]
        public string RiderUrl { get; set; }

        [JsonPropertyName("on_pit")]
        public string OnPit { get; set; }
    }
}