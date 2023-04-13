using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Classification
{
    public class Classification
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("position")]
        public int? Position { get; set; }

        [JsonPropertyName("rider")]
        public Rider Rider { get; set; }

        [JsonPropertyName("team")]
        public Team Team { get; set; }

        //[JsonPropertyName("constructor")]
        //public Constructor Constructor { get; set; }

        //[JsonPropertyName("average_speed")]
        //public double AverageSpeed { get; set; }

        //[JsonPropertyName("gap")]
        //public Gap Gap { get; set; }

        //[JsonPropertyName("total_laps")]
        //public int TotalLaps { get; set; }

        //[JsonPropertyName("time")]
        //public string Time { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        //[JsonPropertyName("status")]
        //public string Status { get; set; }
    }
}
