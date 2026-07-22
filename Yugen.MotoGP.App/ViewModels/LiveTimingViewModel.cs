using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI;
using Microsoft.UI.Dispatching;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Helpers;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTimingLites;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services.LiveTimingService;
using Yugen.MotoGP.App.Services.NavigationService;

namespace Yugen.MotoGP.App.ViewModels;

public partial class LiveTimingViewModel : ObservableObject
{
    private readonly ILiveTimingService _liveTimingService;
    private readonly INavigationService _navigationService;
    private readonly DispatcherQueue _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

    [ObservableProperty]
    public partial Head Head { get; set; } = new Head();

    public bool IsFinished => SessionStatusHelper.GetSessionStatus(Head?.SessionStatusId) == SessionStatus.Finished;

    public ObservableCollection<RiderObservableObject> RiderCollection { get; set; } = [];

    public LiveTimingViewModel(
        ILiveTimingService liveTimingService,
        INavigationService navigationService)
    {
        _liveTimingService = liveTimingService;
        _navigationService = navigationService;

        _liveTimingService.LiveTimingChanged += OnLiveTimingChanged;
    }

    [RelayCommand]
    private async Task Load()
    {
        await _liveTimingService.Initialize();
    }

    [RelayCommand]
    private async Task UnLoad()
    {
        _liveTimingService.DeInitialize();
    }

    private void OnLiveTimingChanged(object sender, LiveTimingEventArgs liveTimingEventArgs)
    {
        _ = _dispatcherQueue.EnqueueAsync(() =>
        {
            this.Head = liveTimingEventArgs.Head;

            RiderCollection.Clear();
            foreach (var rider in liveTimingEventArgs.RiderDtoList)
            {
                var r = new RiderObservableObject(rider);
                RiderCollection.Add(r);
            }
        });
    }
}