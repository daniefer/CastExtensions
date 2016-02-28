using System.Text;

namespace CastExtensions.OldExtensions
{
    public static class SystemExtensions
    {
        public static string ToHexString(this byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return "0000000000000000";
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
