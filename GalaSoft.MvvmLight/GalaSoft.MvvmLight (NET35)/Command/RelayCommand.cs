using System;
using Cirrious.MvvmCross.Commands;

namespace GalaSoft.MvvmLight.Command
{
	public class RelayCommand : MvxRelayCommand
	{
		public RelayCommand(Action execute) 
			: base(execute)
		{
		}

		public RelayCommand(Action execute, Func<bool> canExecute)
			: base(execute, canExecute)
		{   
		}

		public bool CanExecuteEx
		{
			get { return CanExecute(); }
		}
	}
}
