using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.AspNetCore.UI
{
    /// <summary>
    /// Vuex菜单模型
    /// </summary>
    [Serializable]
    public class VuexMenusTreeModel
    {
        /// <summary>
        /// 字符串，对应当前路由的路径，总是解析为绝对路径
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 命名视图组件
        /// </summary>
        public string component { get; set; }
        /// <summary>
        /// 重定向地址，在面包屑中点击会重定向去的地址
        /// </summary>
        public string redirect { get; set; }
        /// <summary>
        /// 当设置 true 的时候该路由不会再侧边栏出现 如401，login等页面，或者如一些编辑页面/edit/1
        /// </summary>
        //public string hidden { get; set; }
        /// <summary>
        /// 设定路由的名字，一定要填写不然使用keep-alive时会出现各种问题
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 在根路由设置权限，这样它下面所以的子路由都继承了这个权限
        /// </summary>
        public Meta meta { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<VuexMenusTreeModel> children { get; set; }
    }
    /// <summary>
    /// VuexMenus路由模型
    /// </summary>
    [Serializable]
    public class VuexMenus
    {
        /// <summary>
        /// 访问路径
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 对应模块
        /// </summary>
        public string component { get; set; }
        /// <summary>
        /// 重定向地址，在面包屑中点击会重定向去的地址
        /// </summary>
        public string redirect { get; set; }
        ///// <summary>
        ///// 当设置 true 的时候该路由不会再侧边栏出现 如401，login等页面，或者如一些编辑页面/edit/1
        ///// </summary>
        //public string hidden { get; set; }
        /// <summary>
        /// 设定路由的名字，一定要填写不然使用keep-alive时会出现各种问题
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Meta meta { get; set; }
    }
    /// <summary>
    /// 路由元信息模型
    /// </summary>
    [Serializable]
    public class Meta
    {
        ///// <summary>
        ///// 设置该路由进入的权限，支持多个权限叠加，可以在根路由设置权限，这样它下面所以的子路由都继承了这个权限
        ///// </summary>
        //public string roles { get; set; }
        /// <summary>
        /// 设置该路由在侧边栏和面包屑中展示的名字
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 设置该路由的图标
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 如果设置为true，则不会被 keep-alive 缓存(默认 false)
        /// </summary>
        //public string noCache { get; set; }
        ///// <summary>
        ///// 如果设置为false，则不会在breadcrumb面包屑中显示,默认设置true
        ///// </summary>
        //public string breadcrumb { get; set; }
    }
}
