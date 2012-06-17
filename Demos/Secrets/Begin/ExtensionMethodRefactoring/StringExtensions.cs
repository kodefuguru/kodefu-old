namespace Functional
{
    using System;

    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string source)
        {
            return String.IsNullOrEmpty(source);
        }
    }
}
