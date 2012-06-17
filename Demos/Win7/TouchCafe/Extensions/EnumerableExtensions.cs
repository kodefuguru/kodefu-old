using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace TouchCafe
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Selectable<T>> ToSelectable<T>(this IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                yield return Selectable.Create(item);
            }
        }

        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> source)
        {
            var collection = new ObservableCollection<T>();

            foreach (T item in source)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
