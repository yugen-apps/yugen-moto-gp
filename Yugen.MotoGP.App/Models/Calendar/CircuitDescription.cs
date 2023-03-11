using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class CircuitDescription
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("business_unit_id")]
        public BusinessUnitId BusinessUnitId { get; set; }

        [JsonPropertyName("business_unit_name")]
        public BusinessUnitName BusinessUnitName { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}