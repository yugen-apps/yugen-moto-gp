using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.WorldStanding;
using Yugen.MotoGP.App.Services.CategoryService;
using Yugen.MotoGP.App.Services.HttpClientService;
using Yugen.MotoGP.App.Services.SeasonService;

namespace Yugen.MotoGP.App.Services.WorldStandingService
{
	public class WorldStandingService : IWorldStandingService
	{
		private readonly IHttpClientService _httpClientService;
		private readonly ISeasonService _seasonService;
		private readonly ICategoryService _categoryService;

		private WorldStanding worldStanding;

		public WorldStandingService(
			IHttpClientService httpClientService,
			ISeasonService seasonService,
			ICategoryService categoryService)
		{
			_httpClientService = httpClientService;
			_seasonService = seasonService;
			_categoryService = categoryService;
		}

		public async Task<WorldStanding> GetWorldStanding()
		{
			var season = await _seasonService.GetCurrent();
			var seasonId = season?.Id;
			if (seasonId == null)
			{
				return null;
			}

			var motoGp = await _categoryService.GetMotoGp(seasonId);
			if (motoGp == null)
			{
				return null;
			}

			// TODO:
			worldStanding = worldStanding ?? await _httpClientService.GetWorldStandings("rider", seasonId, motoGp.Id);
			return worldStanding;
		}
	}
}