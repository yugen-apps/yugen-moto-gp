using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.Season;
using Yugen.MotoGP.App.Models.WorldStanding;

namespace Yugen.MotoGP.App.Services
{
    public interface IWorldStandingService
    {
        Task<SeasonBase> GetCurrentSeason();
        Task<WorldStandingBase> GetWorldStanding(string seasonId = null);
    }
}