using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace Yugen.MotoGP.App.Services
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;

        //private readonly Dictionary<Type, Type> viewMapping = new()
        //{
        //    [typeof(MainPageViewModel)] = typeof(MainPage)
        //};

        public NavigationService(Frame frame)
        {
            InitializeFrame(frame);
        }

        public bool CanGoBack => _frame.CanGoBack;

        public event EventHandler<object> Navigated;

        public event EventHandler NavigatingFrom;

        public void InitializeRootFrame(Frame frame)
        {
            InitializeFrame(frame);
        }

        public void GoBack() => _frame.GoBack();

        public void Navigate<T>()
        {
            NavigatingFrom?.Invoke(this, EventArgs.Empty);
            _frame.Navigate(typeof(T));
            //this.frame.Navigate(this.viewMapping[typeof(T)]);
        }

        public void Navigate<T>(object args)
        {
            NavigatingFrom?.Invoke(this, EventArgs.Empty);
            _frame.Navigate(typeof(T), args);
            //this.frame.Navigate(this.viewMapping[typeof(T)], args);
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