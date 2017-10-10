using Microsoft.Practices.ServiceLocation;
using Windows.UI.Xaml.Controls;
using BalanceSheet.ViewModels;

namespace BalanceSheet.Views
{
    /// <summary>
    /// The page that allows the user to sign in.
    /// </summary>
    public sealed partial class SignInPage : Page
    {
        public SignInPage()
        {
            this.InitializeComponent();
            ViewModel = ServiceLocator.Current.GetInstance<SignInViewModel>();
            DataContext = ViewModel;
        }

        public SignInViewModel ViewModel { get; }
    }
}