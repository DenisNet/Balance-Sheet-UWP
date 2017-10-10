using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using BalanceSheet.Models;

namespace BalanceSheet.Services
{
    public interface IAuthenticationHandler
    {
        /// <summary>
        /// Gets the preferred authentication providers for this app.
        /// </summary>
        /// <value>
        /// The authentication providers.
        /// </value>
        List<MobileServiceAuthenticationProvider> AuthenticationProviders { get; }

        /// <summary>
        /// Starts the authentication process.
        /// </summary>
        /// <param name="provider">The provider to authenticate with.</param>

        Task AuthenticateAsync(MobileServiceAuthenticationProvider provider);

        /// <summary>
        /// Logs the user out.
        /// </summary>
        Task LogoutAsync();

        /// <summary>
        /// Clears the password vault.
        /// </summary>
        void ResetPasswordVault();

        /// <summary>
        /// Restores the sign in status.
        /// </summary>
        /// <returns>True, if successful. Otherwise, false.</returns>
        Task<User> RestoreSignInStatus();
    }
}