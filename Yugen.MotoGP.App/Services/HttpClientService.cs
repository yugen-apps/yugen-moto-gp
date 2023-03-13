using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.WorldStanding;

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
        public Task<WorldStandingBase> GetWorldStanding()
        {
            return _flurlClient.Request("/api/results-front/be/results-api/season/db8dc197-c7b2-4c1b-b3a4-6dc534c014ef/category/e8c110ad-64aa-4e8e-8a86-f2f152f6a942/world-standing")
                .GetJsonAsync<WorldStandingBase>();
        }
    }
}