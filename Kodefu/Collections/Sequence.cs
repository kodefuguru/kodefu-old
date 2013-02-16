namespace Kodefu.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Sequence
    {
        public static IEnumerable<T> Coaelesce<T>(this IEnumerable<T> items)
        {
            return items ?? new T[0];
        }
        
        public static Sequence<T> Concat<T>(this Sequence<T> sequence, IEnumerable<T> other)
        {
            return new Sequence<T>(sequence.AsEnumerable().Concat(other));
        }

        public static Sequence<T> Concat<T>(this Sequence<T> sequence, params T[] items)
        {
            return Sequence.Concat<T>(sequence, (IEnumerable<T>)items);
        }

        public static Sequence<T> Create<T>(this IEnumerable<T> items)
        {
            return new Sequence<T>(items);
        }

        public static Sequence<T> Create<T>(params T[] items)
        {
            return new Sequence<T>(items);
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }
        }

        public static Sequence<T> Empty<T>()
        {
            return new Sequence<T>();
        }

        public static bool Empty<T>(this IEnumerable<T> sequence)
        {
            return !sequence.Any();
        }

        public static Sequence<T> Prepend<T>(this Sequence<T> sequence, IEnumerable<T> other)
        {
            return new Sequence<T>(other.Concat(sequence));
        }

        public static Sequence<T> Prepend<T>(this Sequence<T> sequence, params T[] items)
        {
            return Sequence.Prepend<T>(sequence, (IEnumerable<T>)items);
        }

        public static IEnumerable<T> Materialize<T>(this IEnumerable<T> sequence)
        {
            return sequence.ToArray();
        }

        public static IEnumerable<T> Difference<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.Except(right).Union(right.Except(left));
        }

        public static Sequence<T> Difference<T>(this Sequence<T> left, IEnumerable<T> right)
        {
            return new Sequence<T>(left.Difference(right));
        }
    }

    public struct Sequence<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> value;

        public Sequence(IEnumerable<T> sequence)
        {
            this.value = sequence;
        }

        public Sequence<TResult> Cast<TResult>()
        {
            return new Sequence<TResult>(Enumerable.Cast<TResult>(this));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (this.value ?? new T[0]).GetEnumerator();
        }

        public static implicit operator Sequence<T>(T[] array)
        {
            return new Sequence<T>(array);
        }

        public static Sequence<T> operator +(Sequence<T> left, Sequence<T> right)
        {
            return left.Concat(right);
        }

        public static Sequence<T> operator +(Sequence<T> left, IEnumerable<T> right)
        {
            return left.Concat(right);
        }

        public static Sequence<T> operator +(IEnumerable<T> left, Sequence<T> right)
        {
            return right.Prepend(left);
        }

        public static Sequence<T> operator +(Sequence<T> seq, T item)
        {
            return seq.Concat(item);
        }

        public static Sequence<T> operator +(T item, Sequence<T> seq)
        {
            return seq.Prepend(item);
        }

        public static Sequence<T, T> operator *(Sequence<T> left, Sequence<T> right)
        {
            return new Sequence<T, T>(left, right);
        }

        public static Sequence<T, T> operator *(Sequence<T> seq, T item)
        {
            return new Sequence<T, T>(seq, new[] { item });
        }

        public static Sequence<T, T> operator *(T item, Sequence<T> seq)
        {
            return new Sequence<T, T>(new[] { item }, seq);
        }
    }

    public struct Sequence<T, T2> : IEnumerable<Tuple<T, T2>>
    {
        private readonly IEnumerable<T> listA;
        private readonly IEnumerable<T2> listB;

        public Sequence(IEnumerable<T> sequenceA, IEnumerable<T2> sequenceB)
        {
            this.listA = sequenceA;
            this.listB = sequenceB;
        }

        public Sequence<TResult> Cast<TResult>()
        {
            return new Sequence<TResult>(Enumerable.Cast<TResult>(this));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T a in listA)
                yield return a;
            foreach (T2 b in listB)
                yield return b;
        }

        public IEnumerator<Tuple<T, T2>> GetEnumerator()
        {
            var first = this.listA ?? new T[0];
            var second = this.listB ?? new T2[0];
            return first.SelectMany(a => second.Select(b => Tuple.Create(a, b))).GetEnumerator();
        }

        public static implicit operator Sequence<T, T2>(T[] array)
        {
            return new Sequence<T, T2>(array, new T2[0]);
        }

        public static implicit operator Sequence<T, T2>(Tuple<T, T2>[] tuples)
        {
            return new Sequence<T, T2>(tuples.Select(t => t.Item1).Distinct(), tuples.Select(t => t.Item2).Distinct());
        }
    }
}
