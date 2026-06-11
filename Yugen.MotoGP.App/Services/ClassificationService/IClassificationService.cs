using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Classifications;

namespace Yugen.MotoGP.App.Services.ClassificationService;

public interface IClassificationService
{
	Task<ClassificationBase> Get(string sessionId);
}