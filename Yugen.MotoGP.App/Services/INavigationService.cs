using Microsoft.UI.Xaml.Controls;
using System;

namespace Yugen.MotoGP.App.Services
{
    public interface INavigationService
    {
        event EventHandler<object> Navigated;

        event EventHandler NavigatingFrom;

        bool CanGoBack { get; }

        void InitializeRootFrame(Frame frame);

        void Navigate<T>();

        void Navigate<T>(object args);
    }
}