using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yuebon.WebApi.Areas.WeiXin.Models
{
    /// <summary>
    /// 内容安全校验
    /// </summary>
    [Serializable]
    public class CheckMsgModel
    {
        /// <summary>
        /// 校验内容
        /// </summary>
        public string ContenText {
            get;
            set;
        }

    }
}
