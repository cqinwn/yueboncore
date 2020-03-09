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
            CreateMap<AppInputDto,APP>();
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
            CreateMap<ItemsDetail, ItemsDetailOutputDto>();
            CreateMap<ItemsDetailInputDto, ItemsDetail>();
            CreateMap<Menu, MenuOutputDto>();
            CreateMap<MenuInputDto, Menu>();
            CreateMap<Organize, OrganizeOutputDto>();
            CreateMap<OrganizeInputDto, Organize>();
            CreateMap<Role, RoleOutputDto>();
            CreateMap<RoleInputDto, Role>();
            CreateMap<SystemType, SystemTypeOutputDto>();
            CreateMap<SystemTypeInputDto, SystemType>();
            CreateMap<WorkOrder, WorkOrderOutputDto>();
            CreateMap<WorkOrderInputDto, WorkOrder>();
            CreateMap<UploadFile, UploadFileOuputDto>();
            CreateMap<UploadFileInputDto, UploadFile>();
            CreateMap<UploadFile, UploadFileResultOuputDto>();
            CreateMap<User, UserOutPutDto>().ReverseMap();
            CreateMap<UserInPutDto, User>();
            CreateMap<User, UserLoginDto>()
                .ForMember(e => e.UserId, s => s.MapFrom(o => o.Id));
            CreateMap<List<WorkOrder>, List<WorkOrderOutputDto>>();
            CreateMap<OperateTrajectory, OperateTrajectoryOutputDto>();
            CreateMap<OperateTrajectoryDetail, OperateTrajectoryDetailOutputDto>();
            CreateMap<UserNameCardView, UserNameCardOutPutDto>();
            CreateMap<UserExtend, UserExtendOutPutDto>();
            CreateMap<UserFocus, UserFocusOutPutDto>();
            CreateMap<Log, LogOutPutDto>();
            CreateMap<LogInPutDto, Log>();
            CreateMap<FilterIP, FilterIPOutPutDto>();
            CreateMap<FilterIPInPutDto, FilterIP>();
            CreateMap<SysSetting, SysSettingOutputDto>();
        }
    }
}
