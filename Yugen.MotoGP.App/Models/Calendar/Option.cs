using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class Option
    {
        [JsonPropertyName("date")]
        public int Date { get; set; }

        // TODO: parse date
        [JsonPropertyName("dateStart")]
        public string DateStart { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("month")]
        public string Month { get; set; }

        [JsonPropertyName("day_suffix")]
        public string DaySuffix { get; set; }

        [JsonPropertyName("gp_day")]
        public int GpDay { get; set; }
    }
}