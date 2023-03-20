using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Flurl.Http.Configuration;
using Yugen.MotoGP.App.Services;
using Yugen.MotoGP.App.ViewModels;
using Yugen.MotoGP.App.Views;

namespace Yugen.MotoGP.App
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private Frame _rootFrame;
        private NavigationService _navigationService;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            var startupWindow = new Window
            {
                ExtendsContentIntoTitleBar = true
            };

            if (startupWindow.Content is not AppShell shell)
            {
                InitializeServices();
                shell = new AppShell { Language = ApplicationLanguages.Languages[0] };
                startupWindow.SetTitleBar(shell.AppTitleTextBlock);
                _rootFrame = shell.RootFrame;
                shell.RootFrame.NavigationFailed += OnNavigationFailed;
                startupWindow.Content = shell;
            }

            if (shell.RootFrame.Content == null)
            {
                _navigationService.frame = _rootFrame;

                _navigationService.Navigate<MainPage>(args.Arguments);
            }

            startupWindow.Activate();
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddTransient<AppShellViewModel>()
                .AddTransient<CalendarViewModel>()
                .AddTransient<LiveTimingViewModel>()
                .AddTransient<MainViewModel>()
                .AddTransient<WorldStandingViewModel>()
                .AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>()
                //.AddSingleton<IHttpClientService, HttpClientService>()
                .AddSingleton<IHttpClientService, LocalDataService>()
                .AddSingleton<ILiveTimingService, LiveTimingService>()
                .AddSingleton<NavigationService>(sp => new NavigationService(_rootFrame))
                .BuildServiceProvider();
        }

        private void InitializeServices()
        {
            _navigationService = Services.GetService<NavigationService>();
        }
    }
}