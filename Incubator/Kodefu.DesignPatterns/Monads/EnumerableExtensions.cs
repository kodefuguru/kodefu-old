//-----------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="Microsoft">
//     Copyright (c) KodefuGuru, Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Kodefu
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static IEnumerable<Selectable<T>> ToSelectable<T>(this IEnumerable<T> source)
        {
            foreach (T t in source)
            {
                yield return Selectable.Create(t);
            }
        }

        public static IEnumerable<Selectable<T>> ToSelectable<T>(this IEnumerable<T> source, bool selected)
        {
            foreach (T t in source)
            {
                yield return Selectable.Create(t, selected);
            }
        }

        public static IEnumerable<Indexed<T>> ToIndexed<T>(this IEnumerable<T> source)
        {
            int index = 0;

            foreach (T t in source)
            {
                yield return Indexed.Create(index, t);
                index++;
            }
        }

    }
}
