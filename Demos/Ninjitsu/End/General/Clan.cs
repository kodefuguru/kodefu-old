namespace Ninjas
{
    using System.Collections.Generic;
    using System;

    public class Clan
    {
        List<Ninja> ninjas = new List<Ninja>();

        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<Ninja> Ninjas
        {
            get
            {
                return ninjas;
            }
        }

        public void AddNinja(Ninja ninja)
        {
            if (ninjas.Count > 4)
            {
                throw new Exception("The clan cannot hold more ninjas.");
            }

            ninjas.Add(ninja);
        }
    }
}
