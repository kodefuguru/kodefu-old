namespace RemoveOutParameters
{
    using System;
    using System.Diagnostics.Contracts;

    class Program
    {
        static void Main(string[] args)
        {
            var result = Div(7, 3, (q, r) => new { Quotient = q, Remainder = r });

            Console.WriteLine("Quotient: " + result.Quotient);
            Console.WriteLine("Remainder: " + result.Remainder);
        }

        //public static DivResult Div(int dividend, int divisor)
        //{
        //    Contract.Requires(divisor != 0);

        //    int quotient = dividend / divisor;
        //    int remainder = dividend % divisor;

        //    return new DivResult(quotient, remainder);
        //}

        //public static Tuple<int, int> Div(int dividend, int divisor)
        //{
        //    Contract.Requires(divisor != 0);

        //    int quotient = dividend / divisor;
        //    int remainder = dividend % divisor;

        //    return Tuple.Create(quotient, remainder);
        //}

        public static dynamic Div(int dividend, int divisor)
        {
            Contract.Requires(divisor != 0);

            int quotient = dividend / divisor;
            int remainder = dividend % divisor;

            return new { Quotient = quotient, Remainder = remainder };
        }

        public static T Div<T>(int dividend, int divisor, Func<int, int, T> func)
        {
            Contract.Requires(divisor != 0);
            Contract.Requires(func != null);

            var quotient = dividend / divisor;
            var remainder = dividend % divisor;

            return func(quotient, remainder);
        }

        public static void Div(int dividend, int divisor, Action<int, int> action)
        {
            Contract.Requires(divisor != 0);
            Contract.Requires(action != null);

            var quotient = dividend / divisor;
            var remainder = dividend % divisor;

            action(quotient, remainder);
        }
    }
}