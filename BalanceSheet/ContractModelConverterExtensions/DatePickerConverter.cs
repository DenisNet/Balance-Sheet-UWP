using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BalanceSheet.ContractModelConverterExtensions
{
    class DatePickerConverter: IValueConverter
    {
        /// <summary>
        /// Liefert DayofWeek in String zurueck
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            

            var dt = DateTime.Parse(value.ToString());
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;

            string month;
            if (cultureInfo.TextInfo.CultureName == "de-DE")
            {
                 month = new CultureInfo("de-DE").DateTimeFormat.GetDayName(dt.DayOfWeek);
            }
            else if (cultureInfo.TextInfo.CultureName == "fr-FR")
            {
                month = new CultureInfo("fr-FR").DateTimeFormat.GetDayName(dt.DayOfWeek);
            }
            else
            {
                month = new CultureInfo("en-US").DateTimeFormat.GetDayName(dt.DayOfWeek);
            }

            return month;

        }
        /// <summary>
        /// Liefert Monat in Strung zurueck
        /// </summary>
        /// <param name="value">Value ist DateTime</param>
        /// <returns>Monat in String</returns>
        public object Convert(object value)
        {
            if (value == null)
                return null;


            var dt = DateTime.Parse(value.ToString());
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;

            string month;
            if (cultureInfo.TextInfo.CultureName == "de-DE")
            {
                month = new CultureInfo("de-DE").DateTimeFormat.GetMonthName(dt.Month);
            }
            else if (cultureInfo.TextInfo.CultureName == "fr-FR")
            {
                month = new CultureInfo("fr-FR").DateTimeFormat.GetMonthName(dt.Month);
            }
            else
            {
                month = new CultureInfo("en-US").DateTimeFormat.GetMonthName(dt.Month);
            }

            return month;
        }

        /// <summary>
        /// Liefert Monat in String zuruck
        /// </summary>
        /// <param name="month">Monat in int</param>
        /// <returns>Monat in String</returns>
        public object Convert(int month)
        {
            if (month == 0)
                return 0;


            CultureInfo cultureInfo = CultureInfo.CurrentCulture;

            string monthTemp;
            if (cultureInfo.TextInfo.CultureName == "de-DE")
            {
                monthTemp = new CultureInfo("de-DE").DateTimeFormat.GetMonthName(month);
            }
            else if (cultureInfo.TextInfo.CultureName == "fr-FR")
            {
                monthTemp = new CultureInfo("fr-FR").DateTimeFormat.GetMonthName(month);
            }
            else
            {
                monthTemp = new CultureInfo("en-US").DateTimeFormat.GetMonthName(month);
            }

            return monthTemp;
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }


    }
}