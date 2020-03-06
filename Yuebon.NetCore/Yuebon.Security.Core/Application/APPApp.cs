using Yuebon.Commons.Core.Application;
using Yuebon.Commons.Entity;
using Yuebon.Commons.IoC;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Security.Services;

namespace Yuebon.Security.Application
{
    /// <summary>
    /// 应用
    /// </summary>
    public class APPApp 
    {
        IAPPService aPPService = IoCContainer.Resolve<IAPPService>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_unitOfWork"></param>
        /// <param name="_iService"></param>
        //public APPApp(IUnitOfWork _unitOfWork, IAPPService _iService) : base(_unitOfWork, _iService)
        //{
        //    service = _iService;
        //}


        /// <summary>
        /// 获取app对象,适用于授权查询
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <param name="secret">应用密钥</param>
        /// <returns></returns>
        public APP GetAPP(string appid,string secret)
        {
            return aPPService.GetAPP(appid,secret);
        }
        /// <summary>
        /// 获取app对象,不建议适用于授权查询
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <returns></returns>
        public APP GetAPP(string appid)
        {
            return aPPService.GetAPP(appid);
        }
    }
}
