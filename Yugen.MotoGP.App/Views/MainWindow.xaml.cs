using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();

        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);
        AppWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;
        AppWindow.SetIcon("Assets/Store/AppIcon.ico");

        ViewModel = App.Current.Services.GetService<MainViewModel>();
        ViewModel.Initialize(NavFrame);
    }

    public MainViewModel ViewModel { get; }
}