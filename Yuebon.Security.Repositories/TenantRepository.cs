using Microsoft.IdentityModel.Logging;
using System;
using System.Threading.Tasks;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 租户仓储接口的实现
    /// </summary>
    public class TenantRepository : BaseRepository<Tenant>, ITenantRepository
    {
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// 注入EF上下文
        /// </summary>
        /// <param name="context"></param>
        public TenantRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        /// <summary>
        /// 根据租户账号查询租户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<Tenant> GetByUserName(string userName)
        {
            string sql = $"SELECT * FROM {this.tableName} t WHERE t.TenantName = @TenantName";
            return await Db.Ado.SqlQuerySingleAsync<Tenant>(sql, new { @TenantName = userName });
        }



        /// <summary>
        /// 注册租户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tenantLogOnEntity"></param>
        public async Task<bool> InsertAsync(Tenant entity, TenantLogon tenantLogOnEntity)
        {
            tenantLogOnEntity.Id = IdGeneratorHelper.IdSnowflake();
            tenantLogOnEntity.TenantId = entity.Id;
            tenantLogOnEntity.TenantSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            tenantLogOnEntity.TenantPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(tenantLogOnEntity.TenantPassword).ToLower(), tenantLogOnEntity.TenantSecretkey).ToLower()).ToLower();
            _unitOfWork.BeginTran();
            int row = 0;
            try
            {
                row = await Db.Insertable<Tenant>(entity).ExecuteCommandAsync();
                row = await Db.Insertable<TenantLogon>(tenantLogOnEntity).ExecuteCommandAsync();
                _unitOfWork.CommitTran();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("注册租户异常", ex);
                _unitOfWork.RollbackTran();
            }
            return row > 0;
        }
    }
}