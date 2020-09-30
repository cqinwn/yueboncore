using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.IoC;
using Yuebon.Security.IServices;

namespace Yuebon.Quartz.Jobs
{
    /// <summary>
    /// 测试demo
    /// 
    /// </summary>
    public class SysLogJob : IJob
    {
        ITaskManagerService iService = IoCContainer.Resolve<ITaskManagerService>();

        public Task Execute(IJobExecutionContext context)
        {
            var jobId = context.MergedJobDataMap.GetString("OpenJob");
            //todo:这里可以加入自己的自动任务逻辑
            iService.RecordRun(jobId);
            return Task.Delay(1);
        }
    }
}
