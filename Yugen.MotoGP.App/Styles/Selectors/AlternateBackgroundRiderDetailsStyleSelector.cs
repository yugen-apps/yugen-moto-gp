using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.Base;
using Yugen.MotoGP.App.Models.LiveTiming;
using Yugen.MotoGP.App.ViewModels;

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
