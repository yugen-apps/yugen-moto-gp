using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class TimingId
    {
        [JsonPropertyName("business_unit")]
        public string BusinessUnit { get; set; }

        [JsonPropertyName("id")]
        public object Id { get; set; }
    }
}