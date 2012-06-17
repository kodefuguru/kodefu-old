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
            var disguise = new Disguise
            {
                Person = new Person { FirstName = "Chris", LastName = "Eargle" }
            };

            Console.WriteLine("Ninja!!!\r\n");            
            Console.WriteLine("Given Name: " + disguise.Ninja.GivenName);
            Console.WriteLine("Family Name: " + disguise.Ninja.FamilyName);
            Console.WriteLine("Clan: " + disguise.Ninja.Clan);
            Console.WriteLine("Pirates Killed: " + disguise.Ninja.PiratesKilled);
        }
    }
}
