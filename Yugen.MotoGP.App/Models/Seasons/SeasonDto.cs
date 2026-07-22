using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Seasons;

public class SeasonDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public object Name { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("current")]
    public bool Current { get; set; }
}