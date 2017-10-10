using System;
using System.Reflection;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using BalanceSheet.Commands;
using BalanceSheet.Extensions;
using BalanceSheet.Models;
using BalanceSheet.Services;
using BalanceSheet.Views;
using BalanceSheet.Facades;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;
using System.Linq;

namespace BalanceSheet.ViewModels
{
    /// <summary>
    /// The ViewModel for help view.
    /// </summary>
    class HelpViewModel : ViewModelBase
    {
        private readonly INavigationFacade _navigationFacade;

        private InstructionItem _selectedInstructionItem;


        /// <summary>
        /// The instructional items.
        /// </summary>
        public IList<InstructionItem> InstructionItems { get; private set; }

        /// <summary>
        /// Gets the navigate to target page command.
        /// </summary>
        public RelayCommand<InstructionItem> NavigateToTargetPageCommand { get; }

        public HelpViewModel(INavigationFacade navigationFacade)
        {
            _navigationFacade = navigationFacade;

            InitializeInstructionItems();
        }

        /// <summary>
        /// Gets or sets the current instructional item.
        /// </summary>
        public InstructionItem SelectedInstructionItem
        {
            get { return _selectedInstructionItem; }
            set
            {
                if (value != _selectedInstructionItem)
                {
                    _selectedInstructionItem = value;
                    NotifyPropertyChanged(nameof(SelectedInstructionItem));
                }
            }
        }


        private void InitializeInstructionItems()
        {
            InstructionItems = new List<InstructionItem>();

            var resourceLoader = ResourceLoader.GetForCurrentView();


            var appName = ResourceLoader.GetForCurrentView().GetString("AppName/Text");

            InstructionItems.Add(new InstructionItem(
                resourceLoader.GetString("WelcomePage_Instruction1_Title"),
                string.Format(resourceLoader.GetString("WelcomePage_Instruction1_Content"), appName),
                new Uri("ms-appx:///Assets/Help/Logo.png")));


            InstructionItems.Add(new InstructionItem(
                resourceLoader.GetString("WelcomePage_Instruction3_Title"),
                resourceLoader.GetString("WelcomePage_Instruction3_Content"),
                new Uri("ms-appx:///Assets/Help/Easy.png")));

            InstructionItems.Add(new InstructionItem(
                resourceLoader.GetString("WelcomePage_Instruction2_Title"),
                resourceLoader.GetString("WelcomePage_Instruction2_Content"),
                new Uri("ms-appx:///Assets/Help/Explore.png")));

            InstructionItems.Add(new InstructionItem(
                resourceLoader.GetString("Report"),
                resourceLoader.GetString("HelpPage_Instruction1_Content"),
                new Uri("ms-appx:///Assets/Help/Statistik.png")));

            InstructionItems.Add(new InstructionItem(
                resourceLoader.GetString("Statistics"),
                resourceLoader.GetString("HelpPage_Instruction2_Content"),
                new Uri("ms-appx:///Assets/Help/Diagramm.png")));

        }


        /// <summary>
        /// Loads the state.
        /// </summary>
        public override async Task LoadState()
        {
            await base.LoadState();

            SelectedInstructionItem = null;
            SelectedInstructionItem = InstructionItems.FirstOrDefault();
        }
    }
}