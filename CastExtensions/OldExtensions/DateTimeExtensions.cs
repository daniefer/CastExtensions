using System;
using System.Data.SqlTypes;

namespace CastExtensions.OldExtensions
{
    public static class DateTimeExtensions
    {
        public static bool IsValidSqlDateTime(this DateTime dateTime)
        {
            return dateTime >= SqlDateTime.MinValue.Value || dateTime <= SqlDateTime.MaxValue.Value;
        }
    }
}
