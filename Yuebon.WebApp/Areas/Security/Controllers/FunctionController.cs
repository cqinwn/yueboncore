using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Controllers;
using Yuebon.WebApp.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Commons.Tree;
using Yuebon.Security.Application;
using Yuebon.Commons.Mapping;
using System.Reflection;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class FunctionController : BusinessController<Function, IFunctionService>
    {
        private IMenuService menuService;
        private ISystemTypeService systemTypeService;
        public FunctionController(IFunctionService _iService, IMenuService _menuService, ISystemTypeService _systemTypeService) : base(_iService)
        {
            iService = _iService;
            menuService = _menuService;
            systemTypeService = _systemTypeService;

            AuthorizeKey.InsertKey = "Function/Add";
            AuthorizeKey.UpdateKey = "Function/Edit";
            AuthorizeKey.DeleteKey = "Function/Delete";
            AuthorizeKey.UpdateEnableKey = "Function/Enable";
            AuthorizeKey.ListKey = "Function/List";
            AuthorizeKey.ViewKey = "Function/View";
            AuthorizeKey.DeleteSoftKey = "Function/DeleteSoft";
        }

        protected override void OnBeforeInsert(Function info)
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
        protected override void OnBeforeUpdate(Function info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
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


        [HttpPost]
        public override IActionResult Insert(Function info)
        {
            CommonResult result = new CommonResult();

            long ln = 0;
            if (info.AllowEdit==true)
            {
                string strEnCode = info.EnCode;
                Function listInfo = new Function();
                listInfo = info;
                listInfo.FullName = info.FullName + "列表";
                listInfo.EnCode = strEnCode + "/List";
                listInfo.Icon = "";
                OnBeforeInsert(listInfo);
                string listId = listInfo.Id;
                ln = iService.Insert(listInfo);

                Function addInfo = new Function();
                addInfo = info;
                addInfo.Id = GuidUtils.CreateNo();
                addInfo.FullName = "新增";
                addInfo.EnCode = strEnCode + "/Add";
                addInfo.ParentId = listId;
                addInfo.Icon = "fas fa-plus";
                addInfo.SortCode = 1;
                OnBeforeInsert(addInfo);
                ln = iService.Insert(addInfo);

                Function editnfo = new Function();
                editnfo = info;
                editnfo.Id = GuidUtils.CreateNo();
                editnfo.FullName = "修改";
                editnfo.EnCode = strEnCode + "/Edit";
                editnfo.ParentId = listId;
                editnfo.Icon = "fas fa-edit";
                editnfo.SortCode = 2;
                OnBeforeInsert(editnfo);
                ln = iService.Insert(editnfo);


                Function enableInfo = new Function();
                enableInfo = info;
                enableInfo.Id = GuidUtils.CreateNo();
                enableInfo.FullName = "禁用";
                enableInfo.EnCode = strEnCode + "/Enable";
                enableInfo.ParentId = listId;
                enableInfo.Icon = "fa fa-stop-circle";
                enableInfo.SortCode = 3;
                OnBeforeInsert(enableInfo);
                ln = iService.Insert(enableInfo);


                Function enableInfo1 = new Function();
                enableInfo1 = info;
                enableInfo1.Id = GuidUtils.CreateNo();
                enableInfo1.FullName = "启用";
                enableInfo1.EnCode = strEnCode + "/Enable";
                enableInfo1.ParentId = listId;
                enableInfo1.Icon = "fa fa-play-circle";
                enableInfo1.SortCode = 4;
                OnBeforeInsert(enableInfo1);
                ln = iService.Insert(enableInfo1);


                Function deleteSoftInfo = new Function();
                deleteSoftInfo = info;
                deleteSoftInfo.Id = GuidUtils.CreateNo();
                deleteSoftInfo.FullName = "软删除";
                deleteSoftInfo.EnCode = strEnCode + "/DeleteSoft";
                deleteSoftInfo.ParentId = listId;
                deleteSoftInfo.Icon = "fas fa-trash-alt";
                deleteSoftInfo.SortCode = 5;
                OnBeforeInsert(deleteSoftInfo);
                ln = iService.Insert(deleteSoftInfo);


                Function deleteInfo = new Function();
                deleteInfo = info;
                deleteInfo.Id = GuidUtils.CreateNo();
                deleteInfo.FullName = "删除";
                deleteInfo.EnCode = strEnCode + "/Delete";
                deleteInfo.ParentId = listId;
                deleteInfo.Icon = "fas fa-trash-alt";
                deleteInfo.SortCode = 6;
                OnBeforeInsert(deleteInfo);
                ln = iService.Insert(deleteInfo);
            }
            else
            {
                OnBeforeInsert(info);
                ln = iService.Insert(info);
            }

            if (ln >= 0)
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
            Function obj = iService.Get(id);
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
                        catch (Exception ex)
                        {
                            Log4NetHelper.Error("更新功能异常", ex);//错误记录

                        }
                    }
                }
            }
            CommonResult result = new CommonResult();
            OnBeforeUpdate(obj);
           
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
                result.ResData = iService.Get(id).MapTo<FunctionOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取功能异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public override IActionResult FindWithPager()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            //base.CheckAuthorized(AuthorizeKey.ListKey);

            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "SystemTypeId desc,ParentId desc,SortCode " : Request.Query["sort"].ToString();
            string where = string.Empty;
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" FullName like '%{0}%' or EnCode like '%{0}%'", keywords);
            }
            if (orderFlied == "SystemTypeName") orderFlied = "SystemTypeId";
            if (orderFlied == "ParentName") orderFlied = "ParentId";
            Yuebon.Commons.Pages.PagerInfo pagerInfo = GetPagerInfo();
            List<Function> list = iService.FindWithPager(where, pagerInfo, orderFlied, false);
            List<FunctionOutputDto> listResult = new List<FunctionOutputDto>();
            foreach (Function item in list)
            {
                FunctionOutputDto FunctionOutputDto = new FunctionOutputDto();
                FunctionOutputDto.Id = item.Id;
                FunctionOutputDto.FullName = item.FullName;
                FunctionOutputDto.EnCode = item.EnCode;
                FunctionOutputDto.EnabledMark = item.EnabledMark;
                FunctionOutputDto.Description = item.Description;
                FunctionOutputDto.SortCode = item.SortCode;
                FunctionOutputDto.Icon = item.Icon;
                if (!string.IsNullOrEmpty(item.ParentId))
                {
                    FunctionOutputDto.ParentName = iService.Get(item.ParentId).FullName;
                }
                FunctionOutputDto.ParentId = item.ParentId;
                FunctionOutputDto.SystemTypeId = item.SystemTypeId;
                FunctionOutputDto.SystemTypeName = systemTypeService.Get(item.SystemTypeId).FullName;
                FunctionOutputDto.CreatorTime = item.CreatorTime;
                listResult.Add(FunctionOutputDto);
            }
            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = listResult
            };
            return ToJsonContent(result);
        }


        /// <summary>
        /// 根据父类查询所有子类菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindTreeSelectJson()
        {
            List<Function> list = iService.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (Function item in list)
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
        /// 根据父类查询所有子类菜单
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindAllJSTreeJson()
        {
            FunctionApp functionApp = new FunctionApp();
            return ToJsonContent(functionApp.FuntionTreeViewJson());
        }
    }
}