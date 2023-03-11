using CommunityToolkit.Mvvm.ComponentModel;
using Yugen.MotoGP.App.Models.WorldStanding;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class WorldStandingViewModel : ObservableObject
    {
        private readonly HttpClientService _httpClientService;

        [ObservableProperty]
        private WorldStandingBase _worldStanding = new WorldStandingBase();

        public WorldStandingViewModel(
            HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;

            Get();
        }

        private async void Get()
        {
            this.WorldStanding = await _httpClientService.GetWorldStanding();
        }
    }
}