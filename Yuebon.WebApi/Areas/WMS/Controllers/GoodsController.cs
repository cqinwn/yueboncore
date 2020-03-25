using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.WMS.Dtos;
using Yuebon.WMS.Models;
using Yuebon.WMS.IServices;
using Yuebon.AspNetCore.UI;
using Yuebon.AspNetCore.Mvc;

namespace Yuebon.WebApi.Areas.WMS.Controllers
{
    /// <summary>
    /// 商品接口
    /// </summary>
    [ApiController]
    [Route("api/WMS/[controller]")]
    public class GoodsController : AreaApiController<Goods, GoodsOutputDto, IGoodsService, string>
    {
        private readonly IGoodsCategoriesService goodsCategoriesService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public GoodsController(IGoodsService _iService, IGoodsCategoriesService _goodsCategoriesService) : base(_iService)
        {
            iService = _iService;
            goodsCategoriesService = _goodsCategoriesService;
            AuthorizeKey.ListKey = "Goods/List";
            AuthorizeKey.InsertKey = "Goods/Add";
            AuthorizeKey.UpdateKey = "Goods/Edit";
            AuthorizeKey.UpdateEnableKey = "Goods/Enable";
            AuthorizeKey.DeleteKey = "Goods/Delete";
            AuthorizeKey.DeleteSoftKey = "Goods/DeleteSoft";
            AuthorizeKey.ViewKey = "Goods/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Goods info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
            if (!string.IsNullOrEmpty(info.CategoryId))
            {
                GoodsCategories goodsCategories = goodsCategoriesService.Get(info.CategoryId);
                if (goodsCategories != null)
                {
                    info.CategoryName = goodsCategories.Title;
                }
            }
            info.Volume = (info.GoodsLong * info.GoodWidth * info.Height)/1000;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Goods info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
            if (!string.IsNullOrEmpty(info.CategoryId))
            {
                GoodsCategories goodsCategories = goodsCategoriesService.Get(info.CategoryId);
                if (goodsCategories != null)
                {
                    info.CategoryName = goodsCategories.Title;
                }
            }
            info.Volume = (info.GoodsLong * info.GoodWidth * info.Height) / 1000;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Goods info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }

        /// <summary>
        /// 异步新增或修改数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>

        [HttpPost("InsertOrUpdateAsync")]
        [YuebonAuthorize("Add")]
        public async Task<IActionResult> InsertOrUpdateAsync([FromQuery]GoodsInputDto info)
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
            else if (string.IsNullOrEmpty(info.BaseUnit))
            {
                result.ErrMsg = "请选择基本单位";
                return ToJsonContent(result);
            }
            else if (string.IsNullOrEmpty(info.StoreTemperatureLayer))
            {
                result.ErrMsg = "请选择存放温层";
                return ToJsonContent(result);
            }
            else if (string.IsNullOrEmpty(info.CategoryId))
            {
                result.ErrMsg = "请选择商品分类";
                return ToJsonContent(result);
            }
            else if (string.IsNullOrEmpty(info.OwnerCustormerId))
            {
                result.ErrMsg = "请选择所属客户";
                return ToJsonContent(result);
            }
            else if (info.Weight==0M)
            {
                result.ErrMsg = "请填写重量";
                return ToJsonContent(result);
            }

            if (string.IsNullOrEmpty(info.Id))
            {
                string where = string.Format("EnCode='{0}'", info.EnCode);
                Goods goodsIsExist = iService.GetWhere(where);
                if (goodsIsExist != null)
                {
                    result.ErrMsg = "商品编码不能重复";
                    return ToJsonContent(result);
                }
                Goods goods = new Goods();
                goods = info.MapTo<Goods>();
                OnBeforeInsert(goods);
                long ln = await iService.InsertAsync(goods).ConfigureAwait(true);
                result.Success = ln > 0;
            }
            else
            {
                string where = string.Format("EnCode='{0}' and id!='{1}'", info.EnCode, info.Id);
                Goods goodsIsExist = iService.GetWhere(where);
                if (goodsIsExist != null)
                {
                    result.ErrMsg = "商品编码不能重复";
                    return ToJsonContent(result);
                }
                Goods goods = iService.Get(info.Id);
                goods.Title = info.Title;
                goods.EnTitle = info.EnTitle;
                goods.OtherTitle = info.OtherTitle;
                goods.EnCode = info.EnCode;
                goods.CustomerEnCode = info.CustomerEnCode;
                goods.CategoryId = info.CategoryId;
                goods.OwnerCustormerId = info.OwnerCustormerId;
                goods.StoreTemperatureLayer = info.StoreTemperatureLayer;
                goods.Price = info.Price;
                goods.BarCode = info.BarCode;
                goods.Specs = info.Specs;
                goods.Brand = info.Brand;
                goods.BaseUnit = info.BaseUnit;
                goods.Weight = info.Weight;
                goods.GoodsLong = info.GoodsLong;
                goods.GoodWidth = info.GoodWidth;
                goods.Height = info.Height;
                goods.Volume = info.Volume;
                goods.Period = info.Period;
                goods.AllowedDays = info.AllowedDays;
                goods.BillingWays = info.BillingWays;
                goods.SingleDiskNum = info.SingleDiskNum;
                goods.EncoderHeight = info.EncoderHeight;
                goods.IsDemolitionZero = info.IsDemolitionZero;
                goods.DemolitionZeroUnit = info.DemolitionZeroUnit;
                goods.DemolitionZeroNum = info.DemolitionZeroNum;
                goods.SortCode = info.SortCode;
                goods.EnabledMark = info.EnabledMark;
                goods.ImgUrl = info.ImgUrl;
                goods.Description = info.Description;
                OnBeforeUpdate(goods);
                result.Success = await iService.UpdateAsync(goods, info.Id).ConfigureAwait(true);
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
        /// <param name="search"></param>
        /// <returns></returns>
        [YuebonAuthorize("List")]
        [HttpGet("FindWithPagerAsync")]
        public override async Task<IActionResult> FindWithPagerAsync([FromQuery]SearchModel search)
        {
            CommonResult result = new CommonResult();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "desc" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "SortCode desc,CreatorTime " : Request.Query["Order"].ToString();
            string enCode = Request.Query["EnCode"].ToString();
            string customerEnCode = Request.Query["CustomerEnCode"].ToString();
            string barCode = Request.Query["BarCode"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition();
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and (Title like '%{0}%' Or EnTitle like '%{0}%' Or OtherTitle like '%{0}%')", search.Keywords);
            }
            if (!string.IsNullOrEmpty(enCode))
            {
                where += string.Format(" and EnCode like '%{0}%", enCode);
            }
            if (!string.IsNullOrEmpty(customerEnCode))
            {
                where += string.Format(" and customerEnCode like '%{0}%", customerEnCode);
            }
            if (!string.IsNullOrEmpty(barCode))
            {
                where += string.Format(" and barCode like '%{0}%", barCode);
            }
            PagerInfo pagerInfo = GetPagerInfo();
            List<Goods> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<GoodsOutputDto> resultList = list.MapTo<GoodsOutputDto>();
            PageResult<GoodsOutputDto> pageResult = new PageResult<GoodsOutputDto>
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