using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views
{
    public sealed partial class WorldStandingPage : Page
    {
        public WorldStandingPage()
        {
            this.InitializeComponent();
            ViewModel = App.Current.Services.GetService<WorldStandingViewModel>();
        }

        public WorldStandingViewModel ViewModel { get; }
    }
}