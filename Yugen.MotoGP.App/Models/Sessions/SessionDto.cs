using System;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Sessions;

public class Analysis
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class AnalysisByLap
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class AverageSpeed
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class BestPartialTime
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class Category
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("legacy_id")]
    public int LegacyId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class Circuit
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("legacy_id")]
    public int LegacyId { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("nation")]
    public string Nation { get; set; }
}

public class Classification
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class CombinedClassification
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class CombinedPractice
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

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

public class Country
{
    [JsonPropertyName("iso")]
    public string Iso { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("region_iso")]
    public string RegionIso { get; set; }
}

public class Event
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("sponsored_name")]
    public string SponsoredName { get; set; }

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; }

    [JsonPropertyName("test")]
    public bool Test { get; set; }

    [JsonPropertyName("season")]
    public string Season { get; set; }

    [JsonPropertyName("circuit")]
    public Circuit Circuit { get; set; }

    [JsonPropertyName("country")]
    public Country Country { get; set; }
}

public class FastLapRider
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class FastLapSequence
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class Grid
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class LapChart
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class MaximumSpeed
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class SessionDto
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("condition")]
    public Condition Condition { get; set; }

    [JsonPropertyName("circuit")]
    public string Circuit { get; set; }

    [JsonPropertyName("session_files")]
    public SessionFiles SessionFiles { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("category")]
    public Category Category { get; set; }

    [JsonPropertyName("event")]
    public Event Event { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}

public class Session
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

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

public class WorldStanding
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}
