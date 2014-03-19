/*
//================================================================================
//  FileName: SFIT_Views.sql
//  Desc:
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
----------------------------------------------------------------------------------------------------
--年级班级视图。
if exists(select 0 from sysobjects where xtype = 'v' and name = 'vwSFITGradeClass')
begin
	print 'drop view vwSFITGradeClass'
	drop view vwSFITGradeClass
end
go
	print 'create view vwSFITGradeClass'
go
create view vwSFITGradeClass
as
	select a.SchoolID,b.GradeID,b.GradeCode,b.GradeName,
	a.ClassID,a.ClassCode,a.ClassName,a.JoinYear,a.GradeValue,a.LearnLevel,
	a.SyncStatus,a.LastSyncTime,a.OrderNO
	from tblSFITClass a
	left outer join tblSFITGrade b
	on b.GradeValue = a.GradeValue and b.LearnLevel = a.LearnLevel
go
----------------------------------------------------------------------------------------------------
