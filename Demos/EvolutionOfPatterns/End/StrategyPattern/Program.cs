namespace StrategyPattern
{
    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(() => Console.WriteLine("Called Strategy A"));
            context.ContextInterface();
            context = new Context(() => Console.WriteLine("Called Strategy B"));
            context.ContextInterface();
            context = new Context(() => Console.WriteLine("Called Strategy C"));
            context.ContextInterface(); 
        }
    }
}
