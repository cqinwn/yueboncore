USE [YuebonFW]
GO
/****** Object:  Table [dbo].[CMS_Advert]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_Advert](
	[Id] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Description] [ntext] NULL,
	[EnCode] [nvarchar](200) NULL,
	[ViewNum] [int] NOT NULL,
	[ViewWidth] [int] NULL,
	[ViewHeight] [int] NULL,
	[Target] [nvarchar](50) NULL,
	[EnabledMark] [bit] NOT NULL,
	[DeleteMark] [bit] NOT NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_Albums]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_Albums](
	[Id] [nvarchar](50) NOT NULL,
	[Channel] [nvarchar](255) NULL,
	[ContentId] [nvarchar](255) NULL,
	[ThumbPath] [nvarchar](255) NULL,
	[OriginalPath] [nvarchar](255) NULL,
	[Remark] [nvarchar](500) NULL,
	[AddTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_ArticleBrowseTrajectory]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_ArticleBrowseTrajectory](
	[Id] [nvarchar](50) NOT NULL,
	[ArticleId] [varchar](50) NOT NULL,
	[LeaveTime] [datetime] NULL,
	[Duration] [int] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_CMS_ARTICLEBROWSETRAJECTORY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_ArticleCategory]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_ArticleCategory](
	[Id] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[ParentId] [nvarchar](50) NULL,
	[ClassPath] [nvarchar](500) NULL,
	[ClassLayer] [int] NULL,
	[SortCode] [int] NOT NULL,
	[Description] [ntext] NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[ImgUrl] [nvarchar](255) NULL,
	[SeoTitle] [nvarchar](255) NULL,
	[SeoKeywords] [nvarchar](255) NULL,
	[SeoDescription] [nvarchar](255) NULL,
	[IsHot] [bit] NULL,
	[EnabledMark] [bit] NOT NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_ArticleComments]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_ArticleComments](
	[Id] [nvarchar](50) NOT NULL,
	[ArticleNewsId] [varchar](50) NOT NULL,
	[ParentID] [varchar](50) NOT NULL,
	[Description] [text] NULL,
	[TotalGood] [int] NULL,
	[EnabledMark] [smallint] NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
	[CompanyId] [varchar](50) NULL,
	[DeptId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL,
 CONSTRAINT [PK_CMS_ARTICLECOMMENTS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_ArticleCommentsGood]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_ArticleCommentsGood](
	[Id] [nvarchar](50) NOT NULL,
	[CommentsId] [varchar](50) NOT NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_CMS_ARTICLECOMMENTSGOOD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_ArticleFavorite]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_ArticleFavorite](
	[Id] [nvarchar](50) NOT NULL,
	[ArticleNewsId] [varchar](50) NOT NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_CMS_ARTICLEFAVORITE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_ArticleGood]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_ArticleGood](
	[Id] [nvarchar](50) NOT NULL,
	[ArticleNewsId] [varchar](50) NOT NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_CMS_ARTICLEGOOD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_ArticleNews]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_ArticleNews](
	[Id] [nvarchar](50) NOT NULL,
	[CategoryId] [nvarchar](500) NOT NULL,
	[CategoryName] [nvarchar](500) NULL,
	[Title] [nvarchar](200) NULL,
	[SubTitle] [nvarchar](100) NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[ImgUrl] [nvarchar](255) NULL,
	[SeoTitle] [nvarchar](255) NULL,
	[SeoKeywords] [nvarchar](255) NULL,
	[SeoDescription] [nvarchar](255) NULL,
	[Tags] [nvarchar](500) NULL,
	[Zhaiyao] [nvarchar](255) NULL,
	[Description] [text] NULL,
	[SortCode] [int] NOT NULL,
	[IsMsg] [bit] NOT NULL,
	[IsTop] [bit] NOT NULL,
	[IsRed] [bit] NOT NULL,
	[IsHot] [bit] NOT NULL,
	[IsSys] [bit] NOT NULL,
	[IsNew] [bit] NOT NULL,
	[IsSlide] [bit] NOT NULL,
	[Click] [int] NOT NULL,
	[LikeCount] [int] NOT NULL,
	[TotalGood] [int] NULL,
	[TotalMsg] [int] NULL,
	[TotalBrowse] [int] NULL,
	[TotalFavorite] [int] NULL,
	[StarScore] [decimal](18, 2) NULL,
	[ExtraStarScore] [decimal](18, 2) NULL,
	[Source] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[EnabledMark] [bit] NOT NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_ArticleStar]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_ArticleStar](
	[Id] [nvarchar](50) NOT NULL,
	[ArticleNewsId] [varchar](50) NOT NULL,
	[StartScore] [decimal](2, 2) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_CMS_ARTICLESTAR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_Banner]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_Banner](
	[Id] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[AdId] [nvarchar](50) NOT NULL,
	[SubTitle] [nvarchar](100) NULL,
	[Zhaiyao] [nvarchar](255) NULL,
	[Description] [ntext] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[FilePath] [nvarchar](255) NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[SortCode] [int] NOT NULL,
	[EnabledMark] [bit] NOT NULL,
	[DeleteMark] [bit] NOT NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_PageCategory]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_PageCategory](
	[Id] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[ParentId] [nvarchar](50) NULL,
	[ClassPath] [nvarchar](500) NULL,
	[ClassLayer] [int] NULL,
	[SortCode] [int] NOT NULL,
	[Description] [ntext] NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[ImgUrl] [nvarchar](255) NULL,
	[SeoTitle] [nvarchar](255) NULL,
	[SeoKeywords] [nvarchar](255) NULL,
	[SeoDescription] [nvarchar](255) NULL,
	[EnabledMark] [bit] NOT NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_PageNews]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_PageNews](
	[Id] [nvarchar](50) NOT NULL,
	[CategoryId] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[SubTitle] [nvarchar](100) NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[ImgUrl] [nvarchar](255) NULL,
	[SeoTitle] [nvarchar](255) NULL,
	[SeoKeywords] [nvarchar](255) NULL,
	[SeoDescription] [nvarchar](255) NULL,
	[Tags] [nvarchar](500) NULL,
	[Zhaiyao] [nvarchar](255) NULL,
	[Description] [text] NULL,
	[SortCode] [int] NOT NULL,
	[IsMsg] [bit] NOT NULL,
	[IsTop] [bit] NOT NULL,
	[IsRed] [bit] NOT NULL,
	[IsHot] [bit] NOT NULL,
	[IsSlide] [bit] NOT NULL,
	[IsSys] [bit] NOT NULL,
	[Click] [int] NOT NULL,
	[LikeCount] [int] NOT NULL,
	[Source] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[EnabledMark] [bit] NOT NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CMS_UserArticleCategory]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMS_UserArticleCategory](
	[Id] [varchar](50) NOT NULL,
	[SelectItems] [varchar](max) NULL,
	[UnSelectItems] [varchar](max) NULL,
	[CreatorUserId] [varchar](50) NOT NULL,
	[CreatorTime] [datetime] NOT NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
 CONSTRAINT [PK_CMS_UserArticleCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_APP]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_APP](
	[Id] [nvarchar](50) NOT NULL,
	[AppId] [nvarchar](50) NULL,
	[AppSecret] [nvarchar](50) NULL,
	[EncodingAESKey] [nvarchar](256) NULL,
	[RequestUrl] [nvarchar](256) NULL,
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
/****** Object:  Table [dbo].[Sys_Area]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[SYS_Categories]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Categories](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CategoryCode] [varchar](50) NOT NULL,
	[Level] [int] NOT NULL,
	[PLevel] [int] NOT NULL,
	[EnabledMark] [smallint] NULL,
	[DeleteMark] [smallint] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
	[CompanyId] [varchar](50) NULL,
	[DeptId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL,
 CONSTRAINT [PK_SYS_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_DbBackup]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_FilterIP]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_FilterIP](
	[Id] [varchar](50) NOT NULL,
	[Type] [bit] NULL,
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
/****** Object:  Table [dbo].[Sys_Function]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_Items]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_ItemsDetail]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_Log]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_MemberMessageBox]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MemberMessageBox](
	[Id] [nvarchar](50) NOT NULL,
	[ContentId] [bigint] NULL,
	[MsgContent] [nvarchar](200) NULL,
	[Sernder] [nvarchar](100) NOT NULL,
	[Accepter] [nvarchar](100) NOT NULL,
	[IsRead] [bit] NOT NULL,
	[ReadDate] [datetime] NULL,
 CONSTRAINT [PK_Sys_MemberMessageBox] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_MemberSubscribeMsg]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MemberSubscribeMsg](
	[Id] [nvarchar](50) NOT NULL,
	[SubscribeUserId] [nvarchar](50) NOT NULL,
	[SubscribeType] [nvarchar](50) NOT NULL,
	[MessageTemplateId] [nvarchar](200) NOT NULL,
	[SubscribeTemplateId] [nvarchar](200) NOT NULL,
	[SubscribeStatus] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Menu]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_MessageMailBox]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MessageMailBox](
	[Id] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Description] [ntext] NULL,
	[IsMsgRemind] [bit] NULL,
	[IsSend] [bit] NULL,
	[SendDate] [datetime] NOT NULL,
	[IsCompel] [bit] NULL,
	[DeleteMark] [bit] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_MessageTemplates]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MessageTemplates](
	[Id] [nvarchar](50) NOT NULL,
	[MessageType] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SendEmail] [bit] NOT NULL,
	[SendSMS] [bit] NOT NULL,
	[SendInnerMessage] [bit] NOT NULL,
	[SendWeixin] [bit] NOT NULL,
	[WeixinTemplateId] [varchar](150) NULL,
	[TagDescription] [nvarchar](max) NULL,
	[EmailSubject] [nvarchar](max) NULL,
	[EmailBody] [ntext] NULL,
	[InnerMessageSubject] [nvarchar](max) NULL,
	[InnerMessageBody] [ntext] NULL,
	[SMSBody] [nvarchar](max) NULL,
	[WeiXinTemplateNo] [nvarchar](50) NULL,
	[WeiXinName] [nvarchar](100) NULL,
	[UseInWxApplet] [bit] NULL,
	[WxAppletTemplateId] [nvarchar](50) NULL,
	[AppletTemplateNo] [nvarchar](50) NULL,
	[AppletTemplateName] [nvarchar](100) NULL,
	[WxAppletSubscribeTemplateId] [nvarchar](50) NULL,
	[WxAppletSubscribeTemplateNo] [nvarchar](50) NULL,
	[WxAppletSubscribeTemplateName] [nvarchar](50) NULL,
	[SMSTemplateCode] [nvarchar](max) NULL,
	[SMSTemplateContent] [nvarchar](max) NULL,
	[WxO2OAppletTemplateId] [nvarchar](50) NULL,
	[UseInO2OApplet] [bit] NULL,
 CONSTRAINT [PK_Sys_MessageTemplates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_OpenIdSettings]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_OpenIdSettings](
	[OpenIdType] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Description] [ntext] NULL,
	[Settings] [ntext] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_OperateTrajectory]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_OperateTrajectory](
	[Id] [nvarchar](50) NOT NULL,
	[ContentId] [nvarchar](50) NOT NULL,
	[ContentTitle] [nvarchar](400) NULL,
	[AuthorUserId] [nvarchar](50) NULL,
	[ContentType] [nvarchar](50) NULL,
	[IsGood] [bit] NULL,
	[IsFavorite] [bit] NULL,
	[IsStar] [bit] NULL,
	[TotalDuration] [int] NULL,
	[TotalBrowse] [int] NULL,
	[TotalMsg] [int] NULL,
	[TotalDownload] [int] NULL,
	[IsExt1] [bit] NULL,
	[IsExt2] [bit] NULL,
	[IsExt3] [bit] NULL,
	[TotalExt1] [int] NULL,
	[TotalExt2] [int] NULL,
	[TotalExt3] [int] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sys_OperateTrajectory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_OperateTrajectoryDetail]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_OperateTrajectoryDetail](
	[Id] [nvarchar](50) NOT NULL,
	[ContentId] [nvarchar](50) NOT NULL,
	[ContentTitle] [nvarchar](400) NULL,
	[AuthorUserId] [nvarchar](50) NULL,
	[ContentType] [nvarchar](50) NULL,
	[LeaveTime] [datetime] NULL,
	[Duration] [int] NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [nvarchar](50) NULL,
	[OperateType] [nvarchar](50) NULL,
	[IsSendMSg] [bit] NOT NULL,
 CONSTRAINT [PK_Sys_OperateTrajectoryDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Organize]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_Role]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_RoleAuthorize]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_RoleData]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_SystemType]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_UploadFile]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_User]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_UserExtend]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_UserFocus]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_UserFocus](
	[Id] [nvarchar](50) NOT NULL,
	[FocusUserId] [nvarchar](50) NOT NULL,
	[CreatorUserId] [nvarchar](50) NOT NULL,
	[CreatorTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Sys_UserFocus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_UserFollow]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_UserFollow](
	[Id] [nvarchar](50) NULL,
	[UserId] [nvarchar](50) NULL,
	[FollowUserId] [nvarchar](50) NULL,
	[CreatorTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_UserLogOn]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_UserOpenIds]    Script Date: 2020/3/2 13:29:15 ******/
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
/****** Object:  Table [dbo].[Sys_WorkOrder]    Script Date: 2020/3/2 13:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_WorkOrder](
	[Id] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NULL,
	[SecretContent] [nvarchar](256) NULL,
	[Mobile] [nvarchar](256) NULL,
	[Attachment] [nvarchar](256) NULL,
	[Customer] [nvarchar](256) NULL,
	[Status] [char](1) NULL,
	[DeleteMark] [bit] NULL,
	[Description] [varchar](500) NULL,
	[CreatorTime] [datetime] NULL,
	[CreatorUserId] [varchar](50) NULL,
	[LastModifyTime] [datetime] NULL,
	[LastModifyUserId] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL,
	[DeleteUserId] [varchar](50) NULL,
	[CompanyId] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CMS_ArticleCategory] ADD  CONSTRAINT [DF_CMS_ArticleCategory_IsHot]  DEFAULT ((0)) FOR [IsHot]
GO
ALTER TABLE [dbo].[CMS_ArticleNews] ADD  CONSTRAINT [DF_CMS_ArticleNews_IsSys]  DEFAULT ((0)) FOR [IsSys]
GO
ALTER TABLE [dbo].[CMS_ArticleNews] ADD  CONSTRAINT [DF_CMS_ArticleNews_IsNew]  DEFAULT ((0)) FOR [IsNew]
GO
ALTER TABLE [dbo].[Sys_MemberSubscribeMsg] ADD  CONSTRAINT [DF_MemberSubscribeMsg_SubscribeStatus]  DEFAULT ((0)) FOR [SubscribeStatus]
GO
ALTER TABLE [dbo].[Sys_MessageMailBox] ADD  CONSTRAINT [DF_Sys_MessageMailBox_IsMsgRemind]  DEFAULT ((0)) FOR [IsMsgRemind]
GO
ALTER TABLE [dbo].[Sys_MessageMailBox] ADD  CONSTRAINT [DF_Sys_MessageMailBox_IsMsgRemind1]  DEFAULT ((0)) FOR [IsSend]
GO
ALTER TABLE [dbo].[Sys_MessageTemplates] ADD  CONSTRAINT [DF_Sys_MessageTemplates_SendEmail]  DEFAULT ((0)) FOR [SendEmail]
GO
ALTER TABLE [dbo].[Sys_MessageTemplates] ADD  CONSTRAINT [DF_Sys_MessageTemplates_SendSMS]  DEFAULT ((0)) FOR [SendSMS]
GO
ALTER TABLE [dbo].[Sys_MessageTemplates] ADD  CONSTRAINT [DF_Sys_MessageTemplates_SendInnerMessage]  DEFAULT ((0)) FOR [SendInnerMessage]
GO
ALTER TABLE [dbo].[Sys_MessageTemplates] ADD  CONSTRAINT [DF_Sys_MessageTemplates_SendWeixinMessage]  DEFAULT ((0)) FOR [SendWeixin]
GO
ALTER TABLE [dbo].[Sys_MessageTemplates] ADD  CONSTRAINT [DF__Sys_Me__UseIn__5DB5E0CB]  DEFAULT ((0)) FOR [UseInWxApplet]
GO
ALTER TABLE [dbo].[Sys_MessageTemplates] ADD  CONSTRAINT [DF__Sys_Me__UseIn__5EAA0504]  DEFAULT ((0)) FOR [UseInO2OApplet]
GO
ALTER TABLE [dbo].[Sys_OperateTrajectoryDetail] ADD  CONSTRAINT [DF_Sys_OperateTrajectoryDetail_IsSendMSg]  DEFAULT ((0)) FOR [IsSendMSg]
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleBrowseTrajectory', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleBrowseTrajectory', @level2type=N'COLUMN',@level2name=N'ArticleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'离开时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleBrowseTrajectory', @level2type=N'COLUMN',@level2name=N'LeaveTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问时长，精确到秒' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleBrowseTrajectory', @level2type=N'COLUMN',@level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问进入时间，创建时间。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleBrowseTrajectory', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleBrowseTrajectory', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章浏览轨迹表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleBrowseTrajectory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'ArticleNewsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'评论内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总点赞量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'TotalGood'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'EnabledMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'CompanyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'DeptId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'LastModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次修改用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'LastModifyUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'DeleteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments', @level2type=N'COLUMN',@level2name=N'DeleteUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章评论表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleComments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleCommentsGood', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleCommentsGood', @level2type=N'COLUMN',@level2name=N'CommentsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleCommentsGood', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleCommentsGood', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章评论点赞表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleCommentsGood'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleFavorite', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleFavorite', @level2type=N'COLUMN',@level2name=N'ArticleNewsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleFavorite', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleFavorite', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章收藏表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleFavorite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleGood', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleGood', @level2type=N'COLUMN',@level2name=N'ArticleNewsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleGood', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleGood', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章点赞表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleGood'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleStar', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleStar', @level2type=N'COLUMN',@level2name=N'ArticleNewsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'星级评分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleStar', @level2type=N'COLUMN',@level2name=N'StartScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleStar', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleStar', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章星级表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMS_ArticleStar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Categories', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Categories', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Categories', @level2type=N'COLUMN',@level2name=N'CategoryCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Categories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息内容Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MemberMessageBox', @level2type=N'COLUMN',@level2name=N'ContentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MemberMessageBox', @level2type=N'COLUMN',@level2name=N'Sernder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接受者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MemberMessageBox', @level2type=N'COLUMN',@level2name=N'Accepter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已读' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MemberMessageBox', @level2type=N'COLUMN',@level2name=N'IsRead'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订阅用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MemberSubscribeMsg', @level2type=N'COLUMN',@level2name=N'SubscribeUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订阅类型：SMS短信，WxApplet 微信小程序，InnerMessage站内消息 ，Email邮件通知' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MemberSubscribeMsg', @level2type=N'COLUMN',@level2name=N'SubscribeType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息模板Id主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MemberSubscribeMsg', @level2type=N'COLUMN',@level2name=N'MessageTemplateId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订阅状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MemberSubscribeMsg', @level2type=N'COLUMN',@level2name=N'SubscribeStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否短信提醒' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageMailBox', @level2type=N'COLUMN',@level2name=N'IsMsgRemind'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否发送' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageMailBox', @level2type=N'COLUMN',@level2name=N'IsSend'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是强制消息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageMailBox', @level2type=N'COLUMN',@level2name=N'IsCompel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否发送' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageMailBox', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信模板编号，如果为空则表示不支持微信消息提醒' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'WeiXinTemplateNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信模板中对应的名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'WeiXinName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否用于微信小程序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'UseInWxApplet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小程序模板ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'WxAppletTemplateId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小程序模板编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'AppletTemplateNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小程序模板名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'AppletTemplateName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订阅消息模板ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'WxAppletSubscribeTemplateId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模板编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'WxAppletSubscribeTemplateNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'WxAppletSubscribeTemplateName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'O2O小程序模板ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'WxO2OAppletTemplateId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否在O2O小程序中使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MessageTemplates', @level2type=N'COLUMN',@level2name=N'UseInO2OApplet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectory', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览总时长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectory', @level2type=N'COLUMN',@level2name=N'TotalDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览总时长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectory', @level2type=N'COLUMN',@level2name=N'TotalBrowse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览总时长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectory', @level2type=N'COLUMN',@level2name=N'TotalExt1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览总时长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectory', @level2type=N'COLUMN',@level2name=N'TotalExt2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问进入时间，创建时间。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectory', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectory', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作轨迹表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectoryDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容类型：商机-opp,文章：art；文库：doc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectoryDetail', @level2type=N'COLUMN',@level2name=N'ContentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'离开时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectoryDetail', @level2type=N'COLUMN',@level2name=N'LeaveTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问时长，精确到秒' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectoryDetail', @level2type=N'COLUMN',@level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问进入时间，创建时间。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectoryDetail', @level2type=N'COLUMN',@level2name=N'CreatorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectoryDetail', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商操作轨迹明细表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_OperateTrajectoryDetail'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserFollow', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'被关注用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserFollow', @level2type=N'COLUMN',@level2name=N'FollowUserId'
GO
