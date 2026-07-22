using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.LiveTimingLites;

public class RiderDto
{
    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("rider_id")]
    public int RiderId { get; set; }

    [JsonPropertyName("status_name")]
    public string StatusName { get; set; }

    [JsonPropertyName("status_id")]
    public string StatusId { get; set; }

    [JsonPropertyName("rider_number")]
    public string RiderNumber { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("text_color")]
    public string TextColor { get; set; }

    [JsonPropertyName("pos")]
    public int Pos { get; set; }

    [JsonPropertyName("rider_shortname")]
    public string RiderShortname { get; set; }

    [JsonPropertyName("rider_name")]
    public string RiderName { get; set; }

    [JsonPropertyName("rider_surname")]
    public string RiderSurname { get; set; }

    [JsonPropertyName("rider_nation")]
    public string RiderNation { get; set; }

    [JsonPropertyName("lap_time")]
    public string LapTime { get; set; }

    [JsonPropertyName("num_lap")]
    public int NumLap { get; set; }

    [JsonPropertyName("last_lap")]
    public int LastLap { get; set; }

    [JsonPropertyName("last_lap_time")]
    public string LastLapTime { get; set; }

    [JsonPropertyName("trac_status")]
    public string TracStatus { get; set; }

    [JsonPropertyName("team_name")]
    public string TeamName { get; set; }

    [JsonPropertyName("bike_name")]
    public string BikeName { get; set; }

    [JsonPropertyName("bike_id")]
    public int BikeId { get; set; }

    [JsonPropertyName("gap_first")]
    public string GapFirst { get; set; }

    [JsonPropertyName("gap_prev")]
    public string GapPrev { get; set; }

    [JsonPropertyName("on_pit")]
    public bool OnPit { get; set; }
}

public class Head
{
    [JsonPropertyName("championship_id")]
    public string ChampionshipId { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("circuit_id")]
    public string CircuitId { get; set; }

    [JsonPropertyName("circuit_name")]
    public string CircuitName { get; set; }

    [JsonPropertyName("global_event_id")]
    public string GlobalEventId { get; set; }

    [JsonPropertyName("event_id")]
    public string EventId { get; set; }

    [JsonPropertyName("event_tv_name")]
    public string EventTvName { get; set; }

    [JsonPropertyName("event_shortname")]
    public string EventShortname { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("datet")]
    public int Datet { get; set; }

    [JsonPropertyName("datst")]
    public int Datst { get; set; }

    [JsonPropertyName("num_laps")]
    public int NumLaps { get; set; }

    [JsonPropertyName("gmt")]
    public string Gmt { get; set; }

    [JsonPropertyName("trsid")]
    public int Trsid { get; set; }

    [JsonPropertyName("session_id")]
    public string SessionId { get; set; }

    [JsonPropertyName("session_type")]
    public int SessionType { get; set; }

    [JsonPropertyName("session_name")]
    public string SessionName { get; set; }

    [JsonPropertyName("session_shortname")]
    public string SessionShortname { get; set; }

    [JsonPropertyName("duration")]
    public string Duration { get; set; }

    [JsonPropertyName("remaining")]
    public string Remaining { get; set; }

    [JsonPropertyName("session_status_id")]
    public string SessionStatusId { get; set; }

    [JsonPropertyName("session_status_name")]
    public string SessionStatusName { get; set; }

    [JsonPropertyName("date_formated")]
    public string DateFormated { get; set; }

    [JsonPropertyName("url")]
    public object Url { get; set; }
}

public class LiveTimingLiteDto
{
    [JsonPropertyName("head")]
    public Head Head { get; set; }

    //[JsonPropertyName("rider")]
    //public Rider Rider { get; set; }
}
