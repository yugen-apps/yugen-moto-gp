using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Event;


public class AssetDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("quality")]
    public string Quality { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("mimetype")]
    public string Mimetype { get; set; }
}

public class Assets
{
    [JsonPropertyName("info")]
    public Info Info { get; set; }

    [JsonPropertyName("simple")]
    public Simple Simple { get; set; }
}

public class Broadcast
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("shortname")]
    public string Shortname { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("date_start")]
    public string DateStart { get; set; }

    [JsonPropertyName("date_end")]
    public string DateEnd { get; set; }

    [JsonPropertyName("remain")]
    public int Remain { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("num_laps")]
    public int? NumLaps { get; set; }

    [JsonPropertyName("progressive")]
    public int Progressive { get; set; }

    [JsonPropertyName("has_timing")]
    public bool HasTiming { get; set; }

    [JsonPropertyName("has_live")]
    public bool HasLive { get; set; }

    [JsonPropertyName("has_report")]
    public bool HasReport { get; set; }

    [JsonPropertyName("has_results")]
    public bool HasResults { get; set; }

    [JsonPropertyName("has_on_demand")]
    public bool HasOnDemand { get; set; }

    [JsonPropertyName("is_live")]
    public bool IsLive { get; set; }

    [JsonPropertyName("is_live_timing")]
    public bool IsLiveTiming { get; set; }

    [JsonPropertyName("live")]
    public bool Live { get; set; }

    [JsonPropertyName("category")]
    public Category Category { get; set; }

    [JsonPropertyName("gp_day")]
    public int GpDay { get; set; }

    [JsonPropertyName("timing_id")]
    public int TimingId { get; set; }

    [JsonPropertyName("event")]
    public object Event { get; set; }

    [JsonPropertyName("season")]
    public object Season { get; set; }
}

public class BusinessUnit
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("acronym")]
    public string Acronym { get; set; }
}

public class BusinessUnitId
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
}

public class BusinessUnitName
{
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Category
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("business_unit")]
    public object BusinessUnit { get; set; }

    [JsonPropertyName("acronym")]
    public string Acronym { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("timing_id")]
    public int TimingId { get; set; }

    [JsonPropertyName("priority")]
    public int Priority { get; set; }
}

public class Circuit
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("iso_code")]
    public string IsoCode { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("lat")]
    public string Lat { get; set; }

    [JsonPropertyName("lng")]
    public string Lng { get; set; }

    [JsonPropertyName("place_id")]
    public string PlaceId { get; set; }

    [JsonPropertyName("constructed")]
    public int Constructed { get; set; }

    [JsonPropertyName("designer")]
    public string Designer { get; set; }

    [JsonPropertyName("modified")]
    public object Modified { get; set; }

    [JsonPropertyName("capacity")]
    public object Capacity { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("timing_ids")]
    public List<TimingId> TimingIds { get; set; }

    [JsonPropertyName("track")]
    public Track Track { get; set; }

    [JsonPropertyName("circuit_descriptions")]
    public List<CircuitDescription> CircuitDescriptions { get; set; }

    [JsonPropertyName("user_location")]
    public UserLocation UserLocation { get; set; }
}

public class CircuitDescription
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("business_unit_id")]
    public BusinessUnitId BusinessUnitId { get; set; }

    [JsonPropertyName("business_unit_name")]
    public BusinessUnitName BusinessUnitName { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

public class Distance
{
    [JsonPropertyName("meters")]
    public int Meters { get; set; }

    [JsonPropertyName("kiloMeters")]
    public double KiloMeters { get; set; }

    [JsonPropertyName("miles")]
    public double Miles { get; set; }

    [JsonPropertyName("feet")]
    public double Feet { get; set; }
}

public class EventCategory
{
    [JsonPropertyName("category_id")]
    public string CategoryId { get; set; }

    [JsonPropertyName("category_timing_id")]
    public int CategoryTimingId { get; set; }

    [JsonPropertyName("timing_id")]
    public int TimingId { get; set; }

    [JsonPropertyName("extra_timing_id")]
    public object ExtraTimingId { get; set; }

    [JsonPropertyName("sequence")]
    public int Sequence { get; set; }

    [JsonPropertyName("num_laps")]
    public int? NumLaps { get; set; }

    [JsonPropertyName("sprint_num_laps")]
    public int? SprintNumLaps { get; set; }

    [JsonPropertyName("red_flag")]
    public int? RedFlag { get; set; }

    [JsonPropertyName("sprint_red_flag")]
    public int? SprintRedFlag { get; set; }

    [JsonPropertyName("distance")]
    public Distance Distance { get; set; }
}

public class Info
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("mimetype")]
    public string Mimetype { get; set; }
}

public class LenghtUnits
{
    [JsonPropertyName("meters")]
    public int Meters { get; set; }

    [JsonPropertyName("kiloMeters")]
    public double KiloMeters { get; set; }

    [JsonPropertyName("miles")]
    public double Miles { get; set; }

    [JsonPropertyName("feet")]
    public double Feet { get; set; }
}

public class LongestStraightUnits
{
    [JsonPropertyName("meters")]
    public int Meters { get; set; }

    [JsonPropertyName("kiloMeters")]
    public double KiloMeters { get; set; }

    [JsonPropertyName("miles")]
    public double Miles { get; set; }

    [JsonPropertyName("feet")]
    public double Feet { get; set; }
}

public class Option
{
    [JsonPropertyName("date")]
    public int Date { get; set; }

    [JsonPropertyName("dateStart")]
    public string DateStart { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("day")]
    public int Day { get; set; }

    [JsonPropertyName("month")]
    public string Month { get; set; }

    [JsonPropertyName("day_suffix")]
    public string DaySuffix { get; set; }

    [JsonPropertyName("gp_day")]
    public int GpDay { get; set; }
}

public class EventDto
{
    [JsonPropertyName("event_categories")]
    public List<EventCategory> EventCategories { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("circuit")]
    public Circuit Circuit { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("urls")]
    public List<UrlDto> Urls { get; set; }

    [JsonPropertyName("assets")]
    public List<AssetDto> Assets { get; set; }

    [JsonPropertyName("additional_name")]
    public string AdditionalName { get; set; }

    [JsonPropertyName("season")]
    public Season Season { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("place")]
    public object Place { get; set; }

    [JsonPropertyName("categories")]
    public List<Category> Categories { get; set; }

    [JsonPropertyName("hashtag")]
    public string Hashtag { get; set; }

    [JsonPropertyName("timing_id")]
    public int TimingId { get; set; }

    [JsonPropertyName("has_results")]
    public bool HasResults { get; set; }

    [JsonPropertyName("remain")]
    public object Remain { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("broadcasts")]
    public List<Broadcast> Broadcasts { get; set; }

    [JsonPropertyName("date_end")]
    public string DateEnd { get; set; }

    [JsonPropertyName("time_zone")]
    public string TimeZone { get; set; }

    [JsonPropertyName("shortname")]
    public string Shortname { get; set; }

    [JsonPropertyName("business_unit")]
    public BusinessUnit BusinessUnit { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("results-api-circuit-uuid")]
    public string ResultsApiCircuitUuid { get; set; }

    [JsonPropertyName("sequence")]
    public int Sequence { get; set; }

    [JsonPropertyName("schedule")]
    public Schedule Schedule { get; set; }

    [JsonPropertyName("date_start")]
    public string DateStart { get; set; }

    [JsonPropertyName("results-api-event-uuid")]
    public string ResultsApiEventUuid { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}

public class Schedule
{
    [JsonPropertyName("options")]
    public List<Option> Options { get; set; }

    [JsonPropertyName("selected_day")]
    public int SelectedDay { get; set; }
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

public class Simple
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("mimetype")]
    public string Mimetype { get; set; }
}

public class TimingId
{
    [JsonPropertyName("business_unit")]
    public string BusinessUnit { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class Track
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("business_unit")]
    public object BusinessUnit { get; set; }

    [JsonPropertyName("first_grid")]
    public string FirstGrid { get; set; }

    [JsonPropertyName("box_entry")]
    public bool BoxEntry { get; set; }

    [JsonPropertyName("box_exit")]
    public bool BoxExit { get; set; }

    [JsonPropertyName("lenght")]
    public string Lenght { get; set; }

    [JsonPropertyName("lenght_units")]
    public LenghtUnits LenghtUnits { get; set; }

    [JsonPropertyName("width")]
    public string Width { get; set; }

    [JsonPropertyName("width_units")]
    public WidthUnits WidthUnits { get; set; }

    [JsonPropertyName("longest_straight")]
    public string LongestStraight { get; set; }

    [JsonPropertyName("longest_straight_units")]
    public LongestStraightUnits LongestStraightUnits { get; set; }

    [JsonPropertyName("left_corners")]
    public string LeftCorners { get; set; }

    [JsonPropertyName("right_corners")]
    public string RightCorners { get; set; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }

    [JsonPropertyName("timing_ids")]
    public List<TimingId> TimingIds { get; set; }

    [JsonPropertyName("modification_date")]
    public string ModificationDate { get; set; }

    [JsonPropertyName("assets")]
    public Assets Assets { get; set; }
}

public class UrlDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class UserLocation
{
    [JsonPropertyName("lat")]
    public string Lat { get; set; }

    [JsonPropertyName("lng")]
    public string Lng { get; set; }

    [JsonPropertyName("radius")]
    public int Radius { get; set; }
}

public class WidthUnits
{
    [JsonPropertyName("meters")]
    public int Meters { get; set; }

    [JsonPropertyName("kiloMeters")]
    public double KiloMeters { get; set; }

    [JsonPropertyName("miles")]
    public double Miles { get; set; }

    [JsonPropertyName("feet")]
    public double Feet { get; set; }
}
