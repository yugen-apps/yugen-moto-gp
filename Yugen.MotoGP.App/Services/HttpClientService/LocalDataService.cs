using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Models.Sessions;

namespace Yugen.MotoGP.App.Services.HttpClientService
{
	public class LocalDataService : IHttpClientService
	{
		public async Task<IList<Models.Seasons.Season>> GetSeasons()
		{
			return await Get<IList<Models.Seasons.Season>>("seasons");
		}

		public async Task<IList<Models.Events.Event>> GetEvents(string seasonYear)
		{
			return await Get<IList<Models.Events.Event>>("events");
		}

		public async Task<Models.WorldStanding.WorldStanding> GetWorldStandings(string type, string seasonId, string categoryId)
		{
			return await Get<Models.WorldStanding.WorldStanding>("world-standings");
		}

		public async Task<IList<Models.Categories.Category>> GetCategories(string seasonId)
		{
			return await Get<IList<Models.Categories.Category>>("categories");
		}

		public async Task<ClassificationBase> GetClassifications(string sessionId)
		{
			return await Get<ClassificationBase>("classifications");
		}

		public async Task<IList<SessionBase>> GetSessions(string eventId, string categoryId)
		{
			return await Get<IList<SessionBase>>("sessions");
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
			return JsonSerializer.Deserialize<T>(result, jsonSerializerOptions);
		}

		private static async Task<string> ReadTextAsync(string fileName)
		{
			var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\{fileName}.json";
			return await PathIO.ReadTextAsync(filePath);
		}

		private static readonly JsonSerializerOptions jsonSerializerOptions = new(JsonSerializerDefaults.Web)
		{
			AllowTrailingCommas = true,
			ReadCommentHandling = JsonCommentHandling.Skip,
			NumberHandling = JsonNumberHandling.AllowReadingFromString
		};

		//private static async Task<T> Get<T>(string fileName)
		//{
		//	var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/Data/{fileName}.json"));
		//	var stream = await storageFile.OpenStreamForReadAsync();
		//	return JsonSerializer.Deserialize<T>(stream);
		//}
	}
}