using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using BalanceSheet.Commands;
using BalanceSheet.ComponentModel;
using BalanceSheet.Facades;
using BalanceSheet.Models;
using BalanceSheet.Services;
using BalanceSheet.Views;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;
using BalanceSheet.Controls.Chart;
using BalanceSheet.Controls;

namespace BalanceSheet.ViewModels
{
    /// <summary>
    /// The ViewModel for the home view.
    /// </summary>
    class HomeViewModel : ViewModelBase
    {
        private readonly INavigationFacade _navigationFacade;
        private ChartsModelDatenForHomePage _selectedPieChartItem;
        private UserListView _selectedListBalanceItem;
        MonatYearDaten datum;


        public HomeViewModel(INavigationFacade navigationFacade)
        {
            _navigationFacade = navigationFacade;
            datum = new MonatYearDaten();

            InitializePieChartItems();
            InitiolizeListItemsAsync();
        }

        /// <summary>
        /// The list von items.
        /// </summary>
        public IList<UserListView> ListBalanceItems { get; set; }

        /// <summary>
        /// Gets or sets the current ListViewItem.
        /// </summary>
        public UserListView SelectedListBalanceItem
        {
            get { return _selectedListBalanceItem; }
            set
            {
                if (value != _selectedListBalanceItem)
                {
                    _selectedListBalanceItem = value;
                    NotifyPropertyChanged(nameof(SelectedListBalanceItem));
                }
            }
        }

        private void InitiolizeListItemsAsync()
        {
            ListBalanceItems = new List<UserListView>
            {
                new UserListView() {ListViewDaten = CategoryCostIncomen.Cost},
                new UserListView() {ListViewDaten = CategoryCostIncomen.Incomen}
            };
        }

        /// <summary>
        /// The list von items.
        /// </summary>
        public IList<ChartsModelDatenForHomePage> ListPieChartItems { get; set; }

        /// <summary>
        /// Gets or sets the current PieChartItem.
        /// </summary>
        public ChartsModelDatenForHomePage SelectedPieChartItem
        {
            get { return _selectedPieChartItem; }
            set
            {
                if (value != _selectedPieChartItem)
                {
                    _selectedPieChartItem = value;
                    NotifyPropertyChanged(nameof(SelectedPieChartItem));
                }
            }
        }

        private void InitializePieChartItems()
        {
            ListPieChartItems = new List<ChartsModelDatenForHomePage>
            {
                new ChartsModelDatenForHomePage() { PieChartDaten = CategoryCostIncomen.Cost },
                new ChartsModelDatenForHomePage() { PieChartDaten = CategoryCostIncomen.Incomen}
            };
        }

        /// <summary>
        /// Loads the state.
        /// </summary>
        public override async Task LoadState()
        {
            await base.LoadState();
            SelectedPieChartItem = null;
            SelectedPieChartItem = ListPieChartItems.FirstOrDefault();
            SelectedListBalanceItem = null;
            SelectedListBalanceItem = ListBalanceItems.FirstOrDefault();
        }
    }

}