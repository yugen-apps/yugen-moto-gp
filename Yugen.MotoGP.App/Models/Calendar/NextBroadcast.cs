using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class NextBroadcast
    {
        [JsonPropertyName("id_broadcast")]
        public string IdBroadcast { get; set; }

        [JsonPropertyName("remain")]
        public int Remain { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shortname")]
        public string Shortname { get; set; }

        [JsonPropertyName("category_name")]
        public string CategoryName { get; set; }

        [JsonPropertyName("gp_day")]
        public int GpDay { get; set; }
    }
}