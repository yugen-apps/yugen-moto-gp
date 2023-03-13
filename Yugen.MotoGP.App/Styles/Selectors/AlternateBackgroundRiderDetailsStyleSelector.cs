using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Models.LiveTiming;
using Yugen.MotoGP.App.ViewModels;

namespace Yugen.MotoGP.App.Styles.Selectors
{
    public class AlternateBackgroundRiderDetailsStyleSelector : StyleSelector
    {
        public Style Style1 { get; set; }
        public Style Style2 { get; set; }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            if (item is RiderDetails vm && int.TryParse(vm.Pos, out int position))
            {
                return position % 2 == 0 ? Style1 : Style2;
            }
            return Style1;
        }
    }
}
