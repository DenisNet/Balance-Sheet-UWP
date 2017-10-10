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
    public sealed partial class Personal : Page
    {
        public Personal()
        {
            this.InitializeComponent();

            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            CategoryTextTxtBlock.Text = loader.GetString("Private");
            txtBlockAccessoires.Text = loader.GetString("Accessoires");
            txtBlockFrisuer.Text = loader.GetString("Hairdressing");
            txtBlockKleidung.Text = loader.GetString("Dress");
            txtBlockKosmetik.Text = loader.GetString("Cosmetics");
            txtBlockMedizin.Text = loader.GetString("Medicine");
            txtBlockWellness.Text = loader.GetString("Wellness");
            txtBlockSonstige.Text = loader.GetString("OtherPrivate");

            this.Loaded += Personal_Loaded;
        }

        private void Personal_Loaded(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnAccessoires.Width = fixKostenStack.ActualWidth - 20;
                btnAccessoires.Height = fixKostenStack.ActualWidth - 20;

                btnFrisuer.Width = fixKostenStack.ActualWidth - 20;
                btnFrisuer.Height = fixKostenStack.ActualWidth - 20;

                btnKleidung.Width = fixKostenStack.ActualWidth - 20;
                btnKleidung.Height = fixKostenStack.ActualWidth - 20;

                btnKosmetik.Width = fixKostenStack.ActualWidth - 20;
                btnKosmetik.Height = fixKostenStack.ActualWidth - 20;

                btnMedizin.Width = fixKostenStack.ActualWidth - 20;
                btnMedizin.Height = fixKostenStack.ActualWidth - 20;

                btnWellness.Width = fixKostenStack.ActualWidth - 20;
                btnWellness.Height = fixKostenStack.ActualWidth - 20;

                btnSonstige.Width = fixKostenStack.ActualWidth - 20;
                btnSonstige.Height = fixKostenStack.ActualWidth - 20;
            }
            else
            {
                CmBoxItemCost.Width = ActualWidth / 2;
                CmBoxItemIncome.Width = ActualWidth / 2;
                BtnBack.Visibility = Visibility.Collapsed;
                BtnCancel.Visibility = Visibility.Collapsed;

                btnAccessoires.Width = fixKostenStack.ActualWidth / 2;
                btnAccessoires.Height = fixKostenStack.ActualWidth / 2;
                btnAccessoires.Style = null;

                btnFrisuer.Width = fixKostenStack.ActualWidth / 2;
                btnFrisuer.Height = fixKostenStack.ActualWidth / 2;
                btnFrisuer.Style = null;

                btnKleidung.Width = fixKostenStack.ActualWidth / 2;
                btnKleidung.Height = fixKostenStack.ActualWidth / 2;
                btnKleidung.Style = null;

                btnKosmetik.Width = fixKostenStack.ActualWidth / 2;
                btnKosmetik.Height = fixKostenStack.ActualWidth / 2;
                btnKosmetik.Style = null;

                btnMedizin.Width = fixKostenStack.ActualWidth / 2;
                btnMedizin.Height = fixKostenStack.ActualWidth / 2;
                btnMedizin.Style = null;

                btnWellness.Width = fixKostenStack.ActualWidth / 2;
                btnWellness.Height = fixKostenStack.ActualWidth / 2;
                btnWellness.Style = null;

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

        private void btnAccessoires_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Private.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = PersonalUnderCategory.Accessoires.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnFrisuer_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Private.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = PersonalUnderCategory.Hairdressing.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnKleidung_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Private.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = PersonalUnderCategory.Dress.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnKosmetik_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Private.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = PersonalUnderCategory.Cosmetics.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnMedizin_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Private.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = PersonalUnderCategory.Medicine.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnWellness_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Private.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = PersonalUnderCategory.Wellness.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnSonstige_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(CategorySymbolTxtBlock.Text, CategoryNamenCosts.Private.ToString(), CategorySymbolTxtBlock.FontFamily, clickButton.Content.ToString(), clickButton.FontFamily, comboBox.SelectedIndex);

            SaveResult.UnderCategoryName = PersonalUnderCategory.Wellness.ToString();
            this.Frame.Navigate(typeof(SaveResult), null);
        }
    }
}
