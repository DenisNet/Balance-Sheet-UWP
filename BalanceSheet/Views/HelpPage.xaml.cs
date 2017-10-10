using Microsoft.Practices.ServiceLocation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using BalanceSheet.ViewModels;


namespace BalanceSheet.Views
{
    public sealed partial class HelpPage : Page
    {
        private readonly HelpViewModel viewModel;
        public HelpPage()
        {
            InitializeComponent();

            viewModel = ServiceLocator.Current.GetInstance<HelpViewModel>();
            DataContext = viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await viewModel.LoadState();
        }
    }
}