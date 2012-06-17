namespace Closures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Program
    {
        private static void Main(string[] args)
        {
            var contents = new List<Func<int>>();
            for (var i = 4; i < 7; i++)
            {
                int j = i;
                contents.Add(() => j);
            }
            for (var k = 0; k < contents.Count; k++)
                Console.WriteLine(contents[k]());
        }
    }
}
