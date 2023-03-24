using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Yugen.MotoGP.App.Models.WorldStanding;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class WorldStandingViewModel : ObservableObject
    {
        private readonly IWorldStandingService _worldStandingService;

        [ObservableProperty]
        private WorldStandingBase _worldStanding = new WorldStandingBase();

        [ObservableProperty]
        private ObservableCollection<ClassificationObservableObject> _standingList;

        public WorldStandingViewModel(IWorldStandingService worldStandingService)
        {
            _worldStandingService = worldStandingService;

            Get();
        }

        private async void Get()
        {
            WorldStanding = await _worldStandingService.GetWorldStanding();
            StandingList = new ObservableCollection<ClassificationObservableObject>(WorldStanding.Classification.Select(x => new ClassificationObservableObject(x)));
        }
    }
}