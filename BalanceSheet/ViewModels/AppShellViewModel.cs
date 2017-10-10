using BalanceSheet.NavigationBar;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceSheet.ViewModels
{
    /// <summary>
    /// The ViewModel for the AppShell.
    /// </summary>
    public class AppShellViewModel: ViewModelBase
    {
        public List<INavigationBarMenu> BottomNavigationBarMenu { get; }
        public List<INavigationBarMenu> NavigationBarMenu { get; private set; }
        public AppShellViewModel()
        {
            NavigationBarMenu = ServiceLocator.Current.GetAllInstances<INavigationBarMenu>()
                .Where(i => i.Position == NavigationBarPosition.Top).ToList();
            BottomNavigationBarMenu = ServiceLocator.Current.GetAllInstances<INavigationBarMenu>()
                .Where(i => i.Position == NavigationBarPosition.Bottom).ToList();
        }
    }
}