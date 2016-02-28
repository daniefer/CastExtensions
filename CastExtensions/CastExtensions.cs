using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastExtensions
{
    internal static class CastExtensions
    {
        public static T Cast<T>(this T input) where T: class
        {
            if (input == null)
            {
                return null;
            }
            return input;
        }

        public static bool IsNull<TIn>(this TIn input) where TIn : class
        {
            return input == null || input is DBNull;
        }
    }
}
