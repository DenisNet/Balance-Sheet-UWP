using BalanceSheet.Models;
using BalanceSheet.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace BalanceSheet.Views.Mobile.CostsIncomes
{
    /// <summary>
    /// Save Result 
    /// </summary>
    public sealed partial class SaveResult : Page
    {
        #region Properties
        public static string CategorySymbol { get; internal set; }

        //Name of Category
        public static string CategoryName { get; internal set; }

        public static FontFamily CategorySymbolFontFamily { get; internal set; }

        public static string UnderCategorySymbol { get; internal set; }

        //Name of UnderCategory
        public static string UnderCategoryName { get; internal set; }

        public static FontFamily UnderCategorySymbolFontFamily { get; internal set; }
       
        //für markierung im Delete von Items, und feststellen in SQLite zur welche 
        //Database gehört
        enum CostsOrIncomesIndex { Cost, Income, None };

        /// <summary>
        /// ComboBox = Ausgaben(0) oder Einkommen(1)
        /// </summary>
        public static int IndexComboBox {get; internal set;}
        #endregion

        //DataBase
        //private DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile> optionsBuilder;
        private Store.DataBase.DataBaseEF.DataBaseFile dataBase;

        //UserNumberFormatInfo
        UserNumberFormat uNFI;

        /// <summary>
        /// Default Construktor
        /// </summary>
        public SaveResult()
        {
            this.InitializeComponent();
            uNFI = new UserNumberFormat();
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            btnSpeichern.Content = loader.GetString("BtnSave");

            comboBox.SelectedIndex = IndexComboBox;
            txtBoxWert.Text = 0.ToString("C", uNFI.GetNFI());
            //optionsBuilder = new DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile>();
            //optionsBuilder.UseSqlite("Filename=Balance.db");
            //dataBase = new Store.DataBase.DataBaseEF.DataBaseFile(optionsBuilder.Options);
            dataBase = new Store.DataBase.DataBaseEF.DataBaseFile();
            this.Loaded += SaveResult_Loaded;
        }

        private void SaveResult_Loaded(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Desktop)
            {
                CmBoxItemCost.Width = ActualWidth / 2;
                CmBoxItemIncome.Width = ActualWidth / 2;
                btnSpeichern.Style = null;
                gridWithBack.MaxWidth = 600;
            }
        }

            /// <summary>
            /// Construktor without UnderCategory
            /// </summary>
            /// <param name="categorySymbol">Name Symbol of Category</param>
            /// <param name="categoryName">Name of Category</param>
            /// <param name="categorySymbolFontFamily">FontFamily of Category</param>
            /// <param name="SelectedIndexComboBox">SelectedIndex of ComboBox Ausgaben(0) or Einkommen(1)</param>
            public SaveResult(string categorySymbol, string categoryName, FontFamily categorySymbolFontFamily, int SelectedIndexComboBox)
        {
            CategorySymbol = categorySymbol;
            CategoryName = categoryName;
            CategorySymbolFontFamily = categorySymbolFontFamily;
            UnderCategoryName = string.Empty;
            UnderCategorySymbol = string.Empty;
            UnderCategorySymbolFontFamily = null;
            IndexComboBox = SelectedIndexComboBox;
        }

        /// <summary>
        /// Construktor with UnderCategory
        /// </summary>
        /// <param name="categorySymbol">Name Symbol of Category</param>
        /// <param name="categoryName">Name of Category</param>
        /// <param name="categorySymbolFontFamily">FontFamily of Category</param>
        /// <param name="underCategorySymbol">Name Symbol of UnderCategory</param>
        /// <param name="underCategorySymbolFontFamily">FontFamily of UnderCategory Symbol</param>
        /// <param name="SelectedIndexComboBox">SelectedIndex of ComboBox Ausgaben(0) or Einkommen(1)</param>
        public SaveResult(string categorySymbol, string categoryName, FontFamily categorySymbolFontFamily, string underCategorySymbol, FontFamily underCategorySymbolFontFamily, int SelectedIndexComboBox)
        {
            CategorySymbol = categorySymbol;
            CategoryName = categoryName;
            CategorySymbolFontFamily = categorySymbolFontFamily;
            UnderCategorySymbol = underCategorySymbol;
            UnderCategorySymbolFontFamily = underCategorySymbolFontFamily;
            IndexComboBox = SelectedIndexComboBox;
        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void ComboBox_DropDownClosed(object sender, object e)
        {
            NavigateDropDownClosed.NavigateDropDownClosedMethod(comboBox, gridMain, gridTemp, this.Frame);
        }

        Grid gridTemp = new Grid();

        private void ComboBox_DropDownOpened(object sender, object e)
        {
            gridTemp.Width = gridMain.ActualWidth;
            gridTemp.Height = gridMain.ActualHeight;
            gridTemp.Background = new SolidColorBrush(Color.FromArgb(255, 17, 157, 218));
            gridTemp.Opacity = 0.9;
            gridTemp.Margin = new Thickness(0, -25, 0, 0);
            gridMain.Children.Add(gridTemp);
        }

        private void TxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxWert.Text == 0.ToString("C", uNFI.GetNFI()))
            {
                txtBoxWert.Text = string.Empty;
            }
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnSpeichern.Visibility = Visibility.Collapsed;
                CommandBarSave.Visibility = Visibility.Visible;
            }
            //MainPage.Margin = new Thickness(0, -70, 0, 0);
        }

        private void TxtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxWert.Text == string.Empty)
            {
                txtBoxWert.Text = 0.ToString("C", uNFI.GetNFI());
            }
            else
            {
                PositivNegtivWert();
            }
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnSpeichern.Visibility = Visibility.Visible;
                CommandBarSave.Visibility = Visibility.Collapsed;
            }
            //MainPage.Margin = new Thickness(0, -35, 0, 0);
        }

        //Stellt positive oder negative Wert
        private void PositivNegtivWert()
        {
            if (IndexComboBox == 0)
            {
                if (Double.TryParse(txtBoxWert.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI(), out double d))
                {
                    //Wenn User schon "-" eingegeben
                    if (d < 0)
                    {
                        txtBoxWert.Text = d.ToString("C", uNFI.GetNFI());
                    }
                    //Wenn User keine "-" eingegeben, geben zusaezlich ein Minus
                    else
                    {
                        d = d * -1;
                        txtBoxWert.Text = d.ToString("C", uNFI.GetNFI());
                    }
                }
            }
            else
            {
                if (Double.TryParse(txtBoxWert.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI(), out double d))
                {
                    txtBoxWert.Text = d.ToString("C", uNFI.GetNFI());
                }

            }
        }

        private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NumberFormatInfo localFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            //if americans or Shweiz, then ".", else ","
            if (localFormat.CurrencySymbol == "£" || localFormat.CurrencySymbol == "$" || localFormat.CurrencySymbol == "CHF")
            {
                txtBoxWert.Text = Regex.Replace(txtBoxWert.Text, @"(\d+(\.)\d{2})\d+", @"$1");
                txtBoxWert.Select(txtBoxWert.Text.Length, 0);
                //txtBoxWert.Text = Regex.Replace(txtBoxWert.Text, @"[-]", "");
                txtBoxWert.Text = Regex.Replace(txtBoxWert.Text, @"[,|\.]{2}", "");
            }
            else
            {
                txtBoxWert.Text = Regex.Replace(txtBoxWert.Text, @"(\d+(,)\d{2})\d+", @"$1");
                txtBoxWert.Select(txtBoxWert.Text.Length, 0);
                //txtBoxWert.Text = Regex.Replace(txtBoxWert.Text, @"[-]", "");
                txtBoxWert.Text = Regex.Replace(txtBoxWert.Text, @"[,|\.]{2}", "");
            }
        }

        private async void BtnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            var _homeWithDaten = new MonatYearDaten();

            #region SQLite
            switch (IndexComboBox)
            {
                case 0:
                    #region Costs
                    PositivNegtivWert();
                    try
                    {
                        if (string.IsNullOrWhiteSpace(txtBoxName.Text) || string.IsNullOrWhiteSpace(txtBoxWert.Text))
                        {
                            if (string.IsNullOrWhiteSpace(txtBoxName.Text))
                            {
                                txtBoxName.Focus(FocusState.Programmatic);
                            }
                            else
                            {
                                txtBoxWert.Focus(FocusState.Programmatic);
                            }
                        }
                        else
                        {
                            if (decimal.TryParse(txtBoxWert.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI(), out decimal preis))
                            {
                                using (dataBase)
                                {
                                    var cost = new Store.DataBase.DataBaseEF.Cost
                                    {
                                        CategoryOfCost = CategoryName,
                                        CategoryUnderOfCost = UnderCategoryName,
                                        NameOfCost = txtBoxName.Text,
                                        PreisOfCost = txtBoxWert.Text,
                                        DateOfCost = datePicker.Date.DateTime,
                                        CostsOrIncomes = CostsOrIncomesIndex.Cost.ToString()
                                    };
                                    dataBase.Costs.Add(cost);
                                    dataBase.SaveChanges();
                                }
                            }
                            else
                            {
                                //priceTxBxAdd.Text = string.Empty;
                                //DatenUpdateSourсe();
                                //priceTxBxAdd.Focus();
                                //lblError.Content = "Fehler! Sie haben wahrscheinlich Buchstaben eingeben";
                            }
                        }

                    }
#pragma warning disable CS0168 // Die Variable "em" ist deklariert, wird aber nie verwendet.
                    catch (Exception em)
#pragma warning restore CS0168 // Die Variable "em" ist deklariert, wird aber nie verwendet.
                    {
                        var dialog = new Windows.UI.Popups.MessageDialog(
                                        "Aliquam laoreet magna sit amet mauris iaculis ornare. " +
                                        "Morbi iaculis augue vel elementum volutpat.",
                                        "Lorem Ipsum");

                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 0 });
                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 1 });

                        if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
                        {
                            // Adding a 3rd command will crash the app when running on Mobile !!!
                            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Maybe later") { Id = 2 });
                        }

                        dialog.DefaultCommandIndex = 0;
                        dialog.CancelCommandIndex = 1;

                        var result = dialog.ShowAsync();

                        //var btn = sender as Button;
                        //btn.Content = $"Result: {result.Label} ({result.Id})";

                    }
                    await _homeWithDaten.CostIncomeSummeAsync();
                    await _homeWithDaten.BalanceForYearAsync();

                    if (this.Frame != null && this.Frame.CanGoBack)
                    {
                        this.Frame.GoBack();
                    }
                    if (this.Frame != null && this.Frame.CanGoBack)
                    {
                        this.Frame.GoBack();
                    }
                    if (this.Frame != null && this.Frame.CanGoBack)
                    {
                        this.Frame.GoBack();
                    }
                    #endregion
                    break;
                case 1:
                    #region Incomes
                    PositivNegtivWert();
                    try
                    {
                        if (string.IsNullOrWhiteSpace(txtBoxName.Text) || string.IsNullOrWhiteSpace(txtBoxWert.Text))
                        {
                            if (string.IsNullOrWhiteSpace(txtBoxName.Text))
                            {
                                txtBoxName.Focus(FocusState.Programmatic);
                            }
                            else
                            {
                                txtBoxWert.Focus(FocusState.Programmatic);
                            }
                        }
                        else
                        {
                            if (decimal.TryParse(txtBoxWert.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, uNFI.GetNFI(), out decimal preis))
                            {
                                using (dataBase)
                                {
                                    var income = new Store.DataBase.DataBaseEF.Income
                                    {
                                        CategoryOfIncome = CategoryName,
                                        CategoryUnderOfIncome = UnderCategoryName,
                                        NameOfIncome = txtBoxName.Text,
                                        PreisOfIncome = txtBoxWert.Text,
                                        DateOfIncome = datePicker.Date.DateTime,
                                        CostsOrIncomes = CostsOrIncomesIndex.Income.ToString()
                                    };
                                    dataBase.Incomes.Add(income);
                                    dataBase.SaveChanges();
                                }
                            }
                            else
                            {
                                //priceTxBxAdd.Text = string.Empty;
                                //DatenUpdateSourсe();
                                //priceTxBxAdd.Focus();
                                //lblError.Content = "Fehler! Sie haben wahrscheinlich Buchstaben eingeben";
                            }
                        }
                    }
#pragma warning disable CS0168 // Die Variable "em" ist deklariert, wird aber nie verwendet.
                    catch (Exception em)
#pragma warning restore CS0168 // Die Variable "em" ist deklariert, wird aber nie verwendet.
                    {
                        var dialog = new Windows.UI.Popups.MessageDialog(
                                        "Aliquam laoreet magna sit amet mauris iaculis ornare. " +
                                        "Morbi iaculis augue vel elementum volutpat.",
                                        "Lorem Ipsum");

                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 0 });
                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 1 });

                        if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
                        {
                            // Adding a 3rd command will crash the app when running on Mobile !!!
                            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Maybe later") { Id = 2 });
                        }

                        dialog.DefaultCommandIndex = 0;
                        dialog.CancelCommandIndex = 1;

                        var result = dialog.ShowAsync();

                        //var btn = sender as Button;
                        //btn.Content = $"Result: {result.Label} ({result.Id})";

                    }
                    await _homeWithDaten.CostIncomeSummeAsync();
                    await _homeWithDaten.BalanceForYearAsync();

                    if (this.Frame != null && this.Frame.CanGoBack)
                    {
                        this.Frame.GoBack();
                    }
                    if (this.Frame != null && this.Frame.CanGoBack)
                    {
                        this.Frame.GoBack();
                    }
                    #endregion

                    break;
                default:
                    break;
            }
            #endregion

        }

        private void txtBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnSpeichern.Visibility = Visibility.Collapsed;
                CommandBarSave.Visibility = Visibility.Visible;
            }
            //MainPage.Margin = new Thickness(0, -70, 0, 0);
        }

        private void txtBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Extensions.DeviceFamilyStringExtensions.ToDeviceFamily(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily) == Models.DeviceFamily.Mobile)
            {
                btnSpeichern.Visibility = Visibility.Visible;
                CommandBarSave.Visibility = Visibility.Collapsed;
            }
            //MainPage.Margin = new Thickness(0, -35, 0, 0);
        }
    }
}
