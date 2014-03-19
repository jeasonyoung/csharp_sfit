/*
//================================================================================
//  FileName: SFIT_Procedures_WorksComments.sql
//  Desc:作品评论。
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
------------------------------------------------------------------------------------------------------------
--评论汇总（教育局）
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITWorksCommentsListView')
begin
	print 'drop procedure spSFITWorksCommentsListView'
	drop procedure spSFITWorksCommentsListView
end
go
	print 'create procedure spSFITWorksCommentsListView'
go
create procedure spSFITWorksCommentsListView
(
	@UnitName		nvarchar(128),--所属学校单位名称。
	@GradeID		GUIDEx,--所属年级ID。
	@ClassName		nvarchar(128),--所属班级。
	@CatalogName	nvarchar(128),--所属目录名称。
	@StudentName	nvarchar(128),--学生名称。
	@WorkName		nvarchar(128)--作品名称。
)
as
begin

	select a.CommentID,b.WorkName,b.SchoolName,b.GradeName,b.ClassName,b.CatalogName,c.StudentName,
	a.Status,a.Comment,a.UserName,a.ClientIP,a.CreateDateTime
	from tblSFITWorksComments a
	inner join tblSFITStudentWorks b
	on b.WorkID = a.WorkID
	left outer join tblSFITStudents c
	on c.StudentID = b.StudentID
	
	where (isnull(b.WorkName,'') like '%'+@WorkName+'%')
	and (isnull(b.SchoolName,'') like '%'+@UnitName+'%')
	and (isnull(b.GradeID,'') like '%'+@GradeID+'%')
	and (isnull(b.ClassName,'') like '%'+@ClassName+'%')
	and (isnull(b.CatalogName,'') like '%'+@CatalogName+'%')
	and ((isnull(c.StudentName,'') like '%'+@StudentName+'%') or (isnull(c.StudentCode,'') like '%'+@StudentName+'%'))
	
	order by a.CreateDateTime desc
end
go
------------------------------------------------------------------------------------------------------------
--评论汇总（学校）
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITWorksCommentsByUnitListView')
begin
	print 'drop procedure spSFITWorksCommentsByUnitListView'
	drop procedure spSFITWorksCommentsByUnitListView
end
go
	print 'create procedure spSFITWorksCommentsByUnitListView'
go
create procedure spSFITWorksCommentsByUnitListView
(
	@UnitID			GUIDEx,--所属学校单位名称。
	@GradeID		GUIDEx,--所属年级ID。
	@ClassName		nvarchar(128),--所属班级。
	@CatalogName	nvarchar(128),--所属目录名称。
	@StudentName	nvarchar(128),--学生名称。
	@WorkName		nvarchar(128)--作品名称。
)
as
begin
	select a.CommentID,b.WorkName,b.SchoolName,b.GradeName,b.ClassName,b.CatalogName,c.StudentName,
	a.Status,a.Comment,a.UserName,a.ClientIP,a.CreateDateTime
	from tblSFITWorksComments a
	inner join tblSFITStudentWorks b
	on b.WorkID = a.WorkID
	left outer join tblSFITStudents c
	on c.StudentID = b.StudentID
	
	where (b.SchoolID = @UnitID)
	and (isnull(b.WorkName,'') like '%'+@WorkName+'%')
	and (isnull(b.GradeID,'') like '%'+@GradeID+'%')
	and (isnull(b.ClassName,'') like '%'+@ClassName+'%')
	and (isnull(b.CatalogName,'') like '%'+@CatalogName+'%')
	and ((isnull(c.StudentName,'') like '%'+@StudentName+'%') or (isnull(c.StudentCode,'') like '%'+@StudentName+'%'))
	
	order by a.CreateDateTime desc
end
go
------------------------------------------------------------------------------------------------------------
