using System;
using Windows.UI.Xaml.Controls;
using BalanceSheet.Views;

namespace BalanceSheet.NavigationBar
{
    class ReportNavigationBarMenu : BaseNavigationBarMenu, INavigationBarMenu
    {
        public string Label
        {
            get
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                return loader.GetString("Report");
            }
        }

        public override Symbol Symbol
        {
            get { return Symbol.Accept; }
        }

        public override char SymbolAsChar
        {
            get { return Convert.ToChar(0xEADF); }
        }

        public Type TypePage
        {
            get
            {
                if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
                {
                    return typeof(Views.Mobile.ReportPage_Mobile);
                }
                else
                {
                    return typeof(ReportPage);
                }
            }
        }
    }
}
