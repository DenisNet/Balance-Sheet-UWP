using Windows.UI.Xaml.Controls;
using BalanceSheet.ComponentModel;
using Windows.UI.Xaml.Media;

namespace BalanceSheet.NavigationBar
{
    /// <summary>
    /// Base class for Navigation Bar
    /// </summary>
    public abstract class BaseNavigationBarMenu: ObservableObjectBase
    {
        /// <summary>
        /// Gets the argumets
        /// </summary>
        public virtual object Arguments
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the image that is displayed in the navigation bar.
        /// </summary>
        public virtual ImageSource Image
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the position in the Navigation Bar
        /// </summary>
        public virtual NavigationBarPosition Position
        {
            get { return NavigationBarPosition.Top; }
        }

        /// <summary>
        /// Gets the symbol in the Navigation Bar
        /// </summary>
        public abstract Symbol Symbol { get; }

        /// <summary>
        /// Gets the symbol character
        /// </summary>
        public virtual char SymbolAsChar
        {
            get { return (char)Symbol; }
        }
    }
}