using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Views
{
    public sealed partial class ClassificationPage : Page
    {
        public ClassificationPage()
        {
            this.InitializeComponent();

            ViewModel = App.Current.Services.GetService<ClassificationViewModel>();
        }

        public ClassificationViewModel ViewModel { get; }
    }
}