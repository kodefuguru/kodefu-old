namespace FactoryFunctionPattern
{
    using System;

    static class Extensions
    {
        public static T IfNull<T>(this T obj, Func<T> factory) where T : class
        {
            if (obj == null)
            {
                obj = factory();
            }
            return obj;
        }
    }
}