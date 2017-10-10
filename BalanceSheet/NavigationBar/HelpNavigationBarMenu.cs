using System;
using Windows.UI.Xaml.Controls;
using BalanceSheet.Views;

namespace BalanceSheet.NavigationBar
{
    /// <summary>
    /// Navigation bar menu to AboutPage
    /// <see cref="AboutPage"/>.
    /// </summary>
    class HelpNavigationBarMenu : BaseNavigationBarMenu, INavigationBarMenu
    {
        /// <summary>
        /// Gets the title in the Navigation Bar
        /// </summary>
        public string Label
        {
            get
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                return loader.GetString("Help");
            }
        }

        /// <summary>
        /// Gets the symbol in the Navigation Bar
        /// </summary>
        public override Symbol Symbol
        {
            get { return Symbol.Help; }
        }

        /// <summary>
        /// Gets the type of page
        /// </summary>
        public Type TypePage
        {
            get { return typeof(HelpPage); }
        }

        public override NavigationBarPosition Position
        {
            get { return NavigationBarPosition.Bottom; }
        }
    }
}