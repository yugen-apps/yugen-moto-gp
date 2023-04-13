using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.LiveTiming
{
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

        [JsonPropertyName("gmt")]
        public int? Gmt { get; set; }

        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        [JsonPropertyName("session_type")]
        public string SessionType { get; set; }

        [JsonPropertyName("session_name")]
        public string SessionName { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }

        [JsonPropertyName("session_status_id")]
        public string SessionStatusId { get; set; }

        [JsonPropertyName("session_status_name")]
        public string SessionStatusName { get; set; }

        [JsonPropertyName("date_formated")]
        public string DateFormated { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("trsid")]
        public int Trsid { get; set; }

        [JsonPropertyName("calendar_event_track")]
        public string CalendarEventTrack { get; set; }
    }
}