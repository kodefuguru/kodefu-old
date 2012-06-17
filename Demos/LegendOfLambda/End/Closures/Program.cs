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
            var s = new StringBuilder();
            for (var i = 4; i < 7; i++)
            {
                var j = i;
                contents.Add(() => j);
            }
            for (var k = 0; k < contents.Count; k++)
                s.Append(contents[k]());
            Console.WriteLine(s);
        }
    }
}
