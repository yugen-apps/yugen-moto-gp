using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI;
using Microsoft.UI.Dispatching;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Helpers;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTimingLites;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services.AppService;
using Yugen.MotoGP.App.Services.ConfigService;
using Yugen.MotoGP.App.Services.LiveTimingService;
using Yugen.MotoGP.App.Services.NavigationService;

namespace Yugen.MotoGP.App.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly IAppService _appService;
    private readonly IConfigService _configService;
    private readonly ILiveTimingService _liveTimingService;
    private readonly INavigationService _navigationService;
    private readonly DispatcherQueue _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

    [ObservableProperty]
    public partial Head Head { get; set; } = new Head();

    [ObservableProperty]
    public partial ObservableCollection<EventObservableObject> Events { get; set; }

    [ObservableProperty]
    public partial bool IsCalendarLoading { get; set; }

    public bool IsFinished => SessionStatusHelper.GetSessionStatus(Head?.SessionStatusId) == SessionStatus.Finished;

    public ObservableCollection<RiderObservableObject> RiderCollection { get; set; } = [];

    public HomeViewModel(
        IAppService appService,
        IConfigService configService,
        ILiveTimingService liveTimingService,
        INavigationService navigationService)
    {
        _appService = appService;
        _configService = configService;
        _liveTimingService = liveTimingService;
        _navigationService = navigationService;

        _liveTimingService.LiveTimingChanged += OnLiveTimingChanged;
    }

    [RelayCommand]
    private async Task Load()
    {
        await GetCalendar();

        await InitializeLiveTiming();
    }

    [RelayCommand]
    private async Task UnLoad()
    {
        _liveTimingService.DeInitialize();
    }

    [RelayCommand]
    private void GoToLiveTiming()
    {
        _navigationService.Navigate(MenuItemType.LiveTiming);
    }

    [RelayCommand]
    private void GoToClassification(string id)
    {
        _navigationService.Navigate(MenuItemType.Classification, id);
    }

    private async Task GetCalendar()
    {
        IsCalendarLoading = true;
        var events = await _appService.GetEvents(_configService.CurrentSeasonId);
        Events = new ObservableCollection<EventObservableObject>(
            events.Select(e => new EventObservableObject(e, _appService.GetEventDetails(e.ToadApiUuid)))
        );
        IsCalendarLoading = false;
    }

    private async Task InitializeLiveTiming()
    {
        await _liveTimingService.Initialize();
    }

    private void OnLiveTimingChanged(object sender, LiveTimingEventArgs liveTimingEventArgs)
    {
        _ = _dispatcherQueue.EnqueueAsync(() =>
        {
            this.Head = liveTimingEventArgs.Head;

            RiderCollection.Clear();
            foreach (var rider in liveTimingEventArgs.RiderDtoList)
            {
                RiderCollection.Add(new RiderObservableObject(rider));
            }

            OnPropertyChanged(nameof(IsFinished));
        });
    }
}