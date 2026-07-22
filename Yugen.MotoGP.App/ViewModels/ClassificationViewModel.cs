using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Services.AppService;
using Yugen.MotoGP.App.Services.ConfigService;
using Yugen.MotoGP.App.Services.NavigationService;

namespace Yugen.MotoGP.App.ViewModels;

public partial class ClassificationViewModel : ObservableObject
{
    private readonly IAppService _appService;
    private readonly IConfigService _configService;
    private readonly INavigationService _navigationService;
    private string _eventId;

    [ObservableProperty]
    public partial List<Classification> Classifications { get; set; }

    public ClassificationViewModel(
        IAppService appService,
        IConfigService configService,
        INavigationService navigationService)
    {
        _appService = appService;
        _configService = configService;
        _navigationService = navigationService;

        _navigationService.Navigated += OnNavigationServiceNavigated;
    }

    [RelayCommand]
    private async Task Load()
    {
        await GetCalendar(_eventId);
    }

    [RelayCommand]
    private async Task UnLoad()
    {
        _navigationService.Navigated -= OnNavigationServiceNavigated;
    }

    private async void OnNavigationServiceNavigated(object sender, object e)
    {
        _eventId = e as string;
    }

    private async Task GetCalendar(string eventId)
    {
        if (string.IsNullOrEmpty(eventId))
        {
            return;
        }

        var sessions = await _appService.GetSessions(eventId, _configService.CurrentCategoryId);

        var classification = await _appService.GetRaceClassifications(sessions);

        Classifications = classification?.Classification;
    }
}