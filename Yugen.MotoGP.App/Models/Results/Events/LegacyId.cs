using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Events;

public class LegacyId
{
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    [JsonPropertyName("eventId")]
    public int EventId { get; set; }
}