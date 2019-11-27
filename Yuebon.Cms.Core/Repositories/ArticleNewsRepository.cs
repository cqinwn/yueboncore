using System;

using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using System.Collections.Generic;
using Yuebon.CMS.Dtos;
using System.Data.Common;
using Dapper;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Pages;
using System.Data;
using System.Reflection;
using Yuebon.Commons.Log;
using System.Text;

namespace Yuebon.CMS.Repositories
{
    public class ArticleNewsRepository : BaseRepository<ArticleNews, string>, IArticleNewsRepository
    {
		public ArticleNewsRepository()
        {
            this.tableName = "CMS_ArticleNews";
            this.primaryKey = "Id";
        }

        /// <summary>
        /// 得到商机列表信息，关联用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArticleNewsOutputDto GetArticleNewsListInfo(string id)
        {

            string strWhere = "";
            if (!String.IsNullOrEmpty(id))
            {
                strWhere = " and t1.Id='" + id + "' ";
            }

            using (DbConnection conn = OpenSharedConnection())
            {
                string sql = @"select  t1.*,t2.RealName as RealName,t2.NickName as NickName,t2.HeadIcon as HeadIcon from CMS_ArticleNews t1 left join 
            sys_user t2 on t1.CreatorUserId=t2.Id  where t1.EnabledMark=1";

                if (strWhere != "")
                {
                    sql = sql + strWhere;
                }

                ArticleNewsOutputDto oppOutputDto = conn.QueryFirstOrDefault<ArticleNewsOutputDto>(sql);
                oppOutputDto.ShowAddTime= ExtDate.ToEasyString(oppOutputDto.CreatorTime);
                return oppOutputDto;
            }
        }



        /// <summary>
        /// 分页得到文章列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleNewsOutputDto> GetArticleListByPageWithFlag(string currentpage,
            string pagesize, int flag, string userid)
        {
            string sqlRecord = "";
            string sql = "";
            int countNotIn = (int.Parse(currentpage) - 1) * int.Parse(pagesize);
            switch (flag)
            {
                case 1://我发布的                    
                    sqlRecord = @"select * from CMS_ArticleNews where enabledmark=1 and deletemark=0 and CreatorUserId='" + userid + "'";

                    sql = @"SELECT TOP " + pagesize + @" t1.*,t2.NickName as RealName,t2.HeadIcon as UserIcon FROM CMS_ArticleNews t1
            inner join sys_user t2 on t1.creatorUserid=t2.id 
             WHERE t1.id NOT IN

            (SELECT TOP " + countNotIn + @"  tIn1.id FROM
            CMS_ArticleNews tIn1
            inner join sys_user tIn2 on tIn1.creatorUserid = tIn2.id 
            where tIn1.enabledmark=1 and tIn1.deletemark=0 and tIn1.CreatorUserId='" + userid +
 @"' ORDER BY tIn1.CreatorTime DESC) 

            and t1.enabledmark=1 and t1.deletemark=0 and t1.CreatorUserId='" + userid +
@"' ORDER BY t1.CreatorTime DESC";
                    break;
                case 2://我收藏的

                    sqlRecord = @"select * from CMS_ArticleNews t1 
inner join CMS_ArticleFavorite t2 on t1.Id=t2.ArticleNewsId 
where t1.enabledmark=1 and t1.deletemark=0 and t2.CreatorUserId='" + userid + "'";

                    sql = @"SELECT TOP " + pagesize + @" t1.*,t3.NickName as RealName,t3.HeadIcon as UserIcon FROM CMS_ArticleNews t1
            inner join CMS_ArticleFavorite t2 on t1.Id=t2.ArticleNewsId 
inner join sys_user t3 on t1.creatorUserid=t3.id 
             WHERE t1.id NOT IN

            (SELECT TOP " + countNotIn + @"  tIn1.id FROM
            CMS_ArticleNews tIn1
            inner join CMS_ArticleFavorite tIn2 on  tIn1.Id=tIn2.ArticleNewsId 
inner join sys_user tIn3 on tIn1.creatorUserid=tIn3.id 
            where tIn1.enabledmark=1 and tIn1.deletemark=0 and tIn2.CreatorUserId='" + userid +
@"' ORDER BY tIn2.CreatorTime DESC) 

            and t1.enabledmark=1 and t1.deletemark=0 and t2.CreatorUserId='" + userid +
@"' ORDER BY t2.CreatorTime DESC";
                    break;
                case 3://我点赞的
                    sqlRecord = @"select * from CMS_ArticleNews t1 
inner join CMS_ArticleGood t2 on t1.Id=t2.ArticleNewsId 
where t1.enabledmark=1 and t1.deletemark=0 and t2.CreatorUserId='" + userid + "'";

                    sql = @"SELECT TOP " + pagesize + @" t1.*,t3.NickName as RealName,t3.HeadIcon as UserIcon FROM CMS_ArticleNews t1
            inner join CMS_ArticleGood t2 on t1.Id=t2.ArticleNewsId 
inner join sys_user t3 on t1.creatorUserid=t3.id 
             WHERE t1.id NOT IN

            (SELECT TOP " + countNotIn + @"  tIn1.id FROM
            CMS_ArticleNews tIn1
            inner join CMS_ArticleGood tIn2 on tIn1.Id=tIn2.ArticleNewsId  
inner join sys_user tIn3 on tIn1.creatorUserid=tIn3.id 
            where tIn1.enabledmark=1 and tIn1.deletemark=0 and tIn2.CreatorUserId='" + userid +
@"' ORDER BY tIn2.CreatorTime DESC) 

            and t1.enabledmark=1 and t1.deletemark=0 and t2.CreatorUserId='" + userid +
@"' ORDER BY t2.CreatorTime DESC";
                    break;
                case 4://我评论的
                    sqlRecord = @"select * from CMS_ArticleNews t1 
inner join (select ArticleNewsId,CreatorUserId,CreatorTime from CMS_ArticleComments group by ArticleNewsId,CreatorUserId,CreatorTime) t2 on t1.Id=t2.ArticleNewsId 
where t1.enabledmark=1 and t1.deletemark=0 and t2.CreatorUserId='" + userid + "'";

                    sql = @"SELECT TOP " + pagesize + @" t1.*,t3.NickName as RealName,t3.HeadIcon as UserIcon FROM CMS_ArticleNews t1
            inner join (select ArticleNewsId,CreatorUserId from CMS_ArticleComments group by ArticleNewsId,CreatorUserId) t2 on  t1.Id=t2.ArticleNewsId 
inner join sys_user t3 on t1.creatorUserid=t3.id 
             WHERE t1.id NOT IN

            (SELECT TOP " + countNotIn + @"  tIn1.id FROM
            CMS_ArticleNews tIn1
            inner join (select ArticleNewsId,CreatorUserId from CMS_ArticleComments group by ArticleNewsId,CreatorUserId) tIn2 on  tIn1.Id=tIn2.ArticleNewsId 
inner join sys_user tIn3 on tIn1.creatorUserid=tIn3.id 
            where tIn1.enabledmark=1 and tIn1.deletemark=0 and tIn2.CreatorUserId='" + userid +
@"' ) 

            and t1.enabledmark=1 and t1.deletemark=0 and t2.CreatorUserId='" + userid +
@"' ORDER BY t1.CreatorTime DESC";
                    break;
            }


            List<ArticleNewsOutputDto> list = new List<ArticleNewsOutputDto>();

            using (DbConnection conn = OpenSharedConnection())
            {
                IEnumerable<ArticleNewsOutputDto> docOutputDto = conn.Query<ArticleNewsOutputDto>(sql);

                //得到总记录数
                List<ArticleNewsOutputDto> recordCountList = conn.Query<ArticleNewsOutputDto>(sqlRecord).AsList();

                list = docOutputDto.AsList();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].RecordCount = recordCountList.Count;
                    list[i].ShowAddTime = ExtDate.ToEasyString(list[i].CreatorTime);
                }
                return list;
            }

        }

        public  List<ArticleNewsOutputDto> FindWithPagerUser(string condition, PagerInfo info, string fieldToSort, bool desc, string tablename = "", IDbTransaction trans = null)
        {
            List<ArticleNewsOutputDto> list = new List<ArticleNewsOutputDto>();
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(condition))
            {
                Log4NetHelper.WriteError(type, string.Format("检测出SQL注入的恶意数据, {0}", condition));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1=1";
            }
            if (tablename == "")
            {
                tablename = tableName;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                StringBuilder sb = new StringBuilder();
                int startRows = (info.CurrenetPageIndex - 1) * info.PageSize + 1;//起始记录
                int endNum = info.CurrenetPageIndex * info.PageSize;//结束记录
                string strOrder = string.Format(" {0} {1}", fieldToSort, desc ? "DESC" : "ASC");
                sb.AppendFormat("SELECT  count(*) FROM {0} where {1};", tablename, condition);
                sb.AppendFormat("SELECT {0} FROM {1} where {2} order by {3} rows BETWEEN {4} and {5}", selectedFields, tablename, condition, strOrder, startRows, endNum);


                var reader = conn.QueryMultiple(sb.ToString());
                info.RecordCount = reader.ReadFirst<int>();
                list = reader.Read<ArticleNewsOutputDto>().AsList();
                return list;
            }
        }
    }
}