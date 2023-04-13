using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Sessions;

public class FastLapSequence
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}