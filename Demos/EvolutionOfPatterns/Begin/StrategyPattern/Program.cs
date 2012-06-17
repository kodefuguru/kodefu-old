namespace StrategyPattern
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(new StrategyA());
            context.ContextInterface();
            context = new Context(new StrategyB());
            context.ContextInterface();
            context = new Context(new StrategyC());
            context.ContextInterface();            
        }
    }
}
