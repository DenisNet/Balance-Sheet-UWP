using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using BalanceSheet.Extensions;
using BalanceSheet.Models;
using BalanceSheet.ViewModels;
using BalanceSheet.Views;
using BalanceSheet.Serialization;
//using BalanceSheet.Serialization;

namespace BalanceSheet.Facades
{
    /// <summary>
    /// Encapsulates page navigation.
    /// </summary>
    class NavigationFacade: INavigationFacade
    {
        /// <summary>
        /// The mappings between views and their view models
        /// </summary>
        private static readonly Dictionary<Type, Type> ViewViewModelDictionary = new Dictionary<Type, Type>();
        
        /// <summary>
        /// The current frame.
        /// </summary>
        private Frame frame;
        
        ///// <summary>
        ///// Determines if back navigation
        ///// </summary>
        //public bool CanGoBack
        //{
        //    get { return frame.CanGoBack; }
        //}
        /// <summary>
        /// Adds the specified types to the association list.
        /// </summary>
        /// <param name="view">The view type.</param>
        /// <param name="viewModel">The ViewModel type.</param>
        /// <exception cref="System.ArgumentException">The ViewModel has already been added and is only allowed once.</exception>
        public static void AddType(Type view, Type viewModel)
        {
            if (ViewViewModelDictionary.ContainsKey(viewModel))
            {
                throw new ArgumentException("The ViewModel has already been added and is only allowed once.");
            }
            ViewViewModelDictionary.Add(viewModel, view);
        }

        /// <summary>
        /// Makes sure a frame is available that can be used
        /// for navigation.
        /// </summary>
        private void EnsureNavigationFrameIsAvailable()
        {
            var content = Window.Current.Content;
            if (content is AppShell)
            {
                var appShell = content as AppShell;
                frame = appShell.AppFrame;
            }
            else if (content is Frame)
            {
                var frameShell = content as Frame;
                frame = frameShell;
            }
            else
            {
                throw new ArgumentException("Window.Current.Content");
            }
        }

        /// <summary>
        /// Goes back in the navigation stack for the specified
        /// number of steps.
        /// </summary>
        /// <param name="steps">The steps. By default: 1.</param>
        public void GoBack(int step = 1)
        {
            EnsureNavigationFrameIsAvailable();
            if (step > 1)
            {
                RemoveBackStackFrames(step - 1);
            }
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        ///// Checks if the specified type is a photo upload related page.
        ///// </summary>
        ///// <param name="pageType">The type.</param>
        ///// <returns>Returns true if the specified type is a photo upload related page.</returns>
        //private static bool IsTypePhotoUploadRelated(Type pageType)
        //{
        //    return pageType != null;
        //}

        /// <summary>
        /// Navigates to the specified view model type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="parameter">The parameter. Optional.</param>
        /// <param name="serializeParameter">The serialized parameter. Optional.</param>
        private void Navigate(Type viewModelType, object parametr = null, bool serializeParametr = true)
        {
            var view = ViewViewModelDictionary[viewModelType];
            if (view == null)
            {
                throw new ArgumentException("The specified ViewModel could not be found.");
            }
            if (view.GetTypeInfo().IsSubclassOf(typeof(SettingsFlyout)))
            {
                var flyout = (SettingsFlyout)Activator.CreateInstance(view);
                flyout.ShowIndependent();
            }
            else
            {
                EnsureNavigationFrameIsAvailable();
                if (parametr == null)
                {
                    frame.Navigate(view);
                }
                else
                {
                    if (serializeParametr)
                    {
                        var serialized = SerializationHelper.Serialize(parametr);
                        frame.Navigate(view, serialized);
                    }
                    else
                    {
                        frame.Navigate(view, parametr);
                    }
                }
            }
        }

        /// <summary>
        /// Navigates to the about view.
        /// </summary>
        public void NavigateToAboutView()
        {
            //Navigate(typeof(InfoViewModel));
        }

        public void NavigateToSettingsView()
        {
            Navigate(typeof(SettingsViewModel));
        }

        public void NavigateToCalender()
        {
            Navigate(typeof(CalendarViewModel));
        }
        public async void NavigateToHomeView()
        {
            Navigate(typeof(HomeViewModel));
        }


        public void NavigateToProfile()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Displays a dialog that lets the user pick
        /// a category.
        /// Removes the specified number of frames from the back stack.
        /// </summary>
        /// <param name="numberOfFrames">The number of frames.</param>
        public void RemoveBackStackFrames(int numberOfFrames)
        {
            EnsureNavigationFrameIsAvailable();

            var framesToRemove = numberOfFrames;
            framesToRemove = Math.Min(framesToRemove, frame.BackStackDepth);

            while (framesToRemove > 0)
            {
                frame.BackStack.RemoveAt(frame.BackStackDepth - 1);
                framesToRemove--;
            }
        }

        public void NavigateToCategoriesView()
        {
            throw new NotImplementedException();
        }

        public void NavigateToCropView(StorageFile file)
        {
            throw new NotImplementedException();
        }

        public void NavigateToPhotoDetailsView(string photoId)
        {
            throw new NotImplementedException();
        }

        public void NavigateToProfileView()
        {
            throw new NotImplementedException();
        }

        public void NavigateToProfileView(User user)
        {
            throw new NotImplementedException();
        }

        public void NavigateToSignInView()
        {
            throw new NotImplementedException();
        }

        public void NavigateToWelcomeView()
        {
            Navigate(typeof(WelcomeViewModel));
        }

        public void RemoveUploadPhotoFramesFromBackStack(string categoryIdNavigatedTo)
        {
            throw new NotImplementedException();
        }

        public Task ShowCreateCategoryDialog()
        {
            throw new NotImplementedException();
        }

    }
}        