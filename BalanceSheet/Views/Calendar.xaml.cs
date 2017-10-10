using BalanceSheet.ContractModelConverterExtensions;
using BalanceSheet.Models;
using BalanceSheet.ViewModels;
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


namespace BalanceSheet.Views
{
    public sealed partial class Calendar : Page
    {
        MonatYearDaten datum;
        public Calendar()
        {
            this.InitializeComponent();

            this.Loaded += Calendar_Loaded;
        }

        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            var btn = new ViewModels.AppShellToggleButton();
            btn.SetShellButton(false);
            DatePickerConverter dt = new DatePickerConverter();
            BtnJanuar.Content = dt.Convert(1).ToString();
            BtnFebruar.Content = dt.Convert(2).ToString();
            BtnMarz.Content = dt.Convert(3).ToString();
            BtnApril.Content = dt.Convert(4).ToString();
            BtnMai.Content = dt.Convert(5).ToString();
            BtnJuni.Content = dt.Convert(6).ToString();
            BtnJuli.Content = dt.Convert(7).ToString();
            BtnAugust.Content = dt.Convert(8).ToString();
            BtnSeptember.Content = dt.Convert(9).ToString();
            BtnOktober.Content = dt.Convert(10).ToString();
            BtnNovember.Content = dt.Convert(11).ToString();
            BtnDezember.Content = dt.Convert(12).ToString();
        }

        private void UserDatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten();
            if (datum.Year != 0)
            {
                int i = datum.Year;
                UserDatePicker.Date = new DateTime(i, DateTime.Today.Month, DateTime.Today.Day);
            }
        }

        private void UserDatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            pageRoot.Opacity = 1.0;
        }

        private void UserDatePicker_Tapped(object sender, TappedRoutedEventArgs e)
        {
            pageRoot.Opacity = 0.3;
        }

        private void UserDatePicker_GotFocus(object sender, RoutedEventArgs e)
        {
            pageRoot.Opacity = 1.0;
        }

        private async void BtnJanuar_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(1, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnFebruar_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(2, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnMarz_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(3, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnApril_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(4, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnMai_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(5, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnJuni_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(6, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnJuli_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(7, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnAugust_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(8, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnSeptember_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(9, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnOktober_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(10, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnNovember_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(11, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private async void BtnDezember_Click(object sender, RoutedEventArgs e)
        {
            datum = new MonatYearDaten(12, UserDatePicker.Date.Year);
            await datum.CostIncomeSummeAsync();

            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }
    }
}
