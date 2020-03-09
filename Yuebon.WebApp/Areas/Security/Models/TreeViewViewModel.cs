using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Tree;

namespace Yuebon.WebApp.Areas.Security.Models
{
    public class TreeViewViewModel
    {

        public string nodeId { get; set; }    //树的节点Id，区别于数据库中保存的数据Id。
        public string pid { get; set; }
        public string text { get; set; }  //节点名称
        public string icon { get; set; }
        public string href { get; set; }   //点击节点触发的链接
        public List<TreeViewModel> nodes { get; set; }
        public string tags { get; set; }
        public string parentId { get; set; }
        public bool selectable { get; set; }
    }
}
