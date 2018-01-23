using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AspNetCore.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Api.Controllers
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    [Produces("application/json")]
    [Route("api/Menus")]
    public class MenusController : Controller
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Menu>), (int)HttpStatusCode.OK)]
        public IActionResult GetMenus()
        {
            var menuList = new List<Menu>()
            {
                new Menu(){
                Text = "主导航",
                Group = true,
                Children = new List<Menu>
                {
                    new Menu
                    {
                        Text = "仪表盘",
                        Link = "/dashboard",
                        Icon = "icon-speedometer"
                    },
                    new Menu
                    {
                        Text = "快捷菜单",
                        Icon = "icon-rocket",
                        Shortcut_root = true
                    },
                    new Menu
                    {
                        Text = "Api接口测试",
                        Link = "/apiValues",
                        Icon = "icon-rocket"
                    },
                    new Menu
                    {
                        Text = "产品",
                        Link = "/products/list",
                        Icon = "icon-handbag"
                    }
                }
                }
            };

            return Ok(menuList);
        }
    }
}