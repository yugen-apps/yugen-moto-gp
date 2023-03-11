using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.WorldStanding;

namespace Yugen.MotoGP.App.Services
{
    public class HttpClientService
    {
        private string _baseUrl = "https://www.motogp.com";

        /// <summary>
        /// https://www.motogp.com/en/json/live_timing/685
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<string> GetLiveTiming(int liveTimingId)
        {
            return await $"{_baseUrl}/en/json/live_timing"
                .AppendPathSegment(liveTimingId)
                .GetStringAsync();
        }

        /// <summary>
        /// https://www.motogp.com/api/calendar-front/be/events-api/api/v1/business-unit/mgp/season/2023/events?type=SPORT&upcoming=true&tmp=1676103377756
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<CalendarBase> GetCalendar(string seasonYear)
        {
            return await $"{_baseUrl}/api/calendar-front/be/events-api/api/v1/business-unit/mgp/season"
                .AppendPathSegment(seasonYear)
                .AppendPathSegment("events")
                .GetJsonAsync<CalendarBase>();
        }

        /// <summary>
        /// https://www.motogp.com/api/results-front/be/results-api/season/db8dc197-c7b2-4c1b-b3a4-6dc534c014ef/category/e8c110ad-64aa-4e8e-8a86-f2f152f6a942/world-standing
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<WorldStandingBase> GetWorldStanding()
        {
            return await $"{_baseUrl}/api/results-front/be/results-api/season/db8dc197-c7b2-4c1b-b3a4-6dc534c014ef/category/e8c110ad-64aa-4e8e-8a86-f2f152f6a942/world-standing"
                .GetJsonAsync<WorldStandingBase>();
        }
    }
}