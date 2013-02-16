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

        public static T As<T>(this object item)
            where T : class
        {
            return item as T;
        }

        public static T Cast<T>(this object item)
        {
            return (T)item;
        }

        public static T Coalesce<T>(this T item, Func<T> factory)
            where T : class
        {
            if (item == null)
            {
                return factory();
            }
            return item;
        }

        public static T Coalesce<T>(this T item, T replacement)
            where T : class
        {
            return item ?? replacement;
        }

        public static T Do<T>(this T item, Action<T> action)
        {
            action(item);
            return item;
        }

        public static T If<T>(this T item, Func<T, bool> predicate, Action<T> consequence)
        {
            if (predicate(item))
            {
                consequence(item);
            }
            return item;
        }

        public static T If<T>(this T item, Func<T, bool> predicate, Func<T, T> consequence)
        {
            if (predicate(item))
            {
                return consequence(item);
            }
            return item;
        }

        public static T If<T>(this T item, bool predicate, Func<T, T> consequence)
        {
            if (predicate)
            {
                return consequence(item);
            }
            return item;
        }

        public static TResult If<T, TResult>(this T item, Func<T, bool> predicate, Func<T, TResult> consequence, TResult defaultValue)
        {
            if (predicate(item))
            {
                return consequence(item);
            }
            return defaultValue;
        }

        public static TResult If<T, TResult>(this T item, Func<T, bool> predicate, Func<T, TResult> consequence, Func<T, TResult> alternate)
        {
            if (predicate(item))
            {
                return consequence(item);
            }
            return alternate(item);
        }

        public static T IfNull<T>(this T obj, Action consequence)
        {
            if (obj == null)
            {
                consequence();
            }
            return obj;
        }

        public static TResult IfNull<T, TResult>(this T obj, Func<TResult> mapConsequence, TResult defaultValue = default(TResult))
        {
            if (obj == null)
            {
                return mapConsequence();
            }
            return defaultValue;
        }

        public static T IfNotNull<T>(this T obj, Action<T> consequence)
        {
            if (obj != null)
            {
                consequence(obj);
            }
            return obj;
        }

        public static TResult IfNotNull<T, TResult>(this T obj, Func<T, TResult> mapConsequence)
        {
            if (obj != null)
            {
                return mapConsequence(obj);
            }
            return default(TResult);
        }
    }
}
