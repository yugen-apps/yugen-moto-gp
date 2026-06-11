using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Yugen.MotoGP.App.Services.NavigationService;

namespace Yugen.MotoGP.App.ViewModels
{
	public partial class MainViewModel : ObservableObject
	{
		private readonly INavigationService _navigationService;

		public MainViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public void Initialize(Frame navFrame)
		{
			_navigationService.InitializeRootFrame(navFrame);

			_navigationService.Navigate(MenuItemType.Home);
		}

		[RelayCommand]
		private void Navigate(MenuItemType tag)
		{
			_navigationService.Navigate(tag);
		}
	}
}