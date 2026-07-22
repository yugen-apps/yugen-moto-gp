using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.WorldStandings;
using Yugen.MotoGP.App.Services.AppService;
using Yugen.MotoGP.App.Services.ConfigService;

namespace Yugen.MotoGP.App.ViewModels;

public partial class WorldStandingViewModel : ObservableObject
{
    private readonly IAppService _appService;
    private readonly IConfigService _configService;

    [ObservableProperty]
    public partial WorldStandingDto WorldStanding { get; set; } = new WorldStandingDto();

    [ObservableProperty]
    public partial List<RiderDto> Riders { get; set; } = new List<RiderDto>();

    public WorldStandingViewModel(
        IAppService appService, 
        IConfigService configService)
    {
        _appService = appService;
        _configService = configService;
    }

    [RelayCommand]
    private async Task Load()
    {
        await Get();
    }

    private async Task Get()
    {
        if (_configService.CurrentWorldStandingType == "rider")
        {
            WorldStanding = await _appService.GetWorldStanding(_configService.CurrentWorldStandingType, _configService.CurrentSeasonId, _configService.CurrentCategoryId);
            Riders = WorldStanding.Classification.Rider;
        }
    }
}