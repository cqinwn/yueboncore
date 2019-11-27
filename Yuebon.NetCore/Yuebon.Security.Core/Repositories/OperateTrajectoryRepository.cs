using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Repositories;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class OperateTrajectoryRepository : BaseRepository<OperateTrajectory, string>, IOperateTrajectoryRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public OperateTrajectoryRepository()
        {
            this.tableName = "Sys_OperateTrajectory";
            this.primaryKey = "Id";
        }

        /// <summary>
        /// 分页得到列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <param name="authorid"></param>
        /// <returns></returns>
        public IEnumerable<OperateTrajectoryOutputDto> GetTrajectoryListByPage(string filter, string currentpage,
            string pagesize, string userid, string authorid)
        {
            string sqlRecord = "";
            string sql = "";
            int countNotIn = (int.Parse(currentpage) - 1) * int.Parse(pagesize);
                   
            sqlRecord = @"select * from Sys_OperateTrajectory where AuthorUserId='" + authorid + 
                "' and CreatorUserId='"+userid+"' ";

            sql = @"SELECT TOP " + pagesize + @" t1.*,t2.NickName as RealName,t2.HeadIcon,
ISNULL(t3.ImgUrl,'') as ArticleImg,
ISNULL(t4.IndexImgUrl,'') as JobImg,
ISNULL(t5.IndexImgUrl,'') as OppImg 
FROM Sys_OperateTrajectory t1
            inner join sys_user t2 on t1.creatorUserid=t2.id 
            left join cms_ArticleNews t3 on t1.ContentId=t3.Id 
            left join Job_Position t4 on t1.ContentId = t4.Id 
            left join OPP_Opportunity t5 on t1.ContentId = t5.Id 
             WHERE t1.id NOT IN

            (SELECT TOP " + countNotIn + @"  tIn1.id FROM
            Sys_OperateTrajectory tIn1 
            where tIn1.AuthorUserId='" + authorid + 
            "' and tIn1.CreatorUserId='" + userid + "' "+
            @"and tIn1.ContentId in (
    select ContentId from Sys_OperateTrajectorydetail where
    AuthorUserId = '"+authorid+@"' and CreatorUserId = '"+userid+@"' and CreatorTime>= '"+ filter+
    @" ') ORDER BY tIn1.CreatorTime DESC) 

            and t1.AuthorUserId='" + authorid + 
            "' and t1.CreatorUserId='" + userid + "' " +
   @"and t1.ContentId in (
    select ContentId from Sys_OperateTrajectorydetail where
    AuthorUserId = '"+authorid+@"' and CreatorUserId = '"+userid+@"' and CreatorTime>= '"+ filter+
    @" ') ORDER BY t1.CreatorTime DESC ";


            List<OperateTrajectoryOutputDto> list = new List<OperateTrajectoryOutputDto>();

            using (DbConnection conn = OpenSharedConnection())
            {
                IEnumerable<OperateTrajectoryOutputDto> positionOutputDto = conn.Query<OperateTrajectoryOutputDto>(sql);

                //得到总记录数
                List<OperateTrajectoryOutputDto> recordCountList = conn.Query<OperateTrajectoryOutputDto>(sqlRecord).AsList();

                list = positionOutputDto.AsList();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].RecordCount = recordCountList.Count;
                    list[i].ShowAddTime = ExtDate.ToBrowseTime(list[i].TotalDuration);
                    
                }
                return list;
            }

        }

        /// <summary>
        /// 得到汇总
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="authorid"></param>
        /// <returns></returns>
        public OperateTrajectorySumInfoTypeOutputDto GetSum(string userid, string authorid)
        {

            OperateTrajectorySumInfoTypeOutputDto model =
                new OperateTrajectorySumInfoTypeOutputDto();
            //分别看了几个
            string sqlSum = @"select ISNULL(count(contentType),0) as TypeNums,ContentType  
from Sys_OperateTrajectory 
where AuthorUserId='" + authorid + "' and CreatorUserId='"+userid+
"' group by ContentType ";
            //总浏览时长
            string sqlDuration = @"select ISNULL(sum(TotalDuration),0) as TotalDuration from Sys_OperateTrajectory 
where AuthorUserId='" + authorid + "' and CreatorUserId='" + userid +
"'";

            using (DbConnection conn = OpenSharedConnection())
            {
                //得到总记录数
                List<OperateTrajectorySumTypeOutputDto> recordCountList 
                    = conn.Query<OperateTrajectorySumTypeOutputDto>(sqlSum).AsList();

                OperateTrajectorySumDurationOutputDto duration=
                    conn.QueryFirst<OperateTrajectorySumDurationOutputDto>(sqlDuration);

                if (recordCountList.Count>0)
                {
                    foreach(OperateTrajectorySumTypeOutputDto item in recordCountList)
                    {
                        if(item.ContentType=="opp")
                        {
                            model.OppNums = int.Parse(item.TypeNums.ToString());
                        }
                        if (item.ContentType == "doc")
                        {
                            model.DocNums = int.Parse(item.TypeNums.ToString());
                        }
                        if (item.ContentType == "job")
                        {
                            model.JobNums = int.Parse(item.TypeNums.ToString());
                        }
                        if (item.ContentType == "art")
                        {
                            model.ArticleNums = int.Parse(item.TypeNums.ToString());
                        }
                    }
                }
                else
                {
                    model.OppNums = model.JobNums = model.ArticleNums = model.DocNums = 0;
                }

                model.TotalDuration = ExtDate.ToBrowseTime(duration.TotalDuration);
            }

            return model;

        }

    }
}