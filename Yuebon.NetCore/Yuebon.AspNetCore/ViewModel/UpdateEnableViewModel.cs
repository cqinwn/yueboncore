using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yuebon.AspNetCore.ViewModel
{
    [Serializable]
    public class UpdateEnableViewModel
    {
        /// <summary>
        /// 主键Id集合
        /// </summary>
        public dynamic[] Ids { get; set; }
        /// <summary>
        /// 有效标识，默认为1：即设为无效,0：有效
        /// </summary>
        public string Flag { get; set; }
    }
}
