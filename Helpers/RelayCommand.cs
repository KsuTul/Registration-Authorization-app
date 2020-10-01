namespace WPF_APP.Helpers
{
    using System;
    using System.Windows.Input;

    public class RelayCommand: ICommand
    {
        private readonly Action<object> execute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
             return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
