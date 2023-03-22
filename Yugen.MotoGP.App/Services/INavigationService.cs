using Microsoft.UI.Xaml.Controls;

namespace Yugen.MotoGP.App.Services
{
    public interface INavigationService
    {
        bool CanGoBack { get; }

        void InitializeRootFrame(Frame frame);

        void Navigate<T>();

        void Navigate<T>(object args);
    }
}