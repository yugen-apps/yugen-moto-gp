using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Classifications;

public class BestLap
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }
}

public class Classification
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("position")]
    public int? Position { get; set; }

    [JsonPropertyName("rider")]
    public Rider Rider { get; set; }

    [JsonPropertyName("constructor")]
    public Constructor Constructor { get; set; }

    [JsonPropertyName("team_name")]
    public string TeamName { get; set; }

    [JsonPropertyName("average_speed")]
    public double AverageSpeed { get; set; }

    [JsonPropertyName("gap")]
    public Gap Gap { get; set; }

    [JsonPropertyName("total_laps")]
    public int TotalLaps { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("points")]
    public int Points { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}

public class Constructor
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("legacy_id")]
    public int LegacyId { get; set; }
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

public class Files
{
    [JsonPropertyName("classification")]
    public string Classification { get; set; }

    [JsonPropertyName("analysis")]
    public string Analysis { get; set; }

    [JsonPropertyName("average_speed")]
    public string AverageSpeed { get; set; }

    [JsonPropertyName("fast_lap_sequence")]
    public string FastLapSequence { get; set; }

    [JsonPropertyName("lap_chart")]
    public string LapChart { get; set; }

    [JsonPropertyName("analysis_by_lap")]
    public string AnalysisByLap { get; set; }

    [JsonPropertyName("fast_lap_rider")]
    public string FastLapRider { get; set; }

    [JsonPropertyName("grid")]
    public string Grid { get; set; }

    [JsonPropertyName("session")]
    public string Session { get; set; }

    [JsonPropertyName("world_standing")]
    public string WorldStanding { get; set; }
}

public class Gap
{
    [JsonPropertyName("first")]
    public string First { get; set; }

    [JsonPropertyName("lap")]
    public string Lap { get; set; }
}

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

public class Rider
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("full_name")]
    public string FullName { get; set; }

    [JsonPropertyName("country")]
    public Country Country { get; set; }

    [JsonPropertyName("legacy_id")]
    public int LegacyId { get; set; }

    [JsonPropertyName("riders_id")]
    public string RidersId { get; set; }

    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("riders_api_uuid")]
    public string RidersApiUuid { get; set; }
}

public class ClassificationDto
{
    [JsonPropertyName("classification")]
    public List<Classification> Classification { get; set; }

    [JsonPropertyName("official")]
    public bool Official { get; set; }

    [JsonPropertyName("files")]
    public Files Files { get; set; }

    [JsonPropertyName("session")]
    public Session Session { get; set; }

    [JsonPropertyName("records")]
    public List<Record> Records { get; set; }
}

public class Session
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("number")]
    public object Number { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}
