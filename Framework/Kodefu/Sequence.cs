﻿namespace Kodefu
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Sequence helper methods
    /// </summary>
    public static class Sequence
    {
        /// <summary>
        /// Creates the specified length.
        /// </summary>
        /// <typeparam name="T">Any type that will be generated by the createItem function</typeparam>
        /// <param name="length">The length.</param>
        /// <param name="func">The function used to create <typeparamref name="T"/>.</param>
        /// <returns>An enumeration of type T</returns>
        public static IEnumerable<T> Create<T>(int length, Func<int, T> func)
        {
            Contract.Requires(length >= 0);

            if (func != null)
            {
                for (int i = 0; i < length; i++)
                {
                    yield return func(i);
                }
            }
        }
    }
}
