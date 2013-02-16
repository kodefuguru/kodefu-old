namespace Kodefu
{
    using System;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string FormatWith(this string value, params object[] items)
        {
            return String.Format(value, items);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        public static string RemoveSpecialCharacters(this string input)
        {
            Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            return r.Replace(input, String.Empty);
        }
    }
}
