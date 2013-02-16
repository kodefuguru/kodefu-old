namespace Kodefu.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Collection
    {
        public static ICollection<T> Replace<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            collection.Clear();
            foreach (T item in items)
            {
                collection.Add(item);
            }
            return collection;
        }

        public static TCollection AddTo<T, TCollection>(this T item, TCollection collection)
            where TCollection : ICollection<T>
        {
            return collection.With(item);
        }

        public static T Put<T, TCollection>(this T item, TCollection collection)
            where TCollection : ICollection<T>
        {
            collection.Add(item);
            return item;
        }

        public static TCollection RemoveFrom<T, TCollection>(this T item, TCollection collection)
            where TCollection : ICollection<T>
        {
            return collection.Without(item);
        }

        public static TCollection With<T, TCollection>(this TCollection collection, T item)
            where TCollection : ICollection<T>
        {
            collection.Add(item);
            return collection;
        }

        public static TCollection Without<T, TCollection>(this TCollection collection, T item)
            where TCollection : ICollection<T>
        {
            collection.Remove(item);
            return collection;
        }
    }
}
