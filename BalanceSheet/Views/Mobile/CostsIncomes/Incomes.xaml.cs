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


namespace BalanceSheet.Views.Mobile.CostsIncomes
{
    public sealed partial class Incomes : Page
    {
        public Incomes()
        {
            this.InitializeComponent();

            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            txtGehalt.Text = loader.GetString("Salary");
            txtOthersIncome.Text = loader.GetString("OtherIncomes");

            this.Loaded += Incomes_Loaded;
        }

        private void Incomes_Loaded(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnGehalt.Width = fixKostenStack.ActualWidth - 20;
                btnGehalt.Height = fixKostenStack.ActualWidth - 20;

                btnOthersIncome.Width = fixKostenStack.ActualWidth - 20;
                btnOthersIncome.Height = fixKostenStack.ActualWidth - 20;
            }
            else
            {
                CmBoxItemCost.Width = ActualWidth / 2;
                CmBoxItemIncome.Width = ActualWidth / 2;
                BtnCancel.Visibility = Visibility.Collapsed;

                btnGehalt.Width = fixKostenStack.ActualWidth / 2;
                btnGehalt.Height = fixKostenStack.ActualWidth / 2;
                btnGehalt.Style = null;

                btnOthersIncome.Width = fixKostenStack.ActualWidth / 2;
                btnOthersIncome.Height = fixKostenStack.ActualWidth / 2;
                btnOthersIncome.Style = null;

            }
        }

        private void comboBox_DropDownClosed(object sender, object e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                this.Frame.Navigate(typeof(AddPage_Mobile), null);
            }
            else
            {
                gridMain.Children.Remove(gridTemp);
            }
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

        private void btnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void btnGehalt_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(btnGehalt.Content.ToString(), CategoryNamenIncomen.Salary.ToString(), btnGehalt.FontFamily, comboBox.SelectedIndex);
            
            this.Frame.Navigate(typeof(SaveResult), null);
        }

        private void btnOthersIncome_Click(object sender, RoutedEventArgs e)
        {
            Button clickButton = (Button)sender;
            SaveResult saveResult = new SaveResult(btnOthersIncome.Content.ToString(), CategoryNamenIncomen.OtherIncomes.ToString(), btnOthersIncome.FontFamily, comboBox.SelectedIndex);

            this.Frame.Navigate(typeof(SaveResult), null);
        }
    }
}
