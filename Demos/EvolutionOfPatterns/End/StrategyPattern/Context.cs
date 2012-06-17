namespace StrategyPattern
{
    using System;

    class Context
    {
        public Action Strategy { get; private set; }

        public Context(Action action)
        {
            Strategy = action;
        }

        public void ContextInterface()
        {
            Strategy();
        }
    }

}