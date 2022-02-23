-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: localhost    Database: ybnf
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cms_articlecategory`
--

DROP TABLE IF EXISTS `cms_articlecategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cms_articlecategory` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `Title` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '标题',
  `ParentId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '父级Id',
  `ClassPath` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '全路径',
  `ClassLayer` int DEFAULT NULL COMMENT '层级',
  `SortCode` int DEFAULT NULL COMMENT '排序',
  `LinkUrl` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '外链地址',
  `ImgUrl` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '主图图片地址',
  `SeoTitle` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'SEO标题',
  `SeoKeywords` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'SEO关键词',
  `SeoDescription` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'SEO描述',
  `IsHot` tinyint(1) DEFAULT NULL COMMENT '是否热门',
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci COMMENT '描述',
  `CompanyId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人公司ID',
  `DeptId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人部门ID',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) DEFAULT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='文章分类';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cms_articlenews`
--

DROP TABLE IF EXISTS `cms_articlenews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cms_articlenews` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `CategoryId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '文章分类ID',
  `CategoryName` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '分类名称',
  `Title` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '文章标题',
  `SubTitle` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '副标题',
  `LinkUrl` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '外链',
  `ImgUrl` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '主图图片地址',
  `SeoTitle` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'SEO标题',
  `SeoKeywords` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'SEO关键词',
  `SeoDescription` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'SEO描述',
  `Tags` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '标签，多个用逗号隔开',
  `Zhaiyao` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '摘要',
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci COMMENT '详情',
  `SortCode` int DEFAULT NULL COMMENT '排序',
  `IsMsg` tinyint(1) DEFAULT NULL COMMENT '开启评论',
  `IsTop` tinyint(1) DEFAULT NULL COMMENT '是否置顶，默认不置顶',
  `IsRed` tinyint(1) DEFAULT NULL COMMENT '是否推荐',
  `IsHot` tinyint(1) DEFAULT NULL COMMENT '是否热门，默认否',
  `IsSys` tinyint(1) DEFAULT NULL COMMENT '是否是系统预置文章，不可删除',
  `IsNew` tinyint(1) DEFAULT NULL COMMENT '是否推荐到最新',
  `IsSlide` tinyint(1) DEFAULT NULL COMMENT '是否推荐到幻灯',
  `Click` int DEFAULT NULL COMMENT '点击量',
  `LikeCount` int DEFAULT NULL COMMENT '喜欢量',
  `TotalBrowse` int DEFAULT NULL COMMENT '浏览量',
  `Source` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '来源',
  `Author` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '作者',
  `EnabledMark` tinyint(1) DEFAULT NULL COMMENT '是否发布',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '逻辑删除标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `CompanyId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人公司ID',
  `DeptId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人部门ID',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='文章，通知公告';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_app`
--

DROP TABLE IF EXISTS `sys_app`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_app` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `AppId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '应用Id',
  `AppSecret` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '应用密钥',
  `EncodingAESKey` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '消息加解密密钥',
  `RequestUrl` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '授权请求地址url',
  `Token` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'Token令牌',
  `IsOpenAEKey` tinyint(1) NOT NULL COMMENT '是否开启消息加解密',
  `Description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `CompanyId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户组织主键',
  `DeptId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户部门主键',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='系统应用表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_area`
--

DROP TABLE IF EXISTS `sys_area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_area` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `ParentId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '父级',
  `Layers` int DEFAULT NULL COMMENT '层次',
  `EnCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '编码',
  `FullName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '名称',
  `SimpleSpelling` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '简拼',
  `FullIdPath` varchar(600) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '父级路径',
  `IsLast` tinyint(1) NOT NULL COMMENT '是否是最后一级',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_dbbackup`
--

DROP TABLE IF EXISTS `sys_dbbackup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_dbbackup` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `BackupType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '备份类型',
  `DbName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '数据库名称',
  `FileName` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '文件名称',
  `FileSize` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '文件大小',
  `FilePath` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '文件路径',
  `BackupTime` datetime(6) DEFAULT NULL COMMENT '备份时间',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='数据库备份记录';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_filterip`
--

DROP TABLE IF EXISTS `sys_filterip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_filterip` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `FilterType` tinyint(1) DEFAULT NULL COMMENT '类型，0黑名单，1白名单',
  `StartIP` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '开始IP',
  `EndIP` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '结束IP',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='可访问系统IP地址黑白名单';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_items`
--

DROP TABLE IF EXISTS `sys_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_items` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `ParentId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '父级ID',
  `EnCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
  `FullName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `IsTree` tinyint(1) NOT NULL COMMENT '是否是树型',
  `Layers` int DEFAULT NULL COMMENT '层次',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='数据字典选项主表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_itemsdetail`
--

DROP TABLE IF EXISTS `sys_itemsdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_itemsdetail` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `ItemId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主表主键',
  `ParentId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '父级',
  `ItemCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
  `ItemName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `SimpleSpelling` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '简拼',
  `IsDefault` tinyint(1) DEFAULT NULL COMMENT '默认',
  `Layers` int DEFAULT NULL COMMENT '层次',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '主表主键',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='数据字典选项明细表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_log`
--

DROP TABLE IF EXISTS `sys_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_log` (
  `Id` bigint NOT NULL AUTO_INCREMENT COMMENT '主键',
  `Date` datetime(6) NOT NULL COMMENT '日期',
  `Account` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '用户名',
  `NickName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '姓名',
  `OrganizeId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '组织主键',
  `Type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '类型',
  `IPAddress` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'IP地址',
  `IPAddressName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'IP所在城市',
  `ModuleId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '系统模块Id',
  `ModuleName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '系统模块',
  `Result` tinyint(1) DEFAULT NULL COMMENT '结果',
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci COMMENT '描述',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8314148398694470 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='系统日志';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_membermessagebox`
--

DROP TABLE IF EXISTS `sys_membermessagebox`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_membermessagebox` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `ContentId` bigint DEFAULT NULL,
  `MsgContent` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Sernder` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Accepter` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsRead` tinyint(1) NOT NULL,
  `ReadDate` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_membersubscribemsg`
--

DROP TABLE IF EXISTS `sys_membersubscribemsg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_membersubscribemsg` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `SubscribeUserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SubscribeType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MessageTemplateId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SubscribeTemplateId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SubscribeStatus` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_menu`
--

DROP TABLE IF EXISTS `sys_menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_menu` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `SystemTypeId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '所属系统主键',
  `ParentId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '父级',
  `Layers` int DEFAULT NULL COMMENT '层次',
  `EnCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
  `FullName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `Icon` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '图标',
  `UrlAddress` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '路由',
  `Target` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '目标打开方式',
  `MenuType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '菜单类型（C目录 M菜单 F按钮）',
  `Component` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '组件路径',
  `ActiveMenu` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '设置当前选中菜单，用于新增、编辑、查看操作为单独的路由时指定选中菜单路由，同时设置为隐藏时才有效',
  `IsExpand` tinyint(1) NOT NULL COMMENT '展开',
  `IsShow` tinyint(1) DEFAULT NULL COMMENT '是否显示',
  `IsFrame` tinyint(1) DEFAULT NULL COMMENT '是否外链',
  `IsCache` tinyint(1) DEFAULT NULL COMMENT '设置或获取是否缓存',
  `IsPublic` tinyint(1) DEFAULT NULL COMMENT '公共',
  `AllowEdit` tinyint(1) DEFAULT NULL COMMENT '允许编辑',
  `AllowDelete` tinyint(1) DEFAULT NULL COMMENT '允许删除',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='系统菜单';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_messagemailbox`
--

DROP TABLE IF EXISTS `sys_messagemailbox`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_messagemailbox` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsMsgRemind` tinyint(1) DEFAULT NULL,
  `IsSend` tinyint(1) DEFAULT NULL,
  `SendDate` datetime(6) NOT NULL,
  `IsCompel` tinyint(1) DEFAULT NULL,
  `DeleteMark` tinyint(1) DEFAULT NULL,
  `CreatorTime` datetime(6) DEFAULT NULL,
  `CreatorUserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CompanyId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeptId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `LastModifyTime` datetime(6) DEFAULT NULL,
  `LastModifyUserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeleteTime` datetime(6) DEFAULT NULL,
  `DeleteUserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_messagetemplates`
--

DROP TABLE IF EXISTS `sys_messagetemplates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_messagetemplates` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `MessageType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SendEmail` tinyint(1) NOT NULL,
  `SendSMS` tinyint(1) NOT NULL,
  `SendInnerMessage` tinyint(1) NOT NULL,
  `SendWeixin` tinyint(1) NOT NULL,
  `WeixinTemplateId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `TagDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `EmailSubject` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `EmailBody` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `InnerMessageSubject` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `InnerMessageBody` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SMSBody` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `WeiXinTemplateNo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `WeiXinName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UseInWxApplet` tinyint(1) NOT NULL,
  `WxAppletTemplateId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AppletTemplateNo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AppletTemplateName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `WxAppletSubscribeTemplateId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `WxAppletSubscribeTemplateNo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `WxAppletSubscribeTemplateName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SMSTemplateCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SMSTemplateContent` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `WxO2OAppletTemplateId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UseInO2OApplet` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_organize`
--

DROP TABLE IF EXISTS `sys_organize`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_organize` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `ParentId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '父级',
  `Layers` int NOT NULL COMMENT '层次',
  `EnCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '编码',
  `FullName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `ShortName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '简称',
  `CategoryId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '分类',
  `ManagerId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '负责人',
  `TelePhone` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '电话',
  `MobilePhone` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '手机',
  `WeChat` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '微信',
  `Fax` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '传真',
  `Email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '邮箱',
  `AreaId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '归属区域',
  `Address` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '联系地址',
  `AllowEdit` tinyint(1) DEFAULT NULL COMMENT '允许编辑',
  `AllowDelete` tinyint(1) DEFAULT NULL COMMENT '允许删除',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='组织机构表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_role`
--

DROP TABLE IF EXISTS `sys_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_role` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `OrganizeId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '组织主键',
  `Category` int NOT NULL COMMENT '分类:1-角色2-岗位',
  `EnCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '角色编码',
  `FullName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `Type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '类型',
  `AllowEdit` tinyint(1) DEFAULT NULL COMMENT '允许编辑',
  `AllowDelete` tinyint(1) DEFAULT NULL COMMENT '允许删除',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='角色表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_roleauthorize`
--

DROP TABLE IF EXISTS `sys_roleauthorize`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_roleauthorize` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `ItemType` int NOT NULL COMMENT '项目类型功能标识 0-子系统 1-标识菜单/模块，2标识按钮功能',
  `ItemId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '项目主键',
  `ObjectType` int DEFAULT NULL COMMENT '对象分类/类型1-角色，2-部门，3-用户',
  `ObjectId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '对象主键，对象分类/类型为角色时就是角色ID，部门就是部门ID，用户就是用户ID',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='角色权限表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_roledata`
--

DROP TABLE IF EXISTS `sys_roledata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_roledata` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `RoleId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '角色ID',
  `DType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '类型，company-公司，dept-部门，person-个人',
  `AuthorizeData` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '数据数据，部门ID或个人ID',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='角色的数据权限';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_sequence`
--

DROP TABLE IF EXISTS `sys_sequence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_sequence` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `SequenceName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `SequenceDelimiter` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '分隔符',
  `SequenceReset` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '序号重置规则',
  `Step` int NOT NULL COMMENT '步长',
  `CurrentNo` int NOT NULL COMMENT '当前值',
  `CurrentCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '当前编码',
  `CurrentReset` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '当前重置依赖，即最后一次获取编码的日期',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `CompanyId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人公司ID',
  `DeptId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人部门ID',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) DEFAULT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='单据编码';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_sequencerule`
--

DROP TABLE IF EXISTS `sys_sequencerule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_sequencerule` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `SequenceName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '编码规则名称',
  `RuleOrder` int NOT NULL COMMENT '规则排序',
  `RuleType` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '取规则类别，timestamp、const、bumber',
  `RuleValue` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '规则参数，如YYMMDD',
  `PaddingSide` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '补齐方向，left或right',
  `PaddingWidth` int NOT NULL COMMENT '补齐宽度',
  `PaddingChar` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '填充字符',
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '描述',
  `CompanyId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人公司ID',
  `DeptId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人部门ID',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='序号编码规则表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_systemtype`
--

DROP TABLE IF EXISTS `sys_systemtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_systemtype` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `FullName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '系统名称',
  `EnCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '编码',
  `Url` varchar(254) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '链接',
  `AllowEdit` tinyint(1) DEFAULT NULL COMMENT '允许编辑',
  `AllowDelete` tinyint(1) DEFAULT NULL COMMENT '允许删除',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='子系统';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_taskjobslog`
--

DROP TABLE IF EXISTS `sys_taskjobslog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_taskjobslog` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `TaskId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `TaskName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `JobAction` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Status` tinyint(1) NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatorTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_taskmanager`
--

DROP TABLE IF EXISTS `sys_taskmanager`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_taskmanager` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `TaskName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `GroupName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `EndTime` datetime(6) DEFAULT NULL,
  `StartTime` datetime(6) DEFAULT NULL,
  `Cron` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsLocal` tinyint(1) NOT NULL,
  `JobCallAddress` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `JobCallParams` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `LastRunTime` datetime(6) DEFAULT NULL,
  `LastErrorTime` datetime(6) DEFAULT NULL,
  `NextRunTime` datetime(6) DEFAULT NULL,
  `RunCount` int NOT NULL,
  `ErrorCount` int NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Status` int NOT NULL,
  `SendMail` int NOT NULL,
  `EmailAddress` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `EnabledMark` tinyint(1) DEFAULT NULL,
  `DeleteMark` tinyint(1) DEFAULT NULL,
  `CreatorTime` datetime(6) DEFAULT NULL,
  `CreatorUserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CompanyId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeptId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `LastModifyTime` datetime(6) DEFAULT NULL,
  `LastModifyUserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeleteTime` datetime(6) DEFAULT NULL,
  `DeleteUserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_tenant`
--

DROP TABLE IF EXISTS `sys_tenant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_tenant` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `TenantName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '租户账号',
  `CompanyName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '公司名称',
  `HostDomain` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '访问域名',
  `Email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '租户Email',
  `LinkMan` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '联系人',
  `Telphone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '联系电话',
  `DataSource` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '数据源，分库使用',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '租户介绍',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '是否可用',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '逻辑删除标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `CompanyId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人公司ID',
  `DeptId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人部门ID',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='租户信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_tenantlogon`
--

DROP TABLE IF EXISTS `sys_tenantlogon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_tenantlogon` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `TenantId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '租户ID',
  `TenantPassword` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '租户ID',
  `TenantSecretkey` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '租户ID',
  `AllowStartTime` datetime(6) DEFAULT NULL COMMENT '允许登录时间开始',
  `AllowEndTime` datetime(6) DEFAULT NULL COMMENT '允许登录时间结束',
  `LockStartDate` datetime(6) DEFAULT NULL COMMENT '暂停用户开始日期',
  `LockEndDate` datetime(6) DEFAULT NULL COMMENT '暂停用户结束日期',
  `FirstVisitTime` datetime(6) DEFAULT NULL COMMENT '第一次访问时间',
  `PreviousVisitTime` datetime(6) DEFAULT NULL COMMENT '上一次访问时间',
  `LastVisitTime` datetime(6) DEFAULT NULL COMMENT '最后访问时间',
  `ChangePasswordDate` datetime(6) DEFAULT NULL COMMENT '最后修改密码日期',
  `MultiUserLogin` tinyint(1) DEFAULT NULL COMMENT '允许同时有多用户登录',
  `LogOnCount` int DEFAULT NULL COMMENT '登录次数',
  `TenantOnLine` tinyint(1) DEFAULT NULL COMMENT '在线状态',
  `Question` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '密码提示问题',
  `AnswerQuestion` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '密码提示答案',
  `CheckIPAddress` tinyint(1) DEFAULT NULL COMMENT '是否访问限制',
  `Language` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '软件系统语言',
  `Theme` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '软件系统样式',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='租户信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_uploadfile`
--

DROP TABLE IF EXISTS `sys_uploadfile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_uploadfile` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `FileName` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '文件名称',
  `FilePath` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '文件路径',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `FileType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '文件类型',
  `FileSize` int NOT NULL COMMENT '文件大小',
  `Extension` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '扩展名称',
  `SortCode` int NOT NULL COMMENT '排序',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) DEFAULT NULL COMMENT '有效标志',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '上传时间',
  `Thumbnail` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '缩略图',
  `BelongApp` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '所属应用',
  `BelongAppId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '所属应用ID',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='用户上传附件管理';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_user`
--

DROP TABLE IF EXISTS `sys_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_user` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `Account` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '账户',
  `RealName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '姓名',
  `NickName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '呢称',
  `HeadIcon` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '头像',
  `Gender` int DEFAULT NULL COMMENT '性别,1=男，0=未知，2=女',
  `Birthday` datetime(6) DEFAULT NULL COMMENT '生日',
  `MobilePhone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '手机',
  `Email` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '邮箱',
  `WeChat` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '微信',
  `Country` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '国家',
  `Province` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '省份',
  `City` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '城市',
  `District` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '地区',
  `ManagerId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '主管主键',
  `SecurityLevel` int DEFAULT NULL COMMENT '安全级别',
  `Signature` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '个性签名',
  `OrganizeId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '组织主键',
  `DepartmentId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '部门主键',
  `RoleId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '角色主键',
  `DutyId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '岗位主键',
  `IsAdministrator` tinyint(1) DEFAULT NULL COMMENT '是否管理员',
  `IsMember` tinyint(1) DEFAULT NULL COMMENT '是否会员',
  `MemberGradeId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '头像',
  `ReferralUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '上级推广员',
  `UnionId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '用户在微信开放平台的唯一标识符',
  `SortCode` int DEFAULT NULL COMMENT '排序码',
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '描述',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='用户表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_userextend`
--

DROP TABLE IF EXISTS `sys_userextend`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_userextend` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `UserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '账户ID',
  `CardContent` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '名片',
  `Telphone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '手机',
  `Address` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '地址',
  `CompanyName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '公司名称',
  `PositionTitle` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '职位',
  `WeChatQrCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '微信二维码',
  `IndustryId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '地区',
  `OpenType` int NOT NULL COMMENT '公开情况',
  `IsOtherShare` tinyint(1) NOT NULL COMMENT 'IsOtherShare',
  `ShareTitle` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '分享标题',
  `WebUrl` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '主页',
  `CompanyDesc` varchar(1500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '公司简介',
  `CardTheme` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '主题',
  `VipGrade` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'VIP级别',
  `IsAuthentication` tinyint(1) NOT NULL COMMENT '是否认证',
  `AuthenticationType` int NOT NULL COMMENT '认证类型',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `EnabledMark` tinyint(1) NOT NULL COMMENT '有效标志',
  `CreatorTime` datetime(6) DEFAULT NULL COMMENT '创建日期',
  `CreatorUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建用户主键',
  `CompanyId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人公司ID',
  `DeptId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '创建人部门ID',
  `LastModifyTime` datetime(6) DEFAULT NULL COMMENT '最后修改时间',
  `LastModifyUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '最后修改用户',
  `DeleteTime` datetime(6) DEFAULT NULL COMMENT '删除时间',
  `DeleteUserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='用户扩展信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_userlogon`
--

DROP TABLE IF EXISTS `sys_userlogon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_userlogon` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `UserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户主键',
  `UserPassword` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '用户密码',
  `UserSecretkey` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '用户秘钥',
  `AllowStartTime` datetime(6) DEFAULT NULL COMMENT '允许登录时间开始',
  `AllowEndTime` datetime(6) DEFAULT NULL COMMENT '允许登录时间结束',
  `LockStartDate` datetime(6) DEFAULT NULL COMMENT '暂停用户开始日期',
  `LockEndDate` datetime(6) DEFAULT NULL COMMENT '暂停用户结束日期',
  `FirstVisitTime` datetime(6) DEFAULT NULL COMMENT '第一次访问时间',
  `PreviousVisitTime` datetime(6) DEFAULT NULL COMMENT '上一次访问时间',
  `LastVisitTime` datetime(6) DEFAULT NULL COMMENT '最后访问时间',
  `ChangePasswordDate` datetime(6) DEFAULT NULL COMMENT '最后修改密码日期',
  `MultiUserLogin` tinyint(1) DEFAULT NULL COMMENT '允许同时有多用户登录',
  `LogOnCount` int DEFAULT NULL COMMENT '登录次数',
  `UserOnLine` tinyint(1) DEFAULT NULL COMMENT '在线状态',
  `Question` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '密码提示问题',
  `AnswerQuestion` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT '密码提示答案',
  `CheckIPAddress` tinyint(1) DEFAULT NULL COMMENT '是否访问限制',
  `Language` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '系统语言',
  `Theme` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '系统样式',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='用户登录信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sys_useropenids`
--

DROP TABLE IF EXISTS `sys_useropenids`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_useropenids` (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '主键',
  `UserId` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户编号',
  `OpenIdType` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '第三方类型',
  `OpenId` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT 'OpenId',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='第三方登录与用户绑定表';
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-02-23 14:38:15
