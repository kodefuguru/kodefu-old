namespace Kodefu.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class List
    {
        public static List<T> Create<T>(params T[] items)
        {
            return new List<T>(items);
        }

        public static List<T> Create<T>(IEnumerable<T> items)
        {
            return new List<T>(items);
        }
    }
}
