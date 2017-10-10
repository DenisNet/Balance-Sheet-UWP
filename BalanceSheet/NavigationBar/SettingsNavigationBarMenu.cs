using System;
using Windows.UI.Xaml.Controls;
using BalanceSheet.Views;
using BalanceSheet.Views.Mobile;

namespace BalanceSheet.NavigationBar
{
    /// <summary>
    /// Navigation bar menu item that navigates to the
    /// <see cref="SettingsPage" />.
    /// </summary>
    class SettingsNavigationBarMenu : BaseNavigationBarMenu, INavigationBarMenu
    {
        /// <summary>
        /// Gets the title displayed in the navigation bar.
        /// </summary>
        public string Label
        {
            get
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                return loader.GetString("Settings");
            }
        }

        /// <summary>
        /// Gets the symbol that is displayed in the navigation bar.
        /// </summary>
        public override Symbol Symbol
        {
            get { return Symbol.Setting; }
        }

        /// <summary>
        /// Gets the type of the destination page.
        /// </summary>
        public Type TypePage
        {
            get
            {
                if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
                {
                    return typeof(SettingsPage_Mobile);
                }
                else
                {
                    return typeof(SettingsPage);
                }
            }
        }

        /// <summary>
        /// Gets the positions of the current item in the navigation bar.
        /// </summary>
        public override NavigationBarPosition Position
        {
            get { return NavigationBarPosition.Bottom; }
        }
    }
}