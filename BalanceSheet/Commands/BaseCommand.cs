using System;

namespace BalanceSheet.Commands
{
    public class BaseCommand
    {
        private readonly Func<bool> canExecute;
        protected BaseCommand(Func<bool> can)
        {
            canExecute = can;
        }

        public bool CanExecute(object parametr)
        {
            return canExecute == null || canExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}