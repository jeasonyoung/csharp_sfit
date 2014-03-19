/*
//================================================================================
//  FileName: SFIT_Procedures_Index.sql
//  Desc:Index页面存储过程。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/19
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
--------------------------------------------------------------------------------------------
--按年级获取最新的作品分组。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexTopGrade')
begin
	print 'drop procedure spSFITIndexTopGrade'
	drop procedure spSFITIndexTopGrade
end
go
	print 'create procedure spSFITIndexTopGrade'
go
create procedure spSFITIndexTopGrade
as
begin
	select GradeID,GradeName,OrderNO
	from tblSFITGrade
	order by OrderNO

	--select aa.GradeID,aa.GradeName,b.OrderNO
	--from (
		--select GradeID,GradeName
		--from tblSFITStudentWorks
		--where WorkType = 0 and (WorkStatus & 0x10 = 0x10)
		--group by GradeID,GradeName
	--) aa
	--inner join tblSFITGrade b
	--on b.GradeID = aa.GradeID
	--order by b.OrderNO
end
go
--------------------------------------------------------------------------------------------
--获取学校单位。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexTopUnit')
begin
	print 'drop procedure spSFITIndexTopUnit'
	drop procedure spSFITIndexTopUnit
end
go
	print 'create procedure spSFITIndexTopUnit'
go
create procedure spSFITIndexTopUnit
as
begin
	select SchoolID as UnitID,SchoolName as UnitName,OrderNO
	from tblSFITSchools
	where SchoolType < 5
	order by SchoolType desc,OrderNO
end
go
--------------------------------------------------------------------------------------------
--根据年级ID获取全部的目录数据.
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexAllCatalog')
begin
	print 'drop procedure spSFITIndexAllCatalog'
	drop procedure spSFITIndexAllCatalog
end
go
	print 'create procedure spSFITIndexAllCatalog'
go
create procedure spSFITIndexAllCatalog
(
	@UnitID		GUIDEx,--学校单位ID。
	@GradeID	GUIDEx--年级ID。
)
as
begin
	select a.CatalogID,a.CatalogName,isnull(b.SchoolName,'[全区必修]') as SchoolName,a.CatalogType, a.OrderNO
	from tblSFITCatalog a
	left outer join tblSFITSchools b
	on b.SchoolID = a.SchoolID
	where isnull(b.SchoolID,@UnitID) = @UnitID and a.GradeID = @GradeID
	order by a.OrderNO
	 
	--select a.CatalogID,a.CatalogName,isnull(b.SchoolName,'[全区必修]') as SchoolName,isnull(c.WorkCount,0) as WorkCount
	--from tblSFITCatalog a
	--left outer join tblSFITSchools b
	--on b.SchoolID = a.SchoolID
	--left outer join (
		--select CatalogID,count(WorkID) as WorkCount
		--from tblSFITStudentWorks 
		--where WorkType = 0 and (WorkStatus & 0x10 = 0x10)
		--group by CatalogID
	--) c
	--on c.CatalogID = a.CatalogID
	--where a.GradeID = @GradeID
	--order by a.OrderNO
end
go
--------------------------------------------------------------------------------------------
--根据目录ID获取公开发布的全部作品信息。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexAllWorks')
begin
	print 'drop procedure spSFITIndexAllWorks'
	drop procedure spSFITIndexAllWorks
end
go
	print 'create procedure spSFITIndexAllWorks'
go
create procedure spSFITIndexAllWorks
(
	@UnitID		GUIDEx,--学校单位ID。
	@GradeID	GUIDEx,--年级ID。
	@CatalogID	GUIDEx,--目录ID。
	@Query		nvarchar(128)--模糊查询条件。
)
as
begin
	select a.WorkID,a.WorkName,a.SchoolName,a.GradeName,a.ClassName,a.CatalogName,b.StudentName,b.StudentCode,a.CreateDateTime,a.WorkDescription,a.CheckCode,
	a.SchoolID as UnitID,a.GradeID
	from tblSFITStudentWorks a
	inner join tblSFITStudents b
	on b.StudentID = a.StudentID
	where (a.WorkType = 0) and (a.WorkStatus & 0x10 = 0x10)
	and (a.SchoolID like '%'+ @UnitID) and (a.GradeID like '%'+ @GradeID) and (a.CatalogID like '%' + @CatalogID)
	and ((a.WorkName like '%'+@Query+'%') or (a.SchoolName like '%'+@Query+'%') or (a.GradeName like '%'+@Query+'%') or (a.ClassName like '%'+@Query+'%')
		  or (a.CatalogName like '%'+@Query+'%') or (b.StudentName like '%'+@Query+'%') or (a.CheckCode like '%'+@Query+'%') or (a.WorkDescription like '%'+@Query+'%'))
	order by a.CreateDateTime desc
end
go
--------------------------------------------------------------------------------------------
--根据作品ID获取前50个评论。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITIndexAllComments')
begin
	print 'drop procedure spSFITIndexAllComments'
	drop procedure spSFITIndexAllComments
end
go
	print 'create procedure spSFITIndexAllComments'
go
create procedure spSFITIndexAllComments
(
	@WorkID		GUIDEx--作品ID。
)
as
begin
	select CommentID,UserName,ClientIP,CreateDateTime,Comment
	from tblSFITWorksComments
	where Status = 0
	order by CreateDateTime desc
end
go
--------------------------------------------------------------------------------------------
--根据用户ID获取学校访问密钥下载。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITCenterAccess')
begin
	print 'drop procedure spSFITCenterAccess'
	drop procedure spSFITCenterAccess
end
go
	print 'create procedure spSFITCenterAccess'
go
create procedure spSFITCenterAccess
(
	@EmpolyeeID		GUIDEx--用户ID。
)
as
begin
	select distinct a.AccessID
	from tblSFITCenterAccess a
	inner join tblSFITeachers b
	on b.SchoolID = a.SchoolID
	inner join tblSFITTeaClass c
	on c.TeacherID = b.TeacherID
	where a.AccessStatus = 1
	and c.TeacherID = @EmpolyeeID
end
go
--------------------------------------------------------------------------------------------
