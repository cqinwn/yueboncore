using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.WebApp.Commons;
using Yuebon.WebApp.Models;

namespace Yuebon.WebApp.Controllers
{
    /// <summary>
    /// 基本控制器，增删改查
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TService">Service类型</typeparam>
    public class BusinessController<T, TService> : Controller
        where T : class,IBaseEntity<string>
        where TService : IService<T, string>
    {
        #region 属性变量
        /// <summary>
        /// 当前登录的用户属性
        /// </summary>
        public UserLoginDto CurrentUser = new UserLoginDto();

        /// <summary>
        /// 定义常用功能的控制ID，方便基类控制器对用户权限的控制
        /// </summary>
        protected AuthorizeKey AuthorizeKey = new AuthorizeKey();
        #endregion


        /// <summary>
        /// 服务接口
        /// </summary>
        public TService iService;

        private AuthHelper authHelper = IoCContainer.Resolve<AuthHelper>();


        #region 构造函数及常用
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="_iService"></param>
        public BusinessController(TService _iService)
        {
            iService = _iService;
        }
        #endregion


        #region 权限控制内容
        /// <summary>
        /// 判断当前用户是否拥有某功能点的权限
        /// </summary>
        /// <param name="functionCode">功能编码code</param>
        /// <returns></returns>
        public virtual bool HasFunction(string functionCode)
        {
            return new Permission().HasFunction(functionCode);
        }

        /// <summary>
        /// 判断是否为系统管理员或超级管理员
        /// </summary>
        /// <returns>true:系统管理员,false:不是系统管理员</returns>
        public virtual bool IsAdmin()
        {
            return new Permission().IsAdmin();
        }

        /// <summary>
        /// 用于检查方法执行前的权限，如果未授权，返回MyDenyAccessException异常
        /// </summary>
        /// <param name="functionId"></param>
        protected virtual void CheckAuthorized(string functionId)
        {
            if (!HasFunction(functionId))
            {
                string errorMessage = "您未被授权使用该功能，请重新登录试试或联系管理员进行处理。";
                throw new MyDenyAccessException(errorMessage);
            }
        }

        /// <summary>
        /// 对AuthorizeKey对象里面的操作权限进行赋值，用于页面判断
        /// </summary>
        protected virtual void ConvertAuthorizedInfo()
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
            byte[] currentUserSession;
           HttpContext.Session.TryGetValue("CurrentUser", out currentUserSession);

            if (currentUserSession == null)
            {

                filterContext.Result = new RedirectResult("/Login/Index");
                return;

            }
            else
            {
                //得到用户登录的信息
                CurrentUser = ByteConvertHelper.Bytes2Object<UserLoginDto>(filterContext.HttpContext.Session.Get("CurrentUser"));
            }
            //UserWithAccessedCtrls userWithAccessedCtrls = authHelper.GetCurrentUser();
            if (CurrentUser != null)
            {
                //User user = userWithAccessedCtrls.User;
                //UserLoginDto model = new UserLoginDto();
                //model.Account = user.Account;
                //model.Birthday = user.Birthday;
                //model.Email = user.Email;
                //model.Gender = user.Gender;
                //model.HeadIcon = user.HeadIcon;
                //model.Id = user.Id;
                //model.IsAdministrator = user.IsAdministrator;

                //model.MobilePhone = user.MobilePhone;
                //model.NickName = user.NickName;
                //model.OrganizeId = user.OrganizeId;
                //model.DepartmentId = user.DepartmentId;
                //model.RealName = user.RealName;
                //model.RoleId = user.RoleId;

                //model.SecurityLevel = user.SecurityLevel;
                //model.Signature = user.Signature;
                //model.WeChat = user.WeChat;
                //result.ResData = model;
                //CurrentUser = model;
            }
            else
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
            //设置授权属性，然后赋值给ViewBag保存
            ConvertAuthorizedInfo();
            ViewBag.AuthorizeKey = AuthorizeKey;
        }
        #endregion


        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        public virtual IActionResult Index()
        {
            ViewData["Account"] = CurrentUser.Account;
            ViewData["RealName"] = CurrentUser.RealName;
            return View();
        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IActionResult Edit(string id)
        {
            ViewData["Account"] = CurrentUser.Account;
            ViewData["RealName"] = CurrentUser.RealName;
            ViewData["Id"] = id;
            return View();
        }


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
        /// 新增数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual IActionResult Insert(T info)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.InsertKey);
            CommonResult result = new CommonResult();
            OnBeforeInsert(info);
            long ln = iService.Insert(info);
            if (ln >= 0)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
                result.Success = true;
            }
            else
            {
                result.ErrMsg = ErrCode.err43001;
                result.ErrCode = "43001";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步新增数据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        //[HttpPost]
        //public virtual async Task<IActionResult> InsertAsync(T info, string token)
        //{
        //    //检查用户是否有权限，否则抛出MyDenyAccessException异常
        //    CheckAuthorized(AuthorizeKey.InsertKey);
        //    CommonResult result = new CommonResult();
        //    OnBeforeInsert(info);
        //    long ln = await iService.InsertAsync(info);
        //    if (ln > 0)
        //    {
        //        result.ErrCode = ErrCode.successCode;
        //        result.ErrMsg = ErrCode.err0;
        //    }
        //    else
        //    {
        //        result.ErrMsg = ErrCode.err43001;
        //        result.ErrCode = "43001";
        //    }
        //    return ToJsonContent(result);
        //}

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual IActionResult Update(IFormCollection formValues, string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.UpdateKey);
            T obj = iService.Get(id);
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
                        catch { }
                    }
                }
            }
            CommonResult result = new CommonResult();
            OnBeforeUpdate(obj);
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
        /// 异步更新数据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        //[HttpPost]
        //public virtual async Task<IActionResult> UpdateAsync(IFormCollection formValues, string id, string token)
        //{
        //    //检查用户是否有权限，否则抛出MyDenyAccessException异常
        //    CheckAuthorized(AuthorizeKey.UpdateKey);
        //    T obj = iService.Get(id);
        //    if (obj != null)
        //    {
        //        //遍历提交过来的数据（可能是实体类的部分属性更新）
        //        foreach (string key in formValues.Keys)
        //        {
        //            string value = formValues[key];
        //            System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(key);
        //            if (propertyInfo != null)
        //            {
        //                try
        //                {
        //                    // obj对象有key的属性，把对应的属性值赋值给它(从字符串转换为合适的类型）
        //                    //如果转换失败，会抛出InvalidCastException异常
        //                    propertyInfo.SetValue(obj, ConvertHelper.ChangeType(value, propertyInfo.PropertyType), null);
        //                }
        //                catch { }
        //            }
        //        }
        //    }
        //    CommonResult result = new CommonResult();
        //    OnBeforeUpdate(obj);
        //    bool bl = await iService.UpdateAsync(obj, id);
        //    if (bl)
        //    {
        //        result.ErrCode = ErrCode.successCode;
        //        result.ErrMsg = ErrCode.err0;
        //        result.Success = true;
        //    }
        //    else
        //    {
        //        result.ErrMsg = ErrCode.err43002;
        //        result.ErrCode = "43002";
        //    }
        //    return ToJsonContent(result);
        //}

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="token">token令牌</param>
        [HttpDelete]
        public virtual IActionResult Delete(string id, string token)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.DeleteKey);
            CommonResult result = new CommonResult();

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
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步物理删除
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="token">token令牌</param>
        [HttpDelete]
        public virtual async Task<IActionResult> DeleteAsync(string id, string token)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.DeleteKey);
            CommonResult result = new CommonResult();

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
            return ToJsonContent(result);
        }

        /// <summary>
        /// 删除多个ID的记录
        /// </summary>
        /// <param name="ids">多个id组合，逗号分开（1,2,3,4,5）</param>
        /// <returns></returns>
        public virtual IActionResult DeleteByIds(string ids)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.DeleteKey);
            CommonResult result = new CommonResult();
            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    List<string> idArray = ids.ToDelimitedList<string>(",");
                    foreach (string strId in idArray)
                    {
                        if (!string.IsNullOrEmpty(strId))
                        {
                            bool bl = iService.Delete(strId);
                            if (bl)
                            {
                                result.ErrCode = ErrCode.successCode;
                                result.ErrMsg = ErrCode.err0;
                                result.Success = true;
                            }
                            else
                            {
                                result.ErrMsg = ErrCode.err43003;
                                result.ErrCode = "43003";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("批量删除", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 软删除信息多个ID的记录
        /// </summary>
        /// <param name="ids">多个id组合，逗号分开（1,2,3,4,5）</param>
        /// <returns></returns>
        public virtual IActionResult DeleteSoftByIds(string ids, string bltag = "0")
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.DeleteSoftKey);
            CommonResult result = new CommonResult();
            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    List<string> idArray = ids.ToDelimitedList<string>(",");
                    foreach (string strId in idArray)
                    {
                        if (!string.IsNullOrEmpty(strId))
                        {
                            bool bl = false;
                            if (bltag == "1")
                            {
                                bl = true;
                            }
                            bool blresut = iService.DeleteSoft(bl, strId,CurrentUser.UserId);
                            if (blresut)
                            {
                                result.ErrCode = ErrCode.successCode;
                                result.ErrMsg = ErrCode.err0;
                                result.Success = true;
                            }
                            else
                            {
                                result.ErrMsg = ErrCode.err43003;
                                result.ErrCode = "43003";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error("批量软删除", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 软删除信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="token">token令牌</param>
        /// <param name="bltag">删除标识，默认为1：即设为删除,0：未删除</param>
        [HttpDelete("DeleteSoft")]
        public virtual IActionResult DeleteSoft(string id, string bltag = "1")
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.DeleteSoftKey);
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blResult = iService.DeleteSoft(bl, id,CurrentUser.UserId);
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
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步软删除信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="token">token令牌</param>
        /// <param name="bltag">删除标识，默认为1：即设为删除,0：未删除</param>
        [HttpDelete("DeleteSoftAsync")]
        public virtual async Task<IActionResult> DeleteSoftAsync(string id, string bltag = "1")
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.DeleteSoftKey);
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blResult = await iService.DeleteSoftAsync(bl, id,CurrentUser.UserId);
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
            return ToJsonContent(result);
        }

        /// <summary>
        /// 设为数据有效性
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="token">token令牌</param>
        /// <param name="bltag">有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMark")]
        public virtual IActionResult SetEnabledMark(string id, string token, string bltag = "1")
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.UpdateEnableKey);
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blresut = iService.SetEnabledMark(bl, id,CurrentUser.UserId);
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
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步设为数据有效性
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="token">token令牌</param>
        /// <param name="bltag">有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMarkAsync")]
        public virtual async Task<IActionResult> SetEnabledMarkAsync(string id, string token, string bltag = "1")
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.UpdateEnableKey);
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blresut = await iService.SetEnabledMarkAsync(bl, id,CurrentUser.UserId);
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
            return ToJsonContent(result);
        }

        /// <summary>
        /// 设数据有效性多个ID的记录
        /// </summary>
        /// <param name="ids">多个id组合，逗号分开（1,2,3,4,5）</param>
        /// <returns></returns>
        [HttpPost]
        public virtual IActionResult SetEnabledMarkByIds(string ids, string bltag = "0")
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.UpdateEnableKey);
            CommonResult result = new CommonResult();
            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    bool bl = false;
                    if (bltag == "1")
                    {
                        bl = true;
                    }
                    List<string> idArray = ids.ToDelimitedList<string>(",");
                    foreach (string strId in idArray)
                    {
                        if (!string.IsNullOrEmpty(strId))
                        {
                            bool blresut = iService.SetEnabledMark(bl, strId,CurrentUser.UserId);
                            if (blresut)
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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("批量设置数据有效性异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据ID获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IActionResult GetById(string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ViewKey);
            CommonResult result = new CommonResult();
            try
            {
                result.ResData = iService.Get(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error("获取一个对象异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }
        #endregion


        #region 返回集合的接口
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public virtual IActionResult FindWithPager()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "Id" : Request.Query["sort"].ToString();
          
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition();
            PagerInfo pagerInfo = GetPagerInfo();
            List<T> list = iService.FindWithPager(where, pagerInfo, orderFlied, order);
            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = list
            };
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据Request参数获取分页对象数据
        /// </summary>
        /// <returns></returns>
        protected virtual PagerInfo GetPagerInfo()
        {
            string start = Request.Query["offset"].ToString();
            int pageSize = Request.Query["limit"].ToString() == null ? 1 : int.Parse(Request.Query["limit"].ToString());
            int pageIndex = 1;
            if (!string.IsNullOrWhiteSpace(start))
            {
                pageIndex = (int.Parse(start) / pageSize) + 1;
            }
            PagerInfo pagerInfo = new PagerInfo();
            pagerInfo.CurrenetPageIndex = pageIndex;
            pagerInfo.PageSize = pageSize;
            return pagerInfo;
        }

        /// <summary>
        /// 获取分页操作的查询条件
        /// </summary>
        /// <param name="blDeptCondition">是否开启权限数据</param>
        /// <returns></returns>
        protected virtual string GetPagerCondition(bool blDeptCondition = true)
        {
            string where = "1=1";

            //增加一个CustomedCondition条件，根据客户这个条件进行查询
            string CustomedCondition = Request.Query["CustomedCondition"].ToString()?? "";
            if (!string.IsNullOrWhiteSpace(CustomedCondition))
            {
                where = CustomedCondition;//直接使用条件
            }
            else
            {
                #region 根据数据库字段列，对所有可能的参数进行获值，然后构建查询条件
                //SearchCondition condition = new SearchCondition();
                //DataTable dt = baseBLL.GetFieldTypeList();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    string columnName = dr["ColumnName"].ToString();
                //    string dataType = dr["DataType"].ToString();

                //    //字段增加YUE_前缀字符，避免传递如URL这样的Request关键字冲突
                //    string columnValue = Request["YUE_" + columnName] ?? "";
                //    //对于数值型，如果是显示声明相等的，一般是外键引用，需要特殊处理
                //    bool hasEqualValue = columnValue.StartsWith("=");

                //    if (IsDateTime(dataType))
                //    {
                //        condition.AddDateCondition(columnName, columnValue);
                //    }
                //    else if (IsNumericType(dataType))
                //    {
                //        //如果数据库是数值类型，而传入的值是true或者false,那么代表数据库的参考值为1,0，需要进行转换
                //        bool boolValue = false;
                //        bool isBoolenValue = bool.TryParse(columnValue, out boolValue);
                //        if (isBoolenValue)
                //        {
                //            condition.AddCondition(columnName, boolValue ? 1 : 0, SqlOperator.Equal);
                //        }
                //        else if (hasEqualValue)
                //        {
                //            columnValue = columnValue.Substring(columnValue.IndexOf("=") + 1);
                //            condition.AddCondition(columnName, columnValue, SqlOperator.Equal);
                //        }
                //        else
                //        {
                //            condition.AddNumberCondition(columnName, columnValue);
                //        }
                //    }
                //    else
                //    {
                //        if (ValidateUtil.IsNumeric(columnValue))
                //        {
                //            condition.AddCondition(columnName, columnValue, SqlOperator.Equal);
                //        }
                //        else
                //        {
                //            condition.AddCondition(columnName, columnValue, SqlOperator.Like);
                //        }
                //    }
                //}
                #endregion

               // where = condition.BuildConditionSql().Replace("Where", "");
            }
            if (blDeptCondition)
            {
                //如果公司过滤条件不为空，那么需要进行过滤
                string DataFilterCondition = new YuebonCacheHelper().Get("DataFilterCondition_"+CurrentUser.UserId).ToString();
                if (!string.IsNullOrEmpty(DataFilterCondition))
                {
                    where += string.Format(" {0}", DataFilterCondition);
                }
            }
            return where;
        }
        #endregion


        #region 辅助方法
        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <returns></returns>
        public IActionResult ClearCache()
        {
            CommonResult result = new CommonResult();
            try
            {
                if (IsAdmin())
                {
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    yuebonCacheHelper.RemoveCacheAll();
                    result.Success = true;
                }
                else
                {
                    result.ErrMsg = "您不是系统管理员，不能清除缓存。";
                }
            }
            catch (Exception ex)
            {
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            yuebonCacheHelper.Remove("User_Function_" +CurrentUser.UserId);
            yuebonCacheHelper.Remove("User_Menu_" +CurrentUser.UserId);
            CurrentUser = null;
            return new RedirectResult("/Login/Index");
        }

        /// <summary>
        /// 把object对象转换为ContentResult
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        protected IActionResult ToJsonContent(object obj)
        {
            string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return Content(obj.ToJson());
        }
        #endregion
    }
}