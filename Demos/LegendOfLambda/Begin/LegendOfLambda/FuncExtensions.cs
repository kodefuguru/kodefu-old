namespace LegendOfLambda
{
    using System;

    public static class FuncExtensions
    {
        public static Func<T2, TResult> Apply<T1, T2, TResult>(
            this Func<T1, T2, TResult> func, T1 applied)
        {
            return b => func(applied, b);
        }

        public static Func<T2, T3, TResult> Apply<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func, T1 applied)
        {
            return (b, c) => func(applied, b, c);
        }

        public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(
            this Func<T1, T2, TResult> func)
        {
            return a => b => func(a, b);
        }
         
        public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func)
        {
            return a => b => c => func(a, b, c);
        }

        public static TResult Forward<TSource, TResult>(
            this TSource source, Func<TSource, TResult> func)
        {
            return func(source);
        }

        public static Func<T2, T1, TResult> Flip<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            return (x, y) => func(y, x);
        }

        public static Func<Int32, Double> Sum(this Func<Int32, Double> func, int start = 0)
        {
            return end =>
            {
                Double result = default(Double);

                for (int k = start; k <= end; k++)
                {
                    result += func(k);
                }

                return result;
            };
        }
    }
}