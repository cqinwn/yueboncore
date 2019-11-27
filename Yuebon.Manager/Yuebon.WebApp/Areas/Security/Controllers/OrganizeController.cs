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
using Yuebon.Commons.Tree;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Commons.Mapping;
using System.Reflection;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class OrganizeController : BusinessController<Organize, IOrganizeService>
    {
        public OrganizeController(IOrganizeService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.InsertKey = "Organize/Add";
            AuthorizeKey.UpdateKey = "Organize/Edit";
            AuthorizeKey.DeleteKey = "Organize/Delete";
            AuthorizeKey.UpdateEnableKey = "Organize/Enable";
            AuthorizeKey.ListKey = "Organize/List";
            AuthorizeKey.ViewKey = "Organize/View";
            AuthorizeKey.DeleteSoftKey = "Organize/DeleteSoft";
        }

        protected override void OnBeforeInsert(Organize info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.DeleteMark = false;

        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Organize info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
        }
        [HttpPost]
        public override IActionResult Insert(Organize info)
        {   
            CommonResult result = new CommonResult();
            OnBeforeInsert(info);
            if (string.IsNullOrEmpty(info.ParentId))
            {
                info.Layers = 1;
                info.ParentId = "";
            }
            else
            {
                info.Layers = iService.Get(info.ParentId).Layers + 1;
            }
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }

            long ln = iService.Insert(info);
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
            Organize obj = iService.Get(id);
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
                            var type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
                            Log4NetHelper.WriteError(type, ex);//错误记录
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
                result.ResData = iService.Get(id).MapTo<OrganizeOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.WriteError(type, ex);//错误记录
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
            CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "Layers" : Request.Query["sort"].ToString();
            string where = "1=1";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (FullName like '%{0}%' or EnCode like '%{0}%')", keywords);
            }

            PagerInfo pagerInfo = GetPagerInfo();
            List<Organize> list = iService.FindWithPager(where, pagerInfo, orderFlied, order);

            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = list
            };
            return ToJsonContent(result);
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
            List<OrganizeOutputDto> list = iService.GetListWhere(where).ToList().MapTo<OrganizeOutputDto>();

            //构造成Json的格式传递
            var result = new
            {
                total = list.Count,
                rows = list
            };
            return ToJsonContent(list);
        }

        /// <summary>
        /// 根据父类查询所有子类菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindTreeSelectJson()
        {
            List<Organize> list = iService.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (Organize item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.FullName;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            return ToJsonContent(treeList.TreeSelectJson());
        }
    }
}