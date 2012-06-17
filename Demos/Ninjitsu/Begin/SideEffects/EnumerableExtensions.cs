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
            var collection = source as ICollection<T> ?? source.ToList();

            if (collection.IsReadOnly)
            {
                collection = collection.ToList();
            }

            collection.Add(item);

            return collection;
        }
    }
}
