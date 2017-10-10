using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using BalanceSheet.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BalanceSheet.Controls
{
    public sealed partial class UserListView : Page
    {
        // Using a DependencyProperty as the backing store for ListViewDaten.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListViewDatenProperty =
            DependencyProperty.Register("ListViewDaten", typeof(CategoryCostIncomen), typeof(UserListView), new PropertyMetadata(0));

        /// <summary>
        /// Wahlen welche Daten(Category) in ListView zeigen z.B. alle Costs oder alle Incomes
        /// </summary>
        public CategoryCostIncomen ListViewDaten
        {
            get { return (CategoryCostIncomen)GetValue(ListViewDatenProperty); }
            set
            {
                SetValue(ListViewDatenProperty, value);
            }
        }

        MonatYearDaten datum;
        Views.Mobile.CostsIncomes.UserNumberFormat uNFI;

        public UserListView()
        {
            this.InitializeComponent();

            datum = new MonatYearDaten();
            uNFI = new Views.Mobile.CostsIncomes.UserNumberFormat();

            this.Loaded += UserListView_Loaded;
        }

        private async void UserListView_Loaded(object sender, RoutedEventArgs e)
        {
            await DatenLoaded();
        }

        //Daten in ListView loaded
        private async Task DatenLoaded()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            ObservableCollection<ListBalance> listBalance = new ObservableCollection<ListBalance>();
            listBalance = await ListBalance.GetBalanceListeAsync(ListViewDaten, datum.Monat, datum.Year);
            var listView = new ListView();
            if (listBalance.Count == 0)
            {
                ListViewItem listItem = GetNotDaten();

                listView.IsItemClickEnabled = false;
                listView.Items.Add(listItem);
                gridListView.Children.Add(listView);
                BalanceListView.ItemsSource = listBalance.OrderBy(item => item.Datum.TimeOfDay);
            }
            else
            {
                //zeigt auf verschiedene Sprachen Cost und Incomen
                if (ListViewDaten == CategoryCostIncomen.Cost)
                {
                    TxtCostsIncomen.Text = loader.GetString("TxtCostsHome");
                    BalanceListView.ItemsSource = listBalance.OrderBy(item => item.Datum.TimeOfDay);
                }
                else
                {
                    TxtCostsIncomen.Text = loader.GetString("TxtIncomesHome");
                    BalanceListView.ItemsSource = listBalance.OrderBy(item => item.Datum.TimeOfDay);
                }
            }
        }

        /// <summary>
        /// Write No daten found
        /// </summary>
        /// <returns></returns>
        private ListViewItem GetNotDaten()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            var listItem = new ListViewItem
            {
                Content = loader.GetString("NoData"),
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5, 15, 5, 15),
                Foreground = new SolidColorBrush(Colors.White),
                IsEnabled = false
            };
            return listItem;
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
            //7 => LightSeaGreen	#20B2AA	32, 178, 170
            else if (list.Category == CategoryNamenCosts.Apps.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 32, 178, 170));
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


        private void OnItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
