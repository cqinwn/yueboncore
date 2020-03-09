using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;
using Yuebon.Commons.Tree;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Controllers;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class ItemsController : BusinessController<Items, IItemsService>
    {
        public ItemsController(IItemsService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.InsertKey = "Items/Add";
            AuthorizeKey.UpdateKey = "Items/Edit";
            AuthorizeKey.DeleteKey = "Items/Delete";
            AuthorizeKey.ListKey = "Items/List";
            AuthorizeKey.ViewKey = "Items/View";
            AuthorizeKey.DeleteSoftKey = "Items/DeleteSoft";
        }


        protected override void OnBeforeInsert(Items info)
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
        protected override void OnBeforeUpdate(Items info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
        }

        /// <summary>
        /// 分类select2树形展开，新增、修改需要
        /// </summary>
        /// <returns></returns>
        public IActionResult FindTreeSelectJson()
        {
            List<Items> list = iService.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (Items item in list)
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
        /// 查询所有字典分类，树形展开，初始化数据字典列表展示需要
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllTreeViewJson()
        {
            ItemsApp itemsApp = new ItemsApp();
            return ToJsonContent(itemsApp.ItemsTreeViewJson());
        }
    }
}