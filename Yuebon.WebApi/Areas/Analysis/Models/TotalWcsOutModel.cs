using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yuebon.WebApi.Areas.Analysis.Models
{
    /// <summary>
    /// 控制台首页显示内容
    /// </summary>
    [Serializable]
    public class TotalWcsOutModel
    {
        /// <summary>
        /// 总分拣机任务
        /// </summary>
        public int TotalSortingTaskBill
        {
            get;
            set;
        }
        /// <summary>
        /// 今日分拣机任务
        /// </summary>
        public int TotalTodaySortingTaskBill
        {
            get;
            set;
        }
        /// <summary>
        /// 今日未完成分拣机任务
        /// </summary>
        public int TotalTodayNoFinishedSortingTaskBill
        {
            get;
            set;
        }
        /// <summary>
        /// 总分拣单
        /// </summary>
        public int TotalSortingBill
        {
            get;
            set;
        }
        /// <summary>
        /// 今日分拣单
        /// </summary>
        public int TotalTodaySortingBill
        {
            get;
            set;
        }

        /// <summary>
        /// 今日未完成分拣单
        /// </summary>
        public int TotalTodayNoFinishedSortingBill
        {
            get;
            set;
        }
        /// <summary>
        /// 总分拣物料数
        /// </summary>
        public int TotalSortingTaskDetailBill
        {
            get;
            set;
        }
        /// <summary>
        /// 今日分拣物料数
        /// </summary>
        public int TotalTodaySortGoods
        {
            get;
            set;
        }
        /// <summary>
        /// 今日未分拣物料数
        /// </summary>
        public int TotalTodayNoFinishedSortingTaskDetailBill
        {
            get;
            set;
        }

        /// <summary>
        /// 今日已分拣物料数
        /// </summary>
        public int TotalTodaySortingTaskDetailBill
        {
            get;
            set;
        }
    }
}
