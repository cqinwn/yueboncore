using System;
using Yuebon.Commons.IServices;
using Yuebon.CMS.Models;
using Yuebon.CMS.Dtos;

namespace Yuebon.CMS.IServices
{
    public interface IArticleCommentsGoodService : IService<ArticleCommentsGood, ArticleCommentsGoodOutputDto, string>
    {
    }
}