using System.Text.Json.Serialization;
using Yugen.MotoGP.App.Models.LiveTiming.Worldchamp;

namespace Yugen.MotoGP.App.Models.LiveTiming
{
    public class LiveTimingBase
    {
        [JsonPropertyName("lt")]
        public Lt Lt { get; set; }

        [JsonPropertyName("worldchamp")]
        public WorldchampBase Worldchamp { get; set; }
    }
}