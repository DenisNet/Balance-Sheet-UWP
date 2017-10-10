using BalanceSheet.Models;
using BalanceSheet.ViewModels;
using BalanceSheet.Views.Mobile.CostsIncomes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BalanceSheet.Controls.Chart
{


    class ChartConverter: IValueConverter
    {
        enum EinnahmenAusgaben { Einnahmen, Ausgaben}
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            decimal summeCosts, summeIncomes;
            var homeWithDaten = new MonatYearDaten();

            summeCosts = homeWithDaten.GetWertAusgabe();
            summeIncomes = homeWithDaten.GetWertEinnahme();
            var uNFI = new UserNumberFormat();

            Balance balance = value as Balance;
            ObservableCollection<Balance> data = new ObservableCollection<Balance>();
            {
                Balance einnahmen = new Balance()
                {
                    Name = EinnahmenAusgaben.Einnahmen.ToString(),
                    Price = summeIncomes,
                    Percentage = homeWithDaten.GetPercentageEinnahme().ToString("P", uNFI.GetNFI())
                };
                data.Add(einnahmen);

                Balance ausgaben = new Balance()
                {
                    Name = EinnahmenAusgaben.Ausgaben.ToString(),
                    Price = summeCosts,
                    Percentage = homeWithDaten.GetPercentageAusgabe().ToString("P", uNFI.GetNFI())
                };
                data.Add(ausgaben);
            }
            return data;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}