using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.LiveTiming.Worldchamp
{
    public class Rider
    {
        [JsonPropertyName("cid")]
        public string Cid { get; set; }

        [JsonPropertyName("pos")]
        public string Pos { get; set; }

        [JsonPropertyName("rid")]
        public string Rid { get; set; }

        [JsonPropertyName("points")]
        public string Points { get; set; }

        [JsonPropertyName("bike_name")]
        public string BikeName { get; set; }

        [JsonPropertyName("champ_name")]
        public string ChampName { get; set; }

        [JsonPropertyName("rider_name")]
        public string RiderName { get; set; }

        [JsonPropertyName("rider_surname")]
        public string RiderSurname { get; set; }

        [JsonPropertyName("lap")]
        public string Lap { get; set; }

        [JsonPropertyName("numgara")]
        public string Numgara { get; set; }

        [JsonPropertyName("last_update")]
        public string LastUpdate { get; set; }

        [JsonPropertyName("session_type")]
        public string SessionType { get; set; }

        [JsonPropertyName("session_name")]
        public string SessionName { get; set; }

        [JsonPropertyName("gap_first")]
        public string GapFirst { get; set; }

        [JsonPropertyName("gap_prev")]
        public string GapPrev { get; set; }

        [JsonPropertyName("rider_url")]
        public string RiderUrl { get; set; }
    }
}