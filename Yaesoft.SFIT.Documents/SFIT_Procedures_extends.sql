/*
//================================================================================
//  FileName: SFIT_Procedures_extends.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/23
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
-----------------------------------------------------------------------------------------------
--
-----------------------------------------------------------------------------------------------
--分组列表数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITGroupListView')
begin
	print 'drop procedure spSFITGroupListView'
	drop procedure spSFITGroupListView
end
go
	print 'create procedure spSFITGroupListView'
go
create procedure spSFITGroupListView
(
	@UnitName		nvarchar(128),--所属学校。
	@GroupName		nvarchar(128),--分组名称。
		
	@GroupType		int,--分组类型。
	@IsUnit			int = 0,--是否为学校单位。
	@EmployeeID		GUIDEx--用户ID。
)
as
begin
	if(@IsUnit = 0)
	begin
	
		select isnull(b.SchoolName,'[教育局]') as UnitName,a.GroupID,a.GroupName,a.Description,a.LastModifyEmployeeName,a.LastModifyTime
		from tblSFITGroup a
		left outer join tblSFITSchools b
		on b.SchoolID = a.UnitID
		where (a.GroupType = @GroupType) 
		and (isnull(b.SchoolName,@UnitName) like '%'+@UnitName+'%')
		and (a.GroupName like '%'+@GroupName+'%')
		order by isnull(b.OrderNO,0), a.OrderNO
	
	end else begin
	
		select isnull(b.SchoolName,'[教育局]') as UnitName,a.GroupID,a.GroupName,a.Description,a.LastModifyEmployeeName,a.LastModifyTime
		from tblSFITGroup a
		left outer join tblSFITSchools b
		on b.SchoolID = a.UnitID
		where (a.GroupType = @GroupType)
		and (a.UnitID in (select SchoolID from tblSFITeachers where TeacherID = @EmployeeID))
		and (isnull(b.SchoolName,@UnitName) like '%'+@UnitName+'%')
		and (a.GroupName like '%'+@GroupName+'%')
		order by isnull(b.OrderNO,0), a.OrderNO
	
	end
end
go
-----------------------------------------------------------------------------------------------
--分组目录列表数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITGroupCatalogListView')
begin
	print 'drop procedure spSFITGroupCatalogListView'
	drop procedure spSFITGroupCatalogListView
end
go
	print 'create procedure spSFITGroupCatalogListView'
go
create procedure spSFITGroupCatalogListView
(
	@GroupID	GUIDEx--分组ID。
)
as
begin
	select a.CatalogID,isnull(b.CatalogName,a.CatalogName) as CatalogName,b.CatalogType,
	isnull(c.SchoolName,'[全区必修]') as SchoolName, d.GradeName
	from tblSFITGroupCatalog a
	inner join tblSFITCatalog b
	on b.CatalogID = a.CatalogID
	left outer join tblSFITSchools c
	on c.SchoolID = b.SchoolID
	left outer join tblSFITGrade d
	on d.GradeID = b.GradeID
	where a.GroupID = @GroupID
	order by b.OrderNO
end
go
-----------------------------------------------------------------------------------------------
--分组人员列表数据源。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITGroupStudentsListView')
begin
	print 'drop procedure spSFITGroupStudentsListView'
	drop procedure spSFITGroupStudentsListView
end
go
	print 'create procedure spSFITGroupStudentsListView'
go
create procedure spSFITGroupStudentsListView
(
	@GroupID	GUIDEx--分组ID。
)
as
begin
	select a.StudentID,a.StudentName,a.StudentCode,d.SchoolName,c.ClassName
	from tblSFITGroupStudents a
	left outer join tblSFITClassStudents b
	on b.StudentID = a.StudentID
	left outer join vwSFITGradeClass c
	on c.ClassID = b.ClassID
	left outer join tblSFITSchools d
	on d.SchoolID = c.SchoolID
	where a.GroupID = @GroupID
end
go
-----------------------------------------------------------------------------------------------
--小组作品列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITGroupWorkListView')
begin
	print 'drop procedure spSFITGroupWorkListView'
	drop procedure spSFITGroupWorkListView
end
go
	print 'create procedure spSFITGroupWorkListView'
go
create procedure spSFITGroupWorkListView
(
	@UnitName		nvarchar(128),--所属学校名称。
	@GroupName		nvarchar(128),--所属分组名称。
	@CatalogName	nvarchar(128),--课程科目。
	@StudentName	nvarchar(128),--学生名称。
	
	@GroupType	int = 0,--分组类型。
	@IsUnit	int = 0,--是否为学校单位。
	@EmployeeID		GUIDEx--用户ID。
)
as
begin
	if(@IsUnit = 0)
	begin
	
		select a.GroupName,d.WorkID,d.SchoolName,d.GradeName,d.ClassName,d.WorkName,
		f.StudentName,e.ReviewValue,d.WorkStatus,d.CreateDateTime
		from tblSFITGroup a
		inner join tblSFITGroupCatalog b
		on b.GroupID = a.GroupID
		inner join tblSFITGroupStudents c
		on c.GroupID = a.GroupID
		inner join tblSFITStudentWorks d
		on d.CatalogID = b.CatalogID and d.StudentID = c.StudentID
		left outer join tblSFITeaReviewStudent e
		on e.WorkID = d.WorkID
		inner join tblSFITStudents f
		on f.StudentID = d.StudentID
		
		where (a.GroupType = @GroupType)
		and (d.SchoolName like '%'+@UnitName+'%')
		and (a.GroupName like '%'+@GroupName+'%')
		and (d.CatalogName like '%'+@CatalogName+'%')
		and ((f.StudentCode like '%'+@StudentName+'%') or (f.StudentName like '%'+@StudentName+'%'))
		
		order by a.OrderNO,d.CreateDateTime desc
	
	end else begin
	
		select a.GroupName,d.WorkID,d.SchoolName,d.GradeName,d.ClassName,d.WorkName,
		f.StudentName,e.ReviewValue,d.WorkStatus,d.CreateDateTime
		from tblSFITGroup a
		inner join tblSFITGroupCatalog b
		on b.GroupID = a.GroupID
		inner join tblSFITGroupStudents c
		on c.GroupID = a.GroupID
		inner join tblSFITStudentWorks d
		on d.CatalogID = b.CatalogID and d.StudentID = c.StudentID
		left outer join tblSFITeaReviewStudent e
		on e.WorkID = d.WorkID
		inner join tblSFITStudents f
		on f.StudentID = d.StudentID
		
		where (a.GroupType = @GroupType)
		and (a.UnitID in (select SchoolID from tblSFITeachers where TeacherID = @EmployeeID))
		and (d.SchoolName like '%'+@UnitName+'%')
		and (a.GroupName like '%'+@GroupName+'%')
		and (d.CatalogName like '%'+@CatalogName+'%')
		and ((f.StudentCode like '%'+@StudentName+'%') or (f.StudentName like '%'+@StudentName+'%'))
		
		order by a.OrderNO,d.CreateDateTime desc
	
	end
end
go
-----------------------------------------------------------------------------------------------
