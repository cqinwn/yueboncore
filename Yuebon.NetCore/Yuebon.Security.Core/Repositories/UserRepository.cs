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

using Yuebon.Security.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.IDbContext;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : BaseRepository<User, string>, IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public UserRepository()
        {
        }

        public UserRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据用户账号查询用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<User> GetByUserName(string userName)
       {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"SELECT * FROM Sys_User t WHERE t.Account = @UserName";
                return await conn.QueryFirstOrDefaultAsync<User>(sql, new { @UserName = userName });
            }
       }

        /// <summary>
        /// 根据用户手机号码查询用户信息
        /// </summary>
        /// <param name="mobilephone">手机号码</param>
        /// <returns></returns>
        public async Task<User> GetUserByMobilePhone(string mobilephone)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"SELECT * FROM Sys_User t WHERE t.MobilePhone = @MobilePhone";
                return await conn.QueryFirstOrDefaultAsync<User>(sql, new { @MobilePhone = mobilephone });
            }
        }

        /// <summary>
        /// 根据Email查询用户信息
        /// </summary>
        /// <param name="email">email</param>
        /// <returns></returns>
        public async Task<User> GetUserByEmail(string email)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"SELECT * FROM Sys_User t WHERE t.Email = @Email";
                return await conn.QueryFirstOrDefaultAsync<User>(sql, new { @Email = email });
            }
        }
        /// <summary>
        /// 根据Email、Account、手机号查询用户信息
        /// </summary>
        /// <param name="account">登录账号</param>
        /// <returns></returns>
        public async Task<User> GetUserByLogin(string account)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"SELECT * FROM Sys_User t WHERE (t.Account = @Account Or t.Email = @Account Or t.MobilePhone = @Account)";
                return await conn.QueryFirstOrDefaultAsync<User>(sql, new {@Account = account });
            }
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        public  bool Insert(User entity, UserLogOn userLogOnEntity, IDbTransaction trans = null)
        {
            userLogOnEntity.Id = GuidUtils.CreateNo();
            userLogOnEntity.UserId = entity.Id;
            userLogOnEntity.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            userLogOnEntity.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(userLogOnEntity.UserPassword).ToLower(), userLogOnEntity.UserSecretkey).ToLower()).ToLower();
            DbContext.GetDbSet<User>().Add(entity);
            DbContext.GetDbSet<UserLogOn>().Add(userLogOnEntity);
            return DbContext.SaveChanges()>0;
            //using (IDbConnection conn = OpenSharedConnection())
            //{
            //    try
            //    {
            //        trans = conn.BeginTransaction();
            //        //OperationLogOfInsert(entity);
            //        long row = 0;
            //        userLogOnEntity.Id = GuidUtils.CreateNo();
            //        userLogOnEntity.UserId = entity.Id;
            //        userLogOnEntity.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            //        userLogOnEntity.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(userLogOnEntity.UserPassword).ToLower(), userLogOnEntity.UserSecretkey).ToLower()).ToLower();
            //        row = conn.Insert(entity, trans);
            //        long row1=conn.Insert(userLogOnEntity, trans);
                   
            //        trans.Commit();
            //        return (row + row1)>=2;
            //    }
            //    catch (Exception)
            //    {
            //        trans.Rollback();
            //        throw;
            //    }
                
            //}
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        public async Task<bool> InsertAsync(User entity, UserLogOn userLogOnEntity, IDbTransaction trans = null)
        {
            userLogOnEntity.Id = GuidUtils.CreateNo();
            userLogOnEntity.UserId = entity.Id;
            userLogOnEntity.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            userLogOnEntity.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(userLogOnEntity.UserPassword).ToLower(), userLogOnEntity.UserSecretkey).ToLower()).ToLower();
            DbContext.GetDbSet<User>().Add(entity);
            DbContext.GetDbSet<UserLogOn>().Add(userLogOnEntity);
            return await DbContext.SaveChangesAsync() > 0;

            //using (IDbConnection conn = OpenSharedConnection())
            //{
            //    try
            //    {
            //        trans = conn.BeginTransaction();
            //        long row = 0;
            //        userLogOnEntity.Id = GuidUtils.CreateNo();
            //        userLogOnEntity.UserId = entity.Id;
            //        userLogOnEntity.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            //        userLogOnEntity.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(userLogOnEntity.UserPassword).ToLower(), userLogOnEntity.UserSecretkey).ToLower()).ToLower();
            //        row = await conn.InsertAsync(entity, trans);
            //        long row1 = await conn.InsertAsync(userLogOnEntity, trans);

            //        trans.Commit();
            //        return (row + row1) >= 2;
            //    }
            //    catch (Exception)
            //    {
            //        trans.Rollback();
            //        throw;
            //    }

            //}
        }
        /// <summary>
        /// 注册用户,第三方平台
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="userOpenIds"></param>
        /// <param name="trans"></param>
        public bool Insert(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds, IDbTransaction trans = null)
        {

            DbContext.GetDbSet<User>().Add(entity);
            DbContext.GetDbSet<UserLogOn>().Add(userLogOnEntity); userLogOnEntity.Id = GuidUtils.CreateNo();
            userLogOnEntity.UserId = entity.Id;
            userLogOnEntity.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            userLogOnEntity.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(userLogOnEntity.UserPassword).ToLower(), userLogOnEntity.UserSecretkey).ToLower()).ToLower();
            DbContext.GetDbSet<User>().Add(entity);
            DbContext.GetDbSet<UserLogOn>().Add(userLogOnEntity);
            DbContext.GetDbSet<UserOpenIds>().Add(userOpenIds);
            return  DbContext.SaveChanges() > 0;
            //using (IDbConnection conn = OpenSharedConnection())
            //{
            //    try
            //    {
            //        trans = conn.BeginTransaction();
            //        //OperationLogOfInsert(entity);
            //        userLogOnEntity.Id = GuidUtils.CreateNo();
            //        userLogOnEntity.UserId = entity.Id;
            //        userLogOnEntity.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            //        userLogOnEntity.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(userLogOnEntity.UserPassword).ToLower(), userLogOnEntity.UserSecretkey).ToLower()).ToLower();
            //        long row= conn.Insert(entity, trans);
            //        long row1 = conn.Insert(userLogOnEntity, trans);
            //        long row2 = conn.Insert(userOpenIds, trans);
            //        trans.Commit();

            //        return (row + row1+ row2) >= 3;
            //    }
            //    catch (Exception)
            //    {
            //        trans.Rollback();
            //        throw;
            //    }
            //}
        }

        /// <summary>
        /// 根据微信UnionId查询用户信息
        /// </summary>
        /// <param name="unionId">UnionId值</param>
        /// <returns></returns>
        public User GetUserByUnionId(string unionId)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = string.Format("select * from dbo.Sys_User where UnionId = '{0}'", unionId);
                return conn.QueryFirstOrDefault<User>(sql);
            }
        }
        /// <summary>
        /// 根据第三方OpenId查询用户信息
        /// </summary>
        /// <param name="openIdType">第三方类型</param>
        /// <param name="openId">OpenId值</param>
        /// <returns></returns>
        public User GetUserByOpenId(string openIdType, string openId)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql =string.Format("select * from dbo.Sys_User as u join dbo.Sys_UserOpenIds as o on u.Id = o.UserId and  o.OpenIdType = '{0}' and o.OpenId = '{1}'",openIdType,openId);
                return conn.QueryFirstOrDefault<User>(sql);
            }
        }

        /// <summary>
        /// 根据userId查询用户信息
        /// </summary>
        /// <param name="openIdType">第三方类型</param>
        /// <param name="userId">userId</param>
        /// <returns></returns>
        public UserOpenIds GetUserOpenIdByuserId(string openIdType, string userId)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = string.Format("select * from dbo.Sys_UserOpenIds  where OpenIdType = '{0}' and UserId = '{1}'", openIdType, userId);
                return conn.QueryFirstOrDefault<UserOpenIds>(sql);
            }
        }

        /// <summary>
        /// 更新用户信息,第三方平台
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        public bool UpdateUserByOpenId(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds, IDbTransaction trans = null)
        {
            DbContext.GetDbSet<User>().Add(entity);
            DbContext.GetDbSet<UserOpenIds>().Add(userOpenIds);
            return DbContext.SaveChanges() > 0;
            //using (IDbConnection conn = OpenSharedConnection())
            //{
            //    try
            //    {
            //        trans = conn.BeginTransaction();
            //        //OperationLogOfInsert(entity);
            //        bool row = conn.Update<User>(entity, trans);
            //        bool row1 = conn.Update<UserLogOn>(userLogOnEntity, trans);
            //        trans.Commit();

            //        return row&&row&&row?true:false;
            //    }
            //    catch (Exception)
            //    {
            //        trans.Rollback();
            //        throw;
            //    }
            //}
        }

        /// <summary>
        /// 根据用户ID得到名片信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        //public UserNameCardOutPutDto GetUserNameCardInfo(string userid)
        //{
        //    using (IDbConnection conn = OpenSharedConnection())
        //    {
        //        string sql = @"select * from dbo.Vw_NameCard where MUserId='" + userid + "' ";
        //        return conn.QueryFirstOrDefault<UserNameCardOutPutDto>(sql);
        //    }
        //}




        /// <summary>
        /// 分页得到所有用户用于关注
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<UserAllListFocusOutPutDto> GetUserAllListFocusByPage(string currentpage,
            string pagesize, string userid)
        {
            string sqlRecord = "";
            string sql = "";

            int countNotIn = (int.Parse(currentpage) - 1) * int.Parse(pagesize);

            sqlRecord = @"select * from sys_user where nickname <> '游客' and  ismember=1 ";

            sql = @"SELECT TOP " + pagesize +
                @"
case when t2.Id is null then 'n' 
else 'y' end as IfFocus ,
IsNull(t3.totalFocus,0) as TotalFocus, 
t1.*
from 
(select ISNULL(tin2.VipGrade,0) as VipGrade,
ISNULL(tin2.IsAuthentication,0) as IsAuthentication,
ISNULL(tin2.AuthenticationType,0) as AuthenticationType,
tin1.* from sys_user tin1 
left join Sys_UserExtend tin2 on tin1.Id=tin2.UserId 
where nickname <> '游客' and  ismember=1) t1
left join 
(select * from Sys_UserFocus where creatorUserid='" + userid + @"') t2 
on t1.id=t2.focususerid 
left join 
(select  top 100 percent focusUserID,count(*) as totalFocus from dbo.Sys_UserFocus group by focusUserID order by totalfocus desc) t3
on t1.Id=t3.focusUserID 

where t1.Id not in 
(
select top " + countNotIn + @"
tt1.Id 
from 
(select ISNULL(tin2.VipGrade,0) as VipGrade,
ISNULL(tin2.IsAuthentication,0) as IsAuthentication,
ISNULL(tin2.AuthenticationType,0) as AuthenticationType,
tin1.* from sys_user tin1 
left join Sys_UserExtend tin2 on tin1.Id=tin2.UserId 
where nickname <> '游客' and  ismember=1) tt1
left join 
(select * from Sys_UserFocus where creatorUserid='" + userid + @"') tt2
on tt1.id=tt2.focususerid 
left join 
(select  top 100 percent focusUserID,count(*) as totalFocus from dbo.Sys_UserFocus group by focusUserID order by totalfocus desc) tt3
on tt1.Id=tt3.focusUserID 

order by tt3.totalFocus desc
)

order by t3.totalFocus desc";


            List<UserAllListFocusOutPutDto> list = new List<UserAllListFocusOutPutDto>();

            using (DbConnection conn = OpenSharedConnection())
            {
                IEnumerable<UserAllListFocusOutPutDto> infoOutputDto = conn.Query<UserAllListFocusOutPutDto>(sql);

                //得到总记录数
                List<UserAllListFocusOutPutDto> recordCountList = conn.Query<UserAllListFocusOutPutDto>(sqlRecord).AsList();

                list = infoOutputDto.AsList();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].RecordCount = recordCountList.Count;
                }
                return list;
            }
        }
    }
}