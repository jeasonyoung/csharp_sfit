/*
//================================================================================
//  FileName: SFIT_Paging_20121231.sql
//  Desc:分页存储过程。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-31
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
---------------------------------------------------------------------------------------------------------
--分页通用存储过程。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITRecordForPaging')
begin
	print 'drop procedure spSFITRecordForPaging'
	drop procedure spSFITRecordForPaging
end
go
	print 'create procedure spSFITRecordForPaging'
go
create procedure spSFITRecordForPaging
(
	@sql	nvarchar(4000),--查询语句。
	@pageIndex int = 1,--页码。
	@pageSize  int = 20--单页显示数据。
)
as
begin
	set nocount on
	--
	if(isnull(@pageIndex,0) <= 0)
	begin
		set @pageIndex = 1
	end
	--
	if(isnull(@pageSize,0) <= 0)
	begin
		set @pageSize = 20
	end
	
	declare @P1 int,@start int, @count int, @rowcount int
	exec sp_cursoropen @P1 output,@sql,@scrollopt=1,@ccopt=1,@rowcount=@rowcount output
	set @start = (@pageIndex - 1) * @pageSize + 1
	exec sp_cursorfetch @P1,16,@start,@pageSize
	exec sp_cursorclose @P1
	--
	if(isnull(@rowcount,0) > 0)
	begin
		set @count = @rowcount / @pageSize
		
		declare @tmp int
		set @tmp = @rowcount % @pageSize
		if(isnull(@tmp,0) > 0)
		begin
			set @count = @count + 1
		end
	end
	--
	select isnull(@pageIndex,0) as PAGE_INDEX,isnull(@pageSize,0) as PAGE_SIZE,isnull(@count,0) as PAGE_COUNT, isnull(@rowcount,0) as ROW_COUNT
	set nocount off
end
go
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--按最新作品分学校班级科目获取数据视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwSFITNewWorks')
begin
	print 'drop view vwSFITNewWorks'
	drop view vwSFITNewWorks
end
go
	print 'create view vwSFITNewWorks'
go
create view vwSFITNewWorks
as
	select  SchoolID,SchoolName,ClassID,ClassName,CatalogID,CatalogName, 
	COUNT(WorkID) as Works, max(CreateDateTime) as CreateDateTime
	from vwSFITStudentWorks
	group by SchoolID,SchoolName,ClassID,ClassName,CatalogID,CatalogName
go
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--按点击率排名作品
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwSFITHotWorks')
begin
	print 'drop view vwSFITHotWorks'
	drop view vwSFITHotWorks
end
go
	print 'create view vwSFITHotWorks'
go
create view vwSFITHotWorks
as
	select SchoolName,SchoolID,ClassName,ClassID,CatalogID,StudentName,WorkName,WorkID,CreateDateTime,Hits
	from vwSFITStudentWorks
	where Hits > 0
	--select a.WorkID,a.SchoolID,a.SchoolName,a.ClassID,a.ClassName,a.CatalogID,b.StudentName,a.WorkName,a.CreateDateTime, isnull(a.Hits,0) as Hits
	--from tblSFITStudentWorks a
	--inner join tblSFITStudents b
	--on b.StudentID = a.StudentID
	--where isnull(a.Hits,0) > 0
go
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--按最优作品排名。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwSFITBestWorks')
begin
	print 'drop view vwSFITBestWorks'
	drop view vwSFITBestWorks
end
go
	print 'create view vwSFITBestWorks'
go
create view vwSFITBestWorks
as
	select SchoolName,SchoolID,ClassName,ClassID,CatalogID,StudentName,WorkID,WorkName,ReviewValue,SubjectiveReviews,CreateDateTime
	from vwSFITStudentWorks
	where isnull(ReviewValue,'D-') <> 'D-'
	--select a.WorkID,a.SchoolID,a.SchoolName,a.ClassID,a.ClassName,a.CatalogID, b.StudentName,a.WorkName,a.CreateDateTime,
	--isnull(c.ReviewValue,'') as ReviewValue,isnull(c.SubjectiveReviews,'') as SubjectiveReviews
	--from tblSFITStudentWorks a
	--inner join tblSFITStudents b
	--on b.StudentID = a.StudentID
	--left outer join tblSFITeaReviewStudent c
	--on c.WorkID = a.WorkID
	--
go
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--全部作品视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwSFITALLWorks')
begin
	print 'drop view vwSFITALLWorks'
	drop view vwSFITALLWorks
end
go
	print 'create view vwSFITALLWorks'
go
create view vwSFITALLWorks
as
	select SchoolName,SchoolID,ClassName,ClassID,CatalogName,CatalogID,StudentName,StudentID,WorkName,WorkID,ReviewValue,SubjectiveReviews,CreateDateTime
	from vwSFITStudentWorks
	--select a.WorkID,a.SchoolID,a.SchoolName,a.ClassID,a.ClassName,a.CatalogID,a.CatalogName,a.StudentID, b.StudentName,a.WorkName,a.CreateDateTime,
	--case when isnull(c.ReviewValue,'') = '' then  'D-' else c.ReviewValue end as ReviewValue,
	--isnull(c.SubjectiveReviews,'') as SubjectiveReviews
	--from tblSFITStudentWorks a
	--inner join tblSFITStudents b
	--on b.StudentID = a.StudentID
	--left outer join tblSFITeaReviewStudent c
	--on c.WorkID = a.WorkID
go
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--学校班级数据视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwSFITClasses')
begin
	print 'drop view vwSFITClasses'
	drop view vwSFITClasses
end
go
	print 'create view vwSFITClasses'
go
create view vwSFITClasses
as
	select a.SchoolID,a.ClassID,a.ClassName,a.JoinYear,a.OrderNO
	from tblSFITClass a
	inner join vwSFITGradeClass b
	on b.ClassID = a.ClassID
	inner join tblSFITCatalog c
	on c.GradeID = b.GradeID
	group by a.SchoolID,a.JoinYear,a.ClassID,a.ClassName,a.OrderNO
	having count(c.CatalogID) > 0
	--order by a.SchoolID,a.JoinYear desc,a.OrderNO
go
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--学校年级科目视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwSFITCatalogs')
begin
	print 'drop view vwSFITCatalogs'
	drop view vwSFITCatalogs
end
go
	print 'create view vwSFITCatalogs'
go
create view vwSFITCatalogs
as
	select a.CatalogID,'['+ b.GradeCode + ']' + (case when isnull(a.CatalogType,0) = 1 then  a.CatalogName + '[选修]' else a.CatalogName end) as CatalogName,
	a.GradeID,b.GradeName, 
	case when isnull(a.SchoolID,'') <> '' then a.SchoolID else null end as SchoolID,
	b.OrderNO as GradeOrderNo, a.OrderNO
	from tblSFITCatalog a
	inner join tblSFITGrade b
	on b.GradeID = a.GradeID
go
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--作业时间视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwSFITWorksTime')
begin
	print 'drop view vwSFITWorksTime'
	drop view vwSFITWorksTime
end
go
	print 'create view vwSFITWorksTime'
go
create view vwSFITWorksTime
as
	select SchoolID,ClassID,convert(nvarchar(7),CreateDateTime,121) as WorkTime
	from vwSFITStudentWorks
	group by SchoolID,ClassID,convert(nvarchar(7),CreateDateTime,121)
go
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------