using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using Yugen.MotoGP.App.Models;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly HttpClientService _httpClientService;

        private DispatcherTimer dispatcherTimer;

        public MainViewModel(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;

            Get();

            //SetTimer();
        }

        public ObservableCollection<Rider> RiderCollection { get; set; } = new ObservableCollection<Rider>();

        //[ObservableProperty]
        //private IMediaPlaybackSource _mediaPlaybackSource;

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
            //var response1 = await _httpClientService.GetCalendar("2023");

            var response = await _httpClientService.GetLiveTiming("685");

            using var jsonDocument = JsonDocument.Parse(response);
            var riderJsonElement = jsonDocument
                .RootElement
                .GetProperty("lt")
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