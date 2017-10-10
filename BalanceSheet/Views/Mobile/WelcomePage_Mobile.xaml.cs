using BalanceSheet.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace BalanceSheet.Views
{
    public sealed partial class WelcomePage : Page
    {
        private readonly WelcomeViewModel viewModel;
        public WelcomePage()
        {
            this.InitializeComponent();

            viewModel = ServiceLocator.Current.GetInstance<WelcomeViewModel>();
            DataContext = viewModel;
            var btn = new AppShellToggleButton();
            btn.SetShellButton(false);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await viewModel.LoadState();
        }
    }
}
