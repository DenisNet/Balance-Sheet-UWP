
namespace BalanceSheet.ServiceEnvironment
{
    /// <summary>
    /// The service environment that points to the production service.
    /// </summary>
    public class ServiceEnvironment : ServiceEnvironmentBase
    {
        private const string AzureAppServiceBaseUrl = "https://[Your Prod Azure App Service].azurewebsites.net/";

        public override string ServiceBaseUrl
        {
            get
            {
                return AzureAppServiceBaseUrl;
            }
        }
    }
}