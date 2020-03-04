using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Senparc.CO2NET.AspNet.HttpUtility;
using Senparc.CO2NET.Extensions;
using Senparc.CO2NET.HttpUtility;
using Senparc.CO2NET.Utilities;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.MvcExtension;
using Senparc.Weixin.WxOpen;
using Senparc.Weixin.WxOpen.AdvancedAPIs.Sns;
using Senparc.Weixin.WxOpen.AdvancedAPIs.WxApp;
using Senparc.Weixin.WxOpen.Containers;
using Senparc.Weixin.WxOpen.Entities;
using Senparc.Weixin.WxOpen.Entities.Request;
using Senparc.Weixin.WxOpen.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
using Yuebon.Messages.Application;
using Yuebon.Messages.Dtos;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;
using Yuebon.WebApi.Areas.WeiXin.Models;
using Yuebon.WeChat.CommonService;
using Yuebon.WeChat.MessageHandlers.WxOpenMessageHandler;
using Yuebon.WeChat.Model;

namespace Yuebon.WebApi.Areas.WeiXin.Controllers
{
    /// <summary>
    /// 微信小程序Controller
    /// </summary>

    [Route("api/WeiXin/[controller]")]
    [ApiController]
    public partial class WxOpenController : ApiController
    {
        /// <summary>
        /// 与微信小程序后台的Token设置保持一致，区分大小写。
        /// </summary>
        public static readonly string Token = Config.SenparcWeixinSetting.WxOpenToken;
        /// <summary>
        /// 与微信小程序后台的EncodingAESKey设置保持一致，区分大小写。
        /// </summary>
        public static readonly string EncodingAESKey = Config.SenparcWeixinSetting.WxOpenEncodingAESKey;
        /// <summary>
        /// 与微信小程序后台的AppId设置保持一致，区分大小写。
        /// </summary>
        public static readonly string WxOpenAppId = Config.SenparcWeixinSetting.WxOpenAppId;
        /// <summary>
        /// 与微信小程序账号后台的AppId设置保持一致，区分大小写。
        /// </summary>
        public static readonly string WxOpenAppSecret = Config.SenparcWeixinSetting.WxOpenAppSecret;

        private string _filePath;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private Type type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public WxOpenController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _filePath = _hostingEnvironment.WebRootPath;
        }
        /// <summary>
        /// GET请求用于处理微信小程序后台的URL验证
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(PostModel postModel, string echostr)
        {
            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + postModel.Signature + "," + Senparc.Weixin.MP.CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, Token) + "。" +
                    "如果你在浏览器中看到这句话，说明此地址可以被作为微信小程序后台的Url，请注意保持Token一致。");
            }
        }

        /// <summary>
        /// 用户发送消息后，微信平台自动Post一个请求到这里，并等待响应XML。
        /// </summary>
        /// <param name="postModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Content("参数错误！");
            }

            postModel.Token = Token;//根据自己后台的设置保持一致
            postModel.EncodingAESKey = EncodingAESKey;//根据自己后台的设置保持一致
            postModel.AppId = WxOpenAppId;//根据自己后台的设置保持一致（必须提供）

            //v4.2.2之后的版本，可以设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制
            var maxRecordCount = 10;

            var logPath = ServerUtility.ContentRootMapPath(string.Format("~/Logs/WxOpen/{0}/", SystemTime.Now.ToString("yyyy-MM-dd")));
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            var messageHandler = new CustomWxOpenMessageHandler(Request.GetRequestMemoryStream(), postModel, maxRecordCount);


            try
            {
                /* 如果需要添加消息去重功能，只需打开OmitRepeatedMessage功能，SDK会自动处理。
                 * 收到重复消息通常是因为微信服务器没有及时收到响应，会持续发送2-5条不等的相同内容的RequestMessage*/
                messageHandler.OmitRepeatedMessage = true;

                //测试时可开启此记录，帮助跟踪数据，使用前请确保App_Data文件夹存在，且有读写权限。
                messageHandler.SaveRequestMessageLog();//记录 Request 日志（可选）

                messageHandler.Execute();//执行微信处理过程（关键）

                messageHandler.SaveResponseMessageLog();//记录 Response 日志（可选）

                //return Content(messageHandler.ResponseDocument.ToString());//v0.7-
                //return new FixWeixinBugWeixinResult(messageHandler);//为了解决官方微信5.0软件换行bug暂时添加的方法，平时用下面一个方法即可
                return new WeixinResult(messageHandler);//v0.8+
            }
            catch (Exception ex)
            {
                using (TextWriter tw = new StreamWriter(ServerUtility.ContentRootMapPath("~/Logs/Error_WxOpen_" + DateTime.Now.ToString("yyyyMMddhhmmssss") + ".txt")))
                {
                    tw.WriteLine("ExecptionMessage:" + ex.Message);
                    tw.WriteLine(ex.Source);
                    tw.WriteLine(ex.StackTrace);
                    //tw.WriteLine("InnerExecptionMessage:" + ex.InnerException.Message);

                    if (messageHandler.ResponseDocument != null)
                    {
                        tw.WriteLine(messageHandler.ResponseDocument.ToString());
                    }

                    if (ex.InnerException != null)
                    {
                        tw.WriteLine("========= InnerException =========");
                        tw.WriteLine(ex.InnerException.Message);
                        tw.WriteLine(ex.InnerException.Source);
                        tw.WriteLine(ex.InnerException.StackTrace);
                    }

                    tw.Flush();
                    tw.Close();
                }
                return Content("");
            }
        }

        /// <summary>
        /// wx.login登陆成功之后发送的请求
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost("OnLogin")]
        public IActionResult OnLogin(string code)
        {
            CommonResult result = new CommonResult();
            try
            {
                var jsonResult = SnsApi.JsCode2Json(WxOpenAppId, WxOpenAppSecret, code);
                if (jsonResult.errcode == ReturnCode.请求成功)
                {
                    //Session["WxOpenUser"] = jsonResult;//使用Session保存登陆信息（不推荐）
                    //使用SessionContainer管理登录信息（推荐）
                    var unionId = jsonResult.unionid;
                    var sessionBag = SessionContainer.UpdateSession(null, jsonResult.openid, jsonResult.session_key, unionId);

                    //注意：生产环境下SessionKey属于敏感信息，不能进行传输！
                    //return Json(new { success = true, msg = "OK", sessionId = sessionBag.Key, sessionKey = sessionBag.SessionKey });

                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    UserApp userApp = new UserApp();
                    User user = userApp.GetUserByOpenId("yuebon.openid.wxapplet", jsonResult.openid);
                    if (user == null)
                    {
                        UserInPutDto userInput = new UserInPutDto();
                        userInput.OpenId = jsonResult.openid;
                        userInput.OpenIdType = "yuebon.openid.wxapplet";
                        userInput.NickName = "游客";
                        userInput.UnionId = jsonResult.unionid;
                        result.Success = userApp.CreateUserByWxOpenId(userInput);
                    }
                    string userId = string.Empty;
                    if (result.ResData != null)
                    {
                        userId = result.ResData.ToString();
                    }
                    if (user == null)
                    {
                        user = userApp.GetUserByOpenId("yuebon.openid.wxapplet", jsonResult.openid);
                    }
                    var currentSession = JsonConvert.DeserializeObject<UserAuthSession>(yuebonCacheHelper.Get("login_user_" + user.Id).ToJson());
                    if (currentSession == null || string.IsNullOrWhiteSpace(currentSession.AccessToken))
                    {
                        JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                        TokenResult tokenResult = tokenProvider.LoginToken(user, "wxapplet");
                        currentSession = new UserAuthSession
                        {
                            UserId = user.Id,
                            Account = user.Account,
                            Name = user.RealName,
                            NickName = user.NickName,
                            AccessToken = tokenResult.AccessToken,
                            AppKey = "wxapplet",
                            CreateTime = DateTime.Now,
                            HeadIcon = user.HeadIcon,
                            Gender = user.Gender,
                            ReferralUserId = user.ReferralUserId,
                            MemberGradeId = user.MemberGradeId,
                            Role = new RoleApp().GetRoleEnCode(user.RoleId),
                            MobilePhone = user.MobilePhone,
                            WxSessionId = sessionBag.Key

                        };
                        TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                        yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
                    }
                    CurrentUser = currentSession;
                    result.ResData = currentSession; //new AuthorizeApp().GetAccessedControls(user.Account);
                    result.ErrCode = ErrCode.successCode;
                    result.Success = true;
                }
                else
                {
                    result.ErrCode = ErrCode.failCode;
                    result.ErrMsg = jsonResult.errmsg;
                }
            }
            catch (Exception ex)
            {
                result.ErrMsg = ex.Message;
            }

            return ToJsonContent(result);
        }
        /// <summary>
        /// GetOpenId登陆成功之后发送的请求
        /// </summary>
        /// <param name="code"></param>
        /// <returns>返回openId</returns>
        [HttpGet("GetOpenId")]
        public IActionResult GetOpenId(string code)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            try
            {
                var jsonResult = SnsApi.JsCode2Json(WxOpenAppId, WxOpenAppSecret, code);
                if (jsonResult.errcode == ReturnCode.请求成功)
                {
                    //Session["WxOpenUser"] = jsonResult;//使用Session保存登陆信息（不推荐）
                    //使用SessionContainer管理登录信息（推荐）
                    var unionId =jsonResult.unionid;
                    var sessionBag = SessionContainer.UpdateSession(null, jsonResult.openid, jsonResult.session_key, unionId);
                    //ValidateUserLogin(openId);
                    result.ResData = new { openId = jsonResult.openid, sessionId = sessionBag.Key };
                    result.ErrCode = ErrCode.successCode;
                }
                else
                {
                    result.ErrMsg = jsonResult.errmsg;
                }
            }
            catch (Exception ex)
            {
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="rawData"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        [HttpPost("CheckWxOpenSignature")]
        public ActionResult CheckWxOpenSignature(string code, string rawData, string signature)
        {
            try
            {
                var jsonResult = SnsApi.JsCode2Json(WxOpenAppId, WxOpenAppSecret, code);
                var checkSuccess = EncryptHelper.CheckSignature(code, rawData, signature);
                return Json(new { success = checkSuccess, msg = checkSuccess ? "签名校验成功" : "签名校验失败" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        /// <summary>
        /// 解密电话号码
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="encryptedData"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        [HttpGet("DecryptPhoneNumber")]
        public IActionResult DecryptPhoneNumber(string sessionId, string encryptedData, string iv)
        {
            CommonResult result = new CommonResult();
            var sessionBag = SessionContainer.GetSession(sessionId);
            try
            {
                var phoneNumber = EncryptHelper.DecryptPhoneNumber(sessionId, encryptedData, iv);
                result.ResData = phoneNumber;
                result.ErrCode = ErrCode.successCode;
            }
            catch (Exception ex)
            {
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 解密运动步数
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="encryptedData"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        [HttpPost("DecryptRunData")]
        public IActionResult DecryptRunData(string sessionId, string encryptedData, string iv)
        {
            var sessionBag = SessionContainer.GetSession(sessionId);
            try
            {
                var runData = Senparc.Weixin.WxOpen.Helpers.EncryptHelper.DecryptRunData(sessionId, encryptedData, iv);

                //throw new WeixinException("解密PhoneNumber异常测试");//启用这一句，查看客户端返回的异常信息

                return Json(new { success = true, runData = runData });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });

            }
        }

        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="useBase64"></param>
        /// <param name="codeType"></param>
        /// <returns></returns>
        [HttpPost("GetQrCode")]
        public async Task<IActionResult> GetQrCode(string sessionId, string useBase64, string codeType = "1")
        {
            var sessionBag = SessionContainer.GetSession(sessionId);
            if (sessionBag == null)
            {
                return Json(new { success = false, msg = "请先登录！" });
            }

            MemoryStream ms = new MemoryStream();
            var openId = sessionBag.OpenId;
            var page = "pages/QrCode/QrCode";//此接口不可以带参数，如果需要加参数，必须加到scene中
            var scene = $"OpenIdSuffix:{openId.Substring(openId.Length - 10, 10)}#{codeType}";//储存OpenId后缀，以及codeType。scene最多允许32个字符
            LineColor lineColor = null;//线条颜色
            if (codeType == "2")
            {
                lineColor = new LineColor(221, 51, 238);
            }

            var result = await WxAppApi.GetWxaCodeUnlimitAsync(WxOpenAppId, ms, scene, page, lineColor: lineColor);
            ms.Position = 0;

            if (!useBase64.IsNullOrEmpty())
            {
                //转base64
                var imgBase64 = Convert.ToBase64String(ms.GetBuffer());
                return Json(new { success = true, msg = imgBase64, page = page });
            }
            else
            {
                //返回文件流
                return File(ms, "image/jpeg");
            }
        }
        /// <summary>
        /// 生成分销员二维码
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetReferralQrCode")]
        public async Task<IActionResult> GetReferralQrCode()
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    string page = "pages/index/index";//此接口不可以带参数，如果需要加参数，必须加到scene中
                    string scene = "Ref=" + CurrentUser.UserId;//储存OpenId后缀，以及codeType。scene最多允许32个字符

                    //图片名称
                    string picname = "ref_" + GuidUtils.CreateNo() + ".jpg";
                    var _tempfilepath = "/upload/" + CurrentUser.UserId + "/qrcode/";
                    var uploadPath = _filePath + _tempfilepath;
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    string qrcodePicPath = uploadPath + picname;//小程序二维码图片
                    var resultImg = await WxAppApi.GetWxaCodeUnlimitAsync(WxOpenAppId, qrcodePicPath, scene, page, 280);
                    if (resultImg.errcode == ReturnCode.请求成功)
                    {
                        string picnameh = "refs_" + CurrentUser.UserId + ".jpg";
                        var sor = _filePath + "/images/";
                        string qrcodebg = "share_bg2.jpg";

                        Bitmap cardbmp = new Bitmap(1080, 1926);
                        Graphics g = Graphics.FromImage(cardbmp);
                        g.SmoothingMode = SmoothingMode.HighQuality; ; //抗锯齿
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.High;
                        g.Clear(System.Drawing.Color.White); //白色填充

                        Bitmap bgimg = new Bitmap(1080, 1926);
                        //如果背景图片存在，
                        bgimg = (Bitmap)System.Drawing.Image.FromFile(sor + qrcodebg); //如果存在，读取背景图片
                        g.DrawImage(bgimg, 0, 0, 1080, 1926);
                        //合成二维码
                        Bitmap productImg = new Bitmap(280, 280);
                        productImg = (Bitmap)System.Drawing.Image.FromFile(qrcodePicPath);
                        g.DrawImage(productImg, 713, 1570, 280, 280);
                        //合成头像
                        Bitmap headerimg = new Bitmap(110, 110);
                        if (CurrentUser.HeadIcon.Contains("wx.qlogo.cn"))
                        {
                            headerimg = ImgHelper.GetNetImg(CurrentUser.HeadIcon);
                        }
                        else
                        {
                            headerimg = ImgHelper.GetNetImg(CurrentUser.HeadIcon);
                            //headerimg = (Bitmap)System.Drawing.Image.FromFile(_filePath + CurrentUser.HeadIcon);
                        }
                        headerimg = ImgHelper.CutEllipse(headerimg, new Rectangle(0, 0, 110, 110), new Size(110, 110));
                        g.DrawImage(headerimg, 100, 1505, 110, 110);

                        //合成文字
                        Font nickName = new Font("微软雅黑", 22);
                        Font adtxt = new Font("微软雅黑", 26);

                        StringFormat StringFormat = new StringFormat(StringFormatFlags.DisplayFormatControl);
                        g.DrawString(CurrentUser.NickName, nickName, new SolidBrush(System.Drawing.Color.LightGray), 100, 1630, StringFormat);
                        g.DrawString("推荐你一个超棒的汽车工程师圈子”", adtxt, new SolidBrush(System.Drawing.Color.Black), 100, 1680, StringFormat);

                        cardbmp.Save(uploadPath + picnameh, ImageFormat.Jpeg);
                        cardbmp.Dispose();

                        result.ResData = _tempfilepath + picnameh;
                    }
                    else
                    {
                        result.ErrCode = resultImg.errcode.ToString();
                        result.ErrMsg = resultImg.errmsg;
                    }
                }catch(Exception ex)
                {
                    result.ErrCode = "500";
                    result.ErrMsg = ex.Message;
                }
            }
            return ToJsonContent(result);

        }


        /// <summary>
        /// 生成内容详情海报
        /// </summary>
        /// <returns></returns>
        [HttpPost("ContentPlayBillQrCode")]
        public async Task<IActionResult> ContentPlayBillQrCode(ContentPlayBillModel info)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                MemoryStream ms = new MemoryStream();
                try
                {

                    if (info == null) { return ToJsonContent(result); }
                    string page = info.Page;//此接口不可以带参数，如果需要加参数，必须加到scene中
                    string scene = info.Scene; ;//id=xxxxxx,scene最多允许32个字符

                    //图片名称
                    string picname = "ref_" + GuidUtils.CreateNo() + ".jpg";
                    var _tempfilepath = "/upload/" + CurrentUser.UserId + "/contentqrcode/";
                    var uploadPath = _filePath + _tempfilepath;
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    string qrcodePicPath = uploadPath + picname;//小程序二维码图片
                    var resultImg = await WxAppApi.GetWxaCodeUnlimitAsync(WxOpenAppId, qrcodePicPath, scene, page, 280);
                    if (resultImg.errcode == ReturnCode.请求成功)
                    {
                        string picnameh = "c_" + GuidUtils.CreateNo() + ".jpg";
                        var sor = _filePath + "/images/";
                        string qrcodebg = "share_content_bg.jpg";
                        //if (!string.IsNullOrEmpty(info.ContentType))
                        //{
                        //    if (info.ContentType.ToLower() == "doc")
                        //    {
                        //        dynamic docSetting = JsonConvert.DeserializeObject(yuebonCacheHelper.Get("DocSetting").ToJson());
                        //        if (docSetting != null)
                        //        {
                        //            qrcodebg = docSetting.DetailShareBgImg;//.GetType().GetProperty("DetailShareBgImg").GetValue(docSetting).ToString();
                        //        }
                        //    }
                        //    else if (info.ContentType.ToLower() == "art")
                        //    {
                        //        dynamic artSetting = JsonConvert.DeserializeObject(yuebonCacheHelper.Get("ArtSetting").ToJson());
                        //        if (artSetting != null)
                        //        {
                        //            qrcodebg = artSetting.DetailShareBgImg;//.GetType().GetProperty("DetailShareBgImg").GetValue(artSetting).ToString();
                        //        }
                        //    }
                        //    else if (info.ContentType.ToLower() == "opp")
                        //    {
                        //        dynamic oppSetting = JsonConvert.DeserializeObject(yuebonCacheHelper.Get("OppSetting").ToJson());
                        //        if (oppSetting != null)
                        //        {
                        //            qrcodebg = oppSetting.DetailShareBgImg;//GetType().GetProperty("DetailShareBgImg").GetValue(oppSetting).ToString();
                        //        }
                        //    }
                        //    else if (info.ContentType.ToLower() == "job")
                        //    {
                        //        dynamic jobSetting = JsonConvert.DeserializeObject(yuebonCacheHelper.Get("JobSetting").ToJson());
                        //        if (jobSetting != null)
                        //        {
                        //            qrcodebg = jobSetting.DetailShareBgImg;//GetType().GetProperty("DetailShareBgImg").GetValue(jobSetting).ToString();
                        //        }
                        //    }
                        //}

                        Bitmap cardbmp = new Bitmap(460, 736);
                        Graphics g = Graphics.FromImage(cardbmp);
                        g.SmoothingMode = SmoothingMode.HighQuality; ; //抗锯齿
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.High;
                        g.Clear(System.Drawing.Color.White); //白色填充

                        Bitmap bgimg = new Bitmap(460, 736);
                        //如果背景图片存在，
                        bgimg = (Bitmap)Image.FromFile(qrcodebg); //如果存在，读取背景图片
                        g.DrawImage(bgimg, 0, 0, 460, 736);
                        //合成二维码
                        Bitmap productImg = new Bitmap(128, 128);
                        productImg = (Bitmap)Image.FromFile(qrcodePicPath);
                        g.DrawImage(productImg, 276, 580, 128, 128);
                        //合成文字
                        Font nickName = new Font("微软雅黑", 22);
                        Font adtxt = new Font("微软雅黑", 18);

                        StringFormat stringFormat = new StringFormat(StringFormatFlags.DisplayFormatControl);
                        Brush fontBrush = SystemBrushes.ControlText;
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        RectangleF rectangleF = new RectangleF(40, 500, 380, 80);   
                        g.DrawString(info.Title, adtxt, fontBrush, rectangleF, stringFormat);
                        cardbmp.Save(uploadPath + picnameh, ImageFormat.Jpeg);
                        cardbmp.Dispose();
                        ms.Dispose();

                        result.ResData = _tempfilepath + picnameh;
                    }
                    else
                    {
                        result.ErrCode = resultImg.errcode.ToString();
                        result.ErrMsg = resultImg.errmsg;
                    }
                }
                catch (Exception ex)
                {
                    result.ErrCode = "500";
                    result.ErrMsg = ex.Message;
                }
                finally{
                    ms.Dispose();
                }
            }
            return ToJsonContent(result);

        }
        /// <summary>
        /// 生成内容详情小程序二维码,返回Base64
        /// </summary>
        /// <returns></returns>
        [HttpPost("ContentWxAppletQrCode")]
        public async Task<IActionResult> ContentWxAppletQrCode(ContentPlayBillModel info)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                MemoryStream ms = new MemoryStream();
                try
                {

                    if (info == null) { return ToJsonContent(result); }
                    string page = info.Page;//此接口不可以带参数，如果需要加参数，必须加到scene中
                    string scene = info.Scene; ;//id=xxxxxx,scene最多允许32个字符

                    //图片名称
                    string picname = "ref_" + info.ContentType+info.ContentId + ".png";
                    var _tempfilepath = "/upload/" + CurrentUser.UserId + "/contentqrcode/";
                    var uploadPath = _filePath + _tempfilepath;
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    string qrcodePicPath = uploadPath + picname;//小程序二维码图片
                    if (!System.IO.File.Exists(qrcodePicPath))
                    {
                        var resultImg = await WxAppApi.GetWxaCodeUnlimitAsync(WxOpenAppId, qrcodePicPath, scene, page, 280, false, null, true);
                        ms.Position = 0;
                        if (resultImg.errcode == ReturnCode.请求成功)
                        {
                            //转base64
                            var imgBase64 = Convert.ToBase64String(ms.GetBuffer());
                            result.ErrCode = ErrCode.successCode;
                            result.ResData = imgBase64;
                            result.ErrMsg = _tempfilepath + picname;
                        }
                        else
                        {
                            result.ErrCode = resultImg.errcode.ToString();
                            result.ErrMsg = resultImg.errmsg;
                        }
                    }
                    else
                    {
                        result.ErrCode = ErrCode.successCode;
                        result.ErrMsg = _tempfilepath + picname;
                    }
                    
                }
                catch (Exception ex)
                {
                    result.ErrCode = "500";
                    result.ErrMsg = ex.Message;
                }
                finally
                {
                    ms.Dispose();
                }
            }
            return ToJsonContent(result);

        }

        /// <summary>
        /// 微信快速（一键）登录
        /// </summary>
        /// <returns></returns>
        [HttpPost("QuikLogin")]
        public IActionResult QuikLogin(WxUserInfo info )
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                if (info != null)
                {
                    UserInPutDto userInput = new UserInPutDto();
                    userInput.NickName = info.nickName;
                    userInput.HeadIcon = info.avatarUrl;
                    userInput.Gender = info.gender;
                    userInput.Country = info.country;
                    userInput.Province = info.province;
                    userInput.City = info.city;
                    userInput.language = info.language;
                    userInput.OpenId = info.openId;
                    userInput.OpenIdType = info.openIdType;
                    userInput.ReferralUserId = info.ReferralUserId;
                    UserApp userApp = new UserApp();
                    User user = userApp.GetUserByOpenId(info.openIdType, info.openId);
                    if (user == null)
                    {
                        result.Success = userApp.CreateUserByWxOpenId(userInput);
                    }
                    else
                    {
                        result.Success= userApp.UpdateUserByOpenId(userInput);
                    }
                    user = userApp.GetUserByOpenId(info.openIdType, info.openId);
                    if (user != null)
                    {
                        JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                        TokenResult tokenResult = tokenProvider.LoginToken(user, "wxapplet");
                        var currentSession = new UserAuthSession
                        {
                            UserId = user.Id,
                            Account = user.Account,
                            Name = user.RealName,
                            NickName = user.NickName,
                            AccessToken = tokenResult.AccessToken,
                            AppKey = "wxapplet",
                            CreateTime = DateTime.Now,
                            HeadIcon = user.HeadIcon,
                            Gender = user.Gender,
                            ReferralUserId = user.ReferralUserId,
                            MemberGradeId = user.MemberGradeId,
                            Role = new RoleApp().GetRoleEnCode(user.RoleId)
                        };

                        CurrentUser = currentSession;
                        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                        TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                        yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
                        result.ErrCode = ErrCode.successCode;
                        result.ResData = currentSession;

                    }
                    else
                    {
                        result.ErrCode = ErrCode.failCode;
                    }
                }
            }
            return ToJsonContent(result);
        }
        
        /// <summary>
        /// 根据OpenId登录
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        [HttpGet("LoginByOpenId")]
        public IActionResult LoginByOpenId(string openId)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                try
                {
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    UserApp userApp = new UserApp();
                    User user = userApp.GetUserByOpenId("yuebon.openid.wxapplet", openId);
                    if (user == null)
                    {
                        UserInPutDto userInput = new UserInPutDto();
                        userInput.OpenId = openId;
                        userInput.OpenIdType = "yuebon.openid.wxapplet";
                        userInput.NickName="游客";
                        result.Success = userApp.CreateUserByWxOpenId(userInput);
                    }
                    string userId = string.Empty;
                    if (result.ResData!= null)
                    {
                        userId = result.ResData.ToString();
                    }
                    if (user == null)
                    {
                        user = userApp.GetUserByOpenId("yuebon.openid.wxapplet", openId);
                    }
                    var currentSession = JsonConvert.DeserializeObject<UserAuthSession>(yuebonCacheHelper.Get("login_user_" + user.Id).ToJson());
                    if (currentSession == null||string.IsNullOrWhiteSpace(currentSession.AccessToken))
                    {
                        JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                        TokenResult tokenResult = tokenProvider.LoginToken(user, "wxapplet");
                        currentSession = new UserAuthSession
                        {
                            UserId = user.Id,
                            Account = user.Account,
                            Name = user.RealName,
                            NickName = user.NickName,
                            AccessToken = tokenResult.AccessToken,
                            AppKey = "wxapplet",
                            CreateTime = DateTime.Now,
                            HeadIcon = user.HeadIcon,
                            Gender = user.Gender,
                            ReferralUserId = user.ReferralUserId,
                            MemberGradeId = user.MemberGradeId,
                            Role = new RoleApp().GetRoleEnCode(user.RoleId),
                            MobilePhone=user.MobilePhone
                        };
                        TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                        yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
                    }
                    CurrentUser = currentSession;
                    result.ErrCode = ErrCode.successCode;
                    result.Success = true;
                    result.ResData = currentSession; //new AuthorizeApp().GetAccessedControls(user.Account);
                }
                catch (Exception ex)
                {
                    result.ErrMsg = ex.Message;
                }
            }
            return ToJsonContent(result);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="openId"></param>
        /// <returns>返回openId</returns>
        [HttpGet("CheckOpenId")]
        public IActionResult CheckOpenId(string openId)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            try
            {
                if (result.ErrCode == ErrCode.successCode)
                {

                    if (string.IsNullOrEmpty(openId) && !ValidateUserLogin(openId))
                    {
                        result.ErrCode = ErrCode.successCode;
                        result.ErrMsg = ErrCode.err50001;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据OpenId验证是否登录
        /// </summary>
        /// <param name="openId"></param>
        private bool ValidateUserLogin(string openId)
        {
            User user = new UserApp().GetUserByOpenId("yuebon.openid.wxapplet",openId);
            if (user != null&&user.Id==CurrentUser.UserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 检查一段文本是否含有违法违规内容
        /// </summary>
        /// <returns></returns>
        [HttpPost("CheckMsgSecCheck")]
        public IActionResult CheckMsgSecCheck(CheckMsgModel checkMsgModel)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                try
                {
                    if (checkMsgModel != null)
                    {
                        WxJsonResult res = WxAppApi.MsgSecCheck(WxOpenAppId, checkMsgModel.ContenText);
                        if (res.errcode == ReturnCode.请求成功)
                        {
                            result.ErrCode = ErrCode.successCode;
                            result.Success = true;
                            result.ResData = res;
                        }
                        else
                        {
                            result.ErrCode = ErrCode.failCode;
                            result.ErrMsg = "内容含有违法违规内容";
                            result.ResData = res;
                        }
                    }
                    else
                    {
                        result.ErrCode = ErrCode.failCode;
                        result.ErrMsg = "内容为空";
                    }
                }
                catch (Exception ex)
                {
                    result.ErrCode = "500";
                    result.ErrMsg = ex.Message;
                }
            }
            return ToJsonContent(result);

        }


        /// <summary>
        /// 校验一张图片是否含有违法违规内容
        /// </summary>
        /// <param name="filePath">要检测的图片文件，格式支持PNG、JPEG、JPG、GIF，图片尺寸不超过 750px x 1334px</param>
        /// <returns></returns>
        [HttpGet("ImgSecCheck")]
        public IActionResult ImgSecCheck(string filePath)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                try
                {
                    var fileDic = new Dictionary<string, string>();
                    WxJsonResult res = WxAppApi.ImgSecCheck(WxOpenAppId, filePath);
                    if (res.errcode == ReturnCode.请求成功)
                    {
                        result.ErrCode = ErrCode.successCode;
                        result.Success = true;
                        result.ResData = res;
                    }
                    else
                    {
                        result.ErrCode = ErrCode.failCode;
                        result.ErrMsg = "图片含有违法违规内容，请更换图片";
                        result.ResData = res;
                    }
                }
                catch (Exception ex)
                {
                    result.ErrCode = "500";
                    result.ErrMsg = ex.Message;
                }
            }
            return ToJsonContent(result);

        }

       
    }
}
