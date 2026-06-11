using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Models.Sessions;

namespace Yugen.MotoGP.App.Services.HttpClientService;

public interface IHttpClientService
{
	Task<IList<Models.Seasons.Season>> GetSeasons();

	Task<IList<Models.Events.Event>> GetEvents(string seasonYear);

	Task<Models.WorldStanding.WorldStanding> GetWorldStandings(string type, string seasonId, string categoryId);

	Task<IList<Models.Categories.Category>> GetCategories(string seasonId);

	Task<ClassificationBase> GetClassifications(string sessionId);

	Task<IList<SessionBase>> GetSessions(string eventId, string categoryId);

	Task<string> GetLiveTimingLite();
}