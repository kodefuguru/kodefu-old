namespace FluentContext
{
    using System;
    using System.Collections.Generic;

    public static class ReactiveExtensions
    {
        public static IEnumerable<T> Do<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
            {
                action(item);
                yield return item;
            }
        }
    }
}
