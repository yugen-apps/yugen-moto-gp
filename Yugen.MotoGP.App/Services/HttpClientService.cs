using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models;

namespace Yugen.MotoGP.App.Services
{
    public class HttpClientService
    {
        /// <summary>
        /// https://www.motogp.com/en/json/live_timing/685
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<string> GetLiveTiming(string eventId)
        {
            return await "https://www.motogp.com/en/json/live_timing"
                .AppendPathSegment(eventId)
                .GetStringAsync();
            //.GetJsonAsync<LiveTiming>();
        }

        /// <summary>
        /// https://www.motogp.com/api/calendar-front/be/events-api/api/v1/business-unit/mgp/season/2023/events?type=SPORT&upcoming=true&tmp=1676103377756
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<Calendar> GetCalendar(string seasonYear)
        {
            // TODO: parse dates
            return await "https://www.motogp.com/api/calendar-front/be/events-api/api/v1/business-unit/mgp/season"
                .AppendPathSegment(seasonYear)
                .AppendPathSegment("events")
                .GetJsonAsync<Calendar>();
        }
    }
}