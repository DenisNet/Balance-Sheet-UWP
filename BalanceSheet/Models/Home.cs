using System;
using BalanceSheet.ComponentModel;

namespace BalanceSheet.Models
{
    /// <summary>
    /// Represents a home.
    /// </summary>
    public class Home : ObservableObjectBase
    {
        private string id;
        private string name;

        /// <summary>
        /// Gets the data model validation result.
        /// Returns true, if it contains one or more errors.
        /// Otherwise, false.
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return string.IsNullOrWhiteSpace(name)
                       || name.Length < 2
                       || name.StartsWith("my", StringComparison.CurrentCultureIgnoreCase);
            }
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged(nameof(Id));
                }
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged(nameof(Name));

                    // The name has changed, so we need to update the
                    // object's validation status.
                    NotifyPropertyChanged(nameof(HasErrors));
                }
            }
        }
    }
}