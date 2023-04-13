using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.Results.Classification;
using Yugen.MotoGP.App.Models.Results.Events;
using Yugen.MotoGP.App.Models.Results.Season;
using Yugen.MotoGP.App.Models.Results.Sessions;
using Yugen.MotoGP.App.Models.Results.WorldStanding;

namespace Yugen.MotoGP.App.Services
{
    public class HttpClientService : IHttpClientService
    {
        private const string BaseUrl = "https://www.motogp.com";

        private readonly IFlurlClient _flurlClient;

        public HttpClientService(IFlurlClientFactory flurlClientFac)
        {
            _flurlClient = flurlClientFac.Get(BaseUrl);
        }

        /// <summary>
        /// https://www.motogp.com/en/json/live_timing/685
        /// </summary>
        /// <param name="liveTimingId"></param>
        /// <returns></returns>
        public Task<string> GetLiveTiming(int liveTimingId)
        {
            return _flurlClient.Request("en/json/live_timing")
                .AppendPathSegment(liveTimingId)
                .GetStringAsync();
        }

        /// <summary>
        /// https://www.motogp.com/api/calendar-front/be/events-api/api/v1/business-unit/mgp/season/2023/events?type=SPORT&upcoming=true&tmp=1676103377756
        /// </summary>
        /// <param name="seasonYear"></param>
        /// <returns></returns>
        public Task<CalendarBase> GetCalendar(string seasonYear)
        {
            return _flurlClient.Request("/api/calendar-front/be/events-api/api/v1/business-unit/mgp/season")
                .AppendPathSegment(seasonYear)
                .AppendPathSegment("events")
                .GetJsonAsync<CalendarBase>();
        }

        /// <summary>
        /// https://www.motogp.com/api/results-front/be/results-api/season/db8dc197-c7b2-4c1b-b3a4-6dc534c014ef/category/e8c110ad-64aa-4e8e-8a86-f2f152f6a942/world-standing
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public Task<WorldStandingBase> GetResultsWorldStanding(string seasonId)
        {
            return _flurlClient
                .Request(
                    $"/api/results-front/be/results-api/season/{seasonId}/category/e8c110ad-64aa-4e8e-8a86-f2f152f6a942/world-standing")
                .GetJsonAsync<WorldStandingBase>();
        }

        /// <summary>
        /// https://www.motogp.com/api/results-front/be/results-api/seasons?test=false
        /// </summary>
        /// <returns></returns>
        public Task<IList<SeasonBase>> GetResultsSeasons()
        {
            return _flurlClient.Request("/api/results-front/be/results-api/seasons?test=false")
                .GetJsonAsync<IList<SeasonBase>>();
        }

        /// <summary>
        /// https://www.motogp.com/api/results-front/be/results-api/session/3379c1e5-cae8-4da4-9c23-afc78ffa2778/classifications
        /// </summary>
        /// <returns></returns>
        public Task<ClassificationBase> GetResultsClassification(string eventId)
        {
            return _flurlClient.Request("/api/results-front/be/results-api/session")
                .AppendPathSegment(eventId)
                .AppendPathSegment("classifications")
                .GetJsonAsync<ClassificationBase>();
        }

        /// <summary>
        /// https://www.motogp.com/api/results-front/be/results-api/season/db8dc197-c7b2-4c1b-b3a4-6dc534c023ef/events
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        public Task<IList<EventsBase>> GetResultsEvents(string seasonId = "db8dc197-c7b2-4c1b-b3a4-6dc534c023ef")
        {
            return _flurlClient.Request("/api/results-front/be/results-api/season")
                .AppendPathSegment(seasonId)
                .AppendPathSegment("events")
                .GetJsonAsync<IList<EventsBase>>();
        }

        /// <summary>
        /// https://www.motogp.com/api/results-front/be/results-api/event/df77971c-1f58-4cbd-911f-cf2391fd57e3/category/e8c110ad-64aa-4e8e-8a86-f2f152f6a942/sessions
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public Task<IList<SessionsBase>> GetResultsSessions(string eventId,
            string categoryId = "e8c110ad-64aa-4e8e-8a86-f2f152f6a942")
        {
            return _flurlClient.Request("/api/results-front/be/results-api/event")
                .AppendPathSegment(eventId)
                .AppendPathSegment("category")
                .AppendPathSegment(categoryId)
                .AppendPathSegment("sessions")
                .GetJsonAsync<IList<SessionsBase>>();
        }

        // <summary>
        // https://www.motogp.com/api/results-front/be/results-api/categories
        // </summary>
        // <returns></returns>
        //public Task<IList<SessionsBase>> GetResultsCategories()
        //{
        //    return _flurlClient.Request("/api/results-front/be/results-api/categories")
        //        .GetJsonAsync<IList<SessionsBase>>();
        //}

        // <summary>
        // https://www.motogp.com/api/results-front/be/results-api/categories
        // </summary>
        // <returns></returns>
        //public Task<IList<SessionsBase>> GetResultsCircuits()
        //{
        //    return _flurlClient.Request("/api/results-front/be/results-api/circuits")
        //        .GetJsonAsync<IList<SessionsBase>>();
        //}

        // <summary>
        // https://www.motogp.com/api/results-front/be/results-api/race-placements?page=1
        // </summary>
        // <returns></returns>
        //public Task<IList<SessionsBase>> GetResultsRacePlacements()
        //{
        //    return _flurlClient.Request("/api/results-front/be/results-api/race-placements")
        //        .GetJsonAsync<IList<SessionsBase>>();
        //}
    }
}