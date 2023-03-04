using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using Yugen.MotoGP.App.Models;
using Yugen.MotoGP.App.Services;
using Yugen.MotoGP.App.Views;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        private readonly HttpClientService _httpClientService;
        private readonly NavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<EventViewModel> _events;

        public CalendarViewModel(
            HttpClientService httpClientService,
            NavigationService navigationService)
        {
            _httpClientService = httpClientService;
            _navigationService = navigationService;

            Get();
        }

        private async void Get()
        {
            var calendar = await _httpClientService.GetCalendar("2023");
            Events = new ObservableCollection<EventViewModel>(calendar.events.Select(@event => new EventViewModel(@event)));
        }
    }
}