using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Events;

public class Podiums
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}