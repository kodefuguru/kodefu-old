namespace Ninjas
{
    using System.Collections.Generic;

    public class Clan
    {
        List<Ninja> ninjas = new List<Ninja>();

        public string Name { get; set; }
        public string Location { get; set; }
        public IList<Ninja> Ninjas
        { 
            get
            {
                return ninjas;
            }
        }

        public Clan WithNinja(Ninja ninja)
        {
            this.ninjas.Add(ninja);

            return this;
        }

        public Clan WithNinjas(IList<Ninja> ninjas)
        {
            this.ninjas.AddRange(ninjas);

            return this;
        }
    }
}
