using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.WorldStanding;
using Yugen.MotoGP.App.Services.WorldStandingService;

namespace Yugen.MotoGP.App.ViewModels
{
	public partial class WorldStandingViewModel : ObservableObject
	{
		private readonly IWorldStandingService _worldStandingService;

		[ObservableProperty]
		public partial WorldStanding WorldStanding { get; set; } = new WorldStanding();

		[ObservableProperty]
		public partial List<RiderBase> Riders { get; set; } = new List<RiderBase>();

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
			Riders = WorldStanding.Classification.Rider;
		}
	}
}