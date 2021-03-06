﻿#pragma checksum "C:\Users\Denis\Documents\Visual Studio 2015\Projects\BalanceSheet\BalanceSheet\Views\Mobile\Statistik_Mobile.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6FBEDCA3130C36C62F92421FE32CFDDB"
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
    partial class Statistik_Mobile : 
        global::Windows.UI.Xaml.Controls.Page, 
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

        private class Statistik_Mobile_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IStatistik_Mobile_Bindings
        {
            private global::BalanceSheet.Views.Mobile.Statistik_Mobile dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::BalanceSheet.Controls.UserControlHeader obj9;

            private Statistik_Mobile_obj1_BindingsTracking bindingsTracking;

            public Statistik_Mobile_obj1_Bindings()
            {
                this.bindingsTracking = new Statistik_Mobile_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 9:
                        this.obj9 = (global::BalanceSheet.Controls.UserControlHeader)target;
                        break;
                    default:
                        break;
                }
            }

            // IStatistik_Mobile_Bindings

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

            // Statistik_Mobile_obj1_Bindings

            public void SetDataRoot(global::BalanceSheet.Views.Mobile.Statistik_Mobile newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::BalanceSheet.Views.Mobile.Statistik_Mobile obj, int phase)
            {
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
                    XamlBindingSetters.Set_BalanceSheet_Controls_UserControlHeader_BalanceWert(this.obj9, obj.ToString(), null);
                }
            }

            private class Statistik_Mobile_obj1_BindingsTracking
            {
                global::System.WeakReference<Statistik_Mobile_obj1_Bindings> WeakRefToBindingObj; 

                public Statistik_Mobile_obj1_BindingsTracking(Statistik_Mobile_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<Statistik_Mobile_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_datenViewModel(null);
                }

                public void PropertyChanged_datenViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    Statistik_Mobile_obj1_Bindings bindings;
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
            case 2:
                {
                    this.pivotMain = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                    #line 22 "..\..\..\..\Views\Mobile\Statistik_Mobile.xaml"
                    ((global::Windows.UI.Xaml.Controls.Pivot)this.pivotMain).SelectionChanged += this.pivotMain_SelectionChanged;
                    #line default
                }
                break;
            case 3:
                {
                    this.pivotFixKosten = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 4:
                {
                    this.pivotLebensmittel = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 5:
                {
                    this.pivotAuto = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 6:
                {
                    this.pivotUnterhaltung = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 7:
                {
                    this.pivotVerkehr = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 8:
                {
                    this.pivotPersonal = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
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
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    Statistik_Mobile_obj1_Bindings bindings = new Statistik_Mobile_obj1_Bindings();
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

