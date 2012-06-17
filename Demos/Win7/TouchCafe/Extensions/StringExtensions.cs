using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchCafe
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhitespace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }
    }
}
