using BalanceSheet.Models;
using BalanceSheet.Views.Mobile.CostsIncomes;
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

namespace BalanceSheet.Views.Mobile
{
    /// <summary>
    /// Page for Mobile Incomes and Costs
    /// </summary>
    public sealed partial class AddPage_Mobile : Page
    {
        public AddPage_Mobile()
        {
            this.InitializeComponent();

            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            txtFixkosten.Text = loader.GetString("Fixed");
            txtFoods.Text = loader.GetString("Foods");
            txtAuto.Text = loader.GetString("Auto");
            txtBildung.Text = loader.GetString("Education");
            txtApp.Text = loader.GetString("Apps");
            txtUrlaub.Text = loader.GetString("Vacation");
            txtUnterhaltung.Text = loader.GetString("Entertainment");
            txtHaus.Text = loader.GetString("House");
            txtVerkehr.Text = loader.GetString("Transport");
            txtPersonal.Text = loader.GetString("Private");
            txtSonst.Text = loader.GetString("OtherCosts");

            this.Loaded += AddPage_Mobile_Loaded;
        }

        private void AddPage_Mobile_Loaded(object sender, RoutedEventArgs e)
        {
            var btn = new ViewModels.AppShellToggleButton();
            btn.SetShellButton(false);
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                fixKosten.Width = fixKostenStack.ActualWidth - 20;
                fixKosten.Height = fixKostenStack.ActualWidth - 20;

                food.Width = fixKostenStack.ActualWidth - 20;
                food.Height = fixKostenStack.ActualWidth - 20;

                auto.Width = fixKostenStack.ActualWidth - 20;
                auto.Height = fixKostenStack.ActualWidth - 20;

                bildung.Width = fixKostenStack.ActualWidth - 20;
                bildung.Height = fixKostenStack.ActualWidth - 20;

                softService.Width = fixKostenStack.ActualWidth - 20;
                softService.Height = fixKostenStack.ActualWidth - 20;

                urlaub.Width = fixKostenStack.ActualWidth - 20;
                urlaub.Height = fixKostenStack.ActualWidth - 20;

                unterhaltung.Width = fixKostenStack.ActualWidth - 20;
                unterhaltung.Height = fixKostenStack.ActualWidth - 20;

                allInHouse.Width = fixKostenStack.ActualWidth - 20;
                allInHouse.Height = fixKostenStack.ActualWidth - 20;

                transport.Width = fixKostenStack.ActualWidth - 20;
                transport.Height = fixKostenStack.ActualWidth - 20;

                personKosten.Width = fixKostenStack.ActualWidth - 20;
                personKosten.Height = fixKostenStack.ActualWidth - 20;

                others.Width = fixKostenStack.ActualWidth - 20;
                others.Height = fixKostenStack.ActualWidth - 20;
            }
            else
            {
                CmBoxItemCost.Width = ActualWidth / 2;
                CmBoxItemIncome.Width = ActualWidth / 2;
                BtnCancel.Visibility = Visibility.Collapsed;

                fixKosten.Width = fixKostenStack.ActualWidth / 2;
                fixKosten.Height = fixKostenStack.ActualWidth / 2;
                fixKosten.Style = null;

                food.Width = fixKostenStack.ActualWidth / 2;
                food.Height = fixKostenStack.ActualWidth / 2;
                food.Style = null;

                auto.Width = fixKostenStack.ActualWidth / 2;
                auto.Height = fixKostenStack.ActualWidth / 2;
                auto.Style = null;

                bildung.Width = fixKostenStack.ActualWidth / 2;
                bildung.Height = fixKostenStack.ActualWidth / 2;
                bildung.Style = null;

                softService.Width = fixKostenStack.ActualWidth / 2;
                softService.Height = fixKostenStack.ActualWidth / 2;
                softService.Style = null;

                urlaub.Width = fixKostenStack.ActualWidth / 2;
                urlaub.Height = fixKostenStack.ActualWidth / 2;
                urlaub.Style = null;

                unterhaltung.Width = fixKostenStack.ActualWidth / 2;
                unterhaltung.Height = fixKostenStack.ActualWidth / 2;
                unterhaltung.Style = null;

                allInHouse.Width = fixKostenStack.ActualWidth / 2;
                allInHouse.Height = fixKostenStack.ActualWidth / 2;
                allInHouse.Style = null;

                transport.Width = fixKostenStack.ActualWidth / 2;
                transport.Height = fixKostenStack.ActualWidth / 2;
                transport.Style = null;

                personKosten.Width = fixKostenStack.ActualWidth / 2;
                personKosten.Height = fixKostenStack.ActualWidth / 2;
                personKosten.Style = null;

                others.Width = fixKostenStack.ActualWidth / 2;
                others.Height = fixKostenStack.ActualWidth / 2;
                others.Style = null;
            }

        }

        Grid gridTemp = new Grid();

        private void ComboBox_DropDownClosed(object sender, object e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                gridListView.Children.Remove(gridTemp);
            }
            else
            {
                if (this.Frame != null && this.Frame.CanGoBack)
                {
                    this.Frame.GoBack();
                }
                this.Frame.Navigate(typeof(Incomes), null);
            }
        }

        private void ComboBox_DropDownOpened(object sender, object e)
        {
            gridTemp.Width = gridMain.ActualWidth;
            gridTemp.Height = gridListView.ActualHeight + 30;
            gridTemp.Background = new SolidColorBrush(Color.FromArgb(255, 17, 157, 218));
            gridTemp.Opacity = 0.9;
            gridTemp.Margin = new Thickness(0, -25, 0, 0);
            gridListView.Children.Add(gridTemp);
        }

        //Button >>Back<<
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void BtnFixKosten_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BalanceSheet.Views.Mobile.CostsIncomes.FixKosten), null);
        }

        private void BtnFood_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BalanceSheet.Views.Mobile.CostsIncomes.Lebensmittel), null);
        }

        private void BtnTransport_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BalanceSheet.Views.Mobile.CostsIncomes.Verkehr), null);
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BalanceSheet.Views.Mobile.CostsIncomes.Auto), null);
        }

        private void BtnUnterhaltung_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BalanceSheet.Views.Mobile.CostsIncomes.Unterhaltung), null);
        }

        private void BtnPersonKosten_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BalanceSheet.Views.Mobile.CostsIncomes.Personal), null);
        }

        private void bildung_Click(object sender, RoutedEventArgs e)
        {
            SaveResult saveResult = new SaveResult(bildung.Content.ToString(), CategoryNamenCosts.Education.ToString(), bildung.FontFamily, comboBox.SelectedIndex);
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void softService_Click(object sender, RoutedEventArgs e)
        {
            SaveResult saveResult = new SaveResult(softService.Content.ToString(), CategoryNamenCosts.Apps.ToString(), softService.FontFamily, comboBox.SelectedIndex);
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void urlaub_Click(object sender, RoutedEventArgs e)
        {
            SaveResult saveResult = new SaveResult(urlaub.Content.ToString(), CategoryNamenCosts.Vacation.ToString(), urlaub.FontFamily, comboBox.SelectedIndex);
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void allInHouse_Click(object sender, RoutedEventArgs e)
        {
            SaveResult saveResult = new SaveResult(allInHouse.Content.ToString(), CategoryNamenCosts.House.ToString(), allInHouse.FontFamily, comboBox.SelectedIndex);
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void others_Click(object sender, RoutedEventArgs e)
        {
            SaveResult saveResult = new SaveResult(others.Content.ToString(), CategoryNamenCosts.OtherCosts.ToString(), others.FontFamily, comboBox.SelectedIndex);
            this.Frame.Navigate(typeof(SaveResult), null);
        }
    }
}
