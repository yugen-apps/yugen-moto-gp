using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Results.Classification;

namespace Yugen.MotoGP.App.Services;

public interface IClassificationService
{
    Task<ClassificationBase> GetClassification(string id);
}