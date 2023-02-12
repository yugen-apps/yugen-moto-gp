using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
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
        private Window m_window;

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

        public Window Window => m_window;

        public IServiceProvider Services { get; }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddTransient<MainViewModel>()
                .AddSingleton<HttpClientService>()
                .BuildServiceProvider();
        }
    }
}
