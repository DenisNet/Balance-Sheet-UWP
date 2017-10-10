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
using Syncfusion.UI.Xaml.Charts;
using Windows.UI;
using BalanceSheet.Models;



namespace BalanceSheet.Controls.Chart
{
    /// <summary>
    /// ChartsModelDaten
    /// </summary>
    public sealed partial class ChartsModelDaten : UserControl
    {

        public ChartsModelDaten()
        {
            this.InitializeComponent();

            var daten = new MonatYearDaten();
            pieChartAdornmentInfo.ShowConnectorLine = true;
            pieChartAdornmentInfo.ShowLabel = true;
            pieChartAdornmentInfo.SegmentLabelContent = LabelContent.LabelContentPath;
            pieChartAdornmentInfo.LabelTemplate = dashboardChart1.Resources["labelTemplate"] as DataTemplate;
            pieChartAdornmentInfo.ConnectorLineStyle = dashboardChart1.Resources["connectorLineStyle"] as Style;

            if (daten.GetWertAusgabe() == 0 && daten.GetWertEinnahme() == 0)
            {
                sfchart.Visibility = Visibility.Collapsed;
            }
            else
            {
                sfchart.Visibility = Visibility.Visible;
            }
        }

    }
}
