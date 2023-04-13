using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Sessions;

public class SessionFiles
{
    [JsonPropertyName("classification")]
    public Classification Classification { get; set; }

    [JsonPropertyName("analysis")]
    public Analysis Analysis { get; set; }

    [JsonPropertyName("average_speed")]
    public AverageSpeed AverageSpeed { get; set; }

    [JsonPropertyName("fast_lap_sequence")]
    public FastLapSequence FastLapSequence { get; set; }

    [JsonPropertyName("lap_chart")]
    public LapChart LapChart { get; set; }

    [JsonPropertyName("analysis_by_lap")]
    public AnalysisByLap AnalysisByLap { get; set; }

    [JsonPropertyName("fast_lap_rider")]
    public FastLapRider FastLapRider { get; set; }

    [JsonPropertyName("grid")]
    public Grid Grid { get; set; }

    [JsonPropertyName("session")]
    public Session Session { get; set; }

    [JsonPropertyName("world_standing")]
    public WorldStanding WorldStanding { get; set; }

    [JsonPropertyName("best_partial_time")]
    public BestPartialTime BestPartialTime { get; set; }

    [JsonPropertyName("maximum_speed")]
    public MaximumSpeed MaximumSpeed { get; set; }

    [JsonPropertyName("combined_practice")]
    public CombinedPractice CombinedPractice { get; set; }

    [JsonPropertyName("combined_classification")]
    public CombinedClassification CombinedClassification { get; set; }
}