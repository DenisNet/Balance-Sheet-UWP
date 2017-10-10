using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BalanceSheet.Store.DataBase.DataBaseEF;

namespace BalanceSheet.Migrations
{
    [DbContext(typeof(DataBaseFile))]
    [Migration("20170422165919_DataBaseBalanceSheet")]
    partial class DataBaseBalanceSheet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("BalanceSheet.Store.DataBase.DataBaseEF.Cost", b =>
                {
                    b.Property<int>("CostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryOfCost");

                    b.Property<string>("CategoryUnderOfCost");

                    b.Property<string>("CostsOrIncomes");

                    b.Property<DateTime>("DateOfCost");

                    b.Property<string>("NameOfCost");

                    b.Property<string>("PreisOfCost");

                    b.HasKey("CostId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("BalanceSheet.Store.DataBase.DataBaseEF.Income", b =>
                {
                    b.Property<int>("IncomeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryOfIncome");

                    b.Property<string>("CategoryUnderOfIncome");

                    b.Property<string>("CostsOrIncomes");

                    b.Property<DateTime>("DateOfIncome");

                    b.Property<string>("NameOfIncome");

                    b.Property<string>("PreisOfIncome");

                    b.HasKey("IncomeId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("BalanceSheet.Store.DataBase.DataBaseEF.Kontakt", b =>
                {
                    b.Property<int>("KontaktId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Land");

                    b.Property<string>("Mail");

                    b.Property<string>("Nummer");

                    b.Property<string>("PLZ");

                    b.Property<string>("Strasse");

                    b.Property<string>("Telefon");

                    b.HasKey("KontaktId");

                    b.ToTable("Kontakts");
                });

            modelBuilder.Entity("BalanceSheet.Store.DataBase.DataBaseEF.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DateOfModify");

                    b.Property<string>("Login1");

                    b.Property<string>("Password");

                    b.HasKey("LoginId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("BalanceSheet.Store.DataBase.DataBaseEF.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<DateTime>("DateOfModify");

                    b.Property<DateTime>("DateOfRegistration");

                    b.Property<DateTime>("Geburtsdatum");

                    b.Property<string>("Middlename");

                    b.Property<string>("Nachname");

                    b.Property<string>("PrefferedLanguage");

                    b.Property<string>("Titel");

                    b.Property<string>("Vorname");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
        }
    }
}
