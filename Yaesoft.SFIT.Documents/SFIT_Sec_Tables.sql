/*
//================================================================================
//  FileName: SFIT_Sec_Tables.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/9/27
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
-------------------------------------------------------------------------------------------------
--SFIT 角色数据安全表结构。
-------------------------------------------------------------------------------------------------
--角色学校。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITSecRoleSchool')
begin
	print 'drop table tblSFITSecRoleSchool'
	drop table tblSFITSecRoleSchool
end
go
	print 'create table tblSFITSecRoleSchool'
go
create table tblSFITSecRoleSchool
(
	RoleID		GUIDEx,--角色ID。
	RoleName	nvarchar(256),--角色名称。
	
	SchoolID	GUIDEx,--学校ID。
	
	constraint PK_tblSFITSecRoleSchool primary key(RoleID,SchoolID),--主键约束。
	constraint FK_tblSFITSecRoleSchool_tblSFITSchools_SchoolID foreign key(SchoolID) references tblSFITSchools(SchoolID)--外键约束。
)
go
-------------------------------------------------------------------------------------------------
--角色年级。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITSecRoleGrade')
begin
	print 'drop table tblSFITSecRoleGrade'
	drop table tblSFITSecRoleGrade
end
go
	print 'create table tblSFITSecRoleGrade'
go
create table tblSFITSecRoleGrade
(
	RoleID		GUIDEx,--角色ID。
	RoleName	nvarchar(256),--角色名称。
	
	GradeID		GUIDEx,--年级ID。
	
	constraint PK_tblSFITSecRoleGrade primary key(RoleID,GradeID),--主键约束。
	constraint FK_tblSFITSecRoleGrade_tblSFITGrade_GradeID foreign key(GradeID) references tblSFITGrade(GradeID)--外键约束。
)
go
-------------------------------------------------------------------------------------------------
--角色班级。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITSecRoleClass')
begin
	print 'drop table tblSFITSecRoleClass'
	drop table tblSFITSecRoleClass
end
go
	print 'create table tblSFITSecRoleClass'
go
create table tblSFITSecRoleClass
(
	RoleID		GUIDEx,--角色ID。
	RoleName	nvarchar(256),--角色名称。
	
	ClassID		GUIDEx,--班级ID。
	
	constraint PK_tblSFITSecRoleClass primary key(RoleID,ClassID),--主键约束。
	constraint FK_tblSFITSecRoleClass_tblSFITClass foreign key(ClassID) references tblSFITClass(ClassID)--外键约束。
)
go
-------------------------------------------------------------------------------------------------
