using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;

namespace BalanceSheet.ViewModels.Design
{
    /// <summary>
    /// The design-time ViewModel for the sign-in view.
    /// </summary>
    public class SignInDesignViewModel
    {
        public List<MobileServiceAuthenticationProvider> AuthenticationProviders { get; set; } = new List<MobileServiceAuthenticationProvider>
        {
            MobileServiceAuthenticationProvider.Facebook,
            MobileServiceAuthenticationProvider.Google,
            MobileServiceAuthenticationProvider.MicrosoftAccount
        };
    }
}