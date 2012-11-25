namespace Kodefu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Sequence
    {
        public static IEnumerable<T> Materialize<T>(this IEnumerable<T> sequence)
        {
            return sequence.ToArray();
        }
    }
}
