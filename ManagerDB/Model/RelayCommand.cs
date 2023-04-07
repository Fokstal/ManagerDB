using System;
using System.Windows.Input;

namespace ManagerDB.Model
{
	public class RelayCommand : ICommand
	{
		private Action<object> execute;
		private Func<object, bool>? canExecute;

		public event EventHandler? CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object? parameter)
		{
			if (parameter is not null) return this.canExecute == null || this.canExecute(parameter);
			else return false;
		}

		public void Execute(object? parameter)
		{
			if (parameter is not null) this.execute(parameter);
		}
	}
}
