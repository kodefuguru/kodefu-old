namespace Kodefu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Fluent interface for <see cref="Delegate"/>.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class DelegateExtensions
    {
        /// <summary>
        /// Concatenates the invocation lists of an array of delegates.
        /// </summary>
        /// <param name="delegates">The delegates to combine.</param>
        /// <returns>A new delegate with an invocation list that concatenates 
        /// the invocation lists of the delegates in the delegates array. 
        /// Returns null if delegates is null, if delegates contains zero elements, 
        /// or if every entry in delegates is null.</returns>
        public static Delegate Combine(this IEnumerable<Delegate> delegates)
        {
            return Delegate.Combine(delegates.ToArray());
        }

        /// <summary>
        /// Removes the last occurrence of the invocation list of a delegate from the invocation list of another delegate.
        /// </summary>
        /// <param name="source">The delegate from which to remove the invocation list of value. </param>
        /// <param name="value">The delegate that supplies the invocation list to remove from the invocation list of source.</param>
        /// <returns>A new delegate with an invocation list formed by taking the invocation list of 
        /// source and removing the last occurrence of the invocation list of value, if the invocation 
        /// list of value is found within the invocation list of source. Returns source if value is 
        /// null or if the invocation list of value is not found within the invocation list of source. 
        /// Returns a null reference if the invocation list of value is equal to the invocation list 
        /// of source or if source is a null reference.</returns>
        public static Delegate Remove(this Delegate source, Delegate value)
        {
            return Delegate.Remove(source, value);
        }

        /// <summary>
        /// Removes all occurrences of the invocation list of a delegate from the invocation list of another delegate.
        /// </summary>
        /// <param name="source">The delegate from which to remove the invocation list of value.</param>
        /// <param name="value">The delegate that supplies the invocation list to remove from the invocation list of source.</param>
        /// <returns>A new delegate with an invocation list formed by taking the invocation list 
        /// of source and removing all occurrences of the invocation list of value, if the 
        /// invocation list of value is found within the invocation list of source. 
        /// Returns source if value is null or if the invocation list of value is not found 
        /// within the invocation list of source. Returns a null reference if the invocation 
        /// list of value is equal to the invocation list of source, if source contains only 
        /// a series of invocation lists that are equal to the invocation list of value, or 
        /// if source is a null reference.</returns>
        public static Delegate RemoveAll(this Delegate source, Delegate value)
        {
            return Delegate.Remove(source, value);
        }
    }
}
