using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class BusinessUnitId
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}