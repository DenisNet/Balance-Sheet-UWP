using BalanceSheet.Models;
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


namespace BalanceSheet.Views.Mobile
{
    public sealed partial class Statistik_Mobile : Page
    {
        MonatYearDaten datenViewModel;
        public Statistik_Mobile()
        {
            this.InitializeComponent();
            datenViewModel = new MonatYearDaten();
            this.Loaded += Statistik_Mobile_Loaded;
        }

        private void Statistik_Mobile_Loaded(object sender, RoutedEventArgs e)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            pivotMain.Title = loader.GetString("Costs");
            pivotFixKosten.Header = loader.GetString(CategoryNamenCosts.Fixed.ToString());
            pivotLebensmittel.Header = loader.GetString(CategoryNamenCosts.Foods.ToString());
            pivotAuto.Header = loader.GetString(CategoryNamenCosts.Auto.ToString());
            pivotUnterhaltung.Header = loader.GetString(CategoryNamenCosts.Entertainment.ToString());
            pivotVerkehr.Header = loader.GetString(CategoryNamenCosts.Transport.ToString());
            pivotPersonal.Header = loader.GetString(CategoryNamenCosts.Private.ToString());
        }

        private void pivotMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Controls.Chart.PivotChart.Berechnung berechName = new Controls.Chart.PivotChart.Berechnung();
            if (pivotMain.SelectedIndex == 0)
            {
                berechName.SetCategoryName(pivotMain.SelectedIndex);
            }
            else if (pivotMain.SelectedIndex == 1)
            {
                berechName.SetCategoryName(pivotMain.SelectedIndex);
            }
            else if (pivotMain.SelectedIndex == 2)
            {
                berechName.SetCategoryName(pivotMain.SelectedIndex);
            }
            else if (pivotMain.SelectedIndex == 3)
            {
                berechName.SetCategoryName(pivotMain.SelectedIndex);
            }
            else if (pivotMain.SelectedIndex == 4)
            {
                berechName.SetCategoryName(pivotMain.SelectedIndex);
            }
            else if (pivotMain.SelectedIndex == 5)
            {
                berechName.SetCategoryName(pivotMain.SelectedIndex);
            }
        }
    }
}
