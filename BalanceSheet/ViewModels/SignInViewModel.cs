using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;
using Microsoft.WindowsAzure.MobileServices;
using BalanceSheet.Commands;
using BalanceSheet.Facades;
using BalanceSheet.Services;
using BalanceSheet.Views;

namespace BalanceSheet.ViewModels
{
    /// <summary>
    /// The ViewModel for the sign-in view.
    /// </summary>
    public class SignInViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;
        private readonly INavigationFacade navigationFacade;
        private readonly IPhotoService photoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInViewModel" /> class.
        /// </summary>
        /// <param name="navigationFacade">The navigation facade.</param>
        /// <param name="photoService">The photo service.</param>
        /// <param name="dialogService">The dialog service.</param>
        public SignInViewModel(INavigationFacade navigation, IPhotoService photo,
            IDialogService dialog)
        {
            navigationFacade = navigation;
            photoService = photo;
            dialogService = dialog;

            // Initialize commands
            ChooseAuthProviderCommand = new RelayCommand<MobileServiceAuthenticationProvider>(OnChooseAuthProvider);

            // Initialize auth providers
            AuthenticationProviders = photoService.GetAvailableAuthenticationProviders();
        }

        /// <summary>
        /// Gets or sets the authentication providers.
        /// </summary>
        /// <value>
        /// The authentication providers.
        /// </value>
        public List<MobileServiceAuthenticationProvider> AuthenticationProviders { get; set; }

        /// <summary>
        /// Gets the authentication reassurance message.
        /// </summary>
        public string AuthenticationReassuranceMessage { get; } = ResourceLoader.GetForCurrentView().GetString("SignInPage_ReassuranceMessage");

        /// <summary>
        /// Gets the choose authentication provider command.
        /// </summary>
        /// <value>
        /// The choose authentication provider command.
        /// </value>
        public RelayCommand<MobileServiceAuthenticationProvider> ChooseAuthProviderCommand { get; private set; }

        /// <summary>
        /// Enables or disables the trigger to redirect
        /// to the profile page after a successful sign-in.
        /// 
        /// The default use case is that users will directly navigate to the
        // sign-in page which should redirect to the profile page.
        // Alternatively, users can sign-in using the sign-in
        // dialog, which should not do any redirections.
        /// </summary>
        public bool RedirectToProfilePage { get; set; } = true;

        private async void OnChooseAuthProvider(MobileServiceAuthenticationProvider authenticationProviderProvider)
        {
            try
            {
                await photoService.SignInAsync(authenticationProviderProvider);

                if (RedirectToProfilePage)
                {
                    navigationFacade.NavigateToProfileView();
                    navigationFacade.RemoveBackStackFrames(1);
                }
            }
            catch (AuthenticationException)
            {
                await dialogService.ShowNotification("AuthenticationFailed_Message", "AuthenticationFailed_Title");
            }
            catch (AuthenticationCanceledException)
            {
                // User canceled, do nothing in this case.
            }
            catch (Exception)
            {
                await dialogService.ShowNotification("GenericError_Title", "GenericError_Message");
            }
        }
    }
}