using System;
using Windows.UI.Xaml.Controls;
using BalanceSheet.Views;
using BalanceSheet.Views.Mobile;

namespace BalanceSheet.NavigationBar
{
    class StatisticNavigationBarMenu : BaseNavigationBarMenu, INavigationBarMenu
    {
        public string Label
        {
            get
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                return loader.GetString("Statistics");
            }
        }

        public override Symbol Symbol
        {
            get { return Symbol.Accept; }
        }

        public override char SymbolAsChar
        {
            get { return Convert.ToChar(0xEB05); }
        }

        public Type TypePage
        {
            get
            {
                if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
                {
                    return typeof(Statistik_Mobile);
                }
                else
                {
                    return typeof(StatisticPage);
                }
            }
        }
    }
}
