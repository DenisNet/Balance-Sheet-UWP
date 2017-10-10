using Portable.DataContracts;
using BalanceSheet.Models;

namespace BalanceSheet.ContractModelConverterExtensions
{
    /// <summary>
    /// Helper class to convert between <see cref="User" />
    /// and <see cref="UserContract" /> classes.
    /// </summary>
    public static class UserConverter
    {
        /// <summary>
        /// Converts the given data model to a data contract.
        /// </summary>
        /// <param name="user">The data model.</param>
        /// <returns>The data contract.</returns>
        public static UserContract ToDataContract(this User user)
        {
            return new UserContract
            {
                UserId = user.UserId,
                ProfilePhotoId = user.ProfilePictureId,
                ProfilePhotoUrl = user.ProfilePictureUrl,
                //GoldBalance = user.GoldBalance,
                RegistrationReference = user.RegistrationReference,
                UserCreated = user.UserCreated,
                UserModified = user.UserModified
            };
        }

        /// <summary>
        /// Converts the given data contract to a data model.
        /// </summary>
        /// <param name="userContract">The data contract.</param>
        /// <returns>The data model.</returns>
        public static User ToDataModel(this UserContract userContract)
        {
            return new User
            {
                UserId = userContract.UserId,
                ProfilePictureId = userContract.ProfilePhotoId,
                ProfilePictureUrl = userContract.ProfilePhotoUrl,
                //GoldBalance = userContract.GoldBalance,
                RegistrationReference = userContract.RegistrationReference,
                UserCreated = userContract.UserCreated,
                UserModified = userContract.UserModified
            };
        }
    }
}
