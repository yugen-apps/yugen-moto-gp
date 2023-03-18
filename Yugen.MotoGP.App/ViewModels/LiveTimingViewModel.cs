using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.WinUI;
using Microsoft.UI.Dispatching;
using System.Collections.ObjectModel;
using System.Linq;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTiming;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class LiveTimingViewModel : ObservableObject
    {
        private readonly LiveTimingService _liveTimingService;
        private readonly DispatcherQueue _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

        [ObservableProperty]
        private Head _head = new Head();

        public LiveTimingViewModel(LiveTimingService liveTimingService)
        {
            _liveTimingService = liveTimingService;
            _liveTimingService.LiveTimingChanged += OnLiveTimingChanged;
        }

        public ObservableCollection<RiderDetailsViewModel> RiderCollection { get; set; } = new();


        public void Load(int? liveTimingId)
        {
            _liveTimingService.Initialize(liveTimingId);
        }

        private void OnLiveTimingChanged(object sender, LiveTimingEventArgs liveTimingEventArgs)
        {
            _ = _dispatcherQueue.EnqueueAsync(() =>
            {
                this.Head = liveTimingEventArgs.Head;

                RiderCollection.Clear();
                foreach (var rider in liveTimingEventArgs.RiderDetailsList)
                {
                    var r = new RiderDetailsViewModel(rider);
                    RiderCollection.Add(r);
                }
            });
        }
    }
}