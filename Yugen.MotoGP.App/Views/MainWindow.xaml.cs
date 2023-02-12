using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = App.Current.Services.GetService<MainViewModel>();
        }

        public MainViewModel ViewModel { get; }
    }
}