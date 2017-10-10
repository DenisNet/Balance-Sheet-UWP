using BalanceSheet.Extensions;
using BalanceSheet.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace BalanceSheet.Views.Mobile
{
    public sealed partial class InfoPage_Mobile : Page
    {
        private readonly InfoViewModel _viewModel;

        public InfoPage_Mobile()
        {
            this.InitializeComponent();
            _viewModel = ServiceLocator.Current.GetInstance<InfoViewModel>();
            DataContext = _viewModel;
        }
    }
}
