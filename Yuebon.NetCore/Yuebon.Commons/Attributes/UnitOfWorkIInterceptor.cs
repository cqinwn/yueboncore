using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Yuebon.Commons.Core.Dapper;

namespace Yuebon.Commons.Attributes
{
    /// <summary>
    /// 工作单元事务提交接收器
    /// </summary>
    public class UnitOfWorkIInterceptor : IInterceptor
    {
        private DapperDbContext dBContext;
        public UnitOfWorkIInterceptor(DapperDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void Intercept(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget;
            if (methodInfo == null)
                methodInfo = invocation.Method;

            UnitOfWorkAttribute transaction = methodInfo.GetCustomAttributes<UnitOfWorkAttribute>(true).FirstOrDefault();
            //如果标记了 [UnitOfWork]，并且不在事务嵌套中。
            if (transaction != null && dBContext.Committed)
            {
                //开启事务
                dBContext.BeginTransaction();
                try
                {
                    //事务包裹 查询语句 
                    //https://github.com/mysql-net/MySqlConnector/issues/405
                    invocation.Proceed();
                    //提交事务
                    dBContext.CommitTransaction();
                }
                catch (Exception ex)
                {
                    //回滚
                    dBContext.RollBackTransaction();
                    throw;
                }
            }
            else
            {
                //如果没有标记[UnitOfWork]，直接执行方法
                invocation.Proceed();
            }
        }
    }
}
