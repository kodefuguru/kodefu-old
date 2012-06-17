namespace StrategyPattern
{
    using System;

    class StrategyB : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("Called Strategy B");
        }
    }
}