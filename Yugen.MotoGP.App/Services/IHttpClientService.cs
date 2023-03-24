using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.Season;
using Yugen.MotoGP.App.Models.WorldStanding;

namespace Yugen.MotoGP.App.Services;

public interface IHttpClientService
{
    Task<string> GetLiveTiming(int liveTimingId);

    Task<CalendarBase> GetCalendar(string seasonYear);

    Task<IList<SeasonBase>> GetSeasons();

    Task<WorldStandingBase> GetWorldStanding(string seasonId);
}