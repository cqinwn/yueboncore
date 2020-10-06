USE [master]
GO

if exists (select * from sys.databases where name = 'YBNF')
	drop database [YBNF]

Create database [YBNF]
GO

ALTER DATABASE [YBNF] SET RECOVERY SIMPLE
GO

ALTER DATABASE [YBNF] SET AUTO_SHRINK ON 
GO

USE [YBNF]
GO
/****** Object:  Table [dbo].[Sys_APP]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_APP](
	[Id] [nvarchar](50) NOT NULL,
	[AppId] [nvarchar](50) NULL,
	[AppSecret] [nvarchar](50) NULL,
	[EncodingAESKey] [nvarchar](256) NULL,
	[RequestUrl] [nvarchar](600) NULL,
	[Token] [nvarchar](256) NULL,
	[IsOpenAEKey] [bit] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Area]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Area](
	[Id] [nvarchar](50) NOT NULL,
	[ParentId] [nvarchar](50) NULL,
	[Layers] [int] NULL,
	[EnCode] [nvarchar](50) NULL,
	[FullName] [nvarchar](400) NULL,
	[SimpleSpelling] [nvarchar](200) NULL,
	[FullIdPath] [nvarchar](600) NULL,
	[IsLast] [bit] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_DbBackup]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_DbBackup](
	[Id] [varchar](50) NOT NULL,
	[BackupType] [varchar](50) NULL,
	[DbName] [varchar](50) NULL,
	[FileName] [varchar](50) NULL,
	[FileSize] [varchar](50) NULL,
	[FilePath] [varchar](500) NULL,
	[BackupTime] [datetime] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_FilterIP]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_FilterIP](
	[Id] [varchar](50) NOT NULL,
	[FilterType] [bit] NULL,
	[StartIP] [varchar](50) NULL,
	[EndIP] [varchar](50) NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Function]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Function](
	[Id] [varchar](50) NOT NULL,
	[SystemTypeId] [varchar](50) NOT NULL,
	[ParentId] [varchar](50) NULL,
	[Layers] [int] NULL,
	[EnCode] [varchar](50) NULL,
	[FullName] [varchar](50) NULL,
	[Icon] [varchar](50) NULL,
	[Location] [int] NULL,
	[JsEvent] [varchar](50) NULL,
	[UrlAddress] [varchar](500) NULL,
	[Split] [bit] NULL,
	[IsPublic] [bit] NULL,
	[AllowEdit] [bit] NULL,
	[AllowDelete] [bit] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Items]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Items](
	[Id] [varchar](50) NOT NULL,
	[ParentId] [varchar](50) NULL,
	[EnCode] [varchar](50) NULL,
	[FullName] [varchar](50) NULL,
	[IsTree] [bit] NULL,
	[Layers] [int] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_ItemsDetail]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_ItemsDetail](
	[Id] [varchar](50) NOT NULL,
	[ItemId] [varchar](50) NULL,
	[ParentId] [varchar](50) NULL,
	[ItemCode] [varchar](50) NULL,
	[ItemName] [varchar](50) NULL,
	[SimpleSpelling] [varchar](500) NULL,
	[IsDefault] [bit] NULL,
	[Layers] [int] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Log]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Log](
	[Id] [varchar](50) NOT NULL,
	[Date] [datetime] NULL,
	[Account] [varchar](50) NULL,
	[NickName] [varchar](50) NULL,
	[OrganizeId] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[IPAddress] [varchar](50) NULL,
	[IPAddressName] [varchar](50) NULL,
	[ModuleId] [varchar](50) NULL,
	[ModuleName] [varchar](50) NULL,
	[Result] [bit] NULL,
	[Description] [text] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Menu]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Menu](
	[Id] [nvarchar](50) NOT NULL,
	[SystemTypeId] [nvarchar](50) NULL,
	[ParentId] [nvarchar](50) NULL,
	[Layers] [int] NULL,
	[EnCode] [varchar](50) NULL,
	[FullName] [varchar](50) NULL,
	[Icon] [varchar](50) NULL,
	[UrlAddress] [varchar](500) NULL,
	[Target] [varchar](50) NULL,
	[IsMenu] [bit] NULL,
	[IsExpand] [bit] NULL,
	[IsPublic] [bit] NULL,
	[AllowEdit] [bit] NULL,
	[AllowDelete] [bit] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_OpenIdSettings]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_OpenIdSettings](
	[OpenIdType] [nvarchar](200) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Description] [ntext] NULL,
	[Settings] [ntext] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Organize]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Organize](
	[Id] [varchar](50) NOT NULL,
	[ParentId] [varchar](50) NULL,
	[Layers] [int] NULL,
	[EnCode] [varchar](50) NULL,
	[FullName] [varchar](50) NULL,
	[ShortName] [varchar](50) NULL,
	[CategoryId] [varchar](50) NULL,
	[ManagerId] [varchar](50) NULL,
	[TelePhone] [varchar](20) NULL,
	[MobilePhone] [varchar](20) NULL,
	[WeChat] [varchar](50) NULL,
	[Fax] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[AreaId] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[AllowEdit] [bit] NULL,
	[AllowDelete] [bit] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Role]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Role](
	[Id] [varchar](50) NOT NULL,
	[OrganizeId] [varchar](50) NULL,
	[Category] [int] NULL,
	[EnCode] [varchar](50) NULL,
	[FullName] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[AllowEdit] [bit] NULL,
	[AllowDelete] [bit] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_RoleAuthorize]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_RoleAuthorize](
	[Id] [varchar](50) NOT NULL,
	[ItemType] [int] NULL,
	[ItemId] [varchar](50) NULL,
	[ObjectType] [int] NULL,
	[ObjectId] [varchar](50) NULL,
	[SortCode] [int] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_RoleData]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_RoleData](
	[Id] [nvarchar](50) NOT NULL,
	[RoleId] [nvarchar](50) NOT NULL,
	[BelongCompanys] [ntext] NULL,
	[BelongDepts] [ntext] NULL,
	[ExcludeDepts] [ntext] NULL,
	[Note] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Sequence]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Sequence](
	[Id] [nvarchar](50) NOT NULL,
	[SequenceName] [nvarchar](50) NOT NULL,
	[SequenceDelimiter] [nvarchar](50) NULL,
	[SequenceReset] [nvarchar](50) NULL,
	[Step] [int] NOT NULL,
	[CurrentNo] [int] NOT NULL,
	[CurrentCode] [nvarchar](200) NULL,
	[CurrentReset] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[EnabledMark] [bit] NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL,
 CONSTRAINT [PK_AD_DocNoGenerator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_SequenceRule]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_SequenceRule](
	[Id] [nvarchar](50) NOT NULL,
	[SequenceName] [nvarchar](200) NULL,
	[RuleOrder] [int] NOT NULL,
	[RuleType] [nvarchar](200) NOT NULL,
	[RuleValue] [nvarchar](200) NULL,
	[PaddingSide] [nvarchar](200) NULL,
	[PaddingWidth] [int] NOT NULL,
	[PaddingChar] [nvarchar](200) NULL,
	[Description] [nvarchar](200) NULL,
	[EnabledMark] [bit] NOT NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [nvarchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_AD_Sequence] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_SystemType]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_SystemType](
	[Id] [varchar](50) NOT NULL,
	[EnCode] [varchar](50) NULL,
	[FullName] [varchar](50) NULL,
	[Url] [varchar](250) NULL,
	[AllowEdit] [bit] NULL,
	[AllowDelete] [bit] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_TaskJobsLog]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_TaskJobsLog](
	[Id] [nvarchar](50) NOT NULL,
	[TaskId] [nvarchar](50) NOT NULL,
	[TaskName] [nvarchar](50) NULL,
	[JobAction] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
	[Description] [text] NULL,
	[CreatorTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Sys_TaskJobsLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_TaskManager]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_TaskManager](
	[Id] [nvarchar](50) NOT NULL,
	[TaskName] [nvarchar](300) NOT NULL,
	[GroupName] [nvarchar](300) NOT NULL,
	[Cron] [nvarchar](300) NOT NULL,
	[IsLocal] [bit] NOT NULL,
	[JobCallAddress] [nvarchar](300) NOT NULL,
	[JobCallParams] [nvarchar](300) NULL,
	[LastRunTime] [datetime] NULL,
	[LastErrorTime] [datetime] NULL,
	[NextRunTime] [datetime] NULL,
	[RunCount] [int] NOT NULL,
	[ErrorCount] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[IsSendMail] [bit] NULL,
	[EmailAddress] [nvarchar](200) NULL,
	[Status] [int] NOT NULL,
	[EnabledMark] [bit] NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL,
 CONSTRAINT [PK_Sys_TaskManager] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_UploadFile]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_UploadFile](
	[Id] [nvarchar](50) NOT NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[FilePath] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[FileType] [varchar](20) NULL,
	[FileSize] [int] NULL,
	[Extension] [varchar](20) NULL,
	[EnabledMark] [bit] NOT NULL,
	[SortCode] [int] NOT NULL,
	[DeleteMark] [bit] NOT NULL,
	[CreatorUserId] [uniqueidentifier] NULL,
	[CreateUserName] [nvarchar](50) NULL,
	[CreatorTime] [datetime] NOT NULL,
	[Thumbnail] [nvarchar](500) NULL,
	[BelongApp] [varchar](200) NULL,
	[BelongAppId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_User]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_User](
	[Id] [nvarchar](50) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[RealName] [varchar](50) NULL,
	[NickName] [varchar](50) NULL,
	[HeadIcon] [varchar](250) NULL,
	[Gender] [int] NULL,
	[Birthday] [datetime] NULL,
	[MobilePhone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[WeChat] [varchar](50) NULL,
	[ManagerId] [varchar](50) NULL,
	[SecurityLevel] [int] NULL,
	[Signature] [varchar](500) NULL,
	[Country] [nvarchar](200) NULL,
	[Province] [nvarchar](200) NULL,
	[City] [nvarchar](200) NULL,
	[District] [nvarchar](200) NULL,
	[OrganizeId] [varchar](50) NULL,
	[DepartmentId] [varchar](500) NULL,
	[RoleId] [varchar](500) NULL,
	[DutyId] [varchar](500) NULL,
	[IsAdministrator] [bit] NULL,
	[IsMember] [bit] NULL,
	[MemberGradeId] [varchar](50) NULL,
	[ReferralUserId] [varchar](50) NULL,
	[UnionId] [nvarchar](200) NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[EnabledMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_UserExtend]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_UserExtend](
	[Id] [nvarchar](50) NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[CardContent] [text] NULL,
	[Telphone] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[CompanyName] [nvarchar](250) NULL,
	[PositionTitle] [nvarchar](250) NULL,
	[WechatQrCode] [nvarchar](250) NULL,
	[IndustryId] [nvarchar](500) NULL,
	[OpenType] [int] NULL,
	[IsOtherShare] [bit] NULL,
	[ShareTitle] [nvarchar](250) NULL,
	[WebUrl] [nvarchar](250) NULL,
	[CompanyDesc] [text] NULL,
	[CardTheme] [nvarchar](250) NULL,
	[VipGrade] [nvarchar](50) NULL,
	[IsAuthentication] [bit] NULL,
	[AuthenticationType] [int] NULL,
	[EnabledMark] [bit] NOT NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL,
 CONSTRAINT [PK_CMS_NameCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_UserLogOn]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_UserLogOn](
	[Id] [varchar](50) NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[UserPassword] [varchar](50) NOT NULL,
	[UserSecretkey] [varchar](50) NOT NULL,
	[AllowStartTime] [datetime] NULL,
	[AllowEndTime] [datetime] NULL,
	[LockStartDate] [datetime] NULL,
	[LockEndDate] [datetime] NULL,
	[FirstVisitTime] [datetime] NULL,
	[PreviousVisitTime] [datetime] NULL,
	[LastVisitTime] [datetime] NULL,
	[ChangePasswordDate] [datetime] NULL,
	[MultiUserLogin] [bit] NULL,
	[LogOnCount] [int] NULL,
	[UserOnLine] [bit] NULL,
	[Question] [varchar](50) NULL,
	[AnswerQuestion] [varchar](500) NULL,
	[CheckIPAddress] [bit] NULL,
	[Language] [varchar](50) NULL,
	[Theme] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_UserOpenIds]    Script Date: 2020/10/6 8:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_UserOpenIds](
	[UserId] [nvarchar](50) NOT NULL,
	[OpenIdType] [nvarchar](256) NOT NULL,
	[OpenId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Sys_UserOpenIds] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[OpenIdType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Sys_Sequence] ADD  CONSTRAINT [DF_Sys_SequenceData_Step]  DEFAULT ((1)) FOR [Step]
GO
ALTER TABLE [dbo].[Sys_Sequence] ADD  CONSTRAINT [DF_Sys_Sequence_CurrentNo]  DEFAULT ((0)) FOR [CurrentNo]
GO
ALTER TABLE [dbo].[Sys_Sequence] ADD  CONSTRAINT [DF_Sys_Sequence_EnabledMark]  DEFAULT ((1)) FOR [EnabledMark]
GO
ALTER TABLE [dbo].[Sys_Sequence] ADD  CONSTRAINT [DF_Sys_Sequence_DeleteMark]  DEFAULT ((0)) FOR [DeleteMark]
GO
ALTER TABLE [dbo].[Sys_SequenceRule] ADD  CONSTRAINT [DF_Sys_SequenceRule_RuleOrder]  DEFAULT ((1)) FOR [RuleOrder]
GO
ALTER TABLE [dbo].[Sys_SequenceRule] ADD  CONSTRAINT [DF_Sys_SequenceRule_PaddingSide]  DEFAULT (N'left') FOR [PaddingSide]
GO
ALTER TABLE [dbo].[Sys_SequenceRule] ADD  CONSTRAINT [DF_AD_Sequence_CycleType]  DEFAULT ((2)) FOR [PaddingWidth]
GO
ALTER TABLE [dbo].[Sys_TaskManager] ADD  CONSTRAINT [DF_Sys_TaskManager_IsLocal]  DEFAULT ((1)) FOR [IsLocal]
GO
ALTER TABLE [dbo].[Sys_TaskManager] ADD  CONSTRAINT [DF_Sys_Task_ExeNumber]  DEFAULT ((0)) FOR [RunCount]
GO
ALTER TABLE [dbo].[Sys_TaskManager] ADD  CONSTRAINT [DF_Sys_TaskManager_ErrorCount]  DEFAULT ((0)) FOR [ErrorCount]
GO
ALTER TABLE [dbo].[Sys_TaskManager] ADD  CONSTRAINT [DF_Sys_TaskManager_IsSendMail]  DEFAULT ((0)) FOR [IsSendMail]
GO
ALTER TABLE [dbo].[Sys_TaskManager] ADD  CONSTRAINT [DF_Sys_Task_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Sys_TaskManager] ADD  CONSTRAINT [DF_Sys_Task_EnabledMark]  DEFAULT ((1)) FOR [EnabledMark]
GO
ALTER TABLE [dbo].[Sys_TaskManager] ADD  CONSTRAINT [DF_Sys_Task_DeleteMark]  DEFAULT ((0)) FOR [DeleteMark]
GO
ALTER TABLE [dbo].[Sys_UploadFile] ADD  DEFAULT ((1)) FOR [EnabledMark]
GO
ALTER TABLE [dbo].[Sys_UploadFile] ADD  DEFAULT ((0)) FOR [SortCode]
GO
ALTER TABLE [dbo].[Sys_UploadFile] ADD  DEFAULT ((0)) FOR [DeleteMark]
GO
ALTER TABLE [dbo].[Sys_UploadFile] ADD  DEFAULT (getdate()) FOR [CreatorTime]
GO
ALTER TABLE [dbo].[Sys_UserExtend] ADD  CONSTRAINT [DF_CMS_NameCard_IsOtherShare]  DEFAULT ((1)) FOR [IsOtherShare]
GO
ALTER TABLE [dbo].[Sys_UserExtend] ADD  CONSTRAINT [DF_CMS_NameCard_EnabledMark]  DEFAULT ((1)) FOR [EnabledMark]
GO
ALTER TABLE [dbo].[Sys_UserExtend] ADD  CONSTRAINT [DF_CMS_NameCard_DeleteMark]  DEFAULT ((0)) FOR [DeleteMark]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_APP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地区信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据备份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_DbBackup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP地址过滤' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_FilterIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能模块' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Function'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据字典' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Items'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据字典明细项目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'第三方开放平台设置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OpenIdSettings'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织机构' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Organize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目类型0-子系统，1-模块，2-列表/菜单，3-按钮' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize', @level2type=N'COLUMN',@level2name=N'ItemType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize', @level2type=N'COLUMN',@level2name=N'ItemId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对象分类/类型1-角色，2-部门，3-用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize', @level2type=N'COLUMN',@level2name=N'ObjectType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对象主键，对象分类/类型为角色时就是角色ID，部门就是部门ID，用户就是用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize', @level2type=N'COLUMN',@level2name=N'ObjectId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色功能权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色数据权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务单据号名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'SequenceName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分隔符' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'SequenceDelimiter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号重置规则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'SequenceReset'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'步长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'Step'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'CurrentNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'CurrentCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前重置依赖' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'CurrentReset'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'EnabledMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人组织' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'CompanyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'DeptId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'LastModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'LastModifyUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'DeleteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence', @level2type=N'COLUMN',@level2name=N'DeleteUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码规则名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'SequenceName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规则排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'RuleOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规则类别，const、number、date、timestamp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'RuleType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规则参数，如YYMMDD' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'RuleValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'补齐方向，Left或Right或None' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'PaddingSide'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'补齐宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'PaddingWidth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填充字符' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'PaddingChar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'EnabledMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人组织' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'CompanyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'DeptId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'LastModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'LastModifyUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'DeleteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule', @level2type=N'COLUMN',@level2name=N'DeleteUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序号编码规则表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SequenceRule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_SystemType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskJobsLog', @level2type=N'COLUMN',@level2name=N'TaskId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskJobsLog', @level2type=N'COLUMN',@level2name=N'TaskName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行动作' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskJobsLog', @level2type=N'COLUMN',@level2name=N'JobAction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行状态 正常、异常' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskJobsLog', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结果描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskJobsLog', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskJobsLog', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定时任务执行日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskJobsLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'TaskName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务分组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'GroupName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CRON表达式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'Cron'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是本地任务1：本地任务；0：外部接口任务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'IsLocal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'远程调用接口url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'JobCallAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务参数，JSON格式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'JobCallParams'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'LastRunTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次失败时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'LastErrorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下次执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'NextRunTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'RunCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'异常次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'ErrorCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否接受邮件通知' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'IsSendMail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'EnabledMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人组织' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'CompanyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'DeptId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'LastModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'LastModifyUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'DeleteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager', @level2type=N'COLUMN',@level2name=N'DeleteUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定时任务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_TaskManager'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上传文件管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UploadFile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名片内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'CardContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'Telphone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'PositionTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人微信二维码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'WechatQrCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行业' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'IndustryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隐私：0-不公开，1-公开；2-部分公开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'OpenType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许他人转发你的名片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'IsOtherShare'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转发标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'ShareTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'WebUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'CompanyDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名片样式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'CardTheme'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vip等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'VipGrade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否认证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'IsAuthentication'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'认证类型1-企业；2-个人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend', @level2type=N'COLUMN',@level2name=N'AuthenticationType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户扩展信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserExtend'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户登录信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserLogOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户与第三方开放平台对应关系' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserOpenIds'
GO
