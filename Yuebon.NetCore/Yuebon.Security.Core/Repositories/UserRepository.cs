using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Repositories;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }



        /// <summary>
        /// �����û��˺Ų�ѯ�û���Ϣ
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<User> GetByUserName(string userName)
        {
            string sql = @"SELECT * FROM Sys_User t WHERE t.Account = @UserName";
            return await Db.Ado.SqlQuerySingleAsync<User>(sql, new { @UserName = userName });
        }

        /// <summary>
        /// �����û��ֻ������ѯ�û���Ϣ
        /// </summary>
        /// <param name="mobilephone">�ֻ�����</param>
        /// <returns></returns>
        public async Task<User> GetUserByMobilePhone(string mobilephone)
        {
            string sql = @"SELECT * FROM Sys_User t WHERE t.MobilePhone = @MobilePhone";
            return await Db.Ado.SqlQuerySingleAsync<User>(sql, new { @MobilePhone = mobilephone });
        }

        /// <summary>
        /// ����Email��ѯ�û���Ϣ
        /// </summary>
        /// <param name="email">email</param>
        /// <returns></returns>
        public async Task<User> GetUserByEmail(string email)
        {
            string sql = @"SELECT * FROM Sys_User t WHERE t.Email = @Email";
            return await Db.Ado.SqlQuerySingleAsync<User>(sql, new { @Email = email });
        }
        /// <summary>
        /// ����Email��Account���ֻ��Ų�ѯ�û���Ϣ
        /// </summary>
        /// <param name="account">��¼�˺�</param>
        /// <returns></returns>
        public async Task<User> GetUserByLogin(string account)
        {
            string sql = @"SELECT * FROM Sys_User t WHERE (t.Account = @Account Or t.Email = @Account Or t.MobilePhone = @Account)";
            return await Db.Ado.SqlQuerySingleAsync<User>(sql, new { @Account = account });
        }
        /// <summary>
        /// ע���û�
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        public  bool Insert(User entity, UserLogOn userLogOnEntity)
        {
            userLogOnEntity.Id = IdGeneratorHelper.IdSnowflake();
            userLogOnEntity.UserId = entity.Id;
            userLogOnEntity.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            userLogOnEntity.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(userLogOnEntity.UserPassword).ToLower(), userLogOnEntity.UserSecretkey).ToLower()).ToLower();
            Insert(entity);
            return Db.Insertable<UserLogOn>(userLogOnEntity).ExecuteCommand()>0;
            
        }

        /// <summary>
        /// ע���û�
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        public async Task<bool> InsertAsync(User entity, UserLogOn userLogOnEntity)
        {
            userLogOnEntity.Id = IdGeneratorHelper.IdSnowflake();
            userLogOnEntity.UserId = entity.Id;
            userLogOnEntity.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            userLogOnEntity.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(userLogOnEntity.UserPassword).ToLower(), userLogOnEntity.UserSecretkey).ToLower()).ToLower();
            Insert(entity);
            return await Db.Insertable<UserLogOn>(userLogOnEntity).ExecuteCommandAsync() > 0;
        }
        /// <summary>
        /// ע���û�,������ƽ̨
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="userOpenIds"></param>
        public bool Insert(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds)
        {

            //Db.Insertable<User>().Add(entity);
            //DbContext.GetDbSet<UserLogOn>().Add(userLogOnEntity); userLogOnEntity.Id = GuidUtils.CreateNo();
            //userLogOnEntity.UserId = entity.Id;
            //userLogOnEntity.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            //userLogOnEntity.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(userLogOnEntity.UserPassword).ToLower(), userLogOnEntity.UserSecretkey).ToLower()).ToLower();
            //DbContext.GetDbSet<User>().Add(entity);
            //DbContext.GetDbSet<UserLogOn>().Add(userLogOnEntity);
            //DbContext.GetDbSet<UserOpenIds>().Add(userOpenIds);
            //return  DbContext.SaveChanges() > 0;
            int row = 0;
            return row > 0;
        }

        /// <summary>
        /// ����΢��UnionId��ѯ�û���Ϣ
        /// </summary>
        /// <param name="unionId">UnionIdֵ</param>
        /// <returns></returns>
        public User GetUserByUnionId(string unionId)
        {
            string sql = string.Format("select * from Sys_User where UnionId = '{0}'", unionId);
            return Db.Ado.SqlQuerySingle<User>(sql);
        }
        /// <summary>
        /// ���ݵ�����OpenId��ѯ�û���Ϣ
        /// </summary>
        /// <param name="openIdType">����������</param>
        /// <param name="openId">OpenIdֵ</param>
        /// <returns></returns>
        public User GetUserByOpenId(string openIdType, string openId)
        {
            string sql = string.Format("select * from Sys_User as u join Sys_UserOpenIds as o on u.Id = o.UserId and  o.OpenIdType = '{0}' and o.OpenId = '{1}'", openIdType, openId);
            return Db.Ado.SqlQuerySingle<User>(sql);
        }

        /// <summary>
        /// ����userId��ѯ�û���Ϣ
        /// </summary>
        /// <param name="openIdType">����������</param>
        /// <param name="userId">userId</param>
        /// <returns></returns>
        public UserOpenIds GetUserOpenIdByuserId(string openIdType, long userId)
        {
            string sql = string.Format("select * from Sys_UserOpenIds  where OpenIdType = '{0}' and UserId = '{1}'", openIdType, userId);
            return Db.Ado.SqlQuerySingle<UserOpenIds>(sql);
        }

        /// <summary>
        /// �����û���Ϣ,������ƽ̨
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        public bool UpdateUserByOpenId(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds)
        {
            //DbContext.GetDbSet<User>().Add(entity);
            //DbContext.GetDbSet<UserOpenIds>().Add(userOpenIds);
            //return DbContext.SaveChanges() > 0;
            int row = 0;
            return row > 0;
        }





        /// <summary>
        /// ��ҳ�õ������û����ڹ�ע
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

            sqlRecord = @"select * from sys_user where nickname <> '�ο�' and  ismember=1 ";

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
where nickname <> '�ο�' and  ismember=1) t1
left join 
(select * from Sys_UserFocus where creatorUserid='" + userid + @"') t2 
on t1.id=t2.focususerid 
left join 
(select  top 100 percent focusUserID,count(*) as totalFocus from Sys_UserFocus group by focusUserID order by totalfocus desc) t3
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
where nickname <> '�ο�' and  ismember=1) tt1
left join 
(select * from Sys_UserFocus where creatorUserid='" + userid + @"') tt2
on tt1.id=tt2.focususerid 
left join 
(select  top 100 percent focusUserID,count(*) as totalFocus from Sys_UserFocus group by focusUserID order by totalfocus desc) tt3
on tt1.Id=tt3.focusUserID 

order by tt3.totalFocus desc
)

order by t3.totalFocus desc";



            List<UserAllListFocusOutPutDto> list = Db.Ado.SqlQuery<UserAllListFocusOutPutDto>(sql);

            //�õ��ܼ�¼��
            List<UserAllListFocusOutPutDto> recordCountList = Db.Ado.SqlQuery<UserAllListFocusOutPutDto>(sqlRecord);

            for (int i = 0; i < list.Count; i++)
            {
                list[i].RecordCount = recordCountList.Count;
            }
            return list;
        }
    }
}