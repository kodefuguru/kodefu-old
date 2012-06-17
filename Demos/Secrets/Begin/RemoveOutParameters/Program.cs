namespace RemoveOutParameters
{
    using System;
    using System.Diagnostics.Contracts;
        
    class Program
    {
        static void Main(string[] args)
        {
            int quotient;
            int remainder;
            
            Div(7, 3, out quotient, out remainder);

            Console.WriteLine("Quotient: " + quotient);
            Console.WriteLine("Remainder: " + remainder);
        }

        public static void Div(int dividend, int divisor, out int quotient, out int remainder)
        {
            Contract.Requires(divisor != 0);

            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }
    }
}
