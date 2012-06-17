namespace Ninjas
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            Ninja ninja = CreateNinja(0, null);
            WriteNakedNinjas();
        }

        static Ninja CreateNinja(int piratesKilled, Clothing? clothes)
        {
            return new Ninja
            {
                Name = "Sarutobi Sasuke",
                Weapons = new[]
                {
                    new Weapon(WeaponType.Katana),
                    new Weapon(WeaponType.Shuriken),
                    new Weapon(WeaponType.Bow)
                },
                PiratesKilled = piratesKilled < 1 ?
                    1 : piratesKilled,
                Clothes = clothes ?? Clothing.Shozoku
            };
        }


        static void WriteNakedNinjas()
        {
            var nakedNinjas = Ninjas().Where(n => !n.Clothes.HasValue);

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
