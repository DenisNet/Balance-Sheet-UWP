
namespace BalanceSheet.ServiceEnvironment
{
    public abstract class ServiceEnvironmentBase
    {
        private static ServiceEnvironmentBase current;

        public static ServiceEnvironmentBase Current
        {
            get { return current ?? Default; }
            set { current = value; }
        }

        public static ServiceEnvironmentBase Default
        {
            get
            {
                return new ServiceEnvironment();
            }
        }

        public abstract string ServiceBaseUrl { get; }
    }
}