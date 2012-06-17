namespace Ninjas
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using System.Diagnostics.Contracts;

    public class Program
    {
        static void Main(string[] args)
        {
            var strings = new List<string> { "This", "is", "a" };

            FindTheBug(strings);

            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }
        }

        static void FindTheBug(IList<string> strings)
        {
            Contract.Requires(strings != null);

            strings.Add("Fail");
        }
    }
}
