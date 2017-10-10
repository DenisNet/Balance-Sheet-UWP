using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;
using BalanceSheet.Models;
using BalanceSheet.Views;
using System;

namespace BalanceSheet.Services
{
    public class AuthEnforcementHandler : IAuthEnforcementHandler
    {
        private TaskCompletionSource<bool> contentDialogClosedTaskCompletionSource;
        private readonly ResourceLoader resourceLoader;
        private TaskCompletionSource<SignInCompletionSource> signInTaskCompletionSource;

        public AuthEnforcementHandler()
        {
            resourceLoader = ResourceLoader.GetForCurrentView();
            AppEnvironment.Instance.CurrentUserChanged += Instance_CurrentUserChanged;
        }

        private void Instance_CurrentUserChanged(object sender, User e)
        {
            if (signInTaskCompletionSource != null)
            {
                signInTaskCompletionSource.SetResult(SignInCompletionSource.UserChanged);
            }
        }

        /// <summary>
        /// Requires a user to be signed in successfully.
        /// If not signed in already, the user will be prompted to do so.
        /// </summary>
        /// <exception cref="SignInRequiredException">When sign-in was not successful.</exception>
        public async Task CheckUserAuthentification()
        {
            if (AppEnvironment.Instance.CurrentUser == null)
            {
                var contentDialog = new ContentDialog
                {
                    SecondaryButtonText = resourceLoader.GetString("MessageDialog_Cancel"),
                    Title = resourceLoader.GetString("SignInRequired_Title")
                };

                contentDialogClosedTaskCompletionSource = new TaskCompletionSource<bool>();
                contentDialog.Closed += (s, e) => { contentDialogClosedTaskCompletionSource.SetResult(true); };

                var signinPage = new SignInPage();
                signinPage.ViewModel.RedirectToProfilePage = false;
                contentDialog.Content = signinPage;

                signInTaskCompletionSource = new TaskCompletionSource<SignInCompletionSource>();
                var dialogTask = signInTaskCompletionSource.Task;

                var task = contentDialog.ShowAsync();
                task.Completed = (info, status) =>
                {
                    if (signInTaskCompletionSource != null)
                    {
                        signInTaskCompletionSource.TrySetResult(SignInCompletionSource.DialogClosed);
                        signInTaskCompletionSource = null;
                    }
                };

                var result = await dialogTask;
                if (result == SignInCompletionSource.UserChanged)
                {
                    var contentDialogClosedTask = contentDialogClosedTaskCompletionSource.Task;
                    task.Cancel();
                    await contentDialogClosedTask;
                }

                if (AppEnvironment.Instance.CurrentUser == null)
                {
                    throw new SignInRequiredException("Sign-in not succesfull");
                }
            }
        }
    }
}