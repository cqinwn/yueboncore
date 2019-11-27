using Dapper;
using System;
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
    public class OperateTrajectoryDetailRepository : BaseRepository<OperateTrajectoryDetail, string>, IOperateTrajectoryDetailRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public OperateTrajectoryDetailRepository()
        {
            this.tableName = "Sys_OperateTrajectoryDetail";
            this.primaryKey = "Id";
        }

        /// <summary>
        /// 分页得到职位列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<OperateTrajectoryDetailOutputDto> GetTrajectoryListByPage(string filter, string currentpage,
            string pagesize, string userid)
        {
            string sqlRecord = "";
            string sql = "";
            int countNotIn = (int.Parse(currentpage) - 1) * int.Parse(pagesize);
                   
            sqlRecord = @"select * from Sys_OperateTrajectoryDetail where AuthorUserId='" 
+ userid + "'";

            sql = @"SELECT TOP " + pagesize + @" t1.*,t2.NickName as RealName,t2.HeadIcon FROM 
Sys_OperateTrajectoryDetail t1
            inner join sys_user t2 on t1.creatorUserid=t2.id 
             WHERE t1.id NOT IN

            (SELECT TOP " + countNotIn + @"  tIn1.id FROM
            Sys_OperateTrajectoryDetail tIn1
            inner join sys_user tIn2 on tIn1.creatorUserid = tIn2.id 
            where tIn1.AuthorUserId='" + userid +
 @"' and tIn1.CreatorUserId<>'"+userid+"' and tIn1.CreatorTime>='"+filter+@"' ORDER BY tIn1.CreatorTime DESC) 

            and t1.AuthorUserId='" + userid +
@"' and t1.CreatorUserId<>'" + userid + "' and t1.CreatorTime>='" + filter + "' ORDER BY t1.CreatorTime DESC";


            List<OperateTrajectoryDetailOutputDto> list = new List<OperateTrajectoryDetailOutputDto>();

            using (DbConnection conn = OpenSharedConnection())
            {
                IEnumerable<OperateTrajectoryDetailOutputDto> positionOutputDto = conn.Query<OperateTrajectoryDetailOutputDto>(sql);

                //得到总记录数
                List<OperateTrajectoryDetailOutputDto> recordCountList = conn.Query<OperateTrajectoryDetailOutputDto>(sqlRecord).AsList();

                list = positionOutputDto.AsList();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].RecordCount = recordCountList.Count;
                    list[i].ShowAddTime = ExtDate.ToEasyString(list[i].CreatorTime);
                    if(!Convert.IsDBNull(list[i].Duration))
                    {
                        list[i].BrowseTime = ExtDate.ToBrowseTime(list[i].Duration);
                    }
                    
                }
                return list;
            }

        }

        /// <summary>
        /// 得到总消息数
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetTotalCounts(string userid)
        {
            string sqlRecord = @"select * from Sys_OperateTrajectoryDetail where AuthorUserId='" + userid + "'";
            using (DbConnection conn = OpenSharedConnection())
            {
                //得到总记录数
                List<OperateTrajectoryDetailOutputDto> recordCountList = conn.Query<OperateTrajectoryDetailOutputDto>(sqlRecord).AsList();
                if(recordCountList.Count>0)
                {
                    return recordCountList.Count;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 得到筛选总条数
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetTotalCountsByFilter(string filter, string userid)
        {
            string sql = @"select* from Sys_OperateTrajectoryDetail 
                where AuthorUserId = '" + userid +
                "' and CreatorTime>='" + filter + "'";

            using (DbConnection conn = OpenSharedConnection())
            {
                //得到总记录数
                List<OperateTrajectoryDetailOutputDto> recordCountList = conn.Query<OperateTrajectoryDetailOutputDto>(sql).AsList();
                if (recordCountList.Count > 0)
                {
                    return recordCountList.Count;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 按用户汇总统计未推送的访问轨迹数据
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public List<OperateTrajectoryDetailTotalNoIsSendOutput> GetTotalNoIsSendList(string userId)
        {
            string sql = @"select * from (select count(ContentId) as TotalNum,'文章 ' as TotalDesc,'totalart' as OperateType from (
	        select ContentId from Sys_OperateTrajectoryDetail 
	        where  IsSendMSg=0 and AuthorUserId='" + userId + "' group by ContentId) tt  " +
             "union  select count(CreatorUserId)  as TotalNum, '人数 ' as TotalDesc,'totalman' as OperateType from (" +
             "select CreatorUserId from Sys_OperateTrajectoryDetail  where  IsSendMSg=0 and AuthorUserId= '" + userId + "' group by CreatorUserId	) tt " +
             "union " +
             "select count(1) as TotalNum, '操作 ' as TotalDesc,OperateType  from (select operateType from Sys_OperateTrajectoryDetail " +
             "where  IsSendMSg=0 and AuthorUserId='" + userId + "') tt group by OperateType) as tale1 " +
             "order by OperateType desc";

            using (DbConnection conn = OpenSharedConnection())
            {
                List<OperateTrajectoryDetailTotalNoIsSendOutput> list = conn.Query<OperateTrajectoryDetailTotalNoIsSendOutput>(sql).AsList();
                return list;
            }
        }


        /// <summary>
        /// 按内容发布者分组查询未发送的消息的浏览轨迹
        /// </summary>
        /// <returns></returns>
        public List<OperateTrajectoryDetailAuthorUserId> GetNoIsSendListGroupByAuthorUserId()
        {
            string sql = @"select AuthorUserId from Sys_OperateTrajectoryDetail where IsSendMSg=0 group by  AuthorUserId";
            using (DbConnection conn = OpenSharedConnection())
            {
                List<OperateTrajectoryDetailAuthorUserId> list = conn.Query<OperateTrajectoryDetailAuthorUserId>(sql).AsList();
                return list;
            }
        }

        /// <summary>
        /// 根据内容发布者更新发送状态
        /// </summary>
        /// <param name="AuthorUserId"></param>
        /// <returns></returns>
        public bool UpdateIsSendByAuthorUserId(string AuthorUserId)
        {
          return  UpdateTableField("IsSendMSg", 1, "AuthorUserId='" + AuthorUserId + "'");
        }
    }
}