using System;
using FluentIcon = FluentIcons.Common.Icon;

namespace Yugen.MotoGP.App.Services.NavigationService;

public class MenuItem
{
    public MenuItem(
        MenuItemType tag,
        bool isSelected,
        FluentIcon icon,
        Type page)
    {
        Name = tag.ToString();
        Tag = tag;
        IsSelected = isSelected;
        Icon = icon;
        Page = page;
    }

    public FluentIcon Icon { get; }

    public bool IsSelected { get; }

    public string Name { get; }

    public Type Page { get; }

    public MenuItemType Tag { get; }
}