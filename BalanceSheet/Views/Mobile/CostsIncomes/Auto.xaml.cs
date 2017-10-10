using BalanceSheet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BalanceSheet.Views.Mobile.CostsIncomes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Auto : Page
    {
        public Auto()
        {
            this.InitializeComponent();
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            txtBlockKraftstoff.Text = loader.GetString("Fuel");
            txtBlockReparatur.Text = loader.GetString("Repair");
            txtBlockWaschen.Text = loader.GetString("Wash");
            txtBlockVersicherung.Text = loader.GetString("InsuranceAuto");
            txtBlockBussgeld.Text = loader.GetString("Fine");
            txtBlockSonstige.Text = loader.GetString("OtherAuto");
            this.Loaded += Auto_Loaded;
        }

        private void Auto_Loaded(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnKraftstoff.Width = fixKostenStack.ActualWidth - 20;
                btnKraftstoff.Height = fixKostenStack.ActualWidth - 20;

                btnReparatur.Width = fixKostenStack.ActualWidth - 20;
                btnReparatur.Height = fixKostenStack.ActualWidth - 20;

                btnWaschen.Width = fixKostenStack.ActualWidth - 20;
                btnWaschen.Height = fixKostenStack.ActualWidth - 20;

                btnVersicherung.Width = fixKostenStack.ActualWidth - 20;
                btnVersicherung.Height = fixKostenStack.ActualWidth - 20;

                btnBussgeld.Width = fixKostenStack.ActualWidth - 20;
                btnBussgeld.Height = fixKostenStack.ActualWidth - 20;

                btnSonstige.Width = fixKostenStack.ActualWidth - 20;
                btnSonstige.Height = fixKostenStack.ActualWidth - 20;
            }
            else
            {
                CmBoxItemCost.Width = ActualWidth / 2;
                CmBoxItemIncome.Width = ActualWidth / 2;
                BtnBack.Visibility = Visibility.Collapsed;
                BtnCancel.Visibility = Visibility.Collapsed;

                btnKraftstoff.Width = fixKostenStack.ActualWidth / 2;
                btnKraftstoff.Height = fixKostenStack.ActualWidth / 2;
                btnKraftstoff.Style = null;

                btnReparatur.Width = fixKostenStack.ActualWidth / 2;
                btnReparatur.Height = fixKostenStack.ActualWidth / 2;
                btnReparatur.Style = null;

                btnWaschen.Width = fixKostenStack.ActualWidth / 2;
                btnWaschen.Height = fixKostenStack.ActualWidth / 2;
                btnWaschen.Style = null;

                btnVersicherung.Width = fixKostenStack.ActualWidth / 2;
                btnVersicherung.Height = fixKostenStack.ActualWidth / 2;
                btnVersicherung.Style = null;

                btnBussgeld.Width = fixKostenStack.ActualWidth / 2;
                btnBussgeld.Height = fixKostenStack.ActualWidth / 2;
                btnBussgeld.Style = null;

                btnSonstige.Width = fixKostenStack.ActualWidth / 2;
                btnSonstige.Height = fixKostenStack.ActualWidth / 2;
                btnSonstige.Style = null;

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void comboBox_DropDownClosed(object sender, object e)
        {
            NavigateDropDownClosed.NavigateDropDownClosedMethod(comboBox, gridMain, gridTemp, this.Frame);
        }

        Grid gridTemp = new Grid();

        private void comboBox_DropDownOpened(object sender, object e)
        {
            gridTemp.Width = gridMain.ActualWidth;
            gridTemp.Height = gridMain.ActualHeight;
            gridTemp.Background = new SolidColorBrush(Color.FromArgb(255, 17, 157, 218));
            gridTemp.Opacity = 0.9;
            gridTemp.Margin = new Thickness(0, -25, 0, 0);
            gridMain.Children.Add(gridTemp);
        }

        private void btnKraftstoff_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Auto.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = AutoUnderCategory.Fuel.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnReparatur_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Auto.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = AutoUnderCategory.Repair.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnWaschen_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Auto.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = AutoUnderCategory.Wash.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnVersicherung_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Auto.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = AutoUnderCategory.InsuranceAuto.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnBussgeld_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Auto.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = AutoUnderCategory.Fine.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnSonstige_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Auto.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = AutoUnderCategory.OtherAuto.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }
    }
}
