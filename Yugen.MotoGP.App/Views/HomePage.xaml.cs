using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views
{
	public sealed partial class HomePage : Page
	{
		public HomePage()
		{
			this.InitializeComponent();
			ViewModel = App.Current.Services.GetService<HomeViewModel>();
		}

		public HomeViewModel ViewModel { get; }
	}
}