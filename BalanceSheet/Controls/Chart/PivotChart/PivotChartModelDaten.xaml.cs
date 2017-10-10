using BalanceSheet.Models;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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


namespace BalanceSheet.Controls.Chart.PivotChart
{
    public sealed partial class PivotChartModelDaten : Page
    {
        public PivotChartModelDaten()
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
            Berechnung berechnug = new Berechnung();
            var listBalance = new ObservableCollection<ListBalance>();
            var balance = new ObservableCollection<Balance>();
            balance = await berechnug.DatenSourceLoadedAsync();

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
                pieSeries.ItemsSource = balance;
            }

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
