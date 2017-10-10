using Microsoft.Practices.ServiceLocation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using BalanceSheet.ViewModels;
using Windows.System.Profile;
using Windows.UI.Xaml;

namespace BalanceSheet.Views
{
    public sealed partial class CalendarPage : Page
    {
        //private readonly CalendarViewModel viewModel;
        //private string device;
        public CalendarPage()
        {
            InitializeComponent();

            //var device = AnalyticsInfo.VersionInfo.DeviceFamily;
            //if (device == "Windows.Mobile")
            //{
            //    Mobile.CalendarPage_Mobile calendarMobile = new Mobile.CalendarPage_Mobile();
            //    DataContext = calendarMobile;
            //}



            //viewModel = ServiceLocator.Current.GetInstance<CalendarViewModel>();
            //DataContext = viewModel;

            //device = AnalyticsInfo.VersionInfo.DeviceFamily;
            //if (device == "Windows.Mobile")
            //{
            //    Thickness myThickness = new Thickness();
            //    myThickness.Bottom = 0;
            //    myThickness.Left = 10;
            //    myThickness.Right = 0;
            //    myThickness.Top = 30;
            //    //gridPanel.Margin = myThickness;
            //}
            //else
            //{

            //}
        }

        //protected override async void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);
        //    //await viewModel.LoadState();
        //}
    }
}