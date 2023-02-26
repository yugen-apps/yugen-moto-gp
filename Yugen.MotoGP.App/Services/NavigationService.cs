using Microsoft.UI.Xaml.Controls;
using System.Threading.Tasks;

namespace Yugen.MotoGP.App.Services
{
    public class NavigationService
    {
        private readonly Frame frame;

        //private readonly Dictionary<Type, Type> viewMapping = new()
        //{
        //    [typeof(MainPageViewModel)] = typeof(MainPage)
        //};

        public NavigationService(Frame frame)
        {
            this.frame = frame;
        }

        public bool CanGoBack => this.frame.CanGoBack;

        public void GoBack() => this.frame.GoBack();

        public void Navigate<T>(object args)
        {
            this.frame.Navigate(typeof(T), args);
            //this.frame.Navigate(this.viewMapping[typeof(T)], args);
        }
    }
}
