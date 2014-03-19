/*
//================================================================================
//  FileName: SFIT_Init.sql
//  Desc:初始化数据。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/15
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
*/
--------------------------------------------------------------------------------------------------
--枚举初始化。

--变量定义。
declare @EnumName nvarchar(256)
--学校类型枚举。
set @EnumName = 'Yaesoft.SFIT.EnumSchoolType'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Nursery','幼儿园',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'PrimarySchool','小学',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'JuniorHighSchool','初中',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'HighSchool','高中',0x03,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'ConsistentSystemSchool','一贯制',0x04,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'TwoUnit','二级机构',0x05,5)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Bureau','局机关',0x06,6)
--性别枚举。
set @EnumName = 'Yaesoft.SFIT.EnumGender'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'None','未知',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Male','男',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Female','女',0x02,2)
--学习阶段枚举。
set @EnumName = 'Yaesoft.SFIT.EnumLearnLevel' 
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Nursery','幼儿园',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'PrimarySchool','小学',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'JuniorHighSchool','初中',0x02,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'HighSchool','高中',0x03,3)
--作品状态枚举。
set @EnumName='Yaesoft.SFIT.EnumWorkStatus'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'None','未提交',0x01,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Submit','已提交',0x02,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Recive','已接收',0x04,2)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Review','已批阅',0x08,3)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Upload','已上传',0x10,4)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Release','已发布',0x20,5)
--学生作品类型
set @EnumName='Yaesoft.SFIT.EnumWorkType'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Public','公开',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Protected','不公开',0x01,1)
--评价类型枚举。
set @EnumName='Yaesoft.SFIT.EnumEvaluateType'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Hierarchy','等级制',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Scoring','分数制',0x01,1)
--------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------
--显示类型枚举。
set @EnumName = 'Yaesoft.SFIT.Engine.Persistence.EnumDisplayType'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'None','不显示',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Display','显示',0x01,1)
--访问状态枚举。
set @EnumName = 'Yaesoft.SFIT.Engine.Persistence.EnumAccessStatus'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Non','禁止',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Allow','允许',0x01,1)
--目录类型枚举。
set @EnumName = 'Yaesoft.SFIT.Engine.Persistence.EnumCatalogType'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Required','必修',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Custom','自增',0x01,1)
--同步状态枚举。
set @EnumName = 'Yaesoft.SFIT.Engine.Persistence.EnumSyncStatus'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'None','停止同步',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Sync','允许同步',0x01,1)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Complete','已同步',0x02,2)
--评论状态枚举。
set @EnumName='Yaesoft.SFIT.Engine.Persistence.EnumCommentStatus'
delete from tblCommonEnums where EnumName = @EnumName
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Show','展示',0x00,0)
insert into tblCommonEnums(EnumName,Member,MemberName,IntValue,OrderNo) values(@EnumName,'Hide','隐藏',0x01,1)