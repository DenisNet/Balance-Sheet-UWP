using System;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using BalanceSheet.Models;
using BalanceSheet.Services;

namespace BalanceSheet.Lifecycle
{
    public class AppInitialization
    {
        public static async Task DoInitialization()
        {
            var service = ServiceLocator.Current.GetInstance<IPhotoService>();

            try
            {
                await service.RestoreSignInStatusAsync();
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                var config = await service.GetConfig();
                AppEnvironment.Instance.SetConfig(config);
            }
            catch (Exception)
            {
                //AppEnvironment.Instance.SetConfig(new DefaultConfig());
            }

        }
    }
}