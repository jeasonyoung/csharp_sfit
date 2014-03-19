/*
//================================================================================
//  FileName: SFIT_Procedures_StudentWorks.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/13
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
--================================================================================
--收集作品(教育局)
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITStudentWorksListView')
begin
	 print 'drop procedure spSFITStudentWorksListView'
	 drop procedure spSFITStudentWorksListView
end
go
	print 'create procedure spSFITStudentWorksListView'
go
create procedure spSFITStudentWorksListView
(
	@SchoolName			nvarchar(128),--学校名称。
	@GradeID			GUIDEx,--年级ID
	@ClassName			nvarchar(128),--班级名称。
	@StudentName		nvarchar(128),--学生姓名。
	@WorkName			nvarchar(128),--作品名称。
	@WorkStatus			GUIDEx--作品状态。
)
as
begin
	if(isnull(@WorkStatus,'') <> '')
	begin
	
		declare @status int
		set @status = cast(@WorkStatus as int)
	
		select a.WorkID,a.SchoolName,a.GradeName,a.ClassName,
		case when isnull(a.WorkName,'') = '' then a.CatalogName else a.WorkName end as WorkName,
		c.ReviewValue,c.SubjectiveReviews,
		a.StudentID,b.StudentName,
		a.WorkStatus,a.CreateDateTime
		from tblSFITStudentWorks a
		inner join tblSFITStudents b
		on b.StudentID = a.StudentID
		left outer join tblSFITeaReviewStudent c
		on c.WorkID = a.WorkID
		left outer join tblSFITSchools d
		on d.SchoolID = a.SchoolID
		left outer join tblSFITClass e
		on e.ClassID = a.ClassID
		where (cast(a.WorkStatus as int) & @status = @status)
		and ((isnull(a.SchoolName,'') like '%'+@SchoolName+'%') or (isnull(d.SchoolCode,'') like '%'+@SchoolName+'%'))
		and (a.GradeID like '%'+@GradeID+'%')
		and (isnull(a.WorkName,a.CatalogName) like '%'+@WorkName+'%')
		and ((isnull(a.ClassName,'') like '%'+@ClassName+'%') or (isnull(e.ClassCode,'') like '%'+@ClassName+'%'))
		and ((isnull(b.StudentName,'') like '%'+@StudentName+'%') or (isnull(b.StudentCode,'') like '%'+@StudentName+'%'))
		order by a.CreateDateTime desc,d.OrderNO,d.SchoolType desc,e.OrderNO,e.GradeValue,a.ClassName,b.StudentName
		
	end else begin
		
		select a.WorkID,a.SchoolName,a.GradeName,a.ClassName,
		case when isnull(a.WorkName,'') = '' then a.CatalogName else a.WorkName end as WorkName,
		c.ReviewValue,c.SubjectiveReviews,
		a.StudentID,b.StudentName,
		a.WorkStatus,a.CreateDateTime
		from tblSFITStudentWorks a
		inner join tblSFITStudents b
		on b.StudentID = a.StudentID
		left outer join tblSFITeaReviewStudent c
		on c.WorkID = a.WorkID
		left outer join tblSFITSchools d
		on d.SchoolID = a.SchoolID
		left outer join tblSFITClass e
		on e.ClassID = a.ClassID
		where ((isnull(a.SchoolName,'') like '%'+@SchoolName+'%') or (isnull(d.SchoolCode,'') like '%'+@SchoolName+'%'))
		and (a.GradeID like '%'+@GradeID+'%')
		and (isnull(a.WorkName,a.CatalogName) like '%'+@WorkName+'%')
		and ((isnull(a.ClassName,'') like '%'+@ClassName+'%') or (isnull(e.ClassCode,'') like '%'+@ClassName+'%'))
		and ((isnull(b.StudentName,'') like '%'+@StudentName+'%') or (isnull(b.StudentCode,'') like '%'+@StudentName+'%'))
		order by a.CreateDateTime desc,d.OrderNO,d.SchoolType desc,e.OrderNO,e.GradeValue,a.ClassName,b.StudentName
	
	end
end
go

-------------------------------------------------------------------------------------------------------------------
--收集作品(学校单位)
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITStudentWorksByUnitListView')
begin
	 print 'drop procedure spSFITStudentWorksByUnitListView'
	 drop procedure spSFITStudentWorksByUnitListView
end
go
	print 'create procedure spSFITStudentWorksByUnitListView'
go
create procedure spSFITStudentWorksByUnitListView
(
	@SchoolID			GUIDEx,--学校ID。
	@GradeID			GUIDEx,--年级ID
	@ClassName			nvarchar(128),--班级名称。
	@StudentName		nvarchar(128),--学生姓名。
	@WorkName			nvarchar(128),--作品名称。
	@WorkStatus			GUIDEx--作品状态。
)
as
begin
	if(isnull(@WorkStatus,'') <> '')
	begin
		declare @status int
		set @status = cast(@WorkStatus as int)
		
		select a.WorkID,a.SchoolName,a.GradeName,a.ClassName,
		case when isnull(a.WorkName,'') = '' then a.CatalogName else a.WorkName end as WorkName,
		c.ReviewValue,c.SubjectiveReviews,
		a.StudentID,b.StudentName,
		a.WorkStatus,a.CreateDateTime
		from tblSFITStudentWorks a
		inner join tblSFITStudents b
		on b.StudentID = a.StudentID
		left outer join tblSFITeaReviewStudent c
		on c.WorkID = a.WorkID
		left outer join tblSFITSchools d
		on d.SchoolID = a.SchoolID
		left outer join tblSFITClass e
		on e.ClassID = a.ClassID
		where (a.SchoolID = @SchoolID) 
		and (a.GradeID like '%'+ @GradeID + '%') 
		and (cast(a.WorkStatus as int) & @status = @status)
		and (isnull(a.WorkName,a.CatalogName) like '%'+@WorkName+'%')
		and ((isnull(a.ClassName,'') like '%'+@ClassName+'%') or (isnull(e.ClassCode,'') like '%'+@ClassName+'%'))
		and ((isnull(b.StudentName,'') like '%'+@StudentName+'%') or (isnull(b.StudentCode,'') like '%'+@StudentName+'%'))
		order by a.CreateDateTime desc,d.OrderNO,d.SchoolType desc,e.OrderNO,e.GradeValue,a.ClassName,b.StudentName
		
	end else begin
	
		select a.WorkID,a.SchoolName,a.GradeName,a.ClassName,
		case when isnull(a.WorkName,'') = '' then a.CatalogName else a.WorkName end as WorkName,
		c.ReviewValue,c.SubjectiveReviews,
		a.StudentID,b.StudentName,
		a.WorkStatus,a.CreateDateTime
		from tblSFITStudentWorks a
		inner join tblSFITStudents b
		on b.StudentID = a.StudentID
		left outer join tblSFITeaReviewStudent c
		on c.WorkID = a.WorkID
		left outer join tblSFITSchools d
		on d.SchoolID = a.SchoolID
		left outer join tblSFITClass e
		on e.ClassID = a.ClassID
		where (a.SchoolID = @SchoolID) 
		and (a.GradeID like '%'+ @GradeID + '%') 
		and (isnull(a.WorkName,a.CatalogName) like '%'+@WorkName+'%')
		and ((isnull(a.ClassName,'') like '%'+@ClassName+'%') or (isnull(e.ClassCode,'') like '%'+@ClassName+'%'))
		and ((isnull(b.StudentName,'') like '%'+@StudentName+'%') or (isnull(b.StudentCode,'') like '%'+@StudentName+'%'))
		order by a.CreateDateTime desc,d.OrderNO,d.SchoolType desc,e.OrderNO,e.GradeValue,a.ClassName,b.StudentName
	
	end
end
go
-------------------------------------------------------------------------------------------------------------------
--收集作品（任课教师）。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITStudentWorksByTeaListView')
begin
	print 'drop procedure spSFITStudentWorksByTeaListView'
	drop procedure spSFITStudentWorksByTeaListView
end
go
	print 'create procedure spSFITStudentWorksByTeaListView'
go
create procedure spSFITStudentWorksByTeaListView
(
	@SchoolID	GUIDEx,--学校ID。
	@ClassID	GUIDEx,--任课班级ID。
	@StudentName	nvarchar(128),--学生姓名。
	@WorkName		nvarchar(128),--作品名称。
	@WorkStatus		GUIDEx--作品状态。
)
as
begin
	if(isnull(@WorkStatus,'') <> '')
	begin
		declare @status int
		set @status = cast(@WorkStatus as int)
		
		select a.WorkID,a.SchoolName,a.GradeName,a.ClassName,
		case when isnull(a.WorkName,'') = '' then a.CatalogName else a.WorkName end as WorkName,
		c.ReviewValue,c.SubjectiveReviews,
		a.StudentID,b.StudentName,
		a.WorkStatus,a.CreateDateTime
		from tblSFITStudentWorks a
		inner join tblSFITStudents b
		on b.StudentID = a.StudentID
		left outer join tblSFITeaReviewStudent c
		on c.WorkID = a.WorkID
		left outer join tblSFITSchools d
		on d.SchoolID = a.SchoolID
		left outer join tblSFITClass e
		on e.ClassID = a.ClassID
		where (a.SchoolID = @SchoolID) 
		and (a.ClassID = @ClassID)
		and (cast(a.WorkStatus as int) & @status = @status)
		and (isnull(a.WorkName,a.CatalogName) like '%'+@WorkName+'%')
		and ((isnull(b.StudentName,'') like '%'+@StudentName+'%') or (isnull(b.StudentCode,'') like '%'+@StudentName+'%'))
		order by a.CreateDateTime desc,d.OrderNO,d.SchoolType desc,e.OrderNO,e.GradeValue,a.ClassName,b.StudentName
	
	end else begin
	
		select a.WorkID,a.SchoolName,a.GradeName,a.ClassName,
		case when isnull(a.WorkName,'') = '' then a.CatalogName else a.WorkName end as WorkName,
		c.ReviewValue,c.SubjectiveReviews,
		a.StudentID,b.StudentName,
		a.WorkStatus,a.CreateDateTime
		from tblSFITStudentWorks a
		inner join tblSFITStudents b
		on b.StudentID = a.StudentID
		left outer join tblSFITeaReviewStudent c
		on c.WorkID = a.WorkID
		left outer join tblSFITSchools d
		on d.SchoolID = a.SchoolID
		left outer join tblSFITClass e
		on e.ClassID = a.ClassID
		where (a.SchoolID = @SchoolID) 
		and (a.ClassID = @ClassID)
		and (isnull(a.WorkName,a.CatalogName) like '%'+@WorkName+'%')
		and ((isnull(b.StudentName,'') like '%'+@StudentName+'%') or (isnull(b.StudentCode,'') like '%'+@StudentName+'%'))
		order by a.CreateDateTime desc,d.OrderNO,d.SchoolType desc,e.OrderNO,e.GradeValue,a.ClassName,b.StudentName
		
	end
end
go
-------------------------------------------------------------------------------------------------------------------
--学生查询作品。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITStudentWorksQueryListView')
begin
	print 'drop procedure spSFITStudentWorksQueryListView'
	drop procedure spSFITStudentWorksQueryListView
end
go
	print 'create procedure spSFITStudentWorksQueryListView'
go
create procedure spSFITStudentWorksQueryListView
(
	@StudentID	GUIDEx,--学生ID。
	@UnitName	nvarchar(128),--学校单位名称。
	@GradeName	nvarchar(128),--年级名称。
	@ClassName	nvarchar(128),--班级名称。
	@CatalogName	nvarchar(128),--目录名称。
	@WorkName		nvarchar(128),--作品名称。
	@WorkStatus		GUIDEx--作品状态。
)
as
begin
	if(isnull(@WorkStatus,'') <> '')
	begin
		declare @status int
		set @status = cast(@WorkStatus as int)
		
		select a.WorkID,a.SchoolName,a.GradeName,a.ClassName,
		case when isnull(a.WorkName,'') = '' then a.CatalogName else a.WorkName end as WorkName,
		c.ReviewValue,c.SubjectiveReviews,
		a.StudentID,b.StudentName,
		a.WorkStatus,a.CreateDateTime
		from tblSFITStudentWorks a
		inner join tblSFITStudents b
		on b.StudentID = a.StudentID
		left outer join tblSFITeaReviewStudent c
		on c.WorkID = a.WorkID
		left outer join tblSFITSchools d
		on d.SchoolID = a.SchoolID
		left outer join tblSFITClass e
		on e.ClassID = a.ClassID
		where (a.StudentID = @StudentID)
		and (cast(a.WorkStatus as int) & @status = @status)
		and (a.SchoolName like '%'+ @UnitName + '%')
		and (a.GradeName like '%'+ @GradeName +'%')
		and (a.ClassName like '%'+ @ClassName +'%')
		and (a.CatalogName like '%'+ @CatalogName +'%')
		and (isnull(a.WorkName,a.CatalogName) like '%'+@WorkName+'%')
		order by a.CreateDateTime desc,d.OrderNO,d.SchoolType desc,e.OrderNO,e.GradeValue,a.ClassName,b.StudentName
		
	end else begin
	
		select a.WorkID,a.SchoolName,a.GradeName,a.ClassName,
		case when isnull(a.WorkName,'') = '' then a.CatalogName else a.WorkName end as WorkName,
		c.ReviewValue,c.SubjectiveReviews,
		a.StudentID,b.StudentName,
		a.WorkStatus,a.CreateDateTime
		from tblSFITStudentWorks a
		inner join tblSFITStudents b
		on b.StudentID = a.StudentID
		left outer join tblSFITeaReviewStudent c
		on c.WorkID = a.WorkID
		left outer join tblSFITSchools d
		on d.SchoolID = a.SchoolID
		left outer join tblSFITClass e
		on e.ClassID = a.ClassID
		where (a.StudentID = @StudentID)
		and (a.SchoolName like '%'+ @UnitName + '%')
		and (a.GradeName like '%'+ @GradeName +'%')
		and (a.ClassName like '%'+ @ClassName +'%')
		and (a.CatalogName like '%'+ @CatalogName +'%')
		and (isnull(a.WorkName,a.CatalogName) like '%'+@WorkName+'%')
		order by a.CreateDateTime desc,d.OrderNO,d.SchoolType desc,e.OrderNO,e.GradeValue,a.ClassName,b.StudentName
			
	end
end
go
-------------------------------------------------------------------------------------------------------------------
