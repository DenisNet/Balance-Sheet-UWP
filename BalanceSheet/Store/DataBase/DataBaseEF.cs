using System;
using Microsoft.EntityFrameworkCore;

namespace BalanceSheet.Store.DataBase.DataBaseEF
{
    class DataBaseFile : DbContext
    {
        public DataBaseFile() : base() { }
        public DataBaseFile(DbContextOptions<DataBaseFile> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Balance.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Kontakt> Kontakts { get; set; }
    }


    public class User
    {
        public int UserId { get; set; }

        public string Nachname { get; set; }

        public string Vorname { get; set; }

        public string Middlename { get; set; }

        public string Titel { get; set; }

        public DateTime Geburtsdatum { get; set; }

        public string Company { get; set; }

        public string PrefferedLanguage { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public DateTime DateOfModify { get; set; }
    }

    public class Login
    {
        public int LoginId { get; set; }

        public string Login1 { get; set; }

        public string Password { get; set; }

        public string DateOfModify { get; set; }
    }

    public class Income
    {
        public int IncomeId { get; set; }

        public string NameOfIncome { get; set; }

        public string PreisOfIncome { get; set; }

        public DateTime DateOfIncome { get; set; }

        public string CategoryOfIncome { get; set; }

        public string CategoryUnderOfIncome { get; set; }

        public string CostsOrIncomes { get; internal set; }
    }

    public class Cost
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int CostId { get; set; }

        public string NameOfCost { get; set; }

        public string PreisOfCost { get; set; }

        public DateTime DateOfCost { get; set; }

        public string CategoryOfCost { get; set; }

        public string CategoryUnderOfCost { get; set; }

        public string CostsOrIncomes { get; set; }
    }

    public class Kontakt
    {
        public int KontaktId { get; set; }

        public string Land { get; set; }

        public string City { get; set; }

        public string PLZ { get; set; }

        public string Strasse { get; set; }

        public string Nummer { get; set; }

        public string Mail { get; set; }

        public string Telefon { get; set; }
    }
}