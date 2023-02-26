using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
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
        private Window _window;
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

        public Window Window => _window;

        public IServiceProvider Services { get; }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            _window = new MainWindow();

            // Create a Frame to act as the navigation context.
            _rootFrame = new Frame();

            _rootFrame.NavigationFailed += OnNavigationFailed;

            InitializeServices();

            // Place the frame in the current Window
            _window.Content = _rootFrame;

            _navigationService.Navigate<MainPage>(args.Arguments);

            _window.Activate();
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddTransient<LiveTimingViewModel>()
                .AddTransient<MainViewModel>()
                .AddSingleton<NavigationService>(sp => new NavigationService(_rootFrame))
                .AddSingleton<HttpClientService>()
                .BuildServiceProvider();
        }

        private void InitializeServices()
        {
            _navigationService = Services.GetService<NavigationService>();
        }
    }
}