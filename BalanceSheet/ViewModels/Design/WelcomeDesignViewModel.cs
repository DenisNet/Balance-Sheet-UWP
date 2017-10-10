using BalanceSheet.Models;
using BalanceSheet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace BalanceSheet.ViewModels.Design
{
    class WelcomeDesignViewModel
    {
        public WelcomeDesignViewModel()
        {
            var appName = ResourceLoader.GetForCurrentView().GetString("AppName/Text");

            InstructionItems = new List<InstructionItem>
            {
                new InstructionItem("Welcome",
                    $"{appName} allows you to keep your income and expenses under control.",
                    new Uri("ms-appx:///Assets/Welcome/Logo.png")),
                new InstructionItem("Ready?",
                    "That was easy, right? You should be ready to do your first entry in Balance Sheet.",
                    null,
                    null,
                    typeof(HomePage_Mobile))
            };

            SelectedInstructionItem = InstructionItems.First();
        }

        public IList<InstructionItem> InstructionItems { get; }

        public InstructionItem SelectedInstructionItem { get; set; }

    }
}
