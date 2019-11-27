using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 统计未发送消息的汇总记录
    /// </summary>
    public class OperateTrajectoryDetailTotalNoIsSendOutput
    {
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalNum
        {
            get;
            set;
        }

        /// <summary>
        /// 项目描述
        /// </summary>
        public string TotalDesc
        {
            get;
            set;
        }


        /// <summary>
        /// 统计类型
        /// </summary>
        public string OperateType
        {
            get;
            set;
        }
    }
}
