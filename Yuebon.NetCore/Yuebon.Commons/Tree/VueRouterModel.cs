using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Tree
{
    /// <summary>
    /// Vuex菜单模型
    /// </summary>
    [Serializable]
    public class VueRouterModel
    {
        /// <summary>
        /// 设定路由的名字，一定要填写不然使用keep-alive时会出现各种问题
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 路由地址，对应当前路由的路径，总是解析为绝对路径
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 是否隐藏路由，当设置 true 的时候该路由不会再侧边栏出现
        /// </summary>
        public bool hidden { get; set; }
        /// <summary>
        /// 命名视图组件,组件地址
        /// </summary>
        public string component{ get; set; }
        /// <summary>
        /// 重定向地址，当设置 noRedirect 的时候该路由在面包屑导航中不可被点击
        /// </summary>
        public string redirect { get; set; }
        /// <summary>
        /// 当你一个路由下面的 children 声明的路由大于1个时，自动会变成嵌套的模式--如组件页面
        /// </summary>
        public bool alwaysShow { get; set; }
        /// <summary>
        /// 在根路由设置权限，这样它下面所以的子路由都继承了这个权限
        /// </summary>
        public Meta meta { get; set; }
        /// <summary>
        /// 子路由,子菜单
        /// </summary>
        public List<VueRouterModel> children { get; set; }
    }
    /// <summary>
    /// 路由元信息模型
    /// </summary>
    [Serializable]
    public class Meta
    {
        public Meta(string title, string icon, bool noCache)
        {
            this.title = title;
            this.icon = icon;
            this.noCache = noCache;
        }

        /// <summary>
        /// 设置该路由在侧边栏和面包屑中展示的名字
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 设置该路由的图标
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 设置为true，则不会被 <keep-alive>缓存
        /// </summary>
        public bool noCache { get; set; }
    }
}
