using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Sessions;

namespace Yugen.MotoGP.App.Services.SessionService
{
	public interface ISessionService
	{
		Task<IList<SessionBase>> Get(string eventId, string categoryId);
	}
}