namespace StrategyPattern
{
    class Context
    {
        public IStrategy Strategy { get; private set; }

        public Context(IStrategy strategy)
        {
            Strategy = strategy;
        }

        public void ContextInterface()
        {
            Strategy.AlgorithmInterface();
        }
    }
}