using System.Collections.Generic;
using System.Linq;

namespace CastExtensions.OldExtensions
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// This is used on LIST to ensure that a null list is not passed back">
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">Your list</param>
        /// <returns>An empty list</returns>
        public static IEnumerable<T> EnsureNotNull<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return Enumerable.Empty<T>();
            }
            else
            {
                return enumerable;
            }
        }
    }
}
