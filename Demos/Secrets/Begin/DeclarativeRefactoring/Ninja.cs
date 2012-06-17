namespace Ninjas
{
    using System.Collections.Generic;

    public class Ninja
    {   
        public string Name { get; set; }
        public int PiratesKilled{ get; set; }
        public IEnumerable<Weapon> Weapons { get; set; }
        public Clothing? Clothes { get; set; }
    }
}
