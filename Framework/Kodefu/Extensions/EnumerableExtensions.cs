namespace Kodefu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>
    /// Extensions for <see cref="IEnumerable&lt;T&gt;"/>
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Delimits the strings with the default delimited, a comma.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence with which to create a delimited string.</param>
        /// <returns>
        /// A comma-separated value <see cref="System.String"/>
        /// </returns>
        public static string Delimit<T>(this IEnumerable<T> source)
        {
            Contract.Requires(source != null);

            return source.Select(t => t.ToString()).Delimit();
        }

        /// <summary>
        /// Creates a delimited string from a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence with which to create a delimited string.</param>
        /// <param name="delimiter">The delimiter with which to separate the strings.</param>
        /// <returns>A <see cref="System.String"/> consisting of the elements of value interspersed with the separator string.</returns>
        public static string Delimit<T>(this IEnumerable<T> source, string delimiter)
        {
            Contract.Requires(source != null);

            return source.Select(t => t.ToString()).Delimit(delimiter);
        }

        /// <summary>
        /// Determines whether a sequence is empty.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/>to check for emptiness.</param>
        /// <returns>
        /// true if the source sequence is empty; otherwise, false.
        /// </returns>
        /// <remarks><para>This provides better readability than !source.Any().</para>
        /// <para>There already exists an Enumerable.Empty&lt;T&gt;, which is probably why it wasn't
        /// included in the .NET Framework. This method exists in a class called EnumerableExtensions,
        /// so there should not be any conflict.</para></remarks>
        public static bool Empty<T>(this IEnumerable<T> source)
        {
            Contract.Requires(source != null);

            return !source.Any();
        }

        /// <summary>
        /// Immediately executes an action on each element in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/> which contains elements to be acted upon.</param>
        /// <param name="action">The action to perform on elements in source.</param>
        /// <remarks><para>Execute is preferable name to ForEach as it states what is actually happening.
        /// The action is being invoked on each element in the enumerable immediately, without
        /// returning anything.</para><para>ForEach is ambiguous in its name. Does it return anything?
        /// Does it execute immediately or is it deferred?</para></remarks>
        public static void Execute<T>(this IEnumerable<T> source, Action<T> action)
        {
            Contract.Requires(source != null);
            Contract.Requires(action != null);

            foreach (T element in source)
            {
                action(element);
            }
        }

        /// <summary>
        /// Iterates over a sequence and executes an action.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/> which contains elements to iterated.</param>
        /// <param name="action">The action to perform on elements in source.</param>
        /// <returns>The original sequence.</returns>
        /// <remarks>Iterate provides deferred execution of an action over a sequence and returns the original
        /// sequence. This method and Execute are the two primary versions of ForEach others have implemented.</remarks>
        [Obsolete("Use Each instead")]
        public static IEnumerable<T> Iterate<T>(this IEnumerable<T> source, Action<T> action)
        {
            Contract.Requires(source != null);
            Contract.Requires(action != null);

            foreach (T element in source)
            {
                action(element);
                yield return element;
            }
        }

        /// <summary>
        /// Iterates over a sequence and executes an action.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/> which contains elements to iterated.</param>
        /// <param name="action">The action to perform on elements in source.</param>
        /// <returns>The original sequence.</returns>
        /// <remarks><para>Each provides deferred execution of an action over a sequence and returns the original
        /// sequence. This method and Execute are the two primary versions of ForEach others have implemented.</para>
        /// <para>Each was chosen over Iterate due to shorter syntax and the name being used in jQuery.</para></remarks>
        public static IEnumerable<T> Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            Contract.Requires(source != null);
            Contract.Requires(action != null);

            foreach (T element in source)
            {
                action(element);
                yield return element;
            }
        }

        /// <summary>
        /// Partitions the specified source.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/> to be partitioned.</param>
        /// <param name="size">The maximum size of each partition.</param>
        /// <returns>Multiple <see cref="IEnumerable&lt;T&gt;"/> partitioned by the size parameter.</returns>
        /// <remarks>See http://www.kodefuguru.com/post/2009/12/20/Refactoring-Partition-List.aspx</remarks>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "Nested generics is justified for partitioning sequences.")]
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
        {
            Contract.Requires(source != null);
            Contract.Requires(size > 0);

            int index = 1;
            IEnumerable<T> partition = source.Take(size).AsEnumerable();

            while (partition.Any())
            {
                yield return partition;
                partition = source.Skip(index++ * size).Take(size).AsEnumerable();
            }
        }

        /// <summary>
        /// Fluent Interface to add an item to a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/> to have an item added to it.</param>
        /// <param name="item">The item to be added.</param>
        /// <returns>An <see cref="IEnumerable&lt;T&gt;"/> with the item.</returns>
        public static IEnumerable<T> With<T>(this IEnumerable<T> source, T item)
        {
            foreach (T t in source)
            {
                yield return t;
            }

            yield return item;
        }

        /// <summary>
        /// Fluent Interface to return a sequence that doesn't contain the specified item.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/> to have an item removed from it.</param>
        /// <param name="item">The item to be removed.</param>
        /// <returns>An <see cref="IEnumerable&lt;T&gt;"/> that does not contain the specified items.</returns>
        public static IEnumerable<T> Without<T>(this IEnumerable<T> source, T item)
        {
            foreach (T t in source)
            {
                if (!item.Equals(t))
                {
                    yield return t;
                }
            }
        }

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
    }
}
