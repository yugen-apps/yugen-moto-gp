using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using Yugen.MotoGP.App.Services.NavigationService;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views
{
	public sealed partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();

			ExtendsContentIntoTitleBar = true;
			SetTitleBar(AppTitleBar);
			AppWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;
			AppWindow.SetIcon("Assets/AppIcon.ico");

			NavFrame.NavigationFailed += OnNavigationFailed;

			ViewModel = App.Current.Services.GetService<MainViewModel>();

			ViewModel.Initialize(NavFrame);
		}

		private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void TitleBar_PaneToggleRequested(TitleBar sender, object args)
		{
			NavView.IsPaneOpen = !NavView.IsPaneOpen;
		}

		private void TitleBar_BackRequested(TitleBar sender, object args)
		{
			NavFrame.GoBack();
		}

		private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
		{
			if (args.IsSettingsSelected)
			{
				ViewModel.NavigateCommand.Execute(MenuItemType.Settings);
			}
			else if (args.SelectedItem is MenuItem item)
			{
				ViewModel.NavigateCommand.Execute(item.Tag);
			}
		}

		public MainViewModel ViewModel { get; }
	}
}