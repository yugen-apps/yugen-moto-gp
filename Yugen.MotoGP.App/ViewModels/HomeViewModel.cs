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

namespace Yugen.MotoGP.App.ViewModels
{
	public partial class HomeViewModel : ObservableObject
    {
        private readonly ICalendarService _calendarService;
        private readonly ILiveTimingService _liveTimingService;
        private readonly INavigationService _navigationService;
        private readonly DispatcherQueue _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

		[ObservableProperty]
		public partial Head Head { get; set; } = new Head();

		[ObservableProperty]
		public partial ObservableCollection<EventObservableObject> Events { get; set; }

		[ObservableProperty]
		public partial bool IsCalendarLoading { get; set; }

		public HomeViewModel(
            ICalendarService calendarService,
            ILiveTimingService liveTimingService,
            INavigationService navigationService)
        {
            _calendarService = calendarService;
            _liveTimingService = liveTimingService;
            _navigationService = navigationService;

            _liveTimingService.LiveTimingChanged += OnLiveTimingChanged;
            _navigationService.NavigatingFrom += OnNavigationServiceNavigatingFrom;

            LoadCommand = new AsyncRelayCommand(async () =>
            {
                await GetCalendar();

                await InitializeLiveTiming();
            });
        }

        public IAsyncRelayCommand LoadCommand { get; }

        public bool IsFinished => Head?.SessionStatusId == "F";

        public ObservableCollection<RiderDetailsObservableObject> RiderCollection { get; set; } = new();

        private void OnNavigationServiceNavigatingFrom(object sender, System.EventArgs e)
        {
            if (sender == this)
            {
                return;
            }

            _liveTimingService.DeInitialize();
            _navigationService.NavigatingFrom -= OnNavigationServiceNavigatingFrom;
        }

        [RelayCommand]
        private void GoToLiveTiming()
        {
            _navigationService.Navigate<LiveTimingViewModel>();
        }

        [RelayCommand]
        private void GoToClassification(string id)
        {
            _navigationService.Navigate<ClassificationViewModel>(id);
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

                OnPropertyChanged(nameof(IsFinished));
            });
        }
    }
}