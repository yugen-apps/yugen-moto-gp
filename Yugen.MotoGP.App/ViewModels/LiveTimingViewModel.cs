using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.WinUI;
using Microsoft.UI.Dispatching;
using System.Collections.ObjectModel;
using Yugen.MotoGP.App.Models.Args;
using Yugen.MotoGP.App.Models.LiveTimingLites;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services.LiveTimingService;
using Yugen.MotoGP.App.Services.NavigationService;

namespace Yugen.MotoGP.App.ViewModels
{
	public partial class LiveTimingViewModel : ObservableObject
	{
		private readonly ILiveTimingService _liveTimingService;
		private readonly INavigationService _navigationService;
		private readonly DispatcherQueue _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

		[ObservableProperty]
		public partial Head Head { get; set; } = new Head();

		public LiveTimingViewModel(
			ILiveTimingService liveTimingService,
			INavigationService navigationService)
		{
			_liveTimingService = liveTimingService;
			_navigationService = navigationService;

			_liveTimingService.LiveTimingChanged += OnLiveTimingChanged;
			_navigationService.NavigatingFrom += OnNavigationServiceNavigatingFrom;
			_navigationService.Navigated += OnNavigationServiceNavigated;
		}

		public bool IsFinished => Head?.SessionStatusId == "F";

		public ObservableCollection<RiderDetailsObservableObject> RiderCollection { get; set; } = new();

		private async void OnNavigationServiceNavigated(object sender, object e)
		{
			await _liveTimingService.Initialize();
			_navigationService.Navigated -= OnNavigationServiceNavigated;
		}

		private void OnNavigationServiceNavigatingFrom(object sender, System.EventArgs e)
		{
			if (sender == this)
			{
				return;
			}

			_liveTimingService.DeInitialize();
			_navigationService.NavigatingFrom -= OnNavigationServiceNavigatingFrom;
		}

		private void OnLiveTimingChanged(object sender, LiveTimingEventArgs liveTimingEventArgs)
		{
			_ = _dispatcherQueue.EnqueueAsync(() =>
			{
				this.Head = liveTimingEventArgs.Head;

				RiderCollection.Clear();
				foreach (var rider in liveTimingEventArgs.RiderDetailsList)
				{
					var r = new RiderDetailsObservableObject(rider);
					RiderCollection.Add(r);
				}
			});
		}
	}
}