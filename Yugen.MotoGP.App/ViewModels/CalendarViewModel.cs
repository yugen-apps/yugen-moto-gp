using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        private readonly IHttpClientService _httpClientService;
        private readonly NavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<EventObservableObject> _events;

        public CalendarViewModel(
            IHttpClientService httpClientService,
            NavigationService navigationService)
        {
            _httpClientService = httpClientService;
            _navigationService = navigationService;

            Get();
        }

        private async void Get()
        {
            var calendar = await _httpClientService.GetCalendar("2023");
            Events = new ObservableCollection<EventObservableObject>(calendar.Events.Select(@event => new EventObservableObject(@event)));
        }
    }
}