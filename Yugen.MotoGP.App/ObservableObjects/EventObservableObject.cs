using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Globalization;
using Yugen.MotoGP.App.Constants;
using Yugen.MotoGP.App.Helpers;
using Yugen.MotoGP.App.Services.ImageCacheService;

namespace Yugen.MotoGP.App.ObservableObjects;

public partial class EventObservableObject : ObservableObject
{
    private readonly Models.Events.EventDto _event;
    private readonly Models.Event.EventDto _eventDetailDto;

    private DateTime? DateStart => DateTime.TryParse(_event.DateStart, out var dateStart) ? dateStart : null;

    [ObservableProperty]
    public partial BitmapImage CardSource { get; set; }

    public EventObservableObject(Models.Events.EventDto eventDto, Models.Event.EventDto eventDetailDto)
    {
        _event = eventDto;
        _eventDetailDto = eventDetailDto;
        LoadAssets();
    }

    public string Name => _event.Name;

    public string FlagPath => $"ms-appx:///Assets/Flags/{_event.Country.Iso}.svg";

    public string Hashtag => _eventDetailDto.Hashtag;

    public string StartDay => DateStart?.Day.ToString("00");

    public string StartMonth => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateStart?.Month ?? 1).ToUpperInvariant();

    public string StartDate => DateStart?.ToString(CultureInfo.CurrentCulture);

    public string Kind => _event.Test ? AppConstants.EventKindTest : AppConstants.EventKindRace;

    public string CircuitName => _event.Circuit?.Name ?? string.Empty;

    public string Status
    {
        get => _event.Status switch
        {
            ApiConstants.EventStatusCurrent => AppConstants.EventStatusLiveTiming,
            ApiConstants.EventStatusFinished => AppConstants.EventStatusResults,
            _ => string.Empty,
        };
    }

    public string CircuitCountry => _event.Circuit?.Nation?.ToUpperInvariant() ?? string.Empty;

    public string Id => _event.Id;

    private async void LoadAssets()
    {
        if (_eventDetailDto == null)
        {
            return;
        }

        //FlagPath => AssetsHelper.GetDpiAwareAssetPath(_event.Assets, "flag");
        CardSource = await ImageCacheService.GetFromCacheAsync(new Uri(AssetsHelper.GetDpiAwareAssetPath(_eventDetailDto.Assets, Models.Event.AssetType.Background)));
    }
}