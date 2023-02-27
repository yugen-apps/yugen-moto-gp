using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using Yugen.MotoGP.App.Models;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class LiveTimingViewModel : ObservableObject
    {
        private readonly HttpClientService _httpClientService;

        private DispatcherTimer dispatcherTimer;
        private int _liveTimingId;

        [ObservableProperty]
        private Head _head = new Head();

        public LiveTimingViewModel(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public ObservableCollection<Rider> RiderCollection { get; set; } = new ObservableCollection<Rider>();

        public void Load(int? liveTimingId)
        {
            if (liveTimingId == null)
            {
                return;
            }

            _liveTimingId = (int)liveTimingId;

            Get();

            //SetTimer();
        }

        private void SetTimer()
        {
            dispatcherTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            dispatcherTimer.Tick += (s, e) => Get();
            dispatcherTimer.Start();
        }

        private async void Get()
        {
            var response = await _httpClientService.GetLiveTiming(_liveTimingId);

            using var jsonDocument = JsonDocument.Parse(response);
            var ltJsonElement = jsonDocument
                .RootElement
                .GetProperty("lt");

            this.Head = ltJsonElement
                .GetProperty("head")
                .Deserialize<Head>();

            var riderJsonElement = ltJsonElement
                .GetProperty("rider");

            RiderCollection.Clear();
            foreach (var riderJson in riderJsonElement.EnumerateObject())
            {
                //System.Diagnostics.Debug.WriteLine($"{riderJson.Name}: {riderJson.Value}");
                var rider = riderJson.Value.Deserialize<Rider>();
                RiderCollection.Add(rider);
            }
        }
    }
}