namespace Kodefu.Windows
{
    using System;
    using System.Windows.Input;

    public class ViewCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public ViewCommand(Action<object> execute)
            : this(execute, p => true)
        {
        }

        public ViewCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
