using BalanceSheet.Controls.Chart.PivotChart;
using BalanceSheet.Models;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace BalanceSheet.Controls.Chart
{
    public sealed partial class ChartsModelDatenForHomePage : Page
    {

        // Using a DependencyProperty as the backing store for PieChartDaten.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PieChartDatenProperty =
            DependencyProperty.Register("PieChartDaten", typeof(CategoryCostIncomen), typeof(ChartsModelDatenForHomePage), new PropertyMetadata(0));

        /// <summary>
        /// Wahlen welche Daten(Category) in PieChart zeigen z.B. alle Costs oder alle Incomes
        /// </summary>
        public CategoryCostIncomen PieChartDaten
        {
            get { return (CategoryCostIncomen)GetValue(PieChartDatenProperty); }
            set
            {
                SetValue(PieChartDatenProperty, value);
            }
        }

        public ChartsModelDatenForHomePage()
        {
            this.InitializeComponent();
            pieChartAdornmentInfo.ShowConnectorLine = true;
            pieChartAdornmentInfo.ShowLabel = true;
            pieChartAdornmentInfo.SegmentLabelContent = LabelContent.LabelContentPath;
            pieChartAdornmentInfo.LabelTemplate = dashboardChart1.Resources["labelTemplate"] as DataTemplate;
            pieChartAdornmentInfo.ConnectorLineStyle = dashboardChart1.Resources["connectorLineStyle"] as Style;
            pieSeries.Loaded += PieSeries_Loaded;
        }

        private async void PieSeries_Loaded(object sender, RoutedEventArgs e)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            MonatYearDaten datum = new MonatYearDaten();
            Berechnung berechnug = new Berechnung();
            var listBalance = new ObservableCollection<ListBalance>();
            var balance = new ObservableCollection<Balance>();

            //rechnet fur Piechart Prozent, Price und name
            balance = await berechnug.HomePageDatenSourceLoadedAsync(PieChartDaten, datum.Monat, datum.Year);

            if (balance.Count == 0)
            {
                var listView = new ListView();

                ListViewItem listItem = GetNotDaten();

                listView.IsItemClickEnabled = false;
                listView.Items.Add(listItem);
                dashboardChart1.Children.Add(listView);
            }
            else
            {
                //zeigt auf verschiedene Sprachen Cost und Incomen
                if (PieChartDaten == CategoryCostIncomen.Cost)
                {
                    TxtCostsIncomen.Text = loader.GetString("TxtCostsHome");
                    pieSeries.ItemsSource = balance;
                }
                else
                {
                    TxtCostsIncomen.Text = loader.GetString("TxtIncomesHome");
                    pieSeries.ItemsSource = balance;
                }
            }
            List<Brush> colorBrush = new List<Brush>();

            //Pie diagramm with customs color
            foreach (var item in balance)
            {
                //1 => Red
                if (item.Name == loader.GetString("Fixed"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 229, 20, 0)));
                }
                //2 => Braun
                else if (item.Name == loader.GetString("Foods"))
                {
                    colorBrush.Add( new SolidColorBrush(Color.FromArgb(255, 160, 80, 0)));
                }
                ////3 => Green
                else if (item.Name == loader.GetString("Salary"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 51, 153, 51)));
                }
                //4 => DarkKhaki	#BDB76B	189, 183, 107
                else if (item.Name == loader.GetString("Auto"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 189, 183, 107)));
                }
                //5 => HellGreen
                else if (item.Name == loader.GetString("OtherIncomes"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 162, 193, 57)));
                }
                //6 => DarkRed
                else if (item.Name == loader.GetString("Education"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 216, 0, 115)));
                }
                //7 => LightSeaGreen	#20B2AA	32, 178, 170
                else if (item.Name == loader.GetString("Apps"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 32, 178, 170)));
                }
                //8 => Violet
                else if (item.Name == loader.GetString("Vacation"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 162, 0, 255)));
                }
                //9 => Yellow
                else if (item.Name == loader.GetString("Entertainment"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 254, 190, 23)));
                }
                //10 => Grey
                else if (item.Name == loader.GetString("House"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 208, 179, 136)));
                }
                //11 => SandyBrown	#F4A460	244, 164, 96
                else if (item.Name == loader.GetString("Transport"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 244, 164, 96)));
                }
                //12 => Goldenrod	#DAA520	218, 165, 32
                else if (item.Name == loader.GetString("Private"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 218, 165, 32)));
                }
                //13 => Tomato	#FF6347	255, 99, 71
                else if (item.Name == loader.GetString("OtherCosts"))
                {
                    colorBrush.Add(new SolidColorBrush(Color.FromArgb(255, 255, 99, 71)));
                }
            }
            pieSeries.ColorModel.CustomBrushes = colorBrush;
        }

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

    }
}
