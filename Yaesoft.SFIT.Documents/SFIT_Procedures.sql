/*
//================================================================================
//  FileName: SFIT_Procedures.sql
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
--删除客观评价。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITDeleteEvaluate')
begin
	print 'drop procedure spSFITDeleteEvaluate'
	drop procedure spSFITDeleteEvaluate
end
go
	print 'create procedure spSFITDeleteEvaluate'
go
create procedure spSFITDeleteEvaluate
(
	@EvaluateID		GUIDEx--评价ID。
)
as
begin
	declare @result			nvarchar(256)
	declare @EvaluateName	nvarchar(128)
	declare @resultCode		int
	set @resultCode = 0
	set @result = ''
	
	select top 1 @EvaluateName = EvaluateName
	from tblSFITEvaluate where EvaluateID = @EvaluateID
	------------------------------------------------------------------
	--tblSFITEvaluateSet
	if exists(select 0 from tblSFITEvaluateSet where EvaluateID = @EvaluateID)
	begin
		set @resultCode = -1
		set @result = '评价规则['+ @EvaluateName +']已经被应用。'
	end
	------------------------------------------------------------------
	--删除数据。
	if(@resultCode = 0)
	begin
		delete from tblSFITEvaluateItems where EvaluateID = @EvaluateID
		delete from tblSFITEvaluate where EvaluateID = @EvaluateID
	end
	----返回数据。
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
----------------------------------------------------------------------------------------------------
--客观评价规则应用列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITEvaluateSetListView')
begin
	print 'drop procedure spSFITEvaluateSetListView'
	drop procedure spSFITEvaluateSetListView
end
go
	print 'create procedure spSFITEvaluateSetListView'
go
create procedure spSFITEvaluateSetListView
(
	@GradeID		GUIDEx,--年级ID。
	@EvaluateName	nvarchar(32)--客观评价名称。
)
as
begin
	if(isnull(@GradeID,'') <> '')
	begin
		
		select a.GradeID, b.GradeName + '['+ b.GradeCode + ']' as GradeName,
		a.EvaluateID,c.EvaluateName,c.EvaluateType,a.ModifyTime
		from tblSFITEvaluateSet a
		inner join tblSFITGrade b
		on b.GradeID = a.GradeID
		inner join tblSFITEvaluate c
		on c.EvaluateID = a.EvaluateID
		where a.GradeID = @GradeID and (c.EvaluateName like '%'+@EvaluateName+'%')
		order by b.OrderNO,b.GradeName,c.OrderNO,a.ModifyTime desc
		
	end else begin
	
		select a.GradeID,b.GradeName + '['+ b.GradeCode + ']' as GradeName,
		a.EvaluateID,c.EvaluateName,c.EvaluateType,a.ModifyTime
		from tblSFITEvaluateSet a
		inner join tblSFITGrade b
		on b.GradeID = a.GradeID
		inner join tblSFITEvaluate c
		on c.EvaluateID = a.EvaluateID
		where (c.EvaluateName like '%'+@EvaluateName+'%')
		order by b.OrderNO,b.GradeName,c.OrderNO,a.ModifyTime desc

	end
end
go
----------------------------------------------------------------------------------------------------
--获取知识技能要点列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITKnowledgePointsListView')
begin
	print 'drop procedure spSFITKnowledgePointsListView'
	drop procedure spSFITKnowledgePointsListView
end
go
	print 'create procedure spSFITKnowledgePointsListView'
go
create procedure spSFITKnowledgePointsListView
(
	@TopPointID		GUIDEx,--顶级要点ID。
	@GradeID		GUIDEx,--年级ID。
	@PointName		nvarchar(128)--要点名称。
)
as
begin
	if(isnull(@TopPointID,'') <> '')
	begin
	
		select '' as GradeName, a.ParentPointID,a.PointID,a.PointCode,a.PointName,a.Description
		from dbo.fnSFITKnowledgePointsGetOffSprings('',@TopPointID,1) a
		where (a.PointCode like '%'+@PointName+'%' or a.PointName like '%'+@PointName+'%')
		order by a.OrderNO
		
	end else if(isnull(@GradeID,'') <> '')
	begin
	
		select b.GradeName, a.ParentPointID,a.PointID,a.PointCode,a.PointName,a.Description
		from tblSFITKnowledgePoints a
		left outer join tblSFITGrade b
		on b.GradeID = a.GradeID
		where (isnull(a.ParentPointID,'') = '') 
		and (a.GradeID = @GradeID)
		and (a.PointCode like '%'+@PointName+'%' or a.PointName like '%'+@PointName+'%')
		order by b.OrderNO,b.LearnLevel desc,b.GradeName, a.OrderNO
	
	end else begin
	
		select b.GradeName, a.ParentPointID,a.PointID,a.PointCode,a.PointName,a.Description
		from tblSFITKnowledgePoints a
		left outer join tblSFITGrade b
		on b.GradeID = a.GradeID
		where (isnull(a.ParentPointID,'') = '') 
		and (a.PointCode like '%'+@PointName+'%' or a.PointName like '%'+@PointName+'%')
		order by b.OrderNO,b.LearnLevel desc,b.GradeName, a.OrderNO
		
	end
end
go
----------------------------------------------------------------------------------------------------
--绑定知识技能要点。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITBindKnowledgePoints')
begin
	print 'drop procedure spSFITBindKnowledgePoints'
	drop procedure spSFITBindKnowledgePoints
end
go
	print 'create procedure spSFITBindKnowledgePoints'
go
create procedure spSFITBindKnowledgePoints
(
	@GradeID		GUIDEx,--年级ID。
	@ParentPointID	GUIDEx--父知识要点ID。
)
as
begin
	if(isnull(@GradeID,'') <> '')
	begin
	
		select ParentPointID,PointID, '(' + PointCode + ')' + PointName as PointNameCode, OrderNO 
		from dbo.fnSFITKnowledgePointsGetOffSprings(@GradeID,@ParentPointID,1)
		
	end else if(isnull(@ParentPointID,'') <> '')
	begin
		
		select ParentPointID,PointID, '(' + PointCode + ')' + PointName as PointNameCode, OrderNO 
		from dbo.fnSFITKnowledgePointsGetOffSprings(@GradeID,@ParentPointID,1)
	
	end else begin
		
		select ParentPointID,PointID, '(' + PointCode + ')' + PointName as PointNameCode, OrderNO 
		from tblSFITKnowledgePoints
	
	end
end
go
----------------------------------------------------------------------------------------------------
--删除知识技能要点。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITDeleteKnowledgePoints')
begin
	print 'drop procedure spSFITDeleteKnowledgePoints'
	drop procedure spSFITDeleteKnowledgePoints
end
go
	print 'create procedure spSFITDeleteKnowledgePoints'
go
create procedure spSFITDeleteKnowledgePoints
(
	@PointID	GUIDEx--要点ID。
)
as
begin
	declare @result			nvarchar(256)
	declare @PointName	nvarchar(128)
	declare @resultCode		int
	set @resultCode = 0
	set @result = ''
	------------------------------------------------------------------
	select top 1 @PointName = PointName
	from tblSFITKnowledgePoints where PointID = @PointID
	------------------------------------------------------------------
	--tblSFITCatalogKnowledgePoints
	if exists(select 0 from tblSFITCatalogKnowledgePoints where PointID = @PointID)
	begin
		set @resultCode = -1
		set @result = '['+ @PointName + ']已被目录应用，请先将其删除！'
	end
	------------------------------------------------------------------
	--删除数据。
	if(@resultCode = 0)
	begin
		--定义父要点ID。
		declare @ParentPointID nvarchar(64)
		select @ParentPointID = ParentPointID
		from tblSFITKnowledgePoints where PointID = @PointID 
		---
		if(isnull(@ParentPointID,'') <> '')--当前节点的父节点不是根节点。
		begin
			if exists(select 0 from tblSFITKnowledgePoints where ParentPointID = @PointID)
			begin
				--当前节点有子节点。
				update tblSFITKnowledgePoints 
				set ParentPointID = @ParentPointID
				where ParentPointID = @PointID
			end
			--删除数据。
			delete from tblSFITKnowledgePoints where PointID = @PointID
		end else begin--当前节点的父节点是根节点。
			if exists(select 0 from tblSFITKnowledgePoints where ParentPointID = @PointID)
			begin
				--当前节点有子节点。
				set @resultCode = -1
				set @result = '请先将子要点删除！'
			end else begin
				--当前节点没有有子节点。
				--删除数据。
				delete from tblSFITKnowledgePoints where PointID = @PointID
			end
		end
	end
	----返回数据。
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
----------------------------------------------------------------------------------------------------
--课程目录列表（学校）。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITCatalogByUnitListView')
begin
	print 'drop procedure spSFITCatalogByUnitListView'
	drop procedure spSFITCatalogByUnitListView
end
go
	print 'create procedure spSFITCatalogByUnitListView'
go
create procedure spSFITCatalogByUnitListView
(
	@UnitID			nvarchar(64),--学校单位ID。
	@GradeID		nvarchar(64),--年级ID。
	@CatalogName	nvarchar(128)--课程目录名称。
)
as
begin
	if(isnull(@GradeID,'') <> '')
	begin
		
		select isnull(c.SchoolName,'[全区必修]') as SchoolName,b.GradeName,
		a.CatalogID,a.CatalogCode,a.CatalogName,a.CatalogType,a.CreateEmployeeName,a.LastModifyTime
		from tblSFITCatalog a
		inner join tblSFITGrade b
		on b.GradeID = a.GradeID
		left outer join tblSFITSchools c
		on c.SchoolID = a.SchoolID
		where isnull(c.SchoolID,@UnitID) = @UnitID
		and (a.GradeID = @GradeID)  
		and ((a.CatalogCode like '%'+@CatalogName+'%') or (a.CatalogName like '%'+@CatalogName+'%'))
		order by c.OrderNO, c.SchoolType desc,c.SchoolName,b.OrderNO,b.GradeValue,b.GradeName,
		 a.OrderNO,a.CatalogName
		 
	end else begin
		
		select isnull(c.SchoolName,'[全区必修]') as SchoolName,b.GradeName,
		a.CatalogID,a.CatalogCode,a.CatalogName,a.CatalogType,a.CreateEmployeeName,a.LastModifyTime
		from tblSFITCatalog a
		inner join tblSFITGrade b
		on b.GradeID = a.GradeID
		left outer join tblSFITSchools c
		on c.SchoolID = a.SchoolID
		where isnull(c.SchoolID,@UnitID) = @UnitID
		and ((a.CatalogCode like '%'+@CatalogName+'%') or (a.CatalogName like '%'+@CatalogName+'%'))
		order by c.OrderNO, c.SchoolType desc,c.SchoolName,b.OrderNO,b.GradeValue,b.GradeName,
		 a.OrderNO,a.CatalogName
		 
	end
end
go
----------------------------------------------------------------------------------------------------
--课程目录列表（教育局）。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITCatalogListView')
begin
	print 'drop procedure spSFITCatalogListView'
	drop procedure spSFITCatalogListView
end
go
	print 'create procedure spSFITCatalogListView'
go
create procedure spSFITCatalogListView
(
	@SchoolName		nvarchar(50),--学校名称。
	@GradeID		GUIDEx,--年级ID。
	@CatalogName	nvarchar(128)--课程目录名称。
)
as
begin
	if(isnull(@GradeID,'') <> '')
	begin
		
		select isnull(c.SchoolName,'[全区必修]') as SchoolName,b.GradeName,
		a.CatalogID,a.CatalogCode,a.CatalogName,a.CatalogType,a.CreateEmployeeName,a.LastModifyTime
		from tblSFITCatalog a
		inner join tblSFITGrade b
		on b.GradeID = a.GradeID
		left outer join tblSFITSchools c
		on c.SchoolID = a.SchoolID
		where (a.GradeID = @GradeID)  
		and ((a.CatalogCode like '%'+@CatalogName+'%') or (a.CatalogName like '%'+@CatalogName+'%'))
		and ((isnull(c.SchoolCode,'') like '%'+@SchoolName+'%') or (isnull(c.SchoolName,'') like '%'+@SchoolName+'%'))
		order by c.OrderNO, c.SchoolType desc,c.SchoolName,b.OrderNO,b.GradeValue,b.GradeName,
		 a.OrderNO,a.CatalogName
		 
	end else begin
		
		select isnull(c.SchoolName,'[全区必修]') as SchoolName,b.GradeName,
		a.CatalogID,a.CatalogCode,a.CatalogName,a.CatalogType,a.CreateEmployeeName,a.LastModifyTime
		from tblSFITCatalog a
		inner join tblSFITGrade b
		on b.GradeID = a.GradeID
		left outer join tblSFITSchools c
		on c.SchoolID = a.SchoolID
		where ((a.CatalogCode like '%'+@CatalogName+'%') or (a.CatalogName like '%'+@CatalogName+'%'))
		and ((isnull(c.SchoolCode,'') like '%'+@SchoolName+'%') or (isnull(c.SchoolName,'') like '%'+@SchoolName+'%'))
		order by c.OrderNO, c.SchoolType desc,c.SchoolName,b.OrderNO,b.GradeValue,b.GradeName,
		 a.OrderNO,a.CatalogName
		 
	end
end
go
----------------------------------------------------------------------------------------------------
--删除课程目录。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITDeleteCatalog')
begin
	print 'drop procedure spSFITDeleteCatalog'
	drop procedure spSFITDeleteCatalog
end
go
	print 'create procedure spSFITDeleteCatalog'
go
create procedure spSFITDeleteCatalog
(
	@CatalogID	GUIDEx--目录ID。
)
as
begin
	declare @result			nvarchar(256)
	declare @CatalogName	nvarchar(128)
	declare @resultCode		int
	set @resultCode = 0
	set @result = ''
	---------------------------------------------------------------
	select top 1 @CatalogName = CatalogName
	from tblSFITCatalog where CatalogID = @CatalogID
	---------------------------------------------------------------
	--tblSFITSchoolSetCatalog
	if exists(select 0 from tblSFITSchoolSetCatalog where CatalogID = @CatalogID)
	begin
		set @resultCode = -1
		set @result = '课程目录['+@CatalogName+']下已设置作品提交时间段。'
	end
	---------------------------------------------------------------
	--tblSFITStudentWorks
	if exists(select 0 from tblSFITStudentWorks where CatalogID = @CatalogID)
	begin
		set @resultCode = -1
		set @result = '课程目录['+@CatalogName+']下已有学生作品。'
	end
	---------------------------------------------------------------
	--删除数据。
	if(@resultCode = 0)
	begin
		--删除目录与知识要点的关联。
		delete from tblSFITCatalogKnowledgePoints where CatalogID = @CatalogID
		--删除目录数据。
		delete from tblSFITCatalog where CatalogID = @CatalogID
	end
	----返回数据。
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------
--删除学校数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITDeleteSchools')
begin
	print 'drop procedure spSFITDeleteSchools'
	drop procedure spSFITDeleteSchools
end
go
	print 'create procedure spSFITDeleteSchools'
go
create procedure spSFITDeleteSchools
(
	@SchoolID	GUIDEx--学校ID。
)
as
begin
	declare @result			nvarchar(256)
	declare @SchoolName		nvarchar(128)
	declare @resultCode		int
	set @resultCode = 0
	set @result = ''
	------------------------------------------------------------------
	select top 1 @SchoolName = SchoolName
	from tblSFITSchools where SchoolID = @SchoolID
	------------------------------------------------------------------
	--tblSFITeachers
	if exists(select 0 from tblSFITeachers where SchoolID = @SchoolID)
	begin
		set @resultCode = -1
		set @result = '学校['+ @SchoolName +']下已经有教师数据。'
	end
	------------------------------------------------------------------
	--tblSFITClass
	if exists(select 0 from tblSFITClass where SchoolID = @SchoolID)
	begin
		set @resultCode = -1
		set @result = '学校['+ @SchoolName +']下已经有班级数据。'
	end
	------------------------------------------------------------------
	--tblSFITCenterAccess
	if exists(select 0 from tblSFITCenterAccess where SchoolID = @SchoolID)
	begin
		set @resultCode = -1
		set @result = '学校['+ @SchoolName +']下已经有接入管理数据。'
	end
	------------------------------------------------------------------
	--tblSFITCatalog
	if exists(select 0 from tblSFITCatalog where SchoolID = @SchoolID)
	begin
		set @resultCode = -1
		set @result = '学校['+ @SchoolName +']下已经有课程目录数据。'
	end
	------------------------------------------------------------------
	--tblSFITSchoolSetCatalog
	if exists(select 0 from tblSFITSchoolSetCatalog where SchoolID = @SchoolID)
	begin
		set @resultCode = -1
		set @result = '学校['+ @SchoolName +']下已经有课程目录作品提交时间段数据。'
	end
	------------------------------------------------------------------
	--删除数据。
	if(@resultCode = 0)
	begin
		delete from tblSFITSchools where SchoolID = @SchoolID
	end
	----返回数据。
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------
--删除年级数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITDeleteGrade')
begin
	print 'drop procedure spSFITDeleteGrade'
	drop procedure spSFITDeleteGrade
end
go
	print 'create procedure spSFITDeleteGrade'
go
create procedure spSFITDeleteGrade
(
	@GradeID	GUIDEx--年级ID。
)
as
begin
	declare @result			nvarchar(256)
	declare @GradeName		nvarchar(128)
	declare @resultCode		int
	set @resultCode = 0
	set @result = ''
	------------------------------------------------------------------
	select top 1 @GradeName = GradeName
	from tblSFITGrade where GradeID = @GradeID
	------------------------------------------------------------------
	--tblSFITGradeClass
	--if exists(select 0 from tblSFITGradeClass where GradeID = @GradeID)
	--begin
	--	set @resultCode = -1
	--	set @result = '['+ @GradeName +']下已有班级数据。'
	--end
	------------------------------------------------------------------
	--tblSFITCatalog
	if exists(select 0 from tblSFITCatalog where GradeID = @GradeID)
	begin
		set @resultCode = -1
		set @result = '['+ @GradeName +']下已有课程目录数据。'
	end
	------------------------------------------------------------------
	--tblSFITEvaluateSet
	if exists(select 0 from tblSFITEvaluateSet where GradeID = @GradeID)
	begin
		set @resultCode = -1
		set @result = '['+ @GradeName +']下已设置客观评价方式。'
	end
	------------------------------------------------------------------
	--删除数据。
	if(@resultCode = 0)
	begin
		delete from tblSFITGrade where GradeID = @GradeID
	end
	----返回数据。
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
----------------------------------------------------------------------------------------------------
--教师信息列表数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITeachersListView')
begin
	print 'drop procedure spSFITeachersListView'
	drop procedure spSFITeachersListView
end
go
	print 'create procedure spSFITeachersListView'
go
create procedure spSFITeachersListView
(
	@SchoolID		GUIDEx,--学校名称。
	@TeacherName	nvarchar(256)--教师名称。
)
as
begin
	if(isnull(@SchoolID,'') = '')
	begin
	
		select data.TeacherID,data.TeacherCode,data.TeacherName,b.SchoolName,
		data.SyncStatus,data.LastSyncTime
		from tblSFITeachers data
		inner join tblSFITSchools b
		on b.SchoolID = data.SchoolID
		where (data.TeacherName like '%'+@TeacherName+'%')
		order by b.OrderNO,b.SchoolType desc,b.SchoolName, data.TeacherName
	
	end else begin

		select data.TeacherID,data.TeacherCode,data.TeacherName,b.SchoolName,
		data.SyncStatus,data.LastSyncTime
		from tblSFITeachers data
		inner join tblSFITSchools b
		on b.SchoolID = data.SchoolID
		where (data.SchoolID = @SchoolID) and (data.TeacherName like '%'+@TeacherName+'%')
		order by b.OrderNO,b.SchoolType desc, b.SchoolName,data.TeacherName
	
	end
end
go
----------------------------------------------------------------------------------------------------
--绑定教师数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITBindTeachers')
begin
	print 'drop procedure spSFITBindTeachers'
	drop procedure spSFITBindTeachers
end
go
	print 'create procedure spSFITBindTeachers'
go
create procedure spSFITBindTeachers
(
	@schoolName		nvarchar(64),--学校名称。
	@teacherName	nvarchar(64)--教师名称。
)
as
begin
		select data.TeacherID,data.TeacherCode,data.TeacherName
		from tblSFITeachers data
		inner join tblSFITSchools b
		on b.SchoolID = data.SchoolID
		where (b.SchoolName like '%'+@schoolName+'%') 
		and (data.TeacherName like '%'+@TeacherName+'%')
end
go
----------------------------------------------------------------------------------------------------
--删除教师数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITDeleteTeachers')
begin
	print 'drop procedure spSFITDeleteTeachers'
	drop procedure spSFITDeleteTeachers
end
go
	print 'create procedure spSFITDeleteTeachers'
go
create procedure spSFITDeleteTeachers
(
	@TeacherID	GUIDEx --教师ID。
)
as
begin
	declare @result			nvarchar(256)
	declare @TeacherName	nvarchar(128)
	declare @resultCode		int
	set @resultCode = 0
	set @result = ''
	------------------------------------------------------------------
	select top 1 @TeacherName = TeacherName
	from tblSFITeachers where TeacherID = @TeacherID
	------------------------------------------------------------------
	--tblSFITTeaClass
	if exists(select 0 from tblSFITTeaClass where TeacherID = @TeacherID)
	begin
		set @resultCode = -1
		set @result = '['+ @TeacherName +']教师已分配班级数据。'
	end
	------------------------------------------------------------------
	--tblSFITeaReviewStudent
	if exists(select 0 from tblSFITeaReviewStudent where TeacherID = @TeacherID)
	begin
		set @resultCode = -1
		set @result = '['+ @TeacherName +']教师已有评阅数据。'
	end
	------------------------------------------------------------------
	--删除数据。
	if(@resultCode = 0)
	begin
		delete from tblSFITeachers where TeacherID = @TeacherID
	end
	----返回数据。
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------
--班级信息列表数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITClassListView')
begin
	print 'drop procedure spSFITClassListView'
	drop procedure spSFITClassListView
end
go
	print 'create procedure spSFITClassListView'
go
create procedure spSFITClassListView
(
	@SchoolName		nvarchar(50),--学校ID。
	@GradeID		GUIDEx,--年级ID。
	@ClassName		nvarchar(256)--班级名称。
)
as
begin
	if(isnull(@GradeID,'') <> '')
	begin
	
		select b.SchoolName,
		a.GradeName + '['+ a.GradeCode + ']' as GradeName,
		a.ClassID,a.ClassCode,a.ClassName,a.JoinYear,a.GradeValue,a.LearnLevel,
		a.SyncStatus,a.LastSyncTime
		from vwSFITGradeClass a
		inner join tblSFITSchools b
		on b.SchoolID = a.SchoolID
		where (a.GradeID = @GradeID) and (b.SchoolName like '%'+@SchoolName+'%') and (a.ClassName like '%'+@ClassName+'%')
		order by b.OrderNO,b.SchoolType desc,b.SchoolName,a.OrderNO,a.ClassName
		
	end else begin
		
		select b.SchoolName,
		a.GradeName + '['+ a.GradeCode + ']' as GradeName,
		a.ClassID,a.ClassCode,a.ClassName,a.JoinYear,a.GradeValue,a.LearnLevel,
		a.SyncStatus,a.LastSyncTime
		from vwSFITGradeClass a
		inner join tblSFITSchools b
		on b.SchoolID = a.SchoolID
		where (b.SchoolName like '%'+@SchoolName+'%') and (a.ClassName like '%'+@ClassName+'%')
		order by b.OrderNO,b.SchoolType desc,b.SchoolName,a.OrderNO,a.ClassName
			
	end
end
go
----------------------------------------------------------------------------------------------------
--删除班级数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITDeleteClass')
begin
	print 'drop procedure spSFITDeleteClass'
	drop procedure spSFITDeleteClass
end
go
	print 'create procedure spSFITDeleteClass'
go
create procedure spSFITDeleteClass
(
	@ClassID	GUIDEx--班级ID。
)
as
begin
	declare @result			nvarchar(256)
	declare @ClassName		nvarchar(128)
	declare @resultCode		int
	set @resultCode = 0
	set @result = ''
	------------------------------------------------------------------
	select top 1 @ClassName = ClassName
	from tblSFITClass where ClassID = @ClassID
	------------------------------------------------------------------
	--tblSFITClassStudents
	if exists(select 0 from tblSFITClassStudents where ClassID = @ClassID)
	begin
		set @resultCode = -1
		set @result = '['+ @ClassName +']已有学生数据。'
	end
	------------------------------------------------------------------
	--tblSFITTeaClass
	if exists(select 0 from tblSFITTeaClass where ClassID = @ClassID)
	begin
		set @resultCode = -1
		set @result = '['+ @ClassName +']已分配任课教师数据。'
	end
	------------------------------------------------------------------
	--删除数据。
	if(@resultCode = 0)
	begin
		delete from tblSFITClass where ClassID = @ClassID
	end
	----返回数据。
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------
--学生信息列表数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITStudentsListView')
begin
	print 'drop procedure spSFITStudentsListView'
	drop procedure spSFITStudentsListView
end
go
	print 'create procedure spSFITStudentsListView'
go
create procedure spSFITStudentsListView
(
	@SchoolName		nvarchar(50),--学校名称。
	@GradeName		nvarchar(50),--年级名称。
	@ClassName		nvarchar(50),--班级名称。
	@StudentName	nvarchar(256)--学生姓名。
)
as
begin
	select d.SchoolName,c.GradeName,b.ClassID,c.ClassName,
	a.StudentID,a.StudentCode,a.StudentName,a.Gender,a.JoinYear,a.IDNumber,a.SyncStatus,a.LastSyncTime
	from tblSFITStudents a
	left outer join tblSFITClassStudents b
	on b.StudentID = a.StudentID
	left outer join vwSFITGradeClass c
	on c.ClassID = b.ClassID
	left outer join tblSFITSchools d
	on d.SchoolID = c.SchoolID
	where ((isnull(d.SchoolName,'') like '%'+@SchoolName+'%') or (isnull(d.SchoolCode,'') like '%'+@SchoolName+'%')) 
	and ((isnull(c.GradeName,'') like '%'+@GradeName+'%') or (isnull(c.GradeCode,'') like '%'+@GradeName+'%'))
	and ((isnull(c.ClassName,'') like '%'+@ClassName+'%') or (isnull(c.ClassCode,'') like '%'+@ClassName+'%'))
	and ((isnull(a.StudentName,'') like '%'+@StudentName+'%') or (isnull(a.StudentCode,'') like '%'+@StudentName+'%'))
	
	order by d.OrderNO,d.SchoolType desc,d.SchoolName,c.GradeName,c.OrderNO,c.ClassName,a.StudentName
end
go
----------------------------------------------------------------------------------------------------
--Picker学生信息。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITStudentsPickerView')
begin
	print 'drop procedure spSFITStudentsPickerView'
	drop procedure spSFITStudentsPickerView
end
go
	print 'create procedure spSFITStudentsPickerView'
go
create procedure spSFITStudentsPickerView
(
	@UnitID			GUIDEx,--所属学校ID。
	@ClassName		nvarchar(128),--所属班级名称。
	@StudentName	nvarchar(128)--所属学生名称。
)
as
begin
	select a.StudentID,b.StudentCode,b.StudentName,b.Gender,
	d.SchoolName,c.ClassName
	from tblSFITClassStudents a
	inner join tblSFITStudents b
	on b.StudentID = a.StudentID
	inner join vwSFITGradeClass c
	on c.ClassID = a.ClassID
	left outer join tblSFITSchools d
	on d.SchoolID = c.SchoolID
	where (isnull(c.SchoolID,@UnitID) = @UnitID)
	and ((c.ClassName like '%'+@ClassName+'%') or (c.ClassCode like '%'+@ClassName+'%'))
	and ((b.StudentName like '%'+@StudentName+'%') or (b.StudentCode like '%'+@StudentName+'%'))
	order by isnull(d.OrderNO,0),isnull(c.OrderNO,0),b.StudentCode
end
go
----------------------------------------------------------------------------------------------------
--删除学生信息数据。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITDeleteStudents')
begin
	print 'drop procedure spSFITDeleteStudents'
	drop procedure spSFITDeleteStudents
end
go
	print 'create procedure spSFITDeleteStudents'
go
create procedure spSFITDeleteStudents
(
	@ClassID	GUIDEx,--班级ID。
	@StudentID	GUIDEx--学生ID。
)
as
begin
	declare @result			nvarchar(256)
	declare @StudentName	nvarchar(128)
	declare @resultCode		int
	set @resultCode = 0
	set @result = ''
	------------------------------------------------------------------
	select top 1 @StudentName = StudentName
	from tblSFITStudents where StudentID = @StudentID
	------------------------------------------------------------------
	--tblSFITStudentWorks
	if exists(select 0 from tblSFITStudentWorks where StudentID = @StudentID)
	begin
		set @resultCode = -1
		set @result = '['+ @StudentName +']已有作品数据。' 
	end
	------------------------------------------------------------------
	--删除数据。
	if(@resultCode = 0)
	begin
		delete from tblSFITClassStudents where StudentID = @StudentID and ClassID = @ClassID
		delete from tblSFITStudents where StudentID = @StudentID
	end
	----返回数据。
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------
--任课教师/班级数据(教育局)列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITTeaClassListView')
begin
	print 'drop procedure spSFITTeaClassListView'
	drop procedure spSFITTeaClassListView
end
go
	print 'create procedure spSFITTeaClassListView'
go
create procedure spSFITTeaClassListView
(
	@SchoolName		nvarchar(128),--学校名称。
	@TeacherName	nvarchar(128),--教师名称。
	@ClassName		nvarchar(128)--班级名称。
)
as
begin
	declare @v_table table(TeacherID	nvarchar(32) primary key,--教师ID。
						   ClassName	nvarchar(2048))
	------------------------------------------------------------------
	if exists(select 0 from tblSFITTeaClass)
	begin
		declare @strTeacherID		nvarchar(32)
		declare @strOldTeacherID	nvarchar(32)
		declare @strClassName	nvarchar(256)
		declare @strName		nvarchar(2048)
		
		--定义游标。
		declare TeaClass_Cursor cursor for
		select a.TeacherID,d.ClassName
		from tblSFITTeaClass a
		inner join tblSFITeachers b
		on b.TeacherID = a.TeacherID
		inner join tblSFITSchools c
		on c.SchoolID = b.SchoolID
		inner join tblSFITClass d
		on d.ClassID = a.ClassID
		where ((isnull(c.SchoolName,'') like '%'+@SchoolName+'%') or (isnull(c.SchoolCode,'') like '%'+@SchoolName+'%'))
		  and ((isnull(b.TeacherName,'') like '%'+@TeacherName+'%') or (isnull(b.TeacherCode,'') like '%'+@TeacherName+'%'))
		  and ((isnull(d.ClassName,'') like '%'+@ClassName+'%') or (isnull(d.ClassCode,'') like '%'+@ClassName+'%'))
		order by a.TeacherID,d.ClassName
		
		--打开游标。
		open TeaClass_Cursor
		fetch next from TeaClass_Cursor into @strTeacherID,@strClassName
		
		set @strName = ''
		set @strOldTeacherID = ''
		--叠加数据。
		while(@@fetch_status = 0)
		begin
			if((@strTeacherID <> @strOldTeacherID) and (isnull(@strOldTeacherID,'') <> ''))
			begin
				insert into @v_table(TeacherID,ClassName) values(@strOldTeacherID,@strName)
				set @strName = ''
			end
			
			if(isnull(@strName,'') = '')
			begin
				set @strName = @strClassName
			end else begin
				set @strName = @strName + ',' + @strClassName
			end
			
			set @strOldTeacherID = @strTeacherID
			
			--下一条数据。
			fetch next from TeaClass_Cursor into @strTeacherID,@strClassName
		end
		--关闭游标。
		close TeaClass_Cursor
		deallocate TeaClass_Cursor
		--最后一条数据插入处理。
		insert into @v_table(TeacherID,ClassName) values(@strOldTeacherID,@strName)
	end
	------------------------------------------------------------------
	--输出数据。
	select c.SchoolName,a.TeacherID,b.TeacherCode,b.TeacherName, a.ClassName
	from @v_table a
	inner join tblSFITeachers b
	on b.TeacherID = a.TeacherID
	inner join tblSFITSchools c
	on c.SchoolID = b.SchoolID
	where a.ClassName like '%'+@ClassName+'%'
	order by c.OrderNO,c.SchoolType desc,c.SchoolName,b.TeacherName
end
go
----------------------------------------------------------------------------------------------------
--任课教师/班级数据(学校单位)列表。
if exists(select 0 from sysobjects where  xtype = 'p' and name = 'spSFITTeaClassByUnitListView')
begin
	print 'drop procedure spSFITTeaClassByUnitListView'
	drop procedure spSFITTeaClassByUnitListView
end
go
create procedure spSFITTeaClassByUnitListView
(
	@SchoolID	nvarchar(128),--学校单位ID。
	@TeacherName	nvarchar(128),--教师名称。
	@ClassName		nvarchar(128)--班级名称。
)
as
begin
	declare @v_table table(TeacherID	nvarchar(32) primary key,--教师ID。
						   ClassName	nvarchar(2048))
	------------------------------------------------------------------
	if exists(select 0 from tblSFITTeaClass)
	begin
		declare @strTeacherID		nvarchar(32)
		declare @strOldTeacherID	nvarchar(32)
		declare @strClassName	nvarchar(256)
		declare @strName		nvarchar(2048)
		
		--定义游标。
		declare TeaClass_Cursor cursor for
		select a.TeacherID,d.ClassName
		from tblSFITTeaClass a
		inner join tblSFITeachers b
		on b.TeacherID = a.TeacherID
		inner join tblSFITSchools c
		on c.SchoolID = b.SchoolID
		inner join tblSFITClass d
		on d.ClassID = a.ClassID
		where (b.SchoolID = @SchoolID)
		  and ((isnull(b.TeacherName,'') like '%'+@TeacherName+'%') or (isnull(b.TeacherCode,'') like '%'+@TeacherName+'%'))
		  and ((isnull(d.ClassName,'') like '%'+@ClassName+'%') or (isnull(d.ClassCode,'') like '%'+@ClassName+'%'))
		order by a.TeacherID,d.ClassName
		
		--打开游标。
		open TeaClass_Cursor
		fetch next from TeaClass_Cursor into @strTeacherID,@strClassName
		
		set @strName = ''
		set @strOldTeacherID = ''
		--叠加数据。
		while(@@fetch_status = 0)
		begin
			if((@strTeacherID <> @strOldTeacherID) and (isnull(@strOldTeacherID,'') <> ''))
			begin
				insert into @v_table(TeacherID,ClassName) values(@strOldTeacherID,@strName)
				set @strName = ''
			end
			
			if(isnull(@strName,'') = '')
			begin
				set @strName = @strClassName
			end else begin
				set @strName = @strName + ',' + @strClassName
			end
			
			set @strOldTeacherID = @strTeacherID
			
			--下一条数据。
			fetch next from TeaClass_Cursor into @strTeacherID,@strClassName
		end
		--关闭游标。
		close TeaClass_Cursor
		deallocate TeaClass_Cursor
		--最后一条数据插入处理。
		insert into @v_table(TeacherID,ClassName) values(@strOldTeacherID,@strName)
	end
	------------------------------------------------------------------
	--输出数据。
	select c.SchoolName,a.TeacherID,b.TeacherCode,b.TeacherName, a.ClassName
	from @v_table a
	inner join tblSFITeachers b
	on b.TeacherID = a.TeacherID
	inner join tblSFITSchools c
	on c.SchoolID = b.SchoolID
	where a.ClassName like '%'+@ClassName+'%'
	order by c.OrderNO,c.SchoolType desc,c.SchoolName,b.TeacherName
end
go
----------------------------------------------------------------------------------------------------
--作品附件列表。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITStudentAttachmentListView')
begin
	print 'drop procedure spSFITStudentAttachmentListView'
	drop procedure spSFITStudentAttachmentListView
end
go
	print 'create procedure spSFITStudentAttachmentListView'
go
create procedure spSFITStudentAttachmentListView
(
	@WorkID		GUIDEx--作品名称。	
)
as
begin
	select a.AccessoriesID,b.AccessoriesName,b.ContentType,b.AccessoriesSize,b.Suffix
	from tblSFITStudentAttachment a
	inner join tblSFITAccessories b
	on a.AccessoriesID = b.AccessoriesID
	where a.WorkID = @WorkID
end
go
----------------------------------------------------------------------------------------------------------------------