using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI;
using Microsoft.UI.Dispatching;
using System.Collections.ObjectModel;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.Calendar;
using Yugen.MotoGP.App.Models.LiveTiming;
using Yugen.MotoGP.App.Services;
using Yugen.MotoGP.App.Views;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IHttpClientService _httpClientService;
        private readonly LiveTimingService _liveTimingService;
        private readonly NavigationService _navigationService;
        private readonly DispatcherQueue _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

        [ObservableProperty]
        private CalendarBase _calendar = new CalendarBase();

        public MainViewModel(
            IHttpClientService httpClientService,
            LiveTimingService liveTimingService,
            NavigationService navigationService)
        {
            _httpClientService = httpClientService;
            _liveTimingService = liveTimingService;
            _navigationService = navigationService;
            _liveTimingService.LiveTimingChanged += OnLiveTimingChanged;

            GetCalendar();

            InitializeLiveTiming();
        }

        public ObservableCollection<RiderDetails> RiderCollection { get; set; } = new ObservableCollection<RiderDetails>();

        [RelayCommand]
        private void GoToLiveTiming(int liveTimingId)
        {
            _navigationService.Navigate<LiveTimingPage>(liveTimingId);
        }

        private async void GetCalendar()
        {
            this.Calendar = await _httpClientService.GetCalendar("2023");
        }

        private void InitializeLiveTiming()
        {
            _liveTimingService.Initialize();
        }

        private void OnLiveTimingChanged(object sender, LiveTimingEventArgs liveTimingEventArgs)
        {
            _ = _dispatcherQueue.EnqueueAsync(() =>
            {
                RiderCollection.Clear();
                foreach (var rider in liveTimingEventArgs.RiderDetailsList)
                {
                    RiderCollection.Add(rider);
                }
            });
        }
    }
}