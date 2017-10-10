
namespace BalanceSheet.Models
{
    /// <summary>
    /// Contains default config values which can be used
    /// in the case that the config cannot be load from the service.
    /// </summary>
    public class DefaultConfig : Config
    {
        public DefaultConfig() : base("1.0.0.0", 6, 16)
        {
        }
    }
}