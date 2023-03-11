using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;
using Yugen.MotoGP.App.Models;
using Yugen.MotoGP.App.Services;
using Yugen.MotoGP.App.Views;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly HttpClientService _httpClientService;
        private readonly NavigationService _navigationService;

        [ObservableProperty]
        private Calendar _calendar = new Calendar();
        public ObservableCollection<Rider> RiderCollection { get; set; } = new ObservableCollection<Rider>();

        public MainViewModel(
            HttpClientService httpClientService,
            NavigationService navigationService)
        {
            _httpClientService = httpClientService;
            _navigationService = navigationService;

            Get();
        }

        [RelayCommand]
        private void GoToLiveTiming(int liveTimingId)
        {
            _navigationService.Navigate<LiveTimingPage>(liveTimingId);
        }

        private async void Get()
        {
            Calendar = await _httpClientService.GetCalendar("2023");
            var response = await _httpClientService.GetLiveTiming(685);

            using var jsonDocument = JsonDocument.Parse(response);
            var ltJsonElement = jsonDocument
                .RootElement
                .GetProperty("lt");

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