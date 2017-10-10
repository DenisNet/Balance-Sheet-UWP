using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BalanceSheet.ViewModels;
using BalanceSheet.Unity;
using Microsoft.Practices.ServiceLocation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using BalanceSheet.Views.Mobile.CostsIncomes;
using System.Collections.ObjectModel;
using Windows.UI;
using BalanceSheet.Models;
using Windows.UI.Xaml.Documents;

namespace BalanceSheet.Views
{
    sealed partial class HomePage_Mobile : BalanceSheet.Views.BasePage
    {
        UserNumberFormat uNFI;
        MonatYearDaten datenViewModel;
        public HomePage_Mobile()
        {
            InitializeComponent();

            datenViewModel = new MonatYearDaten();
            this.Loaded += HomePage_Loaded;
            uNFI = new UserNumberFormat();
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            var btn = new AppShellToggleButton();
            btn.SetShellButton(true);
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            BtnTxtAusgbe.Text = loader.GetString("BtnCostsHome");
            BtnTxtEinnahme.Text = loader.GetString("BtnIncomesHome");
            txtBalanceText.Text = loader.GetString("TxtBalanceHome");
            txtIncomeText.Text = loader.GetString("TxtIncomesHome");
            txtCostText.Text = loader.GetString("TxtCostsHome");

            var datum = new MonatYearDaten();

            if (datum.Monat > 0 || datum.Year > 0)
            {
                BtnMonatAuswahl.Content = datum.GetMonatYearString();
            }
            txtAusgabe.Text = datum.GetWertAusgabe().ToString("C", uNFI.GetNFI());
            txtEinnahme.Text = datum.GetWertEinnahme().ToString("C", uNFI.GetNFI());
            txtBalance.Text = datum.GetWertBalance().ToString("C", uNFI.GetNFI());
            if (datum.GetWertBalance() < 0)
            {
                txtBalance.Foreground = new SolidColorBrush(Color.FromArgb(255, 204, 51, 51));
            }
        }

        private void BtnAusgbe_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Mobile.AddPage_Mobile));
        }

        private void BtnEinnahme_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Mobile.CostsIncomes.Incomes), null);
        }

        private void BtnMonatAuswahl_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Calendar));
        }

    }
}