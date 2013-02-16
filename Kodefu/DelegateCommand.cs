namespace Kodefu
{
    using System;
    using System.Windows.Input;

    public sealed class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Func<bool> canExecute;
        private readonly Action executeAction;
        private bool canExecuteCache;

        public DelegateCommand(Action executeAction)
            : this(executeAction, () => true)
        {
        }

        public DelegateCommand(Action executeAction,
            Func<bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.CanExecute();
        }

        public bool CanExecute()
        {
            bool tempCanExecute = this.canExecute();

            if (this.canExecuteCache != tempCanExecute)
            {
                this.canExecuteCache = tempCanExecute;
                if (this.CanExecuteChanged != null)
                {
                    this.CanExecuteChanged(this, new EventArgs());
                }
            }

            return this.canExecuteCache;
        }

        public void Execute(object parameter)
        {
            this.executeAction();
        }

        public void Execute()
        {
            this.executeAction();
        }

        public static implicit operator Action(DelegateCommand command)
        {
            return command.Execute;
        }

        public static implicit operator Action<Object>(DelegateCommand command)
        {
            return a => command.Execute(a);
        }
    }
}