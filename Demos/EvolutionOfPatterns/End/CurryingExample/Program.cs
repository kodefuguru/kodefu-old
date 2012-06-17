namespace CurryingExample
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double, double> div = (x, y) => x / y;
            //Func<double, Func<double, double>> curried = x => y => div(x, y);
            var curried = div.Curry();            
            var inv = curried(1);
            Console.WriteLine(inv(4));
        }
    }

    static class Func
    {
        public static Func<T, Func<T2, TResult>> Curry<T, T2, TResult>(this Func<T, T2, TResult> func)
        {
            return a => b => func(a, b);
        }
    }
}
