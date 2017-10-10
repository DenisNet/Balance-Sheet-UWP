using BalanceSheet.ViewModels;
using BalanceSheet.Views.Mobile.CostsIncomes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace BalanceSheet.Models
{
    public abstract class MonatYearDatenViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Notifies that the property has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    /// <summary>
    /// Rechnet die Werte fur Einnahmen und Ausgeben
    /// </summary>
    public class MonatYearDaten : MonatYearDatenViewModelBase
    {
        private static decimal _einnahme;
        private static decimal _ausgabe;
        private static decimal _balanceEinnahmeAusgabe;
        private decimal _ausgabeForYear;
        private decimal _einnahmeForYear;
        private static decimal _balanceForYear;
        private static decimal _percentAusgabe;
        private static decimal _percentEinnahme;
        private static int _monat;
        private static int _year;

        public int Monat
        {
            get { return _monat; }
        }
        public int Year
        {
            get { return _year; }
        }

        public decimal BalanceForYearProperty
        {
            get
            {
                return _balanceForYear;
            }
            set
            {
                _balanceForYear = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("BalanceForYearProperty");
                NotifyPropertyChanged(nameof(BalanceForYearProperty));
            }
        }

        public MonatYearDaten()
        {
        }


        /// <summary>
        /// Konsturtor for Month and Year
        /// </summary>
        /// <param name="monat"></param>
        /// <param name="year"></param>
        public MonatYearDaten(int monat, int year)
        {
            if (_monat == 0 | _year == 0)
            {
                _monat = DateTime.Today.Month;
                _year = DateTime.Today.Year;
            }
            else
            {
                _monat = monat;
                _year = year;
            }
        }

        public string GetMonatYearString()
        {
            ContractModelConverterExtensions.DatePickerConverter dt = new ContractModelConverterExtensions.DatePickerConverter();
            return dt.Convert(_monat) + " " + _year;
        }


        public decimal GetBalanceForYear()
        {
            return _balanceForYear;
        }
        public decimal GetPercentageAusgabe()
        {
            return _percentAusgabe;
        }

        public decimal GetPercentageEinnahme()
        {
            return _percentEinnahme;
        }

        public decimal GetWertEinnahme()
        {
            return _einnahme;
        }

        public decimal GetWertAusgabe()
        {
            return _ausgabe;
        }

        public decimal GetWertBalance()
        {
            return _balanceEinnahmeAusgabe;
        }

        public async Task CostIncomeSummeAsync()
        {
            var uNFI = new UserNumberFormat();

            decimal? summeCostsTemp, summeIncomesTemp;

            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                summeIncomesTemp = await dataBase.Incomes.AsNoTracking()
                    .Select(c => new
                    {
                        price = (decimal?)Decimal.Parse(c.PreisOfIncome,
                    NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI()),
                        datum = c.DateOfIncome
                    })
                    .Where(a => a.datum.Month == _monat & a.datum.Year == _year)
                    .Select(a => a.price).SumAsync();
            }

            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                summeCostsTemp = await dataBase.Costs.AsNoTracking()
                    .Select(c => new
                    {
                        price = (decimal?)Decimal.Parse(c.PreisOfCost, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI()),
                        datum = c.DateOfCost
                    })
                    .Where(a => a.datum.Month == _monat & a.datum.Year == _year)
                    .Select(a => a.price).SumAsync();
            }

            _ausgabe = (decimal)summeCostsTemp;
            _einnahme = (decimal)summeIncomesTemp;
            _balanceEinnahmeAusgabe = _einnahme + _ausgabe;


            if (_ausgabe == 0 | _einnahme == 0)
            {
                if (_ausgabe == 0)
                {
                    _percentAusgabe = 0;

                }
                else
                {
                    _percentAusgabe = (_ausgabe * -1) / (_einnahme - _ausgabe);
                }
                if (_einnahme == 0)
                {
                    _percentEinnahme = 0;
                }
                else
                {
                    _percentEinnahme = _einnahme / (_einnahme - _ausgabe);
                }
            }
            else
            {
                _percentEinnahme = _einnahme / (_einnahme - _ausgabe);
                _percentAusgabe = (_ausgabe * -1) / (_einnahme - _ausgabe);
            }
        }

        //Berechnet for ganze Jahr
        public async Task BalanceForYearAsync()
        {
            var uNFI = new UserNumberFormat();

            decimal? summeCostsTemp, summeIncomesTemp;

            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                summeIncomesTemp = await dataBase.Incomes.AsNoTracking()
                    .Select(c => new
                    {
                        price = (decimal?)Decimal.Parse(c.PreisOfIncome,
                    NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI()),
                        datum = c.DateOfIncome
                    })
                    .Where(a => a.datum.Year == _year)
                    .Select(a => a.price).SumAsync();
            }

            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                summeCostsTemp = await dataBase.Costs.AsNoTracking()
                    .Select(c => new
                    {
                        price = (decimal?)Decimal.Parse(c.PreisOfCost, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI()),
                        datum = c.DateOfCost
                    })
                    .Where(a => a.datum.Year == _year)
                    .Select(a => a.price).SumAsync();
            }

            _ausgabeForYear = (decimal)summeCostsTemp;
            _einnahmeForYear = (decimal)summeIncomesTemp;
            BalanceForYearProperty = _einnahmeForYear + _ausgabeForYear;
        }

    }
}
