using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Results.Season;
using Yugen.MotoGP.App.Models.Results.WorldStanding;

namespace Yugen.MotoGP.App.Services
{
    public class WorldStandingService : IWorldStandingService
    {
        private readonly IHttpClientService _httpClientService;

        private string _seasonId;
        private WorldStandingBase worldStanding;

        public WorldStandingService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<WorldStandingBase> GetWorldStanding(string seasonId = null)
        {
            if(seasonId == null)
            {
                var season = await GetCurrentSeason();
                seasonId = season?.Id;
            }

            _seasonId = seasonId;

            if(_seasonId == null)
            {
                return null;
            }

            worldStanding = worldStanding ?? await _httpClientService.GetResultsWorldStanding(_seasonId);
            return worldStanding;
        }

        public async Task<SeasonBase> GetCurrentSeason()
        {
            var seasons = await _httpClientService.GetResultsSeasons();
            return seasons.FirstOrDefault(x => x.Current);
        }
    }
}