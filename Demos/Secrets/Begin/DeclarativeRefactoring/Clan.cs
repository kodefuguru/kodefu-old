namespace Ninjas
{
    using System.Collections.Generic;

    public class Clan
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<Ninja> Ninja { get; set; }
    }
}
