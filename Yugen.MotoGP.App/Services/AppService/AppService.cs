using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Categories;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Models.Seasons;
using Yugen.MotoGP.App.Models.Sessions;
using Yugen.MotoGP.App.Models.WorldStandings;
using Yugen.MotoGP.App.Services.ConfigService;
using Yugen.MotoGP.App.Services.HttpClientService;

namespace Yugen.MotoGP.App.Services.AppService;

public class AppService : IAppService
{
    private readonly IConfigService _configService;
    private readonly IHttpClientService _httpClientService;

    private readonly ConcurrentDictionary<string, Models.Event.EventDto> _eventsDictionary = [];
    private IList<Models.Events.EventDto> _events;

    public AppService(
        IConfigService configService,
        IHttpClientService httpClientService)
    {
        _configService = configService;
        _httpClientService = httpClientService;
    }

    public async Task<IList<CategoryDto>> GetCategories(string seasonId)
    {
        _configService.Categories ??= await _httpClientService.GetCategories(seasonId);
        return _configService.Categories;
    }

    public async Task<IList<SeasonDto>> GetSeasons()
    {
        _configService.Seasons ??= await _httpClientService.GetSeasons();
        return _configService.Seasons;
    }

    public async Task<WorldStandingDto> GetWorldStanding(string type, string seasonId, string categoryId)
    {
        if (string.IsNullOrWhiteSpace(type) ||
            string.IsNullOrWhiteSpace(seasonId) ||
            string.IsNullOrWhiteSpace(categoryId))
        {
            return null;
        }

        return await _httpClientService.GetWorldStandings(type, seasonId, categoryId);
    }

    public async Task<IList<Models.Events.EventDto>> GetEvents(string seasonId)
    {
        if (string.IsNullOrWhiteSpace(seasonId))
        {
            return null;
        }

        _events ??= await _httpClientService.GetEvents(seasonId);

        await Parallel.ForEachAsync(_events, async (e, _) =>
        {
            await GetEvent(e.ToadApiUuid);
        });

        return _events;
    }

    private async Task<Models.Event.EventDto> GetEvent(string toadApiUuid)
    {
        var eventDetails = _eventsDictionary.GetValueOrDefault(toadApiUuid);
        if (eventDetails != null)
        {
            return eventDetails;
        }

        eventDetails = await _httpClientService.GetEvent(toadApiUuid);
        _eventsDictionary.TryAdd(toadApiUuid, eventDetails);
        return eventDetails;
    }

    public Models.Event.EventDto GetEventDetails(string toadApiUuid) =>
        _eventsDictionary.GetValueOrDefault(toadApiUuid);

    public async Task<ClassificationDto> GetRaceClassifications(IList<SessionDto> sessions)
    {
        if (sessions == null ||
           !sessions.Any())
        {
            return null;
        }

        var sessionId = sessions.First(static x => x.Type == "RAC").Id;

        return await _httpClientService.GetClassifications(sessionId);
    }

    public async Task<IList<SessionDto>> GetSessions(string eventId, string categoryId)
    {
        return await _httpClientService.GetSessions(eventId, categoryId);
    }
}