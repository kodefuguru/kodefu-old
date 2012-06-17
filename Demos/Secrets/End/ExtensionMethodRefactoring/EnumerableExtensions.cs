namespace Ninjas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> With<T>(this IEnumerable<T> source, T item)
        {
            foreach (T t in source)
            {
                yield return t;
            }

            yield return item;
        }
    }
}
