using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrivateMemberInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var ninja = Turtle.CreateNinja();
            Console.WriteLine(ninja.Steal());
        }

        public class Turtle
        {
            private string secretMessage = "The answer is 42";

            public static Ninja CreateNinja()
            {
                return new Ninja();
            }
        }

        public class Ninja : Turtle
        {
            public string Steal()
            {
                // Do it with the this. keyword.
                return default(string);
            }
        }
    }
}
