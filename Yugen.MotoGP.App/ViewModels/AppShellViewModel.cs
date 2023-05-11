using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public AppShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void GoToCalendar()
        {
            _navigationService.Navigate<CalendarViewModel>();
        }

        [RelayCommand]
        private void GoToMain()
        {
            _navigationService.Navigate<MainViewModel>();
        }

        [RelayCommand]
        private void GoToLiveTiming()
        {
            _navigationService.Navigate<LiveTimingViewModel>();
        }

        [RelayCommand]
        private void GoToWorldStanding()
        {
            _navigationService.Navigate<WorldStandingViewModel>();
        }
    }
}