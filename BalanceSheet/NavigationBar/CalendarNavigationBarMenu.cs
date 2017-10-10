using System;
using Windows.UI.Xaml.Controls;
using BalanceSheet.Views;
using Windows.System.Profile;

namespace BalanceSheet.NavigationBar
{
    class CalendarNavigationBarMenu : BaseNavigationBarMenu, INavigationBarMenu
    {
        public string Label
        {
            get
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                return loader.GetString("Today");
            }
        }

        public override Symbol Symbol
        {
            get { return Symbol.CalendarDay; }
        }

        public Type TypePage
        {
            get
            {
                if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
                {
                    return typeof(Views.Mobile.CalendarPage_Mobile);
                }
                else
                {
                    return typeof(CalendarPage);
                }
            }
        }
    }
}
