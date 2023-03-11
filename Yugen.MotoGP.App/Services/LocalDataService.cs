using System;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.WorldStanding;

namespace Yugen.MotoGP.App.Services
{
    public class LocalDataService
    {
        public async Task<string> GetLiveTiming(int liveTimingId)
        {
            return await Get("livetiming");
        }

        public async Task<CalendarBase> GetCalendar(string seasonYear)
        {
            return await Get<CalendarBase>("calendar");
        }

        public async Task<WorldStandingBase> GetWorldStanding()
        {
            return await Get<WorldStandingBase>("worldstanding");
        }

        private async Task<string> Get(string fileName)
        {
            var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\{fileName}.json";
            return await PathIO.ReadTextAsync(filePath);
        }

        private async Task<T> Get<T>(string fileName)
        {
            var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\{fileName}.json";
            var result = await PathIO.ReadTextAsync(filePath);
            return JsonSerializer.Deserialize<T>(result);

            //var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/Data/{fileName}.json"));
            //var stream = await storageFile.OpenStreamForReadAsync();
            //return JsonSerializer.Deserialize<T>(stream);
        }
    }
}