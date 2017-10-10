using BalanceSheet.ContractModelConverterExtensions;
using BalanceSheet.Models;
using BalanceSheet.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace BalanceSheet.Views
{
    public sealed partial class HomePage : Page
    {
        MonatYearDaten datum;
        Mobile.CostsIncomes.UserNumberFormat uNFI;
        private readonly HomeViewModel viewModel;


        public HomePage()
        {
            this.InitializeComponent();

            viewModel = ServiceLocator.Current.GetInstance<HomeViewModel>();
            DataContext = viewModel;

            datum = new MonatYearDaten();
            uNFI = new Mobile.CostsIncomes.UserNumberFormat();

            this.Loaded += HomePage_Loaded;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            var btn = new ViewModels.AppShellToggleButton();
            btn.SetShellButton(true);
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            BtnTxtAusgbe.Text = loader.GetString("BtnCostsHome");
            BtnTxtEinnahme.Text = loader.GetString("BtnIncomesHome");
            //txtBalanceText.Text = loader.GetString("TxtBalanceHome");
            //txtIncomeText.Text = loader.GetString("TxtIncomesHome");
            //txtCostText.Text = loader.GetString("TxtCostsHome");

            var datum = new MonatYearDaten();

            if (datum.Monat > 0 || datum.Year > 0)
            {
                BtnMonatAuswahl.Content = datum.GetMonatYearString();
            }
            //txtAusgabe.Text = datum.GetWertAusgabe().ToString("C", uNFI.GetNFI());
            //txtEinnahme.Text = datum.GetWertEinnahme().ToString("C", uNFI.GetNFI());
            //txtBalance.Text = datum.GetWertBalance().ToString("C", uNFI.GetNFI());
            //if (datum.GetWertBalance() < 0)
            //{
            //    //txtBalance.Foreground = new SolidColorBrush(Color.FromArgb(255, 204, 51, 51));
            //}
        }

        private void BtnMonatAuswahl_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Calendar));
        }

        private void MonatAuswahl_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Calendar));
        }

        private void BtnEinnahme_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Mobile.CostsIncomes.Incomes), null);
        }

        private void BtnAusgabe_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Mobile.AddPage_Mobile));
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await viewModel.LoadState();
        }

    }
}
