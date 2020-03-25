using System;
using Yuebon.Commons.IServices;
using Yuebon.CMS.Models;
using System.Collections.Generic;
using Yuebon.CMS.Dtos;

namespace Yuebon.CMS.IServices
{
    public interface IBannerService : IService<Banner, BannerOutputDto,string>
    {
        /// <summary>
        /// 根据广告位代码获取该广告位的广告内容
        /// </summary>
        /// <param name="enCode">广告位唯一编码</param>
        /// <returns></returns>
        IEnumerable<Banner> GetListByAdEnCode(string enCode);
    }
}