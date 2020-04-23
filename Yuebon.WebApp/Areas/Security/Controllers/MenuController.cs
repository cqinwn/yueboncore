using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Areas.Security.Models;
using Yuebon.WebApp.Controllers;
using Yuebon.WebApp.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Tree;
using Yuebon.Security.Application;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Security.Dtos;
using Yuebon.Commons.Mapping;
using System.Reflection;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class MenuController : BusinessController<Menu, MenuInputDto, IMenuService, string>
    {
        private IUserService userService;
        private IRoleAuthorizeService roleAuthorizeService;
        private ISystemTypeService systemTypeService;
        public MenuController(IMenuService _iService, IUserService _userService, IRoleAuthorizeService _roleAuthorizeService, ISystemTypeService _systemTypeService) : base(_iService)
        {
            iService = _iService;
            userService = _userService;
            roleAuthorizeService = _roleAuthorizeService;
            systemTypeService = _systemTypeService;

            AuthorizeKey.InsertKey = "Menu/Add";
            AuthorizeKey.UpdateKey = "Menu/Edit";
            AuthorizeKey.DeleteKey = "Menu/Delete";
            AuthorizeKey.UpdateEnableKey = "Menu/Enable";
            AuthorizeKey.ListKey = "Menu/List";
            AuthorizeKey.ViewKey = "Menu/View";
            AuthorizeKey.DeleteSoftKey = "Menu/DeleteSoft";
        }
        protected override void OnBeforeInsert(Menu info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.DeleteMark = false;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
            if (string.IsNullOrEmpty(info.ParentId))
            {
                info.Layers = 1;
                info.ParentId = "";
            }
            else
            {
                info.Layers = iService.Get(info.ParentId).Layers + 1;
            }

        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Menu info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime  = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
        }

        [HttpPost]
        public override IActionResult Insert(Menu info)
        {
            CommonResult result = new CommonResult();
            OnBeforeInsert(info);

            long ln = iService.Insert(info);
            if (ln >=0)
            {
                result.Success = true;
            }
            else
            {
                result.ErrCode = "43001";
            }
            return ToJsonContent(result);
        }

        [HttpPost]
        public override IActionResult Update(IFormCollection formValues, string id)
        {
            Menu obj = iService.Get(id);
            if (obj != null)
            {
                //遍历提交过来的数据（可能是实体类的部分属性更新）
                foreach (string key in formValues.Keys)
                {
                    string value = formValues[key];
                    System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(key);
                    if (propertyInfo != null)
                    {
                        try
                        {
                            // obj对象有key的属性，把对应的属性值赋值给它(从字符串转换为合适的类型）
                            //如果转换失败，会抛出InvalidCastException异常
                            propertyInfo.SetValue(obj, ConvertHelper.ChangeType(value, propertyInfo.PropertyType), null);
                        }
                        catch(Exception ex) {
                            Log4NetHelper.Error("更新菜单异常", ex);//错误记录
                        
                        }
                    }
                }
            }
            CommonResult result = new CommonResult();
            OnBeforeUpdate(obj);
            if (string.IsNullOrEmpty(obj.ParentId))
            {
                obj.Layers = 1;
                obj.ParentId = "";
            }
            else
            {
                obj.Layers = iService.Get(obj.ParentId).Layers + 1;
            }
            bool bl = iService.Update(obj,id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
                result.Success = true;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据ID获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override IActionResult GetById(string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ViewKey);
            CommonResult result = new CommonResult();
            try
            {
                result.ResData = iService.Get(id).MapTo<MenuInputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error("获取菜单异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据用户查询可用菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public  IActionResult FindMenuUserId(string userId)
        {
            CommonResult result = new CommonResult();
            List<ViewMenu> allMenuls = new List<ViewMenu>();
           
            List<Menu> list= iService.GetMenuByUser(userId);
            List<Menu> mainMenus = list.FindAll(c => c.Layers == 1);
            foreach (Menu item in mainMenus)
            {
                ViewMenu viewMenu = new ViewMenu();
                viewMenu.Id = item.Id;
                viewMenu.FullName = item.FullName;
                viewMenu.Icon = item.Icon;
                viewMenu.IsMenu = item.IsMenu;
                viewMenu.IsExpand = item.IsExpand;
                viewMenu.SortCode = item.SortCode;
                viewMenu.UrlAddress = item.UrlAddress;
                List<Menu> subMenus = list.FindAll(c => c.ParentId == item.Id);
                List<ViewMenu> subMenuls = new List<ViewMenu>();
                foreach (Menu sItem in subMenus)
                {
                    ViewMenu subViewMenu = new ViewMenu();
                    subViewMenu.Id = sItem.Id;
                    subViewMenu.FullName = sItem.FullName;
                    subViewMenu.Icon = sItem.Icon;
                    subViewMenu.IsMenu = sItem.IsMenu;
                    subViewMenu.IsExpand = sItem.IsExpand;
                    subViewMenu.SortCode = sItem.SortCode;
                    subViewMenu.UrlAddress = sItem.UrlAddress;
                    subMenuls.Add(subViewMenu);
                }
                viewMenu.SubMenu = subMenuls;
                allMenuls.Add(viewMenu);
            }
            result.Success = true;
            result.ResData = allMenuls.OrderBy(t => t.SortCode).ToList();
            return ToJsonContent(result);
        }


        /// <summary>
        /// 根据父类查询所有子类菜单
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult FindMenuParentId(string parentId)
        {
            CommonResult result = new CommonResult();
            string where = string.Format("parentId='{0}'", parentId);
            List<Menu> list = iService.GetListWhere(where).OrderBy(t => t.SortCode).ToList();
           
            result.Success = true;
            result.ResData = list;
            return ToJsonContent(result);
        }
        /// <summary>
        /// 根据父类查询所有子类菜单
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindTreeSelectJson()
        {
            List<Menu> list = iService.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList();
            
            var treeList = new List<TreeSelectModel>();
            foreach (Menu item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.FullName;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            return ToJsonContent(treeList.TreeSelectJson());
        }

        

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            //base.CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "Layers" : Request.Query["sort"].ToString();
            string where = "1=1";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (FullName like '%{0}%' or EnCode like '%{0}%')", keywords);
            }


            List<Menu> list = iService.GetListWhere(where).OrderBy(t => t.SortCode).ToList();
            List<MenuInputDto> listResult = new List<MenuInputDto>();
            foreach (Menu item in list)
            {
                MenuInputDto MenuOutputDto = new MenuInputDto();
                MenuOutputDto.Id = item.Id;
                MenuOutputDto.FullName = item.FullName;
                MenuOutputDto.EnCode = item.EnCode;
                MenuOutputDto.Icon = item.Icon;
                MenuOutputDto.ParentId = item.ParentId;
                MenuOutputDto.Layers = item.Layers;
                MenuOutputDto.UrlAddress = item.UrlAddress;
                MenuOutputDto.Target = item.Target;
                MenuOutputDto.IsMenu = item.IsMenu;
                MenuOutputDto.IsExpand = item.IsExpand;
                MenuOutputDto.IsPublic = item.IsPublic;
                MenuOutputDto.EnabledMark = item.EnabledMark;
                MenuOutputDto.CreatorTime = item.CreatorTime;
                MenuOutputDto.SystemTypeId = item.SystemTypeId;
                MenuOutputDto.SortCode = item.SortCode;
                MenuOutputDto.SystemTypeName = systemTypeService.Get(item.SystemTypeId).FullName;
                listResult.Add(MenuOutputDto);
            }
            return ToJsonContent(listResult);
        }
    }
}