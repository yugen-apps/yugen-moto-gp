using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugen.MotoGP.App.Constants;

namespace Yugen.MotoGP.App.Converters
{
    public class LiveStatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value is string status && StringComparer.InvariantCultureIgnoreCase.Equals(status, AppConstants.EventLiveTiming)
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return string.Empty;
        }
    }
}
