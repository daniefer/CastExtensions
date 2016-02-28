using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Xml.Linq;

namespace CastExtensions.OldExtensions
{
    static class XElementExtensions
    {
        public static XElement RenameElement(this XElement self, string newName)
        {
            return new XElement(newName, self.Attributes(), self.Elements());
        }

        public static bool IsNullOrNil(this XElement @object)
        {
            if (@object == null)
            {
                return true;
            }
            if (@object.Attributes().Any(x => x.Name.LocalName == "nil"))
            {
                return @object.Attributes().FirstOrDefault(x => x.Name.LocalName == "nil").Value.ToBool();
            }
            return false;
        }

        public static int? ToNullableInt(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableInt();
        }

        public static int ToInt(this XElement @object)
        {
            return @object.ToNullableInt() ?? 0;
        }

        public static long? ToNullableLong(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableLong();
        }

        public static long ToLong(this XElement @object)
        {
            return @object.ToNullableLong() ?? 0;
        }

        public static Guid? ToNullableGuid(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableGuid();
        }

        public static Guid ToGuid(this XElement @object)
        {
            Guid? result = @object.ToNullableGuid();
            return result.HasValue ? result.Value : Guid.Empty;
        }

        public static string ToNullableString(this XElement @object)
        {
            if (@object.IsNullOrNil())
            {
                return null;
            }

            string result = @object.Value.ToNullableString();
            return result;
        }

        public static DateTime? ToNullableDateTime(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableDateTime();
        }

        public static DateTime ToDateTime(this XElement @object)
        {
            return @object.ToNullableDateTime() ?? SqlDateTime.MinValue.Value;
        }

        public static TimeSpan? ToNullableTimeSpan(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableTimeSpan();
        }

        public static TimeSpan ToTimeSpan(this XElement @object)
        {
            return @object.ToNullableTimeSpan() ?? default(TimeSpan);
        }

        public static char? ToNullableChar(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableChar();
        }

        public static char ToChar(this XElement @object)
        {
            return @object.ToNullableChar() ?? default(char);
        }

        public static bool? ToNullableBool(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableBool();
        }

        public static bool ToBool(this XElement @object)
        {
            return @object.ToNullableBool() ?? false;
        }

        public static byte[] ToBytes(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToBytes();
        }

        public static float? ToNullableFloat(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableFloat();
        }

        public static float ToFloat(this XElement @object)
        {
            return @object.ToNullableFloat() ?? (float)0.0;
        }

        public static decimal? ToNullableDecimal(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableDecimal();
        }

        public static decimal ToDecimal(this XElement @object)
        {
            return @object.ToNullableDecimal() ?? 0.0m;
        }

        public static bool? ToNullableYNElseNullBool(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableYNElseNullBool();
        }

        public static bool? ToNullableYNElseNBool(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableYNElseNBool();
        }

        public static bool? ToNullableYNElseYBool(this XElement @object)
        {
            return @object.IsNullOrNil() ? null : @object.Value.ToNullableYNElseYBool();
        }

        public static bool ToYNElseNBool(this XElement @object)
        {
            return @object.ToNullableYNElseNBool() ?? false;
        }

        public static bool ToYNElseYBool(this XElement @object)
        {
            return @object.ToNullableYNElseYBool() ?? true;
        }
    }
}
