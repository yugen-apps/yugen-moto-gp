using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class Event
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("shortname")]
        public string Shortname { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("assets")]
        public IList<Asset> Assets { get; set; }

        [JsonPropertyName("date_start")]
        public DateTime DateStart { get; set; }

        [JsonPropertyName("date_end")]
        public DateTime DateEnd { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("circuit")]
        public Circuit Circuit { get; set; }

        [JsonPropertyName("categories")]
        public IList<Category> Categories { get; set; }

        [JsonPropertyName("event_categories")]
        public IList<EventCategory> EventCategories { get; set; }

        [JsonPropertyName("business_unit")]
        public BusinessUnit BusinessUnit { get; set; }

        [JsonPropertyName("season")]
        public Season Season { get; set; }

        [JsonPropertyName("broadcasts")]
        public IList<Broadcast> Broadcasts { get; set; }

        [JsonPropertyName("schedule")]
        public Schedule Schedule { get; set; }

        [JsonPropertyName("timing_id")]
        public int TimingId { get; set; }

        [JsonPropertyName("urls")]
        public IList<Uri> Urls { get; set; }

        [JsonPropertyName("ticketings")]
        public IList<Ticketing> Ticketings { get; set; }

        [JsonPropertyName("next_broadcast")]
        public NextBroadcast NextBroadcast { get; set; }

        [JsonPropertyName("hashtag")]
        public string Hashtag { get; set; }

        [JsonPropertyName("remain")]
        public int? Remain { get; set; }
    }
}