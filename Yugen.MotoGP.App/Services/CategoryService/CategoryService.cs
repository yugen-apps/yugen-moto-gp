using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Categories;
using Yugen.MotoGP.App.Services.HttpClientService;

namespace Yugen.MotoGP.App.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
		private readonly IHttpClientService _httpClientService;

		private IList<Category> _categories;

		public CategoryService(IHttpClientService httpClientService)
		{
			_httpClientService = httpClientService;
		}

		public async Task<IList<Category>> Get(string seasonId)
		{
			_categories ??= await _httpClientService.GetCategories(seasonId);

			return _categories;
		}

		public async Task<Category> GetMotoGp(string seasonId)
		{
			var categories = await Get(seasonId);

			return categories.FirstOrDefault(c => c.Name.Contains("MotoGP"));
		}
	}
}