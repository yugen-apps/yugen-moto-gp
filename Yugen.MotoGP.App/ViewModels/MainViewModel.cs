using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI;
using Microsoft.UI.Dispatching;
using System.Collections.ObjectModel;
using System.Linq;
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

        public MainViewModel(
            ICalendarService calendarService,
            ILiveTimingService liveTimingService,
            INavigationService navigationService)
        {
            _calendarService = calendarService;
            _liveTimingService = liveTimingService;
            _navigationService = navigationService;
            _liveTimingService.LiveTimingChanged += OnLiveTimingChanged;

            GetCalendar();

            InitializeLiveTiming();
        }

        public ObservableCollection<RiderDetailsObservableObject> RiderCollection { get; set; } = new();

        [RelayCommand]
        private void GoToLiveTiming(int liveTimingId)
        {
            _navigationService.Navigate<LiveTimingPage>(liveTimingId);
        }

        private async void GetCalendar()
        {
            var events = await _calendarService.GetCalendar();
            Events = new ObservableCollection<EventObservableObject>(events.Select(@event => new EventObservableObject(@event)));
        }

        private void InitializeLiveTiming()
        {
            _liveTimingService.Initialize();
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