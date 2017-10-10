using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BalanceSheet.Migrations
{
    public partial class DataBaseBalanceSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryOfCost = table.Column<string>(nullable: true),
                    CategoryUnderOfCost = table.Column<string>(nullable: true),
                    CostsOrIncomes = table.Column<string>(nullable: true),
                    DateOfCost = table.Column<DateTime>(nullable: false),
                    NameOfCost = table.Column<string>(nullable: true),
                    PreisOfCost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    IncomeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryOfIncome = table.Column<string>(nullable: true),
                    CategoryUnderOfIncome = table.Column<string>(nullable: true),
                    CostsOrIncomes = table.Column<string>(nullable: true),
                    DateOfIncome = table.Column<DateTime>(nullable: false),
                    NameOfIncome = table.Column<string>(nullable: true),
                    PreisOfIncome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.IncomeId);
                });

            migrationBuilder.CreateTable(
                name: "Kontakts",
                columns: table => new
                {
                    KontaktId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(nullable: true),
                    Land = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Nummer = table.Column<string>(nullable: true),
                    PLZ = table.Column<string>(nullable: true),
                    Strasse = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakts", x => x.KontaktId);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfModify = table.Column<string>(nullable: true),
                    Login1 = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Company = table.Column<string>(nullable: true),
                    DateOfModify = table.Column<DateTime>(nullable: false),
                    DateOfRegistration = table.Column<DateTime>(nullable: false),
                    Geburtsdatum = table.Column<DateTime>(nullable: false),
                    Middlename = table.Column<string>(nullable: true),
                    Nachname = table.Column<string>(nullable: true),
                    PrefferedLanguage = table.Column<string>(nullable: true),
                    Titel = table.Column<string>(nullable: true),
                    Vorname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Kontakts");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
