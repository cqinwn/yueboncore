
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Extensions;

namespace Yuebon.Commons.Tree
{
    /// <summary>
    /// 树形视图模型
    /// </summary>
    public class TreeViewModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TreeViewModel()
        {
            this.nodes = new List<TreeViewModel>();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nodeId">j节点Id</param>
        /// <param name="pId">父节点Id</param>
        public TreeViewModel(string nodeId, string pId)
        {
            this.nodeId = nodeId;
            this.pid = pId;
            this.nodes = new List<TreeViewModel>();
        }
        /**
         * 生成一个节点
         * @param nodeId
         * @param pId
         * @param text
         * @param icon
         * @param href
         */
        public TreeViewModel(string nodeId, string pId, string text, string icon, string href)
        {
            this.nodeId = nodeId;
            this.pid = pId;
            this.text = text;
            this.icon = icon;
            this.href = href;
            this.nodes = new List<TreeViewModel>();
        }
        /// <summary>
        /// 树的节点Id，区别于数据库中保存的数据Id
        /// </summary>
        public string nodeId { get; set; }
        /// <summary>
        /// 树的父节点Id
        /// </summary>
        public string pid { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string text { get; set; }  
        /// <summary>
        /// 节点图标
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 点击节点触发的链接
        /// </summary>
        public string href { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public List<TreeViewModel> nodes { get; set; }
        /// <summary>
        /// 节点标签
        /// </summary>
        public string tags { get; set; }
        /// <summary>
        /// 节点状态
        /// </summary>
        public TreeViewSateModel state { get; set; }

    }
    /// <summary>
    /// 树形视图节点选择状态
    /// </summary>
    public class TreeViewSateModel
    {
        /// <summary>
        /// 选中
        /// </summary>
        public bool @checked { get; set; }
        /// <summary>
        /// 显示或隐藏
        /// </summary>
        public bool? disabled { get; set; }
        /// <summary>
        /// 展开
        /// </summary>
        public bool? expanded { get; set; }
        /// <summary>
        /// 选中
        /// </summary>
        public bool? selected { get; set; }
    }
}
