using BalanceSheet.Controls;
using BalanceSheet.Models;
using BalanceSheet.Views.Mobile.CostsIncomes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
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


namespace BalanceSheet.Views.Mobile
{
    public class IndexForInterval
    {
#region For Report Page
        //Wenn Datumsbereich wahlen is checked, default is false
        private static bool? DatumBereich { get; set; }

        //Wenn Datumsbereich for all Kategorie wahlen is checked, default is false
        private static bool? DatumBereichForAll { get; set; }

        private static DateTime ErsteDatum { get; set; }

        private static DateTime ZweiteDatum { get; set; }

        /// <summary>
        /// Get nur Erste Datum
        /// </summary>
        /// <returns></returns>
        public DateTime GetErsteDatum()
        {
            return ErsteDatum;
        }

        /// <summary>
        /// Get nur Zweite Datum
        /// </summary>
        /// <returns></returns>
        public DateTime GetZweiteDatum()
        {
            return ZweiteDatum;
        }

        /// <summary>
        /// Get ob for alle Categorys gleiche Datum checked
        /// </summary>
        /// <returns></returns>
        public bool? GetDatumBereichForAll()
        {
            return DatumBereichForAll;
        }

        /// <summary>
        /// Get ob datum Bereich checked ist
        /// </summary>
        /// <returns></returns>
        public bool? GetDatumBereich()
        {
            return DatumBereich;
        }

        /// <summary>
        /// For ein Datumsbereich 
        /// </summary>
        /// <param name="erste"></param>
        /// <param name="zweite"></param>
        /// <param name="datumBereich"></param>
        /// <param name="datumBereichForAll"></param>
        public void SetDatumsBereich(DateTime erste, DateTime zweite, bool? datumBereich, bool? datumBereichForAll)
        {
            ErsteDatum = erste;
            ZweiteDatum = zweite;
            DatumBereich = datumBereich;
            DatumBereichForAll = datumBereichForAll;
        }

        #endregion

        private static bool IndexPage { get; set; }

        private static bool Index { get; set; }

        private static byte SelectIndex { get; set; }

        public bool GetIndexPage()
        {
            return IndexPage;
        }

        public void SetIndexPage(bool indexPage)
        {
            IndexPage = indexPage;
        }

        public byte GetSelectIndex()
        {
            return SelectIndex;
        }

        public void SetSelectIndex(byte i)
        {
            SelectIndex = i;
        }

        public bool GetIndex()
        {
            return Index;
        }

        public void SetIndex(bool i)
        {
            Index = i;
        }
    }
    public sealed partial class ReportPage_Mobile : Page
    {

        private static int IndexPivotMain { get; set; }


        IndexForInterval index;
        MonatYearDaten datenViewModel;

        public ReportPage_Mobile()
        {
            this.InitializeComponent();

            datenViewModel = new MonatYearDaten();

            this.Loaded += ReportPage_Mobile_Loaded;
            pivotMain.SelectedIndex = IndexPivotMain;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ReportPage_Mobile_Loaded(object sender, RoutedEventArgs e)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            pivotFixKosten.Header = loader.GetString(CategoryNamenCosts.Fixed.ToString());
            pivotLebensmittel.Header = loader.GetString(CategoryNamenCosts.Foods.ToString());
            pivotAuto.Header = loader.GetString(CategoryNamenCosts.Auto.ToString());
            pivotBildung.Header = loader.GetString(CategoryNamenCosts.Education.ToString());
            pivotApp.Header = loader.GetString(CategoryNamenCosts.Apps.ToString());
            pivotUrlaub.Header = loader.GetString(CategoryNamenCosts.Vacation.ToString());
            pivotUnterhaltung.Header = loader.GetString(CategoryNamenCosts.Entertainment.ToString());
            pivotHaus.Header = loader.GetString(CategoryNamenCosts.House.ToString());
            pivotVerkehr.Header = loader.GetString(CategoryNamenCosts.Transport.ToString());
            pivotPersonal.Header = loader.GetString(CategoryNamenCosts.Private.ToString());
            pivotSonstAusgaben.Header = loader.GetString(CategoryNamenCosts.OtherCosts.ToString());
            pivotGehalt.Header = loader.GetString(CategoryNamenIncomen.Salary.ToString());
            pivotSonstEinkommen.Header = loader.GetString(CategoryNamenIncomen.OtherIncomes.ToString());

            //clear back stack
            if (this.Frame.CanGoBack)
            {
                this.Frame.BackStack.Clear();
            }
            VisualStateManager.GoToState(this, BalanceState.Name, true);
        }

        ObservableCollection<ListBalance> listBalance;

        private async Task GetDatenAsync(string category, Grid gridCategory, ListView listViewCategory)
        {
            listBalance = new ObservableCollection<ListBalance>();
            var listView = new ListView();
            //If zweit Daten asgewahlt
            if ((bool)index.GetDatumBereich())
            {
                listBalance = await ListBalance.GetBalanceListeAsync(index.GetErsteDatum(), index.GetZweiteDatum(), category);
                if (listBalance.Count == 0)
                {
                    ListViewItem listItem = GetNotDaten();

                    listView.IsItemClickEnabled = false;
                    listView.Items.Add(listItem);
                    gridCategory.Children.Add(listView);
                    listViewCategory.ItemsSource = listBalance.OrderBy(item => item.Datum.TimeOfDay);
                }
                else
                {
                    listViewCategory.ItemsSource = listBalance.OrderBy(item => item.Datum.TimeOfDay);
                }
            }
            //if nur eine Date ausgewahlt
            else
            {
                listBalance = await ListBalance.GetBalanceListeAsync(index.GetErsteDatum(), index.GetZweiteDatum(), category);
                if (listBalance.Count == 0)
                {
                    ListViewItem listItem = GetNotDaten();

                    listView.IsItemClickEnabled = false;
                    listView.Items.Add(listItem);
                    gridCategory.Children.Add(listView);
                    listViewCategory.ItemsSource = listBalance.OrderBy(item => item.Datum.TimeOfDay);
                }
                else
                {
                    listViewCategory.ItemsSource = listBalance.OrderBy(item => item.Datum.TimeOfDay);
                }
            }
        }

        /// <summary>
        /// All Daten gleich laden
        /// </summary>
        /// <returns></returns>
        private async Task AlleDatenGleichLadenAsync()
        {
            await GetDatenAsync(CategoryNamenCosts.Fixed.ToString(), gridFixkosten, FixkostenListView);
            await GetDatenAsync(CategoryNamenCosts.Foods.ToString(), gridLebensmittel, LebensmittelListView);
            await GetDatenAsync(CategoryNamenCosts.Auto.ToString(), gridAuto, AutoListView);
            await GetDatenAsync(CategoryNamenCosts.Education.ToString(), gridBildung, BildungListView);
            await GetDatenAsync(CategoryNamenCosts.Apps.ToString(), gridApp, AppListView);
            await GetDatenAsync(CategoryNamenCosts.Vacation.ToString(), gridUrlaub, UrlaubListView);
            await GetDatenAsync(CategoryNamenCosts.Entertainment.ToString(), gridUnterhaltung, UnterhaltungListView);
            await GetDatenAsync(CategoryNamenCosts.House.ToString(), gridHaus, HausListView);
            await GetDatenAsync(CategoryNamenCosts.Transport.ToString(), gridVerkehr, VerkehrListView);
            await GetDatenAsync(CategoryNamenCosts.Private.ToString(), gridPeronal, PersonalListView);
            await GetDatenAsync(CategoryNamenCosts.OtherCosts.ToString(), gridSonstAusgaben, SonstAusgabeListView);
            await GetDatenAsync(CategoryNamenIncomen.Salary.ToString(), gridGehalt, GehaltListView);
            await GetDatenAsync(CategoryNamenIncomen.OtherIncomes.ToString(), gridSonstEinkommen, SonstEinkommenListView);
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


        //For markieren um nur einmal rechnen
        bool forAllBereich;

        private async void FixkostenListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.Fixed.ToString(), gridFixkosten, FixkostenListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void LebensmittelListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.Foods.ToString(), gridLebensmittel, LebensmittelListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void AutoListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.Auto.ToString(), gridAuto, AutoListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void BildungListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.Education.ToString(), gridBildung, BildungListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void AppListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.Apps.ToString(), gridApp, AppListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void UrlaubListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.Vacation.ToString(), gridUrlaub, UrlaubListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void UnterhaltungListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.Entertainment.ToString(), gridUnterhaltung, UnterhaltungListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void HausListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.House.ToString(), gridHaus, HausListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void VerkehrListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.Transport.ToString(), gridVerkehr, VerkehrListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void PersonalListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.Private.ToString(), gridPeronal, PersonalListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void SonstAusgabeListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenCosts.OtherCosts.ToString(), gridSonstAusgaben, SonstAusgabeListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void GehaltListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {
                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenIncomen.Salary.ToString(), gridGehalt, GehaltListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        private async void SonstEinkommenListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!forAllBereich)
            {
                index = new IndexForInterval();
                if (index.GetIndex())
                {

                    if (index.GetDatumBereichForAll() == false)
                    {
                        await GetDatenAsync(CategoryNamenIncomen.OtherIncomes.ToString(), gridSonstEinkommen, SonstEinkommenListView);
                        forAllBereich = false;
                    }
                    //Wenn alle daten haben gleiche datum
                    else if ((bool)index.GetDatumBereichForAll())
                    {
                        await AlleDatenGleichLadenAsync();
                        forAllBereich = true;
                    }
                    index.SetIndex(false);
                }
                else
                {
                    this.Frame.Navigate(typeof(IntervalDatum));
                    IndexPivotMain = pivotMain.SelectedIndex;
                }
            }
        }

        //Erforderlich => Aussgaben mit bestimmten Farbe markieren
        private void BalanceListView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            ListBalance list = args.Item as ListBalance;
            //1 => Red
            if (list.UnderCategory == FixkostenUnderCategory.Bank.ToString() || 
                list.UnderCategory == LebensmittelUnderCategory.Meat.ToString() ||
                list.UnderCategory == AutoUnderCategory.Fuel.ToString() ||
                list.UnderCategory == UnterhaltungUnderCategory.Cafe.ToString() ||
                list.UnderCategory == VerkehrUnderCategory.Trainticket.ToString() ||
                list.UnderCategory == PersonalUnderCategory.Accessoires.ToString() ||
                list.Category == CategoryNamenCosts.OtherCosts.ToString() )
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 229, 20, 0));
            }
            //2 => Braun
            else if (list.UnderCategory == FixkostenUnderCategory.Rental.ToString() ||
                     list.UnderCategory == LebensmittelUnderCategory.Meer.ToString() ||
                     list.UnderCategory == AutoUnderCategory.Repair.ToString() ||
                     list.UnderCategory == UnterhaltungUnderCategory.Pizza.ToString() ||
                     list.UnderCategory == VerkehrUnderCategory.Singleticket.ToString() ||
                     list.UnderCategory == PersonalUnderCategory.Hairdressing.ToString() ||
                     list.Category == CategoryNamenCosts.Education.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 160, 80, 0));
            }
            //3 => Green
            else if (list.UnderCategory == FixkostenUnderCategory.Groundshuld.ToString() ||
                     list.UnderCategory == LebensmittelUnderCategory.FruitVegetabele.ToString() ||
                     list.UnderCategory == AutoUnderCategory.Wash.ToString() ||
                     list.UnderCategory == UnterhaltungUnderCategory.Restaurant.ToString() ||
                     list.UnderCategory == VerkehrUnderCategory.Taxi.ToString() ||
                     list.UnderCategory == PersonalUnderCategory.Dress.ToString() ||
                     list.Category == CategoryNamenIncomen.Salary.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 51, 153, 51));
            }
            //4 => Rosa
            else if (list.UnderCategory == FixkostenUnderCategory.Extracosts.ToString() ||
                     list.UnderCategory == LebensmittelUnderCategory.Bakery.ToString() ||
                     list.UnderCategory == AutoUnderCategory.InsuranceAuto.ToString() ||
                     list.UnderCategory == UnterhaltungUnderCategory.Kino.ToString() ||
                     list.UnderCategory == VerkehrUnderCategory.Flightticket.ToString() ||
                     list.UnderCategory == PersonalUnderCategory.Cosmetics.ToString() ||
                     list.Category == CategoryNamenCosts.Apps.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 230, 113, 184));
            }
            //5 => HellGreen
            else if (list.UnderCategory == FixkostenUnderCategory.TV.ToString() ||
                     list.UnderCategory == LebensmittelUnderCategory.Milk.ToString() ||
                     list.UnderCategory == AutoUnderCategory.Fine.ToString() ||
                     list.UnderCategory == UnterhaltungUnderCategory.Theatre.ToString() ||
                     list.UnderCategory == VerkehrUnderCategory.Monthlyticket.ToString() ||
                     list.UnderCategory == PersonalUnderCategory.Medicine.ToString() ||
                     list.Category == CategoryNamenIncomen.OtherIncomes.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 162, 193, 57));
            }
            //6 => DarkRed
            else if (list.UnderCategory == FixkostenUnderCategory.Internet.ToString() ||
                     list.UnderCategory == LebensmittelUnderCategory.Sweetnes.ToString() ||
                     list.UnderCategory == AutoUnderCategory.OtherAuto.ToString() ||
                     list.UnderCategory == UnterhaltungUnderCategory.OtherEntertainment.ToString() ||
                     list.UnderCategory == VerkehrUnderCategory.OtherTransport.ToString() ||
                     list.UnderCategory == PersonalUnderCategory.Wellness.ToString() ||
                     list.Category == CategoryNamenCosts.OtherCosts.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 216, 0, 115));
            }
            //7 => Orange
            else if (list.UnderCategory == FixkostenUnderCategory.Telefons.ToString() ||
                     list.UnderCategory == LebensmittelUnderCategory.Drinks.ToString() ||
                     list.UnderCategory == PersonalUnderCategory.OtherPrivate.ToString() ||
                     list.Category == CategoryNamenCosts.Vacation.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 240, 150, 9));
            }
            //8 => Violet
            else if (list.UnderCategory == FixkostenUnderCategory.InsuranceFix.ToString() ||
                     list.UnderCategory == LebensmittelUnderCategory.OtherFoods.ToString() ||
                     list.Category == CategoryNamenCosts.House.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 162, 0, 255));
            }
            //9 => Yellow
            else if (list.UnderCategory == FixkostenUnderCategory.Tax.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 254, 190, 23));
            }
            //10 => Grey
            else if (list.UnderCategory == FixkostenUnderCategory.OtherFix.ToString())
            {
                args.ItemContainer.Background = new SolidColorBrush(Color.FromArgb(255, 208, 179, 136));
            }
        }

#region BottomAppBar

        private void SelectItmesBtn_Click(object sender, RoutedEventArgs e)
        {
            IndexForInterval index = new IndexForInterval();

            if (index.GetSelectIndex() == 0)
            {
                SelectItmeBtn(FixkostenListView);
            }
            else if (index.GetSelectIndex() == 1)
            {
                SelectItmeBtn(LebensmittelListView);
            }
            else if (index.GetSelectIndex() == 2)
            {
                SelectItmeBtn(AutoListView);
            }
            else if (index.GetSelectIndex() == 3)
            {
                SelectItmeBtn(BildungListView);
            }
            else if (index.GetSelectIndex() == 4)
            {
                SelectItmeBtn(AppListView);
            }
            else if (index.GetSelectIndex() == 5)
            {
                SelectItmeBtn(UrlaubListView);
            }
            else if (index.GetSelectIndex() == 6)
            {
                SelectItmeBtn(UnterhaltungListView);
            }
            else if (index.GetSelectIndex() == 7)
            {
                SelectItmeBtn(HausListView);
            }
            else if (index.GetSelectIndex() == 8)
            {
                SelectItmeBtn(VerkehrListView);
            }
            else if (index.GetSelectIndex() == 9)
            {
                SelectItmeBtn(PersonalListView);
            }
            else if (index.GetSelectIndex() == 10)
            {
                SelectItmeBtn(SonstAusgabeListView);
            }
            else if (index.GetSelectIndex() == 11)
            {
                SelectItmeBtn(GehaltListView);
            }
            else if (index.GetSelectIndex() == 12)
            {
                SelectItmeBtn(SonstEinkommenListView);
            }
        }

        private void SelectItmeBtn(ListView listView)
        {
            if (listView.Items.Count > 0)
            {
                VisualStateManager.GoToState(this, MultipleSelectionState.Name, true);
            }
        }

        private async void DeleteItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            IndexForInterval index = new IndexForInterval();

            if (index.GetSelectIndex() == 0)
            {
                await DeleteItemsBtns(FixkostenListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.Fixed.ToString(), gridFixkosten, FixkostenListView);
            }
            else if (index.GetSelectIndex() == 1)
            {
                await DeleteItemsBtns(LebensmittelListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.Foods.ToString(), gridLebensmittel, LebensmittelListView);
            }
            else if (index.GetSelectIndex() == 2)
            {
                await DeleteItemsBtns(AutoListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.Auto.ToString(), gridAuto, AutoListView);
            }
            else if (index.GetSelectIndex() == 3)
            {
                await DeleteItemsBtns(BildungListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.Education.ToString(), gridBildung, BildungListView);
            }
            else if (index.GetSelectIndex() == 4)
            {
                await DeleteItemsBtns(AppListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.Apps.ToString(), gridApp, AppListView);
            }
            else if (index.GetSelectIndex() == 5)
            {
                await DeleteItemsBtns(UrlaubListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.Vacation.ToString(), gridUrlaub, UrlaubListView);
            }
            else if (index.GetSelectIndex() == 6)
            {
                await DeleteItemsBtns(UnterhaltungListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.Entertainment.ToString(), gridUnterhaltung, UnterhaltungListView);
            }
            else if (index.GetSelectIndex() == 7)
            {
                await DeleteItemsBtns(HausListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.House.ToString(), gridHaus, HausListView);
            }
            else if (index.GetSelectIndex() == 8)
            {
                await DeleteItemsBtns(VerkehrListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.Transport.ToString(), gridVerkehr, VerkehrListView);
            }
            else if (index.GetSelectIndex() == 9)
            {
                await DeleteItemsBtns(PersonalListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.Private.ToString(), gridPeronal, PersonalListView);
            }
            else if (index.GetSelectIndex() == 10)
            {
                await DeleteItemsBtns(SonstAusgabeListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenCosts.OtherCosts.ToString(), gridSonstAusgaben, SonstAusgabeListView);
            }
            else if (index.GetSelectIndex() == 11)
            {
                await DeleteItemsBtns(GehaltListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenIncomen.Salary.ToString(), gridGehalt, GehaltListView);
            }
            else if (index.GetSelectIndex() == 12)
            {
                await DeleteItemsBtns(SonstEinkommenListView);
                Task.WaitAll();
                await GetDatenAsync(CategoryNamenIncomen.OtherIncomes.ToString(), gridSonstEinkommen, SonstEinkommenListView);
            }
        }

        private async Task DeleteItemsBtns(ListView listView)
        {
            if (listView.SelectedIndex != -1)
            {
                List<ListBalance> selectedItems = new List<ListBalance>();
                //Um die Deleten vom ListView moglich machen

                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

                foreach (ListBalance balance in listView.SelectedItems)
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

                if (result == ContentDialogResult.Primary)
                {
                    var uNFI = new UserNumberFormat();

                    await datenViewModel.BalanceForYearAsync();
                    await datenViewModel.CostIncomeSummeAsync();
                }
            }
        }

        private void CancelSelectionBtn_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, BalanceState.Name, true);
        }

        #endregion
    }
}
