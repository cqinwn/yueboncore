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
    public class OperateTrajectorySumInfoTypeOutputDto : IOutputDto
    {

        #region Property Members
        /// <summary>
        /// 统计数目
        /// </summary>
        public int OppNums 
        {
            set;
            get;
        }
        /// <summary>
        /// 统计数目
        /// </summary>
        public int DocNums
        {
            set;
            get;
        }

        /// <summary>
        /// 统计数目
        /// </summary>
        public int JobNums
        {
            set;
            get;
        }

        /// <summary>
        /// 统计数目
        /// </summary>
        public int ArticleNums
        {
            set;
            get;
        }

        /// <summary>
        /// 统计数目
        /// </summary>
        public int ShareNums
        {
            set;
            get;
        }


        /// <summary>
        /// 统计
        /// </summary>
        public string  TotalDuration
        {
            set;
            get;
        }

        #endregion

    }
}
