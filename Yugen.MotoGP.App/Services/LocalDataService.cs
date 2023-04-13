using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.Results.Classification;
using Yugen.MotoGP.App.Models.Results.Events;
using Yugen.MotoGP.App.Models.Results.Season;
using Yugen.MotoGP.App.Models.Results.Sessions;
using Yugen.MotoGP.App.Models.Results.WorldStanding;

namespace Yugen.MotoGP.App.Services
{
    public class LocalDataService : IHttpClientService
    {
        public async Task<string> GetLiveTiming(int liveTimingId)
        {
            return await Get("livetiming");
        }

        public async Task<CalendarBase> GetCalendar(string seasonYear)
        {
            return await Get<CalendarBase>("calendar");
        }

        public async Task<WorldStandingBase> GetResultsWorldStanding(string seasonId)
        {
            return await Get<WorldStandingBase>("worldstanding");
        }

        private static async Task<string> Get(string fileName)
        {
            var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\{fileName}.json";
            return await PathIO.ReadTextAsync(filePath);
        }

        private static async Task<T> Get<T>(string fileName)
        {
            var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\{fileName}.json";
            var result = await PathIO.ReadTextAsync(filePath);
            return JsonSerializer.Deserialize<T>(result);

            //var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/Data/{fileName}.json"));
            //var stream = await storageFile.OpenStreamForReadAsync();
            //return JsonSerializer.Deserialize<T>(stream);
        }

        public Task<IList<SeasonBase>> GetResultsSeasons()
        {
            throw new NotImplementedException();
        }

        public Task<ClassificationBase> GetResultsClassification(string race)
        {
            throw new NotImplementedException();
        }

        public Task<IList<EventsBase>> GetResultsEvents(string season = "db8dc197-c7b2-4c1b-b3a4-6dc534c023ef")
        {
            throw new NotImplementedException();
        }

        public Task<IList<SessionsBase>> GetResultsSessions(string eventId, string categoryId = "e8c110ad-64aa-4e8e-8a86-f2f152f6a942")
        {
            throw new NotImplementedException();
        }
    }
}