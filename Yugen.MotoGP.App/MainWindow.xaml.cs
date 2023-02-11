using Flurl;
using Flurl.Http;
using Microsoft.UI.Xaml;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using Yugen.MotoGP.App.Models;

namespace Yugen.MotoGP.App
{
    public sealed partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            this.InitializeComponent();

            Get();

            //SetTimer();
        }

        public ObservableCollection<Rider> RiderCollection { get; set; } = new ObservableCollection<Rider>();

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
            var response = await "https://www.motogp.com/en/json/live_timing"
                .AppendPathSegment("685")
                .GetStringAsync();
            //.GetJsonAsync<LiveTiming>();

            using var jsonDocument = JsonDocument.Parse(response);
            var riderJsonElement = jsonDocument
                .RootElement
                .GetProperty("lt")
                .GetProperty("rider");

            RiderCollection.Clear();
            foreach (var riderJson in riderJsonElement.EnumerateObject())
            {
                //System.Diagnostics.Debug.WriteLine($"{riderJson.Name}: {riderJson.Value}");
                var rider = JsonSerializer.Deserialize<Rider>(riderJson.Value);
                RiderCollection.Add(rider);
            }
        }
    }
}