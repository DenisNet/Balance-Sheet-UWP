﻿#pragma checksum "C:\Users\Denis\Documents\Visual Studio 2015\Projects\BalanceSheet\BalanceSheet\Views\Mobile\CostsIncomes\Incomes.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4FAC2B6AA9ED87CBC869E4AE3125D446"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalanceSheet.Views.Mobile.CostsIncomes
{
    partial class Incomes : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.gridMain = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3:
                {
                    this.grid1 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4:
                {
                    this.gridListView = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5:
                {
                    this.gridListViewEinkommen = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6:
                {
                    this.fixKostenStack = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7:
                {
                    this.btnOthersIncome = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 133 "..\..\..\..\..\Views\Mobile\CostsIncomes\Incomes.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnOthersIncome).Click += this.btnOthersIncome_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.txtOthersIncome = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.btnGehalt = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 119 "..\..\..\..\..\Views\Mobile\CostsIncomes\Incomes.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnGehalt).Click += this.btnGehalt_Click;
                    #line default
                }
                break;
            case 10:
                {
                    this.txtGehalt = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.comboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 87 "..\..\..\..\..\Views\Mobile\CostsIncomes\Incomes.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.comboBox).DropDownClosed += this.comboBox_DropDownClosed;
                    #line 88 "..\..\..\..\..\Views\Mobile\CostsIncomes\Incomes.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.comboBox).DropDownOpened += this.comboBox_DropDownOpened;
                    #line default
                }
                break;
            case 12:
                {
                    this.btnAbbrechen = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 83 "..\..\..\..\..\Views\Mobile\CostsIncomes\Incomes.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAbbrechen).Click += this.btnAbbrechen_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

