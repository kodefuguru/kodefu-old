namespace Ninjas
{
    using System.Collections.Generic;

    public class Ninja
    {
        List<Weapon> weapons;

        public string Name { get; set; }
        public int PiratesKilled{ get; set; }
        public List<Weapon> Weapons
        {
            get
            {
                if (weapons == null)
                {
                    weapons = new List<Weapon>();
                }

                return weapons;
            }
        }

        public Clothing? Clothes { get; set; }
    }
}
