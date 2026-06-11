using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.ObservableObjects;
using Yugen.MotoGP.App.Services;

namespace Yugen.MotoGP.App.ViewModels
{
    public partial class ClassificationViewModel : ObservableObject
    {
        private readonly IClassificationService _classificationService;
        private readonly INavigationService _navigationService;

		[ObservableProperty]
		public partial ObservableCollection<ResultClassificationObservableObject> ClassificationCollection { get; set; }

		public ClassificationViewModel(
            IClassificationService classificationService,
            INavigationService navigationService)
        {
            _classificationService = classificationService;
            _navigationService = navigationService;

            _navigationService.Navigated += OnNavigationServiceNavigated;
        }

        private async void OnNavigationServiceNavigated(object sender, object e)
        {
            await GetCalendar(e as string);
        }

        private async Task GetCalendar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            var classificationBase = await _classificationService.GetClassification(id);
            ClassificationCollection = new ObservableCollection<ResultClassificationObservableObject>(
                classificationBase.Classification.Select(@classification =>
                    new ResultClassificationObservableObject(@classification)));
        }
    }
}