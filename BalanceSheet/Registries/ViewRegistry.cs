using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalanceSheet.Facades;
using BalanceSheet.ViewModels;
using BalanceSheet.Views;

namespace BalanceSheet.Registries
{
    public class ViewRegistry : IRegistry
    {
        public void Configure()
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                NavigationFacade.AddType(typeof(HomePage_Mobile), typeof(HomeViewModel));
                NavigationFacade.AddType(typeof(WelcomePage), typeof(WelcomeViewModel));
            }
            else
            {
                NavigationFacade.AddType(typeof(HomePage), typeof(HomeViewModel));
                NavigationFacade.AddType(typeof(WelcomePage), typeof(WelcomeViewModel));
            }
        }
    }
}