namespace Functional
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class EnumerableStringExtensions
    {
        private const string Delimiter = ",";

        public static string Delimit(this IEnumerable<string> strings)
        {
            return strings.Delimit(Delimiter);
        }

        public static string Delimit(this IEnumerable<string> strings, string delimiter)
        {
            return string.Join(delimiter, strings.ToArray());
        }

        public static void Write(this IEnumerable<string> strings, string path)
        {
            File.WriteAllLines(path, strings.ToArray());
        }

        public static IEnumerable<string> DelimitedReverse(this IEnumerable<string> source)
        {
            return source.Select(l => l.Split(',').Reverse().Delimit());
        }
    }
}
