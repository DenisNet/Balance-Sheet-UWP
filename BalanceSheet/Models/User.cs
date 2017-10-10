using System;
using BalanceSheet.ComponentModel;

namespace BalanceSheet.Models
{
    public class User : ObservableObjectBase
    {
        //private int _goldBalance;

        /// <summary>
        /// Gets or sets the gold balance.
        /// </summary>
        //public int GoldBalance
        //{
        //    get { return _goldBalance; }
        //    set
        //    {
        //        if (value != _goldBalance)
        //        {
        //            _goldBalance = value;

        //            if (_goldBalance < 0)
        //            {
        //                _goldBalance = 0;
        //                throw new ArgumentException("User balance must not fall below zero.");
        //            }

        //            NotifyPropertyChanged(nameof(GoldBalance));
        //        }
        //    }
        //}

        /// <summary>
        /// Gets or sets the profile picture URL.
        /// </summary>
        public string ProfilePictureId { get; set; }

        /// <summary>
        /// Gets or sets the profile picture URL.
        /// </summary>
        public string ProfilePictureUrl { get; set; }

        /// <summary>
        /// Get or set the RegistrationReference
        /// </summary>
        public string RegistrationReference { get; set; }

        /// <summary>
        /// Datetime user record inserted
        /// </summary>
        public DateTime UserCreated { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Datetime user record last updated
        /// </summary>
        public DateTime UserModified { get; set; }
    }
}