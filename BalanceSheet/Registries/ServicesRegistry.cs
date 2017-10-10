using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using BalanceSheet.Facades;
using BalanceSheet.Models;
using BalanceSheet.Views;
using BalanceSheet.Services;
using BalanceSheet.Store;
using BalanceSheet.Store.Simulation;

namespace BalanceSheet.Registries
{
    public class ServicesRegistry : RegistryBase, IRegistry
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public ServicesRegistry(IUnityContainer container) : base(container)
        {
        }

        public void Configure()
        {
            Container.RegisterInstance(typeof(IAppEnvironment), new AppEnvironment());

            Container.RegisterType<IDialogService, MessageDialogService>();
            Container.RegisterType<INavigationFacade, NavigationFacade>();
            Container.RegisterType<IAuthEnforcementHandler, AuthEnforcementHandler>(
                new ContainerControlledLifetimeManager());
            Container.RegisterType<IAuthenticationHandler, AuthenticationHandler>();
            //Container.RegisterType<ILicensingFacade, LicensingFacade>();

            // By default, in Debug mode the photo dummy service is used to showcase
            // test data.
            // In order to connect to a live service, either switch to Release mode
            // or remove the DUMMY_SERVICE directive entry in
            // PhotoSharingApp.Universal > Properties > Build > Conditional compilation symbols.
#if (DEBUG)
            Container.RegisterType<IPhotoService, PhotoDummyService>(new ContainerControlledLifetimeManager());
            CurrentAppProxy.IsMockEnabled = true;
            CurrentAppSimulatorHelper.InitCurrentAppSimulator();
#else
            //Container.RegisterType<IPhotoService, ServiceClient>();
#endif

        }
    }
}