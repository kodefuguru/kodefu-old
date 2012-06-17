namespace CustomQueryExpressions
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            Func<int, double> squareRoot = x => Math.Sqrt(x);
            Func<int, int, double> hypotenuse = (h, w) => squareRoot(square(h) + square(w));

            int height = 3;
            int width = 4;

            Console.WriteLine("Height: " + height);
            Console.WriteLine("Width: " + width);
            Console.WriteLine("Hypoteneuse: " + hypotenuse(height, width));
        }
    }
}
