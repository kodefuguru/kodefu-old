namespace Functional
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Diagnostics.Contracts;
    
    class Program
    {
        static void Main(string[] args)
        {
            string s = null;
            Console.WriteLine(String.IsNullOrEmpty(s));
        }

        //static void Main(string[] args)
        //{
        //    var strings = new List<string> { "This", "is", };

        //    FindTheBug(strings);

        //    foreach (var s in strings)
        //    {
        //        Console.WriteLine(s);
        //    }
        //}

        static void FindTheBug(IList<string> strings)
        {
            Contract.Requires(strings != null);

            strings.Add("Buggy");
        }

        static void FileDemo()
        {
            var lines = File.ReadAllLines("file.txt");
            var reversed = lines.Select(l => String.Join(",",
                                            l.Split(',').Reverse()));
            File.WriteAllLines("file.txt", reversed);

        }
    }
}
