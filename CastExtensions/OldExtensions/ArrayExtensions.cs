using System.Linq;

namespace CastExtensions.OldExtensions
{
    public static class ArrayExtensions
    {
        public static bool NullableEquals(this byte[] bytes1, byte[] bytes2)
        {
            return (bytes1 != null && bytes2 != null && bytes1.SequenceEqual(bytes2)) ||
                   (bytes1 == null && bytes2 == null);
        }
    }
}
