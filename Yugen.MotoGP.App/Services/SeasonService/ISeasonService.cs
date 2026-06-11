using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Seasons;

namespace Yugen.MotoGP.App.Services.SeasonService
{
	public interface ISeasonService
	{
		Task<IList<Season>> Get();
		Task<Season> GetCurrent();
	}
}