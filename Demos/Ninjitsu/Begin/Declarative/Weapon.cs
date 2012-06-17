namespace Ninjas
{
    using System;

    public class Weapon
    {
        public string Name { get; set; }
        public WeaponType Type { get; set; }

        public Weapon(WeaponType type)
            : this(null, type)
        {
        }

        public Weapon(string name, WeaponType type)
        {
            if (String.IsNullOrEmpty(name))
            {
                name = type.ToString();
            }

            this.Name = name;
            this.Type = type;
        }
    }
}
