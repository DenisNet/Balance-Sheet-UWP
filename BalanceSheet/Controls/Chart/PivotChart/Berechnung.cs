using BalanceSheet.Models;
using BalanceSheet.ValueConverters;
using BalanceSheet.ViewModels;
using BalanceSheet.Views.Mobile.CostsIncomes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceSheet.Controls.Chart.PivotChart
{
    class Berechnung
    {
        private static int _categoryName;

        private decimal _summeItem;

        private decimal _summeItems;

        public void SetCategoryName(int category)
        {
            _categoryName = category;
        }

        public int GetCategoryName()
        {
            return _categoryName;
        }
        /// <summary>
        /// Summe All Category Fixkosten, Lebensmittel, Auto, Unterhaltung, Verkehr, Personal
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        internal async Task SummeCategoryAsync(int Category, int monat, int year)
        {
            //Fixkosten
            if (Category == 0)
            {
                _summeItems = await SummeRechnenAsync(CategoryNamenCosts.Fixed.ToString(), monat, year);
            }
            //Lebensmittel
            else if (Category == 1)
            {
                _summeItems = await SummeRechnenAsync(CategoryNamenCosts.Foods.ToString(), monat, year);
            }
            //Auto
            else if (Category == 2)
            {
                _summeItems = await SummeRechnenAsync(CategoryNamenCosts.Auto.ToString(), monat, year);
            }
            //Unterhaltung
            else if (Category == 3)
            {
                _summeItems = await SummeRechnenAsync(CategoryNamenCosts.Entertainment.ToString(), monat, year);
            }
            //Verkehr
            else if (Category == 4)
            {
                _summeItems = await SummeRechnenAsync(CategoryNamenCosts.Transport.ToString(), monat, year);
            }
            //Personal
            else if (Category == 5)
            {
                _summeItems = await SummeRechnenAsync(CategoryNamenCosts.Private.ToString(), monat, year);
            }
        }

        private async Task<decimal> SummeRechnenAsync(string category, int monat, int year)
        {
            var uNFI = new UserNumberFormat();

            decimal? summeTemp;

            if (category == CategoryNamenIncomen.Salary.ToString() || category == CategoryNamenIncomen.OtherIncomes.ToString())
            {
                using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
                {
                    summeTemp = await dataBase.Incomes.AsNoTracking()
                        .Select(c => new
                        {
                            nameCategory = c.CategoryOfIncome,
                            price = (decimal?)Decimal.Parse(c.PreisOfIncome,
                        NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI()),
                            datum = c.DateOfIncome
                        })
                        .Where(a => a.datum.Month == monat & a.datum.Year == year && a.nameCategory == category)
                        .Select(a => a.price).SumAsync();
                }
            }
            else
            {
                using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
                {
                    summeTemp = await dataBase.Costs.AsNoTracking()
                        .Select(c => new
                        {
                            nameCategory = c.CategoryOfCost,
                            price = (decimal?)Decimal.Parse(c.PreisOfCost,
                        NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI()),
                            datum = c.DateOfCost
                        })
                        .Where(a => a.datum.Month == monat & a.datum.Year == year && a.nameCategory == category)
                        .Select(a => a.price).SumAsync();
                }

            }
            _summeItem = (decimal)summeTemp;
            return _summeItem;
        }

        /// <summary>
        /// Get summe one item undercategory
        /// </summary>
        /// <param name="category"></param>
        /// <param name="nameUnderCategory"></param>
        /// <param name="monat"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        internal async Task<decimal> GetSummeAsync(string category, string nameUnderCategory, int monat, int year)
        {
            var uNFI = new UserNumberFormat();

            decimal? summeTemp;
            //decimal summe;

            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                summeTemp = await dataBase.Costs.AsNoTracking()
                    .Select(c => new
                    {
                        nameCategory = c.CategoryOfCost,
                        nameUnderCategory = c.CategoryUnderOfCost,
                        price = (decimal?)Decimal.Parse(c.PreisOfCost,
                    NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI()),
                        datum = c.DateOfCost
                    })
                    .Where(a => a.datum.Month == monat & a.datum.Year == year && a.nameCategory == category && a.nameUnderCategory == nameUnderCategory)
                    .Select(a => a.price).SumAsync();
            }
            _summeItem = (decimal)summeTemp;
            //summe = (decimal)summeTemp;
            return _summeItem;
        }

        internal string GetPercentage()
        {
            UserNumberFormat uNFI = new UserNumberFormat();
            if (_summeItem == 0)
            {
                   return (_summeItem * -1).ToString("P", uNFI.GetNFI());
            }
            else
            {
                return (_summeItem  / _summeItems).ToString("P", uNFI.GetNFI());
            }
        }

        public async Task<ObservableCollection<Balance>> DatenSourceLoadedAsync()
        {
            ObservableCollection<Balance> data = new ObservableCollection<Balance>();
            {
                //Fixkosten
                if (_categoryName == 0)
                {
                    List<FixkostenUnderCategory> list = Enum.GetValues(typeof(FixkostenUnderCategory))
                        .Cast<FixkostenUnderCategory>()
                        .ToList();
                    List<string> listString = new List<string>();
                    foreach (var item in list)
                    {
                        listString.Add(item.ToString());
                    }
                    data = await GetDatenCollection(CategoryNamenCosts.Fixed.ToString(), listString);
                }
                //Lebensmittel
                else if (_categoryName == 1)
                {
                    List<LebensmittelUnderCategory> list = Enum.GetValues(typeof(LebensmittelUnderCategory))
                        .Cast<LebensmittelUnderCategory>()
                        .ToList();

                    List<string> listString = new List<string>();
                    foreach (var item in list)
                    {
                        listString.Add(item.ToString());
                    }
                    data = await GetDatenCollection(CategoryNamenCosts.Foods.ToString(), listString);
                }
                //Auto
                else if (_categoryName == 2)
                {
                    List<AutoUnderCategory> list = Enum.GetValues(typeof(AutoUnderCategory))
                        .Cast<AutoUnderCategory>()
                        .ToList();
                    List<string> listString = new List<string>();
                    foreach (var item in list)
                    {
                        listString.Add(item.ToString());
                    }
                    data = await GetDatenCollection(CategoryNamenCosts.Auto.ToString(), listString);
                }
                //Unterhaltung
                else if (_categoryName == 3)
                {
                    List<UnterhaltungUnderCategory> list = Enum.GetValues(typeof(UnterhaltungUnderCategory))
                        .Cast<UnterhaltungUnderCategory>()
                        .ToList();
                    List<string> listString = new List<string>();
                    foreach (var item in list)
                    {
                        listString.Add(item.ToString());
                    }
                    data = await GetDatenCollection(CategoryNamenCosts.Entertainment.ToString(), listString);

                }
                //Verkehr
                else if (_categoryName == 4)
                {
                    List<VerkehrUnderCategory> list = Enum.GetValues(typeof(VerkehrUnderCategory))
                        .Cast<VerkehrUnderCategory>()
                        .ToList();
                    List<string> listString = new List<string>();
                    foreach (var item in list)
                    {
                        listString.Add(item.ToString());
                    }
                    data = await GetDatenCollection(CategoryNamenCosts.Transport.ToString(), listString);
                }
                //Personal
                else if (_categoryName == 5)
                {
                    List<PersonalUnderCategory> list = Enum.GetValues(typeof(PersonalUnderCategory))
                        .Cast<PersonalUnderCategory>()
                        .ToList();
                    List<string> listString = new List<string>();
                    foreach (var item in list)
                    {
                        listString.Add(item.ToString());
                    }
                    data = await GetDatenCollection(CategoryNamenCosts.Private.ToString(), listString);
                }
            }
            return data;
        }

        /// <summary>
        /// Rechnet was fur wieviel Category in Cost und Incomen
        /// dann rechnet ganze Summe von Cost oder Incomen
        /// </summary>
        /// <param name="category">Category von CatergoryIncomenCost</param>
        /// <param name="monat">Monat</param>
        /// <param name="year">Year</param>
        /// <returns></returns>
        public async Task<ObservableCollection<Balance>> HomePageDatenSourceLoadedAsync(CategoryCostIncomen category, int monat, int year)
        {
            decimal? summeTemp;
            ObservableCollection<Balance> data = new ObservableCollection<Balance>();

            List<string> listString = new List<string>();

            if (category == CategoryCostIncomen.Cost)
            {
                List<CategoryNamenCosts> costs = Enum.GetValues(typeof(CategoryNamenCosts))
                    .Cast<CategoryNamenCosts>()
                    .ToList();
                //add alle Category fur nachste rechnung in GetDatenCollection(List<string> listString)
                foreach (var item in costs)
                {
                    listString.Add(item.ToString());
                }
                var uNFI = new Views.Mobile.CostsIncomes.UserNumberFormat();

                //rechnet ganze Summe von Costs
                using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
                {
                    summeTemp = await dataBase.Costs.AsNoTracking()
                        .Select(c => new
                        {
                            nameCategory = c.CategoryOfCost,
                            price = (decimal?)Decimal.Parse(c.PreisOfCost,
                        NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI()),
                            datum = c.DateOfCost
                        })
                        .Where(a => a.datum.Month == monat & a.datum.Year == year)
                        .Select(a => a.price).SumAsync();
                }
                _summeItems = (decimal)summeTemp;
            }
            else
            {
                List<CategoryNamenIncomen> incomen = Enum.GetValues(typeof(CategoryNamenIncomen))
                    .Cast<CategoryNamenIncomen>()
                    .ToList();
                foreach (var item in incomen)
                {
                    listString.Add(item.ToString());
                }
                var uNFI = new Views.Mobile.CostsIncomes.UserNumberFormat();

                //rechnet ganze Summe von Incomen
                using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
                {
                    summeTemp = await dataBase.Incomes.AsNoTracking()
                        .Select(c => new
                        {
                            nameCategory = c.CategoryOfIncome,
                            price = (decimal?)Decimal.Parse(c.PreisOfIncome,
                        NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI()),
                            datum = c.DateOfIncome
                        })
                        .Where(a => a.datum.Month == monat & a.datum.Year == year)
                        .Select(a => a.price).SumAsync();
                }
                _summeItems = (decimal)summeTemp;
            }

            data = await GetDatenCollection(listString);

            return data;
        }

        private async Task<ObservableCollection<Balance>> GetDatenCollection(List<string> listString)
        {
            var datum = new MonatYearDaten();
            ObservableCollection<Balance> data = new ObservableCollection<Balance>();

            foreach (var item in listString)
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                Balance datenItem = new Balance()
                {
                    Name = loader.GetString(item),
                    Price = await SummeRechnenAsync(item, datum.Monat, datum.Year),
                    Percentage = GetPercentage(),
                };
                if (datenItem.Price == 0)
                {
                    continue;
                }
                else
                {
                    data.Add(datenItem);
                }
            }
            return data;
        }

        private async Task<ObservableCollection<Balance>> GetDatenCollection(string category, List<string> list)
        {
            var datum = new MonatYearDaten();
            ObservableCollection<Balance> data = new ObservableCollection<Balance>();

            await SummeCategoryAsync(_categoryName, datum.Monat, datum.Year);
            foreach (var item in list)
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                Balance datenItem = new Balance()
                {
                    Name = loader.GetString(item),
                    Price = await GetSummeAsync(category, item, datum.Monat, datum.Year),
                    Percentage = GetPercentage(),
                };
                if (datenItem.Price == 0)
                {
                    continue;
                }
                else
                {
                    data.Add(datenItem);
                }
            }
            return data;
        }
    }
}
