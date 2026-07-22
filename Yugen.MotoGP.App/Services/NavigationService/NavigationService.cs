using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Yugen.MotoGP.App.Views;
using FluentIcon = FluentIcons.Common.Icon;

namespace Yugen.MotoGP.App.Services.NavigationService;

public class NavigationService : INavigationService
{
    private Frame _frame;

    public event EventHandler<object> Navigated;

    public static Dictionary<MenuItemType, MenuItem> MenuDictionary => new()
    {
        [MenuItemType.Home] = new MenuItem(
            MenuItemType.Home,
            true,
            FluentIcon.Home,
            typeof(HomePage)
        ),
        [MenuItemType.Calendar] = new MenuItem(
            MenuItemType.Calendar,
            false,
            FluentIcon.Calendar,
            typeof(CalendarPage)
        ),
        [MenuItemType.Classification] = new MenuItem(
            MenuItemType.Classification,
            false,
            FluentIcon.Ribbon,
            typeof(ClassificationPage)
        ),
        [MenuItemType.LiveTiming] = new MenuItem(
            MenuItemType.LiveTiming,
            false,
            FluentIcon.Clock,
            typeof(LiveTimingPage)
        ),
        [MenuItemType.WorldStanding] = new MenuItem(
            MenuItemType.WorldStanding,
            false,
            FluentIcon.Trophy,
            typeof(WorldStandingPage)
        ),
        [MenuItemType.Settings] = new MenuItem(
            MenuItemType.Settings,
            false,
            FluentIcon.Settings,
            null
        )
    };

    public static List<MenuItem> MenuItems => MenuDictionary.Values.ToList();

    public bool CanGoBack => _frame.CanGoBack;

    public void GoBack() => _frame.GoBack();

    public void InitializeRootFrame(Frame frame)
    {
        InitializeFrame(frame);
    }

    public void Navigate(MenuItemType tag, object args = null)
    {
        var menuItem = MenuDictionary[tag];
        _frame.Navigate(menuItem.Page, args);
    }

    private void InitializeFrame(Frame frame)
    {
        _frame = frame;
        _frame?.Navigated += OnFrameNavigated;
        _frame?.NavigationFailed += OnNavigationFailed;
    }

    private void OnFrameNavigated(object sender, NavigationEventArgs e)
    {
        Navigated?.Invoke(sender, e.Parameter);
    }

    private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
        // throw new NotImplementedException();
    }
}