using System.Data;

namespace CastExtensions.OldExtensions
{
    public static class DataSetExtensions
    {
        public static bool DataSetRowsExist(this DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
