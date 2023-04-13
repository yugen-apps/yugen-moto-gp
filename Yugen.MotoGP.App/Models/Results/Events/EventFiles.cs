using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Events;

public class EventFiles
{
    [JsonPropertyName("circuit_information")]
    public CircuitInformation CircuitInformation { get; set; }

    [JsonPropertyName("podiums")]
    public Podiums Podiums { get; set; }

    [JsonPropertyName("pole_positions")]
    public PolePositions PolePositions { get; set; }

    [JsonPropertyName("nations_statistics")]
    public NationsStatistics NationsStatistics { get; set; }

    [JsonPropertyName("riders_all_time")]
    public RidersAllTime RidersAllTime { get; set; }
}