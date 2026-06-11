using Microsoft.UI.Xaml.Controls;
using System;

namespace Yugen.MotoGP.App.Services.NavigationService
{
	public class MenuItem
	{
		public MenuItem(
			MenuItemType tag,
			bool isSelected,
			Symbol symbol,
			string glyph,
			Type viewModel,
			Type page)
		{
			Name = tag.ToString();
			Tag = tag;
			IsSelected = isSelected;
			Symbol = symbol;
			Glyph = glyph;
			ViewModel = viewModel;
			Page = page;
		}

		public string Name { get; }

		public MenuItemType Tag { get; }

		public bool IsSelected { get; }

		public Symbol Symbol { get; }

		public string Glyph { get; }

		public Type ViewModel { get; }

		public Type Page { get; }
	}
}