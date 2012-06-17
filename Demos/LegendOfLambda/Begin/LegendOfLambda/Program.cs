namespace LegendOfLambda
{
    using System;
    using System.Linq;
    
    class Program
    {
        public static double Div(double x, double y)
        {
            return x / y;
        }

        public static double Inv(double y)
        {
            return Div(1, y);
        }

        static void Main(string[] args)
        {
            // arity
            // f x y... fx fy
            Func<double, double, double> div = (x, y) => x / y;
            //Func<double, double> inv = y => 1 / y;
            var curried = div.Curry();
            var inv = div.Apply(1.0);
            Console.WriteLine(curried(1)(4));

        }

       
    }

  

    public delegate double Operation(double x, double y);
}
