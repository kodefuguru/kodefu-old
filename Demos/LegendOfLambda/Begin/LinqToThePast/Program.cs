namespace LinqToThePast
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void Main(string[] args)
        {
            //writeMessage("Hello World");
        }
    }

    public delegate void StringFunc(string message);
}
