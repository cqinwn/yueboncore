using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Quartz.Models;

namespace Yuebon.Quartz.Dtos
{
    public class QuartzProfile : Profile
    {
        public QuartzProfile()
        {

            CreateMap<TaskManager, TaskManagerOutputDto>();
            CreateMap<TaskManagerInputDto, TaskManager>();
            CreateMap<TaskJobsLog, TaskJobsLogOutputDto>();
            CreateMap<TaskJobsLogInputDto, TaskJobsLog>();
            CreateMap<TaskJobsLog, TaskJobsLogVueTimelineOutputDto>()
                .ForMember(s => s.Id, s => s.MapFrom(o => o.Id))
                .ForMember(s => s.TaskId, s => s.MapFrom(o => o.TaskId))
                .ForMember(s => s.TaskName, s => s.MapFrom(o => o.TaskName))
                .ForMember(s => s.JobAction, s => s.MapFrom(o => o.JobAction))
                .ForMember(s => s.Description, s => s.MapFrom(o => o.Description))
                .ForMember(s => s.CreatorTime, s => s.MapFrom(o => o.CreatorTime))
                .ForMember(s => s.Color, s => s.MapFrom(o => (o.Status ? "#e4e7ed" : "#ff0000")));
        }
    }
}
