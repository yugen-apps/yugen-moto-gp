using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views
{
    public sealed partial class LiveTimingPage : Page
    {
        public LiveTimingPage()
        {
            this.InitializeComponent();

            ViewModel = App.Current.Services.GetService<LiveTimingViewModel>();
        }

        public LiveTimingViewModel ViewModel { get; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel.Load(e.Parameter as int?);
        }
    }
}