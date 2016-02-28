using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CastExtensions.OldExtensions
{
    public static class ObjectExtensions
    {
        public static int? GetNullableKey(this object @object)
        {

            if (@object == null)
            {
                return null;
            }


            Type type = @object.GetType();

            foreach (PropertyInfo property in type.GetProperties())
            {
                object[] attribute = property.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), true);
                if (attribute.Length > 0)
                {
                    object value = property.GetValue(@object, null);
                    return value.ToInt();
                }
            }

            return null;
        }


        public static int GetKey(this object @object)
        {
            var returnValue = @object.GetNullableKey();
            return returnValue.HasValue ? returnValue.Value : 0;
        }

        public static XDocument SerializeObject(this object obj)
        {
            XDocument xDoc = new XDocument();

            using (var writer = xDoc.CreateWriter())
            {
                var serializer = new DataContractSerializer(obj.GetType());
                serializer.WriteObject(writer, obj);
            }

            return xDoc;
        }

        public static XElement ToXElement(this object @object)
        {
            if (@object is XElement)
            {
                return (XElement) @object;
            }
            if (@object == null)
            {
                return null;
            }
            XElement output;
            try
            {
                output = XElement.Parse(@object.ToString());
            }
            catch
            {
                output = null;
            }
            return output;
        }

        public static int? ToNullableInt(this object @object)
        {
            int output;
            if (@object == null || @object == DBNull.Value)
            {
                return null;
            }
            if (int.TryParse(@object.ToString(), out output))
            {
                return output;
            }
            else
            {
                return null;
            }
        }

        public static int ToInt(this object @object)
        {
            int? output = @object.ToNullableInt();
            if (output == null)
            {
                return 0;
            }
            return output.Value;
        }

        public static long? ToNullableLong(this object @object)
        {
            long output;
            if (@object == null || @object == DBNull.Value)
            {
                return null;
            }
            if (long.TryParse(@object.ToString(), out output))
            {
                return output;
            }
            return null;
        }

        public static long ToLong(this object @object)
        {
            return @object.ToNullableLong() ?? 0;
        }

        public static Guid? ToNullableGuid(this object @object)
        {
            Guid output;
            if (@object == null || @object == DBNull.Value)
            {
                return null;
            }
            if (@object is Guid?)
            {
                return (Guid?) @object;
            }
            if (Guid.TryParse(@object.ToString(), out output))
            {
                return output;
            }
            return null;
        }

        public static Guid ToGuid(this object @object)
        {
            Guid? result = @object.ToNullableGuid();
            return result.HasValue ? result.Value : Guid.Empty;
        }

        public static string ToNullableString(this object @object)
        {
            if (@object == null)
                return null;
            if (@object.Equals(DBNull.Value))
                return String.Empty;
            if (@object.ToString().Count() == 1 &&
                (@object.ToNullableChar() == '\0' || @object.ToNullableChar() == null))
                return null;
            Queue<char> chars = new Queue<char>();
            foreach (char c in @object.ToString())
            {
                if (c != '\0')
                    chars.Enqueue(c);
            }
            string result = new string(chars.ToArray());
            return result;
        }

        public static DateTime? ToNullableDateTime(this object @object)
        {
            if (@object == null || @object == DBNull.Value)
            {
                return null;
            }
            if (@object is DateTime? || @object is DateTime)
            {
                return ((DateTime?)@object).Value.IsValidSqlDateTime() ? (DateTime?)@object : null;
            }
            DateTime result;
            if (DateTime.TryParse(Convert.ToString(@object), out result))
            {
                if (!result.IsValidSqlDateTime())
                    // valid date range for a SQL Datetime
                {
                    return null;
                }
                return result;
            }
            return null;
        }

        public static DateTime ToDateTime(this object @object)
        {
            DateTime? returnDateTime = @object.ToNullableDateTime();
            if (!returnDateTime.HasValue)
            {
                return SqlDateTime.MinValue.Value;
            }
            return returnDateTime.Value;
        }

        public static TimeSpan? ToNullableTimeSpan(this object @object)
        {
            if (@object == null || @object == DBNull.Value)
            {
                return null;
            }
            Regex regexWithMinutesAndSecondsAndMilliseconds =
                new Regex(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9].\d+$");
            Regex regexWithMinutesAndSeconds = new Regex(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
            Regex regexWithMinutes = new Regex(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");
            string[] stringPieces;
            if (@object is TimeSpan?)
            {
                return (TimeSpan?) @object;
            }
            string formattedString = @object.ToNullableString().Trim();
            if (String.IsNullOrEmpty(formattedString))
            {
                return null;
            }
            if (regexWithMinutesAndSecondsAndMilliseconds.IsMatch(formattedString))
            {
                stringPieces = formattedString.Split(new char[] {':', '.'});
                return new TimeSpan(0, stringPieces[0].ToInt(), stringPieces[1].ToInt(), stringPieces[2].ToInt(),
                    stringPieces[3].ToInt());
            }
            if (regexWithMinutesAndSeconds.IsMatch(formattedString))
            {
                stringPieces = formattedString.Split(':');
                return new TimeSpan(0, stringPieces[0].ToInt(), stringPieces[1].ToInt(), stringPieces[2].ToInt());
            }
            if (regexWithMinutes.IsMatch(formattedString))
            {
                stringPieces = formattedString.Split(':');
                return new TimeSpan(0, stringPieces[0].ToInt(), stringPieces[1].ToInt(), 0);
            }
            return null;
        }

        public static TimeSpan ToTimeSpan(this object @object)
        {
            TimeSpan? output = @object.ToNullableTimeSpan();
            if (!output.HasValue)
            {
                return default(TimeSpan);
            }
            return output.Value;
        }

        public static char? ToNullableChar(this object @object)
        {
            if (@object == null || @object == DBNull.Value)
            {
                return null;
            }
            string converted_value = Convert.ToString(@object);
            if (String.IsNullOrEmpty(converted_value))
            {
                return null;
            }
            else
            {
                Char result;
                if (Char.TryParse(converted_value, out result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public static char ToChar(this object @object)
        {
            char? output = @object.ToNullableChar();
            if (output.HasValue)
            {
                return output.Value;
            }
            return '\0';
        }

        public static bool? ToNullableBool(this object @object)
        {
            if (@object == null || @object == DBNull.Value)
            {
                return null;
            }
            bool result = false;
            int tmpInt = 0;

            if (bool.TryParse(@object.ToNullableString(), out result))
            {
                return result;
            }
            if (int.TryParse(@object.ToNullableString(), out tmpInt))
            {
                return tmpInt == 0 ? (bool?) false : (tmpInt == 1 ? (bool?) true : (bool?) null);
            }
            else
            {
                return null;
            }
        }

        public static bool ToBool(this object @object)
        {
            bool? result = @object.ToNullableBool();
            if (result.HasValue)
            {
                return result.Value;
            }
            return false;
        }

        public static byte[] ToBytes(this object @object)
        {
            if (@object == null)
            {
                return null;
            }
            if (@object is byte[])
            {
                return (byte[]) @object;
            }
            if (@object is SqlBinary)
            {
                return ((SqlBinary) @object).Value;
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, @object);
            return memoryStream.ToArray();
        }

        public static float? ToNullableFloat(this object @object)
        {
            float output;
            if (@object == null || @object == DBNull.Value)
            {
                return null;
            }
            if (float.TryParse(@object.ToString(), out output))
            {
                return output;
            }
            return null;
        }

        public static float ToFloat(this object @object)
        {
            return @object.ToNullableFloat() ?? (float) 0.0;
        }

        public static decimal? ToNullableDecimal(this object @object)
        {
            decimal output;
            if (@object == null || @object == DBNull.Value)
            {
                return null;
            }
            if (decimal.TryParse(@object.ToString(), out output))
            {
                return output;
            }
            return null;
        }

        public static decimal ToDecimal(this object @object)
        {
            return @object.ToNullableDecimal() ?? 0.0m;
        }

        public static bool? ToNullableYNElseNullBool(this object @object)
        {
            if (@object == null || @object == DBNull.Value)
                return null;
            char? tmpchar = @object.ToNullableChar();
            if (tmpchar == 'Y' || tmpchar == 'y')
                return true;
            if (tmpchar == 'N' || tmpchar == 'n')
                return false;
            return null;
        }

        public static bool? ToNullableYNElseNBool(this object @object)
        {
            if (@object == null || @object == DBNull.Value)
                return null;
            char? tmpchar = @object.ToNullableChar();
            if (tmpchar == 'Y' || tmpchar == 'y')
                return true;
            if (tmpchar == 'N' || tmpchar == 'n')
                return false;
            return false;
        }

        public static bool? ToNullableYNElseYBool(this object @object)
        {
            if (@object == null || @object == DBNull.Value)
                return null;
            char? tmpchar = @object.ToNullableChar();
            if (tmpchar == 'Y' || tmpchar == 'y')
                return true;
            if (tmpchar == 'N' || tmpchar == 'n')
                return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="object"></param>
        /// <returns>Returns false if unknown</returns>
        public static bool ToYNElseNBool(this object @object)
        {
            if (@object == null)
                return false;
            char tmpchar = @object.ToChar();
            if (tmpchar == 'Y' || tmpchar == 'y')
                return true;
            if (tmpchar == 'N' || tmpchar == 'n')
                return false;
            return false;
        }

        public static bool ToYNElseYBool(this object @object)
        {
            if (@object == null)
                return true;
            char tmpchar = @object.ToChar();
            if (tmpchar == 'Y' || tmpchar == 'y')
                return true;
            if (tmpchar == 'N' || tmpchar == 'n')
                return false;
            return true;
        }

        public static bool NullableEquals(this object o1, object o2)
        {
            return (o1 != null && o1.Equals(o2)) ||
                   (o2 != null && o2.Equals(o1)) ||
                   (o2 == null && o1 == null) ||
                   (o1 == DBNull.Value && o2 == DBNull.Value);
        }
    }
}
