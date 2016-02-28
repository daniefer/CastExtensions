using System;

namespace CastExtensions.Structs
{
    public static class IntExtensions
    {
        #region decimal
        public static short ToShort(this decimal input)
        {
            return decimal.ToInt16(input);
        }
        public static int ToInt(this decimal input)
        {
            return decimal.ToInt32(input);
        }

        public static long ToLong(this decimal input)
        {
            return decimal.ToInt64(input);
        }

        public static IntPtr ToIntPtr(this decimal input)
        {
            try
            {
                return new IntPtr(input.ToLong());
            }
            catch (OverflowException)
            {
                return IntPtr.Zero;
            }
        }

        public static ushort ToUShort(this decimal input)
        {
            return decimal.ToUInt16(input);
        }

        public static uint ToUInt(this decimal input)
        {
            return decimal.ToUInt32(input);
        }

        public static ulong ToULong(this decimal input)
        {
            return decimal.ToUInt64(input);
        }

        public static UIntPtr ToUIntPtr(this decimal input)
        {
            try
            {
                return new UIntPtr(input.ToULong());
            }
            catch (OverflowException)
            {
                return UIntPtr.Zero;
            }
        }

        public static short? ToNullableShort(this decimal input)
        {
            return input.ToShort();
        }

        public static int? ToNullableInt(this decimal input)
        {
            return input.ToInt();
        }

        public static long? ToNullableLong(this decimal input)
        {
            return input.ToLong();
        }

        public static ushort? ToNullableUShort(this decimal input)
        {
            return input.ToUShort();
        }

        public static uint? ToNullableUInt(this decimal input)
        {
            return input.ToUInt();
        }

        public static ulong? ToNullableULong(this decimal input)
        {
            return input.ToULong();
        }

        public static IntPtr? ToNullableIntPtr(this decimal input)
        {
            return input.ToIntPtr();
        }

        public static UIntPtr? ToNullableUIntPtr(this decimal input)
        {
            return input.ToUIntPtr();
        }
        #endregion

        #region float

        public static short ToShort(this float input)
        {
            if (input > short.MaxValue)
            {
                return short.MaxValue;
            }
            if (input < short.MinValue)
            {
                return short.MinValue;
            }
            return Convert.ToInt16(input);
        }
        #endregion
    }
}