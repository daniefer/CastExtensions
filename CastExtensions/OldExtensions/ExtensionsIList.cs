using System.Collections.Generic;
using System.Linq;

namespace CastExtensions.OldExtensions
{
    public static class ExtensionsIList
    {
        public static bool NullableSequenceEquals<T>(this IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            return (collection2 != null && collection1 != null && collection1.SequenceEqual(collection2)) ||
                   (collection1 == null && collection2 == null);
        }

        public static List<T> EnsureNotNullList<T>(this List<T> list)
        {
            if (list == null)
            {
                return new List<T>();
            }
            else
            {
                return list;
            }
        }
    }
}
