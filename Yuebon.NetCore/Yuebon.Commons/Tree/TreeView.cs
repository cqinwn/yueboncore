﻿namespace Yuebon.Commons.Tree
{
    /// <summary>
    /// 
    /// </summary>
    public static class TreeView
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static string TreeViewJson(this List<TreeViewModel> data, string parentId = "")
        {
            StringBuilder strJson = new StringBuilder();
            //List<TreeViewModel> item = data.FindAll(t => t.parentId == parentId);
            //strJson.Append("[");
            //if (item.Count > 0)
            //{
            //    foreach (TreeViewModel entity in item)
            //    {
            //        strJson.Append("{");
            //        strJson.Append("\"id\":\"" + entity.id + "\",");
            //        strJson.Append("\"text\":\"" + entity.text.Replace("&nbsp;", "") + "\",");
            //        strJson.Append("\"value\":\"" + entity.value + "\",");
            //        if (entity.title != null && !string.IsNullOrEmpty(entity.title.Replace("&nbsp;", "")))
            //        {
            //            strJson.Append("\"title\":\"" + entity.title.Replace("&nbsp;", "") + "\",");
            //        }
            //        if (entity.img != null && !string.IsNullOrEmpty(entity.img.Replace("&nbsp;", "")))
            //        {
            //            strJson.Append("\"img\":\"" + entity.img.Replace("&nbsp;", "") + "\",");
            //        }
            //        if (entity.checkstate != null)
            //        {
            //            strJson.Append("\"checkstate\":" + entity.checkstate + ",");
            //        }
            //        if (entity.parentId != null)
            //        {
            //            strJson.Append("\"parentnodes\":\"" + entity.parentId + "\",");
            //        }
            //        strJson.Append("\"showcheck\":" + entity.showcheck.ToString().ToLower() + ",");
            //        strJson.Append("\"isexpand\":" + entity.isexpand.ToString().ToLower() + ",");
            //        if (entity.complete == true)
            //        {
            //            strJson.Append("\"complete\":" + entity.complete.ToString().ToLower() + ",");
            //        }
            //        strJson.Append("\"hasChildren\":" + entity.hasChildren.ToString().ToLower() + ",");
            //        strJson.Append("\"ChildNodes\":" + TreeViewJson(data, entity.id) + "");
            //        strJson.Append("},");
            //    }
            //    strJson = strJson.Remove(strJson.Length - 1, 1);
            //}
            //strJson.Append("]");
            return strJson.ToString();
        }
    }
}
