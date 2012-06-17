namespace Ninjas
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            Clan clan = new Clan { Name = "Super Ninja Clan" };
            clan.AddNinja(new Ninja { Name = "Ryu" });
            clan.AddNinja(new Ninja { Name = "Bo" });
            clan.AddNinja(new Ninja { Name = "Jyoto" });
            clan.AddNinja(new Ninja { Name = "Mote" });

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
