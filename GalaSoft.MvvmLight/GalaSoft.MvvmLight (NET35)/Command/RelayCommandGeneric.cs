using System;
using Cirrious.MvvmCross.Commands;

namespace GalaSoft.MvvmLight.Command
{
    public class RelayCommand<T> : MvxRelayCommand<T>
    {
        public RelayCommand(Action<T> execute)
            : base(execute)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
            : base(execute, canExecute)
        {
        }

        public bool CanExecuteEx
        {
            get { return CanExecute(null); }
        }
    }
}
