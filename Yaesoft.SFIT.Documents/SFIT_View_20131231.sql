/*
//================================================================================
//  FileName: SFIT_View_20131231.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-12-31
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================*/
--学生作业视图
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwSFITStudentWorks')
begin
	print 'drop view vwSFITStudentWorks'
	drop view vwSFITStudentWorks
end
go
	print 'create view vwSFITStudentWorks'
go
create view vwSFITStudentWorks
as
	select a.SchoolName,a.SchoolID,a.GradeName,a.GradeID,
	(case when isnull(b.ClassName,'') = '' then a.ClassName else b.ClassName end) + '['+ cast(b.JoinYear as nvarchar(4))  +']' as ClassName,a.ClassID,
	a.CatalogName,a.CatalogID,
	c.StudentName,a.StudentID,
	a.WorkStatus,a.WorkType,a.WorkName,a.WorkID,a.CheckCode,
	case when isnull(d.ReviewValue,'') = '' then  'D-' else d.ReviewValue end as ReviewValue,
	isnull(d.SubjectiveReviews,'') as SubjectiveReviews,isnull(a.Hits,0) as Hits,
	a.CreateEmployeeID,a.CreateEmployeeName,a.WorkDescription,a.CreateDateTime
	
	from tblSFITStudentWorks a
	left outer join tblSFITClass b
	on b.ClassID = a.ClassID
	left outer join tblSFITStudents c
	on c.StudentID = a.StudentID
	left outer join tblSFITeaReviewStudent d
	on d.WorkID = a.WorkID
go
-------------------------------------------------------------------------------------