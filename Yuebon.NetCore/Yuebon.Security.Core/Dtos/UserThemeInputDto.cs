using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 用户自定义主题
    /// </summary>
    [Serializable]
    public class UserThemeInputDto
    {
        /// <summary>
        /// 主题颜色
        /// </summary>
        public string Theme { set; get; }

        /// <summary>
        /// 主题风格
        /// </summary>
        public string SideTheme { set; get; }
        /// <summary>
        /// 是否固定 Header
        /// </summary>
        public bool FixedHeader { set; get; }
        /// <summary>
        /// 是否开启 Tags-Views
        /// </summary>
        public bool TagsView { set; get; }
        /// <summary>
        /// 是否显示 Logo
        /// </summary>
        public bool SidebarLogo { set; get; }
    }
}
