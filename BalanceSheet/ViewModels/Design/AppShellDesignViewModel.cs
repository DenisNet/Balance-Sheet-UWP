using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalanceSheet.NavigationBar;

namespace BalanceSheet.ViewModels.Design
{
    /// <summary>
    /// Design for AppShell
    /// </summary>
    public class AppShellDesignViewModel
    {
        public List<INavigationBarMenu> NavigationBarMenu { get; private set; }

        public List<INavigationBarMenu> BottomNavigationBarMenu { get; }
        public AppShellDesignViewModel()
        {
            NavigationBarMenu = new List<INavigationBarMenu>();

            BottomNavigationBarMenu = new List<INavigationBarMenu>
            {
                new SettingsNavigationBarMenu(),
                //new ProfileNavigationBarMenu()
            };
        }

        
    }
}

