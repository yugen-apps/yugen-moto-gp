using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using Yugen.MotoGP.App.ViewModels;
using Yugen.MotoGP.App.Views;

namespace Yugen.MotoGP.App.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> _viewMapping = new()
        {
            [typeof(CalendarViewModel)] = typeof(CalendarPage),
            [typeof(ClassificationViewModel)] = typeof(ClassificationPage),
            [typeof(LiveTimingViewModel)] = typeof(LiveTimingPage),
            [typeof(MainViewModel)] = typeof(MainPage),
            [typeof(WorldStandingViewModel)] = typeof(WorldStandingPage)
        };

        private Frame _frame;

        public NavigationService(Frame frame)
        {
            InitializeFrame(frame);
        }

        public event EventHandler<object> Navigated;

        public event EventHandler NavigatingFrom;

        public bool CanGoBack => _frame.CanGoBack;

        public void InitializeRootFrame(Frame frame)
        {
            InitializeFrame(frame);
        }

        public void GoBack() => _frame.GoBack();

        public void Navigate<T>()
        {
            NavigatingFrom?.Invoke(typeof(T), EventArgs.Empty);
            _frame.Navigate(_viewMapping[typeof(T)]);
        }

        public void Navigate<T>(object args)
        {
            NavigatingFrom?.Invoke(typeof(T), EventArgs.Empty);
            _frame.Navigate(_viewMapping[typeof(T)], args);
        }

        private void InitializeFrame(Frame frame)
        {
            _frame = frame;
            if (_frame == null)
            {
                return;
            }

            _frame.Navigated += OnFrameNavigated;
        }

        private void OnFrameNavigated(object sender, NavigationEventArgs e)
        {
            Navigated?.Invoke(sender, e.Parameter);
        }
    }
}