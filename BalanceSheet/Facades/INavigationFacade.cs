using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using BalanceSheet.Models;

namespace BalanceSheet.Facades
{
    /// <summary>
    /// Encapsulates page navigation.
    /// </summary>
    public interface INavigationFacade
    {
        /// <summary>
        /// Goes back to the previews view(s).
        /// </summary>
        /// <param name="steps">Number of views to go back.</param>
        void GoBack(int steps = 1);

        /// <summary>
        /// Navigates to the about view.
        /// </summary>
        void NavigateToAboutView();

        /// <summary>
        /// Navigates to the Home
        /// </summary>
        void NavigateToHomeView();

        /// <summary>
        /// Navigates to the settings view.
        /// </summary>
        void NavigateToSettingsView();
        /// <summary>
        /// Navigates to the categories view.
        /// </summary>
        void NavigateToCategoriesView();

        /// <summary>
        /// Navigates to the crop view.
        /// </summary>
        /// <param name="file">The photo to crop.</param>
        void NavigateToCropView(StorageFile file);

        /// <summary>
        /// Navigates to the photo details view.
        /// </summary>
        /// <param name="photoId">The photoId.</param>
        void NavigateToPhotoDetailsView(string photoId);

        /// <summary>
        /// Navigates to the signed-in user's profile view.
        /// </summary>
        void NavigateToProfileView();

        /// <summary>
        /// Navigates to the given user's profile view.
        /// </summary>
        /// <param name="user">The user to show the profile view for.</param>
        void NavigateToProfileView(User user);

        /// <summary>
        /// Navigates to the sign-in view.
        /// </summary>
        void NavigateToSignInView();

        /// <summary>
        /// Navigates to the Welcome view.
        /// </summary>
        void NavigateToWelcomeView();

        /// <summary>
        /// Removes the specified number of frames from the back stack.
        /// </summary>
        /// <param name="numberOfFrames">The number of frames.</param>
        void RemoveBackStackFrames(int numberOfFrames);

        /// <summary>
        /// Removes the frames associated with uploading a photo from the back stack.
        /// </summary>
        /// <param name="categoryIdNavigatedTo">The category id that was navigated to after photo upload.</param>
        void RemoveUploadPhotoFramesFromBackStack(string categoryIdNavigatedTo);

        /// <summary>
        /// Displays a dialog that lets the user create
        /// a new category.
        /// </summary>
        Task ShowCreateCategoryDialog();

    }
}