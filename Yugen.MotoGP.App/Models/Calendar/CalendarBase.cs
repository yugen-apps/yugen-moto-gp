using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Calendar
{
    public class CalendarBase
    {
        [JsonPropertyName("events")]
        public IList<Event> Events { get; set; }
    }
}