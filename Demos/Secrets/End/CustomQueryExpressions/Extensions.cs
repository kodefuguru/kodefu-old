namespace CustomQueryExpressions
{
    using System;

    public static class Extensions
    {
        public static Func<T, T2, TResult3> SelectMany<T, T2, TResult, TResult2, TResult3>(this Func<T, TResult> leftFunc, Func<T, Func<T2, TResult2>> rightFunc, Func<TResult, TResult2, TResult3> selector)
        {
            return (x, y) => selector(leftFunc(x), rightFunc(x)(y));
        }
    }
}
