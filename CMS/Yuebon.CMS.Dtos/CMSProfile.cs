using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Dtos
{
    public class CMSProfile : Profile
    {
        public CMSProfile()
        {
           CreateMap<Articlecategory, ArticlecategoryOutputDto>();
           CreateMap<ArticlecategoryInputDto, Articlecategory>();
           CreateMap<Articlenews, ArticlenewsOutputDto>();
           CreateMap<ArticlenewsInputDto, Articlenews>();

        }
    }
}
