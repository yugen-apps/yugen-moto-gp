using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        private readonly ICalendarService _calendarService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<EventObservableObject> _events;

        public CalendarViewModel(
            ICalendarService calendarService,
            INavigationService navigationService)
        {
            _calendarService = calendarService;
            _navigationService = navigationService;

            LoadCommand = new AsyncRelayCommand(async () =>
            {
                await Get();
            });
        }

        public IAsyncRelayCommand LoadCommand { get; }

        private async Task Get()
        {
            var events = await _calendarService.GetCalendar();
            Events = new ObservableCollection<EventObservableObject>(events.Select(@event => new EventObservableObject(@event)));
        }
    }
}