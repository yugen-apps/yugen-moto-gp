using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Categories;
using Yugen.MotoGP.App.Models.Seasons;
using Yugen.MotoGP.App.Services.AppService;
using Yugen.MotoGP.App.Services.ConfigService;
using Yugen.MotoGP.App.Services.NavigationService;

namespace Yugen.MotoGP.App.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IAppService _appService;
    private readonly IConfigService _configService;
    private readonly INavigationService _navigationService;

    public MainViewModel(
        IAppService appService,
        IConfigService configService,
        INavigationService navigationService)
    {
        _appService = appService;
        _configService = configService;
        _navigationService = navigationService;
    }

    [ObservableProperty]
    public partial bool IsPaneOpen { get; set; }

    [ObservableProperty]
    public partial IList<CategoryDto> Categories { get; set; }

    [ObservableProperty]
    public partial CategoryDto SelectedCategory { get; set; }

    [ObservableProperty]
    public partial string[] WorldStandingTypes { get; set; }

    [ObservableProperty]
    public partial string SelectedWorldStandingType { get; set; }

    [ObservableProperty]
    public partial IList<SeasonDto> Seasons { get; set; }

    [ObservableProperty]
    public partial SeasonDto SelectedSeason { get; set; }

    public void Initialize(Frame navFrame)
    {
        _navigationService.InitializeRootFrame(navFrame);
    }

    partial void OnSelectedCategoryChanged(CategoryDto value)
    {
        _configService.CurrentCategoryId = value.Id;
    }

    partial void OnSelectedSeasonChanged(SeasonDto value)
    {
        _configService.CurrentSeasonId = value.Id;
    }

    partial void OnSelectedWorldStandingTypeChanged(string value)
    {
        _configService.CurrentWorldStandingType = value;
    }

    [RelayCommand]
    private async Task Load()
    {
        WorldStandingTypes = ConfigService.WorldStandingTypes;
        SelectedWorldStandingType = WorldStandingTypes[0];

        await _appService.GetSeasons();
        Seasons = _configService.Seasons;
        SelectedSeason = _configService.Seasons.FirstOrDefault(x => x.Current);

        await _appService.GetCategories(_configService.CurrentSeasonId);
        Categories = _configService.Categories;
        SelectedCategory = Categories[0];

        _navigationService.Navigate(MenuItemType.Home);
    }

    [RelayCommand]
    private async Task NavigationViewSelectionChanged(MenuItem menuItem)
    {
        _navigationService.Navigate(menuItem.Tag);
    }

    [RelayCommand]
    private async Task TitleBarBackRequested()
    {
        _navigationService.GoBack();
    }

    [RelayCommand]
    private async Task TitleBarPaneToggleRequested()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}