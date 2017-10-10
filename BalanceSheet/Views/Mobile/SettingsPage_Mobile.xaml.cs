using BalanceSheet.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace BalanceSheet.Views.Mobile
{
    sealed partial class SettingsPage_Mobile
    {
        public SettingsPage_Mobile()
        {
            this.InitializeComponent();

        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            var btn = new AppShellToggleButton();
            btn.SetShellButton(false);

            this.Frame.Navigate(typeof(InfoPage_Mobile));
        }

        private void BtnFeedback_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var btn = new AppShellToggleButton();
            btn.SetShellButton(true);
        }

        private void HyperLinkBtnPrivacy_Click(object sender, RoutedEventArgs e)
        {
            var btn = new AppShellToggleButton();
            btn.SetShellButton(false);

            this.Frame.Navigate(typeof(PrivacyPage_Mobile));
        }

        private void HyperLinkBtnTerms_Click(object sender, RoutedEventArgs e)
        {
            var btn = new AppShellToggleButton();
            btn.SetShellButton(false);

            this.Frame.Navigate(typeof(TermsUse));
        }
    }
}
