using BalanceSheet.ComponentModel;
using System.Threading.Tasks;

namespace BalanceSheet.ViewModels
{

/// <summary>
/// Base class for ViewModels
/// </summary>
public abstract class ViewModelBase: ObservableObjectBase
    {
        /// <summary>
        /// Loads the state.
        /// </summary>
        public virtual Task LoadState()
        {
            return Task.CompletedTask;
        }
    }
}