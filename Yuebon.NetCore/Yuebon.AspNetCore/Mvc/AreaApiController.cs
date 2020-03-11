using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    /// 基本控制器，增删改查
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TService">Service类型</typeparam>
    [ApiController]
    public class AreaApiController<T, TService> : ApiController
        where T : class, IBaseEntity<string>
        where TService : IService<T, string>
    {

        #region 属性变量

        /// <summary>
        /// 定义常用功能的控制ID，方便基类控制器对用户权限的控制
        /// </summary>
        protected AuthorizeKey AuthorizeKey;

        /// <summary>
        /// 服务接口
        /// </summary>
        public TService iService;

        #endregion


        #region 权限控制内容
        /// <summary>
        /// 判断当前用户是否拥有某功能点的权限
        /// </summary>
        /// <param name="functionCode">功能编码code</param>
        /// <returns></returns>
        [HiddenApi]
        private  bool HasFunction(string functionCode)
        {
            return new Permission().HasFunction(functionCode,CurrentUser);
        }

        /// <summary>
        /// 判断是否为系统管理员或超级管理员
        /// </summary>
        /// <returns>true:系统管理员,false:不是系统管理员</returns>
        [HiddenApi]
        private  bool IsAdmin()
        {
            return new Permission().IsAdmin(CurrentUser);
        }

        /// <summary>
        /// 用于检查方法执行前的权限，如果未授权，返回MyDenyAccessException异常
        /// </summary>
        /// <param name="functionId"></param>
        [HttpGet("CheckAuthorized")]
        [HiddenApi]
        public CommonResult  CheckAuthorized(string functionId)
        {
            CommonResult result = new CommonResult();
            if (!HasFunction(functionId))
            {
                result.ErrCode = "40006";
                result.ErrMsg= ErrCode.err40006;
            }
            else
            {
                result.Success = true;
                result.ErrCode = "0";
                result.ErrMsg = ErrCode.err0;

            }
            return result;
        }

        /// <summary>
        /// 对AuthorizeKey对象里面的操作权限进行赋值，用于页面判断
        /// </summary>
        [HiddenApi]
        private void ConvertAuthorizedInfo()
        {
            //判断用户权限
            AuthorizeKey.CanInsert = HasFunction(AuthorizeKey.InsertKey);
            AuthorizeKey.CanUpdate = HasFunction(AuthorizeKey.UpdateKey);
            AuthorizeKey.CanUpdateIsEnable = HasFunction(AuthorizeKey.UpdateIsEnableKey);
            AuthorizeKey.CanUpdateNoEnable = HasFunction(AuthorizeKey.UpdateNoEnableKey);
            AuthorizeKey.CanUpdateEnable = HasFunction(AuthorizeKey.UpdateEnableKey);
            AuthorizeKey.CanDelete = HasFunction(AuthorizeKey.DeleteKey);
            AuthorizeKey.CanDeleteSoft = HasFunction(AuthorizeKey.DeleteSoftKey);
            AuthorizeKey.CanView = HasFunction(AuthorizeKey.ViewKey);
            AuthorizeKey.CanList = HasFunction(AuthorizeKey.ListKey);
            AuthorizeKey.CanExport = HasFunction(AuthorizeKey.ExportKey);
            AuthorizeKey.CanImport = HasFunction(AuthorizeKey.ImportKey);
            AuthorizeKey.CanExtend = HasFunction(AuthorizeKey.ExtendKey);
        }
        #endregion


        #region 异常处理及记录
        /// <summary>
        /// 重新基类在Action执行之前的事情
        /// </summary>
        /// <param name="filterContext">重写方法的参数</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.Success)
            {
                if (CurrentUser == null)
                {
                    filterContext.Result = new RedirectResult("/Login");
                    return;
                }
            }
            else
            {

            }
            base.OnActionExecuting(filterContext);
            //设置授权属性，然后赋值给ViewBag保存
            ConvertAuthorizedInfo();
            ViewBag.AuthorizeKey = AuthorizeKey;
        }
        #endregion
        #region 构造函数及常用

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="_iService"></param>
        public AreaApiController(TService _iService)
        {
            iService = _iService;
        }

        #endregion

        #region 公共添加、修改、删除、查询接口


        /// <summary>
        /// 在插入数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual void OnBeforeInsert(T info)
        {
            //留给子类对参数对象进行修改
        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual void OnBeforeUpdate(T info)
        {
            //留给子类对参数对象进行修改
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual void OnBeforeSoftDelete(T info)
        {
            //留给子类对参数对象进行修改
        }

        /// <summary>
        /// 异步新增数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        public virtual async Task<IActionResult> InsertAsync(T info)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                OnBeforeInsert(info);
                long ln = await iService.InsertAsync(info);
                if (ln > 0)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43001;
                    result.ErrCode = "43001";
                }
            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 异步更新数据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost("Update")]
        public virtual async Task<IActionResult> UpdateAsync(T info,string id)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                OnBeforeUpdate(info);
                bool bl = await iService.UpdateAsync(info,id);
                if (bl)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43002;
                    result.ErrCode = "43002";
                }
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="id">主键Id</param>
        [HttpDelete("Delete")]
        public virtual IActionResult Delete(string id)
        {
            CommonResult result = new CommonResult();

            result = CheckToken();

            if (result.ErrCode == ErrCode.successCode)
            {
                bool bl = iService.Delete(id);
                if (bl)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43003;
                    result.ErrCode = "43003";
                }
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步物理删除
        /// </summary>
        /// <param name="id">主键Id</param>
        [HttpDelete("DeleteAsync")]
        public virtual async Task<IActionResult> DeleteAsync(string id)
        {
            CommonResult result = new CommonResult();
            
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                bool bl = await iService.DeleteAsync(id);
                if (bl)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43003;
                    result.ErrCode = "43003";
                }
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 软删除信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="bltag">删除标识，默认为1：即设为删除,0：未删除</param>
        [HttpGet("DeleteSoft")]
        public virtual IActionResult DeleteSoft(string id,string bltag="1")
        {
            CommonResult result = new CommonResult();           
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                bool bl = false;
                if (bltag == "0")
                {
                    bl = true;
                }
                bool blResult =iService.DeleteSoft(bl,id,CurrentUser.UserId);
                if (blResult)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43002;
                    result.ErrCode = "43002";
                }
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步软删除信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="bltag">删除标识，默认为1：即设为删除,0：未删除</param>
        [HttpPost("DeleteSoftAsync")]
        public virtual async Task<IActionResult> DeleteSoftAsync(string id,string bltag="1")
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                bool bl = false;
                if (bltag == "0")
                {
                    bl = true;
                }
                bool blResult = await iService.DeleteSoftAsync(bl,id,CurrentUser.UserId);
                if (blResult)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43002;
                    result.ErrCode = "43002";
                }
            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 设为数据有效性
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="bltag">有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMark")]
        public virtual IActionResult SetEnabledMark(string id, string bltag="1")
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                bool bl = false;
                if (bltag == "0")
                {
                    bl = true;
                }
                bool blresut = iService.SetEnabledMark(bl, id, CurrentUser.UserId);
                if (blresut)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43002;
                    result.ErrCode = "43002";
                }
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步设为数据有效性
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="bltag">有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMarkAsync")]
        public virtual async Task<IActionResult> SetEnabledMarkAsync(string id, string bltag = "1")
        {
            CommonResult result = new CommonResult();

            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                bool bl = false;
                if (bltag == "0")
                {
                    bl = true;
                }
                bool blresut = await iService.SetEnabledMarkAsync(bl, id, CurrentUser.UserId);
                if (blresut)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43002;
                    result.ErrCode = "43002";
                }
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 根据主键Id获取一个对象信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public virtual IActionResult GetById(string id)
        {
            CommonResult result = new CommonResult();

            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                T info = iService.Get(id);
               
                if (info != null)
                {
                    result.ResData = info;
                }
                else
                {
                    result.ErrMsg = ErrCode.err50001;
                    result.ErrCode = "50001";
                }
            }
            return ToJsonContent(result);
        }
        #endregion

        #region 返回集合的接口
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="info">info</param>
        /// <returns>指定对象的集合</returns>
        [HttpGet("FindWithPager")]
        public virtual IActionResult FindWithPager(T info)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
                string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
                string orderFlied = string.IsNullOrEmpty(Request.Query["sort"].ToString()) ? "Id" : Request.Query["sort"].ToString();

                bool order = orderByDir == "asc" ? false : true;
                string where = GetPagerCondition();
                PagerInfo pagerInfo =GetPagerInfo();
                List<T> list = iService.FindWithPager(where, pagerInfo, orderFlied, order);
                //构造成Json的格式传递
                result.ResData = new
                {
                    recordsTotal = pagerInfo.RecordCount,
                    recordsFiltered = pagerInfo.RecordCount,
                    data = list
                };
            }
            return ToJsonContent(result);
        }



        /// <summary>
        /// 根据Request参数获取分页对象数据
        /// </summary>
        /// <returns></returns>
        protected virtual PagerInfo GetPagerInfo()
        {
            string start = Request.Query["start"].ToString();
            int pageSize = Request.Query["length"].ToString() == null ? 1 : Request.Query["length"].ToString().ToInt();
            int pageIndex = 1;
            if (!string.IsNullOrWhiteSpace(start))
            {
                pageIndex = (start.ToInt() / pageSize) + 1;
            }
            PagerInfo pagerInfo = new PagerInfo();
            pagerInfo.CurrenetPageIndex = pageIndex;
            pagerInfo.PageSize = pageSize;
            return pagerInfo;
        }

        /// <summary>
        /// 获取分页操作的查询条件
        /// </summary>
        /// <returns></returns>
        protected virtual string GetPagerCondition(bool blDeptCondition = true)
        {
            string where = "1=1";

            //增加一个CustomedCondition条件，根据客户这个条件进行查询
            //string CustomedCondition = Request["CustomedCondition"] ?? "";
            //if (!string.IsNullOrWhiteSpace(CustomedCondition))
            //{
            //    where = CustomedCondition;//直接使用条件
            //}
            //else
            //{
            //    #region 根据数据库字段列，对所有可能的参数进行获值，然后构建查询条件
            //    SearchCondition condition = new SearchCondition();
            //    DataTable dt = baseBLL.GetFieldTypeList();
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        string columnName = dr["ColumnName"].ToString();
            //        string dataType = dr["DataType"].ToString();

            //        //字段增加YUE_前缀字符，避免传递如URL这样的Request关键字冲突
            //        string columnValue = Request["YUE_" + columnName] ?? "";
            //        //对于数值型，如果是显示声明相等的，一般是外键引用，需要特殊处理
            //        bool hasEqualValue = columnValue.StartsWith("=");

            //        if (IsDateTime(dataType))
            //        {
            //            condition.AddDateCondition(columnName, columnValue);
            //        }
            //        else if (IsNumericType(dataType))
            //        {
            //            //如果数据库是数值类型，而传入的值是true或者false,那么代表数据库的参考值为1,0，需要进行转换
            //            bool boolValue = false;
            //            bool isBoolenValue = bool.TryParse(columnValue, out boolValue);
            //            if (isBoolenValue)
            //            {
            //                condition.AddCondition(columnName, boolValue ? 1 : 0, SqlOperator.Equal);
            //            }
            //            else if (hasEqualValue)
            //            {
            //                columnValue = columnValue.Substring(columnValue.IndexOf("=") + 1);
            //                condition.AddCondition(columnName, columnValue, SqlOperator.Equal);
            //            }
            //            else
            //            {
            //                condition.AddNumberCondition(columnName, columnValue);
            //            }
            //        }
            //        else
            //        {
            //            if (ValidateUtil.IsNumeric(columnValue))
            //            {
            //                condition.AddCondition(columnName, columnValue, SqlOperator.Equal);
            //            }
            //            else
            //            {
            //                condition.AddCondition(columnName, columnValue, SqlOperator.Like);
            //            }
            //        }
            //    }
            //    #endregion

            //    where = condition.BuildConditionSql().Replace("Where", "");
            //}
            //if (blDeptCondition)
            //{
            //    //如果公司过滤条件不为空，那么需要进行过滤
            //    string DataFilterCondition = Session["DataFilterCondition"].ToString();
            //    if (!string.IsNullOrEmpty(DataFilterCondition))
            //    {
            //        where += string.Format(" {0}", DataFilterCondition);
            //    }
            //}
            return where;
        }
        #endregion


        #region 辅助方法

        #endregion

    }
}
