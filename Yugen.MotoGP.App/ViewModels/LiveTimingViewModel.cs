using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using Yugen.MotoGP.App.Models.LiveTiming;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class LiveTimingViewModel : ObservableObject
    {
        private readonly LiveTimingService _liveTimingService;

        [ObservableProperty]
        private Head _head = new Head();

        public LiveTimingViewModel(LiveTimingService liveTimingService)
        {
            _liveTimingService = liveTimingService;
            _liveTimingService.LiveTimingChanged += OnLiveTimingChanged;
        }

        public ObservableCollection<RiderDetails> RiderCollection { get; set; } = new ObservableCollection<RiderDetails>();

        public void Load(int? liveTimingId)
        {
            if (liveTimingId == null)
            {
                _liveTimingService.Initialize();
            }
            else
            {
                _liveTimingService.Initialize((int)liveTimingId);
            }
        }

        private void OnLiveTimingChanged(object sender, JsonElement ltJsonElement)
        {
            this.Head = ltJsonElement
                .GetProperty("head")
                .Deserialize<Head>();

            var riderJsonElement = ltJsonElement
                .GetProperty("rider");

            RiderCollection.Clear();
            foreach (var riderJson in riderJsonElement.EnumerateObject())
            {
                var rider = riderJson.Value.Deserialize<RiderDetails>();
                RiderCollection.Add(rider);
            }
        }
    }
}