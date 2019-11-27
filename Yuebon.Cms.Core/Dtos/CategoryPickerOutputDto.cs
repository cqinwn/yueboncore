using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// uni-app 下拉列表输出
    /// </summary>
    [Serializable]
   public class CategoryPickerOutputDto
    {
        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 显示内容
        /// </summary>		
        public virtual string label { get; set; }
    }
}
