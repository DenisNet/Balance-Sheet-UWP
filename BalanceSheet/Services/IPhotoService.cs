using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using BalanceSheet.Models;

namespace BalanceSheet.Services
{
    //using PhotoSharingApp.Portable.DataContracts;

    public interface IPhotoService
    {
        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="categoryName">The category name.</param>
        /// <returns>The category.</returns>
        //Task<Category> CreateCategory(string categoryName);

        /// <summary>
        /// Deletes the photo.
        /// </summary>
        /// <param name="photo">The photo.</param>
        //Task DeletePhoto(Photo photo);

        /// <summary>
        /// Fulfills gold on the service.
        /// </summary>
        /// <param name="productReceipt">The product receipt.</param>
        /// <returns>The user with an updated gold balance.</returns>
        //Task<User> FulfillGold(string productReceipt);

        /// <summary>
        /// Gets the available authentication providers.
        /// </summary>
        /// <returns>The authentication providers.</returns>
        List<MobileServiceAuthenticationProvider> GetAvailableAuthenticationProviders();

        /// <summary>
        /// Retrieves all categories without thumbnails.
        /// </summary>
        /// <returns>The categories.</returns>
        //Task<List<Category>> GetCategories();

        /// <summary>
        /// Gets the configuration data.
        /// </summary>
        /// <returns>The configuration data.</returns>
        Task<Config> GetConfig();

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns>The details for the user that is logged in.</returns>
        Task<User> GetCurrentUser();

        /// <summary>
        /// Retrieves hero images.
        /// </summary>
        /// <param name="count">Number of hero images.</param>
        /// <returns>The images.</returns>
        //Task<List<Photo>> GetHeroImages(int count);

        /// <summary>
        /// Gets the leaderboard statistical data
        /// </summary>
        /// <returns>The leaderboard</returns>
        //Task<Leaderboard> GetLeaderboardData(int mostGoldCategoriesCount, int mostGoldPhotosCount, int mostGoldUsersCount, int mostGivingUsersCount);

        /// <summary>
        /// Gets the photo details for the given photo id.
        /// </summary>
        /// <param name="photoId">The photo identifier.</param>
        /// <returns>The photo.</returns>
        //Task<Photo> GetPhotoDetails(string photoId);

        /// <summary>
        /// Gets photos for the given category id.
        /// </summary>
        /// <param name="categoryId">The identifier.</param>
        /// <param name="continuationToken">Optional. The continuation token. By default, null.</param>
        /// <returns>The photos.</returns>
        //Task<PagedResponse<Photo>> GetPhotosForCategoryId(string categoryId, string continuationToken = null);

        /// <summary>
        /// Gets photos uploaded by the current user.
        /// </summary>
        /// <param name="continuationToken">Optional. The continuation token. By default, null.</param>
        /// <returns>The photos.</returns>
        //Task<PagedResponse<Photo>> GetPhotosForCurrentUser(string continuationToken = null);

        /// <summary>
        /// Gets photos uploaded by the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="continuationToken">Optional. The continuation token. By default, null.</param>
        /// <returns>The photos.</returns>
        //Task<PagedResponse<Photo>> GetPhotosForUser(User user, string continuationToken = null);

        /// <summary>
        /// Retrieves top categories with thumbnails.
        /// </summary>
        /// <param name="categoryThumbnailsCount">The number of thumbnails per each category.</param>
        /// <param name="continuationToken">Optional. The continuation token. By default, null.</param>
        /// <returns>The category list.</returns>
        //Task<List<CategoryPreview>> GetTopCategories(int categoryThumbnailsCount, string continuationToken = null);

        /// <summary>
        /// Posts the annotation.
        /// </summary>
        /// <param name="photo">The photo.</param>
        /// <param name="annotationText">The text.</param>
        /// <param name="goldCount">The amount of gold being given.</param>
        /// <returns>The annotation including the id.</returns>
        //Task<Annotation> PostAnnotation(Photo photo, string annotationText, int goldCount);

        /// <summary>
        /// Removes the Annotation.
        /// </summary>
        /// <param name="annotation">The Annotation.</param>
        Task RemoveAnnotation(Annotation annotation);

        /// <summary>
        /// Reports the Annotation as inappropriate.
        /// </summary>
        /// <param name="annotation">The Annotation.</param>
        Task ReportAnnotation(Annotation annotation);

        /// <summary>
        /// Reports the photo as inappropriate.
        /// </summary>
        /// <param name="photo">The photo.</param>
        /// <param name="reportReason">The reason for the report.</param>
        //Task ReportPhoto(Photo photo, ReportReason reportReason);

        /// <summary>
        /// Checks if credentials are available and not expired,
        /// which are then used to restore the sign in status.
        /// The user is not actively taken to a login page.
        /// </summary>
        Task RestoreSignInStatusAsync();

        /// <summary>
        /// Signs the user in.
        /// </summary>
        /// <param name="provider">The provider.</param>
        Task SignInAsync(MobileServiceAuthenticationProvider provider);

        /// <summary>
        /// Signs the user out.
        /// </summary>
        Task SignOutAsync();

        /// <summary>
        /// Updates the photo.
        /// </summary>
        /// <param name="photo">The photo.</param>
        //Task UpdatePhoto(Photo photo);

        /// <summary>
        /// Updates the current user's profile photo
        /// </summary>
        /// <param name="photo">The new profile photo</param>
        /// <returns>The updated user</returns>
        //Task<User> UpdateUserProfilePhoto(Photo photo);

        /// <summary>
        /// Uploads the photo.
        /// </summary>
        /// <param name="stream">The memory stream.</param>
        /// <param name="localPath">The local path.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="categoryId">The id of the assocaited category.</param>
        /// <returns>The uploaded photo.</returns>
        //Task<Photo> UploadPhoto(Stream stream, string localPath, string caption, string categoryId);
    }
}
