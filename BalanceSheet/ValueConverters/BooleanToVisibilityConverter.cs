﻿
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace BalanceSheet.ValueConverters
{
    /// <summary>
    /// Converts a boolean value to <see cref="Visibility" />.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var b = (bool) value;

            if (parameter != null)
            {
                var invert = System.Convert.ToBoolean(parameter);
                if (invert)
                {
                    b = !b;
                }
            }

            return (b) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}