using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.WorldStanding;

namespace Yugen.MotoGP.App.Services.WorldStandingService
{
	public interface IWorldStandingService
	{
		Task<WorldStanding> GetWorldStanding();
	}
}