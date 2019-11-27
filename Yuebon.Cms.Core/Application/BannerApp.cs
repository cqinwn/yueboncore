using System.Collections.Generic;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Commons;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Mapping;

namespace Yuebon.CMS.Application
{
    public class BannerApp
    {

        IBannerService serviceBanner = IoCContainer.Resolve<IBannerService>();
        IAdvertService serviceAdvert = IoCContainer.Resolve<IAdvertService>();

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">是否降序</param>
        /// <returns>指定对象的集合</returns>
        public List<BannerOutputDto> FindWithPager(string where, PagerInfo pagerInfo, string fieldToSort, bool desc)
        {
            List<BannerOutputDto> list= serviceBanner.FindWithPager(where, pagerInfo, fieldToSort, desc).MapTo<BannerOutputDto>();
            return list;
        }
        /// <summary>
        /// 根据广告位代码获取该广告位的广告内容
        /// </summary>
        /// <param name="enCode">广告位唯一编码</param>
        /// <returns></returns>
        public IEnumerable<BannerOutputDto> GetListByAdEnCode(string enCode)
        {
            IEnumerable<BannerOutputDto> list = serviceBanner.GetListByAdEnCode(enCode).MapTo<BannerOutputDto>();
            return list;
        }

        public BannerOutputDto GetWhere(string where)
        {
            BannerOutputDto bannerDto = serviceBanner.GetWhere(where).MapTo<BannerOutputDto>();
            return bannerDto;
        }
    }
}
