using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services.AppService;
using Yugen.MotoGP.App.Services.ConfigService;
using Yugen.MotoGP.App.Services.NavigationService;

namespace Yugen.MotoGP.App.ViewModels;

public partial class CalendarViewModel : ObservableObject
{
    private readonly IAppService _appService;
    private readonly IConfigService _configService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    public partial ObservableCollection<EventObservableObject> Events { get; set; }

    public CalendarViewModel(
        IAppService appService,
        IConfigService configService,
        INavigationService navigationService)
    {
        _appService = appService;
        _configService = configService;
        _navigationService = navigationService;
    }

    [RelayCommand]
    private async Task Load()
    {
        await Get();
    }

    [RelayCommand]
    private void GoToClassification(string id)
    {
        _navigationService.Navigate(MenuItemType.Classification, id);
    }

    private async Task Get()
    {
        var events = await _appService.GetEvents(_configService.CurrentSeasonId);
        Events = new ObservableCollection<EventObservableObject>(
            events.Select(e => new EventObservableObject(e, _appService.GetEventDetails(e.ToadApiUuid)))
        );
    }
}