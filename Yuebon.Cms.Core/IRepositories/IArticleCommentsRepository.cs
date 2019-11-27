using System;
using Yuebon.Commons.IRepositories;
using Yuebon.CMS.Models;
using System.Collections.Generic;
using Yuebon.CMS.Dtos;
using Yuebon.Commons.Pages;
using System.Data;

namespace Yuebon.CMS.IRepositories
{
    public interface IArticleCommentsRepository : IRepository<ArticleComments,string>
    {
        /// <summary>
        /// 得到评论列表
        /// </summary>
        /// <param name="articleid">文档编号</param>
        /// <param name="userId">访问用户编号</param>
        /// <returns></returns>
       IEnumerable<ArticleCommentsOntputDto> GetArticleCommentsListInfo(string articleid, string userId);

        /// <summary>
        /// 分页查询包含用户信息
        /// 查询主表别名为t1,用户表别名为t2，在查询字段需要注意使用t1.xxx格式，xx表示主表字段
        /// 用户信息主要有用户账号：Account、昵称：NickName、真实姓名：RealName、头像：HeadIcon、手机号：MobilePhone
        /// 输出对象请在Dtos中进行自行封装，不能是使用实体Model类
        /// </summary>
        /// <param name="condition">查询条件字段需要加表别名</param>
        /// <param name="info">分页信息</param>
        /// <param name="fieldToSort">排序字段，也需要加表别名</param>
        /// <param name="desc">排序方式</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        List<ArticleCommentsOntputDto> FindWithPagerRelationUserNoCheck(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null);
    }


}