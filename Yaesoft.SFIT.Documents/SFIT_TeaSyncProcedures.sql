/*
//================================================================================
//  FileName: SFIT_SyncProcedures.sql
//  Desc:教师同步数据存储过程。
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/26
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
----------------------------------------------------------------------------------------
--获取教师年级数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITeaSyncGrade')
begin
	print 'drop procedure spSFITeaSyncGrade'
	drop procedure spSFITeaSyncGrade
end
go
	print 'create procedure spSFITeaSyncGrade'
go
create procedure spSFITeaSyncGrade
(
	@SchoolID	GUIDEx,--学年学期。
	@TeacherID	GUIDEx --教师ID。
)
as
begin
	select distinct a.GradeID,a.GradeCode,a.GradeName,a.OrderNO
	from tblSFITGrade a
	inner join vwSFITGradeClass b
	on b.GradeID = a.GradeID
	where b.schoolID = @SchoolID 
	and (b.ClassID in (select ClassID from tblSFITTeaClass where TeacherID = @TeacherID))
end
go
----------------------------------------------------------------------------------------
--获取年级下的客观评价数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITeaSyncEvaluate')
begin
	print 'drop procedure spSFITeaSyncEvaluate'
	drop procedure spSFITeaSyncEvaluate
end
go
	print 'create procedure spSFITeaSyncEvaluate'
go
create procedure spSFITeaSyncEvaluate
(
	@GradeID	GUIDEx--年级ID。
)
as
begin
	declare @EvaluateID GUIDEx
	select top 1 @EvaluateID = EvaluateID
	from tblSFITEvaluateSet
	where GradeID = @GradeID
	order by ModifyTime desc

	select EvaluateID,EvaluateName,EvaluateType,MinValue,MaxValue
	from tblSFITEvaluate
	where EvaluateID = @EvaluateID
	order by OrderNO
end
go
----------------------------------------------------------------------------------------
--获取年级和教师ID下的班级信息。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITeaSyncClass')
begin
	print 'drop procedure spSFITeaSyncClass'
	drop procedure spSFITeaSyncClass
end
go
	print 'create procedure spSFITeaSyncClass'
go
create procedure spSFITeaSyncClass
(
	@GradeID	GUIDEx,--年级ID。
	@TeacherID	GUIDEx--教师ID。
)
as
begin
	select distinct a.ClassID,a.ClassCode,a.ClassName,a.OrderNO
	from tblSFITClass a
	inner join tblSFITTeaClass b
	on b.ClassID = a.ClassID
	inner join vwSFITGradeClass c
	on c.ClassID = a.ClassID
	where (a.SyncStatus <> 0x00)
	and (b.TeacherID = @TeacherID)
	and (c.GradeID = @GradeID)
end
go
----------------------------------------------------------------------------------------
--检验教师是否为授课教师
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITVerifyInstructor')
begin
	print 'drop procedure spSFITVerifyInstructor'
	drop procedure spSFITVerifyInstructor
end
go
	print 'create procedure spSFITVerifyInstructor'
go
create procedure spSFITVerifyInstructor
(
	@SchoolID	GUIDEx,--学校ID。
	@TeacherID	GUIDEx --教师ID。
)
as
begin
	declare @temp table(TeaID	nvarchar(32),--教师ID。
					    SchID	nvarchar(32))--学校ID。

	insert into @temp(TeaID,SchID)
	select distinct a.TeacherID,b.SchoolID
	from tblSFITTeaClass a
	inner join tblSFITClass b
	on b.ClassID = a.ClassID
	
	if exists(select 0 from @temp where SchID = @SchoolID and TeaID = @TeacherID)
		select 1
	else
		select 0
end
go
----------------------------------------------------------------------------------------
