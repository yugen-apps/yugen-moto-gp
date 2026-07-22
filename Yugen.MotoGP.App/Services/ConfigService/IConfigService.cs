using System.Collections.Generic;
using Yugen.MotoGP.App.Models.Categories;
using Yugen.MotoGP.App.Models.Seasons;

namespace Yugen.MotoGP.App.Services.ConfigService;

public interface IConfigService
{
    string CurrentSeasonId { get; set; }

    string CurrentCategoryId { get; set; }

    string CurrentWorldStandingType { get; set; }

    IList<CategoryDto> Categories { get; set; }
    IList<SeasonDto> Seasons { get; set; }
}