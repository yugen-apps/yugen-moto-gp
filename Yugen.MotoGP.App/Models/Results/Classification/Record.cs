using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Classification;

public class Record
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("rider")]
    public Rider Rider { get; set; }

    [JsonPropertyName("bestLap")]
    public BestLap BestLap { get; set; }

    [JsonPropertyName("speed")]
    public string Speed { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("isNewRecord")]
    public bool IsNewRecord { get; set; }
}