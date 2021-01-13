USE [YBNF]
GO
INSERT [dbo].[CMS_Articlecategory] ([Id], [Title], [ParentId], [ClassPath], [ClassLayer], [SortCode], [LinkUrl], [ImgUrl], [SeoTitle], [SeoKeywords], [SeoDescription], [IsHot], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211164796431794', N'公告', N'', NULL, 1, 99, N'', NULL, NULL, NULL, NULL, NULL, N'', 1, 0, CAST(N'2021-01-12T11:16:47.963' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'2020101619434422287774', N'2020101619392209546893', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CMS_Articlecategory] ([Id], [Title], [ParentId], [ClassPath], [ClassLayer], [SortCode], [LinkUrl], [ImgUrl], [SeoTitle], [SeoKeywords], [SeoDescription], [IsHot], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211165664517119', N'通知', N'', NULL, 1, 99, N'', NULL, NULL, NULL, NULL, NULL, N'', 1, 0, CAST(N'2021-01-12T11:16:56.647' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'2020101619434422287774', N'2020101619392209546893', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_APP] ([Id], [AppId], [AppSecret], [EncodingAESKey], [RequestUrl], [Token], [IsOpenAEKey], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806291558018946', N'system', N'87135AB0160F706D8B47F06BDABA6FC6', N'A4F1DAA293D5A0655136A176A9C03666', N',192.168.1.106:809,localhost,192.168.1.104:808,192.168.1.107:809,192.168.0.104:808,192.168.31.246:809,192.168.1.110:811,base.api.yuebon.com,netcoreapi.ts.yuebon.com,s.v.yuebon.com,192.168.1.110:809;192.168.3.3:809;192.168.1.79:809,192.168.0.106:809,193.168.25.137:8082,193.168.25.137:8083,193.168.25.137:8086,193.168.25.137:8081,10.50.2.152:9528', N'0099', 1, 0, 1, N'', CAST(N'2018-06-29T15:58:05.543' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-10-15T17:14:18.207' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_APP] ([Id], [AppId], [AppSecret], [EncodingAESKey], [RequestUrl], [Token], [IsOpenAEKey], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201807031608165724', N'wmsapp', N'B8548D08B8BA023677939E3AE8A4388E', N'39641FFDAED557D2D6F2F1FC08A37696', N',192.168.1.110,localhost,192.168.1.110:809,192.168.1.107:809,192.168.1.88:809,192.168.31.246:809,192.168.1.110:810,192.168.1.110:811,192.168.1.110:809,192.168.31.246:809;192.168.31.246:809', N'00990l', 1, 0, 1, N'', CAST(N'2018-07-03T16:08:16.413' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'5AB270C0-5D33-4203-A54F-4552699FDA3C', N'80E10CD5-7591-40B8-A005-BCDE1B961E76', CAST(N'2020-10-15T17:14:18.207' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_APP] ([Id], [AppId], [AppSecret], [EncodingAESKey], [RequestUrl], [Token], [IsOpenAEKey], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201807031638418753', N'crmapp', N'393C2FA175AE2EBB3D4916E586827F51', NULL, N',192.168.1.110,localhost,192.168.1.110:809,192.168.1.107:809,192.168.1.88:809,192.168.31.246:809,192.168.1.110:810,192.168.1.110:811', N'00990l1', 0, 0, 1, NULL, CAST(N'2018-07-03T16:38:41.517' AS DateTime), N'201806202328082008', N'201806131523019338', N'201806122217567448', CAST(N'2020-10-15T17:14:49.340' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_APP] ([Id], [AppId], [AppSecret], [EncodingAESKey], [RequestUrl], [Token], [IsOpenAEKey], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201807031645057091', N'crmwapp', N'CADB0412E4A16A6448F16E062870CB45', N'B2CA7B802B4619B9566A74BFB3FEBBA6', N',192.168.1.110,localhost,192.168.1.110:809,192.168.1.107:809,192.168.1.88:809,192.168.31.246:809,192.168.1.110:810,192.168.1.110:811', NULL, 1, 0, 1, NULL, CAST(N'2018-07-03T16:45:05.187' AS DateTime), N'201806202328082008', N'201806131523019338', N'201806122217567448', CAST(N'2020-10-15T17:14:18.207' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_APP] ([Id], [AppId], [AppSecret], [EncodingAESKey], [RequestUrl], [Token], [IsOpenAEKey], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201904071956284182', N'zhantucar', N'B5B54305A3D65371F201C958FF7BF8D0', NULL, N',192.168.1.110,localhost,192.168.1.110:809,192.168.1.107:809,192.168.1.88:809,192.168.31.246:809,192.168.1.110:810,192.168.1.110:811', N'zhantucar', 0, 0, 1, NULL, CAST(N'2019-04-07T19:56:28.920' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'5AB270C0-5D33-4203-A54F-4552699FDA3C', N'80E10CD5-7591-40B8-A005-BCDE1B961E76', CAST(N'2020-10-15T17:14:18.207' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_APP] ([Id], [AppId], [AppSecret], [EncodingAESKey], [RequestUrl], [Token], [IsOpenAEKey], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201909031645057091', N'wxapplet', N'818C57B349758BB399CD67DCF9506B73', N'Q2CA7B802B4619B9566A74BFB3FEBBA8', N',192.168.1.110,localhost, 192.168.1.110:809, 192.168.1.102:809, 192.168.1.88:809, 192.168.0.64:812, 192.168.1.110:810, 192.168.1.110:811, api.qichetester.com, doc.api.qichetester.com, opp.api.qichetester.com, cms.api.qichetester.com,192.168.4.229', N'009900', 1, 0, 1, N'', CAST(N'2019-09-03T16:45:05.187' AS DateTime), N'201806202328082008', N'201806131523019338', N'201806122217567448', CAST(N'2020-10-15T17:14:18.207' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_APP] ([Id], [AppId], [AppSecret], [EncodingAESKey], [RequestUrl], [Token], [IsOpenAEKey], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020030615305549714879', N'wmspda', N'B679197AD12EB30D641730D50CB0D68C', N'9A511437956FAB1C5B2CDAF18BFAB6B0', N'172.20.88.11,netcoreapi.ts.yuebon.com,localhost:8080,localhost', N'F7468', 0, 0, 1, NULL, CAST(N'2020-03-06T15:30:55.497' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'201806131523019338', N'201906060900443360', CAST(N'2020-10-15T17:14:31.970' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_FilterIP] ([Id], [FilterType], [StartIP], [EndIP], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020042315450071372463', 0, N'192.168.1.101', N'192.168.1.199', 99, NULL, 0, N'', NULL, NULL, CAST(N'2020-12-30T11:38:29.337' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806291944303740', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'QuestionType', N'问题类型', 0, 2, 99, 0, 1, NULL, CAST(N'2018-06-29T19:44:30.390' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'', N'Sys_Items', N'通用字典', 0, 1, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'OrganizeCategory', N'机构分类', 0, 2, 2, 0, 1, NULL, NULL, NULL, CAST(N'2020-10-19T15:55:04.537' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'RoleType', N'角色类型', 0, 2, 3, 0, 1, NULL, NULL, NULL, CAST(N'2020-10-16T16:45:28.830' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'0DF5B725-5FB8-487F-B0E4-BC563A77EB04', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'DbType', N'数据库类型', 0, 2, 4, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'DbLogType', N'系统日志', NULL, NULL, 16, NULL, 1, NULL, CAST(N'2016-07-19T17:09:45.977' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'AuditState', N'审核状态', 0, 2, 6, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2748F35F-4EE2-417C-A907-3453146AAF67', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'Certificate', N'证件名称', 0, 2, 7, 0, 1, NULL, NULL, NULL, CAST(N'2020-04-23T19:20:47.243' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'Education', N'学历', 0, 2, 8, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'FA7537E2-1C64-4431-84BF-66158DD63269', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'101', N'婚姻', 0, 2, 12, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'8CEB2F71-026C-4FA6-9A61-378127AE7320', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'102', N'生育', 0, 2, 13, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'15023A4E-4856-44EB-BE71-36A106E2AA59', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'103', N'民族', 0, 2, 14, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'BDD797C3-2323-4868-9A63-C8CC3437AEAA', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'104', N'性别', 0, 2, 15, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2019111411143998775145', N'77070117-3F1A-41BA-BF81-B8B85BF10D5E', N'sysIndustry', N'行业', 1, 2, 67, 0, 1, NULL, CAST(N'2019-11-14T11:14:39.987' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-04-23T19:10:26.177' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518363999932307', N'2020031518574467761393', N'Unit', N'单位', 0, 2, 11, 0, 1, NULL, CAST(N'2020-03-15T18:36:40.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518502068403513', N'2020031518574467761393', N'StoreTemperatureLayer', N'存放温层', 0, 2, 15, 0, 1, NULL, CAST(N'2020-03-15T18:50:20.683' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518574467761393', N'', N'WMS', N'仓储系统', 0, 1, 2, 0, 1, NULL, CAST(N'2020-03-15T18:57:44.677' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518590238738718', N'2020031518574467761393', N'BillingWays', N'计费方式', 0, 2, 1, 0, 1, NULL, CAST(N'2020-03-15T18:59:02.387' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518590238738819', N'2020031518574467761393', N'OutStockBillStatus', N'出库单状态', 0, 2, 1, 0, 1, NULL, CAST(N'2020-03-15T18:59:02.387' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Items] ([Id], [ParentId], [EnCode], [FullName], [IsTree], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518590238738223', N'2020031518574467761393', N'OutStockType', N'出库类型', 0, 2, 1, 0, 1, NULL, CAST(N'2020-03-15T18:59:02.387' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806291944581505', N'201806291944303740', N'', N'系统异常', N'系统异常', N'', 0, NULL, 1, 0, 1, N'', CAST(N'2018-06-29T19:44:58.420' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2018-06-30T13:28:59.707' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806291945335901', N'201806291944303740', N'', N'新需求', N'新需求', N'', 0, NULL, 2, 0, 1, N'', CAST(N'2018-06-29T19:45:33.393' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2018-06-30T13:29:10.963' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'B97BD7F5-B212-40C1-A1F7-DD9A2E63EEF2', N'9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', N'', N'Group', N'集团', NULL, NULL, NULL, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2C3715AC-16F7-48FC-AB40-B0931DB1E729', N'9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', N'', N'Area', N'区域', NULL, NULL, NULL, 2, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'D082BDB9-5C34-49BF-BD51-4E85D7BFF646', N'9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', N'', N'Company', N'公司', NULL, NULL, NULL, 3, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2B540AC5-6E64-4688-BB60-E0C01DFA982C', N'9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', N'', N'SubCompany', N'子公司', NULL, NULL, NULL, 4, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'A64EBB80-6A24-48AF-A10E-B6A532C32CA6', N'9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', N'', N'Department', N'部门', NULL, NULL, NULL, 5, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'D1F439B9-D80E-4547-9EF0-163391854AB5', N'9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', N'', N'SubDepartment', N'子部门', NULL, NULL, NULL, 6, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'19EE595A-E775-409D-A48F-B33CF9F262C7', N'9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', N'', N'WorkGroup', N'小组', NULL, 0, NULL, 7, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'e5079bae-a8c0-4209-9019-6a2b4a3a7dac', N'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', N'', N'1', N'系统角色', NULL, 0, NULL, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'04aba88d-f09b-46c6-bd90-a38471399b0e', N'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', N'', N'2', N'业务角色', NULL, 0, NULL, 2, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'cc6daa5c-a71c-4b2c-9a98-336bc3ee13c8', N'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', N'', N'3', N'其他角色', NULL, 0, NULL, 3, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'7a6d1bc4-3ec7-4c57-be9b-b4c97d60d5f6', N'954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', N'', N'1', N'草稿', NULL, 0, NULL, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'ce340c73-5048-4940-b86e-e3b3d53fdb2c', N'954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', N'', N'2', N'提交', NULL, 0, NULL, 2, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'41053517-215d-4e11-81cd-367c0e9578d7', N'954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', N'', N'3', N'通过', NULL, 0, NULL, 3, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'e1979a4f-7fc1-42b9-a0e2-52d7059e8fb9', N'954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', N'', N'4', N'待审', NULL, 0, NULL, 4, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'63acf96d-6115-4d76-a994-438f59419aad', N'954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', N'', N'5', N'退回', NULL, 0, NULL, 5, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'8b7b38bf-07c5-4f71-a853-41c5add4a94e', N'954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', N'', N'6', N'完成', NULL, 0, NULL, 6, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'49b68663-ad01-4c43-b084-f98e3e23fee8', N'954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', N'', N'7', N'废弃', NULL, 0, NULL, 7, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'fa6c1873-888c-4b70-a2cc-59fccbb22078', N'0DF5B725-5FB8-487F-B0E4-BC563A77EB04', N'', N'SqlServer', N'SqlServer', NULL, 0, NULL, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'27e85cb8-04e7-447b-911d-dd1e97dfab83', N'0DF5B725-5FB8-487F-B0E4-BC563A77EB04', N'', N'Oracle', N'Oracle', NULL, 0, NULL, 2, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'34a642b2-44d4-485f-b3fc-6cce24f68b0f', N'0DF5B725-5FB8-487F-B0E4-BC563A77EB04', N'', N'MySql', N'MySql', NULL, 0, NULL, 3, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'1950efdf-8685-4341-8d2c-ac85ac7addd0', N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'', N'1', N'小学', NULL, 0, NULL, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'433511a9-78bd-41a0-ab25-e4d4b3423055', N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'', N'2', N'初中', NULL, 0, NULL, 2, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'acb128a6-ff63-4e25-b1e8-0a336ed3ab18', N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'', N'3', N'高中', NULL, 0, NULL, 3, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'a4974810-d88d-4d54-82cc-fd779875478f', N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'', N'4', N'中专', NULL, 0, NULL, 4, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'486a82e3-1950-425e-b2ce-b5d98f33016a', N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'', N'5', N'大专', NULL, 0, NULL, 5, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'34222d46-e0c6-446e-8150-dbefc47a1d5f', N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'', N'6', N'本科', NULL, 0, NULL, 6, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'3f280e2b-92f6-466c-8cc3-d7c8ff48cc8d', N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'', N'7', N'硕士', NULL, 0, NULL, 7, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'930b8de2-049f-4753-b9fd-87f484911ee4', N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'', N'8', N'博士', NULL, 0, NULL, 8, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'355ad7a4-c4f8-4bd3-9c72-ff07983da0f0', N'00F76465-DBBA-484A-B75C-E81DEE9313E6', N'', N'9', N'其他', NULL, 0, NULL, 9, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'5d6def0e-e2a7-48eb-b43c-cc3631f60dd7', N'BDD797C3-2323-4868-9A63-C8CC3437AEAA', N'', N'1', N'男', NULL, 0, NULL, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'822baf7c-abdb-4257-9b78-1f550806f544', N'BDD797C3-2323-4868-9A63-C8CC3437AEAA', N'', N'0', N'女', NULL, 0, NULL, 2, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'738edf2a-d59f-4992-97ef-d847db23bcb8', N'FA7537E2-1C64-4431-84BF-66158DD63269', N'', N'1', N'已婚', NULL, 0, NULL, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'a7c4aba2-a891-4558-9b0a-bd7a1100a645', N'FA7537E2-1C64-4431-84BF-66158DD63269', N'', N'2', N'未婚', NULL, 0, NULL, 2, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'f9609400-7caf-49af-ae3c-7671a9292fb3', N'FA7537E2-1C64-4431-84BF-66158DD63269', N'', N'3', N'离异', NULL, 0, NULL, 3, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'a6f271f9-8653-4c5c-86cf-4cd00324b3c3', N'FA7537E2-1C64-4431-84BF-66158DD63269', N'', N'4', N'丧偶', NULL, 0, NULL, 4, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'7c1135be-0148-43eb-ae49-62a1e16ebbe3', N'FA7537E2-1C64-4431-84BF-66158DD63269', N'', N'5', N'其他', NULL, 0, NULL, 5, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'582e0b66-2ee9-4885-9f0c-3ce3ebf96e12', N'8CEB2F71-026C-4FA6-9A61-378127AE7320', N'', N'1', N'已育', NULL, 0, NULL, 1, 0, 1, NULL, NULL, NULL, CAST(N'2020-10-13T14:45:03.067' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'de2167f3-40fe-4bf7-b8cb-5b1c554bad7a', N'8CEB2F71-026C-4FA6-9A61-378127AE7320', N'', N'2', N'未育', NULL, 0, NULL, 2, 0, 1, NULL, NULL, NULL, CAST(N'2020-10-13T14:45:03.067' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'49300258-1227-4b85-b6a2-e948dbbe57a4', N'15023A4E-4856-44EB-BE71-36A106E2AA59', N'', N'汉族', N'汉族', NULL, 0, NULL, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'd69cb819-2bb3-4e1d-9917-33b9a439233d', N'2748F35F-4EE2-417C-A907-3453146AAF67', N'', N'1', N'身份证', NULL, 0, NULL, 1, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'4c2f2428-2e00-4336-b9ce-5a61f24193f6', N'2748F35F-4EE2-417C-A907-3453146AAF67', N'', N'2', N'士兵证', NULL, 0, NULL, 2, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'48c4e0f5-f570-4601-8946-6078762db3bf', N'2748F35F-4EE2-417C-A907-3453146AAF67', N'', N'3', N'军官证', NULL, 0, NULL, 3, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'0096ad81-4317-486e-9144-a6a02999ff19', N'2748F35F-4EE2-417C-A907-3453146AAF67', N'', N'4', N'护照', NULL, 0, NULL, 4, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'ace2d5e8-56d4-4c8b-8409-34bc272df404', N'2748F35F-4EE2-417C-A907-3453146AAF67', N'', N'5', N'其它', NULL, 0, NULL, 5, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'795f2695-497a-4f5e-ab1d-706095c1edb9', N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'', N'Other', N'其他', NULL, 0, NULL, 0, NULL, 1, NULL, CAST(N'2016-07-19T17:10:33.007' AS DateTime), NULL, CAST(N'2016-07-19T18:20:09.773' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'643209c8-931b-4641-9e04-b8bdd11800af', N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'', N'Login', N'登录', NULL, 0, NULL, 1, NULL, 1, NULL, CAST(N'2016-07-19T17:10:39.943' AS DateTime), NULL, CAST(N'2016-07-19T18:20:17.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'3c884a03-4f34-4150-b134-966387f1de2a', N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'', N'Exit', N'退出', NULL, 0, NULL, 2, NULL, 1, NULL, CAST(N'2016-07-19T17:10:49.840' AS DateTime), NULL, CAST(N'2016-07-19T18:20:23.017' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'ccc8e274-75da-4eb8-bed0-69008ab7c41c', N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'', N'Visit', N'访问', NULL, 0, NULL, 3, NULL, 1, NULL, CAST(N'2016-07-19T17:10:55.123' AS DateTime), NULL, CAST(N'2016-07-19T18:20:29.293' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'e545061c-93fd-4ca2-ab29-b43db9db798b', N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'', N'Create', N'新增', NULL, 0, NULL, 4, NULL, 1, NULL, CAST(N'2016-07-19T17:11:03.397' AS DateTime), NULL, CAST(N'2016-07-19T18:20:35.897' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'a13ccf0d-ac8f-44ac-a522-4a54edf1f0fa', N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'', N'Delete', N'删除', NULL, 0, NULL, 5, NULL, 1, NULL, CAST(N'2016-07-19T17:11:09.173' AS DateTime), NULL, CAST(N'2016-07-19T18:20:43.070' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'392f88a8-02c2-49eb-8aed-b2acf474272a', N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'', N'Update', N'修改', NULL, 0, NULL, 6, NULL, 1, NULL, CAST(N'2016-07-19T17:11:14.407' AS DateTime), NULL, CAST(N'2016-07-19T18:20:49.043' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'24e39617-f04e-4f6f-9209-ad71e870e7c6', N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'', N'Submit', N'提交', NULL, 0, NULL, 7, NULL, 1, NULL, CAST(N'2016-07-19T17:11:19.540' AS DateTime), NULL, CAST(N'2016-07-19T18:20:54.710' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'7fc8fa11-4acf-409a-a771-aaf1eb81e814', N'9a7079bd-0660-4549-9c2d-db5e8616619f', N'', N'Exception', N'异常', NULL, 0, NULL, 8, NULL, 1, NULL, CAST(N'2016-07-19T17:11:25.400' AS DateTime), NULL, CAST(N'2016-07-19T18:21:01.443' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518371073493219', N'2020031518363999932307', N'', N'箱', N'箱', N'xiang', 0, NULL, 1, 0, 1, NULL, CAST(N'2020-03-15T18:37:10.737' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518373510988350', N'2020031518363999932307', N'', N'个', N'个', N'ge', 0, NULL, 2, 0, 1, NULL, CAST(N'2020-03-15T18:37:35.110' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518375117651872', N'2020031518363999932307', N'', N'件', N'件', N'jian', 0, NULL, 3, 0, 1, NULL, CAST(N'2020-03-15T18:37:51.177' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518383329605923', N'2020031518363999932307', N'', N'条', N'条', N'tiao', 0, NULL, 5, 0, 1, NULL, CAST(N'2020-03-15T18:38:33.297' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518514008607372', N'2020031518502068403513', N'', N'冷藏', N'冷藏', N'lc', 0, NULL, 1, 0, 1, NULL, CAST(N'2020-03-15T18:51:40.087' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518520550764804', N'2020031518502068403513', N'', N'恒温', N'恒温', N'hw', 0, NULL, 2, 0, 1, NULL, CAST(N'2020-03-15T18:52:05.507' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518523777122682', N'2020031518502068403513', N'', N'常温', N'常温', N'cw', 0, NULL, 3, 0, 1, NULL, CAST(N'2020-03-15T18:52:37.770' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519013385646199', N'2020031518590238738819', N'', N'0', N'待审核', N'', 0, NULL, 1, 0, 1, N'出库单状态', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519013385646102', N'2020031518590238738819', N'', N'1', N'待分拣', N'', 0, NULL, 1, 0, 1, N'出库单状态', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519013385646103', N'2020031518590238738819', N'', N'2', N'分拣中', N'', 0, NULL, 1, 0, 1, N'出库单状态', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519013385646104', N'2020031518590238738819', N'', N'3', N'打包中', N'', 0, NULL, 1, 0, 1, N'出库单状态', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519013385646105', N'2020031518590238738819', N'', N'4', N'待出库', N'', 0, NULL, 1, 0, 1, N'出库单状态', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519013385646106', N'2020031518590238738819', N'', N'5', N'已出库', N'', 0, NULL, 1, 0, 1, N'出库单状态', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519013385646298', N'2020031518590238738223', N'', N'0', N'销售出库', N'', 0, NULL, 1, 0, 1, N'整托盘', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'202003151901338564622', N'2020031518590238738223', N'', N'1', N'补货', N'', 0, NULL, 1, 0, 1, N'整托盘', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518383329601924', N'2020031518363999932307', N'', N'片', N'片', N'pian', 0, NULL, 5, 0, 1, NULL, CAST(N'2020-03-15T18:38:33.297' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518383329602924', N'2020031518363999932307', N'', N'盒', N'盒', N'he', 0, NULL, 5, 0, 1, NULL, CAST(N'2020-03-15T18:38:33.297' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519000746527561', N'2020031518590238738718', N'', N'计吨', N'计吨', N'jd', 0, NULL, 1, 0, 1, NULL, CAST(N'2020-03-15T19:00:07.467' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519010257773237', N'2020031518590238738718', N'', N'轻抛按箱', N'按箱', N'qpax', 0, NULL, 2, 0, 1, N'', CAST(N'2020-03-15T19:01:02.577' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031519013385646198', N'2020031518590238738718', N'', N'整托', N'整托', N'ztp', 0, NULL, 1, 0, 1, N'整托盘', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'202003151901338564623', N'2020031518590238738223', N'', N'2', N'其他', N'', 0, NULL, 1, 0, 1, N'整托盘', CAST(N'2020-03-15T19:01:33.857' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-05-14T17:25:41.100' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518371173493219', N'2020031518363999932307', N'', N'PC', N'PC', N'xiang', 0, NULL, 1, 0, 1, NULL, CAST(N'2020-03-15T18:37:10.737' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101518190417886360', N'2020031518502068403513', N'', N'11', N'11', NULL, 1, NULL, 3, 0, 1, NULL, CAST(N'2020-10-15T18:19:04.180' AS DateTime), N'2020100517554098226223', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101015533503275863', N'15023A4E-4856-44EB-BE71-36A106E2AA59', N'', N'回族', N'回族', NULL, 1, NULL, 99, 0, 1, NULL, CAST(N'2020-10-10T15:53:35.033' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [ParentId], [ItemCode], [ItemName], [SimpleSpelling], [IsDefault], [Layers], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020031518381846423927', N'2020031518363999932307', N'', N'瓶', N'瓶', N'ping', 0, NULL, 4, 0, 1, NULL, CAST(N'2020-03-15T18:38:18.463' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211063645228270', CAST(N'2021-01-12T11:06:36.453' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=2021010319110318113791', 0, 1, CAST(N'2021-01-12T11:06:36.453' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211063686927611', CAST(N'2021-01-12T11:06:36.870' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''2021010319110318113791'' 耗时 :50.6 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:06:36.870' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211063966157083', CAST(N'2021-01-12T11:06:39.660' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=2021010319110318113791', 0, 1, CAST(N'2021-01-12T11:06:39.660' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211063972037068', CAST(N'2021-01-12T11:06:39.720' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''2021010319110318113791'' 耗时 :22.6 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:06:39.720' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211064573115130', CAST(N'2021-01-12T11:06:45.730' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Login/Logout', 0, 1, CAST(N'2021-01-12T11:06:45.730' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211064662509904', CAST(N'2021-01-12T11:06:46.627' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select * from Sys_UserLogOn  where UserId=''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'' 耗时 :46.4 ms,状态 :成功【sql2】SET NOCOUNT ON;
UPDATE [Sys_UserLogOn] SET [AllowEndTime] = 2100-12-31T23:59:59, [AllowStartTime] = 2017-01-01T00:00:00, [AnswerQuestion] = '''', [ChangePasswordDate] = 2020-10-12T09:26:34, [CheckIPAddress] = 0, [FirstVisitTime] = 2020-10-06T15:05:27, [Language] = '''', [LastVisitTime] = 2021-01-05T22:06:11, [LockEndDate] = 2020-10-06T00:00:00, [LockStartDate] = 2017-01-01T00:00:00, [LogOnCount] = 159, [MultiUserLogin] = 0, [PreviousVisitTime] = 2021-01-05T22:06:11, [Question] = '''', [Theme] = '''', [UserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [UserOnLine] = 0, [UserPassword] = ''5039b1d6a774b864af4a013d9c905c06'', [UserSecretkey] = ''9eeb98044bbedd1a''
WHERE [Id] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'';
SELECT @@ROWCOUNT;

 耗时 :88.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:06:46.627' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211065259836477', CAST(N'2021-01-12T11:06:52.600' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Captcha', 0, 1, CAST(N'2021-01-12T11:06:52.600' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211065339707397', CAST(N'2021-01-12T11:06:53.397' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Captcha', 0, 1, CAST(N'2021-01-12T11:06:53.397' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211065368413649', CAST(N'2021-01-12T11:06:53.683' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT * FROM Sys_APP t WHERE t.AppId = ''system'' and AppSecret=''87135AB0160F706D8B47F06BDABA6FC6'' and EnabledMark=1 耗时 :50.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:06:53.683' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211065485435009', CAST(N'2021-01-12T11:06:54.853' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT * FROM Sys_APP t WHERE t.AppId = ''system'' and AppSecret=''87135AB0160F706D8B47F06BDABA6FC6'' and EnabledMark=1 耗时 :23.8 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:06:54.853' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211065550042085', CAST(N'2021-01-12T11:06:55.500' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Security/SysSetting/GetInfo', 0, 1, CAST(N'2021-01-12T11:06:55.500' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211065728011426', CAST(N'2021-01-12T11:06:57.280' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Security/SysSetting/GetInfo', 0, 1, CAST(N'2021-01-12T11:06:57.280' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211070660483402', CAST(N'2021-01-12T11:07:06.603' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Login/GetCheckUser?username=admin&password=admin888&vcode=afc8&vkey=202101121106529540&appId=system&systemCode=openauth', 0, 1, CAST(N'2021-01-12T11:07:06.603' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211070665056004', CAST(N'2021-01-12T11:07:09.867' AS DateTime), N'admin', N'超级管理员', NULL, N'Login', N'0.0.0.1', N'未知', NULL, N'登录', 1, N'登录成功', 0, 1, CAST(N'2021-01-12T11:07:09.867' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211070993564990', CAST(N'2021-01-12T11:07:09.937' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select count(*) from Sys_FilterIP  where  replace(StartIP, ''.'', '''')>=1 and replace(EndIP, ''.'', '''')<=1 and FilterType=0 and EnabledMark=1 耗时 :93.5 ms,状态 :成功【sql2】SELECT * FROM Sys_APP t WHERE t.AppId = ''system'' and EnabledMark=1 耗时 :29.1 ms,状态 :成功【sql3】SELECT * FROM Sys_SystemType t WHERE t.EnCode = ''openauth'' 耗时 :34.7 ms,状态 :成功【sql4】SELECT * FROM Sys_User t WHERE (t.Account = ''admin'' Or t.Email = ''admin'' Or t.MobilePhone = ''admin'') 耗时 :99 ms,状态 :成功【sql5】SELECT * FROM Sys_UserLogOn t WHERE t.UserId = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'' 耗时 :21.5 ms,状态 :成功【sql6】select * from Sys_UserLogOn  where UserId=''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'' 耗时 :22.2 ms,状态 :成功【sql7】SET NOCOUNT ON;
UPDATE [Sys_UserLogOn] SET [AllowEndTime] = 2100-12-31T23:59:59, [AllowStartTime] = 2017-01-01T00:00:00, [AnswerQuestion] = '''', [ChangePasswordDate] = 2020-10-12T09:26:34, [CheckIPAddress] = 0, [FirstVisitTime] = 2020-10-06T15:05:27, [Language] = '''', [LastVisitTime] = 2021-01-12T11:07:07, [LockEndDate] = 2020-10-06T00:00:00, [LockStartDate] = 2017-01-01T00:00:00, [LogOnCount] = 160, [MultiUserLogin] = 0, [PreviousVisitTime] = 2021-01-12T11:07:07, [Question] = '''', [Theme] = '''', [UserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [UserOnLine] = 1, [UserPassword] = ''5039b1d6a774b864af4a013d9c905c06'', [UserSecretkey] = ''9eeb98044bbedd1a''
WHERE [Id] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'';
SELECT @@ROWCOUNT;

 耗时 :24.9 ms,状态 :成功【sql8】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :43.9 ms,状态 :成功【sql9】SELECT 1 耗时 :23.4 ms,状态 :成功【sql10】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :25.2 ms,状态 :成功【sql11】SELECT 1 耗时 :20.8 ms,状态 :成功【sql12】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :31.2 ms,状态 :成功【sql13】SELECT 1 耗时 :30.9 ms,状态 :成功【sql14】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :32.9 ms,状态 :成功【sql15】SELECT 1 耗时 :25.9 ms,状态 :成功【sql16】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :30.6 ms,状态 :成功【sql17】SELECT 1 耗时 :29.3 ms,状态 :成功【sql18】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :32.2 ms,状态 :成功【sql19】SELECT 1 耗时 :28.2 ms,状态 :成功【sql20】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :33.1 ms,状态 :成功【sql21】SELECT 1 耗时 :28 ms,状态 :成功【sql22】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :31 ms,状态 :成功【sql23】SELECT 1 耗时 :25 ms,状态 :成功【sql24】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :29.8 ms,状态 :成功【sql25】SELECT 1 耗时 :28.6 ms,状态 :成功【sql26】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :32.1 ms,状态 :成功【sql27】SELECT 1 耗时 :28.8 ms,状态 :成功【sql28】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :33.7 ms,状态 :成功【sql29】SELECT 1 耗时 :28.8 ms,状态 :成功【sql30】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :27.9 ms,状态 :成功【sql31】SELECT 1 耗时 :53.1 ms,状态 :成功【sql32】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.5 ms,状态 :成功【sql33】SELECT 1 耗时 :20.6 ms,状态 :成功【sql34】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :25.2 ms,状态 :成功【sql35】SELECT 1 耗时 :22.2 ms,状态 :成功【sql36】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.6 ms,状态 :成功【sql37】SELECT 1 耗时 :21.1 ms,状态 :成功【sql38】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.9 ms,状态 :成功【sql39】SELECT 1 耗时 :19.4 ms,状态 :成功【sql40】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.4 ms,状态 :成功【sql41】SELECT 1 耗时 :20.7 ms,状态 :成功【sql42】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :24 ms,状态 :成功【sql43】SELECT 1 耗时 :21.6 ms,状态 :成功【sql44】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :26.1 ms,状态 :成功【sql45】SELECT 1 耗时 :22.7 ms,状态 :成功【sql46】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.1 ms,状态 :成功【sql47】SELECT 1 耗时 :23 ms,状态 :成功【sql48】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :27 ms,状态 :成功【sql49】SELECT 1 耗时 :20.8 ms,状态 :成功【sql50】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :25.2 ms,状态 :成功【sql51】SELECT 1 耗时 :20.6 ms,状态 :成功【sql52】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.3 ms,状态 :成功【sql53】SELECT 1 耗时 :34.2 ms,状态 :成功【sql54】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :30.8 ms,状态 :成功【sql55】SELECT 1 耗时 :26.3 ms,状态 :成功【sql56】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :33.4 ms,状态 :成功【sql57】SELECT 1 耗时 :26.8 ms,状态 :成功【sql58】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.4 ms,状态 :成功【sql59】SELECT 1 耗时 :25.9 ms,状态 :成功【sql60】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :25.1 ms,状态 :成功【sql61】SELECT 1 耗时 :23.1 ms,状态 :成功【sql62】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :22.1 ms,状态 :成功【sql63】select  *  from Sys_SystemType  where  DeleteMark=0 and EnabledMark=1  耗时 :35.7 ms,状态 :成功【sql64】SELECT DISTINCT b.* FROM sys_menu as b INNER JOIN Sys_RoleAuthorize as a On b.Id = a.ItemId   Where SystemTypeId=''201806141508359155''  耗时 :89.7 ms,状态 :成功【sql65】SELECT * FROM Sys_SystemType t WHERE t.EnCode = ''openauth'' 耗时 :22.5 ms,状态 :成功【sql66】SELECT DISTINCT b.* FROM sys_menu as b INNER JOIN Sys_RoleAuthorize as a On b.Id = a.ItemId  WHERE ObjectId IN (''F0A2B36F-35A7-4660-B46C-D4AB796591EB'')and menutype in(''M'', ''C'') AND SystemTypeId=''201806141508359155''  耗时 :73.9 ms,状态 :成功【sql67】select AuthorizeData from Sys_RoleData  where  RoleId in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') and DType=''dept'' 耗时 :46.5 ms,状态 :成功【sql68】insert into Sys_Log ([Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''2021-01-12T11:07:09'', ''admin'', ''超级管理员'', '''', ''Login'', ''0.0.0.1'', ''未知'', '''', ''登录'', 1, ''登录成功'', 0, 1, ''2021-01-12T11:07:09'', '''', '''', '''', '''', '''', ''2021011211070665056004''); select @@ROWCOUNT  num 耗时 :25 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:07:09.937' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211071090828611', CAST(N'2021-01-12T11:07:10.907' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=Menu', 0, 1, CAST(N'2021-01-12T11:07:10.907' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211071091197224', CAST(N'2021-01-12T11:07:10.913' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=null', 0, 1, CAST(N'2021-01-12T11:07:10.913' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211071282765568', CAST(N'2021-01-12T11:07:12.827' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=', 0, 1, CAST(N'2021-01-12T11:07:12.827' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211071299568398', CAST(N'2021-01-12T11:07:12.997' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:07:12.997' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211084280592423', CAST(N'2021-01-12T11:08:42.807' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:08:42.807' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211084287099690', CAST(N'2021-01-12T11:08:42.870' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :23.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:08:42.870' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211090119018030', CAST(N'2021-01-12T11:09:01.190' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:09:01.190' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211090128848839', CAST(N'2021-01-12T11:09:01.290' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :53.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:09:01.290' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211093381342793', CAST(N'2021-01-12T11:09:33.813' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/Insert', 0, 1, CAST(N'2021-01-12T11:09:33.813' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211093464182350', CAST(N'2021-01-12T11:09:34.643' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211084197203605'' 耗时 :32.6 ms,状态 :成功【sql2】INSERT INTO Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211084197203605'', 2, ''Articlecategory'', ''文章分类'', ''icon-xuhao'', ''/articlecategory/index'', '''', ''M'', ''articlecategory/index'', 0, 1, 0, 0, 0, null, null, 99, '''', 0, 1, ''2021-01-12T11:09:33'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211093383813777''); select @@ROWCOUNT  num 耗时 :28.2 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:09:34.643' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211093553525795', CAST(N'2021-01-12T11:09:35.537' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:09:35.537' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211093564442694', CAST(N'2021-01-12T11:09:35.643' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :52.9 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:09:35.643' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211095443552816', CAST(N'2021-01-12T11:09:54.437' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:09:54.437' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211095453047311', CAST(N'2021-01-12T11:09:54.530' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :51 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:09:54.530' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100573413200', CAST(N'2021-01-12T11:10:05.733' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/Insert', 0, 1, CAST(N'2021-01-12T11:10:05.733' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100617508199', CAST(N'2021-01-12T11:10:06.177' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211093383813777'' 耗时 :24.6 ms,状态 :成功【sql2】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211093383813777'', 3, ''Articlecategory/List'', ''列表'', '''', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 99, '''', 0, 1, ''2021-01-12T11:10:05'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211100576523295''); select @@ROWCOUNT  num 耗时 :28 ms,状态 :成功【sql3】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211093383813777'' 耗时 :28.2 ms,状态 :成功【sql4】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211093383813777'', 3, ''Articlecategory/Add'', ''新增'', ''el-icon-plus'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 1, '''', 0, 1, ''2021-01-12T11:10:05'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211100583237730''); select @@ROWCOUNT  num 耗时 :24.8 ms,状态 :成功【sql5】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211093383813777'' 耗时 :23.9 ms,状态 :成功【sql6】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211093383813777'', 3, ''Articlecategory/Edit'', ''修改'', ''el-icon-edit'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 2, '''', 0, 1, ''2021-01-12T11:10:05'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211100590361637''); select @@ROWCOUNT  num 耗时 :26.7 ms,状态 :成功【sql7】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211093383813777'' 耗时 :21.6 ms,状态 :成功【sql8】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211093383813777'', 3, ''Articlecategory/Enable'', ''禁用'', ''el-icon-video-pause'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 3, '''', 0, 1, ''2021-01-12T11:10:05'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211100595928007''); select @@ROWCOUNT  num 耗时 :25.5 ms,状态 :成功【sql9】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211093383813777'' 耗时 :21.5 ms,状态 :成功【sql10】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211093383813777'', 3, ''Articlecategory/Enable'', ''启用'', ''el-icon-video-play'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 4, '''', 0, 1, ''2021-01-12T11:10:06'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211100601001133''); select @@ROWCOUNT  num 耗时 :25.3 ms,状态 :成功【sql11】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211093383813777'' 耗时 :22.2 ms,状态 :成功【sql12】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211093383813777'', 3, ''Articlecategory/DeleteSoft'', ''软删除'', ''el-icon-delete'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 5, '''', 0, 1, ''2021-01-12T11:10:06'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211100606072467''); select @@ROWCOUNT  num 耗时 :27.3 ms,状态 :成功【sql13】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211093383813777'' 耗时 :22 ms,状态 :成功【sql14】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211093383813777'', 3, ''Articlecategory/Delete'', ''删除'', ''el-icon-delete'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 6, '''', 0, 1, ''2021-01-12T11:10:06'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211100611473440''); select @@ROWCOUNT  num 耗时 :32.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:10:06.177' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100716849522', CAST(N'2021-01-12T11:10:07.170' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:10:07.170' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100728623718', CAST(N'2021-01-12T11:10:07.287' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:10:07.287' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100737035797', CAST(N'2021-01-12T11:10:07.370' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :27.3 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:10:07.370' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211105033096563', CAST(N'2021-01-12T11:10:50.330' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:10:50.330' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211105043286030', CAST(N'2021-01-12T11:10:50.433' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :51.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:10:50.433' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211111842108428', CAST(N'2021-01-12T11:11:18.420' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/Insert', 0, 1, CAST(N'2021-01-12T11:11:18.420' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211111852004539', CAST(N'2021-01-12T11:11:18.520' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211084197203605'' 耗时 :25.1 ms,状态 :成功【sql2】INSERT INTO Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211084197203605'', 2, ''Articlenews'', ''文章列表'', ''icon-emaxcitygerenxinxitubiaoji03'', ''/articlenews/index'', '''', ''M'', ''articlenews/index'', 0, 1, 0, 0, 0, null, null, 99, '''', 0, 1, ''2021-01-12T11:11:18'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211111845261274''); select @@ROWCOUNT  num 耗时 :37 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:18.520' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211111913796995', CAST(N'2021-01-12T11:11:19.137' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:11:19.137' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211111923673615', CAST(N'2021-01-12T11:11:19.237' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:11:19.237' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113372599565', CAST(N'2021-01-12T11:11:33.727' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:11:33.727' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113378752558', CAST(N'2021-01-12T11:11:33.787' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :22.9 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:33.787' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113752194536', CAST(N'2021-01-12T11:11:37.523' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Security/Menu/GetById?id=2021011211113260438763', 0, 1, CAST(N'2021-01-12T11:11:37.523' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113758184043', CAST(N'2021-01-12T11:11:37.583' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211113260438763'' 耗时 :21.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:37.583' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113815694134', CAST(N'2021-01-12T11:11:38.157' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:11:38.157' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113824797571', CAST(N'2021-01-12T11:11:38.247' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :49.2 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:38.247' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114040219620', CAST(N'2021-01-12T11:11:40.403' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/Update?id=2021011211113260438763', 0, 1, CAST(N'2021-01-12T11:11:40.403' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114070384722', CAST(N'2021-01-12T11:11:40.703' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211113260438763'' 耗时 :22.6 ms,状态 :成功【sql2】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211111845261274'' 耗时 :24.6 ms,状态 :成功【sql3】SET NOCOUNT ON;
UPDATE [Sys_Menu] SET [AllowDelete] = '''', [AllowEdit] = '''', [Component] = '''', [CreatorTime] = 2021-01-12T11:11:32, [CreatorUserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [DeleteMark] = 0, [DeleteTime] = null, [DeleteUserId] = '''', [Description] = '''', [EnCode] = ''Articlenews/List'', [EnabledMark] = 1, [FullName] = ''列表'', [Icon] = '''', [IsCache] = 0, [IsExpand] = 0, [IsFrame] = 0, [IsPublic] = 0, [IsShow] = 0, [LastModifyTime] = 2021-01-12T11:11:40, [LastModifyUserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [Layers] = 3, [MenuType] = ''F'', [ParentId] = ''2021011211111845261274'', [SortCode] = 99, [SystemTypeId] = ''201806141508359155'', [Target] = '''', [UrlAddress] = ''''
WHERE [Id] = ''2021011211113260438763'';
SELECT @@ROWCOUNT;

 耗时 :27.7 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:40.703' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114130529048', CAST(N'2021-01-12T11:11:41.307' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:11:41.307' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114142257265', CAST(N'2021-01-12T11:11:41.423' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:11:41.423' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114148542295', CAST(N'2021-01-12T11:11:41.487' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :21.6 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:41.487' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114448308624', CAST(N'2021-01-12T11:11:44.483' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Security/Menu/GetById?id=2021011211100576523295', 0, 1, CAST(N'2021-01-12T11:11:44.483' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114454161597', CAST(N'2021-01-12T11:11:44.540' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211100576523295'' 耗时 :23.2 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:44.540' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114510131430', CAST(N'2021-01-12T11:11:45.100' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:11:45.100' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114520095461', CAST(N'2021-01-12T11:11:45.200' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :51.5 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:45.200' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114723743982', CAST(N'2021-01-12T11:11:47.237' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/Update?id=2021011211100576523295', 0, 1, CAST(N'2021-01-12T11:11:47.237' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114740301200', CAST(N'2021-01-12T11:11:47.403' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211100576523295'' 耗时 :21.9 ms,状态 :成功【sql2】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211093383813777'' 耗时 :23.2 ms,状态 :成功【sql3】SET NOCOUNT ON;
UPDATE [Sys_Menu] SET [AllowDelete] = '''', [AllowEdit] = '''', [Component] = '''', [CreatorTime] = 2021-01-12T11:10:05, [CreatorUserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [DeleteMark] = 0, [DeleteTime] = null, [DeleteUserId] = '''', [Description] = '''', [EnCode] = ''Articlecategory/List'', [EnabledMark] = 1, [FullName] = ''列表'', [Icon] = '''', [IsCache] = 0, [IsExpand] = 0, [IsFrame] = 0, [IsPublic] = 0, [IsShow] = 0, [LastModifyTime] = 2021-01-12T11:11:47, [LastModifyUserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [Layers] = 3, [MenuType] = ''F'', [ParentId] = ''2021011211093383813777'', [SortCode] = 99, [SystemTypeId] = ''201806141508359155'', [Target] = '''', [UrlAddress] = ''''
WHERE [Id] = ''2021011211100576523295'';
SELECT @@ROWCOUNT;

 耗时 :22.3 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:47.403' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114801352004', CAST(N'2021-01-12T11:11:48.013' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:11:48.013' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114811401582', CAST(N'2021-01-12T11:11:48.113' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :50.8 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:48.113' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114814749778', CAST(N'2021-01-12T11:11:48.147' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:11:48.147' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114820688055', CAST(N'2021-01-12T11:11:48.207' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :23 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:48.207' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211120629702560', CAST(N'2021-01-12T11:12:06.297' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=User', 0, 1, CAST(N'2021-01-12T11:12:06.297' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211120716367873', CAST(N'2021-01-12T11:12:07.163' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Organize/GetAllOrganizeTreeTable', 0, 1, CAST(N'2021-01-12T11:12:07.163' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211120732428269', CAST(N'2021-01-12T11:12:07.323' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Organize  耗时 :38.6 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:07.323' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211120743548157', CAST(N'2021-01-12T11:12:07.437' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Role/GetAllEnable', 0, 1, CAST(N'2021-01-12T11:12:07.437' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211071306743297', CAST(N'2021-01-12T11:07:13.067' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :28.2 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:07:13.067' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211071312682655', CAST(N'2021-01-12T11:07:13.127' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  where 1=1 耗时 :24.4 ms,状态 :成功【sql2】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :66.6 ms,状态 :成功【sql3】select  *   from Sys_Menu  where SystemTypeId=''201806141511351940'' 耗时 :22 ms,状态 :成功【sql4】select  *   from Sys_Menu  where SystemTypeId=''201904031316131800'' 耗时 :21.3 ms,状态 :成功【sql5】select  *   from Sys_Menu  where SystemTypeId=''201907011617511504'' 耗时 :24.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:07:13.127' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211071576818535', CAST(N'2021-01-12T11:07:15.767' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=', 0, 1, CAST(N'2021-01-12T11:07:15.767' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211071597011614', CAST(N'2021-01-12T11:07:15.970' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  where 1=1 耗时 :21.5 ms,状态 :成功【sql2】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :47.5 ms,状态 :成功【sql3】select  *   from Sys_Menu  where SystemTypeId=''201806141511351940'' 耗时 :24.5 ms,状态 :成功【sql4】select  *   from Sys_Menu  where SystemTypeId=''201904031316131800'' 耗时 :21.6 ms,状态 :成功【sql5】select  *   from Sys_Menu  where SystemTypeId=''201907011617511504'' 耗时 :25.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:07:15.970' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211072065906437', CAST(N'2021-01-12T11:07:20.660' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141511351940', 0, 1, CAST(N'2021-01-12T11:07:20.660' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211072072127298', CAST(N'2021-01-12T11:07:20.720' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141511351940'' 耗时 :22.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:07:20.720' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211072377746693', CAST(N'2021-01-12T11:07:23.777' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:07:23.777' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211072389267741', CAST(N'2021-01-12T11:07:23.893' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :63 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:07:23.893' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211081833242963', CAST(N'2021-01-12T11:08:18.333' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:08:18.333' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211081845097113', CAST(N'2021-01-12T11:08:18.450' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :62.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:08:18.450' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211084193303773', CAST(N'2021-01-12T11:08:41.933' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/Insert', 0, 1, CAST(N'2021-01-12T11:08:41.933' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211084205847384', CAST(N'2021-01-12T11:08:42.060' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】INSERT INTO Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', '''', 1, ''Cms'', ''文章管理'', ''icon-emaxcitygerenxinxitubiaoji03'', ''/cms'', '''', ''C'', '''', 0, 1, 0, 0, 0, null, null, 99, '''', 0, 1, ''2021-01-12T11:08:41'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211084197203605''); select @@ROWCOUNT  num 耗时 :33.2 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:08:42.060' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211084269502434', CAST(N'2021-01-12T11:08:42.697' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:08:42.697' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211084279371106', CAST(N'2021-01-12T11:08:42.793' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :58.2 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:08:42.793' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211093567616903', CAST(N'2021-01-12T11:09:35.677' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:09:35.677' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211093574656197', CAST(N'2021-01-12T11:09:35.747' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :26.8 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:09:35.747' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100729857502', CAST(N'2021-01-12T11:10:07.300' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :66.2 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:10:07.300' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211111924452914', CAST(N'2021-01-12T11:11:19.243' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :50.6 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:19.243' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211111932382602', CAST(N'2021-01-12T11:11:19.323' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :22.7 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:19.323' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211112474803458', CAST(N'2021-01-12T11:11:24.747' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:11:24.747' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211112485004997', CAST(N'2021-01-12T11:11:24.850' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :53.5 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:24.850' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113256813097', CAST(N'2021-01-12T11:11:32.567' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/Insert', 0, 1, CAST(N'2021-01-12T11:11:32.567' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113299289878', CAST(N'2021-01-12T11:11:32.993' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211111845261274'' 耗时 :23.9 ms,状态 :成功【sql2】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211111845261274'', 3, ''Articlenews/List'', ''列表'', '''', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 99, '''', 0, 1, ''2021-01-12T11:11:32'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211113260438763''); select @@ROWCOUNT  num 耗时 :23.8 ms,状态 :成功【sql3】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211111845261274'' 耗时 :23.1 ms,状态 :成功【sql4】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211111845261274'', 3, ''Articlenews/Add'', ''新增'', ''el-icon-plus'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 1, '''', 0, 1, ''2021-01-12T11:11:32'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211113265594642''); select @@ROWCOUNT  num 耗时 :28 ms,状态 :成功【sql5】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211111845261274'' 耗时 :24.4 ms,状态 :成功【sql6】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211111845261274'', 3, ''Articlenews/Edit'', ''修改'', ''el-icon-edit'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 2, '''', 0, 1, ''2021-01-12T11:11:32'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211113271113293''); select @@ROWCOUNT  num 耗时 :29.4 ms,状态 :成功【sql7】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211111845261274'' 耗时 :21.5 ms,状态 :成功【sql8】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211111845261274'', 3, ''Articlenews/Enable'', ''禁用'', ''el-icon-video-pause'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 3, '''', 0, 1, ''2021-01-12T11:11:32'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211113277633034''); select @@ROWCOUNT  num 耗时 :25.9 ms,状态 :成功【sql9】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211111845261274'' 耗时 :21.3 ms,状态 :成功【sql10】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211111845261274'', 3, ''Articlenews/Enable'', ''启用'', ''el-icon-video-play'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 4, '''', 0, 1, ''2021-01-12T11:11:32'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211113282976349''); select @@ROWCOUNT  num 耗时 :23.5 ms,状态 :成功【sql11】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211111845261274'' 耗时 :23.1 ms,状态 :成功【sql12】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211111845261274'', 3, ''Articlenews/DeleteSoft'', ''软删除'', ''el-icon-delete'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 5, '''', 0, 1, ''2021-01-12T11:11:32'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211113287838584''); select @@ROWCOUNT  num 耗时 :26.9 ms,状态 :成功【sql13】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211111845261274'' 耗时 :25.7 ms,状态 :成功【sql14】insert into Sys_Menu ([SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Target], [MenuType], [Component], [IsExpand], [IsShow], [IsFrame], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''201806141508359155'', ''2021011211111845261274'', 3, ''Articlenews/Delete'', ''删除'', ''el-icon-delete'', '''', '''', ''F'', '''', 0, 1, 0, 0, 0, null, null, 6, '''', 0, 1, ''2021-01-12T11:11:32'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', '''', '''', '''', '''', ''2021011211113293224086''); select @@ROWCOUNT  num 耗时 :29.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:32.993' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113364675275', CAST(N'2021-01-12T11:11:33.647' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:11:33.647' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113376138230', CAST(N'2021-01-12T11:11:33.760' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :57.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:33.760' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211114142974832', CAST(N'2021-01-12T11:11:41.430' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :62.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:11:41.430' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211120755121067', CAST(N'2021-01-12T11:12:07.550' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Role  where  DeleteMark=0 and EnabledMark=1 耗时 :37.9 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:07.550' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211120839804853', CAST(N'2021-01-12T11:12:08.397' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/User/FindWithPagerSearchAsync', 0, 1, CAST(N'2021-01-12T11:12:08.397' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211120906131967', CAST(N'2021-01-12T11:12:09.060' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select count(*) as Total from Sys_User Where 1=1 ;With Paging AS
                ( SELECT ROW_NUMBER() OVER ( order by CreatorTime DESC) as RowNumber,  *  FROM Sys_User Where 1=1)
                SELECT * FROM Paging WHERE RowNumber Between 1 and 20 耗时 :49.7 ms,状态 :成功【sql2】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :37.2 ms,状态 :成功【sql3】select  *  from Sys_Role  where Id in(''2019091721053342871332'') 耗时 :23.3 ms,状态 :成功【sql4】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619373694586929'' 耗时 :22.6 ms,状态 :成功【sql5】select  *  from Sys_Role  where Id in(''2019091721053342871332'') 耗时 :20.4 ms,状态 :成功【sql6】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :25.3 ms,状态 :成功【sql7】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :20.8 ms,状态 :成功【sql8】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020091317280067305041'' 耗时 :22 ms,状态 :成功【sql9】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :22.7 ms,状态 :成功【sql10】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :21.4 ms,状态 :成功【sql11】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020091317280067305041'' 耗时 :22.6 ms,状态 :成功【sql12】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :23.6 ms,状态 :成功【sql13】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :21.3 ms,状态 :成功【sql14】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619392209546893'' 耗时 :23.4 ms,状态 :成功【sql15】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :23 ms,状态 :成功【sql16】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :24.5 ms,状态 :成功【sql17】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020091317274420379133'' 耗时 :22.2 ms,状态 :成功【sql18】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :23.8 ms,状态 :成功【sql19】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :21.3 ms,状态 :成功【sql20】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619423736813802'' 耗时 :21.3 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:09.060' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211122845361291', CAST(N'2021-01-12T11:12:28.453' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/User/DeleteBatchAsync', 0, 1, CAST(N'2021-01-12T11:12:28.453' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211122861827386', CAST(N'2021-01-12T11:12:28.617' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】delete from Sys_User where id in (''2020123011083102191165'', ''2020122916175658252204'', ''2020051415044714091504'') 耗时 :37.5 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:28.617' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211123010319489', CAST(N'2021-01-12T11:12:30.103' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/User/FindWithPagerSearchAsync', 0, 1, CAST(N'2021-01-12T11:12:30.103' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211123081703643', CAST(N'2021-01-12T11:12:30.817' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select count(*) as Total from Sys_User Where 1=1 ;With Paging AS
                ( SELECT ROW_NUMBER() OVER ( order by CreatorTime DESC) as RowNumber,  *  FROM Sys_User Where 1=1)
                SELECT * FROM Paging WHERE RowNumber Between 1 and 20 耗时 :30.9 ms,状态 :成功【sql2】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :27.4 ms,状态 :成功【sql3】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :24.3 ms,状态 :成功【sql4】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020091317280067305041'' 耗时 :26 ms,状态 :成功【sql5】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :24.8 ms,状态 :成功【sql6】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :21 ms,状态 :成功【sql7】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619392209546893'' 耗时 :38.3 ms,状态 :成功【sql8】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :38.6 ms,状态 :成功【sql9】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :28.5 ms,状态 :成功【sql10】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020091317274420379133'' 耗时 :33.5 ms,状态 :成功【sql11】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :33.6 ms,状态 :成功【sql12】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :266.9 ms,状态 :成功【sql13】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619423736813802'' 耗时 :27.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:30.817' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211123966424965', CAST(N'2021-01-12T11:12:39.663' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=Role', 0, 1, CAST(N'2021-01-12T11:12:39.663' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124020249509', CAST(N'2021-01-12T11:12:40.203' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Organize/GetAllOrganizeTreeTable', 0, 1, CAST(N'2021-01-12T11:12:40.203' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124027394666', CAST(N'2021-01-12T11:12:40.273' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Organize  耗时 :20.8 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:40.273' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124043043004', CAST(N'2021-01-12T11:12:40.430' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Security/Items/GetListByItemCode?itemCode=RoleType', 0, 1, CAST(N'2021-01-12T11:12:40.430' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124048929976', CAST(N'2021-01-12T11:12:40.490' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Role/FindWithPagerAsync', 0, 1, CAST(N'2021-01-12T11:12:40.490' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124076604652', CAST(N'2021-01-12T11:12:40.767' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(2) [s].[Id], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[IsTree], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ParentId], [s].[SortCode]
FROM [Sys_Items] AS [s]
WHERE [s].[EnCode] = ''RoleType'' 耗时 :49.7 ms,状态 :成功【sql2】select  *  from Sys_ItemsDetail  where  DeleteMark=0 and EnabledMark=1  and ItemId=''D94E4DC1-C2FD-4D19-9D5D-3886D39900CE'' 耗时 :52 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:40.767' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124080803524', CAST(N'2021-01-12T11:12:40.807' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select count(*) as Total from Sys_Role Where 1=1 and Category=1 ;With Paging AS
                ( SELECT ROW_NUMBER() OVER ( order by SortCode DESC) as RowNumber,  *  FROM Sys_Role Where 1=1 and Category=1)
                SELECT * FROM Paging WHERE RowNumber Between 1 and 20 耗时 :47.8 ms,状态 :成功【sql2】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :22.8 ms,状态 :成功【sql3】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :23.4 ms,状态 :成功【sql4】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :24.6 ms,状态 :成功【sql5】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020091317280067305041'' 耗时 :22.4 ms,状态 :成功【sql6】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :23 ms,状态 :成功【sql7】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :24.8 ms,状态 :成功【sql8】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619434422287774'' 耗时 :23.4 ms,状态 :成功【sql9】SELECT TOP(1) [s].[Id], [s].[Address], [s].[AllowDelete], [s].[AllowEdit], [s].[AreaId], [s].[CategoryId], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[Email], [s].[EnCode], [s].[EnabledMark], [s].[Fax], [s].[FullName], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[ManagerId], [s].[MobilePhone], [s].[ParentId], [s].[ShortName], [s].[SortCode], [s].[TelePhone], [s].[WeChat]
FROM [Sys_Organize] AS [s]
WHERE [s].[Id] = ''2020101619392209546893'' 耗时 :22.3 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:40.807' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124524527353', CAST(N'2021-01-12T11:12:45.247' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleData/GetAllRoleDataByRoleId?roleId=F0A2B36F-35A7-4660-B46C-D4AB796591EB', 0, 1, CAST(N'2021-01-12T11:12:45.247' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124531867974', CAST(N'2021-01-12T11:12:45.320' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_RoleData  where RoleId=''F0A2B36F-35A7-4660-B46C-D4AB796591EB'' 耗时 :30.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:45.320' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124537542208', CAST(N'2021-01-12T11:12:45.377' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Organize/GetAllOrganizeTreeTable', 0, 1, CAST(N'2021-01-12T11:12:45.377' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124546978501', CAST(N'2021-01-12T11:12:45.470' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Organize  耗时 :36.5 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:45.470' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124551516351', CAST(N'2021-01-12T11:12:45.517' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetAllEnable', 0, 1, CAST(N'2021-01-12T11:12:45.517' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124556948073', CAST(N'2021-01-12T11:12:45.570' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  where  DeleteMark=0 and EnabledMark=1 耗时 :22.3 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:45.570' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124591739835', CAST(N'2021-01-12T11:12:45.917' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/GetRoleAuthorizeFunction?roleId=F0A2B36F-35A7-4660-B46C-D4AB796591EB&itemType=0', 0, 1, CAST(N'2021-01-12T11:12:45.917' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124593455384', CAST(N'2021-01-12T11:12:45.933' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/GetAllFunctionTree', 0, 1, CAST(N'2021-01-12T11:12:45.933' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124599613874', CAST(N'2021-01-12T11:12:45.997' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *  from Sys_RoleAuthorize  where ItemType=0 and ObjectId in (''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') and ObjectType=1 耗时 :43.6 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:45.997' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124603661584', CAST(N'2021-01-12T11:12:46.037' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/GetRoleAuthorizeFunction?roleId=F0A2B36F-35A7-4660-B46C-D4AB796591EB&itemType=1', 0, 1, CAST(N'2021-01-12T11:12:46.037' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124614095902', CAST(N'2021-01-12T11:12:46.140' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *  from Sys_RoleAuthorize  where ItemType=1 and ObjectId in (''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') and ObjectType=1 耗时 :53.6 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:46.140' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211124617875091', CAST(N'2021-01-12T11:12:46.180' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  where 1=1 耗时 :25.4 ms,状态 :成功【sql2】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :85 ms,状态 :成功【sql3】select  *   from Sys_Menu  where SystemTypeId=''201806141511351940'' 耗时 :23.9 ms,状态 :成功【sql4】select  *   from Sys_Menu  where SystemTypeId=''201904031316131800'' 耗时 :20.9 ms,状态 :成功【sql5】select  *   from Sys_Menu  where SystemTypeId=''201907011617511504'' 耗时 :21.7 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:46.180' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211125539094298', CAST(N'2021-01-12T11:12:55.390' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/SaveRoleAuthorize', 0, 1, CAST(N'2021-01-12T11:12:55.390' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211125957637562', CAST(N'2021-01-12T11:12:59.577' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】delete from Sys_RoleAuthorize where ObjectId=''F0A2B36F-35A7-4660-B46C-D4AB796591EB''; 耗时 :28.3 ms,状态 :成功【sql2】delete from Sys_RoleData where RoleId=''F0A2B36F-35A7-4660-B46C-D4AB796591EB''; 耗时 :24.4 ms,状态 :成功【sql3】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543309550''
           , 0
           , ''201806141508359155''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql4】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543315900''
           , 1
           , ''2021011211084197203605''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.8 ms,状态 :成功【sql5】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543321775''
           , 1
           , ''2021011211093383813777''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql6】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543329485''
           , 2
           , ''2021011211100583237730''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.9 ms,状态 :成功【sql7】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543325558''
           , 2
           , ''2021011211100590361637''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql8】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543326795''
           , 2
           , ''2021011211100595928007''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24 ms,状态 :成功【sql9】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543325675''
           , 2
           , ''2021011211100601001133''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.2 ms,状态 :成功【sql10】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543321716''
           , 2
           , ''2021011211100606072467''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.4 ms,状态 :成功【sql11】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543328809''
           , 2
           , ''2021011211100611473440''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql12】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543327902''
           , 2
           , ''2021011211100576523295''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql13】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543337145''
           , 1
           , ''2021011211111845261274''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.7 ms,状态 :成功【sql14】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543334552''
           , 2
           , ''2021011211113265594642''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.1 ms,状态 :成功【sql15】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543335052''
           , 2
           , ''2021011211113271113293''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.9 ms,状态 :成功【sql16】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543336565''
           , 2
           , ''2021011211113277633034''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql17】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543334083''
           , 2
           , ''2021011211113282976349''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql18】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543334766''
           , 2
           , ''2021011211113287838584''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql19】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543335166''
           , 2
           , ''2021011211113293224086''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql20】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543334450''
           , 2
           , ''2021011211113260438763''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql21】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543347979''
           , 1
           , ''1''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.8 ms,状态 :成功【sql22】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543343312''
           , 1
           , ''201905041649159560''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql23】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543343997''
           , 2
           , ''2021010314265872439474''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25 ms,状态 :成功【sql24】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543344809''
           , 2
           , ''2021010314280909099314''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.4 ms,状态 :成功【sql25】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543341886''
           , 1
           , ''3''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql26】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543345679''
           , 2
           , ''2021010314293148672477''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql27】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543341648''
           , 2
           , ''2021010314302276644526''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql28】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543341883''
           , 2
           , ''2021010314473160136431''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql29】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543351807''
           , 2
           , ''2021010314525585211515''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.8 ms,状态 :成功【sql30】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543356420''
           , 2
           , ''2021010314535010864350''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.5 ms,状态 :成功【sql31】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543359998''
           , 2
           , ''2021010320121395837658''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.7 ms,状态 :成功【sql32】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543354817''
           , 1
           , ''4''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql33】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543357342''
           , 2
           , ''2021010315063387468705''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.6 ms,状态 :成功【sql34】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543357430''
           , 2
           , ''2021010315063389314029''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql35】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543354366''
           , 2
           , ''2021010315063392168016''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql36】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543353643''
           , 2
           , ''2021010315063394048962''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.6 ms,状态 :成功【sql37】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543365913''
           , 2
           , ''2021010315063395829111''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.8 ms,状态 :成功【sql38】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543364523''
           , 2
           , ''2021010315063397424616''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql39】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543366759''
           , 2
           , ''2021010315063384478437''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql40】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543361381''
           , 2
           , ''2021010316040698162073''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :31.3 ms,状态 :成功【sql41】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543361409''
           , 2
           , ''2021010316051714119704''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :32.6 ms,状态 :成功【sql42】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543369612''
           , 1
           , ''5''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.9 ms,状态 :成功【sql43】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543368174''
           , 2
           , ''2021010315075515608293''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.7 ms,状态 :成功【sql44】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543364505''
           , 2
           , ''2021010315075517418867''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :53 ms,状态 :成功【sql45】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543371503''
           , 2
           , ''2021010315075519656824''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql46】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543377787''
           , 2
           , ''2021010315075521218314''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql47】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543374980''
           , 2
           , ''2021010315075522857783''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql48】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543377338''
           , 2
           , ''2021010315075524463436''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql49】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543374379''
           , 2
           , ''2021010315075525983094''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql50】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543371464''
           , 2
           , ''2021010315105223757513''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.3 ms,状态 :成功【sql51】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543373581''
           , 2
           , ''2021010315100806775237''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.7 ms,状态 :成功【sql52】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543389468''
           , 1
           , ''6''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :33.3 ms,状态 :成功【sql53】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543382759''
           , 2
           , ''2021010315132783165373''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql54】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543384992''
           , 2
           , ''2021010315132784647036''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql55】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543381760''
           , 2
           , ''2021010315132786229265''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :45 ms,状态 :成功【sql56】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543387089''
           , 2
           , ''2021010315132787977688''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql57】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543381506''
           , 2
           , ''2021010315132789912350''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql58】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543381376''
           , 2
           , ''2021010315132791643307''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql59】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543388419''
           , 2
           , ''2021010315132781838294''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql60】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543394423''
           , 2
           , ''2021010316083259762810''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.3 ms,状态 :成功【sql61】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543397289''
           , 2
           , ''2021010316100011385581''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql62】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543393491''
           , 2
           , ''2021010316100012707325''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql63】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543397302''
           , 2
           , ''2021010316100014008890''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql64】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543398088''
           , 2
           , ''2021010316100015306916''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql65】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543391433''
           , 2
           , ''2021010316100016609991''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql66】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543392889''
           , 2
           , ''2021010316100018015698''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.2 ms,状态 :成功【sql67】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543399635''
           , 2
           , ''2021010316100009998659''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.7 ms,状态 :成功【sql68】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543407844''
           , 1
           , ''2020042316122987266087''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.6 ms,状态 :成功【sql69】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543407434''
           , 2
           , ''2021010316453713145150''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :34.8 ms,状态 :成功【sql70】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543404431''
           , 2
           , ''2021010316453714778755''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql71】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543406456''
           , 2
           , ''2021010316453715932821''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.5 ms,状态 :成功【sql72】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543404661''
           , 2
           , ''2021010316453717238579''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.9 ms,状态 :成功【sql73】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543405336''
           , 2
           , ''2021010316453718652652''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql74】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543407310''
           , 2
           , ''2021010316453719872053''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.8 ms,状态 :成功【sql75】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543409922''
           , 2
           , ''2021010316453710775564''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql76】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543414351''
           , 1
           , ''2020110314123396328561''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.6 ms,状态 :成功【sql77】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543418180''
           , 2
           , ''2021010315175286366578''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.6 ms,状态 :成功【sql78】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543415506''
           , 2
           , ''2021010315175287647040''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.8 ms,状态 :成功【sql79】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543413419''
           , 2
           , ''2021010315175288886376''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.6 ms,状态 :成功【sql80】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543417458''
           , 2
           , ''2021010315175290104050''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql81】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543418351''
           , 2
           , ''2021010315175292201815''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql82】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543411784''
           , 2
           , ''2021010315175293736914''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql83】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543412778''
           , 2
           , ''2021010315175285146141''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql84】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543423473''
           , 1
           , ''8''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql85】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543426151''
           , 2
           , ''2021010315183150312981''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :39.9 ms,状态 :成功【sql86】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543428003''
           , 2
           , ''2021010315183151659795''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :33.9 ms,状态 :成功【sql87】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543423679''
           , 2
           , ''2021010315183153249546''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :30.8 ms,状态 :成功【sql88】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543422685''
           , 2
           , ''2021010315183154826786''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.7 ms,状态 :成功【sql89】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543423991''
           , 2
           , ''2021010315183156352951''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :49.2 ms,状态 :成功【sql90】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543427114''
           , 2
           , ''2021010315183157889290''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.8 ms,状态 :成功【sql91】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543427541''
           , 2
           , ''2021010315183159324286''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql92】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543439300''
           , 1
           , ''2020110314142274602075''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :31.5 ms,状态 :成功【sql93】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543439536''
           , 1
           , ''2020110314161523904459''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :41.9 ms,状态 :成功【sql94】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543433788''
           , 2
           , ''2021010315194792606013''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :31.5 ms,状态 :成功【sql95】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543431661''
           , 2
           , ''2021010315204129496922''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql96】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543436722''
           , 2
           , ''2021010315194793896582''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql97】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543438977''
           , 2
           , ''2021010315194795273488''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql98】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543437748''
           , 2
           , ''2021010315194797086431''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql99】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543433994''
           , 2
           , ''2021010315194798698862''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.3 ms,状态 :成功【sql100】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543443002''
           , 2
           , ''2021010315194799827547''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql101】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543441680''
           , 2
           , ''2021010315194800999273''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.9 ms,状态 :成功【sql102】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543442565''
           , 1
           , ''2020110314165224964779''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql103】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543443630''
           , 2
           , ''2021010315212004586381''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.9 ms,状态 :成功【sql104】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543448120''
           , 2
           , ''2021010321015604704406''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :32.7 ms,状态 :成功【sql105】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543444290''
           , 1
           , ''2020110314182794069057''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql106】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543446626''
           , 1
           , ''2020110314190914102881''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.8 ms,状态 :成功【sql107】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543444078''
           , 2
           , ''2021010315215315394611''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql108】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543459620''
           , 2
           , ''2021010315215327767703''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql109】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543454269''
           , 2
           , ''2021010315215328948079''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql110】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543457776''
           , 2
           , ''2021010315215330182636''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.9 ms,状态 :成功【sql111】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543456835''
           , 2
           , ''2021010315215331498258''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql112】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543457640''
           , 2
           , ''2021010315215332842957''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql113】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543456176''
           , 2
           , ''2021010315215334061002''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25 ms,状态 :成功【sql114】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543456838''
           , 1
           , ''2020110314195207514356''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql115】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543455632''
           , 2
           , ''2021010315222503738750''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.4 ms,状态 :成功【sql116】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543461276''
           , 2
           , ''2021010315222505099926''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.5 ms,状态 :成功【sql117】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543467998''
           , 2
           , ''2021010315222506982025''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql118】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543464610''
           , 2
           , ''2021010315222508743670''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql119】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543466621''
           , 2
           , ''2021010315222510354377''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.9 ms,状态 :成功【sql120】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543466241''
           , 2
           , ''2021010315222511918449''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql121】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543464112''
           , 2
           , ''2021010315222513987026''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql122】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543468610''
           , 1
           , ''201806120821141288''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql123】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543464975''
           , 1
           , ''7''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.3 ms,状态 :成功【sql124】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543473136''
           , 2
           , ''2021010315340190128841''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql125】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543478306''
           , 1
           , ''2020110314220971767837''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql126】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543476628''
           , 2
           , ''2021010321100441931251''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql127】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543477412''
           , 1
           , ''2020110314224299715445''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql128】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543476747''
           , 2
           , ''2021010321102869902680''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql129】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543475185''
           , 1
           , ''2020110314231504343408''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :31.6 ms,状态 :成功【sql130】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543478357''
           , 2
           , ''2021010321105884295252''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql131】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543486919''
           , 1
           , ''9''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.8 ms,状态 :成功【sql132】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543482170''
           , 1
           , ''201806141351101389''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql133】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543489492''
           , 2
           , ''2021010315233975086228''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql134】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543483551''
           , 2
           , ''2021010315233976493618''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql135】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543484640''
           , 2
           , ''2021010315233978026300''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.7 ms,状态 :成功【sql136】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543481252''
           , 2
           , ''2021010315233979627999''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql137】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543484881''
           , 2
           , ''2021010315233981246649''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql138】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543487783''
           , 2
           , ''2021010315233982801956''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql139】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543497341''
           , 2
           , ''2021010315233984299075''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql140】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543499146''
           , 1
           , ''201806291506346894''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql141】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543499859''
           , 2
           , ''2021010315295372466127''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql142】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543494272''
           , 2
           , ''2021010315295385481609''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.5 ms,状态 :成功【sql143】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543498663''
           , 2
           , ''2021010315295389238874''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql144】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543493476''
           , 2
           , ''2021010315295390992753''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql145】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543495244''
           , 2
           , ''2021010315295392674499''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql146】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543506062''
           , 2
           , ''2021010315295394456942''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql147】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543509554''
           , 2
           , ''2021010315295396508020''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.3 ms,状态 :成功【sql148】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543504463''
           , 2
           , ''2021010315315773909706''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.8 ms,状态 :成功【sql149】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543502510''
           , 2
           , ''2021010315323086026943''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql150】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543504033''
           , 1
           , ''201806121608404625''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql151】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543509697''
           , 2
           , ''2021010315304419294420''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql152】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543508047''
           , 2
           , ''2021010315304421057774''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql153】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543509714''
           , 2
           , ''2021010315304422692928''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.1 ms,状态 :成功【sql154】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543513939''
           , 2
           , ''2021010315304424338490''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql155】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543515704''
           , 2
           , ''2021010315304425833907''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :32.9 ms,状态 :成功【sql156】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543516643''
           , 2
           , ''2021010315304436069801''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql157】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543515147''
           , 2
           , ''2021010315304417212621''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql158】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543518696''
           , 1
           , ''2020042216381028741066''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql159】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125543519675''
           , 1
           , ''201806040726499682''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql160】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125545244325''
           , 0
           , ''201806141508359155''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.5 ms,状态 :成功【sql161】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211125545248704''
           , 0
           , ''201806141511351940''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:12:55''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql162】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211125544649677''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619434422287774''
           , ''dept'')  耗时 :22.4 ms,状态 :成功【sql163】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211125544649298''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619373694586929''
           , ''dept'')  耗时 :21.9 ms,状态 :成功【sql164】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211125544646945''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619392209546893''
           , ''dept'')  耗时 :22.9 ms,状态 :成功【sql165】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211125544649843''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619394356374788''
           , ''dept'')  耗时 :21.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:12:59.577' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211133237051154', CAST(N'2021-01-12T11:13:32.370' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/SaveRoleAuthorize', 0, 1, CAST(N'2021-01-12T11:13:32.370' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211133699438089', CAST(N'2021-01-12T11:13:36.993' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】delete from Sys_RoleAuthorize where ObjectId=''F0A2B36F-35A7-4660-B46C-D4AB796591EB''; 耗时 :24.4 ms,状态 :成功【sql2】delete from Sys_RoleData where RoleId=''F0A2B36F-35A7-4660-B46C-D4AB796591EB''; 耗时 :20.7 ms,状态 :成功【sql3】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241634075''
           , 0
           , ''201806141508359155''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql4】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241633039''
           , 1
           , ''2021011211084197203605''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql5】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241645266''
           , 1
           , ''2021011211093383813777''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql6】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241642412''
           , 2
           , ''2021011211100583237730''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.5 ms,状态 :成功【sql7】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241648120''
           , 2
           , ''2021011211100590361637''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql8】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241652978''
           , 2
           , ''2021011211100595928007''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql9】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241653944''
           , 2
           , ''2021011211100601001133''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.8 ms,状态 :成功【sql10】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241661944''
           , 2
           , ''2021011211100606072467''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.7 ms,状态 :成功【sql11】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241667970''
           , 2
           , ''2021011211100611473440''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql12】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241665106''
           , 2
           , ''2021011211100576523295''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.8 ms,状态 :成功【sql13】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241673156''
           , 1
           , ''2021011211111845261274''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.7 ms,状态 :成功【sql14】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241673436''
           , 2
           , ''2021011211113265594642''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26 ms,状态 :成功【sql15】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241672205''
           , 2
           , ''2021011211113271113293''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql16】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241687802''
           , 2
           , ''2021011211113277633034''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql17】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241684949''
           , 2
           , ''2021011211113282976349''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.2 ms,状态 :成功【sql18】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241687144''
           , 2
           , ''2021011211113287838584''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.5 ms,状态 :成功【sql19】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241694579''
           , 2
           , ''2021011211113293224086''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.1 ms,状态 :成功【sql20】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241696895''
           , 2
           , ''2021011211113260438763''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.4 ms,状态 :成功【sql21】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241705979''
           , 1
           , ''1''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.7 ms,状态 :成功【sql22】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241704125''
           , 1
           , ''201905041649159560''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql23】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241706317''
           , 2
           , ''2021010314265872439474''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.6 ms,状态 :成功【sql24】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241709613''
           , 2
           , ''2021010314280909099314''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23 ms,状态 :成功【sql25】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241708870''
           , 1
           , ''3''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.6 ms,状态 :成功【sql26】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241717741''
           , 2
           , ''2021010314293148672477''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.2 ms,状态 :成功【sql27】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241711831''
           , 2
           , ''2021010314302276644526''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql28】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241718725''
           , 2
           , ''2021010314473160136431''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.7 ms,状态 :成功【sql29】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241716467''
           , 2
           , ''2021010314525585211515''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23 ms,状态 :成功【sql30】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241724556''
           , 2
           , ''2021010314535010864350''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql31】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241724407''
           , 2
           , ''2021010320121395837658''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.4 ms,状态 :成功【sql32】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241723790''
           , 1
           , ''4''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql33】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241724156''
           , 2
           , ''2021010315063387468705''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.8 ms,状态 :成功【sql34】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241731716''
           , 2
           , ''2021010315063389314029''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.1 ms,状态 :成功【sql35】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241739768''
           , 2
           , ''2021010315063392168016''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql36】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241736423''
           , 2
           , ''2021010315063394048962''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.8 ms,状态 :成功【sql37】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241735098''
           , 2
           , ''2021010315063395829111''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql38】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241747820''
           , 2
           , ''2021010315063397424616''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql39】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241746597''
           , 2
           , ''2021010315063384478437''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.1 ms,状态 :成功【sql40】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241745745''
           , 2
           , ''2021010316040698162073''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.7 ms,状态 :成功【sql41】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241745892''
           , 2
           , ''2021010316051714119704''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.4 ms,状态 :成功【sql42】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241742279''
           , 1
           , ''5''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql43】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241751767''
           , 2
           , ''2021010315075515608293''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql44】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241752345''
           , 2
           , ''2021010315075517418867''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql45】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241758076''
           , 2
           , ''2021010315075519656824''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql46】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241759739''
           , 2
           , ''2021010315075521218314''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql47】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241751669''
           , 2
           , ''2021010315075522857783''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql48】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241751138''
           , 2
           , ''2021010315075524463436''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql49】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241763592''
           , 2
           , ''2021010315075525983094''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql50】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241767511''
           , 2
           , ''2021010315105223757513''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :43.4 ms,状态 :成功【sql51】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241769054''
           , 2
           , ''2021010315100806775237''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql52】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241761004''
           , 1
           , ''6''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql53】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241763963''
           , 2
           , ''2021010315132783165373''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql54】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241776864''
           , 2
           , ''2021010315132784647036''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.3 ms,状态 :成功【sql55】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241779008''
           , 2
           , ''2021010315132786229265''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql56】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241774653''
           , 2
           , ''2021010315132787977688''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql57】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241774945''
           , 2
           , ''2021010315132789912350''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql58】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241772011''
           , 2
           , ''2021010315132791643307''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql59】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241788227''
           , 2
           , ''2021010315132781838294''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql60】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241783478''
           , 2
           , ''2021010316083259762810''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql61】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241781334''
           , 2
           , ''2021010316100011385581''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql62】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241785558''
           , 2
           , ''2021010316100012707325''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :30 ms,状态 :成功【sql63】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241789806''
           , 2
           , ''2021010316100014008890''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23 ms,状态 :成功【sql64】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241792470''
           , 2
           , ''2021010316100015306916''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.9 ms,状态 :成功【sql65】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241791066''
           , 2
           , ''2021010316100016609991''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.2 ms,状态 :成功【sql66】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241797894''
           , 2
           , ''2021010316100018015698''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :30.2 ms,状态 :成功【sql67】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241798973''
           , 2
           , ''2021010316100009998659''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :30.5 ms,状态 :成功【sql68】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241792782''
           , 1
           , ''2020042316122987266087''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.1 ms,状态 :成功【sql69】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241809443''
           , 2
           , ''2021010316453713145150''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.5 ms,状态 :成功【sql70】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241801345''
           , 2
           , ''2021010316453714778755''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :375.3 ms,状态 :成功【sql71】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241804957''
           , 2
           , ''2021010316453715932821''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql72】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241807047''
           , 2
           , ''2021010316453717238579''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql73】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241801842''
           , 2
           , ''2021010316453718652652''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql74】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241814615''
           , 2
           , ''2021010316453719872053''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.2 ms,状态 :成功【sql75】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241818196''
           , 2
           , ''2021010316453710775564''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26 ms,状态 :成功【sql76】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241815363''
           , 1
           , ''2020110314123396328561''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.8 ms,状态 :成功【sql77】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241819761''
           , 2
           , ''2021010315175286366578''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.4 ms,状态 :成功【sql78】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241824132''
           , 2
           , ''2021010315175287647040''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql79】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241821311''
           , 2
           , ''2021010315175288886376''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.7 ms,状态 :成功【sql80】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241826088''
           , 2
           , ''2021010315175290104050''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.7 ms,状态 :成功【sql81】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241829374''
           , 2
           , ''2021010315175292201815''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.7 ms,状态 :成功【sql82】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241822755''
           , 2
           , ''2021010315175293736914''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql83】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241828202''
           , 2
           , ''2021010315175285146141''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.3 ms,状态 :成功【sql84】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241831522''
           , 1
           , ''8''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql85】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241833779''
           , 2
           , ''2021010315183150312981''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :44.1 ms,状态 :成功【sql86】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241832707''
           , 2
           , ''2021010315183151659795''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :40.2 ms,状态 :成功【sql87】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241837788''
           , 2
           , ''2021010315183153249546''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.7 ms,状态 :成功【sql88】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241841600''
           , 2
           , ''2021010315183154826786''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql89】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241843982''
           , 2
           , ''2021010315183156352951''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql90】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241847590''
           , 2
           , ''2021010315183157889290''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql91】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241848246''
           , 2
           , ''2021010315183159324286''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql92】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241843751''
           , 1
           , ''2020110314142274602075''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.4 ms,状态 :成功【sql93】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241853912''
           , 1
           , ''2020110314161523904459''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29 ms,状态 :成功【sql94】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241852327''
           , 2
           , ''2021010315194792606013''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :34.4 ms,状态 :成功【sql95】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241859530''
           , 2
           , ''2021010315204129496922''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :30.5 ms,状态 :成功【sql96】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241854480''
           , 2
           , ''2021010315194793896582''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.8 ms,状态 :成功【sql97】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241853192''
           , 2
           , ''2021010315194795273488''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql98】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241858135''
           , 2
           , ''2021010315194797086431''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql99】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241865683''
           , 2
           , ''2021010315194798698862''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql100】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241862387''
           , 2
           , ''2021010315194799827547''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.5 ms,状态 :成功【sql101】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241866848''
           , 2
           , ''2021010315194800999273''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.1 ms,状态 :成功【sql102】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241867835''
           , 1
           , ''2020110314165224964779''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql103】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241876881''
           , 2
           , ''2021010315212004586381''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql104】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241877241''
           , 2
           , ''2021010321015604704406''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :34.2 ms,状态 :成功【sql105】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241872666''
           , 1
           , ''2020110314182794069057''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26 ms,状态 :成功【sql106】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241876710''
           , 1
           , ''2020110314190914102881''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.1 ms,状态 :成功【sql107】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241875698''
           , 2
           , ''2021010315215315394611''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27 ms,状态 :成功【sql108】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241885367''
           , 2
           , ''2021010315215327767703''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql109】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241881547''
           , 2
           , ''2021010315215328948079''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql110】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241884835''
           , 2
           , ''2021010315215330182636''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.6 ms,状态 :成功【sql111】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241884045''
           , 2
           , ''2021010315215331498258''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.8 ms,状态 :成功【sql112】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241886808''
           , 2
           , ''2021010315215332842957''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql113】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241898177''
           , 2
           , ''2021010315215334061002''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql114】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241899520''
           , 1
           , ''2020110314195207514356''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql115】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241896565''
           , 2
           , ''2021010315222503738750''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.9 ms,状态 :成功【sql116】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241894355''
           , 2
           , ''2021010315222505099926''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql117】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241891654''
           , 2
           , ''2021010315222506982025''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql118】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241905068''
           , 2
           , ''2021010315222508743670''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23 ms,状态 :成功【sql119】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241903752''
           , 2
           , ''2021010315222510354377''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql120】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241906688''
           , 2
           , ''2021010315222511918449''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql121】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241902378''
           , 2
           , ''2021010315222513987026''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql122】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241902188''
           , 1
           , ''201806120821141288''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql123】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241908015''
           , 1
           , ''7''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql124】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241918903''
           , 2
           , ''2021010315340190128841''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql125】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241912918''
           , 1
           , ''2020110314220971767837''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql126】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241917683''
           , 2
           , ''2021010321100441931251''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql127】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241915859''
           , 1
           , ''2020110314224299715445''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql128】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241923152''
           , 2
           , ''2021010321102869902680''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql129】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241926298''
           , 1
           , ''2020110314231504343408''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql130】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241925932''
           , 2
           , ''2021010321105884295252''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :31.9 ms,状态 :成功【sql131】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241927873''
           , 1
           , ''9''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.3 ms,状态 :成功【sql132】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241922333''
           , 1
           , ''201806141351101389''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.2 ms,状态 :成功【sql133】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241935900''
           , 2
           , ''2021010315233975086228''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql134】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241931072''
           , 2
           , ''2021010315233976493618''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.5 ms,状态 :成功【sql135】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241938392''
           , 2
           , ''2021010315233978026300''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql136】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241935865''
           , 2
           , ''2021010315233979627999''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.6 ms,状态 :成功【sql137】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241934905''
           , 2
           , ''2021010315233981246649''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.9 ms,状态 :成功【sql138】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241944301''
           , 2
           , ''2021010315233982801956''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.1 ms,状态 :成功【sql139】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241946058''
           , 2
           , ''2021010315233984299075''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql140】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241941402''
           , 1
           , ''201806291506346894''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql141】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241948972''
           , 2
           , ''2021010315295372466127''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.8 ms,状态 :成功【sql142】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241945519''
           , 2
           , ''2021010315295385481609''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.1 ms,状态 :成功【sql143】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241952502''
           , 2
           , ''2021010315295389238874''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql144】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241954884''
           , 2
           , ''2021010315295390992753''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.4 ms,状态 :成功【sql145】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241955229''
           , 2
           , ''2021010315295392674499''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.2 ms,状态 :成功【sql146】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241951566''
           , 2
           , ''2021010315295394456942''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql147】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241956189''
           , 2
           , ''2021010315295396508020''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.1 ms,状态 :成功【sql148】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241962859''
           , 2
           , ''2021010315315773909706''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.6 ms,状态 :成功【sql149】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241967856''
           , 2
           , ''2021010315323086026943''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.3 ms,状态 :成功【sql150】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241962850''
           , 1
           , ''201806121608404625''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.8 ms,状态 :成功【sql151】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241964224''
           , 2
           , ''2021010315304419294420''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.6 ms,状态 :成功【sql152】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241965070''
           , 2
           , ''2021010315304421057774''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :32.9 ms,状态 :成功【sql153】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241976347''
           , 2
           , ''2021010315304422692928''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :31.5 ms,状态 :成功【sql154】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241971933''
           , 2
           , ''2021010315304424338490''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :35.9 ms,状态 :成功【sql155】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241971011''
           , 2
           , ''2021010315304425833907''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.8 ms,状态 :成功【sql156】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241976789''
           , 2
           , ''2021010315304436069801''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :33.8 ms,状态 :成功【sql157】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241976778''
           , 2
           , ''2021010315304417212621''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql158】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241984970''
           , 1
           , ''2020042216381028741066''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.4 ms,状态 :成功【sql159】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133241985930''
           , 1
           , ''201806040726499682''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.8 ms,状态 :成功【sql160】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133245424821''
           , 0
           , ''201806141508359155''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.6 ms,状态 :成功【sql161】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211133245422223''
           , 0
           , ''201806141511351940''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:13:32''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql162】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211133243748592''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619434422287774''
           , ''dept'')  耗时 :23.4 ms,状态 :成功【sql163】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211133243745199''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619373694586929''
           , ''dept'')  耗时 :29.3 ms,状态 :成功【sql164】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211133243753918''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619392209546893''
           , ''dept'')  耗时 :27.9 ms,状态 :成功【sql165】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211133243752845''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619394356374788''
           , ''dept'')  耗时 :21.9 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:13:36.993' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211140088282162', CAST(N'2021-01-12T11:14:00.883' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/SaveRoleAuthorize', 0, 1, CAST(N'2021-01-12T11:14:00.883' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211140551036379', CAST(N'2021-01-12T11:14:05.510' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】delete from Sys_RoleAuthorize where ObjectId=''F0A2B36F-35A7-4660-B46C-D4AB796591EB''; 耗时 :36 ms,状态 :成功【sql2】delete from Sys_RoleData where RoleId=''F0A2B36F-35A7-4660-B46C-D4AB796591EB''; 耗时 :23.4 ms,状态 :成功【sql3】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092277401''
           , 0
           , ''201806141508359155''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql4】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092272659''
           , 1
           , ''2021011211084197203605''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :38.1 ms,状态 :成功【sql5】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092272026''
           , 1
           , ''2021011211093383813777''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.5 ms,状态 :成功【sql6】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092281510''
           , 2
           , ''2021011211100583237730''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :381.4 ms,状态 :成功【sql7】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092285923''
           , 2
           , ''2021011211100590361637''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26 ms,状态 :成功【sql8】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092288416''
           , 2
           , ''2021011211100595928007''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :42.4 ms,状态 :成功【sql9】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092289990''
           , 2
           , ''2021011211100601001133''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.2 ms,状态 :成功【sql10】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092297061''
           , 2
           , ''2021011211100606072467''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.9 ms,状态 :成功【sql11】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092294824''
           , 2
           , ''2021011211100611473440''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.2 ms,状态 :成功【sql12】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092291789''
           , 2
           , ''2021011211100576523295''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.2 ms,状态 :成功【sql13】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092291536''
           , 1
           , ''2021011211111845261274''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.3 ms,状态 :成功【sql14】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092302006''
           , 2
           , ''2021011211113265594642''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.3 ms,状态 :成功【sql15】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092302356''
           , 2
           , ''2021011211113271113293''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.9 ms,状态 :成功【sql16】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092305092''
           , 2
           , ''2021011211113277633034''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql17】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092307521''
           , 2
           , ''2021011211113282976349''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql18】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092315064''
           , 2
           , ''2021011211113287838584''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.1 ms,状态 :成功【sql19】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092318920''
           , 2
           , ''2021011211113293224086''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.2 ms,状态 :成功【sql20】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092315439''
           , 2
           , ''2021011211113260438763''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.1 ms,状态 :成功【sql21】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092311140''
           , 1
           , ''1''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.3 ms,状态 :成功【sql22】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092325927''
           , 1
           , ''201905041649159560''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.2 ms,状态 :成功【sql23】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092329199''
           , 2
           , ''2021010314265872439474''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :34.4 ms,状态 :成功【sql24】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092321457''
           , 2
           , ''2021010314280909099314''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.2 ms,状态 :成功【sql25】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092324669''
           , 1
           , ''3''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.3 ms,状态 :成功【sql26】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092337274''
           , 2
           , ''2021010314293148672477''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :31.4 ms,状态 :成功【sql27】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092336044''
           , 2
           , ''2021010314302276644526''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.4 ms,状态 :成功【sql28】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092338215''
           , 2
           , ''2021010314473160136431''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql29】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092335261''
           , 2
           , ''2021010314525585211515''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.7 ms,状态 :成功【sql30】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092347116''
           , 2
           , ''2021010314535010864350''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.6 ms,状态 :成功【sql31】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092345802''
           , 2
           , ''2021010320121395837658''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.7 ms,状态 :成功【sql32】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092345121''
           , 1
           , ''4''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.2 ms,状态 :成功【sql33】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092341671''
           , 2
           , ''2021010315063387468705''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.8 ms,状态 :成功【sql34】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092357486''
           , 2
           , ''2021010315063389314029''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.5 ms,状态 :成功【sql35】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092351244''
           , 2
           , ''2021010315063392168016''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.3 ms,状态 :成功【sql36】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092354075''
           , 2
           , ''2021010315063394048962''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :39.4 ms,状态 :成功【sql37】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092358637''
           , 2
           , ''2021010315063395829111''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.4 ms,状态 :成功【sql38】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092359471''
           , 2
           , ''2021010315063397424616''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.5 ms,状态 :成功【sql39】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092367299''
           , 2
           , ''2021010315063384478437''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :40.3 ms,状态 :成功【sql40】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092362753''
           , 2
           , ''2021010316040698162073''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.6 ms,状态 :成功【sql41】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092367298''
           , 2
           , ''2021010316051714119704''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.4 ms,状态 :成功【sql42】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092362272''
           , 1
           , ''5''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26 ms,状态 :成功【sql43】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092374030''
           , 2
           , ''2021010315075515608293''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.1 ms,状态 :成功【sql44】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092378637''
           , 2
           , ''2021010315075517418867''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :30.7 ms,状态 :成功【sql45】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092371584''
           , 2
           , ''2021010315075519656824''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql46】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092383270''
           , 2
           , ''2021010315075521218314''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.7 ms,状态 :成功【sql47】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092382890''
           , 2
           , ''2021010315075522857783''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql48】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092384630''
           , 2
           , ''2021010315075524463436''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.4 ms,状态 :成功【sql49】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092386999''
           , 2
           , ''2021010315075525983094''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.7 ms,状态 :成功【sql50】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092399087''
           , 2
           , ''2021010315105223757513''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25 ms,状态 :成功【sql51】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092391356''
           , 2
           , ''2021010315100806775237''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.3 ms,状态 :成功【sql52】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092394689''
           , 1
           , ''6''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.2 ms,状态 :成功【sql53】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092393589''
           , 2
           , ''2021010315132783165373''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql54】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092401602''
           , 2
           , ''2021010315132784647036''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql55】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092403953''
           , 2
           , ''2021010315132786229265''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.7 ms,状态 :成功【sql56】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092407015''
           , 2
           , ''2021010315132787977688''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql57】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092403806''
           , 2
           , ''2021010315132789912350''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.7 ms,状态 :成功【sql58】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092415859''
           , 2
           , ''2021010315132791643307''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql59】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092416247''
           , 2
           , ''2021010315132781838294''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.7 ms,状态 :成功【sql60】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092415679''
           , 2
           , ''2021010316083259762810''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql61】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092425710''
           , 2
           , ''2021010316100011385581''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.6 ms,状态 :成功【sql62】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092422645''
           , 2
           , ''2021010316100012707325''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql63】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092423400''
           , 2
           , ''2021010316100014008890''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.8 ms,状态 :成功【sql64】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092424729''
           , 2
           , ''2021010316100015306916''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql65】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092428602''
           , 2
           , ''2021010316100016609991''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql66】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092436051''
           , 2
           , ''2021010316100018015698''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.3 ms,状态 :成功【sql67】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092432717''
           , 2
           , ''2021010316100009998659''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.3 ms,状态 :成功【sql68】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092433403''
           , 1
           , ''2020042316122987266087''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql69】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092442523''
           , 2
           , ''2021010316453713145150''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql70】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092443821''
           , 2
           , ''2021010316453714778755''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23 ms,状态 :成功【sql71】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092446743''
           , 2
           , ''2021010316453715932821''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql72】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092449622''
           , 2
           , ''2021010316453717238579''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.5 ms,状态 :成功【sql73】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092456657''
           , 2
           , ''2021010316453718652652''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.2 ms,状态 :成功【sql74】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092455892''
           , 2
           , ''2021010316453719872053''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql75】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092451001''
           , 2
           , ''2021010316453710775564''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql76】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092453489''
           , 1
           , ''2020110314123396328561''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql77】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092455874''
           , 2
           , ''2021010315175286366578''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql78】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092453660''
           , 2
           , ''2021010315175287647040''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql79】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092469415''
           , 2
           , ''2021010315175288886376''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql80】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092466470''
           , 2
           , ''2021010315175290104050''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24 ms,状态 :成功【sql81】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092466167''
           , 2
           , ''2021010315175292201815''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.2 ms,状态 :成功【sql82】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092468387''
           , 2
           , ''2021010315175293736914''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql83】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092462838''
           , 2
           , ''2021010315175285146141''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.7 ms,状态 :成功【sql84】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092463573''
           , 1
           , ''8''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql85】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092464295''
           , 2
           , ''2021010315183150312981''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql86】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092472987''
           , 2
           , ''2021010315183151659795''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.9 ms,状态 :成功【sql87】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092475979''
           , 2
           , ''2021010315183153249546''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.7 ms,状态 :成功【sql88】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092478015''
           , 2
           , ''2021010315183154826786''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql89】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092473064''
           , 2
           , ''2021010315183156352951''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql90】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092486944''
           , 2
           , ''2021010315183157889290''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql91】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092484978''
           , 2
           , ''2021010315183159324286''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.3 ms,状态 :成功【sql92】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092486470''
           , 1
           , ''2020110314142274602075''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql93】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092492076''
           , 1
           , ''2020110314161523904459''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql94】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092491114''
           , 2
           , ''2021010315194792606013''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql95】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092499714''
           , 2
           , ''2021010315204129496922''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.2 ms,状态 :成功【sql96】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092491158''
           , 2
           , ''2021010315194793896582''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.9 ms,状态 :成功【sql97】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092506457''
           , 2
           , ''2021010315194795273488''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql98】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092508992''
           , 2
           , ''2021010315194797086431''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.4 ms,状态 :成功【sql99】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092503081''
           , 2
           , ''2021010315194798698862''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.9 ms,状态 :成功【sql100】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092507743''
           , 2
           , ''2021010315194799827547''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.1 ms,状态 :成功【sql101】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092515359''
           , 2
           , ''2021010315194800999273''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql102】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092511347''
           , 1
           , ''2020110314165224964779''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql103】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092515718''
           , 2
           , ''2021010315212004586381''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.7 ms,状态 :成功【sql104】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092518869''
           , 2
           , ''2021010321015604704406''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql105】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092523650''
           , 1
           , ''2020110314182794069057''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql106】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092527497''
           , 1
           , ''2020110314190914102881''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql107】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092524980''
           , 2
           , ''2021010315215315394611''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.6 ms,状态 :成功【sql108】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092525346''
           , 2
           , ''2021010315215327767703''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.4 ms,状态 :成功【sql109】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092531215''
           , 2
           , ''2021010315215328948079''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql110】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092537635''
           , 2
           , ''2021010315215330182636''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql111】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092539940''
           , 2
           , ''2021010315215331498258''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql112】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092544722''
           , 2
           , ''2021010315215332842957''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql113】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092547041''
           , 2
           , ''2021010315215334061002''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql114】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092549130''
           , 1
           , ''2020110314195207514356''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql115】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092547574''
           , 2
           , ''2021010315222503738750''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql116】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092546653''
           , 2
           , ''2021010315222505099926''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.2 ms,状态 :成功【sql117】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092551241''
           , 2
           , ''2021010315222506982025''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.2 ms,状态 :成功【sql118】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092554521''
           , 2
           , ''2021010315222508743670''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.4 ms,状态 :成功【sql119】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092557722''
           , 2
           , ''2021010315222510354377''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.6 ms,状态 :成功【sql120】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092563530''
           , 2
           , ''2021010315222511918449''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql121】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092567048''
           , 2
           , ''2021010315222513987026''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.9 ms,状态 :成功【sql122】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092563060''
           , 1
           , ''201806120821141288''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :41.1 ms,状态 :成功【sql123】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092563032''
           , 1
           , ''7''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.8 ms,状态 :成功【sql124】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092571160''
           , 2
           , ''2021010315340190128841''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql125】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092578476''
           , 1
           , ''2020110314220971767837''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql126】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092579714''
           , 2
           , ''2021010321100441931251''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.9 ms,状态 :成功【sql127】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092574797''
           , 1
           , ''2020110314224299715445''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.5 ms,状态 :成功【sql128】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092582605''
           , 2
           , ''2021010321102869902680''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.2 ms,状态 :成功【sql129】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092589260''
           , 1
           , ''2020110314231504343408''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql130】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092589410''
           , 2
           , ''2021010321105884295252''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql131】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092587886''
           , 1
           , ''9''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.9 ms,状态 :成功【sql132】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092598633''
           , 1
           , ''201806141351101389''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql133】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092595639''
           , 2
           , ''2021010315233975086228''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql134】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092596474''
           , 2
           , ''2021010315233976493618''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql135】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092603052''
           , 2
           , ''2021010315233978026300''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.7 ms,状态 :成功【sql136】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092608452''
           , 2
           , ''2021010315233979627999''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql137】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092604487''
           , 2
           , ''2021010315233981246649''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.9 ms,状态 :成功【sql138】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092609043''
           , 2
           , ''2021010315233982801956''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.3 ms,状态 :成功【sql139】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092601501''
           , 2
           , ''2021010315233984299075''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql140】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092613167''
           , 1
           , ''201806291506346894''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql141】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092614545''
           , 2
           , ''2021010315295372466127''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql142】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092612903''
           , 2
           , ''2021010315295385481609''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql143】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092627235''
           , 2
           , ''2021010315295389238874''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql144】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092627643''
           , 2
           , ''2021010315295390992753''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql145】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092622777''
           , 2
           , ''2021010315295392674499''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.4 ms,状态 :成功【sql146】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092629765''
           , 2
           , ''2021010315295394456942''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24 ms,状态 :成功【sql147】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092632212''
           , 2
           , ''2021010315295396508020''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql148】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092631192''
           , 2
           , ''2021010315315773909706''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql149】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092631039''
           , 2
           , ''2021010315323086026943''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.4 ms,状态 :成功【sql150】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092641202''
           , 1
           , ''201806121608404625''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql151】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092644205''
           , 2
           , ''2021010315304419294420''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql152】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092643685''
           , 2
           , ''2021010315304421057774''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.8 ms,状态 :成功【sql153】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092643023''
           , 2
           , ''2021010315304422692928''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.6 ms,状态 :成功【sql154】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092655719''
           , 2
           , ''2021010315304424338490''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.5 ms,状态 :成功【sql155】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092652681''
           , 2
           , ''2021010315304425833907''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.8 ms,状态 :成功【sql156】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092657517''
           , 2
           , ''2021010315304436069801''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.8 ms,状态 :成功【sql157】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092654162''
           , 2
           , ''2021010315304417212621''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.7 ms,状态 :成功【sql158】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092661911''
           , 1
           , ''2020042216381028741066''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql159】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140092669670''
           , 1
           , ''201806040726499682''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql160】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140094409138''
           , 0
           , ''201806141508359155''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.4 ms,状态 :成功【sql161】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211140094403929''
           , 0
           , ''201806141511351940''
           , 1
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , 99
           , ''2021-01-12T11:14:00''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql162】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211140093705235''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619434422287774''
           , ''dept'')  耗时 :21.5 ms,状态 :成功【sql163】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211140093709400''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619373694586929''
           , ''dept'')  耗时 :22.3 ms,状态 :成功【sql164】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211140093708704''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619392209546893''
           , ''dept'')  耗时 :21.5 ms,状态 :成功【sql165】 INSERT INTO Sys_RoleData
           (Id
           , RoleId
           , AuthorizeData
           , DType)
     VALUES
           (''2021011211140093709247''
           , ''F0A2B36F-35A7-4660-B46C-D4AB796591EB''
           , ''2020101619394356374788''
           , ''dept'')  耗时 :21.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:14:05.510' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211142969758132', CAST(N'2021-01-12T11:14:29.697' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Organize/GetAllOrganizeTreeTable', 0, 1, CAST(N'2021-01-12T11:14:29.697' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211142973471109', CAST(N'2021-01-12T11:14:29.733' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleData/GetAllRoleDataByRoleId?roleId=4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 0, 1, CAST(N'2021-01-12T11:14:29.733' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211142976281915', CAST(N'2021-01-12T11:14:29.763' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Organize  耗时 :25.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:14:29.763' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211142978561874', CAST(N'2021-01-12T11:14:29.787' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_RoleData  where RoleId=''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C'' 耗时 :20 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:14:29.787' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211143004793415', CAST(N'2021-01-12T11:14:30.047' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetAllEnable', 0, 1, CAST(N'2021-01-12T11:14:30.047' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211143010165022', CAST(N'2021-01-12T11:14:30.100' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  where  DeleteMark=0 and EnabledMark=1 耗时 :21.5 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:14:30.100' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211143044852972', CAST(N'2021-01-12T11:14:30.450' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/GetRoleAuthorizeFunction?roleId=4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C&itemType=1', 0, 1, CAST(N'2021-01-12T11:14:30.450' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211143045323332', CAST(N'2021-01-12T11:14:30.453' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/GetRoleAuthorizeFunction?roleId=4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C&itemType=0', 0, 1, CAST(N'2021-01-12T11:14:30.453' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211143052365818', CAST(N'2021-01-12T11:14:30.523' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *  from Sys_RoleAuthorize  where ItemType=0 and ObjectId in (''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C'') and ObjectType=1 耗时 :28.8 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:14:30.523' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211160253939805', CAST(N'2021-01-12T11:16:02.540' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Login/Logout', 0, 1, CAST(N'2021-01-12T11:16:02.540' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211160267539882', CAST(N'2021-01-12T11:16:02.677' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select * from Sys_UserLogOn  where UserId=''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'' 耗时 :22.3 ms,状态 :成功【sql2】SET NOCOUNT ON;
UPDATE [Sys_UserLogOn] SET [AllowEndTime] = 2100-12-31T23:59:59, [AllowStartTime] = 2017-01-01T00:00:00, [AnswerQuestion] = '''', [ChangePasswordDate] = 2020-10-12T09:26:34, [CheckIPAddress] = 0, [FirstVisitTime] = 2020-10-06T15:05:27, [Language] = '''', [LastVisitTime] = 2021-01-12T11:07:07, [LockEndDate] = 2020-10-06T00:00:00, [LockStartDate] = 2017-01-01T00:00:00, [LogOnCount] = 160, [MultiUserLogin] = 0, [PreviousVisitTime] = 2021-01-12T11:07:07, [Question] = '''', [Theme] = '''', [UserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [UserOnLine] = 0, [UserPassword] = ''5039b1d6a774b864af4a013d9c905c06'', [UserSecretkey] = ''9eeb98044bbedd1a''
WHERE [Id] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'';
SELECT @@ROWCOUNT;

 耗时 :23.3 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:02.677' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211160318536888', CAST(N'2021-01-12T11:16:03.187' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Captcha', 0, 1, CAST(N'2021-01-12T11:16:03.187' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211160408929703', CAST(N'2021-01-12T11:16:04.090' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT * FROM Sys_APP t WHERE t.AppId = ''system'' and AppSecret=''87135AB0160F706D8B47F06BDABA6FC6'' and EnabledMark=1 耗时 :22.9 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:04.090' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211160451009681', CAST(N'2021-01-12T11:16:04.510' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Captcha', 0, 1, CAST(N'2021-01-12T11:16:04.510' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211160540403319', CAST(N'2021-01-12T11:16:05.403' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT * FROM Sys_APP t WHERE t.AppId = ''system'' and AppSecret=''87135AB0160F706D8B47F06BDABA6FC6'' and EnabledMark=1 耗时 :22 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:05.403' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211160695425425', CAST(N'2021-01-12T11:16:06.953' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Security/SysSetting/GetInfo', 0, 1, CAST(N'2021-01-12T11:16:06.953' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211161537743559', CAST(N'2021-01-12T11:16:15.377' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Login/GetCheckUser?username=admin&password=admin888&vcode=T7ug&vkey=202101121116045560&appId=system&systemCode=openauth', 0, 1, CAST(N'2021-01-12T11:16:15.377' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211161541446775', CAST(N'2021-01-12T11:16:17.393' AS DateTime), N'admin', N'超级管理员', NULL, N'Login', N'0.0.0.1', N'未知', NULL, N'登录', 1, N'登录成功', 0, 1, CAST(N'2021-01-12T11:16:17.393' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211161744933938', CAST(N'2021-01-12T11:16:17.450' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select count(*) from Sys_FilterIP  where  replace(StartIP, ''.'', '''')>=1 and replace(EndIP, ''.'', '''')<=1 and FilterType=0 and EnabledMark=1 耗时 :21.1 ms,状态 :成功【sql2】SELECT * FROM Sys_APP t WHERE t.AppId = ''system'' and EnabledMark=1 耗时 :23.6 ms,状态 :成功【sql3】SELECT * FROM Sys_SystemType t WHERE t.EnCode = ''openauth'' 耗时 :21.8 ms,状态 :成功【sql4】SELECT * FROM Sys_User t WHERE (t.Account = ''admin'' Or t.Email = ''admin'' Or t.MobilePhone = ''admin'') 耗时 :22.1 ms,状态 :成功【sql5】SELECT * FROM Sys_UserLogOn t WHERE t.UserId = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'' 耗时 :23.4 ms,状态 :成功【sql6】select * from Sys_UserLogOn  where UserId=''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'' 耗时 :21.5 ms,状态 :成功【sql7】SET NOCOUNT ON;
UPDATE [Sys_UserLogOn] SET [AllowEndTime] = 2100-12-31T23:59:59, [AllowStartTime] = 2017-01-01T00:00:00, [AnswerQuestion] = '''', [ChangePasswordDate] = 2020-10-12T09:26:34, [CheckIPAddress] = 0, [FirstVisitTime] = 2020-10-06T15:05:27, [Language] = '''', [LastVisitTime] = 2021-01-12T11:16:15, [LockEndDate] = 2020-10-06T00:00:00, [LockStartDate] = 2017-01-01T00:00:00, [LogOnCount] = 161, [MultiUserLogin] = 0, [PreviousVisitTime] = 2021-01-12T11:16:15, [Question] = '''', [Theme] = '''', [UserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [UserOnLine] = 1, [UserPassword] = ''5039b1d6a774b864af4a013d9c905c06'', [UserSecretkey] = ''9eeb98044bbedd1a''
WHERE [Id] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'';
SELECT @@ROWCOUNT;

 耗时 :22.2 ms,状态 :成功【sql8】select  *  from Sys_Role  where Id in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') 耗时 :25.7 ms,状态 :成功【sql9】SELECT 1 耗时 :27.9 ms,状态 :成功【sql10】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :28.2 ms,状态 :成功【sql11】SELECT 1 耗时 :41.3 ms,状态 :成功【sql12】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :29.1 ms,状态 :成功【sql13】SELECT 1 耗时 :27.7 ms,状态 :成功【sql14】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :30.7 ms,状态 :成功【sql15】SELECT 1 耗时 :26.3 ms,状态 :成功【sql16】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :29.2 ms,状态 :成功【sql17】SELECT 1 耗时 :27 ms,状态 :成功【sql18】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :26.5 ms,状态 :成功【sql19】SELECT 1 耗时 :22.8 ms,状态 :成功【sql20】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :29.9 ms,状态 :成功【sql21】SELECT 1 耗时 :29.4 ms,状态 :成功【sql22】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :26.4 ms,状态 :成功【sql23】SELECT 1 耗时 :22 ms,状态 :成功【sql24】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :30.2 ms,状态 :成功【sql25】SELECT 1 耗时 :22 ms,状态 :成功【sql26】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :25.6 ms,状态 :成功【sql27】SELECT 1 耗时 :22.4 ms,状态 :成功【sql28】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :28.5 ms,状态 :成功【sql29】SELECT 1 耗时 :22 ms,状态 :成功【sql30】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :24.8 ms,状态 :成功【sql31】SELECT 1 耗时 :22.8 ms,状态 :成功【sql32】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.7 ms,状态 :成功【sql33】SELECT 1 耗时 :20.7 ms,状态 :成功【sql34】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :21.7 ms,状态 :成功【sql35】SELECT 1 耗时 :20.6 ms,状态 :成功【sql36】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.5 ms,状态 :成功【sql37】SELECT 1 耗时 :22.7 ms,状态 :成功【sql38】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.6 ms,状态 :成功【sql39】SELECT 1 耗时 :22 ms,状态 :成功【sql40】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :25.2 ms,状态 :成功【sql41】SELECT 1 耗时 :21.6 ms,状态 :成功【sql42】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.2 ms,状态 :成功【sql43】SELECT 1 耗时 :22.1 ms,状态 :成功【sql44】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :28.1 ms,状态 :成功【sql45】SELECT 1 耗时 :24.2 ms,状态 :成功【sql46】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :25.2 ms,状态 :成功【sql47】SELECT 1 耗时 :22.1 ms,状态 :成功【sql48】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :24.8 ms,状态 :成功【sql49】SELECT 1 耗时 :24 ms,状态 :成功【sql50】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :24.7 ms,状态 :成功【sql51】SELECT 1 耗时 :23.5 ms,状态 :成功【sql52】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.6 ms,状态 :成功【sql53】SELECT 1 耗时 :23.1 ms,状态 :成功【sql54】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.3 ms,状态 :成功【sql55】SELECT 1 耗时 :21.9 ms,状态 :成功【sql56】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :30.2 ms,状态 :成功【sql57】SELECT 1 耗时 :24.3 ms,状态 :成功【sql58】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.1 ms,状态 :成功【sql59】SELECT 1 耗时 :21.6 ms,状态 :成功【sql60】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :23.2 ms,状态 :成功【sql61】SELECT 1 耗时 :22.5 ms,状态 :成功【sql62】
IF EXISTS
    (SELECT *
     FROM [sys].[objects] o
     WHERE [o].[type] = ''U''
     AND [o].[is_ms_shipped] = 0
     AND NOT EXISTS (SELECT *
         FROM [sys].[extended_properties] AS [ep]
         WHERE [ep].[major_id] = [o].[object_id]
             AND [ep].[minor_id] = 0
             AND [ep].[class] = 1
             AND [ep].[name] = N''microsoft_database_tools_support''
    )
)
SELECT 1 ELSE SELECT 0 耗时 :25.4 ms,状态 :成功【sql63】select  *  from Sys_SystemType  where  DeleteMark=0 and EnabledMark=1  耗时 :22.7 ms,状态 :成功【sql64】SELECT DISTINCT b.* FROM sys_menu as b INNER JOIN Sys_RoleAuthorize as a On b.Id = a.ItemId   Where SystemTypeId=''201806141508359155''  耗时 :74.5 ms,状态 :成功【sql65】SELECT * FROM Sys_SystemType t WHERE t.EnCode = ''openauth'' 耗时 :22.2 ms,状态 :成功【sql66】SELECT DISTINCT b.* FROM sys_menu as b INNER JOIN Sys_RoleAuthorize as a On b.Id = a.ItemId  WHERE ObjectId IN (''F0A2B36F-35A7-4660-B46C-D4AB796591EB'')and menutype in(''M'', ''C'') AND SystemTypeId=''201806141508359155''  耗时 :51.3 ms,状态 :成功【sql67】select AuthorizeData from Sys_RoleData  where  RoleId in(''F0A2B36F-35A7-4660-B46C-D4AB796591EB'') and DType=''dept'' 耗时 :20 ms,状态 :成功【sql68】insert into Sys_Log ([Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''2021-01-12T11:16:17'', ''admin'', ''超级管理员'', '''', ''Login'', ''0.0.0.1'', ''未知'', '''', ''登录'', 1, ''登录成功'', 0, 1, ''2021-01-12T11:16:17'', '''', '''', '''', '''', '''', ''2021011211161541446775''); select @@ROWCOUNT  num 耗时 :30 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:17.450' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211161813488491', CAST(N'2021-01-12T11:16:18.133' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=null', 0, 1, CAST(N'2021-01-12T11:16:18.133' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211161816869362', CAST(N'2021-01-12T11:16:18.170' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=Menu', 0, 1, CAST(N'2021-01-12T11:16:18.170' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211161873661486', CAST(N'2021-01-12T11:16:18.737' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=', 0, 1, CAST(N'2021-01-12T11:16:18.737' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211161895202476', CAST(N'2021-01-12T11:16:18.953' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  where 1=1 耗时 :24.4 ms,状态 :成功【sql2】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :53.4 ms,状态 :成功【sql3】select  *   from Sys_Menu  where SystemTypeId=''201806141511351940'' 耗时 :22.6 ms,状态 :成功【sql4】select  *   from Sys_Menu  where SystemTypeId=''201904031316131800'' 耗时 :29.6 ms,状态 :成功【sql5】select  *   from Sys_Menu  where SystemTypeId=''201907011617511504'' 耗时 :30.2 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:18.953' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211162917669379', CAST(N'2021-01-12T11:16:29.177' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/CMS/Articlenews/FindWithPagerAsync', 0, 1, CAST(N'2021-01-12T11:16:29.177' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211162935003748', CAST(N'2021-01-12T11:16:29.350' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select count(*) as Total from cms_articlenews Where 1=1 ;With Paging AS
                ( SELECT ROW_NUMBER() OVER ( order by CreatorTime DESC) as RowNumber,  *  FROM cms_articlenews Where 1=1)
                SELECT * FROM Paging WHERE RowNumber Between 1 and 20 耗时 :36.5 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:29.350' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211163208922804', CAST(N'2021-01-12T11:16:32.090' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=Articlecategory', 0, 1, CAST(N'2021-01-12T11:16:32.090' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211163606511394', CAST(N'2021-01-12T11:16:36.067' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/CMS/Articlecategory/GetAllCategoryTreeTable?keyword=', 0, 1, CAST(N'2021-01-12T11:16:36.067' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211163615074105', CAST(N'2021-01-12T11:16:36.150' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from cms_articlecategory  where 1=1 order by ClassLayer, SortCode 耗时 :32.8 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:36.150' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211164792411917', CAST(N'2021-01-12T11:16:47.923' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/CMS/Articlecategory/Insert', 0, 1, CAST(N'2021-01-12T11:16:47.923' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211164802328613', CAST(N'2021-01-12T11:16:48.023' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】INSERT INTO cms_articlecategory ([Title], [ParentId], [ClassPath], [ClassLayer], [SortCode], [LinkUrl], [ImgUrl], [SeoTitle], [SeoKeywords], [SeoDescription], [IsHot], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''公告'', '''', '''', 1, 99, '''', '''', '''', '''', '''', null, '''', 1, 0, ''2021-01-12T11:16:47'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', ''2020101619434422287774'', ''2020101619392209546893'', '''', '''', '''', '''', ''2021011211164796431794''); select @@ROWCOUNT  num 耗时 :42.7 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:48.023' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211164850097992', CAST(N'2021-01-12T11:16:48.500' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/CMS/Articlecategory/GetAllCategoryTreeTable?keyword=', 0, 1, CAST(N'2021-01-12T11:16:48.500' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211164862086439', CAST(N'2021-01-12T11:16:48.620' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from cms_articlecategory  where 1=1 order by ClassLayer, SortCode 耗时 :35.5 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:48.620' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211165022205999', CAST(N'2021-01-12T11:16:50.223' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/CMS/Articlecategory/GetAllCategoryTreeTable?keyword=', 0, 1, CAST(N'2021-01-12T11:16:50.223' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211165029213353', CAST(N'2021-01-12T11:16:50.293' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from cms_articlecategory  where 1=1 order by ClassLayer, SortCode 耗时 :23.3 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:50.293' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211165661006095', CAST(N'2021-01-12T11:16:56.610' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/CMS/Articlecategory/Insert', 0, 1, CAST(N'2021-01-12T11:16:56.610' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211165667644747', CAST(N'2021-01-12T11:16:56.677' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】INSERT INTO cms_articlecategory ([Title], [ParentId], [ClassPath], [ClassLayer], [SortCode], [LinkUrl], [ImgUrl], [SeoTitle], [SeoKeywords], [SeoDescription], [IsHot], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (''通知'', '''', '''', 1, 99, '''', '''', '''', '''', '''', null, '''', 1, 0, ''2021-01-12T11:16:56'', ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', ''2020101619434422287774'', ''2020101619392209546893'', '''', '''', '''', '''', ''2021011211165664517119''); select @@ROWCOUNT  num 耗时 :26.3 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:56.677' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211165711226594', CAST(N'2021-01-12T11:16:57.113' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/CMS/Articlecategory/GetAllCategoryTreeTable?keyword=', 0, 1, CAST(N'2021-01-12T11:16:57.113' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211165718015470', CAST(N'2021-01-12T11:16:57.180' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from cms_articlecategory  where 1=1 order by ClassLayer, SortCode 耗时 :28.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:57.180' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211165937537344', CAST(N'2021-01-12T11:16:59.377' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=Articlenews', 0, 1, CAST(N'2021-01-12T11:16:59.377' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211170273049767', CAST(N'2021-01-12T11:17:02.730' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=Articlecategory', 0, 1, CAST(N'2021-01-12T11:17:02.730' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211143052366710', CAST(N'2021-01-12T11:14:30.523' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *  from Sys_RoleAuthorize  where ItemType=1 and ObjectId in (''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C'') and ObjectType=1 耗时 :23.6 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:14:30.523' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211143045763914', CAST(N'2021-01-12T11:14:30.457' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/GetAllFunctionTree', 0, 1, CAST(N'2021-01-12T11:14:30.457' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211143074222901', CAST(N'2021-01-12T11:14:30.743' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  where 1=1 耗时 :22.2 ms,状态 :成功【sql2】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :68.6 ms,状态 :成功【sql3】select  *   from Sys_Menu  where SystemTypeId=''201806141511351940'' 耗时 :21.6 ms,状态 :成功【sql4】select  *   from Sys_Menu  where SystemTypeId=''201904031316131800'' 耗时 :21.1 ms,状态 :成功【sql5】select  *   from Sys_Menu  where SystemTypeId=''201907011617511504'' 耗时 :21.1 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:14:30.743' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211145601249266', CAST(N'2021-01-12T11:14:56.013' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/RoleAuthorize/SaveRoleAuthorize', 0, 1, CAST(N'2021-01-12T11:14:56.013' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211145995265967', CAST(N'2021-01-12T11:14:59.953' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】delete from Sys_RoleAuthorize where ObjectId=''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''; 耗时 :21.7 ms,状态 :成功【sql2】delete from Sys_RoleData where RoleId=''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''; 耗时 :22 ms,状态 :成功【sql3】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606225153''
           , 0
           , ''201806141508359155''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql4】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606239557''
           , 1
           , ''2021011211084197203605''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql5】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606231461''
           , 1
           , ''2021011211093383813777''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.6 ms,状态 :成功【sql6】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606231079''
           , 2
           , ''2021011211100583237730''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql7】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606234807''
           , 2
           , ''2021011211100590361637''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql8】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606236697''
           , 2
           , ''2021011211100595928007''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql9】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606237785''
           , 2
           , ''2021011211100601001133''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.8 ms,状态 :成功【sql10】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606239333''
           , 2
           , ''2021011211100606072467''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.5 ms,状态 :成功【sql11】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606231330''
           , 2
           , ''2021011211100611473440''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql12】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606235154''
           , 2
           , ''2021011211100576523295''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql13】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606232008''
           , 1
           , ''2021011211111845261274''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.1 ms,状态 :成功【sql14】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606238646''
           , 2
           , ''2021011211113265594642''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql15】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606246898''
           , 2
           , ''2021011211113271113293''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql16】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606245527''
           , 2
           , ''2021011211113277633034''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.9 ms,状态 :成功【sql17】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606249737''
           , 2
           , ''2021011211113282976349''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql18】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606242568''
           , 2
           , ''2021011211113287838584''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23 ms,状态 :成功【sql19】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606247851''
           , 2
           , ''2021011211113293224086''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql20】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606245969''
           , 2
           , ''2021011211113260438763''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.9 ms,状态 :成功【sql21】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606241776''
           , 1
           , ''1''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql22】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606242764''
           , 1
           , ''201905041649159560''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.2 ms,状态 :成功【sql23】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606244299''
           , 2
           , ''2021010314265872439474''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql24】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606246594''
           , 2
           , ''2021010314280909099314''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql25】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606243882''
           , 1
           , ''3''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql26】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606258883''
           , 2
           , ''2021010314293148672477''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql27】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606253049''
           , 2
           , ''2021010314302276644526''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.4 ms,状态 :成功【sql28】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606258325''
           , 2
           , ''2021010314473160136431''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.7 ms,状态 :成功【sql29】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606256794''
           , 2
           , ''2021010314525585211515''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql30】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606257660''
           , 2
           , ''2021010314535010864350''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql31】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606251159''
           , 2
           , ''2021010320121395837658''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql32】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606255144''
           , 1
           , ''4''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.3 ms,状态 :成功【sql33】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606254037''
           , 2
           , ''2021010315063387468705''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.5 ms,状态 :成功【sql34】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606255805''
           , 2
           , ''2021010315063389314029''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql35】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606259735''
           , 2
           , ''2021010315063392168016''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql36】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606257239''
           , 2
           , ''2021010315063394048962''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :31.1 ms,状态 :成功【sql37】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606251399''
           , 2
           , ''2021010315063395829111''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.6 ms,状态 :成功【sql38】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606262320''
           , 2
           , ''2021010315063397424616''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql39】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606261498''
           , 2
           , ''2021010315063384478437''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql40】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606264438''
           , 2
           , ''2021010316040698162073''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.8 ms,状态 :成功【sql41】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606261612''
           , 2
           , ''2021010316051714119704''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql42】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606263028''
           , 1
           , ''5''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.2 ms,状态 :成功【sql43】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606263388''
           , 2
           , ''2021010315075515608293''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql44】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606267460''
           , 2
           , ''2021010315075517418867''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql45】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606266444''
           , 2
           , ''2021010315075519656824''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql46】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606273634''
           , 2
           , ''2021010315075521218314''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.8 ms,状态 :成功【sql47】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606279922''
           , 2
           , ''2021010315075522857783''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql48】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606271897''
           , 2
           , ''2021010315075524463436''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql49】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606274161''
           , 2
           , ''2021010315075525983094''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.4 ms,状态 :成功【sql50】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606271784''
           , 2
           , ''2021010315105223757513''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql51】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606274195''
           , 2
           , ''2021010315100806775237''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql52】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606279009''
           , 1
           , ''6''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql53】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606273263''
           , 2
           , ''2021010315132783165373''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.3 ms,状态 :成功【sql54】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606272521''
           , 2
           , ''2021010315132784647036''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.1 ms,状态 :成功【sql55】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606276132''
           , 2
           , ''2021010315132786229265''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql56】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606278648''
           , 2
           , ''2021010315132787977688''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql57】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606275727''
           , 2
           , ''2021010315132789912350''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.6 ms,状态 :成功【sql58】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606287305''
           , 2
           , ''2021010315132791643307''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql59】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606287925''
           , 2
           , ''2021010315132781838294''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql60】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606288202''
           , 2
           , ''2021010316083259762810''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.9 ms,状态 :成功【sql61】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606288448''
           , 2
           , ''2021010316100011385581''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25 ms,状态 :成功【sql62】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606281409''
           , 2
           , ''2021010316100012707325''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23 ms,状态 :成功【sql63】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606284039''
           , 2
           , ''2021010316100014008890''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql64】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606283978''
           , 2
           , ''2021010316100015306916''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.4 ms,状态 :成功【sql65】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606286282''
           , 2
           , ''2021010316100016609991''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql66】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606287663''
           , 2
           , ''2021010316100018015698''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.2 ms,状态 :成功【sql67】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606282751''
           , 2
           , ''2021010316100009998659''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.5 ms,状态 :成功【sql68】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606283980''
           , 1
           , ''2020042316122987266087''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.9 ms,状态 :成功【sql69】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606288094''
           , 2
           , ''2021010316453713145150''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql70】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606291282''
           , 2
           , ''2021010316453714778755''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql71】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606293746''
           , 2
           , ''2021010316453715932821''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql72】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606297648''
           , 2
           , ''2021010316453717238579''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.2 ms,状态 :成功【sql73】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606293393''
           , 2
           , ''2021010316453718652652''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.3 ms,状态 :成功【sql74】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606295408''
           , 2
           , ''2021010316453719872053''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql75】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606292159''
           , 2
           , ''2021010316453710775564''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql76】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606291513''
           , 1
           , ''2020110314123396328561''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.9 ms,状态 :成功【sql77】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606298247''
           , 2
           , ''2021010315175286366578''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql78】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606293592''
           , 2
           , ''2021010315175287647040''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql79】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606292167''
           , 2
           , ''2021010315175288886376''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql80】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606295844''
           , 2
           , ''2021010315175290104050''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql81】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606307702''
           , 2
           , ''2021010315175292201815''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22 ms,状态 :成功【sql82】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606305109''
           , 2
           , ''2021010315175293736914''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.1 ms,状态 :成功【sql83】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606309578''
           , 2
           , ''2021010315175285146141''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql84】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606309994''
           , 1
           , ''8''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql85】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606302184''
           , 2
           , ''2021010315183150312981''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql86】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606303058''
           , 2
           , ''2021010315183151659795''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql87】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606306826''
           , 2
           , ''2021010315183153249546''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.3 ms,状态 :成功【sql88】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606307503''
           , 2
           , ''2021010315183154826786''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql89】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606308065''
           , 2
           , ''2021010315183156352951''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.1 ms,状态 :成功【sql90】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606303022''
           , 2
           , ''2021010315183157889290''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql91】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606304234''
           , 2
           , ''2021010315183159324286''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql92】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606309835''
           , 1
           , ''2020110314142274602075''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.1 ms,状态 :成功【sql93】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606319627''
           , 1
           , ''2020110314161523904459''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql94】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606318719''
           , 2
           , ''2021010315194792606013''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql95】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606318321''
           , 2
           , ''2021010315204129496922''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.2 ms,状态 :成功【sql96】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606312443''
           , 2
           , ''2021010315194793896582''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.6 ms,状态 :成功【sql97】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606311986''
           , 2
           , ''2021010315194795273488''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.6 ms,状态 :成功【sql98】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606319776''
           , 2
           , ''2021010315194797086431''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql99】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606319044''
           , 2
           , ''2021010315194798698862''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.7 ms,状态 :成功【sql100】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606313064''
           , 2
           , ''2021010315194799827547''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.8 ms,状态 :成功【sql101】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606315235''
           , 2
           , ''2021010315194800999273''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql102】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606314261''
           , 1
           , ''2020110314165224964779''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21 ms,状态 :成功【sql103】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606315168''
           , 2
           , ''2021010315212004586381''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.2 ms,状态 :成功【sql104】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606325588''
           , 2
           , ''2021010321015604704406''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql105】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606329326''
           , 1
           , ''2020110314182794069057''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.4 ms,状态 :成功【sql106】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606321013''
           , 1
           , ''2020110314190914102881''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.7 ms,状态 :成功【sql107】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606323365''
           , 2
           , ''2021010315215315394611''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23 ms,状态 :成功【sql108】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606327038''
           , 2
           , ''2021010315215327767703''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql109】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606323491''
           , 2
           , ''2021010315215328948079''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.9 ms,状态 :成功【sql110】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606325211''
           , 2
           , ''2021010315215330182636''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.2 ms,状态 :成功【sql111】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606328665''
           , 2
           , ''2021010315215331498258''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24 ms,状态 :成功【sql112】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606328975''
           , 2
           , ''2021010315215332842957''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.9 ms,状态 :成功【sql113】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606327773''
           , 2
           , ''2021010315215334061002''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql114】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606325809''
           , 1
           , ''2020110314195207514356''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.1 ms,状态 :成功【sql115】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606337007''
           , 2
           , ''2021010315222503738750''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql116】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606335414''
           , 2
           , ''2021010315222505099926''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.3 ms,状态 :成功【sql117】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606336624''
           , 2
           , ''2021010315222506982025''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.6 ms,状态 :成功【sql118】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606334477''
           , 2
           , ''2021010315222508743670''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.1 ms,状态 :成功【sql119】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606338869''
           , 2
           , ''2021010315222510354377''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.7 ms,状态 :成功【sql120】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606333315''
           , 2
           , ''2021010315222511918449''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.7 ms,状态 :成功【sql121】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606336724''
           , 2
           , ''2021010315222513987026''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.9 ms,状态 :成功【sql122】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606339665''
           , 1
           , ''201806120821141288''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.3 ms,状态 :成功【sql123】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606333299''
           , 1
           , ''7''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26 ms,状态 :成功【sql124】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606339802''
           , 2
           , ''2021010315340190128841''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.7 ms,状态 :成功【sql125】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606339824''
           , 1
           , ''2020110314220971767837''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.5 ms,状态 :成功【sql126】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606336220''
           , 2
           , ''2021010321100441931251''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.2 ms,状态 :成功【sql127】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606348232''
           , 1
           , ''2020110314224299715445''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.1 ms,状态 :成功【sql128】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606345156''
           , 2
           , ''2021010321102869902680''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.1 ms,状态 :成功【sql129】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606344028''
           , 1
           , ''2020110314231504343408''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.6 ms,状态 :成功【sql130】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606347119''
           , 2
           , ''2021010321105884295252''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.4 ms,状态 :成功【sql131】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606345395''
           , 1
           , ''9''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.8 ms,状态 :成功【sql132】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606346725''
           , 1
           , ''201806141351101389''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :19.8 ms,状态 :成功【sql133】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606347038''
           , 2
           , ''2021010315233975086228''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.9 ms,状态 :成功【sql134】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606348344''
           , 2
           , ''2021010315233976493618''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.1 ms,状态 :成功【sql135】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606344825''
           , 2
           , ''2021010315233978026300''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.8 ms,状态 :成功【sql136】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606344429''
           , 2
           , ''2021010315233979627999''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28 ms,状态 :成功【sql137】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606348612''
           , 2
           , ''2021010315233981246649''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.4 ms,状态 :成功【sql138】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606348419''
           , 2
           , ''2021010315233982801956''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.5 ms,状态 :成功【sql139】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606356832''
           , 2
           , ''2021010315233984299075''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24.2 ms,状态 :成功【sql140】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606356333''
           , 1
           , ''201806291506346894''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29.9 ms,状态 :成功【sql141】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606355540''
           , 2
           , ''2021010315295372466127''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :29 ms,状态 :成功【sql142】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606355870''
           , 2
           , ''2021010315295385481609''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :25.4 ms,状态 :成功【sql143】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606358369''
           , 2
           , ''2021010315295389238874''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :23.3 ms,状态 :成功【sql144】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606359564''
           , 2
           , ''2021010315295390992753''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27.3 ms,状态 :成功【sql145】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606353697''
           , 2
           , ''2021010315295392674499''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.8 ms,状态 :成功【sql146】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606351443''
           , 2
           , ''2021010315295394456942''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :34.1 ms,状态 :成功【sql147】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606353505''
           , 2
           , ''2021010315295396508020''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :20.7 ms,状态 :成功【sql148】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606353258''
           , 2
           , ''2021010315315773909706''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.8 ms,状态 :成功【sql149】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606355658''
           , 2
           , ''2021010315323086026943''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql150】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606368132''
           , 1
           , ''201806121608404625''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :21.5 ms,状态 :成功【sql151】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606363482''
           , 2
           , ''2021010315304419294420''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql152】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606365277''
           , 2
           , ''2021010315304421057774''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.7 ms,状态 :成功【sql153】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606367389''
           , 2
           , ''2021010315304422692928''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :27 ms,状态 :成功【sql154】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606366543''
           , 2
           , ''2021010315304424338490''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :28.5 ms,状态 :成功【sql155】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606362206''
           , 2
           , ''2021010315304425833907''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.9 ms,状态 :成功【sql156】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606363012''
           , 2
           , ''2021010315304436069801''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24 ms,状态 :成功【sql157】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606365267''
           , 2
           , ''2021010315304417212621''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :22.6 ms,状态 :成功【sql158】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606367142''
           , 1
           , ''2020042216381028741066''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :24 ms,状态 :成功【sql159】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606368734''
           , 1
           , ''201806040726499682''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :26.5 ms,状态 :成功【sql160】 INSERT INTO Sys_RoleAuthorize
           (Id
           , ItemType
           , ItemId
           , ObjectType
           , ObjectId
           , SortCode
           , CreatorTime
           , CreatorUserId)
     VALUES(''2021011211145606941326''
           , 0
           , ''201806141508359155''
           , 1
           , ''4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C''
           , 99
           , ''2021-01-12T11:14:56''
           , ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'')  耗时 :31.2 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:14:59.953' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211152375612514', CAST(N'2021-01-12T11:15:23.757' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=Menu', 0, 1, CAST(N'2021-01-12T11:15:23.757' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211152789268072', CAST(N'2021-01-12T11:15:27.893' AS DateTime), NULL, NULL, NULL, N'Visit', N'::1', NULL, NULL, NULL, 0, N'/api/Security/Menu/GetById?id=2021011211084197203605', 0, 1, CAST(N'2021-01-12T11:15:27.893' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211152795118549', CAST(N'2021-01-12T11:15:27.950' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211084197203605'' 耗时 :23.3 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:15:27.950' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211152854693313', CAST(N'2021-01-12T11:15:28.547' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:15:28.547' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211152865581963', CAST(N'2021-01-12T11:15:28.657' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :62.8 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:15:28.657' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211153573056349', CAST(N'2021-01-12T11:15:35.730' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/Update?id=2021011211084197203605', 0, 1, CAST(N'2021-01-12T11:15:35.730' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211153588435791', CAST(N'2021-01-12T11:15:35.883' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】SELECT TOP(1) [s].[Id], [s].[AllowDelete], [s].[AllowEdit], [s].[Component], [s].[CreatorTime], [s].[CreatorUserId], [s].[DeleteMark], [s].[DeleteTime], [s].[DeleteUserId], [s].[Description], [s].[EnCode], [s].[EnabledMark], [s].[FullName], [s].[Icon], [s].[IsCache], [s].[IsExpand], [s].[IsFrame], [s].[IsPublic], [s].[IsShow], [s].[LastModifyTime], [s].[LastModifyUserId], [s].[Layers], [s].[MenuType], [s].[ParentId], [s].[SortCode], [s].[SystemTypeId], [s].[Target], [s].[UrlAddress]
FROM [Sys_Menu] AS [s]
WHERE [s].[Id] = ''2021011211084197203605'' 耗时 :32.1 ms,状态 :成功【sql2】SET NOCOUNT ON;
UPDATE [Sys_Menu] SET [AllowDelete] = '''', [AllowEdit] = '''', [Component] = '''', [CreatorTime] = 2021-01-12T11:08:41, [CreatorUserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [DeleteMark] = 0, [DeleteTime] = null, [DeleteUserId] = '''', [Description] = '''', [EnCode] = ''Cms'', [EnabledMark] = 1, [FullName] = ''文章管理'', [Icon] = ''icon-emaxcitygerenxinxitubiaoji03'', [IsCache] = 0, [IsExpand] = 0, [IsFrame] = 0, [IsPublic] = 0, [IsShow] = 1, [LastModifyTime] = 2021-01-12T11:15:35, [LastModifyUserId] = ''9f2ec079-7d0f-4fe2-90ab-8b09a8302aba'', [Layers] = 1, [MenuType] = ''C'', [ParentId] = '''', [SortCode] = 1299, [SystemTypeId] = ''201806141508359155'', [Target] = '''', [UrlAddress] = ''/cms''
WHERE [Id] = ''2021011211084197203605'';
SELECT @@ROWCOUNT;

 耗时 :26.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:15:35.883' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211153647721562', CAST(N'2021-01-12T11:15:36.477' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/Menu/GetAllMenuTreeTable?systemTypeId=201806141508359155', 0, 1, CAST(N'2021-01-12T11:15:36.477' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211153657575499', CAST(N'2021-01-12T11:15:36.577' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_Menu  where SystemTypeId=''201806141508359155'' 耗时 :50 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:15:36.577' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211153660771398', CAST(N'2021-01-12T11:15:36.607' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:15:36.607' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211153666791625', CAST(N'2021-01-12T11:15:36.667' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :23.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:15:36.667' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211161884211137', CAST(N'2021-01-12T11:16:18.843' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Security/SystemType/GetSubSystemList', 0, 1, CAST(N'2021-01-12T11:16:18.843' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211161890834322', CAST(N'2021-01-12T11:16:18.910' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from Sys_SystemType  耗时 :27.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:18.910' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211162509241622', CAST(N'2021-01-12T11:16:25.093' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=Articlecategory', 0, 1, CAST(N'2021-01-12T11:16:25.093' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211162575418186', CAST(N'2021-01-12T11:16:25.753' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/CMS/Articlecategory/GetAllCategoryTreeTable?keyword=', 0, 1, CAST(N'2021-01-12T11:16:25.753' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211162614058321', CAST(N'2021-01-12T11:16:26.140' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from cms_articlecategory  where 1=1 order by ClassLayer, SortCode 耗时 :29.7 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:26.140' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211162864188912', CAST(N'2021-01-12T11:16:28.643' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/Function/GetListByParentEnCode?enCode=Articlenews', 0, 1, CAST(N'2021-01-12T11:16:28.643' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211162912296054', CAST(N'2021-01-12T11:16:29.123' AS DateTime), N'admin', N'超级管理员', NULL, N'Visit', N'::1', N'未知', NULL, NULL, 0, N'/api/CMS/Articlecategory/GetAllCategoryTreeTable', 0, 1, CAST(N'2021-01-12T11:16:29.123' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Log] ([Id], [Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211162919281376', CAST(N'2021-01-12T11:16:29.193' AS DateTime), NULL, NULL, NULL, N'SQL', NULL, NULL, NULL, NULL, 1, N'【sql1】select  *   from cms_articlecategory  where 1=1 order by ClassLayer, SortCode 耗时 :26.4 ms,状态 :成功', 0, 1, CAST(N'2021-01-12T11:16:29.193' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'1', N'201806141508359155', N'', 1, N'Security', N'系统管理', N'icon-set', N'/setting', NULL, N'expand', N'C', 1, 0, 1, 0, 0, 1, 1, 996, 0, 1, NULL, CAST(N'2018-06-03T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-04T11:46:33.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2018-06-03T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806040726499682', N'201806141508359155', N'9', 2, N'DbTools', N'数据库连接', N'icon-databaseserverst', N'/tool/dbtools', N'tool/dbtools', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 100, 0, 1, NULL, CAST(N'2018-06-04T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-04-22T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806120821141288', N'201806141508359155', N'', 1, N'SysLog', N'日志管理', N'icon-log', N'/log', NULL, N'expand', N'C', 0, 0, 1, 0, 0, 1, 1, 998, 0, 1, NULL, CAST(N'2018-06-12T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-04T11:47:15.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806121608404625', N'201806141508359155', N'9', 2, N'Menu', N'功能模块', N'icon-module', N'/menu/index', N'menu/index', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 7, 0, 1, NULL, CAST(N'2018-06-12T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:48:38.000' AS DateTime), N'2020031712130656785909', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806141351101389', N'201806141508359155', N'9', 2, N'SystemType', N'系统类型', N'icon-xitong', N'/systemtype/index', N'systemtype/index', N'expand', N'M', 0, 0, 1, 0, 0, 1, 1, 5, 0, 1, NULL, CAST(N'2018-06-14T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:48:16.000' AS DateTime), N'2020031712130656785909', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806291506346894', N'201806141508359155', N'9', 2, N'APP', N'应用管理', N'icon-app', N'/app/index', N'app/index', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 6, 0, 1, NULL, CAST(N'2018-06-29T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:48:26.000' AS DateTime), N'2020031712130656785909', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201905041649159560', N'201806141508359155', N'1', 2, N'SysSetting/Index', N'系统设置', N'icon-set', N'/setting/index', N'setting/index', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, NULL, CAST(N'2019-05-04T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-04-22T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020042216381028741066', N'201806141508359155', N'9', 2, N'CodeGenerator', N'代码生成器', N'icon-code', N'/tool/index', N'tool/index', NULL, N'M', 0, 0, 1, 0, 0, 1, 1, 99, 0, 1, NULL, CAST(N'2020-04-22T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-04-22T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020042316122987266087', N'201806141508359155', N'1', 2, N'UploadFile', N'文件管理', N'icon-emaxcitygerenxinxitubiaoji03', N'/uploadfile/index', N'uploadfile/index', NULL, N'M', 0, 0, 1, 0, 1, 1, 1, 99, 0, 1, NULL, CAST(N'2020-04-23T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:46:19.000' AS DateTime), N'2020031712130656785909', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314123396328561', N'201806141508359155', N'1', 2, N'Tenant', N'多租户', N'icon-shequ', N'/tenant/index', N'tenant/index', NULL, N'M', 0, 0, 1, 0, 1, 1, 1, 99, 0, 1, NULL, CAST(N'2020-11-03T14:12:34.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:46:32.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314142274602075', N'201806141508359155', N'', 1, N'Task', N'定时任务', N'icon-time', N'/taskmanager', NULL, NULL, N'C', 0, 0, 1, 0, 0, 1, 1, 997, 0, 1, NULL, CAST(N'2020-11-03T14:14:23.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-04T11:46:46.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314161523904459', N'201806141508359155', N'2020110314142274602075', 2, N'TaskManager', N'任务列表', N'icon-time', N'/taskmanager/index', N'taskmanager/index', NULL, N'M', 0, 0, 1, 0, 0, 1, 1, 99, 0, 1, NULL, CAST(N'2020-11-03T14:16:15.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:47:39.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314165224964779', N'201806141508359155', N'2020110314142274602075', 2, N'TaskJobsLog', N'任务日志', N'icon-log', N'/taskmanager/log', N'taskmanager/log', NULL, N'M', 0, 0, 1, 0, 0, 1, 1, 99, 0, 1, NULL, CAST(N'2020-11-03T14:16:52.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:47:15.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314182794069057', N'201806141508359155', N'', 1, N'DocumentConfig', N'单据配置', N'icon-emaxcitygerenxinxitubiaoji03', N'/seq', NULL, NULL, N'C', 0, 0, 1, 0, 0, 1, 1, 997, 0, 1, NULL, CAST(N'2020-11-03T14:18:28.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-04T11:46:59.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314190914102881', N'201806141508359155', N'2020110314182794069057', 2, N'Sequence', N'业务单据编码', N'icon-xuhao', N'/seq/index', N'seq/index', NULL, N'M', 0, 0, 1, 0, 0, 1, 1, 99, 0, 1, NULL, CAST(N'2020-11-03T14:19:09.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:47:51.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314195207514356', N'201806141508359155', N'2020110314182794069057', 2, N'SequenceRule', N'单据编码规则', N'icon-guze', N'/seq/rule', N'seq/rule', NULL, N'M', 0, 0, 1, 0, 0, 1, 1, 100, 0, 1, NULL, CAST(N'2020-11-03T14:19:52.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:48:02.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314220971767837', N'201806141508359155', N'201806120821141288', 2, N'Log/List', N'操作日志', N'icon-log', N'/syslog/index', N'syslog/index', NULL, N'M', 0, 0, 1, 0, 0, 1, 1, 99, 0, 1, NULL, CAST(N'2020-11-03T14:22:10.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-12-26T14:02:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314224299715445', N'201806141508359155', N'201806120821141288', 2, N'Log/Exception', N'异常日志', N'icon-log', N'/syslog/exception', N'syslog/exception', NULL, N'M', 0, 0, 1, 0, 0, 1, 1, 99, 0, 1, NULL, CAST(N'2020-11-03T14:22:43.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-12-26T14:02:06.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020110314231504343408', N'201806141508359155', N'201806120821141288', 2, N'Log/SQL', N'SQL日志', N'icon-log', N'/syslog/sql', N'syslog/sql', NULL, N'M', 0, 0, 1, 0, 0, 1, 1, 99, 0, 1, NULL, CAST(N'2020-11-03T14:23:15.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-12-26T14:02:12.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010314265872439474', N'201806141508359155', N'201905041649159560', 3, N'SysSetting/GetSysInfo', N'获取系统信息', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T14:26:59.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010314280909099314', N'201806141508359155', N'201905041649159560', 3, N'SysSetting/Edit', N'修改', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T14:28:09.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010314293148672477', N'201806141508359155', N'3', 3, N'Organize/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T14:29:31.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-03T19:01:38.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010314302276644526', N'201806141508359155', N'3', 3, N'Organize/Edit', N'修改', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T14:30:23.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-03T14:53:24.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010314473160136431', N'201806141508359155', N'3', 3, N'Organize/Delete', N'删除', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T14:47:32.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-03T14:51:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010314525585211515', N'201806141508359155', N'3', 3, N'Organize/Enable', N'启用', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T14:52:56.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-03T14:53:08.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010314535010864350', N'201806141508359155', N'3', 3, N'Organize/Enable', N'禁用', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T14:53:50.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315063384478437', N'201806141508359155', N'4', 3, N'User/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T15:06:34.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315063387468705', N'201806141508359155', N'4', 3, N'User/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:06:34.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315063389314029', N'201806141508359155', N'4', 3, N'User/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:06:34.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315063392168016', N'201806141508359155', N'4', 3, N'User/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:06:34.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315063394048962', N'201806141508359155', N'4', 3, N'User/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:06:34.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315063395829111', N'201806141508359155', N'4', 3, N'User/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:06:34.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315063397424616', N'201806141508359155', N'4', 3, N'User/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:06:34.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315075515608293', N'201806141508359155', N'5', 3, N'Role/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:07:55.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315075517418867', N'201806141508359155', N'5', 3, N'Role/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:07:55.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315075519656824', N'201806141508359155', N'5', 3, N'Role/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:07:55.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315075521218314', N'201806141508359155', N'5', 3, N'Role/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:07:55.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315075522857783', N'201806141508359155', N'5', 3, N'Role/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:07:55.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315075524463436', N'201806141508359155', N'5', 3, N'Role/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:07:55.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315075525983094', N'201806141508359155', N'5', 3, N'Role/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:07:55.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315100806775237', N'201806141508359155', N'5', 3, N'RoleAuthorize/List', N'角色功能', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 1, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T15:10:08.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-03T21:18:21.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315105223757513', N'201806141508359155', N'5', 3, N'Role/SetAuthorize', N'设置权限', N'true', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 8, 0, 1, NULL, CAST(N'2021-01-03T15:10:52.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315132781838294', N'201806141508359155', N'6', 3, N'Items/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T15:13:28.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315132783165373', N'201806141508359155', N'6', 3, N'Items/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:13:28.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315132784647036', N'201806141508359155', N'6', 3, N'Items/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:13:28.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315132786229265', N'201806141508359155', N'6', 3, N'Items/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:13:28.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315132787977688', N'201806141508359155', N'6', 3, N'Items/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:13:28.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315132789912350', N'201806141508359155', N'6', 3, N'Items/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:13:28.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315132791643307', N'201806141508359155', N'6', 3, N'Items/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:13:28.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315175285146141', N'201806141508359155', N'2020110314123396328561', 3, N'Tenant/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T15:17:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315175286366578', N'201806141508359155', N'2020110314123396328561', 3, N'Tenant/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:17:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315175287647040', N'201806141508359155', N'2020110314123396328561', 3, N'Tenant/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:17:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315175288886376', N'201806141508359155', N'2020110314123396328561', 3, N'Tenant/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:17:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315175290104050', N'201806141508359155', N'2020110314123396328561', 3, N'Tenant/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:17:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315175292201815', N'201806141508359155', N'2020110314123396328561', 3, N'Tenant/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:17:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315175293736914', N'201806141508359155', N'2020110314123396328561', 3, N'Tenant/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:17:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315183150312981', N'201806141508359155', N'8', 3, N'FilterIP/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T15:18:32.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315183151659795', N'201806141508359155', N'8', 3, N'FilterIP/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:18:32.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315183153249546', N'201806141508359155', N'8', 3, N'FilterIP/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:18:32.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315183154826786', N'201806141508359155', N'8', 3, N'FilterIP/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:18:32.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315183156352951', N'201806141508359155', N'8', 3, N'FilterIP/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:18:32.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315183157889290', N'201806141508359155', N'8', 3, N'FilterIP/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:18:32.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315183159324286', N'201806141508359155', N'8', 3, N'FilterIP/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:18:32.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315194792606013', N'201806141508359155', N'2020110314161523904459', 3, N'TaskManager/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 1, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T15:19:48.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315194793896582', N'201806141508359155', N'2020110314161523904459', 3, N'TaskManager/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 1, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:19:48.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315194795273488', N'201806141508359155', N'2020110314161523904459', 3, N'TaskManager/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 1, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:19:48.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315194797086431', N'201806141508359155', N'2020110314161523904459', 3, N'TaskManager/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 1, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:19:48.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315194798698862', N'201806141508359155', N'2020110314161523904459', 3, N'TaskManager/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 1, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:19:48.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315194799827547', N'201806141508359155', N'2020110314161523904459', 3, N'TaskManager/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 1, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:19:48.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315194800999273', N'201806141508359155', N'2020110314161523904459', 3, N'TaskManager/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 1, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:19:48.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315204129496922', N'201806141508359155', N'2020110314161523904459', 3, N'TaskManager/ChangeStatus', N'启动', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T15:20:41.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315212004586381', N'201806141508359155', N'2020110314165224964779', 3, N'TaskJobsLog/Delete', N'删除', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T15:21:20.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315215315394611', N'201806141508359155', N'2020110314190914102881', 3, N'Sequence/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T15:21:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315215327767703', N'201806141508359155', N'2020110314190914102881', 3, N'Sequence/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:21:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315215328948079', N'201806141508359155', N'2020110314190914102881', 3, N'Sequence/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:21:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315215330182636', N'201806141508359155', N'2020110314190914102881', 3, N'Sequence/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:21:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315215331498258', N'201806141508359155', N'2020110314190914102881', 3, N'Sequence/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:21:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315215332842957', N'201806141508359155', N'2020110314190914102881', 3, N'Sequence/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:21:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315215334061002', N'201806141508359155', N'2020110314190914102881', 3, N'Sequence/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:21:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315222503738750', N'201806141508359155', N'2020110314195207514356', 3, N'SequenceRule/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T15:22:25.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-03T21:03:15.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315222505099926', N'201806141508359155', N'2020110314195207514356', 3, N'SequenceRule/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:22:25.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315222506982025', N'201806141508359155', N'2020110314195207514356', 3, N'SequenceRule/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:22:25.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315222508743670', N'201806141508359155', N'2020110314195207514356', 3, N'SequenceRule/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:22:25.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315222510354377', N'201806141508359155', N'2020110314195207514356', 3, N'SequenceRule/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:22:25.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315222511918449', N'201806141508359155', N'2020110314195207514356', 3, N'SequenceRule/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:22:25.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315222513987026', N'201806141508359155', N'2020110314195207514356', 3, N'SequenceRule/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:22:25.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315233975086228', N'201806141508359155', N'201806141351101389', 3, N'SystemType/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T15:23:40.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315233976493618', N'201806141508359155', N'201806141351101389', 3, N'SystemType/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:23:40.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315233978026300', N'201806141508359155', N'201806141351101389', 3, N'SystemType/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:23:40.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315233979627999', N'201806141508359155', N'201806141351101389', 3, N'SystemType/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:23:40.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315233981246649', N'201806141508359155', N'201806141351101389', 3, N'SystemType/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:23:40.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315233982801956', N'201806141508359155', N'201806141351101389', 3, N'SystemType/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:23:40.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315233984299075', N'201806141508359155', N'201806141351101389', 3, N'SystemType/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:23:40.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315295372466127', N'201806141508359155', N'201806291506346894', 3, N'APP/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T15:29:54.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-03T15:33:01.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315295385481609', N'201806141508359155', N'201806291506346894', 3, N'APP/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:29:54.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315295389238874', N'201806141508359155', N'201806291506346894', 3, N'APP/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:29:54.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315295390992753', N'201806141508359155', N'201806291506346894', 3, N'APP/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:29:54.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315295392674499', N'201806141508359155', N'201806291506346894', 3, N'APP/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:29:54.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315295394456942', N'201806141508359155', N'201806291506346894', 3, N'APP/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:29:54.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315295396508020', N'201806141508359155', N'201806291506346894', 3, N'APP/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:29:54.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315304417212621', N'201806141508359155', N'201806121608404625', 3, N'Menu/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T15:30:44.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315304419294420', N'201806141508359155', N'201806121608404625', 3, N'Menu/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T15:30:44.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315304421057774', N'201806141508359155', N'201806121608404625', 3, N'Menu/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T15:30:44.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315304422692928', N'201806141508359155', N'201806121608404625', 3, N'Menu/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T15:30:44.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315304424338490', N'201806141508359155', N'201806121608404625', 3, N'Menu/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T15:30:44.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315304425833907', N'201806141508359155', N'201806121608404625', 3, N'Menu/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T15:30:44.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315304436069801', N'201806141508359155', N'201806121608404625', 3, N'Menu/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T15:30:44.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315315773909706', N'201806141508359155', N'201806291506346894', 3, N'APP/ResetAppSecret', N'重置AppSecret', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 98, 0, 1, NULL, CAST(N'2021-01-03T15:31:58.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-03T15:32:49.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315323086026943', N'201806141508359155', N'201806291506346894', 3, N'APP/ResetEncodingAESKey', N'重置消息密钥', N'true', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T15:32:31.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010315340190128841', N'201806141508359155', N'7', 3, N'Log/Delete', N'删除', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T15:34:02.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316040698162073', N'201806141508359155', N'4', 3, N'User/ModifyPassword', N'修改密码', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T16:04:07.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316051714119704', N'201806141508359155', N'4', 3, N'User/ResetPassword', N'重置密码', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T16:05:17.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316083259762810', N'201806141508359155', N'6', 3, N'ItemsDetail', N'字典明细', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T16:08:33.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-05T21:40:33.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316100009998659', N'201806141508359155', N'2021010316083259762810', 4, N'ItemsDetail/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T16:10:00.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-05T21:41:25.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316100011385581', N'201806141508359155', N'2021010316083259762810', 4, N'ItemsDetail/Add', N'明细新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T16:10:00.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-05T21:42:21.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316100012707325', N'201806141508359155', N'2021010316083259762810', 4, N'ItemsDetail/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T16:10:00.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-05T21:42:34.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316100014008890', N'201806141508359155', N'2021010316083259762810', 4, N'ItemsDetail/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T16:10:00.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-05T21:42:45.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316100015306916', N'201806141508359155', N'2021010316083259762810', 4, N'ItemsDetail/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T16:10:00.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-05T21:42:58.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316100016609991', N'201806141508359155', N'2021010316083259762810', 4, N'ItemsDetail/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T16:10:00.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-05T21:42:06.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316100018015698', N'201806141508359155', N'2021010316083259762810', 4, N'ItemsDetail/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T16:10:00.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-05T21:41:53.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316453710775564', N'201806141508359155', N'2020042316122987266087', 3, N'UploadFile/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T16:45:37.000' AS DateTime), N'2020031712130656785909', CAST(N'2021-01-03T19:05:56.000' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316453713145150', N'201806141508359155', N'2020042316122987266087', 3, N'UploadFile/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-03T16:45:37.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316453714778755', N'201806141508359155', N'2020042316122987266087', 3, N'UploadFile/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-03T16:45:37.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316453715932821', N'201806141508359155', N'2020042316122987266087', 3, N'UploadFile/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-03T16:45:37.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316453717238579', N'201806141508359155', N'2020042316122987266087', 3, N'UploadFile/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-03T16:45:37.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316453718652652', N'201806141508359155', N'2020042316122987266087', 3, N'UploadFile/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-03T16:45:37.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010316453719872053', N'201806141508359155', N'2020042316122987266087', 3, N'UploadFile/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-03T16:45:37.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010320121395837658', N'201806141508359155', N'3', 3, N'Organize/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-03T20:12:14.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010321015604704406', N'201806141508359155', N'2020110314165224964779', 3, N'TaskJobsLog/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T21:01:56.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010321100441931251', N'201806141508359155', N'2020110314220971767837', 3, N'Log/Delete', N'删除', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T21:10:04.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010321102869902680', N'201806141508359155', N'2020110314224299715445', 3, N'Log/Delete', N'删除', N'', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T21:10:29.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021010321105884295252', N'201806141508359155', N'2020110314231504343408', 3, N'Log/Delete', N'删除', N'true', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 0, 0, 1, NULL, CAST(N'2021-01-03T21:10:59.000' AS DateTime), N'2020031712130656785909', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211084197203605', N'201806141508359155', N'', 1, N'Cms', N'文章管理', N'icon-emaxcitygerenxinxitubiaoji03', N'/cms', N'', NULL, N'C', 0, 0, 1, 0, 0, NULL, NULL, 1299, 0, 1, NULL, CAST(N'2021-01-12T11:08:41.973' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-12T11:15:35.797' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211093383813777', N'201806141508359155', N'2021011211084197203605', 2, N'Articlecategory', N'文章分类', N'icon-xuhao', N'/articlecategory/index', N'articlecategory/index', NULL, N'M', 0, 0, 1, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-12T11:09:33.837' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100576523295', N'201806141508359155', N'2021011211093383813777', 3, N'Articlecategory/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-12T11:10:05.767' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-12T11:11:47.303' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100583237730', N'201806141508359155', N'2021011211093383813777', 3, N'Articlecategory/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-12T11:10:05.833' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100590361637', N'201806141508359155', N'2021011211093383813777', 3, N'Articlecategory/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-12T11:10:05.903' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100595928007', N'201806141508359155', N'2021011211093383813777', 3, N'Articlecategory/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-12T11:10:05.960' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100601001133', N'201806141508359155', N'2021011211093383813777', 3, N'Articlecategory/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-12T11:10:06.010' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100606072467', N'201806141508359155', N'2021011211093383813777', 3, N'Articlecategory/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-12T11:10:06.060' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211100611473440', N'201806141508359155', N'2021011211093383813777', 3, N'Articlecategory/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-12T11:10:06.113' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211111845261274', N'201806141508359155', N'2021011211084197203605', 2, N'Articlenews', N'文章列表', N'icon-emaxcitygerenxinxitubiaoji03', N'/articlenews/index', N'articlenews/index', NULL, N'M', 0, 0, 1, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-12T11:11:18.453' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113260438763', N'201806141508359155', N'2021011211111845261274', 3, N'Articlenews/List', N'列表', N'', N'', N'', NULL, N'F', 0, 0, 0, 0, 0, NULL, NULL, 99, 0, 1, NULL, CAST(N'2021-01-12T11:11:32.603' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-12T11:11:40.467' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113265594642', N'201806141508359155', N'2021011211111845261274', 3, N'Articlenews/Add', N'新增', N'el-icon-plus', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 1, 0, 1, NULL, CAST(N'2021-01-12T11:11:32.657' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113271113293', N'201806141508359155', N'2021011211111845261274', 3, N'Articlenews/Edit', N'修改', N'el-icon-edit', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 2, 0, 1, NULL, CAST(N'2021-01-12T11:11:32.710' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113277633034', N'201806141508359155', N'2021011211111845261274', 3, N'Articlenews/Enable', N'禁用', N'el-icon-video-pause', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 3, 0, 1, NULL, CAST(N'2021-01-12T11:11:32.777' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113282976349', N'201806141508359155', N'2021011211111845261274', 3, N'Articlenews/Enable', N'启用', N'el-icon-video-play', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 4, 0, 1, NULL, CAST(N'2021-01-12T11:11:32.830' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113287838584', N'201806141508359155', N'2021011211111845261274', 3, N'Articlenews/DeleteSoft', N'软删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 5, 0, 1, NULL, CAST(N'2021-01-12T11:11:32.880' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2021011211113293224086', N'201806141508359155', N'2021011211111845261274', 3, N'Articlenews/Delete', N'删除', N'el-icon-delete', N'', N'', NULL, N'F', 0, 0, 1, 0, 0, NULL, NULL, 6, 0, 1, NULL, CAST(N'2021-01-12T11:11:32.933' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'3', N'201806141508359155', N'1', 2, N'Organize', N'机构管理', N'icon-jigou', N'/organize/index', N'organize/index', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, NULL, CAST(N'2018-06-03T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T15:57:36.000' AS DateTime), N'2020031712130656785909', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'4', N'201806141508359155', N'1', 2, N'User', N'用户管理', N'icon-friend', N'/user/index', N'user/index', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 3, 0, 1, NULL, CAST(N'2018-06-03T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:05:49.000' AS DateTime), N'2020031712130656785909', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'5', N'201806141508359155', N'1', 2, N'Role', N'岗位角色', N'icon-jiaose3-01', N'/role/index', N'role/index', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 4, 0, 1, NULL, CAST(N'2018-06-03T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:06:00.000' AS DateTime), N'2020031712130656785909', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'6', N'201806141508359155', N'1', 2, N'Items', N'数据字典', N'icon-zidian', N'/items/index', N'items/index', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 6, 0, 1, NULL, CAST(N'2018-06-03T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:44:52.000' AS DateTime), N'2020031712130656785909', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'7', N'201806141508359155', N'201806120821141288', 2, N'Log/Login', N'登录日志', N'icon-log', N'/syslog/login', N'syslog/login', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 7, 0, 1, NULL, CAST(N'2018-06-03T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-12-26T14:01:54.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'8', N'201806141508359155', N'1', 2, N'FilterIP', N'访问控制', N'icon-adjust', N'/filterip/index', N'filterip/index', N'iframe', N'M', 0, 0, 1, 0, 0, 1, 1, 102, 0, 1, NULL, CAST(N'2018-06-03T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-03T16:46:43.000' AS DateTime), N'2020031712130656785909', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Menu] ([Id], [SystemTypeId], [ParentId], [Layers], [EnCode], [FullName], [Icon], [UrlAddress], [Component], [Target], [MenuType], [IsExpand], [IsFrame], [IsShow], [IsCache], [IsPublic], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'9', N'201806141508359155', N'', 1, N'Tools', N'开发者', N'icon-kaifazhe', N'/tool', NULL, N'expand', N'C', 0, 0, 1, 0, 0, 1, 1, 1003, 0, 1, NULL, CAST(N'2018-06-04T00:00:00.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2021-01-04T11:47:29.000' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2001-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091317274420379133', N'2020101619354744221165', 3, N'', N'创新研究院', N'', N'Department', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 0, N'', CAST(N'2020-09-13T17:27:44.203' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-20T09:19:54.297' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091317280067305041', N'2020101619354744221165', 3, N'', N'营销中心', N'', N'Department', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 1, N'', CAST(N'2020-09-13T17:28:00.673' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-16T19:36:17.637' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101619345715379169', N'2020101619354744221165', 3, N'', N'董事会', N'', N'Department', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 1, N'', CAST(N'2020-10-16T19:34:57.153' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-16T19:36:51.703' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101619351306798960', N'2020101619354744221165', 3, N'', N'行政中心', N'', N'Department', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 1, N'', CAST(N'2020-10-16T19:35:13.067' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-16T19:35:58.997' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101619373694586929', N'2020101619434422287774', 2, N'', N'越邦智能', N'', N'Company', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 1, N'', CAST(N'2020-10-16T19:37:36.947' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-16T19:43:52.227' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101619392209546893', N'2020091317274420379133', 4, N'', N'开源部', N'', N'SubDepartment', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 0, N'', CAST(N'2020-10-16T19:39:22.097' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-20T09:19:54.297' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101619394356374788', N'2020091317274420379133', 4, N'', N'定制研发部', N'', N'SubDepartment', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 0, N'', CAST(N'2020-10-16T19:39:43.563' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-20T09:19:54.297' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101619423736813802', N'2020101619380976351432', 3, N'', N'智能制造', N'', N'WorkGroup', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 1, N'', CAST(N'2020-10-16T19:42:37.367' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-16T19:45:57.390' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101619434422287774', N'', 1, N'', N'越邦集团', N'', N'Group', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 1, N'', CAST(N'2020-10-16T19:43:44.223' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-16T19:44:26.863' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Organize] ([Id], [ParentId], [Layers], [EnCode], [FullName], [ShortName], [CategoryId], [ManagerId], [TelePhone], [MobilePhone], [WeChat], [Fax], [Email], [AreaId], [Address], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101619354744221165', N'2020101619434422287774', 2, N'', N'越邦科技', N'', N'Company', N'', N'', N'', N'', N'', N'', NULL, N'', 1, 1, 99, 0, 0, N'', CAST(N'2020-10-16T19:35:47.443' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-16T19:44:01.163' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [Category], [EnCode], [FullName], [Type], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', N'2020101619392209546893', 1, N'administrators', N'超级管理员', N'1', 0, 0, 1, 0, 1, N'', CAST(N'2016-07-10T00:00:00.000' AS DateTime), NULL, CAST(N'2020-10-19T23:48:43.030' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [Category], [EnCode], [FullName], [Type], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', N'2020101619434422287774', 1, N'system', N'系统管理员', N'1', 0, 0, 2, 0, 1, N'', CAST(N'2016-07-10T00:00:00.000' AS DateTime), NULL, CAST(N'2020-10-14T23:42:22.650' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [Category], [EnCode], [FullName], [Type], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'42C44AC0-27FA-482D-B5E3-8F9B38B80A6A', N'2020101619434422287774', 1, N'configuration', N'系统配置员', N'2', 0, 0, 3, 0, 1, NULL, CAST(N'2016-07-10T00:00:00.000' AS DateTime), NULL, CAST(N'2020-10-14T23:42:22.650' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [Category], [EnCode], [FullName], [Type], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'7A9CF301-FCDF-4BC9-A52B-A7D4FAE2D344', N'2020101619434422287774', 1, N'developer', N'系统开发人员', N'2', 0, 0, 4, 0, 1, NULL, CAST(N'2016-07-10T00:00:00.000' AS DateTime), NULL, CAST(N'2020-10-14T23:42:22.650' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [Category], [EnCode], [FullName], [Type], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'531F7D18-C49F-4F4F-A920-0074FCB52078', N'2020091317280067305041', 1, N'guest', N'访客人员', N'1', 0, 0, 7, 0, 1, N'', CAST(N'2016-07-10T00:00:00.000' AS DateTime), NULL, CAST(N'2020-10-16T20:40:14.470' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [Category], [EnCode], [FullName], [Type], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'AADB479E-9F87-49B1-AE2D-5DA6FECA3F8E', N'2020101619434422287774', 1, N'ArticleEditor', N'文章编辑', N'2', 0, 0, 10, 0, 1, N'文章编辑人员', CAST(N'2016-07-10T00:00:00.000' AS DateTime), NULL, CAST(N'2020-10-19T23:48:43.030' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [Category], [EnCode], [FullName], [Type], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2019091721053342871332', N'2020101619434422287774', 1, N'usermember', N'普通会员', N'1', 0, 0, 99, 0, 1, NULL, CAST(N'2019-09-17T21:05:33.430' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-14T23:42:22.650' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [Category], [EnCode], [FullName], [Type], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101412493109642506', N'2020101619434422287774', 1, N'default', N'默认', N'2', NULL, NULL, 99, 0, 1, N'', CAST(N'2020-10-14T12:49:31.097' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-14T23:42:22.650' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092277401', 0, N'201806141508359155', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092272659', 1, N'2021011211084197203605', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092272026', 1, N'2021011211093383813777', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092281510', 2, N'2021011211100583237730', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092285923', 2, N'2021011211100590361637', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092288416', 2, N'2021011211100595928007', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092289990', 2, N'2021011211100601001133', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092297061', 2, N'2021011211100606072467', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092294824', 2, N'2021011211100611473440', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092291789', 2, N'2021011211100576523295', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092291536', 1, N'2021011211111845261274', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092302006', 2, N'2021011211113265594642', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092302356', 2, N'2021011211113271113293', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092305092', 2, N'2021011211113277633034', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092307521', 2, N'2021011211113282976349', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092315064', 2, N'2021011211113287838584', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092318920', 2, N'2021011211113293224086', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092315439', 2, N'2021011211113260438763', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092311140', 1, N'1', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092325927', 1, N'201905041649159560', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092329199', 2, N'2021010314265872439474', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092321457', 2, N'2021010314280909099314', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092324669', 1, N'3', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092337274', 2, N'2021010314293148672477', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092336044', 2, N'2021010314302276644526', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092338215', 2, N'2021010314473160136431', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092335261', 2, N'2021010314525585211515', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092347116', 2, N'2021010314535010864350', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092345802', 2, N'2021010320121395837658', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092345121', 1, N'4', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092341671', 2, N'2021010315063387468705', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092357486', 2, N'2021010315063389314029', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092351244', 2, N'2021010315063392168016', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092354075', 2, N'2021010315063394048962', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092358637', 2, N'2021010315063395829111', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092359471', 2, N'2021010315063397424616', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092367299', 2, N'2021010315063384478437', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092362753', 2, N'2021010316040698162073', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092367298', 2, N'2021010316051714119704', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092362272', 1, N'5', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092374030', 2, N'2021010315075515608293', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092378637', 2, N'2021010315075517418867', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092371584', 2, N'2021010315075519656824', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092383270', 2, N'2021010315075521218314', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092382890', 2, N'2021010315075522857783', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092384630', 2, N'2021010315075524463436', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092386999', 2, N'2021010315075525983094', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092399087', 2, N'2021010315105223757513', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092391356', 2, N'2021010315100806775237', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092394689', 1, N'6', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092393589', 2, N'2021010315132783165373', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092401602', 2, N'2021010315132784647036', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092403953', 2, N'2021010315132786229265', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092407015', 2, N'2021010315132787977688', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092403806', 2, N'2021010315132789912350', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092415859', 2, N'2021010315132791643307', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092416247', 2, N'2021010315132781838294', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092415679', 2, N'2021010316083259762810', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092425710', 2, N'2021010316100011385581', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092422645', 2, N'2021010316100012707325', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092423400', 2, N'2021010316100014008890', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092424729', 2, N'2021010316100015306916', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092428602', 2, N'2021010316100016609991', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092436051', 2, N'2021010316100018015698', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092432717', 2, N'2021010316100009998659', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092433403', 1, N'2020042316122987266087', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092442523', 2, N'2021010316453713145150', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092443821', 2, N'2021010316453714778755', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092446743', 2, N'2021010316453715932821', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092449622', 2, N'2021010316453717238579', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092456657', 2, N'2021010316453718652652', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092455892', 2, N'2021010316453719872053', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092451001', 2, N'2021010316453710775564', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092453489', 1, N'2020110314123396328561', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092455874', 2, N'2021010315175286366578', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092453660', 2, N'2021010315175287647040', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092469415', 2, N'2021010315175288886376', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092466470', 2, N'2021010315175290104050', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092466167', 2, N'2021010315175292201815', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092468387', 2, N'2021010315175293736914', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092462838', 2, N'2021010315175285146141', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092463573', 1, N'8', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092464295', 2, N'2021010315183150312981', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092472987', 2, N'2021010315183151659795', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092475979', 2, N'2021010315183153249546', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092478015', 2, N'2021010315183154826786', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092473064', 2, N'2021010315183156352951', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092486944', 2, N'2021010315183157889290', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092484978', 2, N'2021010315183159324286', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092486470', 1, N'2020110314142274602075', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092492076', 1, N'2020110314161523904459', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092491114', 2, N'2021010315194792606013', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092499714', 2, N'2021010315204129496922', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092491158', 2, N'2021010315194793896582', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.923' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092506457', 2, N'2021010315194795273488', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092508992', 2, N'2021010315194797086431', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092503081', 2, N'2021010315194798698862', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092507743', 2, N'2021010315194799827547', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092515359', 2, N'2021010315194800999273', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092511347', 1, N'2020110314165224964779', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092515718', 2, N'2021010315212004586381', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092518869', 2, N'2021010321015604704406', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092523650', 1, N'2020110314182794069057', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092527497', 1, N'2020110314190914102881', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092524980', 2, N'2021010315215315394611', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092525346', 2, N'2021010315215327767703', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092531215', 2, N'2021010315215328948079', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092537635', 2, N'2021010315215330182636', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092539940', 2, N'2021010315215331498258', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092544722', 2, N'2021010315215332842957', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092547041', 2, N'2021010315215334061002', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092549130', 1, N'2020110314195207514356', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092547574', 2, N'2021010315222503738750', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092546653', 2, N'2021010315222505099926', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092551241', 2, N'2021010315222506982025', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092554521', 2, N'2021010315222508743670', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092557722', 2, N'2021010315222510354377', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092563530', 2, N'2021010315222511918449', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092567048', 2, N'2021010315222513987026', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092563060', 1, N'201806120821141288', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092563032', 1, N'7', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092571160', 2, N'2021010315340190128841', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092578476', 1, N'2020110314220971767837', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092579714', 2, N'2021010321100441931251', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092574797', 1, N'2020110314224299715445', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092582605', 2, N'2021010321102869902680', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092589260', 1, N'2020110314231504343408', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092589410', 2, N'2021010321105884295252', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092587886', 1, N'9', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092598633', 1, N'201806141351101389', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092595639', 2, N'2021010315233975086228', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092596474', 2, N'2021010315233976493618', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092603052', 2, N'2021010315233978026300', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092608452', 2, N'2021010315233979627999', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092604487', 2, N'2021010315233981246649', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092609043', 2, N'2021010315233982801956', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092601501', 2, N'2021010315233984299075', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092613167', 1, N'201806291506346894', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092614545', 2, N'2021010315295372466127', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092612903', 2, N'2021010315295385481609', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092627235', 2, N'2021010315295389238874', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092627643', 2, N'2021010315295390992753', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092622777', 2, N'2021010315295392674499', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092629765', 2, N'2021010315295394456942', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092632212', 2, N'2021010315295396508020', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092631192', 2, N'2021010315315773909706', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092631039', 2, N'2021010315323086026943', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092641202', 1, N'201806121608404625', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092644205', 2, N'2021010315304419294420', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092643685', 2, N'2021010315304421057774', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092643023', 2, N'2021010315304422692928', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092655719', 2, N'2021010315304424338490', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092652681', 2, N'2021010315304425833907', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092657517', 2, N'2021010315304436069801', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092654162', 2, N'2021010315304417212621', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092661911', 1, N'2020042216381028741066', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140092669670', 1, N'201806040726499682', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.927' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140094409138', 0, N'201806141508359155', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.943' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211140094403929', 0, N'201806141511351940', 1, N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 99, CAST(N'2021-01-12T11:14:00.943' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606225153', 0, N'201806141508359155', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606239557', 1, N'2021011211084197203605', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606231461', 1, N'2021011211093383813777', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606231079', 2, N'2021011211100583237730', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606234807', 2, N'2021011211100590361637', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606236697', 2, N'2021011211100595928007', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606237785', 2, N'2021011211100601001133', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606239333', 2, N'2021011211100606072467', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606231330', 2, N'2021011211100611473440', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606235154', 2, N'2021011211100576523295', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606232008', 1, N'2021011211111845261274', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606238646', 2, N'2021011211113265594642', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606246898', 2, N'2021011211113271113293', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606245527', 2, N'2021011211113277633034', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606249737', 2, N'2021011211113282976349', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606242568', 2, N'2021011211113287838584', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606247851', 2, N'2021011211113293224086', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606245969', 2, N'2021011211113260438763', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606241776', 1, N'1', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606242764', 1, N'201905041649159560', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606244299', 2, N'2021010314265872439474', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606246594', 2, N'2021010314280909099314', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606243882', 1, N'3', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606258883', 2, N'2021010314293148672477', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606253049', 2, N'2021010314302276644526', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606258325', 2, N'2021010314473160136431', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606256794', 2, N'2021010314525585211515', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606257660', 2, N'2021010314535010864350', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606251159', 2, N'2021010320121395837658', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606255144', 1, N'4', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606254037', 2, N'2021010315063387468705', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606255805', 2, N'2021010315063389314029', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606259735', 2, N'2021010315063392168016', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606257239', 2, N'2021010315063394048962', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606251399', 2, N'2021010315063395829111', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606262320', 2, N'2021010315063397424616', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606261498', 2, N'2021010315063384478437', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606264438', 2, N'2021010316040698162073', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606261612', 2, N'2021010316051714119704', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606263028', 1, N'5', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606263388', 2, N'2021010315075515608293', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606267460', 2, N'2021010315075517418867', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606266444', 2, N'2021010315075519656824', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606273634', 2, N'2021010315075521218314', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606279922', 2, N'2021010315075522857783', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606271897', 2, N'2021010315075524463436', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606274161', 2, N'2021010315075525983094', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606271784', 2, N'2021010315105223757513', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606274195', 2, N'2021010315100806775237', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606279009', 1, N'6', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606273263', 2, N'2021010315132783165373', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606272521', 2, N'2021010315132784647036', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606276132', 2, N'2021010315132786229265', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606278648', 2, N'2021010315132787977688', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606275727', 2, N'2021010315132789912350', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606287305', 2, N'2021010315132791643307', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606287925', 2, N'2021010315132781838294', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606288202', 2, N'2021010316083259762810', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606288448', 2, N'2021010316100011385581', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606281409', 2, N'2021010316100012707325', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606284039', 2, N'2021010316100014008890', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606283978', 2, N'2021010316100015306916', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606286282', 2, N'2021010316100016609991', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606287663', 2, N'2021010316100018015698', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606282751', 2, N'2021010316100009998659', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606283980', 1, N'2020042316122987266087', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606288094', 2, N'2021010316453713145150', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606291282', 2, N'2021010316453714778755', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606293746', 2, N'2021010316453715932821', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606297648', 2, N'2021010316453717238579', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606293393', 2, N'2021010316453718652652', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606295408', 2, N'2021010316453719872053', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606292159', 2, N'2021010316453710775564', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606291513', 1, N'2020110314123396328561', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606298247', 2, N'2021010315175286366578', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606293592', 2, N'2021010315175287647040', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606292167', 2, N'2021010315175288886376', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606295844', 2, N'2021010315175290104050', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606307702', 2, N'2021010315175292201815', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606305109', 2, N'2021010315175293736914', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606309578', 2, N'2021010315175285146141', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606309994', 1, N'8', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606302184', 2, N'2021010315183150312981', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606303058', 2, N'2021010315183151659795', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606306826', 2, N'2021010315183153249546', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606307503', 2, N'2021010315183154826786', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606308065', 2, N'2021010315183156352951', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606303022', 2, N'2021010315183157889290', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606304234', 2, N'2021010315183159324286', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606309835', 1, N'2020110314142274602075', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606319627', 1, N'2020110314161523904459', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606318719', 2, N'2021010315194792606013', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606318321', 2, N'2021010315204129496922', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606312443', 2, N'2021010315194793896582', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606311986', 2, N'2021010315194795273488', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606319776', 2, N'2021010315194797086431', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606319044', 2, N'2021010315194798698862', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606313064', 2, N'2021010315194799827547', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606315235', 2, N'2021010315194800999273', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606314261', 1, N'2020110314165224964779', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606315168', 2, N'2021010315212004586381', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606325588', 2, N'2021010321015604704406', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606329326', 1, N'2020110314182794069057', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606321013', 1, N'2020110314190914102881', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606323365', 2, N'2021010315215315394611', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606327038', 2, N'2021010315215327767703', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606323491', 2, N'2021010315215328948079', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606325211', 2, N'2021010315215330182636', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606328665', 2, N'2021010315215331498258', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606328975', 2, N'2021010315215332842957', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606327773', 2, N'2021010315215334061002', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606325809', 1, N'2020110314195207514356', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606337007', 2, N'2021010315222503738750', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606335414', 2, N'2021010315222505099926', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606336624', 2, N'2021010315222506982025', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606334477', 2, N'2021010315222508743670', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606338869', 2, N'2021010315222510354377', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606333315', 2, N'2021010315222511918449', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606336724', 2, N'2021010315222513987026', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606339665', 1, N'201806120821141288', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606333299', 1, N'7', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606339802', 2, N'2021010315340190128841', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606339824', 1, N'2020110314220971767837', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606336220', 2, N'2021010321100441931251', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606348232', 1, N'2020110314224299715445', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606345156', 2, N'2021010321102869902680', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606344028', 1, N'2020110314231504343408', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606347119', 2, N'2021010321105884295252', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606345395', 1, N'9', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606346725', 1, N'201806141351101389', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606347038', 2, N'2021010315233975086228', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606348344', 2, N'2021010315233976493618', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606344825', 2, N'2021010315233978026300', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606344429', 2, N'2021010315233979627999', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606348612', 2, N'2021010315233981246649', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606348419', 2, N'2021010315233982801956', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606356832', 2, N'2021010315233984299075', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606356333', 1, N'201806291506346894', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606355540', 2, N'2021010315295372466127', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606355870', 2, N'2021010315295385481609', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606358369', 2, N'2021010315295389238874', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606359564', 2, N'2021010315295390992753', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606353697', 2, N'2021010315295392674499', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606351443', 2, N'2021010315295394456942', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606353505', 2, N'2021010315295396508020', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606353258', 2, N'2021010315315773909706', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606355658', 2, N'2021010315323086026943', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606368132', 1, N'201806121608404625', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606363482', 2, N'2021010315304419294420', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606365277', 2, N'2021010315304421057774', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606367389', 2, N'2021010315304422692928', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606366543', 2, N'2021010315304424338490', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606362206', 2, N'2021010315304425833907', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606363012', 2, N'2021010315304436069801', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606365267', 2, N'2021010315304417212621', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606367142', 1, N'2020042216381028741066', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606368734', 1, N'201806040726499682', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.063' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [ItemType], [ItemId], [ObjectType], [ObjectId], [SortCode], [CreatorTime], [CreatorUserId]) VALUES (N'2021011211145606941326', 0, N'201806141508359155', 1, N'4B2140D3-E61D-488E-ADF6-FF0EBCBC5D2C', 99, CAST(N'2021-01-12T11:14:56.070' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
GO
INSERT [dbo].[Sys_RoleData] ([Id], [RoleId], [AuthorizeData], [DType]) VALUES (N'2021011211140093705235', N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', N'2020101619434422287774', N'dept')
GO
INSERT [dbo].[Sys_RoleData] ([Id], [RoleId], [AuthorizeData], [DType]) VALUES (N'2021011211140093709400', N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', N'2020101619373694586929', N'dept')
GO
INSERT [dbo].[Sys_RoleData] ([Id], [RoleId], [AuthorizeData], [DType]) VALUES (N'2021011211140093708704', N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', N'2020101619392209546893', N'dept')
GO
INSERT [dbo].[Sys_RoleData] ([Id], [RoleId], [AuthorizeData], [DType]) VALUES (N'2021011211140093709247', N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', N'2020101619394356374788', N'dept')
GO
INSERT [dbo].[Sys_Sequence] ([Id], [SequenceName], [SequenceDelimiter], [SequenceReset], [Step], [CurrentNo], [CurrentCode], [CurrentReset], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622233226492848', N'OutStockSN', N'', N'D', 1, 1, N'O202101120001210112', N'20210112', N'出库单单据号', 1, 0, CAST(N'2020-09-16T22:23:32.267' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-17T11:31:21.573' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Sequence] ([Id], [SequenceName], [SequenceDelimiter], [SequenceReset], [Step], [CurrentNo], [CurrentCode], [CurrentReset], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622241380081119', N'SortingSn', N'-', N'D', 1, 15, N'S-201017-0001', N'20201017', N'分拣单单据号', 1, 0, CAST(N'2020-09-16T22:24:13.800' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-19T10:56:24.117' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Sequence] ([Id], [SequenceName], [SequenceDelimiter], [SequenceReset], [Step], [CurrentNo], [CurrentCode], [CurrentReset], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622245051611735', N'SortingMachineTaskSn', N'', N'D', 1, 3, N'T202009170002', N'20200917', N'分拣机任务单据号', 1, 0, CAST(N'2020-09-16T22:24:50.517' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-16T22:24:50.517' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Sequence] ([Id], [SequenceName], [SequenceDelimiter], [SequenceReset], [Step], [CurrentNo], [CurrentCode], [CurrentReset], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622252678439604', N'PackSn', N'', N'D', 1, 3, N'P0001', N'20200919', N'装箱流水号', 1, 0, CAST(N'2020-09-16T22:25:26.783' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-16T22:25:26.783' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Sequence] ([Id], [SequenceName], [SequenceDelimiter], [SequenceReset], [Step], [CurrentNo], [CurrentCode], [CurrentReset], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091711331621735973', N'DeliveryBillSn', N'', N'D', 1, 0, N'', N'', N'发货单单据号编码', 0, 0, CAST(N'2020-09-17T11:33:16.217' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-10-15T18:26:54.290' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Sequence] ([Id], [SequenceName], [SequenceDelimiter], [SequenceReset], [Step], [CurrentNo], [CurrentCode], [CurrentReset], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'O-20200917-0001', N'OrderSn', N'', N'D', 1, 0, N'', N'', N'', 1, 0, CAST(N'2020-09-17T00:27:04.277' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-17T00:27:04.277' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Sequence] ([Id], [SequenceName], [SequenceDelimiter], [SequenceReset], [Step], [CurrentNo], [CurrentCode], [CurrentReset], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N's-200929-0001', N'test', N'', N'M', 1, 70, N'T20100069', N'20201015', N'定时任务编码', 1, 0, CAST(N'2020-09-29T10:21:04.757' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-10-17T21:31:01.503' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_Sequence] ([Id], [SequenceName], [SequenceDelimiter], [SequenceReset], [Step], [CurrentNo], [CurrentCode], [CurrentReset], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'S-201015-0001', N'1212', N'', N'D', 1, 0, N'', N'', N'', 1, 0, CAST(N'2020-10-15T13:05:44.530' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-10-15T13:05:44.530' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Sequence] ([Id], [SequenceName], [SequenceDelimiter], [SequenceReset], [Step], [CurrentNo], [CurrentCode], [CurrentReset], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'S-201017-0001', N'test2', N'', N'D', 1, 0, N'', N'', N'', 1, 0, CAST(N'2020-10-17T21:31:31.903' AS DateTime), N'2020100517554098226223', NULL, NULL, CAST(N'2020-10-17T21:36:55.110' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622255613938383', N'OutStockSN', 1, N'const', N'O', N'None', 0, N'', N'前缀', 1, 0, CAST(N'2020-09-16T22:25:56.140' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622261403457807', N'OutStockSN', 2, N'date', N'', N'None', 0, N'', N'', 1, 0, CAST(N'2020-09-16T22:26:14.033' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622265137154321', N'OutStockSN', 3, N'number', N'1', N'Left', 4, N'0', N'自动序列号4位', 1, 0, CAST(N'2020-09-16T22:26:51.370' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-17T00:06:17.230' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622273376698812', N'PackSn', 1, N'const', N'P', N'None', 0, N'', N'', 1, 0, CAST(N'2020-09-16T22:27:33.767' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622274676569843', N'PackSn', 2, N'shortdate', N'', N'None', 0, N'', N'', 1, 0, CAST(N'2020-09-16T22:27:46.767' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-17T19:49:14.577' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091622282042827395', N'PackSn', 3, N'number', N'1', N'Left', 4, N'0', N'', 1, 0, CAST(N'2020-09-16T22:28:20.427' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-17T19:48:58.580' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091711512802562446', N'SortingSn', 3, N'number', N'1', N'Left', 4, N'0', N'0', 1, 0, CAST(N'2020-09-17T11:51:28.027' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-19T10:50:24.170' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091711552369965968', N'SortingMachineTaskSn', 2, N'date', N'S', N'None', 0, N'0', N'', 1, 0, CAST(N'2020-09-17T11:55:23.700' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-17T17:08:47.570' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091711554429235678', N'SortingMachineTaskSn', 3, N'number', N'S', N'Left', 4, N'0', N'', 1, 0, CAST(N'2020-09-17T11:55:44.293' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-17T17:08:38.563' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091717090026108202', N'SortingMachineTaskSn', 1, N'const', N'T', N'None', 0, N'0', N'', 1, 0, CAST(N'2020-09-17T17:09:00.260' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020091910495034834434', N'SortingSn', 2, N'shortdate', N'', N'None', 0, N'0', N'', 1, 0, CAST(N'2020-09-19T10:49:50.350' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-10-05T18:19:04.630' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020092910232255018776', N'TaskManager', 3, N'number', N'1', N'Left', 4, N'0', N'', 1, 0, CAST(N'2020-09-29T10:23:22.550' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-09-29T12:13:38.377' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020100518174354988772', N'TaskManager', 1, N'const', N'T', N'None', 0, N'', N'', 1, 0, CAST(N'2020-10-05T18:17:43.550' AS DateTime), N'2020100517554098226223', NULL, NULL, CAST(N'2020-10-10T15:52:39.810' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020100518181058152944', N'TaskManager', 2, N'sydate', N'', N'None', 0, N'', N'', 1, 0, CAST(N'2020-10-05T18:18:10.580' AS DateTime), N'2020100517554098226223', NULL, NULL, CAST(N'2020-10-05T18:18:46.117' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020100518192657955174', N'SortingSn', 1, N'const', N'S', N'None', 0, N'', N'', 1, 0, CAST(N'2020-10-05T18:19:26.580' AS DateTime), N'2020100517554098226223', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_SequenceRule] ([Id], [SequenceName], [RuleOrder], [RuleType], [RuleValue], [PaddingSide], [PaddingWidth], [PaddingChar], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101412483431552588', N'OutStockSN', 3, N'shortdate', N'D', N'None', 0, N'', N'', 1, 0, CAST(N'2020-10-14T12:48:34.317' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Sys_SystemType] ([Id], [EnCode], [FullName], [Url], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806141508359155', N'openauth', N'权限系统', N'http://netvue.ts.yuebon.com', NULL, NULL, 1, 0, 1, N'权限系统是基础系统，包含机构、岗位、角色、用户等功能', CAST(N'2018-06-14T15:08:35.640' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-05T22:32:44.200' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_SystemType] ([Id], [EnCode], [FullName], [Url], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201806141511351940', N'YuebonWcs', N'易拣货', N'http://wcs.ts.yuebon.com', NULL, NULL, 99, 0, 1, N'', CAST(N'2018-06-14T15:11:35.250' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-09-17T21:06:48.387' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_SystemType] ([Id], [EnCode], [FullName], [Url], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201904031316131800', N'CMS', N'CMS系统', N'/cms/Index', NULL, NULL, 99, NULL, 1, N'454545', NULL, NULL, CAST(N'2020-05-16T22:08:24.113' AS DateTime), N'2020031712130656785909', NULL, NULL)
GO
INSERT [dbo].[Sys_SystemType] ([Id], [EnCode], [FullName], [Url], [AllowEdit], [AllowDelete], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'201907011617511504', N'wxapplet', N'微信小程序', NULL, 0, 0, 1, 0, 1, NULL, CAST(N'2019-07-01T16:17:51.823' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-15T17:54:14.010' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_TaskManager] ([Id], [TaskName], [GroupName], [StartTime], [EndTime], [Cron], [IsLocal], [JobCallAddress], [JobCallParams], [LastRunTime], [LastErrorTime], [NextRunTime], [RunCount], [ErrorCount], [Description], [SendMail], [EmailAddress], [Status], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'T20090010', N'测试任务', N'每天任务', CAST(N'2020-10-12T04:00:00.000' AS DateTime), CAST(N'2020-11-24T04:00:00.000' AS DateTime), N'0 0/10 * * * ? ', 1, N'Yuebon.Quartz.Jobs.TestJob', N'1212', CAST(N'2020-10-12T14:00:00.047' AS DateTime), CAST(N'2020-10-05T17:24:00.063' AS DateTime), CAST(N'2020-10-20T09:20:00.000' AS DateTime), 2731, 9, N'这是一个demo', 1, N'cqinwn@qq.com', 0, 1, 0, CAST(N'2020-09-30T14:18:08.067' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'', N'', CAST(N'2020-10-20T09:17:15.893' AS DateTime), N'2020100517554098226223', NULL, N'')
GO
INSERT [dbo].[Sys_TaskManager] ([Id], [TaskName], [GroupName], [StartTime], [EndTime], [Cron], [IsLocal], [JobCallAddress], [JobCallParams], [LastRunTime], [LastErrorTime], [NextRunTime], [RunCount], [ErrorCount], [Description], [SendMail], [EmailAddress], [Status], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'T20090012', N'删除日志', N'日志处理', CAST(N'2020-10-10T04:00:00.000' AS DateTime), CAST(N'2028-10-30T16:00:00.000' AS DateTime), N'0 0 0/3 * * ?', 1, N'Yuebon.Quartz.Jobs.SysLogJob', N'', CAST(N'2020-10-19T12:00:00.447' AS DateTime), CAST(N'2020-10-05T18:00:00.270' AS DateTime), CAST(N'2020-10-20T12:00:00.000' AS DateTime), 176, 4, N'每小时删除日志操作', 1, N'cqinwn@qq.com', 0, 1, 0, CAST(N'2020-09-30T18:45:47.243' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'', N'', CAST(N'2020-10-20T10:57:17.480' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, N'')
GO
INSERT [dbo].[Sys_Tenant] ([Id], [TenantName], [CompanyName], [HostDomain], [LinkMan], [Telphone], [DataSource], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020101613060943279447', N'cqinwn', N'越邦科技', N'cqinwn.v.s.yuebon.com', N'chen', N'1380013800', N'312', N'1212', 1, 0, CAST(N'2020-10-16T13:06:09.433' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, CAST(N'2020-10-16T13:15:22.313' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_Tenant] ([Id], [TenantName], [CompanyName], [HostDomain], [LinkMan], [Telphone], [DataSource], [Description], [EnabledMark], [DeleteMark], [CreatorTime], [CreatorUserId], [CompanyId], [DeptId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020102010064263456315', N'23', N'23', N'234', N'234', N'234', N'234', N'234', 1, 1, CAST(N'2020-10-20T10:06:42.633' AS DateTime), N'2020100517554098226223', N'2020101619434422287774', N'2020091317280067305041', NULL, NULL, CAST(N'2020-10-20T10:12:47.290' AS DateTime), N'2020100517554098226223')
GO
INSERT [dbo].[Sys_UploadFile] ([Id], [FileName], [FilePath], [Description], [FileType], [FileSize], [Extension], [EnabledMark], [SortCode], [DeleteMark], [CreatorUserId], [CreateUserName], [CreatorTime], [Thumbnail], [BelongApp], [BelongAppId]) VALUES (N'2020100517252960569228', N'0beece605a0c7f98cdff10815338341a_1.jpg', N'upload/2020/10/5/2020100517252941069634.jpg', N'', N'.jpg', 31144, N'.jpg', 1, 0, 0, NULL, NULL, CAST(N'2020-10-05T17:25:29.607' AS DateTime), N'upload/2020/10/5//2020100517252941069634_300x300.jpg', N'', N'')
GO
INSERT [dbo].[Sys_UploadFile] ([Id], [FileName], [FilePath], [Description], [FileType], [FileSize], [Extension], [EnabledMark], [SortCode], [DeleteMark], [CreatorUserId], [CreateUserName], [CreatorTime], [Thumbnail], [BelongApp], [BelongAppId]) VALUES (N'2020091720402857808008', N'login-logo.png', N'upload/2020/9/17/2020091720402857303176.png', N'', N'.png', 6368, N'.png', 1, 0, 0, NULL, NULL, CAST(N'2020-09-17T20:40:28.577' AS DateTime), N'upload/2020/9/17//2020091720402857303176_300x300.png', N'', N'')
GO
INSERT [dbo].[Sys_UploadFile] ([Id], [FileName], [FilePath], [Description], [FileType], [FileSize], [Extension], [EnabledMark], [SortCode], [DeleteMark], [CreatorUserId], [CreateUserName], [CreatorTime], [Thumbnail], [BelongApp], [BelongAppId]) VALUES (N'2020100518051314939060', N'2020091720402857303176.png', N'upload/2020/10/5/2020100518051313004355.png', N'', N'.png', 6368, N'.png', 1, 0, 0, NULL, NULL, CAST(N'2020-10-05T18:05:13.150' AS DateTime), N'upload/2020/10/5//2020100518051313004355_300x300.png', N'', N'')
GO
INSERT [dbo].[Sys_UploadFile] ([Id], [FileName], [FilePath], [Description], [FileType], [FileSize], [Extension], [EnabledMark], [SortCode], [DeleteMark], [CreatorUserId], [CreateUserName], [CreatorTime], [Thumbnail], [BelongApp], [BelongAppId]) VALUES (N'2020101013545160354070', N'新建文本文档.txt', N'upload/2020/10/10/2020101013545159944973.txt', N'', N'.txt', 2573, N'.txt', 1, 0, 0, NULL, NULL, CAST(N'2020-10-10T13:54:51.603' AS DateTime), NULL, N'', N'')
GO
INSERT [dbo].[Sys_UploadFile] ([Id], [FileName], [FilePath], [Description], [FileType], [FileSize], [Extension], [EnabledMark], [SortCode], [DeleteMark], [CreatorUserId], [CreateUserName], [CreatorTime], [Thumbnail], [BelongApp], [BelongAppId]) VALUES (N'2020101517112102525545', N'163259lyzldm82zmmm6dqo.jpg', N'upload/2020/10/15/2020101517112056358824.jpg', N'', N'.jpg', 157470, N'.jpg', 1, 0, 0, NULL, NULL, CAST(N'2020-10-15T17:11:21.023' AS DateTime), N'upload/2020/10/15//2020101517112056358824_300x300.jpg', N'', N'')
GO
INSERT [dbo].[Sys_UploadFile] ([Id], [FileName], [FilePath], [Description], [FileType], [FileSize], [Extension], [EnabledMark], [SortCode], [DeleteMark], [CreatorUserId], [CreateUserName], [CreatorTime], [Thumbnail], [BelongApp], [BelongAppId]) VALUES (N'2020101615291367647139', N'抢购详情.png', N'upload/2020/10/16/2020101615291360013866.png', N'', N'.png', 1092032, N'.png', 1, 0, 0, NULL, NULL, CAST(N'2020-10-16T15:29:13.677' AS DateTime), N'upload/2020/10/16//2020101615291360013866_300x300.png', N'', N'')
GO
INSERT [dbo].[Sys_UploadFile] ([Id], [FileName], [FilePath], [Description], [FileType], [FileSize], [Extension], [EnabledMark], [SortCode], [DeleteMark], [CreatorUserId], [CreateUserName], [CreatorTime], [Thumbnail], [BelongApp], [BelongAppId]) VALUES (N'2020101615294915199353', N'我的.png', N'upload/2020/10/16/2020101615294910394631.png', N'', N'.png', 620797, N'.png', 1, 0, 0, NULL, NULL, CAST(N'2020-10-16T15:29:49.153' AS DateTime), N'upload/2020/10/16//2020101615294910394631_300x300.png', N'', N'')
GO
INSERT [dbo].[Sys_UploadFile] ([Id], [FileName], [FilePath], [Description], [FileType], [FileSize], [Extension], [EnabledMark], [SortCode], [DeleteMark], [CreatorUserId], [CreateUserName], [CreatorTime], [Thumbnail], [BelongApp], [BelongAppId]) VALUES (N'2020101615300857727179', N'酒.png', N'upload/2020/10/16/2020101615300855954150.png', N'', N'.png', 12721, N'.png', 1, 0, 0, NULL, NULL, CAST(N'2020-10-16T15:30:08.577' AS DateTime), N'upload/2020/10/16//2020101615300855954150_300x300.png', N'', N'')
GO
INSERT [dbo].[Sys_UploadFile] ([Id], [FileName], [FilePath], [Description], [FileType], [FileSize], [Extension], [EnabledMark], [SortCode], [DeleteMark], [CreatorUserId], [CreateUserName], [CreatorTime], [Thumbnail], [BelongApp], [BelongAppId]) VALUES (N'2020101716162143958235', N'login-logo.png', N'upload/2020/10/17/2020101716162142257985.png', N'', N'.png', 6368, N'.png', 1, 0, 0, NULL, NULL, CAST(N'2020-10-17T16:16:21.440' AS DateTime), N'upload/2020/10/17//2020101716162142257985_300x300.png', N'', N'')
GO
INSERT [dbo].[Sys_User] ([Id], [Account], [RealName], [NickName], [HeadIcon], [Gender], [Birthday], [MobilePhone], [Email], [WeChat], [ManagerId], [SecurityLevel], [Signature], [Country], [Province], [City], [District], [OrganizeId], [DepartmentId], [RoleId], [DutyId], [IsAdministrator], [IsMember], [MemberGradeId], [ReferralUserId], [UnionId], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'admin', N'超级管理员', N'超级管理员', NULL, 1, NULL, N'13800138000', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2020101619434422287774', N'2020101619392209546893', N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', NULL, 1, NULL, NULL, NULL, NULL, 99, 0, 1, N'', CAST(N'2020-05-12T11:43:36.750' AS DateTime), N'2020050714314578446583', CAST(N'2020-12-30T13:20:17.707' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_User] ([Id], [Account], [RealName], [NickName], [HeadIcon], [Gender], [Birthday], [MobilePhone], [Email], [WeChat], [ManagerId], [SecurityLevel], [Signature], [Country], [Province], [City], [District], [OrganizeId], [DepartmentId], [RoleId], [DutyId], [IsAdministrator], [IsMember], [MemberGradeId], [ReferralUserId], [UnionId], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020050714314578446583', N'wcs', N'wcs测试用户', N'wcs测试用户', NULL, 1, NULL, N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2020101619434422287774', N'2020101619423736813802', N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', NULL, 1, NULL, NULL, NULL, NULL, 99, 0, 1, N'', CAST(N'2020-05-07T14:31:45.783' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-16T20:29:22.523' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_User] ([Id], [Account], [RealName], [NickName], [HeadIcon], [Gender], [Birthday], [MobilePhone], [Email], [WeChat], [ManagerId], [SecurityLevel], [Signature], [Country], [Province], [City], [District], [OrganizeId], [DepartmentId], [RoleId], [DutyId], [IsAdministrator], [IsMember], [MemberGradeId], [ReferralUserId], [UnionId], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020050915115104169149', N'autoer', N'机器人', N'机器人', NULL, 1, NULL, N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2020101619434422287774', N'2020091317274420379133', N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', NULL, 1, NULL, NULL, NULL, NULL, 99, 0, 1, N'用于系统自动化处理的账号', CAST(N'2020-05-09T15:11:51.043' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-10-16T20:29:17.377' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
GO
INSERT [dbo].[Sys_User] ([Id], [Account], [RealName], [NickName], [HeadIcon], [Gender], [Birthday], [MobilePhone], [Email], [WeChat], [ManagerId], [SecurityLevel], [Signature], [Country], [Province], [City], [District], [OrganizeId], [DepartmentId], [RoleId], [DutyId], [IsAdministrator], [IsMember], [MemberGradeId], [ReferralUserId], [UnionId], [SortCode], [DeleteMark], [EnabledMark], [Description], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId]) VALUES (N'2020100517554098226223', N'test', N'测试账号', N'测试账号', NULL, 1, NULL, N'18708908877', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2020101619434422287774', N'2020091317280067305041', N'F0A2B36F-35A7-4660-B46C-D4AB796591EB', NULL, 1, NULL, NULL, NULL, NULL, 99, 0, 1, N'', CAST(N'2020-10-05T17:55:40.983' AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(N'2020-12-29T15:59:29.017' AS DateTime), N'2020100517554098226223', NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', N'5039b1d6a774b864af4a013d9c905c06', N'9eeb98044bbedd1a', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2020-10-06T00:00:00.000' AS DateTime), CAST(N'2020-10-06T15:05:27.283' AS DateTime), CAST(N'2021-01-12T11:16:15.557' AS DateTime), CAST(N'2021-01-12T11:16:15.557' AS DateTime), CAST(N'2020-10-12T09:26:34.180' AS DateTime), 0, 161, 1, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020031712130659893499', N'2020031712130656785909', N'7e29edb38e8eec489ec169452247e67c', N'559b6347ac7b300d', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020041711444391798929', N'2020041711444387653354', N'ffd015721f2df3dfaa91884645f69589', N'5c767588a7e9474c', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020041918484483875127', N'2020041918484479709774', N'b76afb92338c02c4c69a3180f3d390b7', N'1ac15cdd47fdbdb1', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020050714314582596483', N'2020050714314578446583', N'ac88cc35d65619d07e6868b555a74d8d', N'75aa72236efa4b44', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2020-10-12T09:29:18.060' AS DateTime), CAST(N'2020-10-12T13:46:50.753' AS DateTime), CAST(N'2020-10-12T13:46:50.753' AS DateTime), NULL, 0, 4, 1, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020050915115105156659', N'2020050915115104169149', N'7c6345b3c4d627f758232294875c9b24', N'b29c801634732471', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020051211433675926751', N'2020051211433674936555', N'8ba7db369731a86b6cbe4af2016f693e', N'ff96e6347a0eabea', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020051415044715016490', N'2020051415044714091504', N'8be532b339676be1d240795cc70e25d3', N'22b90d18792bb69d', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, CAST(N'2020-10-06T14:50:47.107' AS DateTime), 0, 1, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020062412372188409932', N'2020062412372187315896', N'3acc7019cc62326fc4620f54282a25c7', N'8f6136efddb347cc', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020062622485115721608', N'2020062622485115012955', N'09ba5f17f71c410644dae4eade1bcc4a', N'2a1e8158f8aeac92', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020100517554100798258', N'2020100517554098226223', N'317d0894ccaba9295c8496a3ab507de5', N'1a1992493e9e7205', CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2100-12-31T23:59:59.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2017-01-01T00:00:00.000' AS DateTime), CAST(N'2020-10-06T17:19:58.003' AS DateTime), CAST(N'2020-12-30T11:49:53.880' AS DateTime), CAST(N'2020-12-30T11:49:53.880' AS DateTime), CAST(N'2020-12-29T10:17:32.720' AS DateTime), 0, 407, 1, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020123011083107631739', N'2020123011083102191165', N'4fc49d37c96ef5edfb22bd425c6c233b', N'ec4b25f3d7482063', CAST(N'2020-12-30T11:08:31.073' AS DateTime), CAST(N'2120-12-30T11:08:31.073' AS DateTime), CAST(N'2020-12-30T11:08:31.073' AS DateTime), CAST(N'2020-12-30T11:08:31.073' AS DateTime), CAST(N'2020-12-30T11:08:56.127' AS DateTime), CAST(N'2020-12-30T11:08:56.127' AS DateTime), CAST(N'2020-12-30T11:08:56.127' AS DateTime), CAST(N'2020-12-30T11:08:40.140' AS DateTime), 0, 1, 1, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [UserPassword], [UserSecretkey], [AllowStartTime], [AllowEndTime], [LockStartDate], [LockEndDate], [FirstVisitTime], [PreviousVisitTime], [LastVisitTime], [ChangePasswordDate], [MultiUserLogin], [LogOnCount], [UserOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme]) VALUES (N'2020122916175658629172', N'2020122916175658252204', N'dd28e689fdcc73bcf838f816dde0c34e', N'3d20cb5f8ee9774a', CAST(N'2020-12-29T16:17:56.583' AS DateTime), CAST(N'2120-12-29T16:17:56.583' AS DateTime), CAST(N'2020-12-29T16:17:56.583' AS DateTime), CAST(N'2020-12-29T16:17:56.583' AS DateTime), NULL, NULL, NULL, CAST(N'2020-12-29T16:17:56.583' AS DateTime), 0, 0, NULL, NULL, NULL, 0, NULL, NULL)
GO
