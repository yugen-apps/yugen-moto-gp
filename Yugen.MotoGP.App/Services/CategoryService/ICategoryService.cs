using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Categories;

namespace Yugen.MotoGP.App.Services.CategoryService
{
	public interface ICategoryService
	{
		Task<IList<Category>> Get(string seasonId);
		Task<Category> GetMotoGp(string seasonId);
	}
}