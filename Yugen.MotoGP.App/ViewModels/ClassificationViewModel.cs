using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Classifications;
using Yugen.MotoGP.App.Services.CategoryService;
using Yugen.MotoGP.App.Services.ClassificationService;
using Yugen.MotoGP.App.Services.NavigationService;
using Yugen.MotoGP.App.Services.SeasonService;
using Yugen.MotoGP.App.Services.SessionService;

namespace Yugen.MotoGP.App.ViewModels
{
	public partial class ClassificationViewModel : ObservableObject
	{
		private readonly IClassificationService _classificationService;
		private readonly INavigationService _navigationService;
		private readonly ISessionService _sessionService;
		private readonly ISeasonService _seasonService;
		private readonly ICategoryService _categoryService;

		[ObservableProperty]
		public partial List<Classification> Classifications { get; set; }

		public ClassificationViewModel(
			IClassificationService classificationService,
			INavigationService navigationService,
			ISessionService sessionService,
			ISeasonService seasonService,
			ICategoryService categoryService)
		{
			_classificationService = classificationService;
			_navigationService = navigationService;
			_sessionService = sessionService;
			_seasonService = seasonService;
			_categoryService = categoryService;

			_navigationService.Navigated += OnNavigationServiceNavigated;
		}

		private async void OnNavigationServiceNavigated(object sender, object e)
		{
			await GetCalendar(e as string);
		}

		private async Task GetCalendar(string eventId)
		{
			if (string.IsNullOrEmpty(eventId))
			{
				return;
			}

			var season = await _seasonService.GetCurrent();
			var seasonId = season?.Id;
			if (seasonId == null)
			{
				return;
			}

			var motoGp = await _categoryService.GetMotoGp(seasonId);
			if (motoGp == null)
			{
				return;
			}

			var sessions = await _sessionService.Get(eventId, motoGp.Id);

			var sessionId = sessions.First(static x => x.Type == "RAC").Id;

			var classification = await _classificationService.Get(sessionId);

			Classifications = classification.Classification;
		}
	}
}