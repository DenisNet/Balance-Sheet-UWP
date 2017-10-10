using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace BalanceSheet.NavigationBar
{
    /// <summary>
    /// Defines a menu for the navigation bar.
    /// </summary>
    public interface INavigationBarMenu
    {
        /// <summary>
        /// Gets the arguments that can be passed optionally to the target page.
        /// </summary>
        object Arguments { get; }

        /// <summary>
        /// Gets the type of page.
        /// </summary>
        Type TypePage { get; }

        /// <summary>
        /// Gets the image that is displayed in the navigation bar.
        /// </summary>
        ImageSource Image { get; }

        /// <summary>
        /// Gets the title displayed.
        /// </summary>
        string Label { get; }

        /// <summary>
        /// Gets the positions in the navigation bar.
        /// </summary>
        NavigationBarPosition Position { get; }

        /// <summary>
        /// Gets the symbol in the navigation bar.
        /// </summary>
        Symbol Symbol { get; }

        /// <summary>
        /// Gets the symbol character.
        /// </summary>
        char SymbolAsChar { get; }
    }

}