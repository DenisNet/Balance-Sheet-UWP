using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using BalanceSheet.ViewModels;

namespace BalanceSheet.Registries
{
    public class ViewModelRegistry : RegistryBase, IRegistry
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public ViewModelRegistry(IUnityContainer container) : base(container)
        {
        }

        public void Configure()
        {
            //Container.RegisterType<HomeViewModel>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<StreamViewModel>(new ExternallyControlledLifetimeManager());
            //Container.RegisterType<IUploadFinishedHandler, DefaultUploadFinishedHandler>();
        }
    }
}