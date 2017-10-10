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
    public sealed partial class Verkehr : Page
    {
        public Verkehr()
        {
            this.InitializeComponent();

            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            CategoryTextTxtBlock.Text = loader.GetString("Transport");
            txtBlockBahnticket.Text = loader.GetString("Trainticket");
            txtBlockEinzelticket.Text = loader.GetString("Singleticket");
            txtBlockTaxi.Text = loader.GetString("Taxi");
            txtBlockFlug.Text = loader.GetString("Flightticket");
            txtBlockMonatsticket.Text = loader.GetString("Monthlyticket");
            txtBlockSonstige.Text = loader.GetString("OtherTransport");

            this.Loaded += Verkehr_Loaded;

        }

        private void Verkehr_Loaded(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnBahnticket.Width = fixKostenStack.ActualWidth - 20;
                btnBahnticket.Height = fixKostenStack.ActualWidth - 20;

                btnEinzelticket.Width = fixKostenStack.ActualWidth - 20;
                btnEinzelticket.Height = fixKostenStack.ActualWidth - 20;

                btnTaxi.Width = fixKostenStack.ActualWidth - 20;
                btnTaxi.Height = fixKostenStack.ActualWidth - 20;

                btnFlug.Width = fixKostenStack.ActualWidth - 20;
                btnFlug.Height = fixKostenStack.ActualWidth - 20;

                btnMonatsticket.Width = fixKostenStack.ActualWidth - 20;
                btnMonatsticket.Height = fixKostenStack.ActualWidth - 20;

                btnSonstige.Width = fixKostenStack.ActualWidth - 20;
                btnSonstige.Height = fixKostenStack.ActualWidth - 20;
            }
            else
            {
                CmBoxItemCost.Width = ActualWidth / 2;
                CmBoxItemIncome.Width = ActualWidth / 2;
                BtnBack.Visibility = Visibility.Collapsed;
                BtnCancel.Visibility = Visibility.Collapsed;

                btnBahnticket.Width = fixKostenStack.ActualWidth / 2;
                btnBahnticket.Height = fixKostenStack.ActualWidth / 2;
                btnBahnticket.Style = null;

                btnEinzelticket.Width = fixKostenStack.ActualWidth / 2;
                btnEinzelticket.Height = fixKostenStack.ActualWidth / 2;
                btnEinzelticket.Style = null;

                btnTaxi.Width = fixKostenStack.ActualWidth / 2;
                btnTaxi.Height = fixKostenStack.ActualWidth / 2;
                btnTaxi.Style = null;

                btnFlug.Width = fixKostenStack.ActualWidth / 2;
                btnFlug.Height = fixKostenStack.ActualWidth / 2;
                btnFlug.Style = null;

                btnMonatsticket.Width = fixKostenStack.ActualWidth / 2;
                btnMonatsticket.Height = fixKostenStack.ActualWidth / 2;
                btnMonatsticket.Style = null;

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

        private void btnBahnticket_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Transport.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = VerkehrUnderCategory.Trainticket.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnEinzelticket_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Transport.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = VerkehrUnderCategory.Singleticket.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnTaxi_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Transport.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = VerkehrUnderCategory.Taxi.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnFlug_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Transport.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = VerkehrUnderCategory.Flightticket.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnMonatsticket_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Transport.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = VerkehrUnderCategory.Monthlyticket.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnSonstige_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Transport.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = VerkehrUnderCategory.OtherTransport.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }
    }
}
