using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Yugen.MotoGP.App.Models.Base;

namespace Yugen.MotoGP.App.Styles.Selectors
{
    public class GPAlternateBackgroundListViewStyleSelector : StyleSelector
    {
        public Style EvenStyle { get; set; }

        public Style OddStyle { get; set; }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            if (item is IPosition pos)
            {
                return pos.Position % 2 == 0 ? EvenStyle : OddStyle;
            }
            return EvenStyle;
        }
    }
}