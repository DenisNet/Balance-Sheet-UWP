using BalanceSheet.Models;
using BalanceSheet.Services;

namespace BalanceSheet.ViewModels
{
    /// <summary>
    /// ViewModel for the PageHeader UI component.
    /// </summary>
    public class PageHeaderViewModel : ViewModelBase
    {
        private User _currentUser;

        /// <summary>
        /// The constructor.
        /// </summary>
        public PageHeaderViewModel(IPhotoService photoService)
        {
            // Get current user as UI will bind directly to it.
            //CurrentUser = AppEnvironment.Instance.CurrentUser;

            //IsDummyServiceEnabled = photoService is PhotoDummyService;
        }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (value != _currentUser)
                {
                    _currentUser = value;
                    NotifyPropertyChanged(nameof(CurrentUser));
                }
            }
        }

        public bool IsDummyServiceEnabled { get; set; }
    }
}