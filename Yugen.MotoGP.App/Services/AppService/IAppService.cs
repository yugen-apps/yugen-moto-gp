using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Categories;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Models.Seasons;
using Yugen.MotoGP.App.Models.Sessions;
using Yugen.MotoGP.App.Models.WorldStandings;

namespace Yugen.MotoGP.App.Services.AppService;

public interface IAppService
{
    Task<IList<CategoryDto>> GetCategories(string seasonId);
    
    Task<IList<SeasonDto>> GetSeasons();
    
    Task<WorldStandingDto> GetWorldStanding(string type, string seasonId, string categoryId);

    Task<IList<Models.Events.EventDto>> GetEvents(string seasonId);

    Models.Event.EventDto GetEventDetails(string toadApiUuid);

    Task<ClassificationDto> GetRaceClassifications(IList<SessionDto> sessions);

    Task<IList<SessionDto>> GetSessions(string eventId, string categoryId);
}