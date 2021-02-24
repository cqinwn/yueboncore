using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

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

        [HttpPost("Insert")]
        [YuebonAuthorize("Add")]
        public override async Task<IActionResult> InsertAsync(SequenceInputDto info)
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
                Sequence sequence =info.MapTo<Sequence>();
                OnBeforeInsert(sequence);
                long ln = await iService.InsertAsync(sequence).ConfigureAwait(true);
                result.Success = ln > 0;
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
        /// 异步更新数据，需要在业务模块控制器重写该方法,否则更新无效
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public override async Task<IActionResult> UpdateAsync(SequenceInputDto info)
        {
            CommonResult result = new CommonResult();
            if (string.IsNullOrEmpty(info.SequenceName))
            {
                result.ErrMsg = "单据名称不能为空";
                return ToJsonContent(result);
            }

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