/*
//================================================================================
//  FileName: SFIT_Tables_extends.sql
//  Desc:表结构扩展。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/16
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
-----------------------------------------------------------------------------------------------------
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITGroupCatalog')
begin
	print 'drop table tblSFITGroupCatalog'
	drop table tblSFITGroupCatalog
end
go
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITGroupStudents')
begin
	print 'drop table tblSFITGroupStudents'
	drop table tblSFITGroupStudents
end
go
-----------------------------------------------------------------------------------------------------
--分组管理。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITGroup')
begin
	print 'drop table tblSFITGroup'
	drop table tblSFITGroup
end
go
	print 'create table tblSFITGroup'
go
create table tblSFITGroup
(
	GroupID		GUIDEx,--分组ID。
	GroupName	nvarchar(128),--分组名称。
	GroupType	int default(0),--分组类型(0-兴趣小组，1-竞赛管理)。
	
	UnitID		GUIDEx default(null),--所属单位（为空时为教育局直属）。
	OrderNO		int default(1),--排序字段。
	
	Description	nvarchar(256),--描述说明。
	
	LastModifyEmployeeID	GUIDEx null,--最后修改者ID。
	LastModifyEmployeeName	nvarchar(64),--最后修改者名称。
	
	LastModifyTime			datetime default(getdate()),--最后修改时间。
	
	constraint PK_tblSFITGroup primary key(GroupID)--主键约束。
)
go
-----------------------------------------------------------------------------------------------------
--分组目录。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITGroupCatalog')
begin
	print 'drop table tblSFITGroupCatalog'
	drop table tblSFITGroupCatalog
end
go
	print 'crate table tblSFITGroupCatalog'
go
create table tblSFITGroupCatalog
(
	GroupID		GUIDEx,--分组ID。
	CatalogID	GUIDEx,--目录ID。
	CatalogName	nvarchar(128),--目录名称。
	
	constraint PK_tblSFITGroupCatalog primary key(GroupID,CatalogID),--主键约束。
	constraint FK_tblSFITGroupCatalog_tblSFITGroup_GroupID foreign key(GroupID) references tblSFITGroup(GroupID)--外键约束。
)
-----------------------------------------------------------------------------------------------------
--分组人员。
if exists(select 0 from sysobjects where xtype = 'u' and name = 'tblSFITGroupStudents')
begin
	print 'drop table tblSFITGroupStudents'
	drop table tblSFITGroupStudents
end
go
	print 'create table tblSFITGroupStudents'
go
create table tblSFITGroupStudents
(
	GroupID		GUIDEx,--分组ID。
	StudentID	GUIDEx,--学生ID。
	StudentCode	nvarchar(128),--学生代码。
	StudentName	nvarchar(128),--学生名称。
	
	constraint PK_tblSFITGroupStudents primary key(GroupID,StudentID),--主键约束。
	constraint FK_tblSFITGroupStudents_tblSFITGroup_GroupID foreign key(GroupID) references tblSFITGroup(GroupID)--外键约束。
)
-----------------------------------------------------------------------------------------------------


