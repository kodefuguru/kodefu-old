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

        public static IEnumerable<T> Difference<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.Except(right).Union(right.Except(left));
        }
    }
}
