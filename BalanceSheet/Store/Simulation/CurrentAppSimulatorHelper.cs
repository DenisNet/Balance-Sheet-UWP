using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;

namespace BalanceSheet.Store.Simulation
{
    /// <summary>
    /// Helper class for <see cref="CurrentAppSimulatorHelper" />.
    /// </summary>
    public static class CurrentAppSimulatorHelper
    {
        /// <summary>
        /// Initializes the <see cref="CurrentAppSimulator"/> with sample data.
        /// </summary>
        public static async void InitCurrentAppSimulator()
        {
            var proxyDataFolder = await Package.Current.InstalledLocation.GetFolderAsync(@"Store\Simulation");
            var proxyFile = await proxyDataFolder.GetFileAsync("app-listing.xml");
            await CurrentAppSimulator.ReloadSimulatorAsync(proxyFile);
        }
    }
}