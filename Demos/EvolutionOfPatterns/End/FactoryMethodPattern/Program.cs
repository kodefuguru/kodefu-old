namespace FactoryMethodPattern
{
    using System;

    partial class Program
    {
        static void Main(string[] args)
        {
            var pair = KeyValuePair.Create(1, "Value");
            Console.WriteLine(pair);
        }
    }
}
