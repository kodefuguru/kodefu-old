namespace StrategyPattern
{
    using System;

    class StrategyC : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("Called Strategy C");
        }
    }
}