using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Globalization;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using BalanceSheet.Lifecycle;
using BalanceSheet.Facades;
using BalanceSheet.Unity;
using BalanceSheet.Views;
using Microsoft.EntityFrameworkCore;
using BalanceSheet.Models;
using BalanceSheet.Controls.Chart;

namespace BalanceSheet
{
    /// <summary>
    /// Default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();

            // Register for events
            Suspending += OnSuspending;
            UnhandledException += OnUnhandledException;

            #region First Run the App, create the SQLite Data Base ??????

            //var optionsBuilder = new DbContextOptionsBuilder<Store.DataBase.DataBaseEF.DataBaseFile>();
            //optionsBuilder.UseSqlite("Filename=Balance.db");
            //if DataBase not exist dann weiter
            bool x = CheckDataBase().Result;
            if (CheckDataBase().Result == false)
            {
                using (var db = new Store.DataBase.DataBaseEF.DataBaseFile())
                {
                    db.Database.MigrateAsync();
                }
            }
            #endregion

        }

        private async Task<bool> CheckDataBase()
        {
            bool dbExist = true;
            try
            {
                Windows.Storage.StorageFile sf = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("Balance.db");
            }
            catch (Exception)
            {
                dbExist = false;
            }
            return dbExist;
        }

        /// <summary>
        /// Initialize the App launch.
        /// </summary>
        /// <returns>The AppShell of the app.</returns>
        private async Task<AppShell> Initialize()
        {
            var shell = Window.Current.Content as AppShell;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (shell == null)
            {
                UnityBootstrapper.Init();
                UnityBootstrapper.ConfigureRegistries();

                await AppInitialization.DoInitialization();

                // Create a AppShell to act as the navigation context and navigate to the first page
                shell = new AppShell()
                {
                    // Set the default language
                    Language = ApplicationLanguages.Languages[0]
                };
                shell.AppFrame.NavigationFailed += OnNavigationFailed;
            }
            return shell;
        }

        /// <summary>
        /// Invoked when the application is activated by some means other than normal launching.
        /// </summary>
        /// <param name="args">Event data for the event.</param>
        protected override async void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);

            var shell = Window.Current.Content as AppShell;

            // Check if the application needs to be initialized.
            if (shell == null)
            {
                shell = await Initialize();
            }

            // Place our app shell in the current Window
            Window.Current.Content = shell;

            //GoldReceivedNotificationClickedHandler(args);
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            // Enable the tile queue on the primary tile (enables medium/wide/large tile queues)
            TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueue(true);
            BadgeUpdateManager.CreateBadgeUpdaterForApplication();

            //var applicationMergedDics = Application.Current.Resources.MergedDictionaries;
            //applicationMergedDics[0].MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("ms-appx:///Styles/Styles.xaml") });

            //rootFrame.Navigate(typeof(MainPage), e.Arguments);

            //holen Einnahmen und Ausgaben aus SQLite
            var homeWithDaten = new MonatYearDaten(DateTime.Today.Month, DateTime.Today.Year);
            await homeWithDaten.CostIncomeSummeAsync();
            await homeWithDaten.BalanceForYearAsync();

            ChartsModelDaten charts = new ChartsModelDaten();

            var shell = await Initialize();

            // Place our app shell in the current Window
            Window.Current.Content = shell;

            if (shell.AppFrame.Content == null)
            {
                var facade = ServiceLocator.Current.GetInstance<INavigationFacade>();
                if (AppLaunchCounter.IsFirstLaunch())
                {
                    facade.NavigateToWelcomeView();
                }
                else
                {
                    facade.NavigateToHomeView();
                }
            }

            // Refresh launch counter, needs to be done
            // after AppLaunchCounter.IsFirstLaunch() is being checked.
            AppLaunchCounter.RegisterLaunch();

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }

        /// <summary>
        /// Invoked when the app runs into an unhandled exception. Telemetry logs the
        /// unhandled exception and appropriate message is displayed to the user experiencing
        /// the exception.
        /// </summary>
        /// <param name="sender">The source of the unhandled exception.</param>
        /// <param name="e">Details about the unhandled exception event.</param>
        private async void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            var resourceLoader = ResourceLoader.GetForCurrentView();
            var dialog = new MessageDialog(resourceLoader.GetString("UnexpectedError_Message"),
                resourceLoader.GetString("UnexpectedError_Title"));

            await dialog.ShowAsync();
        }
    }
}