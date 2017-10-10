using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using BalanceSheet.Registries;

namespace BalanceSheet.Unity
{
    /// <summary>
    /// Help initial Unity deependency container
    /// </summary>
    public class UnityBootstrapper
    {
        /// <summary>
        /// Gets or sets the dependency container.
        /// </summary>
        public static UnityContainer Container { get; set; }

        public static List<IRegistry> Registries { get; private set; }

        private static void AddRegistries()
        {
            Registries.Add(new NavigationBarRegistry(Container));
            Registries.Add(new ServicesRegistry(Container));
            Registries.Add(new ViewModelRegistry(Container));
            Registries.Add(new ViewRegistry());
        }

        /// <summary>
        /// Configures all registered dependencies.
        /// </summary>
        public static void ConfigureRegistries()
        {
            AddRegistries();
            Registries.ForEach(i => i.Configure());
        }

        /// <summary>
        /// Initializes the <see cref="ServiceLocator" />.
        /// </summary>
        public static void Init()
        {
            Container = new UnityContainer();
            Registries = new List<IRegistry>();
            var locator = new UnityServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}