namespace Kodefu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides static methods for creating KeyValuePair objects.
    /// </summary>
    public static class KeyValuePair
    {
        /// <summary>
        /// Creates a new <see cref="KeyValuePair&lt;K, V&gt;"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="key">The value of the key.</param>
        /// <param name="value">The value of the value.</param>
        /// <returns>A <see cref="KeyValuePair&lt;K, V&gt;"/> whose value is (key, value).</returns>
        /// <remarks>Create(K, V) is a helper method that you can call to instantiate a KeyValuePair object without having to explicitly specify the types of its components.</remarks>
        public static KeyValuePair<TKey, TValue> Create<TKey, TValue>(TKey key, TValue value)
        {
            return new KeyValuePair<TKey, TValue>(key, value);
        }
    }
}
