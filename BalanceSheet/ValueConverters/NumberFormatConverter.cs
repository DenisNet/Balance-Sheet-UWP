using BalanceSheet.Views.Mobile.CostsIncomes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BalanceSheet.ValueConverters
{
    class NumberFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            string wert = value.ToString();
            var uNFI = new UserNumberFormat();
            decimal item;
            Decimal.TryParse(wert, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI(), out item);

            return item.ToString("C", uNFI.GetNFI());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
