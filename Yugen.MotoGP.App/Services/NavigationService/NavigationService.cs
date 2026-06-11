using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Yugen.MotoGP.App.ViewModels;
using Yugen.MotoGP.App.Views;

namespace Yugen.MotoGP.App.Services.NavigationService
{
	public class NavigationService : INavigationService
	{
		public static List<MenuItem> MenuItems => MenuDictionary.Values.ToList();

		public static Dictionary<MenuItemType, MenuItem> MenuDictionary => new()
		{
			[MenuItemType.Home] = new MenuItem(
				MenuItemType.Home,
				true,
				Symbol.Home,
				"&#xEA3A;",
				typeof(HomeViewModel),
				typeof(HomePage)
			),
			[MenuItemType.Calendar] = new MenuItem(
				MenuItemType.Calendar,
				false,
				Symbol.Calendar,
				"&#xEA3A;",
				typeof(CalendarViewModel),
				typeof(CalendarPage)
			),
			[MenuItemType.Classification] = new MenuItem(
				MenuItemType.Classification,
				false,
				Symbol.Calculator,
				"&#xEA3A;",
				typeof(ClassificationViewModel),
				typeof(ClassificationPage)
			),
			[MenuItemType.LiveTiming] = new MenuItem(
				MenuItemType.LiveTiming,
				false,
				Symbol.Clock,
				"&#xEA3A;",
				typeof(LiveTimingViewModel),
				typeof(LiveTimingPage)
			),
			[MenuItemType.WorldStanding] = new MenuItem(
				MenuItemType.WorldStanding,
				false,
				Symbol.World,
				"&#xEA3A;",
				typeof(WorldStandingViewModel),
				typeof(WorldStandingPage)
			),
			[MenuItemType.Settings] = new MenuItem(
				MenuItemType.Settings,
				false,
				Symbol.Setting,
				"&#xEA3A;",
				null,
				null
			)
		};

		private Frame _frame;

		public event EventHandler<object> Navigated;

		public event EventHandler NavigatingFrom;

		public bool CanGoBack => _frame.CanGoBack;

		public void InitializeRootFrame(Frame frame)
		{			
			InitializeFrame(frame);
		}

		public void GoBack() => _frame.GoBack();

		public void Navigate(MenuItemType tag, object args = null)
		{
			var menuItem = MenuDictionary[tag];
			NavigatingFrom?.Invoke(menuItem.ViewModel, EventArgs.Empty);
			_frame.Navigate(menuItem.Page, args);
		}

		private void InitializeFrame(Frame frame)
		{
			_frame = frame;
			if (_frame == null)
			{
				return;
			}

			_frame.Navigated += OnFrameNavigated;
		}

		private void OnFrameNavigated(object sender, NavigationEventArgs e)
		{
			Navigated?.Invoke(sender, e.Parameter);
		}
	}
}