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
            FileDemo();
        }

        static void FileDemo()
        {
            File.ReadAllLines("file.txt")
                .DelimitedReverse()
                .Write("file.txt");
        }
    }
}
