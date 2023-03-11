using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Yugen.MotoGP.App.Services;
using Yugen.MotoGP.App.Views;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        private readonly NavigationService _navigationService;

        public AppShellViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void GoToCalendar()
        {
            _navigationService.Navigate<CalendarPage>();
        }

        [RelayCommand]
        private void GoToMain()
        {
            _navigationService.Navigate<MainPage>();
        }

        [RelayCommand]
        private void GoToLiveTiming()
        {
            _navigationService.Navigate<LiveTimingPage>();
        }

        [RelayCommand]
        private void GoToWorldStanding()
        {
            _navigationService.Navigate<WorldStandingPage>();
        }
    }
}