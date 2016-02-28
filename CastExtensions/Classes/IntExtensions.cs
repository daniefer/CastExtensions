using System;

namespace CastExtensions.Classes
{
    public static class ClassToIntExtensions
    {
        public static short ToShort<T>(this T input) where T : class
        {
            short output;
            if (short.TryParse(input.ToSafeString(), out output))
            {
                return output;
            }
            return default(short);
        }

        public static int ToInt<T>(this T input) where T : class
        {
            int output;
            if (int.TryParse(input.ToSafeString(), out output))
            {
                return output;
            }
            return default(int);
        }

        public static long ToLong<T>(this T input) where T : class
        {
            long output;
            if (long.TryParse(input.ToSafeString(), out output))
            {
                return output;
            }
            return default(long);
        }

        public static IntPtr ToIntPtr<T>(this T input) where T : class
        {
            if (input == null)
            {
                return IntPtr.Zero;
            }
            long output = input.ToLong();
            if (output == 0)
            {
                return IntPtr.Zero;
            }
            try
            {
                return new IntPtr(output);
            }
            catch (OverflowException)
            {
                return IntPtr.Zero;
            }
        }

        public static ushort ToUShort<T>(this T input) where T : class
        {
            ushort output;
            if (ushort.TryParse(input.ToSafeString(), out output))
            {
                return output;
            }
            return default(ushort);
        }

        public static uint ToUInt<T>(this T input) where T : class
        {
            uint output;
            if (uint.TryParse(input.ToSafeString(), out output))
            {
                return output;
            }
            return default(uint);
        }

        public static ulong ToULong<T>(this T input) where T : class
        {
            ulong output;
            if (ulong.TryParse(input.ToSafeString(), out output))
            {
                return output;
            }
            return default(ulong);
        }

        public static UIntPtr ToUIntPtr<T>(this T input) where T : class
        {
            if (input == null)
            {
                return UIntPtr.Zero;
            }
            ulong output = input.ToULong();
            if (output == 0)
            {
                return UIntPtr.Zero;
            }
            try
            {
                return new UIntPtr(output);
            }
            catch (OverflowException)
            {
                return UIntPtr.Zero;
            }
        }

        public static short? ToNullableShort<T>(this T input) where T : class
        {
            return input.IsNull() ? (short?)null : input.ToShort();
        }

        public static int? ToNullableInt<T>(this T input) where T : class
        {
            return input.IsNull() ? (int?)null : input.ToInt();
        }

        public static long? ToNullableLong<T>(this T input) where T : class
        {
            return input.IsNull() ? (long?)null : input.ToLong();
        }

        public static ushort? ToNullableUShort<T>(this T input) where T : class
        {
            return input.IsNull() ? (ushort?)null : input.ToUShort();
        }

        public static uint? ToNullableUInt<T>(this T input) where T : class
        {
            return input.IsNull() ? (uint?)null : input.ToUInt();
        }

        public static ulong? ToNullableULong<T>(this T input) where T : class
        {
            return input.IsNull() ? (ulong?)null : input.ToULong();
        }

        public static IntPtr? ToNullableIntPtr<T>(this T input) where T : class
        {
            return input.IsNull() ? (IntPtr?)null : input.ToIntPtr();
        }

        public static UIntPtr? ToNullableUIntPtr<T>(this T input) where T : class
        {
            return input.IsNull() ? (UIntPtr?)null : input.ToUIntPtr();
        }
    }
}