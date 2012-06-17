namespace CurryingExample
{
    using System;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double, double> div = (x, y) => x / y;
            Func<double, Func<double, double>> curried = x => y => div(x, y);
            var inv = curried(1);
            Console.WriteLine(inv(4));
        }
    }
}
