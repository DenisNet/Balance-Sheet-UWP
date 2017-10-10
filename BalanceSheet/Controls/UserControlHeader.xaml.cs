using BalanceSheet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace BalanceSheet.Controls
{
    public sealed partial class UserControlHeader : UserControl
    {

        public MonatYearDaten datenViewModel;

        public UserControlHeader()
        {
            this.InitializeComponent();

            datenViewModel = new MonatYearDaten();
        }

        //Zusatz Property for dinamic Balance 
        public string BalanceWert
        {
            get { return (string)GetValue(BalanceWertProperty); }
            set
            {
                if (datenViewModel.BalanceForYearProperty < 0)
                {
                    txtPrice.Foreground = new SolidColorBrush(Color.FromArgb(255, 204, 51, 51));
                }
                else
                {
                    txtPrice.Foreground = new SolidColorBrush(Color.FromArgb(255, 125, 249, 88));
                }

                SetValue(BalanceWertProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for BalanceWert.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BalanceWertProperty =
            DependencyProperty.Register("BalanceWert", typeof(string), typeof(UserControlHeader), new PropertyMetadata(0));

    }
}
