

namespace BalanceSheet.Models
{
    /// <summary>
    /// Defines the app environment
    /// </summary>
    public interface IAppEnvironment
    {
        /// <summary>
        /// Stores the current user that is logged in.
        /// </summary>
        User CurrentUser { get; set; }
    }
}
