using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Yugen.MotoGP.App.Constants;
using Yugen.MotoGP.App.Models.Categories;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Models.Events;
using Yugen.MotoGP.App.Models.Seasons;
using Yugen.MotoGP.App.Models.Sessions;
using Yugen.MotoGP.App.Models.WorldStandings;

namespace Yugen.MotoGP.App.Services.HttpClientService;

public class LocalDataService : IHttpClientService
{
    public async Task<IList<SeasonDto>> GetSeasons()
    {
        return await Get<IList<SeasonDto>>("seasons");
    }

    public async Task<IList<EventDto>> GetEvents(string seasonId)
    {
        return await Get<IList<EventDto>>("events");
    }
    public async Task<Models.Event.EventDto> GetEvent(string toad_api_uuid)
    {
        return await Get<Models.Event.EventDto>("event");
    }

    public async Task<WorldStandingDto> GetWorldStandings(string type, string seasonId, string categoryId)
    {
        return await Get<WorldStandingDto>("world-standings\\rider");
    }

    public async Task<IList<CategoryDto>> GetCategories(string seasonId)
    {
        return await Get<IList<CategoryDto>>("categories");
    }

    public async Task<ClassificationDto> GetClassifications(string sessionId)
    {
        return await Get<ClassificationDto>("classifications");
    }

    public async Task<IList<SessionDto>> GetSessions(string eventId, string categoryId)
    {
        return await Get<IList<SessionDto>>("sessions");
    }

    public async Task<string> GetLiveTimingLite()
    {
        return await Get("livetiming-lite");
    }

    private static async Task<string> Get(string fileName)
    {
        return await ReadTextAsync(fileName);
    }

    private static async Task<T> Get<T>(string fileName)
    {
        var result = await ReadTextAsync(fileName);
        return JsonSerializer.Deserialize<T>(result, AppConstants.JsonSerializerOptions);
    }

    private static async Task<string> ReadTextAsync(string fileName)
    {
        var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\{fileName}.json";
        return await PathIO.ReadTextAsync(filePath);
    }


    //private static async Task<T> Get<T>(string fileName)
    //{
    //	var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/Data/{fileName}.json"));
    //	var stream = await storageFile.OpenStreamForReadAsync();
    //	return JsonSerializer.Deserialize<T>(stream);
    //}
}