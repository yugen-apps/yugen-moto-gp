using System.Collections.Generic;
using Yugen.MotoGP.App.Models.Categories;
using Yugen.MotoGP.App.Models.Seasons;

namespace Yugen.MotoGP.App.Services.ConfigService;

public class ConfigService : IConfigService
{
    public IList<CategoryDto> Categories  { get; set; }

    public IList<SeasonDto> Seasons { get; set; }

    public string CurrentCategoryId { get; set; }

    public string CurrentSeasonId { get; set; }

    public string CurrentWorldStandingType { get; set; } = WorldStandingTypes[0];

    public static string[] WorldStandingTypes => [
        "rider",
        "teaam",
        "constructor"
    ];
}