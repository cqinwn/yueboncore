using AutoMapper;
using System.Collections.Generic;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class SecurityProfile : Profile
    {
        /// <summary>
        /// /
        /// </summary>
        public SecurityProfile()
        {
            CreateMap<APP, AppOutputDto>();
            CreateMap<APPInputDto, APP>();
            CreateMap<Area, AreaOutputDto>();
            CreateMap<Area, AreaPickerOutputDto>()
                .ForMember(s=>s.label,s=>s.MapFrom(o=>o.FullName))
                .ForMember(s => s.value, s => s.MapFrom(o => o.Id));
            CreateMap<Area, AreaSelect2OutDto>()
                .ForMember(e => e.text, s => s.MapFrom(o => o.FullName))
                .ForMember(e => e.id, s => s.MapFrom(o => o.Id));
            CreateMap<AreaInputDto, Area>();
            CreateMap<Function, FunctionOutputDto>();
            CreateMap<FunctionInputDto, Function>();
            CreateMap<Function, FunctionTreeTableOutputDto>();
            CreateMap<ItemsDetail, ItemsDetailOutputDto>();
            CreateMap<ItemsDetailInputDto, ItemsDetail>();
            CreateMap<Items, ItemsOutputDto>();
            CreateMap<ItemsInputDto, Items>();
            CreateMap<Menu, MenuOutputDto>();
            CreateMap<Menu, MenuTreeTableOutputDto>();
            CreateMap<Menu, ModuleFunctionOutputDto>()
                .ForMember(s => s.Id, s => s.MapFrom(o => o.Id))
                .ForMember(s=>s.FullName,s=>s.MapFrom(o=>o.FullName));
            CreateMap<MenuInputDto, Menu>();
            CreateMap<Organize, OrganizeOutputDto>();
            CreateMap<OrganizeInputDto, Organize>();
            CreateMap<Role, RoleOutputDto>();
            CreateMap<RoleInputDto, Role>();
            CreateMap<SystemType, SystemTypeOutputDto>();
            CreateMap<SystemTypeInputDto, SystemType>();
            CreateMap<UploadFile, UploadFileOutputDto>();
            CreateMap<UploadFileInputDto, UploadFile>();
            CreateMap<UploadFile, UploadFileResultOuputDto>();
            CreateMap<User, UserOutputDto>().ReverseMap();
            CreateMap<UserInputDto, User>();
            CreateMap<User, UserLoginDto>()
                .ForMember(e => e.UserId, s => s.MapFrom(o => o.Id));
            CreateMap<UserExtend, UserExtendOutputDto>();
            CreateMap<Log, LogOutputDto>();
            CreateMap<LogInputDto, Log>();
            CreateMap<FilterIP, FilterIPOutputDto>();
            CreateMap<FilterIPInputDto, FilterIP>();
            CreateMap<SysSetting, SysSettingOutputDto>();

            CreateMap<Sequence, SequenceOutputDto>();
            CreateMap<SequenceInputDto, Sequence>();
            CreateMap<SequenceRule, SequenceRuleOutputDto>();
            CreateMap<SequenceRuleInputDto, SequenceRule>(); 
            CreateMap<TaskManager, TaskManagerOutputDto>();
            CreateMap<TaskManagerInputDto, TaskManager>();
            CreateMap<TaskJobsLog, TaskJobsLogOutputDto>();
            CreateMap<TaskJobsLogInputDto, TaskJobsLog>();
        }
    }
}
