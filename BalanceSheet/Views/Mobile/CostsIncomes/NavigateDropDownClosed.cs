using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BalanceSheet.Views.Mobile.CostsIncomes
{
    class NavigateDropDownClosed
    {
        //Navigate to Incomes without Stack
        public static void NavigateDropDownClosedMethod(ComboBox comboBox, Grid gridMain, Grid gridTemp, Frame frame)
        {
            if (comboBox.SelectedIndex == 0)
            {
                gridMain.Children.Remove(gridTemp);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (frame != null && frame.CanGoBack)
                    {
                        frame.GoBack();
                    }
                }

                frame.Navigate(typeof(Incomes), null);
            }

        }
    }
}
