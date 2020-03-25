using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.WebApi.Areas.WMS.Models;
using Yuebon.WMS.Dtos;
using Yuebon.WMS.IServices;
using Yuebon.WMS.Models;

namespace Yuebon.WebApi.Areas.WMS.Controllers
{
    /// <summary>
    /// 商品类别接口
    /// </summary>
    [ApiController]
    [Route("api/WMS/[controller]")]
    public class GoodsCategoriesController : AreaApiController<GoodsCategories, GoodsCategoriesOutputDto, IGoodsCategoriesService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public GoodsCategoriesController(IGoodsCategoriesService _iService) : base(_iService)
        {
            iService = _iService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(GoodsCategories info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
            if (string.IsNullOrEmpty(info.ParentId))
            {
                info.ClassLayer = 1;
                info.ClassPath = info.Id;
                info.ParentId = "";
            }
            else
            {
                info.ClassLayer = iService.Get(info.ParentId).ClassLayer + 1;
                info.ClassPath = info.ParentId + "," + info.Id;
            }
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(GoodsCategories info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
            if (string.IsNullOrEmpty(info.ParentId))
            {
                info.ClassLayer = 1;
                info.ClassPath = info.Id;
                info.ParentId = "";
            }
            else
            {
                info.ClassLayer = iService.Get(info.ParentId).ClassLayer + 1;
                info.ClassPath = info.ParentId + "," + info.Id;
            }
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(GoodsCategories info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }
        /// <summary>
        /// 新增或修改数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost("InsertOrUpdateAsync")]
        [YuebonAuthorize("Add")]
        public async Task<IActionResult> InsertOrUpdateAsync([FromQuery]GoodsCategoriesInputDto info)
        {
            CommonResult result = new CommonResult();

            if (string.IsNullOrEmpty(info.Title))
            {
                result.ErrMsg = "商品名称不能为空";
                return ToJsonContent(result);
            }
            else if (string.IsNullOrEmpty(info.EnCode))
            {
                result.ErrMsg = "商品编码不能为空";
                return ToJsonContent(result);
            }
            if (string.IsNullOrEmpty(info.Id))
            {
                string where = string.Format("EnCode='{0}'", info.EnCode);
                GoodsCategories goods = iService.GetWhere(where);
                if (goods != null)
                {
                    result.ErrMsg = "分类编码不能重复";
                    return ToJsonContent(result);
                }
                GoodsCategories goodsCategories = new GoodsCategories();
                goodsCategories = info.MapTo<GoodsCategories>();
                OnBeforeInsert(goodsCategories);
                long ln = await iService.InsertAsync(goodsCategories).ConfigureAwait(true);
                result.Success = ln > 0;
            }
            else
            {
                string where = string.Format("EnCode='{0}' and id!='{1}'", info.EnCode, info.Id);
                GoodsCategories goods = iService.GetWhere(where);
                if (goods != null)
                {
                    result.ErrMsg = "分类编码不能重复";
                    return ToJsonContent(result);
                }
                GoodsCategories goodsCategories = new GoodsCategories();
                goodsCategories = iService.Get(info.Id);
                goodsCategories.ParentId = info.ParentId;
                goodsCategories.EnCode = info.EnCode;
                goodsCategories.EnabledMark = info.EnabledMark;
                goodsCategories.Title = info.Title;
                goodsCategories.SortCode = info.SortCode;
                OnBeforeUpdate(goodsCategories);
                result.Success = await iService.UpdateAsync(goodsCategories,info.Id).ConfigureAwait(true);
            }
            if (result.Success)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.Success = false;
                result.ErrMsg = ErrCode.err43001;
                result.ErrCode = "43001";
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetDetailById")]
        [YuebonAuthorize("View")]
        public async Task<IActionResult> GetDetailById(string id)
        {
            CommonResult result = new CommonResult();
            GoodsCategoriesOutputDto goodsCategoriesOutputDto= await iService.GetOutDtoAsync(id);
            result.ResData = goodsCategoriesOutputDto;
            result.Success = true;
            return ToJsonContent(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetAlldEnabledMark")]
        [NoPermissionRequired]
        public async Task<IActionResult> GetAlldEnabledMark()
        {
            CommonResult result = new CommonResult();
            IEnumerable<GoodsCategories> list = await iService.GetAllByIsNotDeleteAndEnabledMarkAsync();
            result.ResData = list.MapTo<GoodsCategoriesOutputDto>();
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithPager1Async")]
        [YuebonAuthorize("List")]
        public  async Task<IActionResult> FindWithPager1Async([FromQuery]SearchGoodsCategoriesModel search)
        {
            CommonResult result = new CommonResult();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString())? "" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "SortCode" : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition();
            if (!string.IsNullOrEmpty(search.Title))
            {
                where += " and Title like '%" + search.Title + "%'";
            };
            if (!string.IsNullOrEmpty(search.EnCode))
            {
                where += " and EnCode like '%" + search.EnCode + "%'";
            };
            if (!string.IsNullOrEmpty(search.ParentId))
            {
                where += " and ParentId = '" + search.ParentId + "'";
            };
            PagerInfo pagerInfo = GetPagerInfo();
            List<GoodsCategories> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<GoodsCategoriesOutputDto> resultList = list.MapTo<GoodsCategoriesOutputDto>();
            PageResult<GoodsCategoriesOutputDto> pageResult = new PageResult<GoodsCategoriesOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = resultList,
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            result.ResData = pageResult;
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }
    }
}