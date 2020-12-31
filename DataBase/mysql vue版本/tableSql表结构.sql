/*
 Navicat Premium Data Transfer

 Source Server         : 本机
 Source Server Type    : MySQL
 Source Server Version : 80017
 Source Host           : localhost:3306
 Source Schema         : ybnf

 Target Server Type    : MySQL
 Target Server Version : 80017
 File Encoding         : 65001

 Date: 30/12/2020 20:54:11
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sys_app
-- ----------------------------
DROP TABLE IF EXISTS `sys_app`;
CREATE TABLE `sys_app`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `AppId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `AppSecret` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `EncodingAESKey` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `RequestUrl` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Token` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsOpenAEKey` tinyint(1) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NOT NULL DEFAULT 1,
  `EnabledMark` tinyint(1) NOT NULL DEFAULT 0,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NOT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CompanyId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeptId` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_area
-- ----------------------------
DROP TABLE IF EXISTS `sys_area`;
CREATE TABLE `sys_area`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ParentId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Layers` int(8) NULL DEFAULT NULL,
  `EnCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FullName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `SimpleSpell` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FullIdPath` varchar(600) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsLast` tinyint(1) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyU` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_dbbackup
-- ----------------------------
DROP TABLE IF EXISTS `sys_dbbackup`;
CREATE TABLE `sys_dbbackup`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `BackupType` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DbName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FileName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FileSize` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FilePath` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `BackupTime` datetime(0) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_filterip
-- ----------------------------
DROP TABLE IF EXISTS `sys_filterip`;
CREATE TABLE `sys_filterip`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FilterType` tinyint(1) NULL DEFAULT NULL,
  `StartIP` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `EndIP` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_function
-- ----------------------------
DROP TABLE IF EXISTS `sys_function`;
CREATE TABLE `sys_function`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `SystemTypeId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ParentId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Layers` int(8) NULL DEFAULT NULL,
  `EnCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FullName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Icon` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Location` int(8) NULL DEFAULT NULL,
  `JsEvent` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UrlAddress` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Split` tinyint(1) NULL DEFAULT NULL,
  `IsPublic` tinyint(1) NULL DEFAULT NULL,
  `AllowEdit` tinyint(1) NULL DEFAULT NULL,
  `AllowDelete` tinyint(1) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_items
-- ----------------------------
DROP TABLE IF EXISTS `sys_items`;
CREATE TABLE `sys_items`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ParentId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `EnCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FullName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsTree` tinyint(1) NULL DEFAULT NULL,
  `Layers` int(8) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_itemsdetail
-- ----------------------------
DROP TABLE IF EXISTS `sys_itemsdetail`;
CREATE TABLE `sys_itemsdetail`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ItemId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ParentId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ItemCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ItemName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `SimpleSpelling` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsDefault` tinyint(1) NULL DEFAULT NULL,
  `Layers` int(8) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` date NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_log
-- ----------------------------
DROP TABLE IF EXISTS `sys_log`;
CREATE TABLE `sys_log`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Date` datetime(0) NULL DEFAULT NULL,
  `Account` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `NickName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `OrganizeId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Type` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IPAddress` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IPAddressName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ModuleId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ModuleName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Result` tinyint(1) NULL DEFAULT NULL,
  `Description` mediumtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `SystemTypeId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ParentId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Layers` int(8) NULL DEFAULT NULL,
  `EnCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FullName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Icon` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UrlAddress` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Target` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsMenu` tinyint(1) NULL DEFAULT NULL,
  `IsExpand` tinyint(1) NULL DEFAULT NULL,
  `IsPublic` tinyint(1) NULL DEFAULT NULL,
  `AllowEdit` tinyint(1) NULL DEFAULT NULL,
  `AllowDelete` tinyint(1) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_openidsettings
-- ----------------------------
DROP TABLE IF EXISTS `sys_openidsettings`;
CREATE TABLE `sys_openidsettings`  (
  `OpenIdType` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Description` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Settings` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_organize
-- ----------------------------
DROP TABLE IF EXISTS `sys_organize`;
CREATE TABLE `sys_organize`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ParentId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Layers` int(8) NULL DEFAULT NULL,
  `EnCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FullName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ShortName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CategoryId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ManagerId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `TelePhone` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `MobilePhone` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `WeChat` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Fax` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `AreaId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Address` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `AllowEdit` tinyint(1) NULL DEFAULT NULL,
  `AllowDelete` tinyint(1) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OrganizeId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Category` int(8) NULL DEFAULT NULL,
  `EnCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FullName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Type` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `AllowEdit` tinyint(1) NULL DEFAULT NULL,
  `AllowDelete` tinyint(1) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_roleauthorize
-- ----------------------------
DROP TABLE IF EXISTS `sys_roleauthorize`;
CREATE TABLE `sys_roleauthorize`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ItemType` int(8) NULL DEFAULT NULL,
  `ItemId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ObjectType` int(8) NULL DEFAULT NULL,
  `ObjectId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_roledata
-- ----------------------------
DROP TABLE IF EXISTS `sys_roledata`;
CREATE TABLE `sys_roledata`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `RoleId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DType` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `AuthorizeData` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_sequence
-- ----------------------------
DROP TABLE IF EXISTS `sys_sequence`;
CREATE TABLE `sys_sequence`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `SequenceName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `SequenceDelimiter` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `SequenceReset` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Step` int(11) NULL DEFAULT NULL,
  `CurrentNo` int(11) NULL DEFAULT NULL,
  `CurrentCode` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CurrentReset` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Description` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `EnabledMark` tinyint(1) NOT NULL DEFAULT 1,
  `DeleteMark` tinyint(1) NULL DEFAULT 0,
  `CreatorTime` datetime(0) NOT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CompanyId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeptId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '业务单据编码表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_sequencerule
-- ----------------------------
DROP TABLE IF EXISTS `sys_sequencerule`;
CREATE TABLE `sys_sequencerule`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `SequenceName` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `RuleOrder` int(11) NOT NULL,
  `RuleType` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `RuleValue` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `PaddingSide` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `PaddingWidth` int(11) NULL DEFAULT NULL,
  `Sys_SequenceRulecol` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `PaddingChar` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Description` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NOT NULL DEFAULT 1,
  `DeleteMark` tinyint(1) NULL DEFAULT 0,
  `CreatorTime` datetime(0) NOT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CompanyId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeptId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '业务单据编码规则表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_systemtype
-- ----------------------------
DROP TABLE IF EXISTS `sys_systemtype`;
CREATE TABLE `sys_systemtype`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `EnCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FullName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Url` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `AllowEdit` tinyint(1) NULL DEFAULT NULL,
  `AllowDelete` tinyint(1) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_taskjobslog
-- ----------------------------
DROP TABLE IF EXISTS `sys_taskjobslog`;
CREATE TABLE `sys_taskjobslog`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `TaskId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `TaskName` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `JobAction` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Status` tinyint(1) NOT NULL DEFAULT 0,
  `Description` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `CreatorTime` datetime(0) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '定时任务日志' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_taskmanager
-- ----------------------------
DROP TABLE IF EXISTS `sys_taskmanager`;
CREATE TABLE `sys_taskmanager`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `TaskName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `GroupName` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `StartTime` datetime(0) NULL DEFAULT NULL,
  `EndTime` datetime(0) NULL DEFAULT NULL,
  `Cron` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `IsLocal` tinyint(1) NOT NULL DEFAULT 0,
  `JobCallAddress` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `JobCallParams` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastRunTime` datetime(0) NULL DEFAULT NULL,
  `LastErrorTime` datetime(0) NULL DEFAULT NULL,
  `NextRunTime` datetime(0) NULL DEFAULT NULL,
  `RunCount` int(11) NULL DEFAULT NULL,
  `ErrorCount` int(11) NULL DEFAULT NULL,
  `Description` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `SendMail` int(11) NULL DEFAULT 0,
  `EmailAddress` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Status` int(11) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NOT NULL DEFAULT 1,
  `DeleteMark` tinyint(1) NULL DEFAULT 0,
  `CreatorTime` datetime(0) NOT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CompanyId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeptId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '定时任务' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_tenant
-- ----------------------------
DROP TABLE IF EXISTS `sys_tenant`;
CREATE TABLE `sys_tenant`  (
  `Id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TenantName` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CompanyName` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `HostDomain` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `LinkMan` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Telphone` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `DataSource` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NOT NULL DEFAULT 1,
  `DeleteMark` tinyint(1) NULL DEFAULT 0,
  `CreatorTime` datetime(0) NOT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CompanyId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeptId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '租户' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_uploadfile
-- ----------------------------
DROP TABLE IF EXISTS `sys_uploadfile`;
CREATE TABLE `sys_uploadfile`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FileName` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FilePath` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Description` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FileType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FileSize` int(8) NULL DEFAULT NULL,
  `Extension` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateUserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `Thumbnail` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `BelongApp` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `BelongAppId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Account` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `RealName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `NickName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `HeadIcon` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Gender` int(8) NULL DEFAULT NULL,
  `Birthday` datetime(0) NULL DEFAULT NULL,
  `MobilePhone` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `WeChat` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ManagerId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `SecurityLevel` int(8) NULL DEFAULT NULL,
  `Signature` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Country` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Province` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `City` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `District` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `OrganizeId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DepartmentId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `RoleId` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DutyId` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsAdministrator` tinyint(1) NULL DEFAULT NULL,
  `IsMember` tinyint(1) NULL DEFAULT NULL,
  `MemberGradeId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ReferralUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UnionId` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `SortCode` int(8) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_userextend
-- ----------------------------
DROP TABLE IF EXISTS `sys_userextend`;
CREATE TABLE `sys_userextend`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CardContent` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Telphone` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Address` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CompanyName` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `PositionTite` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `WechatQrCode` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IndustryId` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `OpenType` int(8) NULL DEFAULT NULL,
  `IsOtherShare` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ShareTitle` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `WebUrl` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CompanyDesc` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `CardTheme` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `VipGrade` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsAuthentication` tinyint(1) NULL DEFAULT NULL,
  `AuthenticationType` int(8) NULL DEFAULT NULL,
  `EnabledMark` tinyint(1) NULL DEFAULT NULL,
  `DeleteMark` tinyint(1) NULL DEFAULT NULL,
  `CreatorTime` datetime(0) NULL DEFAULT NULL,
  `CreatorUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CompanyId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeptId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LastModifyTime` datetime(0) NULL DEFAULT NULL,
  `LastModifyUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL,
  `DeleteUserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_userlogon
-- ----------------------------
DROP TABLE IF EXISTS `sys_userlogon`;
CREATE TABLE `sys_userlogon`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UserId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UserPassword` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UserSecretkey` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `AllowStartTime` datetime(0) NULL DEFAULT NULL,
  `AllowEndTime` datetime(0) NULL DEFAULT NULL,
  `LockStartDate` datetime(0) NULL DEFAULT NULL,
  `LockEndDate` datetime(0) NULL DEFAULT NULL,
  `FirstVisitTime` datetime(0) NULL DEFAULT NULL,
  `PreviousVisitTime` datetime(0) NULL DEFAULT NULL,
  `LastVisitTime` datetime(0) NULL DEFAULT NULL,
  `ChangePasswordDate` datetime(0) NULL DEFAULT NULL,
  `MultiUserLogin` tinyint(1) NULL DEFAULT NULL,
  `LogOnCount` int(8) NULL DEFAULT NULL,
  `UserOnLine` tinyint(1) NULL DEFAULT NULL,
  `Question` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `AnswerQuestion` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CheckIPAddress` tinyint(1) NULL DEFAULT NULL,
  `Language` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Theme` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_useropenids
-- ----------------------------
DROP TABLE IF EXISTS `sys_useropenids`;
CREATE TABLE `sys_useropenids`  (
  `UserId` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `OpenIdType` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `OpenId` varchar(254) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
