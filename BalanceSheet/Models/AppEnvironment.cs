using System;
using Microsoft.Practices.ServiceLocation;
using Windows.System.Profile;
using BalanceSheet.ComponentModel;
using BalanceSheet.Extensions;

namespace BalanceSheet.Models
{
    public class AppEnvironment : ObservableObjectBase, IAppEnvironment
    {
        public static readonly int DefaultMinimumCropDimension = 200;
        public static readonly double FloatingComparisonTolerance = 0.001;
        private User currentUser;

        public int CategoryThumbnailsCount { get; set; }
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (value != currentUser)
                {
                    currentUser = value;
                    NotifyPropertyChanged(nameof(CurrentUser));
                    CurrentUserChanged?.Invoke(this, CurrentUser);
                }
            }
        }

        private DeviceFamily DeviceFamily { get; } = AnalyticsInfo.VersionInfo.DeviceFamily.ToDeviceFamily();

        public static AppEnvironment Instance
        {
            get { return ServiceLocator.Current.GetAllInstances<IAppEnvironment>() as AppEnvironment; }
        }

        public bool IsDesktopDeviceFamily
        {
            get { return DeviceFamily == DeviceFamily.Desktop; }
        }

        public bool IsMobileDeviceFamily
        {
            get { return DeviceFamily == DeviceFamily.Mobile; }
        }

        public event EventHandler<User> CurrentUserChanged;

        public void SetConfig(Config config)
        {
            if (IsMobileDeviceFamily)
            {
                CategoryThumbnailsCount = config.CatThumSmallFromFaktor;
            }
            else
            {
                CategoryThumbnailsCount = config.CatThumLargeFromFaktor;
            }
        }
    }
}