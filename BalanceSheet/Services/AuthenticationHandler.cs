using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Security.Credentials;
using BalanceSheet.Models;
using BalanceSheet.ContractModelConverterExtensions;
using Portable.DataContracts;

namespace BalanceSheet.Services
{
    /// <summary>
    /// Helper calss for doing authentication & managing auth status
    /// using Azure Mobile Services.
    /// </summary>
    class AuthenticationHandler : IAuthenticationHandler
    {
        public List<MobileServiceAuthenticationProvider> AuthenticationProviders { get; }

        public AuthenticationHandler()
        {
            AuthenticationProviders = new List<MobileServiceAuthenticationProvider>
            {
                MobileServiceAuthenticationProvider.Facebook,
                MobileServiceAuthenticationProvider.Google,
                MobileServiceAuthenticationProvider.MicrosoftAccount,
                MobileServiceAuthenticationProvider.Twitter
            };
        }

        /// <summary>
        /// Starts the authentication process.
        /// </summary>
        /// <param name="provider">The provider to authenticate with.</param>
        public async Task AuthenticateAsync(MobileServiceAuthenticationProvider provider)
        {
            //try
            //{
            //    var vault = new PasswordVault();

            //    //var user = await AzureAppService.Current.LoginAsync(provider);

            //    // Create and store the user credentials.
            //    var credential = new PasswordCredential(provider.ToString(),
            //        //user.UserId, user.MobileServiceAuthenticationToken);

            //    vault.Add(credential);
            //}
            //catch (InvalidOperationException invalidOperationException)
            //{
            //    if (invalidOperationException.Message
            //        .Contains("Authentication was cancelled by the user."))
            //    {
            //        throw new AuthenticationCanceledException("Authentication canceled by user",
            //            invalidOperationException);
            //    }

            //    throw new AuthenticationException("Authentication failed", invalidOperationException);
            //}
            //catch (Exception e)
            //{
            //    throw new AuthenticationException("Authentication failed", e);
            //}
        }

        public async Task LogoutAsync()
        {
            var vault = new PasswordVault();
            var credential = vault.RetrieveAll().FirstOrDefault();
            if (credential != null)
            {
                var user = new MobileServiceUser(credential.UserName);
                credential.RetrievePassword();
                user.MobileServiceAuthenticationToken = credential.Password;
                AzureAppService.Current.CurrentUser = user;

                try
                {
                    // Try to return an item now to determine if the cached credential has expired.
                    await AzureAppService.Current.LogoutAsync();
                }
                catch (MobileServiceInvalidOperationException)
                {
                    // We are not interested in any exceptions here
                }
                finally
                {
                    // Make sure vault is cleaned up
                    ResetPasswordVault();
                }
            }

            await Task.FromResult(0);
        }

        public void ResetPasswordVault()
        {
            var vault = new PasswordVault();
            var credentials = vault.RetrieveAll();
            foreach (var item in credentials)
            {
                vault.Remove(item);
            }
        }

        public async Task<User> RestoreSignInStatus()
        {
            // Use the PasswordVault to securely store and access credentials.
            var vault = new PasswordVault();
            // Try to get an existing credential from the vault.
            var credential = vault.RetrieveAll().FirstOrDefault();

            if (credential != null)
            {
                // Create a user from the stored credentials.
                var user = new MobileServiceUser(credential.UserName);
                credential.RetrievePassword();
                user.MobileServiceAuthenticationToken = credential.Password;

                // Set the user from the stored credentials.
                AzureAppService.Current.CurrentUser = user;

                try
                {
                    var userContract = await AzureAppService.Current.InvokeApiAsync<UserContract>("User", HttpMethod.Get,
                        null);

                    return userContract.ToDataModel();
                }
                catch (MobileServiceInvalidOperationException invalidOperationException)
                {
                    if (invalidOperationException.Response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Remove the credentials.
                        ResetPasswordVault();

                        AzureAppService.Current.CurrentUser = null;
                        credential = null;
                    }
                }
            }
            return null;
        }
    }
}