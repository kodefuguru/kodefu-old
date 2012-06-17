namespace StrategyPattern
{
    using System;
    
    class StrategyA : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("Called Strategy A");
        }
    }
}
