using System.Collections.Generic;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Commons;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Application
{
    public class AdvertApp
    {

        IAdvertService service = IoCContainer.Resolve<IAdvertService>();

        /// <summary>
        /// 根据广告位编码查询广告位
        /// </summary>
        /// <param name="enCode">广告位代码</param>
        /// <returns></returns>
        public Advert GetAdvertByEnCode(string enCode)
        {
            Advert advert = service.GetWhere(string.Format("EnCode='{0}'", enCode));
            return advert;
        }
        /// <summary>
        /// 根据广告位Id查询广告位
        /// </summary>
        /// <param name="id">广告位Id/param>
        /// <returns></returns>
        public Advert GetAdvertById(string id)
        {
            Advert advert = service.Get(id);
            return advert;
        }
    }
}

