using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Results.Season;
using Yugen.MotoGP.App.Models.Results.WorldStanding;

namespace Yugen.MotoGP.App.Services
{
    public interface IWorldStandingService
    {
        Task<SeasonBase> GetCurrentSeason();

        Task<WorldStandingBase> GetWorldStanding(string seasonId = null);
    }
}