namespace Combinators
{
    using System;
    using System.Linq;

    public static class Program
    {
        private static void Main(string[] args)
        {
            Func<int, double> f = k => 4 * (Math.Pow(-1, k) / ((2.0 * k) + 1));
            var calculatePi = f.Sum();
            Console.WriteLine(calculatePi(20000));

            Func<double, double, double> div = (x, y) => x / y;
            var curried = div.Curry();
            var inv = curried(1);

            Console.WriteLine("div(2,4): " + div(2, 4));
            Console.WriteLine("curried(2)(4): " + curried(2)(4));
            Console.WriteLine("inv(4): " + inv(4));
        }
    }
}
