using System.Xml.Serialization;

namespace Yuebon.Commons.Pages
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="info"></param>
    public delegate void PageInfoChanged(PagerInfo info);

    /// <summary>
    /// 分页实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class PagerInfo
    {
        /// <summary>
        /// 页面选择事件
        /// </summary>
        public event PageInfoChanged OnPageInfoChanged;
        /// <summary>
        /// 当前页码
        /// </summary>
        private int currenetPageIndex;
        /// <summary>
        /// 每页显示的记录
        /// </summary>
        private int pageSize=50;
        /// <summary>
        /// 记录总数
        /// </summary>
        private int recordCount;

        #region 属性变量

        /// <summary>
        /// 获取或设置当前页码
        /// </summary>
        [XmlElement(ElementName = "CurrenetPageIndex")]
        [DataMember]
        public int CurrenetPageIndex
        {
            get { return currenetPageIndex; }
            set
            {
                currenetPageIndex = value;

                if (OnPageInfoChanged != null)
                {
                    OnPageInfoChanged(this);
                }
            }
        }

        /// <summary>
        /// 获取或设置每页显示的记录
        /// </summary>
        [XmlElement(ElementName = "PageSize")]
        [DataMember]
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = value;
                if (OnPageInfoChanged != null)
                {
                    OnPageInfoChanged(this);
                }
            }
        }

        /// <summary>
        /// 获取或设置记录总数
        /// </summary>
        [XmlElement(ElementName = "RecordCount")]
        [DataMember]
        public int RecordCount
        {
            get { return recordCount; }
            set
            {
                recordCount = value;
                if (OnPageInfoChanged != null)
                {
                    OnPageInfoChanged(this);
                }
            }
        }

        /// <summary>
        /// 排序字段(例如:id desc,time asc)
        /// </summary>
        public string StrOrderByFileds { get; set; }
        /// <summary>
        /// 查询条件( 例如:id = 1 and name = 小明)
        /// </summary>
        public string Conditions { get; set; }
        #endregion
    }
}
