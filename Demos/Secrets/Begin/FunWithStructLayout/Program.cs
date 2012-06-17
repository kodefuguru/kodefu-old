using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunWithStructLayout
{
    class Program
    {
        static void Main(string[] args)
        {
            var union = new Union { Integer = 1 };
            Console.WriteLine(union.Byte);            
        }
    }
}
