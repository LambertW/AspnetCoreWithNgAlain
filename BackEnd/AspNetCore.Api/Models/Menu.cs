using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Models
{
    /// <summary>
    /// 菜单项
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// i18n主键
        /// </summary>
        public string I18n { get; set; }

        /// <summary>
        /// 是否菜单组
        /// </summary>
        public bool? Group { get; set; }

        /// <summary>
        /// angular 路由
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 外部链接
        /// </summary>
        public string ExternalLink { get; set; }

        /// <summary>
        /// 链接 Target
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 徽标数，展示的数字。（注：`group:true` 无效）
        /// </summary>
        public string Badge { get; set; }

        /// <summary>
        /// 徽标数，显示小红点
        /// </summary>
        public bool? Badge_dot { get; set; }

        /// <summary>
        /// 徽标数，设置 Badge 颜色
        /// </summary>
        public string Badge_status { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool? Hide { get; set; }

        /// <summary>
        /// TODO ACL配置 
        /// </summary>
        public string Acl { get; set; }

        /// <summary>
        /// 是否快捷菜单项
        /// </summary>
        public bool? Shortcut { get; set; }

        /// <summary>
        /// 快捷菜单根节点
        /// </summary>
        public bool? Shortcut_root { get; set; }

        /// <summary>
        /// 是否允许服用
        /// </summary>
        public bool? Reuse { get; set; }

        /// <summary>
        /// 二级菜单
        /// </summary>
        public ICollection<Menu> Children { get; set; }
    }
}
