namespace Combinators
{
    using System;
    using System.Linq;

    public static class Program
    {                                                                           
        private static void Main(string[] args)
        {
            Func<int, double> f = k => 4 * (Math.Pow(-1, k) / ((2.0 * k) + 1));
            var g = f.Sum();
            Console.WriteLine(g(10000000));
        }
    }
}
