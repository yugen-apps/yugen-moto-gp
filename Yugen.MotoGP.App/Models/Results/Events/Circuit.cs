using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Events;

public class Circuit
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("legacy_id")]
    public int LegacyId { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("nation")]
    public string Nation { get; set; }
}