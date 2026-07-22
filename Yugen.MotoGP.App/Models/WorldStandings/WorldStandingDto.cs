using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.WorldStandings;

// Constructor, Rider, Teaam
public class Classification
{
    [JsonPropertyName("rider")]
    public List<RiderDto> Rider { get; set; }

    [JsonPropertyName("constructor")]
    public List<ConstructorDto> Constructor { get; set; }

    [JsonPropertyName("team")]
    public List<TeamDto> Team { get; set; }
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
    [JsonPropertyName("pdf")]
    public string Pdf { get; set; }

    [JsonPropertyName("xml")]
    public string Xml { get; set; }
}

public class WorldStandingDto
{
    [JsonPropertyName("classification")]
    public Classification Classification { get; set; }

    [JsonPropertyName("files")]
    public Files Files { get; set; }

    [JsonPropertyName("official")]
    public bool Official { get; set; }
}

// Constructor, Teaam
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

public class Season
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("current")]
    public bool Current { get; set; }
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

// Constructor
public class ConstructorDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("ordering")]
    public int Ordering { get; set; }

    [JsonPropertyName("season")]
    public Season Season { get; set; }

    [JsonPropertyName("category")]
    public Category Category { get; set; }

    [JsonPropertyName("session")]
    public Session Session { get; set; }

    [JsonPropertyName("constructor")]
    public ConstructorDto Constructor { get; set; }

    [JsonPropertyName("points")]
    public int Points { get; set; }

    [JsonPropertyName("event")]
    public Event Event { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("legacy_id")]
    public int LegacyId { get; set; }
}

// Teaam
public class TeamDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("ordering")]
    public int Ordering { get; set; }

    [JsonPropertyName("season")]
    public Season Season { get; set; }

    [JsonPropertyName("category")]
    public Category Category { get; set; }

    [JsonPropertyName("session")]
    public Session Session { get; set; }

    [JsonPropertyName("team")]
    public string Team { get; set; }

    [JsonPropertyName("points")]
    public int Points { get; set; }

    [JsonPropertyName("event")]
    public Event Event { get; set; }
}

// Rider
public class RiderDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("rider")]
    public RiderDto Rider { get; set; }

    [JsonPropertyName("constructor")]
    public ConstructorDto Constructor { get; set; }

    [JsonPropertyName("team_name")]
    public string TeamName { get; set; }

    [JsonPropertyName("session")]
    public string Session { get; set; }

    [JsonPropertyName("points")]
    public int Points { get; set; }

    [JsonPropertyName("pointsFromFirst")]
    public int PointsFromFirst { get; set; }

    [JsonPropertyName("pointsFromPrevious")]
    public int PointsFromPrevious { get; set; }

    [JsonPropertyName("race_wins")]
    public int RaceWins { get; set; }

    [JsonPropertyName("podiums")]
    public int Podiums { get; set; }

    [JsonPropertyName("last_positions")]
    public LastPositions LastPositions { get; set; }

    [JsonPropertyName("sprint_wins")]
    public int SprintWins { get; set; }

    [JsonPropertyName("sprint_podiums")]
    public int SprintPodiums { get; set; }

    [JsonPropertyName("sprint_last_positions")]
    public SprintLastPositions SprintLastPositions { get; set; }

    [JsonPropertyName("position_change")]
    public int PositionChange { get; set; }

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

public class LastPositions
{
    [JsonPropertyName("HUN")]
    public int? HUN { get; set; }

    [JsonPropertyName("ITA")]
    public int? ITA { get; set; }

    [JsonPropertyName("CAT")]
    public int? CAT { get; set; }
}

public class SprintLastPositions
{
    [JsonPropertyName("HUN")]
    public int? HUN { get; set; }

    [JsonPropertyName("ITA")]
    public int? ITA { get; set; }

    [JsonPropertyName("CAT")]
    public int? CAT { get; set; }
}
