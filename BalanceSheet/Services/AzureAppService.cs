using Microsoft.WindowsAzure.MobileServices;
using BalanceSheet.ServiceEnvironment;

namespace BalanceSheet.Services
{
    /// <summary>
    /// Provides access to the Azure App Service that
    /// offers authentication with 3rd party providers.
    /// </summary>
    public class AzureAppService
    {
        private static MobileServiceClient mobileServiceClient;
        public static MobileServiceClient Current
        {
            get
            {
                if (mobileServiceClient == null)
                {
                    mobileServiceClient = new MobileServiceClient(ServiceEnvironmentBase.Current.ServiceBaseUrl);
                }
                return mobileServiceClient;
            }
        }

        public static void Reset()
        {
            mobileServiceClient = null;
        }
    }
}