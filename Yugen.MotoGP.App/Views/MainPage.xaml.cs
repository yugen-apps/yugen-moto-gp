using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = App.Current.Services.GetService<MainViewModel>();
        }

        public MainViewModel ViewModel { get; }
    }
}
