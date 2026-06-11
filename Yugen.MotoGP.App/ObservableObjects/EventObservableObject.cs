using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Globalization;
using Yugen.MotoGP.App.Constants;
using Yugen.MotoGP.App.Helpers;
using Yugen.MotoGP.App.Models.Events;
using Yugen.MotoGP.App.Services.ImageCacheService;

namespace Yugen.MotoGP.App.ObservableObjects
{
	public partial class EventObservableObject : ObservableObject
	{
		private readonly Event _event;
		private DateTime? DateStart => DateTime.TryParse(_event.DateStart, out var dateStart) ? dateStart : null;

		[ObservableProperty]
		public partial BitmapImage CardSource { get; set; }

		public EventObservableObject(Event eventModel)
		{
			_event = eventModel;
			LoadAssets();
		}

		public string Name => _event.Name;

		//public string FlagPath => AssetsHelper.GetDpiAwareAssetPath(_event.Assets, "flag");
		public string FlagPath => $"ms-appx:///Assets/Flags/{_event.Country}.svg";

		public string Hashtag => _event.Hashtag;



		public string StartDay => DateStart?.Day.ToString("00");

		public string StartMonth => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateStart?.Month ?? 1).ToUpperInvariant();

		public string StartDate => DateStart?.ToString(CultureInfo.CurrentCulture);

		public string Kind => _event.Kind;

		public string CircuitName => _event.Circuit?.Name ?? string.Empty;

		public string Status
		{
			get => _event.Status switch
			{
				ApiConstants.EventStatusCurrent => AppConstants.EventLiveTiming,
				ApiConstants.EventStatusFinished => AppConstants.EventResults,
				_ => string.Empty,
			};
		}

		public string CircuitCountry => _event.Circuit?.Country?.ToUpperInvariant() ?? string.Empty;

		public string Id => _event.Id;

		private async void LoadAssets()
		{
			CardSource = await ImageCacheService.GetFromCacheAsync(new Uri(AssetsHelper.GetDpiAwareAssetPath(_event.Assets, "card")));
		}
	}
}