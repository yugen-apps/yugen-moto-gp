using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Events;

public class Country
{
    [JsonPropertyName("iso")]
    public string Iso { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("region_iso")]
    public string RegionIso { get; set; }
}