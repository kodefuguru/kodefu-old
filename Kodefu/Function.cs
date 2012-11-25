namespace Kodefu
{
    using System;
    using System.Linq;
    
    public static class Function
    {
        public static Func<TResult> Apply<T, TResult>(this Func<T, TResult> func, T arg)
        {
            return () => func(arg);
        }

        public static Func<T2, TResult> Apply<T, T2, TResult>(this Func<T, T2, TResult> func, T arg)
        {
            return b => func(arg, b);
        }
        
        public static Func<TResult> Apply<T, T2, TResult>(this Func<T, T2, TResult> func, T arg1, T2 arg2)
        {
            return () => func(arg1, arg2);
        }

        public static Func<T2, T3, TResult> Apply<T, T2, T3, TResult>(this Func<T, T2, T3, TResult> func, T arg)
        {
            return (b,c) => func(arg, b, c);
        }

        public static Func<T3, TResult> Apply<T, T2, T3, TResult>(this Func<T, T2, T3, TResult> func, T arg1, T2 arg2)
        {
            return c => func(arg1, arg2, c);
        }

        public static Func<TResult> Apply<T, T2, T3, TResult>(this Func<T, T2, T3, TResult> func, T arg1, T2 arg2, T3 arg3)
        {
            return () => func(arg1, arg2, arg3);
        }

        public static Func<T2, T3, T4, TResult> Apply<T, T2, T3, T4, TResult>(this Func<T, T2, T3, T4, TResult> func, T arg)
        {
            return (b, c, d) => func(arg, b, c, d);
        }

        public static Func<T3, T4, TResult> Apply<T, T2, T3, T4, TResult>(this Func<T, T2, T3, T4, TResult> func, T arg1, T2 arg2)
        {
            return (c, d) => func(arg1, arg2, c, d);
        }

        public static Func<T4, TResult> Apply<T, T2, T3, T4, TResult>(this Func<T, T2, T3, T4, TResult> func, T arg1, T2 arg2, T3 arg3)
        {
            return d => func(arg1, arg2, arg3, d);
        }

        public static Func<TResult> Apply<T, T2, T3, T4, TResult>(this Func<T, T2, T3, T4, TResult> func, T arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return () => func(arg1, arg2, arg3, arg4);
        }

        public static Func<T, Func<T2, TResult>> Curry<T, T2, TResult>(this Func<T, T2, TResult> func)
        {
            return a => b => func(a, b);
        }

        public static Func<T, Func<T2, Func<T3, TResult>>> Curry<T, T2, T3, TResult>(this Func<T, T2, T3, TResult> func)
        {
            return a => b => c => func(a, b, c);
        }

        public static Func<T, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T, T2, T3, T4, TResult>(this Func<T, T2, T3, T4, TResult> func)
        {
            return a => b => c => d => func(a, b, c, d);
        }

        public static Func<T, TResult2> Select<T, TResult, TResult2>(this Func<T, TResult> func, Func<TResult, TResult2> selector)
        {
            return a => selector(func(a));
        }

        public static Func<T, T2, TResult2> Select<T, T2, TResult, TResult2>(this Func<T, T2, TResult> func, Func<TResult, TResult2> selector)
        {
            return (a, b) => selector(func(a, b));
        }

        public static Func<T, T2, T3, TResult2> Select<T, T2, T3, TResult, TResult2>(this Func<T, T2, T3, TResult> func, Func<TResult, TResult2> selector)
        {
            return (a, b, c) => selector(func(a, b, c));
        }

        public static Func<T, T2, T3, T4, TResult2> Select<T, T2, T3, T4, TResult, TResult2>(this Func<T, T2, T3, T4, TResult> func, Func<TResult, TResult2> selector)
        {
            return (a, b, c, d) => selector(func(a, b, c, d));
        }

        public static Func<T, T2, TResult3> SelectMany<T, T2, TResult, TResult2, TResult3>(this Func<T, TResult> left, Func<T2, TResult2> right, Func<TResult, TResult2, TResult3> selector)
        {
            return (a, b) => selector(left(a), right(b));
        }

        public static Func<T, T2, TResult3> SelectMany<T, T2, TResult, TResult2, TResult3>(this Func<T, TResult> left, Func<int, Func<T2, TResult2>> right, Func<TResult, TResult2, TResult3> selector)
        {
            return SelectMany(left, right(default(int)), selector);
        }

        public static Func<T, T2, T3, TResult3> SelectMany<T, T2, T3, TResult, TResult2, TResult3>(this Func<T, TResult> left, Func<T2, T3, TResult2> right, Func<TResult, TResult2, TResult3> selector)
        {
            return (a, b, c) => selector(left(a), right(b, c));
        }

        public static Func<T, T2, T3, TResult3> SelectMany<T, T2, T3, TResult, TResult2, TResult3>(this Func<T, TResult> left, Func<int, Func<T2, T3, TResult2>> right, Func<TResult, TResult2, TResult3> selector)
        {
            return SelectMany(left, right(default(int)), selector);
        }

        public static Func<T, T2, T3, T4, TResult3> SelectMany<T, T2, T3, T4, TResult, TResult2, TResult3>(this Func<T, TResult> left, Func<T2, T3, T4, TResult2> right, Func<TResult, TResult2, TResult3> selector)
        {
            return (a, b, c, d) => selector(left(a), right(b, c, d));
        }

        public static Func<T, T2, T3, T4, TResult3> SelectMany<T, T2, T3, T4, TResult, TResult2, TResult3>(this Func<T, TResult> left, Func<int, Func<T2, T3, T4, TResult2>> right, Func<TResult, TResult2, TResult3> selector)
        {
            return SelectMany(left, right(default(int)), selector);
        }

        public static Func<T, T2, T3, TResult3> SelectMany<T, T2, T3, TResult, TResult2, TResult3>(this Func<T, T2, TResult> left, Func<T3, TResult2> right, Func<TResult, TResult2, TResult3> selector)
        {
            return (a, b, c) => selector(left(a, b), right(c));
        }

        public static Func<T, T2, T3, TResult3> SelectMany<T, T2, T3, TResult, TResult2, TResult3>(this Func<T, T2, TResult> left, Func<int, Func<T3, TResult2>> right, Func<TResult, TResult2, TResult3> selector)
        {
            return SelectMany(left, right(default(int)), selector);
        }

        public static Func<T, T2, T3, T4, TResult3> SelectMany<T, T2, T3, T4, TResult, TResult2, TResult3>(this Func<T, T2, TResult> left, Func<T3, T4, TResult2> right, Func<TResult, TResult2, TResult3> selector)
        {
            return (a, b, c, d) => selector(left(a, b), right(c, d));
        }

        public static Func<T, T2, T3, T4, TResult3> SelectMany<T, T2, T3, T4, TResult, TResult2, TResult3>(this Func<T, T2, TResult> left, Func<int, Func<T3, T4, TResult2>> right, Func<TResult, TResult2, TResult3> selector)
        {
            return SelectMany(left, right(default(int)), selector);
        }

        public static Func<T, T2, T3, T4, TResult3> SelectMany<T, T2, T3, T4, TResult, TResult2, TResult3>(this Func<T, T2, T3, TResult> left, Func<T4, TResult2> right, Func<TResult, TResult2, TResult3> selector)
        {
            return (a, b, c, d) => selector(left(a, b, c), right(d));
        }

        public static Func<T, T2, T3, T4, TResult3> SelectMany<T, T2, T3, T4, TResult, TResult2, TResult3>(this Func<T, T2, T3, TResult> left, Func<int, Func<T4, TResult2>> right, Func<TResult, TResult2, TResult3> selector)
        {
            return SelectMany(left, right(default(int)), selector);
        }

        public static Func<T, T2, TResult> Uncurry<T, T2, TResult>(this Func<T, Func<T2, TResult>> func)
        {
            return (a, b) => func(a)(b);
        }

        public static Func<T, T2, T3, TResult> Uncurry<T, T2, T3, TResult>(this Func<T, Func<T2, Func<T3, TResult>>> func)
        {
            return (a, b, c) => func(a)(b)(c);
        }

        public static Func<T, T2, T3, T4, TResult> Uncurry<T, T2, T3, T4, TResult>(this Func<T, Func<T2, Func<T3, Func<T4, TResult>>>> func)
        {
            return (a, b, c, d) => func(a)(b)(c)(d);
        }
    }
}
