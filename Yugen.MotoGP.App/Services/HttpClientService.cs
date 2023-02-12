using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace Yugen.MotoGP.App.Services
{
    public class HttpClientService
    {
        public async Task<string> GetLiveTiming(string eventId)
        {
            return await "https://www.motogp.com/en/json/live_timing"
                .AppendPathSegment(eventId)
                .GetStringAsync();
            //.GetJsonAsync<LiveTiming>();
        }
    }
}