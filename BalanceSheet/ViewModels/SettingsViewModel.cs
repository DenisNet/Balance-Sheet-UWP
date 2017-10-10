
using System;
using BalanceSheet.Commands;
using BalanceSheet.Facades;
using BalanceSheet.Models;
using BalanceSheet.Services;
using BalanceSheet.Views;
using Windows.System;

namespace BalanceSheet.ViewModels
{
    /// <summary>
    /// The ViewModel for the settings view.
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;
        private readonly INavigationFacade navigationFacade;
        //private readonly IPhotoService photoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsViewModel" /> class.
        /// </summary>
        /// <param name="navigationFacade">The navigation facade.</param>
        /// <param name="dialogService">The dialog service.</param>
        public SettingsViewModel(INavigationFacade navigation,
            IDialogService dialog)
        {
            //photoService = photo;
            navigationFacade = navigation;
            dialogService = dialog;

            PrivacyCommand = new RelayCommand(OnShowPrivacyPolicy);
            AboutCommand = new RelayCommand(OnShowAbout);
            SignOutCommand = new RelayCommand(OnSignOut);
        }

        /// <summary>
        /// Gets the about command
        /// </summary>
        public RelayCommand AboutCommand { get; private set; }

        /// <summary>
        /// Returns true, if user is signed in. Otherwise, false.
        /// </summary>
        public bool IsUserSignedIn
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the privacy policy command.
        /// </summary>
        public RelayCommand PrivacyCommand { get; private set; }

        /// <summary>
        /// Gets the sign out command.
        /// </summary>
        public RelayCommand SignOutCommand { get; private set; }

        private void OnShowAbout()
        {
            //navigationFacade.NavigateToAboutView();
        }

        private async void OnShowPrivacyPolicy()
        {
            //await Launcher.LaunchUriAsync(new Uri("http://Your_Privacy_Page.com"));
        }

        private async void OnSignOut()
        {
            //try
            //{
            //    await photoService.SignOutAsync();

            //    // Resetting the current user.
            //    AppEnvironment.Instance.CurrentUser = null;

            //    NotifyPropertyChanged(nameof(IsUserSignedIn));
            //}
            //catch (Exception)
            //{
            //    await dialogService.ShowGenericServiceErrorNotification();
            //}
        }
    }
}