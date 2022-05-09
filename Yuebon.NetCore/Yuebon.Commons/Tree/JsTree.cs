using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Json;

namespace Yuebon.Commons.Tree
{
    public static class JsTree
    {

        public static List<JsTreeModel> JsTreeJson(this List<JsTreeModel> data)
        {
            return JsTreeJson(data, 0, "").ToList<JsTreeModel>();
        }
        private static string JsTreeJson(List<JsTreeModel> data, long parentId, string blank)
        {
            List<JsTreeModel> list = new List<JsTreeModel>();
            JsTreeModel jsTreeModel = new JsTreeModel();
            var ChildNodeList = data.FindAll(t => t.parent == parentId);
            var tabline = "";
            if (parentId==0)
            {
                tabline = "";
            }
            if (ChildNodeList.Count > 0)
            {
                tabline = tabline + blank;
            }
            foreach (JsTreeModel entity in ChildNodeList)
            {
                jsTreeModel = entity;
                jsTreeModel.children= JsTreeJson(data, entity.id, tabline).ToList<JsTreeModel>();
                list.Add(jsTreeModel);
                
            }
            return list.ToJson().ToString();
        }
    }
}
