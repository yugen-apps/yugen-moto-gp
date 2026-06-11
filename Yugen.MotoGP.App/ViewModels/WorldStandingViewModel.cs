using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Results.WorldStanding;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class WorldStandingViewModel : ObservableObject
    {
        private readonly IWorldStandingService _worldStandingService;

		[ObservableProperty]
		public partial WorldStandingBase WorldStanding { get; set; } = new WorldStandingBase();

		[ObservableProperty]
		public partial ObservableCollection<ClassificationObservableObject> StandingList { get; set; }

		public WorldStandingViewModel(IWorldStandingService worldStandingService)
        {
            _worldStandingService = worldStandingService;

            LoadCommand = new AsyncRelayCommand(async () =>
            {
                await Get();
            });
        }

        public IAsyncRelayCommand LoadCommand { get; }

        private async Task Get()
        {
            WorldStanding = await _worldStandingService.GetWorldStanding();
            StandingList = new ObservableCollection<ClassificationObservableObject>(WorldStanding.Classification.Select(x => new ClassificationObservableObject(x)));
        }
    }
}