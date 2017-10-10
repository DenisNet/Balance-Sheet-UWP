using System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace BalanceSheet.Views
{
    /// <summary>
    /// A dialog service that uses <see cref="MessageDialog"/> for showing
    /// messages to the user.
    /// </summary>
    class MessageDialogService : IDialogService
    {
        private readonly CoreDispatcher dispetcher;

        public MessageDialogService()
        {
            dispetcher = Window.Current.Dispatcher;
        }
        /// <summary>
        /// Shows a notification that there is an issue with communicating
        /// to the service.
        /// </summary>
        public async Task ShowGenericServiceErrorNotification()
        {
            await ShowNotification("ServiceError_Message", "GenericError_Title");
        }

        /// <summary>
        /// Shows the notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="useResourceLoader">
        /// if set to <c>true</c> the message and title
        /// parameters specify the resource id.
        /// </param>
        public async Task ShowNotification(string message, string title, bool useResourceLoader = true)
        {
            Action action = async () =>
            {
                if (useResourceLoader)
                {
                    var resourceLoader = ResourceLoader.GetForCurrentView();
                    message = resourceLoader.GetString(message);
                    title = resourceLoader.GetString(title);
                }
                var dialog = new MessageDialog(message, title);
                await dialog.ShowAsync();
            };
            if (dispetcher.HasThreadAccess)
            {
                action();
            }
            else
            {
                await dispetcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
            }
        }

        /// <summary>
        /// Shows a notification that lets the user choose between yes and no.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="useResourceLoader">
        /// if set to <c>true</c> the message and title
        /// parameters specify the resource id.
        /// </param>
        /// <returns>True, if user has chosen yes. Otherwise, false.</returns>
        public async Task<bool> ShowYesNoNotification(string message, string title, bool useResourceLoader = true)
        {
            var resourceLoader = ResourceLoader.GetForCurrentView();
            if (useResourceLoader)
            {
                message = resourceLoader.GetString(message);
                title = resourceLoader.GetString(title);
            }
            var yesCom = new UICommand(resourceLoader.GetString("MessageDialog_Yes"));
            var noCom = new UICommand(resourceLoader.GetString("MessageDialog_No"));

            var dialog = new MessageDialog(message, title);
            dialog.Commands.Add(yesCom);
            dialog.Commands.Add(noCom);
            var result = await dialog.ShowAsync();
            return result == yesCom;
        }
    }
}