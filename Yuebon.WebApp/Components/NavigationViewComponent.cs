using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Json;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApp.Components
{
    [ViewComponent(Name = "Navigation")]
    public class NavigationViewComponent : ViewComponent
    {
        private readonly IMenuService _menuService;
        private readonly IUserService _userService;
        private AuthHelper authHelper;
        public NavigationViewComponent(IMenuService menuService, IUserService userService, AuthHelper _authHelper)
        {
            _menuService = menuService;
            _userService = userService;
            authHelper = _authHelper;
        }

        public IViewComponentResult Invoke()
        {
            //UserWithAccessedCtrls userWithAccessedCtrls = authHelper.GetCurrentUser();
            var userId = HttpContext.Session.GetString("CurrentUserId");
            //var userId = userWithAccessedCtrls.User.Id;
            List<MenuOutputDto> allMenuls = new List<MenuOutputDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            if (yuebonCacheHelper.Exists("User_Menu_" + userId))
            {
                allMenuls = JsonConvert.DeserializeObject<List<MenuOutputDto>>(yuebonCacheHelper.Get("User_Menu_" + userId).ToJson());
            }
            else
            {
                MenuApp menuApp = new MenuApp();
                List<Menu> list = menuApp.GetMenuByUser(userId, "");
                List<Menu> mainMenus = list.FindAll(c => c.Layers == 1);
                foreach (Menu item in mainMenus)
                {
                    MenuOutputDto viewMenu = new MenuOutputDto();
                    viewMenu.Id = item.Id;
                    viewMenu.FullName = item.FullName;
                    viewMenu.Icon = item.Icon;
                    viewMenu.IsMenu = item.IsMenu;
                    viewMenu.IsExpand = item.IsExpand;
                    viewMenu.SortCode = item.SortCode;
                    viewMenu.UrlAddress = item.UrlAddress;
                    viewMenu.EnCode = item.EnCode;
                    List<Menu> subMenus = list.FindAll(c => c.ParentId == item.Id);
                    List<MenuOutputDto> subMenuls = new List<MenuOutputDto>();
                    foreach (Menu sItem in subMenus)
                    {
                        MenuOutputDto subViewMenu = new MenuOutputDto();
                        subViewMenu.Id = sItem.Id;
                        subViewMenu.FullName = sItem.FullName;
                        subViewMenu.Icon = sItem.Icon;
                        subViewMenu.IsMenu = sItem.IsMenu;
                        subViewMenu.IsExpand = sItem.IsExpand;
                        subViewMenu.SortCode = sItem.SortCode;
                        subViewMenu.UrlAddress = sItem.UrlAddress;
                        subViewMenu.EnCode = sItem.EnCode;
                        subMenuls.Add(subViewMenu);
                    }
                    viewMenu.SubMenu = subMenuls.OrderBy(t => t.SortCode).ToList();
                    allMenuls.Add(viewMenu);
                }
                allMenuls = allMenuls.OrderBy(t => t.SortCode).ToList();
                yuebonCacheHelper.Add("User_Menu_" + userId, allMenuls);
            }
            return View(allMenuls);
        }
    }
}