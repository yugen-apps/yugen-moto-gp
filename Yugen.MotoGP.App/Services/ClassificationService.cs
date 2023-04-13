using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Results.Classification;

namespace Yugen.MotoGP.App.Services;

public class ClassificationService : IClassificationService
{
    private readonly IHttpClientService _httpClientService;

    public ClassificationService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<ClassificationBase> GetClassification(string eventId)
    {
        var sessions = await _httpClientService.GetResultsSessions(eventId);
        var sessionId = sessions.First(x => x.Type == "RAC").Id;
        return await _httpClientService.GetResultsClassification(sessionId);
    }
}