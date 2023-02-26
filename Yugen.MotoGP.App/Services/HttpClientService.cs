using Flurl;
using Flurl.Http;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
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
        public async Task<string> GetLiveTiming(int liveTimingId)
        {
            var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\livetiming.json";
            return await PathIO.ReadTextAsync(filePath);

            //var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/Data/livetiming.json"));
            //var stream = await storageFile.OpenStreamForReadAsync();
            //var liveTiming = JsonSerializer.Deserialize<LiveTiming>(stream);

            return await "https://www.motogp.com/en/json/live_timing"
                .AppendPathSegment(liveTimingId)
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
            var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\calendar.json";
            var result = await PathIO.ReadTextAsync(filePath);
            var calendar = JsonSerializer.Deserialize<Calendar>(result);
            return calendar;

            // TODO: parse dates
            return await "https://www.motogp.com/api/calendar-front/be/events-api/api/v1/business-unit/mgp/season"
                .AppendPathSegment(seasonYear)
                .AppendPathSegment("events")
                .GetJsonAsync<Calendar>();
        }
    }
}