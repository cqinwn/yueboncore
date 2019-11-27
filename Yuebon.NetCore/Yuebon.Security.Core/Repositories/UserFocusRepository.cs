using System;

using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using Dapper;
using System.Data;
using Yuebon.Commons.Options;
using System.Data.Common;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Helpers;
using Dapper.Contrib.Extensions;
using Yuebon.Security.Dtos;
using System.Collections.Generic;
using Yuebon.Commons.Extend;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserFocusRepository : BaseRepository<UserFocus, string>, IUserFocusRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public UserFocusRepository()
        {
            this.tableName = "Sys_UserFocus";
            this.primaryKey = "Id";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public long InsertFocus(string focusid, string creatoruserid)
        {
            string sql = @"select * from Sys_UserFocus where FocusUserId='" +
                focusid + "' and CreatorUserId='" + creatoruserid + "' ";

            using (DbConnection conn = OpenSharedConnection())
            {

                UserFocus userFocus = conn.QueryFirstOrDefault<UserFocus>(sql);

                if(userFocus != null)
                {
                    //不操作
                }
                else
                {
                    userFocus = new UserFocus();
                    userFocus.FocusUserId = focusid;
                    userFocus.CreatorUserId = creatoruserid;
                    userFocus.CreatorTime = DateTime.Now;
                }                

                return conn.Insert<UserFocus>(userFocus);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public int DeleteFocus(string focusid, string creatoruserid)
        {
            string sql = @"delete from Sys_UserFocus where FocusUserId='" +
                focusid + "' and CreatorUserId='" + creatoruserid + "' ";
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.Execute(sql);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public bool GetIfFocusStatus(string focusid, string creatoruserid)
        {
            string sql = @"select * from Sys_UserFocus where FocusUserId='" +
                focusid + "' and CreatorUserId='" + creatoruserid + "' ";

            using (DbConnection conn = OpenSharedConnection())
            {

                UserFocus userFocus = conn.QueryFirstOrDefault<UserFocus>(sql);

                if (userFocus != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public int GetTotalFocus(string creatoruserid)
        {
            string sql = @"select * from Sys_UserFocus where CreatorUserId='" + creatoruserid + "' ";
            using (DbConnection conn = OpenSharedConnection())
            {
                IEnumerable<UserFocus> list =  conn.Query<UserFocus>(sql);
                if(list!=null)
                {
                    return list.AsList().Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 分页得到列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<UserFocusExtendOutPutDto> GetUserFocusListByPage(string filter, string currentpage,
            string pagesize, string userid)
        {
            string sqlRecord = "";
            string sql = "";
            string searchkey = " and 1=1 ";
            string searchkeyIn = " and 1=1 ";
            if (!String.IsNullOrEmpty(filter))
            {
                searchkey += " and t2.NickName like '%" + filter + "%' ";
                searchkeyIn += " and tIn2.NickName like '%" + filter + "%' ";
            }

            int countNotIn = (int.Parse(currentpage) - 1) * int.Parse(pagesize);

            sqlRecord = @"select * from Sys_UserFocus where CreatorUserId='" + userid +"'";

            sql = @"SELECT TOP " + pagesize + @" t1.*,t2.NickName as FUserNickName,t2.HeadIcon as FUserHeadIcon,
t2.MobilePhone as FUserMobilePhone,ISNULL(t3.OpenType,1) as FUserOpenType 
FROM Sys_UserFocus t1
 inner join sys_user t2 on t1.FocusUserId=t2.id               
 left join sys_userextend t3 on t1.FocusUserId=t3.UserId   
             WHERE t1.id NOT IN

            (SELECT TOP " + countNotIn + @"  tIn1.id FROM
            Sys_UserFocus tIn1 
            inner join sys_user tIn2 on tIn1.FocusUserId=tIn2.id  
            where tIn1.CreatorUserId='" + userid + "' "+ searchkeyIn+ @" ORDER BY tIn1.CreatorTime DESC) 

            and t1.CreatorUserId='" + userid +"' "+ searchkey+ " ORDER BY t1.CreatorTime DESC";


            List<UserFocusExtendOutPutDto> list = new List<UserFocusExtendOutPutDto>();

            using (DbConnection conn = OpenSharedConnection())
            {
                IEnumerable<UserFocusExtendOutPutDto> infoOutputDto = conn.Query<UserFocusExtendOutPutDto>(sql);

                //得到总记录数
                List<UserFocusExtendOutPutDto> recordCountList = conn.Query<UserFocusExtendOutPutDto>(sqlRecord).AsList();

                list = infoOutputDto.AsList();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].RecordCount = recordCountList.Count;
                    list[i].ShowAddTime = ExtDate.ToEasyString(list[i].CreatorTime);

                }
                return list;
            }
        }
    }
}