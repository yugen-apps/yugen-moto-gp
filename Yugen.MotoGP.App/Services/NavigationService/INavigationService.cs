using Microsoft.UI.Xaml.Controls;
using System;

namespace Yugen.MotoGP.App.Services.NavigationService
{
	public interface INavigationService
	{
		event EventHandler<object> Navigated;

		event EventHandler NavigatingFrom;

		bool CanGoBack { get; }

		void InitializeRootFrame(Frame frame);

		void Navigate(MenuItemType tag, object args = null);
	}
}