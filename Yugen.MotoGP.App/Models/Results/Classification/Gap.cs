using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Classification;

public class Gap
{
    [JsonPropertyName("first")]
    public string First { get; set; }

    [JsonPropertyName("lap")]
    public string Lap { get; set; }
}