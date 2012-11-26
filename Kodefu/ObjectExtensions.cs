namespace Kodefu
{
    using System;

    /// <summary>
    /// LinqToObjects can't be used from within the same namespace containing this code.
    /// </summary>
    public static class ObjectExtensions
    {
        public static TResult Select<T, TResult>(this T item, Func<T, TResult> selector)
        {
            return selector(item);
        }

        public static Maybe<T> Where<T>(this T item, Func<T, bool> predicate)
        {
            return Maybe.Create(item, () => predicate(item));
        }

        public static TResult SelectMany<T, T2, TResult>(this T left, T2 right, Func<T, T2, TResult> selector)
        {
            return selector(left, right);
        }

        public static TResult SelectMany<T, T2, TResult>(this T left, Func<int, T2> right, Func<T, T2, TResult> selector)
        {
            return SelectMany(left, right(0), selector);
        }
    }
}
