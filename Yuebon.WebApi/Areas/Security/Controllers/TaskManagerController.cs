using Quartz;
using Yuebon.AspNetCore.ViewModel;
using Yuebon.Quartz.Jobs;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 定时任务接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class TaskManagerController : AreaApiController<TaskManager, TaskManagerOutputDto,TaskManagerInputDto,ITaskManagerService>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISequenceService _sequenceService;
        private ISchedulerCenter _schedulerCenter;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="schedulerCenter"></param>
        /// <param name="sequenceService"></param>
        public TaskManagerController(ITaskManagerService _iService, ISchedulerCenter schedulerCenter, ISequenceService sequenceService) : base(_iService)
        {
            iService = _iService;
            _schedulerCenter = schedulerCenter;
            _sequenceService=sequenceService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(TaskManager info)
        {
            info.Id= IdGeneratorHelper.IdSnowflake();
            info.TaskCode = _sequenceService.GetSequenceNext("TaskManager");
            if (string.IsNullOrEmpty(info.TaskCode))
            {
                info.TaskCode=IdGeneratorHelper.IdSnowflake().ToString();
            }
            info.DeleteMark = false;
            info.RunCount = 0;
            info.Status = 0;

            CronExpression cronExpression = new CronExpression(info.Cron);
            info.NextRunTime =cronExpression.GetNextValidTimeAfter(DateTime.Now).ToDateTime();
            info.CreatorTime =info.NextRunTime=info.LastRunTime=info.LastModifyTime= DateTime.Now;
            info.CreatorUserId =info.LastModifyUserId= CurrentUser.UserId;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(TaskManager info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
            CronExpression cronExpression = new CronExpression(info.Cron);
            info.NextRunTime = cronExpression.GetNextValidTimeAfter(DateTime.Now).ToDateTime();
           
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(TaskManager info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }
        /// <summary>
        /// 异步更新数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public override async Task<IActionResult> UpdateAsync(TaskManagerInputDto tinfo)
        {
            CommonResult result = new CommonResult();

            TaskManager info = iService.GetById(tinfo.Id);
            info.TaskName = tinfo.TaskName;
            info.GroupName = tinfo.GroupName;
            info.JobCallAddress = tinfo.JobCallAddress;
            info.JobCallParams = tinfo.JobCallParams;
            info.Cron = tinfo.Cron;
            info.EnabledMark = tinfo.EnabledMark;
            info.Description = tinfo.Description;
            info.IsLocal = tinfo.IsLocal;
            info.SendMail = tinfo.SendMail;
            info.EmailAddress = tinfo.EmailAddress;
            info.StartTime = tinfo.StartTime;
            info.EndTime = tinfo.EndTime;


            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 获取本地可执行的任务列表
        /// </summary>
        [HttpGet("GetLocalHandlers")]
        [YuebonAuthorize("List")]
        public IActionResult GetLocalHandlers()
        {
            CommonResult result = new CommonResult();
            try
            {
                result.ResData = QueryLocalHandlers();
                result.ErrCode = ErrCode.successCode;
            }
            catch (Exception ex)
            {
                result.ErrCode ="500";
                result.ErrMsg = ex.InnerException?.Message ?? ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 改变任务状态，启动/停止
        /// </summary>
        [HttpPost("ChangeStatus")]
        [YuebonAuthorize("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(ChangeJobStatusReq req)
        {
            CommonResult result = new CommonResult();
            try
            {
                TaskManager job = iService.GetById(req.Id);
               
                if (job == null)
                {
                    throw new Exception("任务不存在");
                }
                OnBeforeUpdate(job);
                job.Status = req.Status;
                if (job.Status == 0) //停止
                {
                    await _schedulerCenter.StopScheduleJobAsync(job);
                }
                else  //启动
                {
                    await _schedulerCenter.AddScheduleJobAsync(job);
                }
                if (job.Status == 1)
                {
                  await _schedulerCenter.StartScheduleAsync();
                }
                iService.Update(job);
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = "切换成功，可以在系统日志中查看运行结果";

            }
            catch (Exception ex)
            {
                result.ErrCode = "500";
                result.ErrMsg = ex.InnerException?.Message ?? ex.Message;
            }

            return ToJsonContent(result);
        }
        /// <summary>
        /// 异步批量设为数据有效性，设置为禁用时会停止已在运行的任务
        /// </summary>
        /// <param name="info">主键Id集合和有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMarktBatchAsync")]
        [YuebonAuthorize("Enable")]
        public override async Task<IActionResult> SetEnabledMarktBatchAsync(UpdateEnableViewModel info)
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (info.Flag == "1")
            {
                bl = true;
            }
            string where = string.Empty;
            where = "id in ("+ String.Join(",",info.Ids)+ ")";
            if (!bl)
            {
                foreach (long item in info.Ids)
                {
                    if (string.IsNullOrEmpty(item.ToString())) continue;
                    TaskManager job = await iService.GetAsync(long.Parse(item.ToString()));
                    if (job == null)
                    {
                        throw new Exception("任务不存在");
                    }
                    await _schedulerCenter.StopScheduleJobAsync(job);
                }
            }
            if (!string.IsNullOrEmpty(where))
            {
                bool blresut = await iService.SetEnabledMarkByWhereAsync(bl, where, CurrentUser.UserId);
                if (blresut)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43002;
                    result.ErrCode = "43002";
                }
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 异步批量物理删除
        /// </summary>
        /// <param name="info">删除信息</param>
        [HttpDelete("DeleteBatchAsync")]
        [YuebonAuthorize("Delete")]
        public override async Task<IActionResult> DeleteBatchAsync(DeletesInputDto info)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            where = "id in (" + String.Join(",", info.Ids) + ")";
            foreach (var item in info.Ids)
            {
                if (string.IsNullOrEmpty(item.ToString())) continue;
                TaskManager job = await iService.GetAsync(item.ToString().ToLong());
                if (job == null)
                {
                    throw new Exception("任务不存在");
                }

                await _schedulerCenter.StopScheduleJobAsync(job);
            }

            if (!string.IsNullOrEmpty(where))
            {
                bool bl = await iService.DeleteBatchWhereAsync(where).ConfigureAwait(false);
                if (bl)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43003;
                    result.ErrCode = "43003";
                }
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 返回系统的job接口
        /// </summary>
        /// <returns></returns>
        private static List<LocalTaskModel> QueryLocalHandlers()
        {
            var implementationAssembly = Assembly.Load("Yuebon.Quartz.Jobs");
            var implementationTypes =implementationAssembly.DefinedTypes.Where(t =>t.GetInterfaces().Contains(typeof(IJob))).ToArray(); 
            List<string> list= implementationTypes.Select(u => u.FullName).ToList();
            List<LocalTaskModel> resulList = new List<LocalTaskModel>();
            foreach(var item in list)
            {
                LocalTaskModel localTaskModel = new LocalTaskModel();
                localTaskModel.FullName = item;
                resulList.Add(localTaskModel);
            }
            return resulList;
        }
    }
}