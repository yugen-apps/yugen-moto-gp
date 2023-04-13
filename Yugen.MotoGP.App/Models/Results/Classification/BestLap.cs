using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Classification;

public class BestLap
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }
}