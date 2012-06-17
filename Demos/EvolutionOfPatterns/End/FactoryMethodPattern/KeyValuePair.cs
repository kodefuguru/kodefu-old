namespace FactoryMethodPattern
{
    using System.Collections.Generic;

    partial class Program
    {
        static class KeyValuePair
        {
            public static KeyValuePair<T, T2> Create<T, T2>(T key, T2 value)
            {
                return new KeyValuePair<T, T2>(key, value);
            }
        }
    }
}