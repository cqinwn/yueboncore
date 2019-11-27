using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.CMS.Models;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Mapping;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class CMSProfile : Profile
    {
        public CMSProfile()
        {
            CreateMap<ArticleNews, ArticleNewsOutputDto>()
                .ForMember(entity => entity.ShowAddTime, opt => opt.MapFrom(src => src.CreatorTime.ToEasyString()));
            CreateMap<ArticleNewsInputDto, ArticleNews>();
            CreateMap<ArticleNewsInputDto, ArticleNews>();
            CreateMap<ArticleCategory, ArticleCategoryOutputDto>();
            CreateMap<ArticleCategory, ArticleSimpleCategoryOutputDto>();
            CreateMap<ArticleCategoryInputDto, ArticleCategory>();
            CreateMap<ArticleCategory, CategoryPickerOutputDto>()
                .ForMember(entity=>entity.value,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(entity => entity.label, opt => opt.MapFrom(src => src.Title));

            CreateMap<Advert, AdvertOutputDto>();
            CreateMap<AdvertInputDto, Advert>();

            CreateMap<Banner, BannerOutputDto>();
            CreateMap<BannerInputDto, Banner>();

            CreateMap<PageCategory, PageCategoryOutputDto>();
            CreateMap<PageCategoryInputDto, PageCategory>();

            CreateMap<PageNews, PageNewsOutputDto>();
            CreateMap<PageNewsInputDto, PageNews>();
            CreateMap<ArticleComments, ArticleCommentsOntputDto>();
            CreateMap<ArticleCommentsInputDto, ArticleComments>();
        }
    }
}
