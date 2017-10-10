using BalanceSheet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.ComponentModel;
using Windows.UI.Xaml.Media.Animation;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Core;

namespace BalanceSheet.Views.Mobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarPage_Mobile : Page
    {
        //private DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile> optionsBuilder;
        //private Store.DataBase.DataBaseEF.DataBaseFile dataBase;
        //UserNumberFormatInfo
        CostsIncomes.UserNumberFormat uNFI;
        //private ObservableCollection<ListBalance> Balances;

        MonatYearDaten datenViewModel;

        public CalendarPage_Mobile()
        {
            this.InitializeComponent();

            datenViewModel = new MonatYearDaten();
            uNFI = new CostsIncomes.UserNumberFormat();
            //optionsBuilder = new DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile>();
            //optionsBuilder.UseSqlite("Filename=Balance.db");
            //dataBase = new Store.DataBase.DataBaseEF.DataBaseFile(optionsBuilder.Options);
            //dataBase = new Store.DataBase.DataBaseEF.DataBaseFile();
        }

        private void BtnAddPlus_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddPage_Mobile));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var btn = new ViewModels.AppShellToggleButton();
            btn.SetShellButton(true);

            await DatenLoaded();
            //ObservableCollection<ListBalance> listBalance = new ObservableCollection<ListBalance>();
            //listBalance = ListBalance.GetBalanceListe();
            //BalanceListView.ItemsSource = listBalance.OrderBy(item => item.Datum.TimeOfDay);
            //BalanceListView.ItemsSource = listBalance;
            //BalanceListView.ItemsSource = ListBalance.GetBalanceListe();
            VisualStateManager.GoToState(this, BalanceState.Name, true);
        }

        //Daten in ListView loaded
        private async Task DatenLoaded()
        {
            ObservableCollection<ListBalance> listBalance = new ObservableCollection<ListBalance>();
            listBalance = await ListBalance.GetBalanceListeAsync(datePicker.Date.Date);
            BalanceListView.ItemsSource = listBalance.OrderBy(item => item.Datum.TimeOfDay);
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelectItmesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BalanceListView.Items.Count > 0)
            {
                VisualStateManager.GoToState(this, MultipleSelectionState.Name, true);
            }
        }

        private async void DeleteItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BalanceListView.SelectedIndex != -1)
            {
                List<ListBalance> selectedItems = new List<ListBalance>();
                //Um die Deleten vom ListView moglich machen

                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

                foreach (ListBalance balance in BalanceListView.SelectedItems)
                {
                    selectedItems.Add(balance);
                }
                var dialogContent = new ContentDialog()
                {
                    FontFamily = new FontFamily("Segoe Print"),
                    Background = new SolidColorBrush(Color.FromArgb(255, 69, 184, 234)),
                    Foreground = new SolidColorBrush(Colors.White),
                    Title = loader.GetString("TtlDelete"),
                    Content = loader.GetString("DialogContent"),
                    PrimaryButtonText = loader.GetString("Yes"),
                    SecondaryButtonText = loader.GetString("No")
                };
                ContentDialogResult result = await dialogContent.ShowAsync(); ;

                foreach (ListBalance balance in selectedItems)
                {
                    switch (balance.CostsOrIncomes)
                    {
                        #region Costs Case

                        case "Cost":
                            if (result == ContentDialogResult.Primary)
                            {
                                using (var db = new Store.DataBase.DataBaseEF.DataBaseFile())
                                {
                                    var name =
                                         (from nameCosts in db.Costs
                                          where nameCosts.CostId == balance.ID
                                          select nameCosts).FirstOrDefault();
                                    db.Costs.Remove(name);
                                    db.SaveChanges();
                                }
                            }
                            break;
                            
                        #endregion
                        
                        #region Incomes  Case

                        case "Income":
                            if (result == ContentDialogResult.Primary)
                            {
                                using (var db = new Store.DataBase.DataBaseEF.DataBaseFile())
                                {
                                    var name =
                                         (from nameIncomes in db.Incomes
                                          where nameIncomes.IncomeId == balance.ID
                                          select nameIncomes).FirstOrDefault();
                                    db.Incomes.Remove(name);
                                    db.SaveChanges();
                                }
                            }
                            break;

                        #endregion

                        default:
                            break;
                    }
                }
            }
            //Page aktualisieren
            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
            this.Frame.Navigate(typeof(CalendarPage_Mobile), null);
        }

        private void CancelSelectionBtn_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, BalanceState.Name, true);
        }

        //Erforderlich => Aussgaben mit bestimmten Farbe markieren
        private void BalanceListView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            ListBalance list = args.Item as ListBalance;

            //1 => Red
            if (list.Category == CategoryNamenCosts.Fixed.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 229, 20, 0));
            }
            //2 => Braun
            else if (list.Category == CategoryNamenCosts.Foods.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 160, 80, 0));
            }
            //3 => Green
            else if (list.Category == CategoryNamenIncomen.Salary.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 51, 153, 51));
            }
            //4 => DarkKhaki	#BDB76B	189, 183, 107
            else if (list.Category == CategoryNamenCosts.Auto.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 189, 183, 107));
            }
            //5 => HellGreen
            else if (list.Category == CategoryNamenIncomen.OtherIncomes.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 162, 193, 57));
            }
            //6 => DarkRed
            else if (list.Category == CategoryNamenCosts.Education.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 216, 0, 115));
            }
            //7 => Orange
            else if (list.Category == CategoryNamenCosts.Apps.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 240, 150, 9));
            }
            //8 => Violet
            else if (list.Category == CategoryNamenCosts.Vacation.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 162, 0, 255));
            }
            //9 => Yellow
            else if (list.Category == CategoryNamenCosts.Entertainment.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 254, 190, 23));
            }
            //10 => Grey
            else if (list.Category == CategoryNamenCosts.House.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 208, 179, 136));
            }
            //11 => SandyBrown	#F4A460	244, 164, 96
            else if (list.Category == CategoryNamenCosts.Transport.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 244, 164, 96));
            }
            //12 => Goldenrod	#DAA520	218, 165, 32
            else if (list.Category == CategoryNamenCosts.Private.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 218, 165, 32));
            }
            //13 => Tomato	#FF6347	255, 99, 71
            else if (list.Category == CategoryNamenCosts.OtherCosts.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 255, 99, 71));
            }
        }

        private async void datePicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            await DatenLoaded();
        }
    }
}
