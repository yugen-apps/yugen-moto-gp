using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class BusinessUnitName
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}