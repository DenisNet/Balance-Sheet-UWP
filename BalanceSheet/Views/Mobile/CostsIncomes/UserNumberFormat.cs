using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceSheet.Views.Mobile.CostsIncomes
{
    class UserNumberFormat
    {
        internal NumberFormatInfo GetNFI()
        {
            CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);
            NumberFormatInfo nfi = cultureInfo.NumberFormat;

            nfi.CurrencySymbol = cultureInfo.NumberFormat.CurrencySymbol;
            //Positive Pattern 0 - 3 (3 -> "n $")
            nfi.CurrencyPositivePattern = 3;
            //Negative Pattern 0 - 15 (8 -> "-n $")
            nfi.CurrencyNegativePattern = 8;

            return nfi;
        }
    }
}
