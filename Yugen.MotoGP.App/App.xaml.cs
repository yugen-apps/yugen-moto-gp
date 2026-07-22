using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using Yugen.MotoGP.App.Services.AppService;
using Yugen.MotoGP.App.Services.ConfigService;
using Yugen.MotoGP.App.Services.HttpClientService;
using Yugen.MotoGP.App.Services.LiveTimingService;
using Yugen.MotoGP.App.Services.NavigationService;
using Yugen.MotoGP.App.ViewModels;
using Yugen.MotoGP.App.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Yugen.MotoGP.App;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// The main application window. Use <c>App.Window</c> from any class that needs
    /// the window reference (for dialogs, pickers, interop, etc.).
    /// </summary>
    public static Window Window { get; private set; } = null!;

    /// <summary>
    /// The UI thread dispatcher. Use <c>App.DispatcherQueue</c> to marshal calls
    /// to the UI thread. Fully qualified to avoid CS0104 ambiguity with
    /// <see cref="Windows.System.DispatcherQueue"/>.
    /// </summary>
    public static Microsoft.UI.Dispatching.DispatcherQueue DispatcherQueue { get; private set; } = null!;

    /// <summary>
    /// The native window handle (HWND). Use for file pickers,
    /// <c>DataTransferManager</c>, and any WinRT interop that requires
    /// <c>InitializeWithWindow</c>.
    /// </summary>
    public static nint WindowHandle =>
        WinRT.Interop.WindowNative.GetWindowHandle(Window);

    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    /// <summary>
    /// Initializes the singleton application object.
    /// </summary>
    public App()
    {
        Services = ConfigureServices();

        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        Window = new MainWindow();
        DispatcherQueue = Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();
        Window.Activate();
    }

    private static IServiceProvider ConfigureServices() => new ServiceCollection()
            .AddTransient<CalendarViewModel>()
            .AddTransient<ClassificationViewModel>()
            .AddTransient<LiveTimingViewModel>()
            .AddTransient<HomeViewModel>()
            .AddTransient<MainViewModel>()
            .AddTransient<WorldStandingViewModel>()
            .AddSingleton<IAppService, AppService>()
            .AddSingleton<IConfigService, ConfigService>()
            .AddSingleton<IFlurlClientBuilder, FlurlClientBuilder>()
            .AddSingleton<IHttpClientService, HttpClientService>()
            //.AddSingleton<IHttpClientService, LocalDataService>()
            .AddSingleton<ILiveTimingService, LiveTimingService>()
            .AddSingleton<INavigationService, NavigationService>()
            .BuildServiceProvider();
}
