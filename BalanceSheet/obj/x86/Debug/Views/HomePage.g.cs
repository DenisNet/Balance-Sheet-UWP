﻿#pragma checksum "C:\Users\Denis\Documents\Visual Studio 2015\Projects\BalanceSheet\BalanceSheet\Views\HomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F37195333B9A8A0F761249D0E4C61F63"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalanceSheet.Views
{
    partial class HomePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        private class HomePage_obj3_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IHomePage_Bindings
        {
            private global::BalanceSheet.Models.ListBalance dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj4;
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;

            public HomePage_obj3_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::BalanceSheet.Models.ListBalance data = args.NewValue as global::BalanceSheet.Models.ListBalance;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::BalanceSheet.Models.ListBalance was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = 1;
                        this.SetDataRoot(args.Item as global::BalanceSheet.Models.ListBalance);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.Grid)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                    case 1:
                        Windows.UI.Xaml.Markup.XamlBindingHelper.ResumeRendering(this.obj5);
                        nextPhase = -1;
                        break;
                }
                this.Update_((global::BalanceSheet.Models.ListBalance) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Windows.UI.Xaml.Markup.XamlBindingHelper.SuspendRendering(this.obj5);
            }

            // IHomePage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // HomePage_obj3_Bindings

            public void SetDataRoot(global::BalanceSheet.Models.ListBalance newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::BalanceSheet.Models.ListBalance obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Preis(obj.Preis, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0) | (1 << 1))) != 0)
                    {
                        this.Update_Name(obj.Name, phase);
                    }
                }
            }
            private void Update_Preis(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj4, obj, null);
                }
            }
            private void Update_Name(global::System.String obj, int phase)
            {
                if((phase & ((1 << 1) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                }
            }
        }
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
                    this.NameFromRessourceFormatConverter = (global::BalanceSheet.ValueConverters.NameFromRessourceConverter)(target);
                }
                break;
            case 2:
                {
                    this.BalanceListViewTemplate = (global::Windows.UI.Xaml.DataTemplate)(target);
                }
                break;
            case 6:
                {
                    this.flipView = (global::Windows.UI.Xaml.Controls.FlipView)(target);
                }
                break;
            case 7:
                {
                    this.gridListView = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 8:
                {
                    this.flipViewList = (global::Windows.UI.Xaml.Controls.FlipView)(target);
                }
                break;
            case 9:
                {
                    this.BtnMonatAuswahl = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 99 "..\..\..\Views\HomePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtnMonatAuswahl).Click += this.MonatAuswahl_Click;
                    #line default
                }
                break;
            case 10:
                {
                    this.BtnAusgabe = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 101 "..\..\..\Views\HomePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtnAusgabe).Click += this.BtnAusgabe_Click;
                    #line default
                }
                break;
            case 11:
                {
                    this.BtnEinnahme = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 106 "..\..\..\Views\HomePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtnEinnahme).Click += this.BtnEinnahme_Click_1;
                    #line default
                }
                break;
            case 12:
                {
                    this.BtnTxtEinnahme = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.BtnTxtAusgbe = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            switch(connectionId)
            {
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Grid element3 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    HomePage_obj3_Bindings bindings = new HomePage_obj3_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::BalanceSheet.Models.ListBalance) element3.DataContext);
                    element3.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element3, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

