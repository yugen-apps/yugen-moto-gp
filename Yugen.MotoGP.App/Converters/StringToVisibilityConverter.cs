using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace Yugen.MotoGP.App.Converters
{
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value is string str && !string.IsNullOrWhiteSpace(str)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return string.Empty;
        }
    }
}