using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class Schedule
    {
        [JsonPropertyName("options")]
        public IList<Option> Options { get; set; }

        [JsonPropertyName("selected_day")]
        public int SelectedDay { get; set; }
    }
}