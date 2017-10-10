using Microsoft.Practices.Unity;

namespace BalanceSheet.Registries
{
    /// <summary>
    /// Base class for registering implementations to the Unity container.
    /// </summary>
    public class RegistryBase
    {
        protected IUnityContainer Container {get; set;}

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        protected RegistryBase(IUnityContainer container)
        {
            Container = container;
        }
    }
}