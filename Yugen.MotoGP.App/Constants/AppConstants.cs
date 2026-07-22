using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Constants;

public static class AppConstants
{
    public const string EventStatusLiveTiming = "Live Timing";
    public const string EventStatusResults = "Results";
    public const string EventKindRace = "Race";
    public const string EventKindTest = "Test";

    public static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web)
    {
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        NumberHandling =
                JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString,
        WriteIndented = true
    };
}