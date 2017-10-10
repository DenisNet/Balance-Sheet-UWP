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
    public sealed partial class FixKosten : Page
    {
        public FixKosten()
        {
            this.InitializeComponent();
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            CategoryTextTxtBlock.Text = loader.GetString("Fixed");
            txtBlockBank.Text = loader.GetString("Bank");
            txtBlockMiete.Text = loader.GetString("Rental");
            txtBlockGrundschuld.Text = loader.GetString("Groundshuld");
            txtBlockNebenkosten.Text = loader.GetString("Extracosts");
            txtBlockFernsehen.Text = loader.GetString("TV");
            txtBlockInternet.Text = loader.GetString("Internet");
            txtBlockTelefon.Text = loader.GetString("Telefons");
            txtBlockVersicherung.Text = loader.GetString("InsuranceFix");
            txtBlockSteuer.Text = loader.GetString("Tax");
            txtBlockSonstige.Text = loader.GetString("OtherFix");

            this.Loaded += FixKosten_Loaded;
        }

        private void FixKosten_Loaded(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {

                btnBank.Width = fixKostenStack.ActualWidth - 20;
                btnBank.Height = fixKostenStack.ActualWidth - 20;

                btnMiete.Width = fixKostenStack.ActualWidth - 20;
                btnMiete.Height = fixKostenStack.ActualWidth - 20;

                btnGrundschuld.Width = fixKostenStack.ActualWidth - 20;
                btnGrundschuld.Height = fixKostenStack.ActualWidth - 20;

                btnNebenkosten.Width = fixKostenStack.ActualWidth - 20;
                btnNebenkosten.Height = fixKostenStack.ActualWidth - 20;

                btnFernsehen.Width = fixKostenStack.ActualWidth - 20;
                btnFernsehen.Height = fixKostenStack.ActualWidth - 20;

                btnInternet.Width = fixKostenStack.ActualWidth - 20;
                btnInternet.Height = fixKostenStack.ActualWidth - 20;

                btnTelefon.Width = fixKostenStack.ActualWidth - 20;
                btnTelefon.Height = fixKostenStack.ActualWidth - 20;

                btnVersicherung.Width = fixKostenStack.ActualWidth - 20;
                btnVersicherung.Height = fixKostenStack.ActualWidth - 20;

                btnSteuer.Width = fixKostenStack.ActualWidth - 20;
                btnSteuer.Height = fixKostenStack.ActualWidth - 20;

                btnSonstige.Width = fixKostenStack.ActualWidth - 20;
                btnSonstige.Height = fixKostenStack.ActualWidth - 20;
            }
            else
            {
                CmBoxItemCost.Width = ActualWidth / 2;
                CmBoxItemIncome.Width = ActualWidth / 2;
                BtnBack.Visibility = Visibility.Collapsed;
                BtnCancel.Visibility = Visibility.Collapsed;

                btnBank.Width = fixKostenStack.ActualWidth / 2;
                btnBank.Height = fixKostenStack.ActualWidth / 2;
                btnBank.Style = null;

                btnMiete.Width = fixKostenStack.ActualWidth / 2;
                btnMiete.Height = fixKostenStack.ActualWidth / 2;
                btnMiete.Style = null;

                btnGrundschuld.Width = fixKostenStack.ActualWidth / 2;
                btnGrundschuld.Height = fixKostenStack.ActualWidth / 2;
                btnGrundschuld.Style = null;

                btnNebenkosten.Width = fixKostenStack.ActualWidth / 2;
                btnNebenkosten.Height = fixKostenStack.ActualWidth / 2;
                btnNebenkosten.Style = null;

                btnFernsehen.Width = fixKostenStack.ActualWidth / 2;
                btnFernsehen.Height = fixKostenStack.ActualWidth / 2;
                btnFernsehen.Style = null;

                btnInternet.Width = fixKostenStack.ActualWidth / 2;
                btnInternet.Height = fixKostenStack.ActualWidth / 2;
                btnInternet.Style = null;

                btnTelefon.Width = fixKostenStack.ActualWidth / 2;
                btnTelefon.Height = fixKostenStack.ActualWidth / 2;
                btnTelefon.Style = null;

                btnVersicherung.Width = fixKostenStack.ActualWidth / 2;
                btnVersicherung.Height = fixKostenStack.ActualWidth / 2;
                btnVersicherung.Style = null;

                btnSteuer.Width = fixKostenStack.ActualWidth / 2;
                btnSteuer.Height = fixKostenStack.ActualWidth / 2;
                btnSteuer.Style = null;

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

        private void btnBank_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.Bank.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnMiete_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.Rental.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnGrundschuld_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.Groundshuld.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnNebenkosten_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.Extracosts.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnFernsehen_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.TV.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnInternet_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.Internet.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnTelefon_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.Telefons.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnVersicherung_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.InsuranceFix.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnSteuer_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.Tax.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnSonstige_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Fixed.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = FixkostenUnderCategory.OtherFix.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }
    }
}
