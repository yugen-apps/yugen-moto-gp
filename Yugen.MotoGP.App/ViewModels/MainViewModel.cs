using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI;
using Microsoft.UI.Dispatching;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTiming;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services;
using Yugen.MotoGP.App.Views;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ICalendarService _calendarService;
        private readonly ILiveTimingService _liveTimingService;
        private readonly INavigationService _navigationService;
        private readonly DispatcherQueue _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

        [ObservableProperty]
        private Head _head = new Head();

        [ObservableProperty]
        private ObservableCollection<EventObservableObject> _events;

        [ObservableProperty]
        private bool _isCalendarLoading;

        public MainViewModel(
            ICalendarService calendarService,
            ILiveTimingService liveTimingService,
            INavigationService navigationService)
        {
            _calendarService = calendarService;
            _liveTimingService = liveTimingService;
            _navigationService = navigationService;
            _liveTimingService.LiveTimingChanged += OnLiveTimingChanged;

            LoadCommand = new AsyncRelayCommand(async () =>
            {
                await GetCalendar();

                await InitializeLiveTiming();
            });
            UnloadCommand = new RelayCommand(() =>
            {
                _liveTimingService.DeInitialize();
            });
        }

        public IAsyncRelayCommand LoadCommand { get; }

        public IRelayCommand UnloadCommand { get; }

        public ObservableCollection<RiderDetailsObservableObject> RiderCollection { get; set; } = new();

        [RelayCommand]
        private void GoToLiveTiming(int liveTimingId)
        {
            _navigationService.Navigate<LiveTimingPage>(liveTimingId);
        }

        private async Task GetCalendar()
        {
            IsCalendarLoading = true;
            var events = await _calendarService.GetCalendar();
            Events = new ObservableCollection<EventObservableObject>(events.Select(@event => new EventObservableObject(@event)));
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
                foreach (var rider in liveTimingEventArgs.RiderDetailsList)
                {
                    RiderCollection.Add(new RiderDetailsObservableObject(rider));
                }
            });
        }
    }
}