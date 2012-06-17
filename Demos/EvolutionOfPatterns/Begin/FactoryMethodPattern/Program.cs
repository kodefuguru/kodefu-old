namespace FactoryMethodPattern
{
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main(string[] args)
        {
            var pair = new KeyValuePair<int, string>(1, "Value");
            Console.WriteLine(pair);
        }
    }
}
