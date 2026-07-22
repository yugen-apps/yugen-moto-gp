using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Constants;
using Yugen.MotoGP.App.Models.Categories;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Models.Events;
using Yugen.MotoGP.App.Models.Seasons;
using Yugen.MotoGP.App.Models.Sessions;
using Yugen.MotoGP.App.Models.WorldStandings;

namespace Yugen.MotoGP.App.Services.HttpClientService;

public class HttpClientService : IHttpClientService
{
    private const string BaseUrl = "https://api.pulselive.motogp.com/motogp";

    private readonly IFlurlClient _flurlClient;

    public HttpClientService(IFlurlClientBuilder flurlClientBuilder)
    {
        _flurlClient = flurlClientBuilder.Build();
        _flurlClient.BaseUrl = BaseUrl;
        _flurlClient.AllowAnyHttpStatus();
        _flurlClient.Settings.JsonSerializer = new DefaultJsonSerializer(AppConstants.JsonSerializerOptions);
    }

    /// <summary>
    /// https://api.pulselive.motogp.com/motogp/v1/results/seasons
    /// </summary>
    /// <returns></returns>
    public Task<IList<SeasonDto>> GetSeasons()
    {
        return _flurlClient.Request("/v1/results/seasons")
            .GetJsonAsync<IList<SeasonDto>>();
    }

    /// <summary>
    /// https://api.pulselive.motogp.com/motogp/v1/results/categories?seasonUuid=e88b4e43-2209-47aa-8e83-0e0b1cedde6e
    /// </summary>
    /// <param name="seasonId"></param>
    /// <returns></returns>
    public Task<IList<CategoryDto>> GetCategories(string seasonId)
    {
        return _flurlClient.Request("/v1/results/categories")
            .AppendQueryParam("seasonUuid", seasonId)
            .GetJsonAsync<IList<CategoryDto>>();
    }

    /// <summary>
    /// https://api.pulselive.motogp.com/motogp/v1/results/events?seasonUuid=e88b4e43-2209-47aa-8e83-0e0b1cedde6e&isFinished=true
    /// </summary>
    /// <param name="toadApiUuid"></param>
    /// <returns></returns>
    public Task<IList<EventDto>> GetEvents(string seasonUuid)
    {
        return _flurlClient.Request("/v1/results/events")
            .AppendQueryParam("seasonUuid", seasonUuid)
            .GetJsonAsync<IList<EventDto>>();
    }

    /// <summary>
    /// https://api.pulselive.motogp.com/motogp/v1/events/364a0bd9-d3c2-4ab3-a4cd-211ff469953e
    /// </summary>
    /// <param name="seasonId"></param>
    /// <returns></returns>
    public Task<Models.Event.EventDto> GetEvent(string toadApiUuid)
    {
        return _flurlClient.Request("/v1/events")
            .AppendPathSegments(toadApiUuid)
            .GetJsonAsync<Models.Event.EventDto>();
    }

    /// <summary>
    /// https://api.pulselive.motogp.com/motogp/v2/results/world-standings?type=rider&season=e88b4e43-2209-47aa-8e83-0e0b1cedde6e&category=e8c110ad-64aa-4e8e-8a86-f2f152f6a942
    /// </summary>
    /// <param name="type"></param>
    /// <param name="seasonId"></param>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    public Task<WorldStandingDto> GetWorldStandings(string type, string seasonId, string categoryId)
    {
        return _flurlClient
            .Request("/v2/results/world-standings")
            .AppendQueryParam("type", type)
            .AppendQueryParam("season", seasonId)
            .AppendQueryParam("category", categoryId)
            .GetJsonAsync<WorldStandingDto>();
    }

    /// <summary>
    /// https://api.pulselive.motogp.com/motogp/v2/results/classifications?session=a3d72de3-e81c-478a-9669-59727f722e4b&test=false
    /// </summary>
    /// <param name="sessionId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ClassificationDto> GetClassifications(string sessionId)
    {
        return _flurlClient
            .Request("/v2/results/classifications")
            .AppendQueryParam("session", sessionId)
            .GetJsonAsync<ClassificationDto>();
    }

    /// <summary>
    /// https://api.pulselive.motogp.com/motogp/v1/results/sessions?eventUuid=dd266adb-3930-4099-a3d1-a9807362f048&categoryUuid=e8c110ad-64aa-4e8e-8a86-f2f152f6a942
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IList<SessionDto>> GetSessions(string eventId, string categoryId)
    {
        return _flurlClient.Request("/v1/results/sessions")
            .AppendQueryParam("eventUuid", eventId)
            .AppendQueryParam("categoryUuid", categoryId)
            .GetJsonAsync<IList<SessionDto>>();
    }

    /// <summary>
    /// https://api.pulselive.motogp.com/motogp/v1/timing-gateway/livetiming-lite
    /// </summary>
    /// <returns></returns>
    public Task<string> GetLiveTimingLite()
    {
        return _flurlClient.Request("/v1/timing-gateway/livetiming-lite")
            .GetStringAsync();
    }
}