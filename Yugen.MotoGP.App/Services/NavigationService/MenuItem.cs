using System;
using FluentIcon = FluentIcons.Common.Icon;

namespace Yugen.MotoGP.App.Services.NavigationService
{
    public class MenuItem
    {
        public MenuItem(
            MenuItemType tag,
            bool isSelected,
            FluentIcon icon,
            string glyph,
            Type viewModel,
            Type page)
        {
            Name = tag.ToString();
            Tag = tag;
            IsSelected = isSelected;
            Glyph = glyph;
            Icon = icon;
            ViewModel = viewModel;
            Page = page;
        }

        public string Glyph { get; }

        public FluentIcon Icon { get; }

        public bool IsSelected { get; }

        public string Name { get; }

        public Type Page { get; }

        public MenuItemType Tag { get; }

        public Type ViewModel { get; }
    }
}