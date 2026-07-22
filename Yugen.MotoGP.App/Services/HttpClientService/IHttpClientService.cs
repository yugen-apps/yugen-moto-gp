using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Categories;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Models.Events;
using Yugen.MotoGP.App.Models.Seasons;
using Yugen.MotoGP.App.Models.Sessions;
using Yugen.MotoGP.App.Models.WorldStandings;

namespace Yugen.MotoGP.App.Services.HttpClientService;

public interface IHttpClientService
{
    Task<IList<SeasonDto>> GetSeasons();

    Task<IList<EventDto>> GetEvents(string seasonId);

    Task<Models.Event.EventDto> GetEvent(string toadApiUuid);

    Task<WorldStandingDto> GetWorldStandings(string type, string seasonId, string categoryId);

    Task<IList<CategoryDto>> GetCategories(string seasonId);

    Task<ClassificationDto> GetClassifications(string sessionId);

    Task<IList<SessionDto>> GetSessions(string eventId, string categoryId);

    Task<string> GetLiveTimingLite();
}