using BalanceSheet.Models;
using BalanceSheet.ValueConverters;
using BalanceSheet.ViewModels;
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

namespace BalanceSheet.Views.Mobile.CostsIncomes
{
    public sealed partial class Lebensmittel : Page
    {
        public Lebensmittel()
        {
            this.InitializeComponent();

            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            CategoryTextTxtBlock.Text = loader.GetString("Foods");
            txtBlockFleisch.Text = loader.GetString("Meat");
            txtBlockMeerprod.Text = loader.GetString("Meer");
            txtBlockObst.Text = loader.GetString("FruitVegetabele");
            txtBlockBackwaren.Text = loader.GetString("Bakery");
            txtBlockMilch.Text = loader.GetString("Milk");
            txtBlockSussigkeit.Text = loader.GetString("Sweetnes");
            txtBlockGetrenk.Text = loader.GetString("Drinks");
            txtBlockSonstige.Text = loader.GetString("OtherFoods");

            this.Loaded += Lebensmittel_Loaded;
        }

        private void Lebensmittel_Loaded(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnFleisch.Width = fixKostenStack.ActualWidth - 20;
                btnFleisch.Height = fixKostenStack.ActualWidth - 20;

                btnMeerprod.Width = fixKostenStack.ActualWidth - 20;
                btnMeerprod.Height = fixKostenStack.ActualWidth - 20;

                btnObst.Width = fixKostenStack.ActualWidth - 20;
                btnObst.Height = fixKostenStack.ActualWidth - 20;

                btnBackwaren.Width = fixKostenStack.ActualWidth - 20;
                btnBackwaren.Height = fixKostenStack.ActualWidth - 20;

                btnMilch.Width = fixKostenStack.ActualWidth - 20;
                btnMilch.Height = fixKostenStack.ActualWidth - 20;

                btnSussigkeit.Width = fixKostenStack.ActualWidth - 20;
                btnSussigkeit.Height = fixKostenStack.ActualWidth - 20;

                btnGetrenk.Width = fixKostenStack.ActualWidth - 20;
                btnGetrenk.Height = fixKostenStack.ActualWidth - 20;

                btnSonstige.Width = fixKostenStack.ActualWidth - 20;
                btnSonstige.Height = fixKostenStack.ActualWidth - 20;
            }
            else
            {
                CmBoxItemCost.Width = ActualWidth / 2;
                CmBoxItemIncome.Width = ActualWidth / 2;
                BtnBack.Visibility = Visibility.Collapsed;
                BtnCancel.Visibility = Visibility.Collapsed;

                btnFleisch.Width = fixKostenStack.ActualWidth / 2;
                btnFleisch.Height = fixKostenStack.ActualWidth / 2;
                btnFleisch.Style = null;

                btnMeerprod.Width = fixKostenStack.ActualWidth / 2;
                btnMeerprod.Height = fixKostenStack.ActualWidth / 2;
                btnMeerprod.Style = null;

                btnObst.Width = fixKostenStack.ActualWidth / 2;
                btnObst.Height = fixKostenStack.ActualWidth / 2;
                btnObst.Style = null;

                btnBackwaren.Width = fixKostenStack.ActualWidth / 2;
                btnBackwaren.Height = fixKostenStack.ActualWidth / 2;
                btnBackwaren.Style = null;

                btnMilch.Width = fixKostenStack.ActualWidth / 2;
                btnMilch.Height = fixKostenStack.ActualWidth / 2;
                btnMilch.Style = null;

                btnSussigkeit.Width = fixKostenStack.ActualWidth / 2;
                btnSussigkeit.Height = fixKostenStack.ActualWidth / 2;
                btnSussigkeit.Style = null;

                btnGetrenk.Width = fixKostenStack.ActualWidth / 2;
                btnGetrenk.Height = fixKostenStack.ActualWidth / 2;
                btnGetrenk.Style = null;

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

        private void btnFleisch_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Foods.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = LebensmittelUnderCategory.Meat.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);

        }

        private void btnObst_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Foods.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = LebensmittelUnderCategory.FruitVegetabele.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);

        }

        private void btnMeerprod_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Foods.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = LebensmittelUnderCategory.Meer.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);

        }

        private void btnBackwaren_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Foods.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = LebensmittelUnderCategory.Bakery.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);

        }

        private void btnMilch_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Foods.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = LebensmittelUnderCategory.Milk.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);

        }

        private void btnSussigkeit_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Foods.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = LebensmittelUnderCategory.Sweetnes.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);

        }

        private void btnGetrenk_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Foods.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = LebensmittelUnderCategory.Drinks.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);

        }

        private void btnSonstige_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Foods.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = LebensmittelUnderCategory.OtherFoods.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);

        }
    }
}
