using Microsoft.Practices.Unity;
using BalanceSheet.NavigationBar;
using BalanceSheet.Unity;

namespace BalanceSheet.Registries
{
    public class NavigationBarRegistry : RegistryBase, IRegistry
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="container">The Unity container.</param>
        public NavigationBarRegistry(IUnityContainer container): base(container)
        {
        }

        /// <summary>
        /// Configures dependencies.
        /// </summary>
        public void Configure()
        {
            Container.RegisterTypeWithName<INavigationBarMenu, HomeNavigationBarMenu>();
            Container.RegisterTypeWithName<INavigationBarMenu, CalendarNavigationBarMenu>();
            Container.RegisterTypeWithName<INavigationBarMenu, ReportNavigationBarMenu>();
            Container.RegisterTypeWithName<INavigationBarMenu, StatisticNavigationBarMenu>();
            //Container.RegisterTypeWithName<INavigationBarMenu, WelcomeNavigationBarMenu>();

            Container.RegisterTypeWithName<INavigationBarMenu, SettingsNavigationBarMenu>();
            //Container.RegisterTypeWithName<INavigationBarMenu, ProfileNavigationBarMenu>();
            Container.RegisterTypeWithName<INavigationBarMenu, HelpNavigationBarMenu>();
        }
    }
}