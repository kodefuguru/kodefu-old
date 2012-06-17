namespace Ninjas
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            Clan clan = new Clan { Name = "Super Ninja Clan" }
                .WithNinja(new Ninja { Name = "Ryu" })                
                .WithNinja(new Ninja { Name = "Ryu" })
                .WithNinja(new Ninja { Name = "Bo" })
                .WithNinja(new Ninja { Name = "Jyoto" })
                .WithNinja(new Ninja { Name = "Mote" });

            WriteNinjas(clan.Ninjas);
        }

        static void WriteNinjas(IEnumerable<Ninja> ninjas)
        {
            foreach (var ninja in ninjas)
            {
                Console.WriteLine(ninja.Name);
            }
        }
    }
}
