using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Controllers;
using Yuebon.WebApp.Models;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class AppController : BusinessController<APP, IAPPService>
    {
        public AppController(IAPPService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.InsertKey = "App/Add";
            AuthorizeKey.UpdateKey = "App/Edit";
            AuthorizeKey.DeleteKey = "App/Delete";
            AuthorizeKey.UpdateEnableKey = "App/Enable";
            AuthorizeKey.ListKey = "App/List";
            AuthorizeKey.ViewKey = "App/View";
        }

        protected override void OnBeforeInsert(APP info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.AppSecret = MD5Util.GetMD5_32(GuidUtils.NewGuidFormatN()).ToUpper();
            if (info.IsOpenAEKey)
            {
                info.EncodingAESKey = MD5Util.GetMD5_32(GuidUtils.NewGuidFormatN()).ToUpper();
            }
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.CompanyId = CurrentUser.OrganizeId;
            info.DeptId = CurrentUser.DepartmentId;
            info.DeleteMark = false;

        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(APP info)
        {
            //留给子类对参数对象进行修改
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
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
                result.ResData = iService.Get(id).MapTo<AppOutputDto>();
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
            string orderFlied = Request.Query["sort"].ToString() == "" ? "Id" : Request.Query["sort"].ToString();
            string where = GetPagerCondition();
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (AppId like '%{0}%' or Description like '%{0}%')", keywords);
            }
            Yuebon.Commons.Pages.PagerInfo pagerInfo = GetPagerInfo();
            List<AppOutputDto> list = iService.FindWithPager(where, pagerInfo, orderFlied, order).MapTo<AppOutputDto>();

            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = list
            };
            return ToJsonContent(result);
        }


        /// <summary>
        /// 重置AppSecret
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ResetAppSecret(string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized("App/ResetAppSecret");
            CommonResult result = new CommonResult();
            APP aPP = iService.Get(id);
            aPP.AppSecret = MD5Util.GetMD5_32(GuidUtils.NewGuidFormatN()).ToUpper();
            bool bl = iService.Update(aPP, id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = aPP.AppSecret;
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
        /// 重置消息加密密钥EncodingAESKey
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ResetEncodingAESKey(string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized("App/ResetEncodingAESKey");
            CommonResult result = new CommonResult();
            APP aPP = iService.Get(id);
            aPP.EncodingAESKey = MD5Util.GetMD5_32(GuidUtils.NewGuidFormatN()).ToUpper();
            bool bl = iService.Update(aPP, id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = aPP.EncodingAESKey;
                result.Success = true;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }
    }
}