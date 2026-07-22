using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views;

public sealed partial class LiveTimingPage : Page
{
    public LiveTimingPage()
    {
        this.InitializeComponent();

        ViewModel = App.Current.Services.GetService<LiveTimingViewModel>();
    }

    public LiveTimingViewModel ViewModel { get; }
}