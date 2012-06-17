namespace Ninjas
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    
    public class Program
    {
        static void Main(string[] args)
        {
            
        }

        static Ninja CreateNinja(int piratesKilled, Clothing? clothes)
        {
            Ninja ninja = new Ninja();
            ninja.Name = "Sarutobi Sasuke";
            Weapon katana = new Weapon(WeaponType.Katana);
            Weapon shuriken = new Weapon(WeaponType.Shuriken);
            Weapon bow = new Weapon(WeaponType.Bow);
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(katana);
            weapons.Add(shuriken);
            weapons.Add(bow);
            ninja.Weapons = weapons;

            if (piratesKilled < 1)
            {
                ninja.PiratesKilled = 1;
            }
            else
            {
                ninja.PiratesKilled = piratesKilled;
            }

            if (clothes.HasValue)
            {
                ninja.Clothes = clothes.Value;
            }
            else
            {
                ninja.Clothes = Clothing.Shozoku;
            }

            return ninja;
        }
       
        static void WriteNakedNinjas()
        {
            List<Ninja> nakedNinjas = new List<Ninja>();
            foreach (Ninja ninja in Ninjas())
            {
                if (!ninja.Clothes.HasValue)
                {
                    nakedNinjas.Add(ninja);
                }
            }
            foreach (Ninja ninja in nakedNinjas)
            {
                Console.WriteLine(ninja.Name);
            }
        }

        static IEnumerable<Ninja> Ninjas()
        {
            return new[]
            {
                new Ninja
                {
                    Name = "Ninja 1",
                    Clothes = Clothing.Shozoku
                },
                new Ninja
                {
                    Name = "Ninja 2",
                    Clothes = Clothing.Shozoku
                },
                new Ninja
                {
                    Name = "Naked Ninja 1",
                    Clothes = null
                },
                new Ninja
                {
                    Name = "Naked Ninja 2",
                    Clothes = null
                }
            };
        }
    }
}
