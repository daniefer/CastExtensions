using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastExtensions
{
    public static class StringExtensions
    {
        public static string ToSafeString<T>(this T input) where T : class
        {
            if (input == null || input is DBNull)
            {
                return string.Empty;
            }
            return input.ToString();
        }
    }
}
