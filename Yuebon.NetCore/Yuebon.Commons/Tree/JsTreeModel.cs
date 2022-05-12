using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Tree
{
    /// <summary>
    /// JsTree 数据模型实体
    /// {
    ///     id          : "string" // required
    ///     parent      : "string" // required
    ///     text        : "string" // node text
    ///     icon        : "string" // string for custom
    ///     state       : {
    ///         opened    : boolean  // is the node open
    ///         disabled  : boolean  // is the node disabled
    ///         selected  : boolean  // is the node selected
    ///     },
    ///     li_attr     : {}  // attributes for the generated LI node
    ///     a_attr      : {}  // attributes for the generated A node
    /// }
    /// </summary>
    public class JsTreeModel
    {
        public long id { get; set; }
        public long? parent { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public JsTreeStateModel state { get; set; }
        public List<JsTreeModel> children { get; set; }
    }
    public class JsTreeStateModel
    {
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
    }
    }
