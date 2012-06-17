namespace Kodefu
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;

    /// <summary>
    /// Extension methods for <see cref="String"/>. 
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class StringExtensions
    {
        /// <summary>
        /// Creates a new instance of <see cref="String"/> with the same value as a specified <see cref="String"/>.
        /// </summary>
        /// <param name="source">The <see cref="String"/> to copy.</param>
        /// <returns>A new <see cref="String"/> with the same value as str.</returns>
        public static string Copy(this string source)
        {
            return String.Copy(source);
        }

        /// <summary>
        /// Replaces the format item in the source <see cref="String"/> with the text equivalent of the value of a corresponding <see cref="Object"/> instance in a specified array.
        /// </summary>
        /// <param name="format">A <see cref="String"/> containing zero or more format items.</param>
        /// <param name="args">An <see cref="Object"/> array containing zero or more objects to format.</param>
        /// <returns>A copy of the source string in which the format items have been replaced by the <see cref="String"/> equivalent of the corresponding instances of <see cref="Object"/> in args.</returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return format.FormatWith(CultureInfo.InvariantCulture, args);
        }

        /// <summary>
        /// Replaces the format item in the source <see cref="String"/> with the text equivalent of the value of a corresponding <see cref="Object"/> instance in a specified array.
        /// </summary>
        /// <param name="format">A <see cref="String"/> containing zero or more format items.</param>
        /// <param name="provider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information. </param>
        /// <param name="args">An <see cref="Object"/> array containing zero or more objects to format.</param>
        /// <returns>A copy of the source string in which the format items have been replaced by the <see cref="String"/> equivalent of the corresponding instances of <see cref="Object"/> in args.</returns>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            return String.Format(provider, format, args);
        }

        /// <summary>
        /// Retrieves the system's reference to the specified <see cref="String"/>.
        /// </summary>
        /// <param name="source">A <see cref="String"/> check in the intern pool.</param>
        /// <returns>If the value of str is already interned, the system's reference is returned; 
        /// otherwise, a new reference to a string with the value of str is returned.</returns>
        public static string Intern(this string source)
        {
            return String.Intern(source);
        }

        /// <summary>
        /// Indicates whether the specified <see cref="String"/> object is null or an <see cref="String.Empty"/> string.
        /// </summary>
        /// <param name="source">A <see cref="String"/> reference.</param>
        /// <returns>true if the <see cref="String"/> is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return String.IsNullOrEmpty(source);
        }

        public static void Write(this string source, string fileName)
        {
            File.WriteAllText(fileName, source);
        }
    }
}
