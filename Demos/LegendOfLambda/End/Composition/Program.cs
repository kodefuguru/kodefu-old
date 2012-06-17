namespace Composition
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //Func<double, double, double> div = (x, y) => x / y;
            //Func<double, double> inv = y => div(1, y);
            //Console.WriteLine("div(2,4): " + div(2, 4));
            //Console.WriteLine("inv(4): " + inv(4));

            Func<double, double, double> div = (x, y) => x / y;
            Func<double, Func<double, double>> curried = x => y => div(x, y);
            var inv = curried(1);
 
            Console.WriteLine("div(2,4): " + div(2, 4));
            Console.WriteLine("curried(2)(4): " + curried(2)(4));
            Console.WriteLine("inv(4): " + inv(4));

        }
    }
}
