namespace Kodefu
{
    using System;

    public static class Number
    {
        public static string FormatSeparated(this double num)
        {
            return String.Format("{0:n}", num);
        }

        public static string FormatSeparated(this float num)
        {
            return String.Format("{0:n}", num);
        }

        public static string FormatSeparated(this int num)
        {
            return String.Format("{0:n}", num);
        }

        private static readonly Random generator = new Random();

        public static int Random(int min, int max)
        {
            return generator.Next(min, max);
        }

        public static int Random(int min, double max)
        {
            return generator.Next(min, (int)max);
        }

        public static double SquareRoot(this int num)
        {
            return System.Math.Sqrt(num);
        }
    }
}
