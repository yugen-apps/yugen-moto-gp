using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Services.HttpClientService;

namespace Yugen.MotoGP.App.Services.ClassificationService;

public class ClassificationService : IClassificationService
{
	private readonly IHttpClientService _httpClientService;

	public ClassificationService(IHttpClientService httpClientService)
	{
		_httpClientService = httpClientService;
	}

	public async Task<ClassificationBase> Get(string sessionId)
	{
		return await _httpClientService.GetClassifications(sessionId);
	}
}
