namespace CommandPattern
{
    using System;

    class DelegateCommand
    {
        private Action action;
        private Func<bool> predicate;

        public DelegateCommand(Action action) : this(action, () => true)
        {
        }

        public DelegateCommand(Action action, Func<bool> predicate)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public bool CanExecute()
        {
            return predicate();
        }

        public void Execute()
        {
            if (CanExecute())
            {
                action();
            }
        }
    }
}