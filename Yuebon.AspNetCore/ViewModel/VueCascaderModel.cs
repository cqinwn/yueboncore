using System;
using System.Collections.Generic;
using System.Text;


namespace Yuebon.AspNetCore.ViewModel
{
    /// <summary>
    /// Vue Cascader 级联选择模型
    /// </summary>
    [Serializable]
    public class VueCascaderModel
    {
        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string label { get; set; }


        /// <summary>
        /// 子集
        /// </summary>
        public List<VueCascaderModel> children { get; set; }
    }
}
