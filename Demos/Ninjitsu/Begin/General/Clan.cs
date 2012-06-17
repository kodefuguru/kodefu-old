namespace Ninjas
{
    using System.Collections.Generic;
    using System;

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
    }
}
