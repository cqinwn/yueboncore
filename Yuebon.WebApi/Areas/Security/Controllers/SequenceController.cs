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
using Yuebon.Security.Application;

namespace Yuebon.SecurityApi.Areas.Security.Controllers
{
    /// <summary>
    /// 单据编码接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class SequenceController : AreaApiController<Sequence, SequenceOutputDto, SequenceInputDto, ISequenceService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public SequenceController(ISequenceService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "Sequence/List";
            AuthorizeKey.InsertKey = "Sequence/Add";
            AuthorizeKey.UpdateKey = "Sequence/Edit";
            AuthorizeKey.UpdateEnableKey = "Sequence/Enable";
            AuthorizeKey.DeleteKey = "Sequence/Delete";
            AuthorizeKey.DeleteSoftKey = "Sequence/DeleteSoft";
            AuthorizeKey.ViewKey = "Sequence/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Sequence info)
        {
            info.Id = GuidUtils.CreateNo();
            info.Id = new SequenceApp().GetSequenceNext("SortingSn");
            info.CreatorTime=info.LastModifyTime = DateTime.Now;
            info.CreatorUserId = info.LastModifyUserId= CurrentUser.UserId;
            info.CompanyId = CurrentUser.OrganizeId;
            info.DeptId = CurrentUser.DeptId;
            info.CurrentNo = 0;
            info.CurrentReset = "";
            info.DeleteMark = false;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Sequence info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Sequence info)
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
        public async Task<IActionResult> InsertOrUpdateAsync(SequenceInputDto info)
        {
            CommonResult result = new CommonResult();

            if (string.IsNullOrEmpty(info.SequenceName))
            {
                result.ErrMsg = "单据名称不能为空";
                return ToJsonContent(result);
            }

            if (string.IsNullOrEmpty(info.Id))
            {
                string where = string.Format("SequenceName='{0}'", info.SequenceName);
                Sequence sequenceIsExist = iService.GetWhere(where);
                if (sequenceIsExist != null)
                {
                    result.ErrMsg = "规则名称不能重复";
                    return ToJsonContent(result);
                }
                Sequence sequence = new Sequence();
                sequence = info.MapTo<Sequence>();

                OnBeforeInsert(sequence);
                long ln = await iService.InsertAsync(sequence).ConfigureAwait(true);
                result.Success = ln > 0;
            }
            else
            {
                string where = string.Format("SequenceName='{0}' and id!='{1}'", info.SequenceName, info.Id);
                Sequence goodsIsExist = iService.GetWhere(where);
                if (goodsIsExist != null)
                {
                    result.ErrMsg = "规则名称不能重复";
                    return ToJsonContent(result);
                }
                Sequence sequence = iService.Get(info.Id);
                sequence.SequenceName = info.SequenceName;
                sequence.SequenceDelimiter = info.SequenceDelimiter;
                sequence.SequenceReset = info.SequenceReset;
                sequence.Step = info.Step;
                sequence.CurrentNo = info.CurrentNo;
                sequence.CurrentCode = info.CurrentCode;
                sequence.CurrentReset = info.CurrentReset;
                sequence.EnabledMark = info.EnabledMark;
                sequence.Description = info.Description;
                OnBeforeUpdate(sequence);
                result.Success = await iService.UpdateAsync(sequence, info.Id).ConfigureAwait(true);
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
    }
}