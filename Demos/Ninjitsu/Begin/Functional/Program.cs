namespace Functional
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    class Program
    {
        static void Main(string[] args)
        {
            string s = null;
            Console.WriteLine(String.IsNullOrEmpty(s));
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
