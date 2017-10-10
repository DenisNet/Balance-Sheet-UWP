using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceSheet.Models
{
    /// <summary>
    /// All Costs Category
    /// </summary>
    public enum CategoryNamenCosts { Fixed = 1, Foods, Auto, Education, Apps, Vacation, Entertainment, House, Transport, Private, OtherCosts }
    /// <summary>
    /// All Incomes Category
    /// </summary>
    public enum CategoryNamenIncomen { Salary = 1, OtherIncomes }
    public enum CategoryCostIncomen { Incomen = 1, Cost }
    public enum FixkostenUnderCategory { Bank = 1, Rental, Groundshuld, Extracosts, TV, Internet, Telefons, InsuranceFix, Tax, OtherFix }
    public enum LebensmittelUnderCategory { Meat = 1, Meer, FruitVegetabele, Bakery, Milk, Sweetnes, Drinks, OtherFoods }
    public enum AutoUnderCategory { Fuel = 1, Repair, Wash, InsuranceAuto, Fine, OtherAuto }
    public enum UnterhaltungUnderCategory { Cafe = 1, Pizza, Restaurant, Kino, Theatre, OtherEntertainment }
    public enum VerkehrUnderCategory { Trainticket = 1, Singleticket, Taxi, Flightticket, Monthlyticket, OtherTransport }
    public enum PersonalUnderCategory { Accessoires = 1, Hairdressing, Dress, Cosmetics, Medicine, Wellness, OtherPrivate }

    class ListBalance
    {
        #region Properties
        public long ID { get; internal set; }
        public string Preis { get; internal set; }
        public string Name { get; internal set; }     
        public DateTime Datum { get; internal set; }
        public string Category { get; internal set; }
        public string UnderCategory { get; internal set; }
        public string CostsOrIncomes { get; set; }
        #endregion

        public ListBalance()
        {
            // default values for each property.
            ID = 0;
            Name = string.Empty;
            Preis = string.Empty;
            Datum = DateTime.Today;
            Category = string.Empty;
            UnderCategory = string.Empty;
            CostsOrIncomes = string.Empty;
        }

        //Alle Kost beitrege, wird in GetBalanceListeAsync benutzt
        public static async Task<ListBalance> GetNewCostsBalanceAsync(int i)
        {
            string name, preis, category, underCategory, costsOrIncomes;
            //int category, underCategory;
            long id;
            DateTime datum;

            //var optionsBuilder = new DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile>();
            //optionsBuilder.UseSqlite("Filename=Balance.db");
            //using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile(optionsBuilder.Options))
            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                id = await
                    (from nameCost in dataBase.Costs
                     where nameCost.CostId == i
                     select nameCost.CostId).FirstOrDefaultAsync();
                name = await
                 (from nameCost in dataBase.Costs
                  where nameCost.CostId == i
                  select nameCost.NameOfCost).FirstOrDefaultAsync();
                preis = await
                 (from nameCost in dataBase.Costs
                  where nameCost.CostId == i
                  select nameCost.PreisOfCost).FirstOrDefaultAsync();
                datum = await
                 (from nameCost in dataBase.Costs
                  where nameCost.CostId == i
                  select nameCost.DateOfCost).FirstOrDefaultAsync();
                category = await
                 (from nameCost in dataBase.Costs
                  where nameCost.CostId == i
                  select nameCost.CategoryOfCost).FirstOrDefaultAsync();
                underCategory = await
                 (from nameCost in dataBase.Costs
                  where nameCost.CostId == i
                  select nameCost.CategoryUnderOfCost).FirstOrDefaultAsync();
                costsOrIncomes = await
                    (from nameCost in dataBase.Costs
                     select nameCost.CostsOrIncomes).FirstOrDefaultAsync();
            }

            return new ListBalance()
            {
                ID = id,
                Name = name,
                Preis = preis,
                Datum = datum,
                Category = category,
                UnderCategory = underCategory,
                CostsOrIncomes = costsOrIncomes
            };
        }

        //Alle Income beitrege, wird in GetBalanceListeAsync benutzt
        public static async Task<ListBalance> GetNewIncomesBalanceAsync(int i)
        {
            string name, preis, category, underCategory, costsOrIncomes;
            //int category, underCategory;
            long id;
            DateTime datum;

            //var optionsBuilder = new DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile>();
            //optionsBuilder.UseSqlite("Filename=Balance.db");
            //using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile(optionsBuilder.Options))
            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                id = await 
                    (from nameIncome in dataBase.Incomes
                      where nameIncome.IncomeId == i
                      select nameIncome.IncomeId).FirstOrDefaultAsync();
                name = await
                 (from nameIncome in dataBase.Incomes
                  where nameIncome.IncomeId == i
                  select nameIncome.NameOfIncome).FirstOrDefaultAsync();
                preis = await
                 (from nameIncome in dataBase.Incomes
                  where nameIncome.IncomeId == i
                  select nameIncome.PreisOfIncome).FirstOrDefaultAsync();
                datum = await
                 (from nameIncome in dataBase.Incomes
                  where nameIncome.IncomeId == i
                  select nameIncome.DateOfIncome).FirstOrDefaultAsync();
                category = await
                 (from nameIncome in dataBase.Incomes
                  where nameIncome.IncomeId == i
                  select nameIncome.CategoryOfIncome).FirstOrDefaultAsync();
                underCategory = await
                 (from nameIncome in dataBase.Incomes
                  where nameIncome.IncomeId == i
                  select nameIncome.CategoryUnderOfIncome).FirstOrDefaultAsync();
                costsOrIncomes = await
                    (from nameIncome in dataBase.Incomes
                     select nameIncome.CostsOrIncomes).FirstOrDefaultAsync();
            }

            return new ListBalance()
            {
                ID = id,
                Name = name,
                Preis = preis,
                Datum = datum,
                Category = category,
                UnderCategory = underCategory,
                CostsOrIncomes = costsOrIncomes
            };
        }


        internal async static Task<ObservableCollection<ListBalance>> GetBalanceListeAsync(CategoryCostIncomen category, int monat, int year)
        {
            ObservableCollection<ListBalance> balances = new ObservableCollection<ListBalance>();
            ListBalance listBalance = new ListBalance();
            var cost = new List<Store.DataBase.DataBaseEF.Cost>();
            var income = new List<Store.DataBase.DataBaseEF.Income>();

            //var optionsBuilder = new DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile>();
            //optionsBuilder.UseSqlite("Filename=Balance.db");
            //using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile(optionsBuilder.Options))
            if (category == CategoryCostIncomen.Cost)
            {
                using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
                {
                    cost = await
                     (from nameCost in dataBase.Costs
                      where nameCost.DateOfCost.Month == monat && nameCost.DateOfCost.Year == year
                      select nameCost).ToListAsync();
                }
                foreach (var item in cost)
                {
                    listBalance = await GetNewCostsBalanceAsync(item.CostId);
                    balances.Add(listBalance);
                }
            }
            else
            {
                using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
                {
                    income = await
                        (from nameIncome in dataBase.Incomes
                         where nameIncome.DateOfIncome.Month == monat && nameIncome.DateOfIncome.Year == year
                         select nameIncome).ToListAsync();
                }
                foreach (var item in income)
                {
                    listBalance = await GetNewIncomesBalanceAsync(item.IncomeId);
                    balances.Add(listBalance);
                }
            }

            return balances;
        }

        /// <summary>
        /// For HomePage Get all Liste Incomes and Costs
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        internal async static Task<ObservableCollection<ListBalance>> GetBalanceListeAsync(int monat, int year)
        {
            ObservableCollection<ListBalance> balances = new ObservableCollection<ListBalance>();

            var cost = new List<Store.DataBase.DataBaseEF.Cost>();
            var income = new List<Store.DataBase.DataBaseEF.Income>();

            //var optionsBuilder = new DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile>();
            //optionsBuilder.UseSqlite("Filename=Balance.db");
            //using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile(optionsBuilder.Options))
            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                cost = await
                 (from nameCost in dataBase.Costs
                  where nameCost.DateOfCost.Month == monat && nameCost.DateOfCost.Year == year
                  select nameCost).ToListAsync();
                income = await
                    (from nameIncome in dataBase.Incomes
                     where nameIncome.DateOfIncome.Month == monat && nameIncome.DateOfIncome.Year == year
                     select nameIncome).ToListAsync();
            }

            foreach (var item in cost)
            {
                ListBalance listBalance = new ListBalance();
                listBalance = await GetNewCostsBalanceAsync(item.CostId);
                balances.Add(listBalance);
            }
            foreach (var item in income)
            {
                ListBalance listBalance = new ListBalance();
                listBalance = await GetNewIncomesBalanceAsync(item.IncomeId);
                balances.Add(listBalance);
            }
            return balances;
        }

        /// <summary>
        /// For CalendarPage Get all Liste Incomes and Costs
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        public async static Task<ObservableCollection<ListBalance>> GetBalanceListeAsync(DateTime datum)
        {
            ObservableCollection<ListBalance> balances = new ObservableCollection<ListBalance>();

            var cost = new List<Store.DataBase.DataBaseEF.Cost>();
            var income = new List<Store.DataBase.DataBaseEF.Income>();

            //var optionsBuilder = new DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile>();
            //optionsBuilder.UseSqlite("Filename=Balance.db");
            //using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile(optionsBuilder.Options))
            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                cost = await
                 (from nameCost in dataBase.Costs
                  where nameCost.DateOfCost.Date == datum.Date
                  select nameCost).ToListAsync();
                income = await
                    (from nameIncome in dataBase.Incomes
                     where nameIncome.DateOfIncome.Date == datum.Date
                     select nameIncome).ToListAsync();
            }

            foreach (var item in cost)
            {
                ListBalance listBalance = new ListBalance();
                listBalance = await GetNewCostsBalanceAsync(item.CostId);
                balances.Add(listBalance);
            }
            foreach (var item in income)
            {
                ListBalance listBalance = new ListBalance();
                listBalance = await GetNewIncomesBalanceAsync(item.IncomeId);
                balances.Add(listBalance);
            }
            return balances;
        }

#region For ReportPage, zegt alle einzelne Costs und Incomes in Liste

        /// <summary>
        /// For One Datum
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        internal async static Task<ObservableCollection<ListBalance>> GetBalanceListeAsync(DateTime ersteDatum, string category)
        {
            ObservableCollection<ListBalance> balances = new ObservableCollection<ListBalance>();

            var cost = new List<Store.DataBase.DataBaseEF.Cost>();
            var income = new List<Store.DataBase.DataBaseEF.Income>();

            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                if (category == CategoryNamenIncomen.Salary.ToString() || category == CategoryNamenIncomen.OtherIncomes.ToString())
                {
                    income = await
                         (from nameIncome in dataBase.Incomes
                          where nameIncome.DateOfIncome.Date == ersteDatum && nameIncome.CategoryOfIncome == category
                          select nameIncome).ToListAsync();
                }
                else
                {
                    cost = await
                         (from nameCost in dataBase.Costs
                          where nameCost.DateOfCost.Date == ersteDatum && nameCost.CategoryOfCost == category
                          select nameCost).ToListAsync();
                }
            }

            if (category == CategoryNamenIncomen.Salary.ToString() || category == CategoryNamenIncomen.OtherIncomes.ToString())
            {
                foreach (var item in income)
                {
                    ListBalance listBalance = new ListBalance();
                    listBalance = await GetNewIncomesBalanceAsync(item.IncomeId);
                    balances.Add(listBalance);
                }
            }
            else
            {
                foreach (var item in cost)
                {
                    ListBalance listBalance = new ListBalance();
                    listBalance = await GetNewCostsBalanceAsync(item.CostId);
                    balances.Add(listBalance);
                }
            }
            return balances;
        }

        /// <summary>
        /// For Bereichs Datum 
        /// </summary>
        /// <param name="ersteDatum"></param>
        /// <param name="zweiteDatum"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        internal async static Task<ObservableCollection<ListBalance>> GetBalanceListeAsync(DateTime ersteDatum, DateTime zweiteDatum, string category)
        {
            ObservableCollection<ListBalance> balances = new ObservableCollection<ListBalance>();

            var cost = new List<Store.DataBase.DataBaseEF.Cost>();
            var income = new List<Store.DataBase.DataBaseEF.Income>();


            using (var dataBase = new Store.DataBase.DataBaseEF.DataBaseFile())
            {
                if (category == CategoryNamenIncomen.Salary.ToString() || category == CategoryNamenIncomen.OtherIncomes.ToString())
                {
                    income = await
                         (from nameIncome in dataBase.Incomes
                          where nameIncome.DateOfIncome.Date >= ersteDatum && nameIncome.DateOfIncome.Date <= zweiteDatum && nameIncome.CategoryOfIncome == category
                          select nameIncome).ToListAsync();
                }
                else
                {
                    cost = await
                         (from nameCost in dataBase.Costs
                          where nameCost.DateOfCost.Date >= ersteDatum && nameCost.DateOfCost.Date <= zweiteDatum && nameCost.CategoryOfCost == category
                          select nameCost).ToListAsync();
                }
            }

            if (category == CategoryNamenIncomen.Salary.ToString() || category == CategoryNamenIncomen.OtherIncomes.ToString())
            {
                foreach (var item in income)
                {
                    ListBalance listBalance = new ListBalance();
                    listBalance = await GetNewIncomesBalanceAsync(item.IncomeId);
                    balances.Add(listBalance);
                }
            }
            else
            {
                foreach (var item in cost)
                {
                    ListBalance listBalance = new ListBalance();
                    listBalance = await GetNewCostsBalanceAsync(item.CostId);
                    balances.Add(listBalance);
                }
            }
            return balances;
        }
#endregion

    }
}
