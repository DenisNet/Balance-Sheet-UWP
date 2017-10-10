using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace BalanceSheet.Commands
{
    public class RelayCommand<T> : BaseCommand, ICommand
    {
        private readonly Action<T> action;
        public RelayCommand(Action<T> act) : this(act, null)
        { }

        public RelayCommand(Action<T> act, Func<bool> can) : base(can)
        {
            if (act == null)
            {
                throw new ArgumentException(nameof(act));
            }
            action = act;
        }

        public void Execute(object parametr)
        {
            if (parametr is ItemClickEventArgs)
            {
                parametr = ((ItemClickEventArgs)parametr).ClickedItem;
            }
            if (parametr is T)
            {
                action((T)parametr);
            }
        }
    }

    public class RelayCommand : BaseCommand, ICommand
    {
        private readonly Action action;

        public RelayCommand(Action act)
            : this(act, null)
        {
        }

        public RelayCommand(Action act, Func<bool> canExecute)
            : base(canExecute)
        {
            if (act == null)
            {
                throw new ArgumentNullException(nameof(act));
            }

            action = act;
        }

        public void Execute(object parameter)
        {
            action();
        }

    }
}