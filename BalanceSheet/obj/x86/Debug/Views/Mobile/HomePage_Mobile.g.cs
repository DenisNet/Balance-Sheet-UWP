﻿#pragma checksum "C:\Users\Denis\Documents\Visual Studio 2015\Projects\BalanceSheet\BalanceSheet\Views\Mobile\HomePage_Mobile.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B7591BEB8013EEE1DABA2F6CF4ABBFB6"
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
    partial class HomePage_Mobile : 
        global::BalanceSheet.Views.BasePage, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_BalanceSheet_Controls_UserControlHeader_BalanceWert(global::BalanceSheet.Controls.UserControlHeader obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.BalanceWert = value ?? global::System.String.Empty;
            }
        };

        private class HomePage_Mobile_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IHomePage_Mobile_Bindings
        {
            private global::BalanceSheet.Views.HomePage_Mobile dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::BalanceSheet.Controls.UserControlHeader obj14;

            private HomePage_Mobile_obj1_BindingsTracking bindingsTracking;

            public HomePage_Mobile_obj1_Bindings()
            {
                this.bindingsTracking = new HomePage_Mobile_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 14:
                        this.obj14 = (global::BalanceSheet.Controls.UserControlHeader)target;
                        break;
                    default:
                        break;
                }
            }

            // IHomePage_Mobile_Bindings

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
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // HomePage_Mobile_obj1_Bindings

            public void SetDataRoot(global::BalanceSheet.Views.HomePage_Mobile newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::BalanceSheet.Views.HomePage_Mobile obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_datenViewModel(obj.datenViewModel, phase);
                    }
                }
            }
            private void Update_datenViewModel(global::BalanceSheet.Models.MonatYearDaten obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_datenViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_datenViewModel_BalanceForYearProperty(obj.BalanceForYearProperty, phase);
                    }
                }
            }
            private void Update_datenViewModel_BalanceForYearProperty(global::System.Decimal obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_BalanceSheet_Controls_UserControlHeader_BalanceWert(this.obj14, obj.ToString(), null);
                }
            }

            private class HomePage_Mobile_obj1_BindingsTracking
            {
                global::System.WeakReference<HomePage_Mobile_obj1_Bindings> WeakRefToBindingObj; 

                public HomePage_Mobile_obj1_BindingsTracking(HomePage_Mobile_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<HomePage_Mobile_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                    UpdateChildListeners_datenViewModel(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    HomePage_Mobile_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::BalanceSheet.Views.HomePage_Mobile obj = sender as global::BalanceSheet.Views.HomePage_Mobile;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_datenViewModel(obj.datenViewModel, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "datenViewModel":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_datenViewModel(obj.datenViewModel, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::BalanceSheet.Views.HomePage_Mobile obj)
                {
                    HomePage_Mobile_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        if (bindings.dataRoot != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
                        }
                    }
                }
                public void PropertyChanged_datenViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    HomePage_Mobile_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::BalanceSheet.Models.MonatYearDaten obj = sender as global::BalanceSheet.Models.MonatYearDaten;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_datenViewModel_BalanceForYearProperty(obj.BalanceForYearProperty, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "BalanceForYearProperty":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_datenViewModel_BalanceForYearProperty(obj.BalanceForYearProperty, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::BalanceSheet.Models.MonatYearDaten cache_datenViewModel = null;
                public void UpdateChildListeners_datenViewModel(global::BalanceSheet.Models.MonatYearDaten obj)
                {
                    if (obj != cache_datenViewModel)
                    {
                        if (cache_datenViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_datenViewModel).PropertyChanged -= PropertyChanged_datenViewModel;
                            cache_datenViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_datenViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_datenViewModel;
                        }
                    }
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
                    this.pageRoot = (global::BalanceSheet.Views.BasePage)(target);
                }
                break;
            case 2:
                {
                    this.PieChart = (global::BalanceSheet.Controls.Chart.ChartsModelDaten)(target);
                }
                break;
            case 3:
                {
                    this.txtCostText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.txtAusgabe = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.txtIncomeText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.txtEinnahme = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.txtBalanceText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.txtBalance = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 58 "..\..\..\..\Views\Mobile\HomePage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.BtnAusgbe_Click;
                    #line default
                }
                break;
            case 10:
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 71 "..\..\..\..\Views\Mobile\HomePage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.BtnEinnahme_Click;
                    #line default
                }
                break;
            case 11:
                {
                    this.BtnTxtEinnahme = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.BtnTxtAusgbe = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.BtnMonatAuswahl = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 41 "..\..\..\..\Views\Mobile\HomePage_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtnMonatAuswahl).Click += this.BtnMonatAuswahl_Click;
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
            switch(connectionId)
            {
            case 1:
                {
                    global::BalanceSheet.Views.BasePage element1 = (global::BalanceSheet.Views.BasePage)target;
                    HomePage_Mobile_obj1_Bindings bindings = new HomePage_Mobile_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

