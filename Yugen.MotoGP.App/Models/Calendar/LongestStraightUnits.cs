using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class LongestStraightUnits
    {
        [JsonPropertyName("meters")]
        public int Meters { get; set; }

        [JsonPropertyName("kiloMeters")]
        public double KiloMeters { get; set; }

        [JsonPropertyName("miles")]
        public double Miles { get; set; }

        [JsonPropertyName("feet")]
        public double Feet { get; set; }
    }
}