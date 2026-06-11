using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Models.Sessions;

namespace Yugen.MotoGP.App.Services.HttpClientService
{
	public class HttpClientService : IHttpClientService
	{
		private const string BaseUrl = "https://api.pulselive.motogp.com/motogp";

		private readonly IFlurlClient _flurlClient;

		public HttpClientService(IFlurlClientBuilder flurlClientBuilder)
		{
			_flurlClient = flurlClientBuilder.Build();
			_flurlClient.BaseUrl = BaseUrl;
			_flurlClient.AllowAnyHttpStatus();
		}

		/// <summary>
		/// https://api.pulselive.motogp.com/motogp/v1/results/seasons
		/// </summary>
		/// <returns></returns>
		public Task<IList<Models.Seasons.Season>> GetSeasons()
		{
			return _flurlClient.Request("/v1/results/seasons")
				.GetJsonAsync<IList<Models.Seasons.Season>>();
		}

		/// <summary>
		/// https://api.pulselive.motogp.com/motogp/v1/results/categories?seasonUuid=e88b4e43-2209-47aa-8e83-0e0b1cedde6e
		/// </summary>
		/// <param name="seasonId"></param>
		/// <returns></returns>
		public Task<IList<Models.Categories.Category>> GetCategories(string seasonId)
		{
			return _flurlClient.Request("/v1/results/categories")
				.AppendQueryParam("seasonUuid", seasonId)
				.GetJsonAsync<IList<Models.Categories.Category>>();
		}

		/// <summary>
		/// https://api.pulselive.motogp.com/motogp/v1/results/seasons
		/// </summary>
		/// <param name="seasonYear"></param>
		/// <returns></returns>
		public Task<IList<Models.Events.Event>> GetEvents(string seasonYear)
		{
			return _flurlClient.Request("/v1/events")
				.AppendQueryParam("seasonYear", seasonYear)
				.GetJsonAsync<IList<Models.Events.Event>>();
		}

		/// <summary>
		/// https://api.pulselive.motogp.com/motogp/v2/results/world-standings?type=rider&season=e88b4e43-2209-47aa-8e83-0e0b1cedde6e&category=e8c110ad-64aa-4e8e-8a86-f2f152f6a942
		/// </summary>
		/// <param name="type"></param>
		/// <param name="seasonId"></param>
		/// <param name="categoryId"></param>
		/// <returns></returns>
		public Task<Models.WorldStanding.WorldStanding> GetWorldStandings(string type, string seasonId, string categoryId)
		{
			return _flurlClient
				.Request("/v2/results/world-standings")
				.AppendQueryParam("type", type)
				.AppendQueryParam("season", seasonId)
				.AppendQueryParam("category", categoryId)
				.GetJsonAsync<Models.WorldStanding.WorldStanding>();
		}

		/// <summary>
		/// https://api.pulselive.motogp.com/motogp/v2/results/classifications?session=a3d72de3-e81c-478a-9669-59727f722e4b&test=false
		/// </summary>
		/// <param name="sessionId"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public Task<ClassificationBase> GetClassifications(string sessionId)
		{
			return _flurlClient
				.Request("/v2/results/classifications")
				.AppendQueryParam("session", sessionId)
				.GetJsonAsync<ClassificationBase>();
		}

		/// <summary>
		/// https://api.pulselive.motogp.com/motogp/v1/results/sessions?eventUuid=dd266adb-3930-4099-a3d1-a9807362f048&categoryUuid=e8c110ad-64aa-4e8e-8a86-f2f152f6a942
		/// </summary>
		/// <param name="eventId"></param>
		/// <param name="categoryId"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public Task<IList<SessionBase>> GetSessions(string eventId, string categoryId)
		{
			return _flurlClient.Request("/v1/results/sessions")
				.AppendQueryParam("eventUuid", eventId)
				.AppendQueryParam("&categoryUuid", categoryId)
				.GetJsonAsync<IList<SessionBase>>();
		}

		/// <summary>
		/// https://api.pulselive.motogp.com/motogp/v1/timing-gateway/livetiming-lite
		/// </summary>
		/// <returns></returns>
		public Task<string> GetLiveTimingLite()
		{
			return _flurlClient.Request("/v1/timing-gateway/livetiming-lite")
				.GetStringAsync();
		}
	}
}