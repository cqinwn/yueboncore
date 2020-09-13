using System.Data.Common;

namespace Yuebon.Commons.Data
{
    public class MicroDataTableHelper
    {

        /// <summary>
        /// DbDataReaders 数据转化Datatable
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static MicroDataTable FillDataTable(DbDataReader reader, int pageIndex, int pageSize)
        {
            bool defined = false;
            MicroDataTable table = new MicroDataTable();
            int index = 0;
            int beginIndex = pageSize * pageIndex;
            int endIndex = pageSize * (pageIndex + 1) - 1;
            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                if (!defined)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        MicroDataColumn column = new MicroDataColumn()
                        {
                            ColumnName = reader.GetName(i),
                            ColumnType = reader.GetFieldType(i)
                        };
                        table.Columns.Add(column);
                    }
                    defined = true;
                }
                if (index >= beginIndex && index <= endIndex)
                {
                    reader.GetValues(values);
                    table.Rows.Add(new MicroDataRow(table.Columns, values));
                }
                index++;
            }
            table.TotalCount = index;
            return table;
        }
    }
}
