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

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BalanceSheet.Views.Mobile
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class IntervalDatum : Page
    {
        public IntervalDatum()
        {
            this.InitializeComponent();
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            txtChoose.Text = loader.GetString("TxtChoose");
            CheckInterval.Content = loader.GetString("CheckInterval");
            CheckGleichDatumInterval.Content = loader.GetString("CheckGleichDatumInterval");
            btnNext.Content = loader.GetString("BtnNext");
        }

        #region Erste CheckBox for Interval

        private void IntervalCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            DatePickerSeconder.IsEnabled = true;
        }

        private void CheckInterval_Unchecked(object sender, RoutedEventArgs e)
        {
            DatePickerSeconder.IsEnabled = false;
        }

#endregion

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var appShell = new ViewModels.AppShellToggleButton();
            appShell.SetShellButton(false);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var appShell = new ViewModels.AppShellToggleButton();
            appShell.SetShellButton(true);
            IndexForInterval index = new IndexForInterval();
            index.SetIndex(true);
            index.SetDatumsBereich(DatePickerFirst.Date.DateTime, DatePickerSeconder.Date.DateTime, CheckInterval.IsChecked, CheckGleichDatumInterval.IsChecked);

            Frame.Navigate(typeof(ReportPage_Mobile));
        }

#region DatePicker zeigt von Montag bis Sonntag default

        private void DatePickerFirst_Loaded(object sender, RoutedEventArgs e)
        {
            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    DatePickerFirst.Date = DateTime.Today;
                    break;
                case DayOfWeek.Tuesday:
                    DatePickerFirst.Date = DateTime.Today.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    DatePickerFirst.Date = DateTime.Today.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    DatePickerFirst.Date = DateTime.Today.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    DatePickerFirst.Date = DateTime.Today.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    DatePickerFirst.Date = DateTime.Today.AddDays(-5);
                    break;
                case DayOfWeek.Sunday:
                    DatePickerFirst.Date = DateTime.Today.AddDays(-6);
                    break;
            }
        }

        private void DatePickerSeconder_Loaded(object sender, RoutedEventArgs e)
        {
            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    DatePickerSeconder.Date = DateTime.Today.AddDays(6);
                    break;
                case DayOfWeek.Tuesday:
                    DatePickerSeconder.Date = DateTime.Today.AddDays(5);
                    break;
                case DayOfWeek.Wednesday:
                    DatePickerSeconder.Date = DateTime.Today.AddDays(4);
                    break;
                case DayOfWeek.Thursday:
                    DatePickerSeconder.Date = DateTime.Today.AddDays(3);
                    break;
                case DayOfWeek.Friday:
                    DatePickerSeconder.Date = DateTime.Today.AddDays(2);
                    break;
                case DayOfWeek.Saturday:
                    DatePickerSeconder.Date = DateTime.Today.AddDays(1);
                    break;
                case DayOfWeek.Sunday:
                    DatePickerSeconder.Date = DateTime.Today;
                    break;
            }
        }

        #endregion

    }
}
