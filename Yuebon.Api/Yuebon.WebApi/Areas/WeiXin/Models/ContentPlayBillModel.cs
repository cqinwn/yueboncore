using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yuebon.WebApi.Areas.WeiXin.Models
{
    /// <summary>
    /// 详情页面生成海报传入参数模型
    /// </summary>
    [Serializable]
    public class ContentPlayBillModel
    {

        /// <summary>
        /// 内容Id
        /// </summary>
        public string ContentId
        {
            get;
            set;
        }
        /// <summary>
        /// 内容类型art 文章、job职位等
        /// </summary>
        public string ContentType
        {
            get;
            set;
        }
        /// <summary>
        /// 内容标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 小程序跳转页面
        /// </summary>
        public string Page
        {
            get;
            set;
        }

        /// <summary>
        /// 最大32个可见字符，只支持数字，大小写英文以及部分特殊字符：!#$&'()*+,/:;=?@-._~，其它字符请自行编码为合法字符（因不支持%，中文无法使用 urlencode 处理，请使用其他编码方式）
        /// </summary>
        public string Scene
        {
            get;
            set;
        }


    }
}
