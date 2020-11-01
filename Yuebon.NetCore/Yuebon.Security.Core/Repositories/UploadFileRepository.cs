using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class UploadFileRepository : BaseRepository<UploadFile, string>, IUploadFileRepository
    {
        public UploadFileRepository()
        {
        }

        public UploadFileRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据应用Id和应用标识批量更新数据
        /// </summary>
        /// <param name="beLongAppId">更新后的应用Id</param>
        /// <param name="oldBeLongAppId">更新前旧的应用Id</param>
        /// <param name="belongApp">应用标识</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool UpdateByBeLongAppId(string beLongAppId,string oldBeLongAppId, string belongApp=null, IDbTransaction trans = null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                try
                {
                    trans = conn.BeginTransaction();
                    string sqlStr = string.Format("update {0} set beLongAppId='{1}' where beLongAppId='{2}'",this.tableName,beLongAppId, oldBeLongAppId);
                    if (!string.IsNullOrEmpty(belongApp))
                    {
                        sqlStr = string.Format(" and BelongApp='{0}'",belongApp);
                    }
                    int num = conn.Execute(sqlStr, null, trans);
                    trans.Commit();
                    return num>=0;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    } 
}
