using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Sessions;
using Yugen.MotoGP.App.Services.HttpClientService;

namespace Yugen.MotoGP.App.Services.SessionService;

public class SessionService : ISessionService
{
	private readonly IHttpClientService _httpClientService;

	public SessionService(IHttpClientService httpClientService)
	{
		_httpClientService = httpClientService;
	}

	public async Task<IList<SessionBase>> Get(string eventId, string categoryId)
	{
		return await _httpClientService.GetSessions(eventId, categoryId);
	}
}