using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceSheet.ViewModels
{
    /// <summary>
    /// Liefert wann soll TogleButton gezeigt werden
    /// </summary>
    class AppShellToggleButton
    {
        private static bool shellButton;

        public bool GetShellButton()
        {
            return shellButton;
        }

        public void SetShellButton(bool v)
        {
            shellButton = v;
        }
    }
}
