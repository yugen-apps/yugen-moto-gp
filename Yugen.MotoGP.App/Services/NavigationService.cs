using Microsoft.UI.Xaml.Controls;

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
            _frame = frame;
        }

        public void InitializeRootFrame(Frame frame)
        {
            _frame = frame;
        }

        public bool CanGoBack => _frame.CanGoBack;

        public void GoBack() => _frame.GoBack();

        public void Navigate<T>()
        {
            _frame.Navigate(typeof(T));
            //this.frame.Navigate(this.viewMapping[typeof(T)]);
        }

        public void Navigate<T>(object args)
        {
            _frame.Navigate(typeof(T), args);
            //this.frame.Navigate(this.viewMapping[typeof(T)], args);
        }
    }
}