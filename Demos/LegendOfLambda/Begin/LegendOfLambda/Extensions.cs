namespace LegendOfLambda
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static String Delimit(this IEnumerable<string> strings, string delimiter)
        {
            return String.Join(delimiter, strings);
        }

        public static string FormatWith(this string format, params string[] strings)
        {
            return String.Format(format, strings);
        }
    }
}