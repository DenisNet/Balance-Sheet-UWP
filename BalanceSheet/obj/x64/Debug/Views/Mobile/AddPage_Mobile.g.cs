﻿#pragma checksum "C:\Users\Denis\Documents\Visual Studio 2015\Projects\BalanceSheet\BalanceSheet\Views\Mobile\AddPage_Mobile.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8B30FB6C72DB5FCEF469D78A5E87DBD1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalanceSheet.Views.Mobile
{
    partial class AddPage_Mobile : 
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
                    this.gridListViewAusgaben = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6:
                {
                    this.fixKostenStack = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7:
                {
                    this.others = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 8:
                {
                    this.personKosten = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 249 "..\..\..\..\Views\Mobile\AddPage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.personKosten).Click += this.BtnPersonKosten_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.transport = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 235 "..\..\..\..\Views\Mobile\AddPage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.transport).Click += this.BtnTransport_Click;
                    #line default
                }
                break;
            case 10:
                {
                    this.allInHouse = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 11:
                {
                    this.unterhaltung = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 208 "..\..\..\..\Views\Mobile\AddPage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.unterhaltung).Click += this.BtnUnterhaltung_Click;
                    #line default
                }
                break;
            case 12:
                {
                    this.urlaub = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 13:
                {
                    this.softService = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 14:
                {
                    this.bildung = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 15:
                {
                    this.auto = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 149 "..\..\..\..\Views\Mobile\AddPage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.auto).Click += this.BtnAuto_Click;
                    #line default
                }
                break;
            case 16:
                {
                    this.food = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 133 "..\..\..\..\Views\Mobile\AddPage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.food).Click += this.BtnFood_Click;
                    #line default
                }
                break;
            case 17:
                {
                    this.fixKosten = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 118 "..\..\..\..\Views\Mobile\AddPage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.fixKosten).Click += this.BtnFixKosten_Click;
                    #line default
                }
                break;
            case 18:
                {
                    this.comboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 86 "..\..\..\..\Views\Mobile\AddPage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.comboBox).DropDownClosed += this.ComboBox_DropDownClosed;
                    #line 86 "..\..\..\..\Views\Mobile\AddPage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.comboBox).DropDownOpened += this.ComboBox_DropDownOpened;
                    #line default
                }
                break;
            case 19:
                {
                    this.btnAbbrechen = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 83 "..\..\..\..\Views\Mobile\AddPage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAbbrechen).Click += this.BtnBack_Click;
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

