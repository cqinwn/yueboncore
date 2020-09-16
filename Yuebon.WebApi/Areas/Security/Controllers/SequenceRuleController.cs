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
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;
using Yuebon.Security.IServices;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.UI;

namespace Yuebon.SecurityApi.Areas.Security.Controllers
{
    /// <summary>
    /// 序号编码规则表接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class SequenceRuleController : AreaApiController<SequenceRule, SequenceRuleOutputDto, SequenceRuleInputDto, ISequenceRuleService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public SequenceRuleController(ISequenceRuleService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "SequenceRule/List";
            AuthorizeKey.InsertKey = "SequenceRule/Add";
            AuthorizeKey.UpdateKey = "SequenceRule/Edit";
            AuthorizeKey.UpdateEnableKey = "SequenceRule/Enable";
            AuthorizeKey.DeleteKey = "SequenceRule/Delete";
            AuthorizeKey.DeleteSoftKey = "SequenceRule/DeleteSoft";
            AuthorizeKey.ViewKey = "SequenceRule/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(SequenceRule info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(SequenceRule info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(SequenceRule info)
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
        public async Task<IActionResult> InsertOrUpdateAsync(SequenceRuleInputDto info)
        {
            CommonResult result = new CommonResult();

            if (string.IsNullOrEmpty(info.SequenceName))
            {
                result.ErrMsg = "单据名称不能为空";
                return ToJsonContent(result);
            }

            if (string.IsNullOrEmpty(info.Id))
            {
                string where = string.Format("RuleType='{0}' and SequenceName='{1}'", info.RuleType, info.SequenceName);
                SequenceRule goodsIsExist = iService.GetWhere(where);
                if (goodsIsExist != null)
                {
                    result.ErrMsg = "该单据此规则类别已添加不能重复";
                    return ToJsonContent(result);
                }
                SequenceRule sequence = new SequenceRule();
                sequence = info.MapTo<SequenceRule>();
                OnBeforeInsert(sequence);
                long ln = await iService.InsertAsync(sequence).ConfigureAwait(true);
                result.Success = ln > 0;
            }
            else
            {
                string where = string.Format("RuleType='{0}' and id!='{1}' and SequenceName='{2}'", info.RuleType, info.Id, info.SequenceName);
                SequenceRule goodsIsExist = iService.GetWhere(where);
                if (goodsIsExist != null)
                {
                    result.ErrMsg = "该单据此规则类别已添加不能重复";
                    return ToJsonContent(result);
                }
                SequenceRule sequenceRule = iService.Get(info.Id);
                sequenceRule.SequenceName = info.SequenceName;
                sequenceRule.RuleOrder = info.RuleOrder;
                sequenceRule.RuleType = info.RuleType;
                sequenceRule.RuleValue = info.RuleValue;
                sequenceRule.PaddingSide = info.PaddingSide;
                sequenceRule.PaddingWidth = info.PaddingWidth;
                sequenceRule.PaddingChar = info.PaddingChar;
                sequenceRule.EnabledMark = info.EnabledMark;
                sequenceRule.Description = info.Description;
                OnBeforeUpdate(sequenceRule);
                result.Success = await iService.UpdateAsync(sequenceRule, info.Id).ConfigureAwait(true);
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
        /// 分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithPagerAsync")]
        [YuebonAuthorize("List")]
        public override async Task<IActionResult> FindWithPagerAsync([FromQuery] SearchModel search)
        {
            CommonResult result = new CommonResult();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "desc" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? " SequenceName desc,RuleOrder asc,CreatorTime " : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition();
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and SequenceName like '%{0}%' ", search.Keywords);
            }
            PagerInfo pagerInfo = GetPagerInfo();
            List<SequenceRule> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<SequenceRuleOutputDto> resultList = list.MapTo<SequenceRuleOutputDto>();
            PageResult<SequenceRuleOutputDto> pageResult = new PageResult<SequenceRuleOutputDto>
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