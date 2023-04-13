using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Sessions;

public class Condition
{
    [JsonPropertyName("track")]
    public string Track { get; set; }

    [JsonPropertyName("air")]
    public string Air { get; set; }

    [JsonPropertyName("humidity")]
    public string Humidity { get; set; }

    [JsonPropertyName("ground")]
    public string Ground { get; set; }

    [JsonPropertyName("weather")]
    public string Weather { get; set; }
}