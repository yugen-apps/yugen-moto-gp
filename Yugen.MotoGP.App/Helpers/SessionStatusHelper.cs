using Yugen.MotoGP.App.Models.LiveTimingLites;

namespace Yugen.MotoGP.App.Helpers;

public static class SessionStatusHelper
{
    public static SessionStatus GetSessionStatus(string sessionStatusId)
    {
        return sessionStatusId switch
        {
            "N" => SessionStatus.NotStarted,
            "S" => SessionStatus.Started,
            "F" => SessionStatus.Finished,
            _ => SessionStatus.Unknown
        };
    }
}