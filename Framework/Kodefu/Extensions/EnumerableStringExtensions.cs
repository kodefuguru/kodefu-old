namespace Kodefu
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Fluent interface for IEnumerable&lt;string&gt;
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EnumerableStringExtensions
    {
        /// <summary>
        /// The delimiter used if Delimit is called without the separator parameter.
        /// </summary>
        private const string Delimiter = ",";

        /// <summary>
        /// Delimits the strings with the default delimited, a comma.
        /// </summary>
        /// <param name="strings">The strings.</param>
        /// <returns>A comma-separated value <see cref="System.String"/></returns>
        public static string Delimit(this IEnumerable<string> strings)
        {
            return strings.Delimit(Delimiter);
        }
        
        /// <summary>
        /// Creates a delimited string
        /// </summary>
        /// <param name="strings">The strings.</param>
        /// <param name="delimiter">The delimiter with which to separate the strings.</param>
        /// <returns>A <see cref="System.String"/> consisting of the elements of value interspersed with the separator string.</returns>
        public static string Delimit(this IEnumerable<string> strings, string delimiter)
        {
            Contract.Requires(strings != null);

            return string.Join(delimiter, strings.ToArray());
        }

        /// <summary>
        /// Writes the specified strings.
        /// </summary>
        /// <param name="strings">The strings.</param>
        /// <param name="path">The path to the file that is to be written.</param>
        public static void Write(this IEnumerable<string> strings, string path)
        {
            File.WriteAllLines(path, strings.ToArray());
        }
    }
}
