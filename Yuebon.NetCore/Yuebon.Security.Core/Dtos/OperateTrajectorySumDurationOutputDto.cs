using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    ///  输入DTO：APP信息
    /// </summary>
    [Serializable]
    public class OperateTrajectorySumDurationOutputDto : IOutputDto
    {

        #region Property Members
        /// <summary>
        /// 统计数目
        /// </summary>
        public int TotalDuration
        {
            set;
            get;
        }


        #endregion

    }
}
