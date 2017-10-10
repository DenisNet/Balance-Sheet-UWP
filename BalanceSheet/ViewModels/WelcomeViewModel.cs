using BalanceSheet.Commands;
using BalanceSheet.Extensions;
using BalanceSheet.Facades;
using BalanceSheet.Models;
using BalanceSheet.Services;
using BalanceSheet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Resources;

namespace BalanceSheet.ViewModels
{
    class WelcomeViewModel: ViewModelBase
    {
        private readonly INavigationFacade _navigationFacade;

        private InstructionItem _selectedInstructionItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomeViewModel"/> class.
        /// </summary>
        /// <param name="navigationFacade">The navigation facade.</param>
        public WelcomeViewModel(INavigationFacade navigationFacade)
        {
            _navigationFacade = navigationFacade;
            NavigateToTargetPageCommand = new RelayCommand<InstructionItem>(OnNavigateToTargetPage);
           

            InitializeInstructionItems();
        }

        /// <summary>
        /// The instructional items.
        /// </summary>
        public IList<InstructionItem> InstructionItems { get; private set; }

        /// <summary>
        /// Gets the navigate to target page command.
        /// </summary>
        public RelayCommand<InstructionItem> NavigateToTargetPageCommand { get; }

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
            var appName = ResourceLoader.GetForCurrentView().GetString("AppName/Text");
            var resourceLoader = ResourceLoader.GetForCurrentView();

            InstructionItems = new List<InstructionItem>
            {
                new InstructionItem(
                resourceLoader.GetString("WelcomePage_Instruction1_Title"),
                string.Format(resourceLoader.GetString("WelcomePage_Instruction1_Content"), appName),
                new Uri("ms-appx:///Assets/Welcome/Logo.png")),

                new InstructionItem(
                resourceLoader.GetString("WelcomePage_Instruction2_Title"),
                resourceLoader.GetString("WelcomePage_Instruction2_Content"),
                new Uri("ms-appx:///Assets/Welcome/Explore.png")),

                new InstructionItem(
                resourceLoader.GetString("WelcomePage_Instruction3_Title"),
                resourceLoader.GetString("WelcomePage_Instruction3_Content"),
                new Uri("ms-appx:///Assets/Welcome/Easy.png")),

                new InstructionItem(
                resourceLoader.GetString("WelcomePage_Instruction4_Title"),
                resourceLoader.GetString("WelcomePage_Instruction4_Content"),
                null,
                resourceLoader.GetString("WelcomePage_ButtonStart_Text"),
                typeof(HomePage_Mobile))
            };
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

        private void OnNavigateToTargetPage(InstructionItem instructionItem)
        {
            _navigationFacade.NavigateToHomeView();
        }
    }
}
