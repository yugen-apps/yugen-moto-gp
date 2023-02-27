using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views
{
    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            this.InitializeComponent();
            ViewModel = App.Current.Services.GetService<AppShellViewModel>();
        }

        public AppShellViewModel ViewModel { get; }
    }
}