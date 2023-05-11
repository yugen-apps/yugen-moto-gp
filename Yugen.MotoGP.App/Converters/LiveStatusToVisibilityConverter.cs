using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using Yugen.MotoGP.App.Constants;

namespace Yugen.MotoGP.App.Converters
{
    public class LiveStatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string str)
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return Visibility.Collapsed;
                }
                if (StringComparer.InvariantCultureIgnoreCase.Equals(str, AppConstants.EventLiveTiming))
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return string.Empty;
        }
    }
}