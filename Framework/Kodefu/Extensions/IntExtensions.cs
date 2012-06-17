namespace Kodefu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Fluent interface for Int
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class IntExtensions
    {
        /// <summary>
        /// Creates a sequence from the starting number to the ending number.
        /// </summary>
        /// <param name="start">The starting number.</param>
        /// <param name="end">The ending number.</param>
        /// <returns>A sequence of integers</returns>
        public static IEnumerable<int> To(this int start, int end)
        {
            int count = end - start;
            
            // modifer will cause it to count down if end is less than the start
            int modifier = count < 0 ? -1 : 1;

            return Sequence.Create(1 + Math.Abs(count), i => start + (i * modifier));
        }
    }
}
