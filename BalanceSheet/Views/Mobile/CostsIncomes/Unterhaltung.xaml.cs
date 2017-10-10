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
    public sealed partial class Unterhaltung : Page
    {
        public Unterhaltung()
        {
            this.InitializeComponent();

            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            CategoryTextTxtBlock.Text = loader.GetString("Entertainment");
            txtBlockCafe.Text = loader.GetString("Cafe");
            txtBlockPizza.Text = loader.GetString("Pizza");
            txtBlockRestaurant.Text = loader.GetString("Restaurant");
            txtBlockKino.Text = loader.GetString("Kino");
            txtBlockTheater.Text = loader.GetString("Theatre");
            txtBlockSonstige.Text = loader.GetString("OtherEntertainment");

            this.Loaded += Unterhaltung_Loaded;
        }

        private void Unterhaltung_Loaded(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnCafe.Width = fixKostenStack.ActualWidth - 20;
                btnCafe.Height = fixKostenStack.ActualWidth - 20;

                btnPizza.Width = fixKostenStack.ActualWidth - 20;
                btnPizza.Height = fixKostenStack.ActualWidth - 20;

                btnRestaurant.Width = fixKostenStack.ActualWidth - 20;
                btnRestaurant.Height = fixKostenStack.ActualWidth - 20;

                btnKino.Width = fixKostenStack.ActualWidth - 20;
                btnKino.Height = fixKostenStack.ActualWidth - 20;

                btnTheater.Width = fixKostenStack.ActualWidth - 20;
                btnTheater.Height = fixKostenStack.ActualWidth - 20;

                btnSonstige.Width = fixKostenStack.ActualWidth - 20;
                btnSonstige.Height = fixKostenStack.ActualWidth - 20;
            }
            else
            {
                CmBoxItemCost.Width = ActualWidth / 2;
                CmBoxItemIncome.Width = ActualWidth / 2;
                BtnBack.Visibility = Visibility.Collapsed;
                BtnCancel.Visibility = Visibility.Collapsed;

                btnCafe.Width = fixKostenStack.ActualWidth / 2;
                btnCafe.Height = fixKostenStack.ActualWidth / 2;
                btnCafe.Style = null;

                btnPizza.Width = fixKostenStack.ActualWidth / 2;
                btnPizza.Height = fixKostenStack.ActualWidth / 2;
                btnPizza.Style = null;

                btnRestaurant.Width = fixKostenStack.ActualWidth / 2;
                btnRestaurant.Height = fixKostenStack.ActualWidth / 2;
                btnRestaurant.Style = null;

                btnKino.Width = fixKostenStack.ActualWidth / 2;
                btnKino.Height = fixKostenStack.ActualWidth / 2;
                btnKino.Style = null;

                btnTheater.Width = fixKostenStack.ActualWidth / 2;
                btnTheater.Height = fixKostenStack.ActualWidth / 2;
                btnTheater.Style = null;

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

        private void btnCafe_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Entertainment.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = UnterhaltungUnderCategory.Cafe.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnPizza_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Entertainment.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = UnterhaltungUnderCategory.Pizza.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnRestaurant_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Entertainment.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = UnterhaltungUnderCategory.Restaurant.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnKino_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Entertainment.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = UnterhaltungUnderCategory.Kino.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnTheater_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Entertainment.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = UnterhaltungUnderCategory.Theatre.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnSonstige_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Entertainment.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = UnterhaltungUnderCategory.OtherEntertainment.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }
    }
}
