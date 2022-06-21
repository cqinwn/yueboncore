using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Data
{
    /// <summary>
    /// 查询结果数据表样式
    /// </summary>
    public class MicroDataTable
    { 
        /// <summary>
        /// 整个查询语句结果的总条数，而非本DataTable的条数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 数据列名称
        /// </summary>
        public List<MicroDataColumn> Columns { get; set; } = new List<MicroDataColumn>();
        /// <summary>
        /// 数据记录
        /// </summary>
        public List<MicroDataRow> Rows { get; set; } = new List<MicroDataRow>();
        /// <summary>
        /// 主键
        /// </summary>
        public MicroDataColumn[] PrimaryKey { get; set; }
        public MicroDataRow NewRow()
        {
            return new MicroDataRow(this.Columns, new object[Columns.Count]);
        }
    }
    public class MicroDataColumn
    {
        public string ColumnName { get; set; }
        public Type ColumnType { get; set; }
    }
    public class MicroDataRow
    {
        private object[] _ItemArray;
        public List<MicroDataColumn> Columns { get; private set; }
        public MicroDataRow(List<MicroDataColumn> columns, object[] itemArray)
        {
            this.Columns = columns;
            this._ItemArray = itemArray;
        }
        public object this[int index]
        {
            get { return _ItemArray[index]; }
            set { _ItemArray[index] = value; }
        }
        public object this[string columnName]
        {
            get
            {
                int i = 0;
                foreach (MicroDataColumn column in Columns)
                {
                    if (column.ColumnName == columnName)
                        break;
                    i++;
                }
                return _ItemArray[i];
            }
            set
            {
                int i = 0;
                foreach (MicroDataColumn column in Columns)
                {
                    if (column.ColumnName == columnName)
                        break;
                    i++;
                }
                _ItemArray[i] = value;
            }
        }
    }
}
