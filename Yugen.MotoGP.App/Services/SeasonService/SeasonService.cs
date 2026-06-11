using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Services.HttpClientService;

namespace Yugen.MotoGP.App.Services.SeasonService
{
	public class SeasonService : ISeasonService
	{
		private readonly IHttpClientService _httpClientService;

		private IList<Models.Seasons.Season> _seasons;

		public SeasonService(IHttpClientService httpClientService)
		{
			_httpClientService = httpClientService;
		}

		public async Task<IList<Models.Seasons.Season>> Get()
		{
			_seasons ??= await _httpClientService.GetSeasons();

			return _seasons;
		}

		public async Task<Models.Seasons.Season> GetCurrent()
		{
			var seasons = await Get();
			return seasons.FirstOrDefault(x => x.Current);
		}
	}
}