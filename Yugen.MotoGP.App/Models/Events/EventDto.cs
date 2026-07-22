using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Events;

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

public class CircuitInformation
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
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

public class LegacyId
{
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    [JsonPropertyName("eventId")]
    public int EventId { get; set; }
}

public class NationsStatistics
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class Podiums
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class PolePositions
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class RidersAllTime
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("menu_position")]
    public int MenuPosition { get; set; }
}

public class EventDto
{
    [JsonPropertyName("country")]
    public Country Country { get; set; }

    [JsonPropertyName("event_files")]
    public EventFiles EventFiles { get; set; }

    [JsonPropertyName("circuit")]
    public Circuit Circuit { get; set; }

    [JsonPropertyName("test")]
    public bool Test { get; set; }

    [JsonPropertyName("sponsored_name")]
    public string SponsoredName { get; set; }

    [JsonPropertyName("date_end")]
    public string DateEnd { get; set; }

    [JsonPropertyName("toad_api_uuid")]
    public string ToadApiUuid { get; set; }

    [JsonPropertyName("date_start")]
    public string DateStart { get; set; }

    [JsonPropertyName("additional_name")]
    public string AdditionalName { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("legacy_id")]
    public List<LegacyId> LegacyId { get; set; }

    [JsonPropertyName("season")]
    public Season Season { get; set; }

    [JsonPropertyName("short_name")]
    public string ShortName { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
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