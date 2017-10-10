using System;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace BalanceSheet.ValueConverters
{
    public class AuthProviderToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var s = value.ToString();

            return string
                .Concat(s.Select(c => char.IsUpper(c) ? " " + c : c.ToString()))
                .TrimStart(' ');
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}