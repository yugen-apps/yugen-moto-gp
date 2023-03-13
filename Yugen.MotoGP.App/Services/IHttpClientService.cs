using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.WorldStanding;

namespace Yugen.MotoGP.App.Services;

public interface IHttpClientService
{
    Task<string> GetLiveTiming(int liveTimingId);

    Task<CalendarBase> GetCalendar(string seasonYear);

    Task<WorldStandingBase> GetWorldStanding();
}