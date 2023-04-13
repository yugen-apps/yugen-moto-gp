using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.Results.Classification;
using Yugen.MotoGP.App.Models.Results.Events;
using Yugen.MotoGP.App.Models.Results.Season;
using Yugen.MotoGP.App.Models.Results.Sessions;
using Yugen.MotoGP.App.Models.Results.WorldStanding;

namespace Yugen.MotoGP.App.Services;

public interface IHttpClientService
{
    Task<string> GetLiveTiming(int liveTimingId);

    Task<CalendarBase> GetCalendar(string seasonYear);

    Task<IList<SeasonBase>> GetResultsSeasons();

    Task<WorldStandingBase> GetResultsWorldStanding(string seasonId);

    Task<ClassificationBase> GetResultsClassification(string race);

    Task<IList<EventsBase>> GetResultsEvents(string season = "db8dc197-c7b2-4c1b-b3a4-6dc534c023ef");

    Task<IList<SessionsBase>> GetResultsSessions(string eventId, string categoryId = "e8c110ad-64aa-4e8e-8a86-f2f152f6a942");
}