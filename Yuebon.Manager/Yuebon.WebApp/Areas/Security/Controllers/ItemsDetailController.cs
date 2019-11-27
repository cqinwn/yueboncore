using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Tree;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Controllers;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class ItemsDetailController : BusinessController<ItemsDetail, IItemsDetailService>
    {
        private IItemsService itemsService;
        public ItemsDetailController(IItemsDetailService _iService, IItemsService _itemsService) : base(_iService)
        {
            itemsService = _itemsService;
            //AuthorizeKey.InsertKey = "Items/Add";
            //AuthorizeKey.UpdateKey = "Items/Edit";
            //AuthorizeKey.DeleteKey = "Items/Delete";
            //AuthorizeKey.ListKey = "Items/List";
            //AuthorizeKey.ViewKey = "Items/View";
        }

        protected override void OnBeforeInsert(ItemsDetail info)
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
            bool bltree = itemsService.Get(info.ItemId).IsTree;
            if (bltree)
            {
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
            else
            {
                info.ParentId = "";
            }

        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(ItemsDetail info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
            bool bltree = itemsService.Get(info.ItemId).IsTree;
            if (bltree)
            {
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
            else
            {
                info.ParentId = "";
            }
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
                result.ResData = iService.Get(id).MapTo<ItemsDetailOutputDto>();
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

            Yuebon.Commons.Pages.PagerInfo pagerInfo = GetPagerInfo();
            List<ItemsDetailOutputDto> listResult = new List<ItemsDetailOutputDto>();
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "SortCode" : Request.Query["sort"].ToString();
            string itemId = Request.Query["itemid"].ToString() == null ? "" : Request.Query["itemid"].ToString();
            string where = "1=1";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(itemId))
            {
                where += string.Format(" and  ItemId='{0}'", itemId);

                if (!string.IsNullOrEmpty(keywords))
                {
                    where += string.Format(" and ( FullName like '%{0}%' or EnCode like '%{0}%')", keywords);
                }
                if (orderFlied == "SystemTypeName") orderFlied = "SystemTypeId";
                if (orderFlied == "ParentName") orderFlied = "ParentId";
                List<ItemsDetail> list = iService.FindWithPager(where, pagerInfo, orderFlied, false);
                foreach (ItemsDetail item in list)
                {
                    ItemsDetailOutputDto ItemsDetailOutputDto = new ItemsDetailOutputDto();
                    ItemsDetailOutputDto.Id = item.Id;
                    ItemsDetailOutputDto.ItemName = item.ItemName;
                    ItemsDetailOutputDto.ItemCode = item.ItemCode;
                    ItemsDetailOutputDto.EnabledMark = item.EnabledMark;
                    ItemsDetailOutputDto.Description = item.Description;
                    ItemsDetailOutputDto.SortCode = item.SortCode;
                    ItemsDetailOutputDto.IsDefault = item.IsDefault;
                    if (!string.IsNullOrEmpty(item.ParentId))
                    {
                        ItemsDetailOutputDto.ParentName = iService.Get(item.ParentId).ItemName;
                    }
                    ItemsDetailOutputDto.ParentId = item.ParentId;
                    ItemsDetailOutputDto.CreatorTime = item.CreatorTime;
                    listResult.Add(ItemsDetailOutputDto);
                }
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
        /// 分类select2树形展开，新增、修改需要
        /// </summary>
        /// <returns></returns>
        public IActionResult FindTreeSelectJson()
        {
            List<ItemsDetail> list = iService.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (ItemsDetail item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.ItemName;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            return ToJsonContent(treeList.TreeSelectJson());
        }


        /// <summary>
        /// 根据类型获取内容select2
        /// </summary>
        /// <param name="itemName">分类名称</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindSelectJson(string itemName)
        {
            string sqlWhere = string.Format("FullName='{0}'", itemName);
            Items info = itemsService.GetWhere(sqlWhere);
            sqlWhere = string.Format("ItemId='{0}'", info.Id);
            List<ItemsDetail> list = iService.GetAllByIsNotDeleteAndEnabledMark(sqlWhere).OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (ItemsDetail item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.ItemCode;
                treeModel.text = item.ItemName;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            return ToJsonContent(treeList.TreeSelectJson());
        }
    }
}