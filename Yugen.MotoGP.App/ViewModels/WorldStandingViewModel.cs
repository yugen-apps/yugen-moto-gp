using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Yugen.MotoGP.App.Models.WorldStanding;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class WorldStandingViewModel : ObservableObject
    {
        private readonly IHttpClientService _httpClientService;

        [ObservableProperty]
        private WorldStandingBase _worldStanding = new WorldStandingBase();

        [ObservableProperty]
        private ObservableCollection<ClassificationViewModel> _standingList;

        public WorldStandingViewModel(
            IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;

            Get();
        }

        private async void Get()
        {
            WorldStanding = await _httpClientService.GetWorldStanding();
            StandingList = new ObservableCollection<ClassificationViewModel>(WorldStanding.Classification.Select(x => new ClassificationViewModel(x)));
        }
    }
}