using System;

namespace Portable.DataContracts
{
    public class UserContract
    {
        /// <summary>
        /// User gold total balance.
        /// </summary>
        public int GoldBalance { get; set; }

        /// <summary>
        /// Guid of profile picture, null at creation.
        /// </summary>
        public string ProfilePhotoId { get; set; }

        /// <summary>
        /// Url of profile picture, null at creation.
        /// </summary>
        public string ProfilePhotoUrl { get; set; }

        /// <summary>
        /// AzureMobileServices auth id, the only id we have at the time of creation.
        /// </summary>
        public string RegistrationReference { get; set; }

        /// <summary>
        /// Timestamp when the profile was created.
        /// </summary>
        public DateTime UserCreated { get; set; }

        /// <summary>
        /// UserId in the form of a guid.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Timestamp when the profile was last modified.
        /// </summary>
        public DateTime UserModified { get; set; }
    }
}