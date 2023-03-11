using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class Track
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

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
        public IList<TimingId> TimingIds { get; set; }

        [JsonPropertyName("modification_date")]
        public DateTime ModificationDate { get; set; }

        [JsonPropertyName("assets")]
        public object Assets { get; set; }
    }
}