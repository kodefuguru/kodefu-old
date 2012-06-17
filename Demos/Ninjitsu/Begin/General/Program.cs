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
            clan.Ninjas.Add(new Ninja { Name = "Ryu" });
            clan.Ninjas.Add(new Ninja { Name = "Bo" });
            clan.Ninjas.Add(new Ninja { Name = "Jyoto" });
            clan.Ninjas.Add(new Ninja { Name = "Mote" });
            clan.Ninjas.Add(new Ninja { Name = "Pirate" });

            WriteNinjas(clan.Ninjas);
        }

        static void WriteNinjas(IList<Ninja> ninjas)
        {
            foreach (var ninja in ninjas)
            {
                Console.WriteLine(ninja.Name);
            }
        }
    }
}
