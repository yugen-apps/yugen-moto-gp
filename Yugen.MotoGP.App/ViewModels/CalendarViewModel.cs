using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private Calendar _calendar = new Calendar();

        public CalendarViewModel(
            HttpClientService httpClientService,
            NavigationService navigationService)
        {
            _httpClientService = httpClientService;
            _navigationService = navigationService;
        }
    }
}