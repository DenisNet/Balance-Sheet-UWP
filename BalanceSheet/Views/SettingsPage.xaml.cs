using Microsoft.Practices.ServiceLocation;
using BalanceSheet.ViewModels;

namespace BalanceSheet.Views
{
    /// <summary>
    /// The settings page.
    /// </summary>
    sealed partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            var viewModel = ServiceLocator.Current.GetInstance<SettingsViewModel>();
            DataContext = viewModel;
        }
    }
}