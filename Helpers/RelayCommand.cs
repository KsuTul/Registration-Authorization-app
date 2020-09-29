using System;
using System.Windows.Input;

namespace App.Helpers
{
    public class RelayCommand: ICommand
    {
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}
