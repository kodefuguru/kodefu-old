namespace Ninjas
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var strings = new List<string> { "This", "is", "a" }.AsEnumerable();
            var strings2 = strings.With("test");

            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }
        }
    }
}
