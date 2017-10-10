using System;
using Windows.UI.Xaml.Controls;
using BalanceSheet.Views;

namespace BalanceSheet.NavigationBar
{
    /// <summary>
    /// Navigation bar menu to Home
    /// <see cref="HomePage"/>.
    /// </summary>
    public class HomeNavigationBarMenu : BaseNavigationBarMenu, INavigationBarMenu
    {
        /// <summary>
        /// Gets the title in the Navigation Bar
        /// </summary>
        public string Label
        {
            get { return "Home"; }
        }

        /// <summary>
        /// Gets the symbol in the Navigation Bar
        /// </summary>
        public override Symbol Symbol
        {
            get { return Symbol.Home; }
        }

        /// <summary>
        /// Gets the type of page
        /// </summary>
        public Type TypePage
        {
            get
            {
                if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
                {
                    return typeof(HomePage_Mobile);
                }
                else
                {
                    return typeof(HomePage);
                }
            }
        }
    }
}

