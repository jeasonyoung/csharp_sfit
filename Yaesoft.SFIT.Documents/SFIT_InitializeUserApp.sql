/*
//================================================================================
//  FileName: SFIT_InitializeUserApp.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/9
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
---初始化用户应用系统授权。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSFITInitializeUserApp')
begin
	print 'drop procedure spSFITInitializeUserApp'
	drop procedure spSFITInitializeUserApp
end
go
	print 'create procedure spSFITInitializeUserApp'
go
create procedure spSFITInitializeUserApp
(
	@TeacherCode	nvarchar(32),--教师代码。
	@SystemID		nvarchar(32)--系统代码。
)
as
begin
	declare @teacherID nvarchar(32),@teacherName nvarchar(32), @appID	nvarchar(32)
	--获取教师ID。
	select top 1 @teacherID = teacherID,@teacherName = teacherName
	from tblSFITeachers
	where teacherCode = @TeacherCode
	--获取应用系统授权ID。
	select top 1 @appID = AppAuthID
	from tblSysMgrAppAuthorization
	where SystemID = @SystemID
	--
	if((isnull(@teacherID,'') <> '') and (isnull(@appID,'') <> ''))
	begin
		if(not exists(select 0 from tblSysMgrEmployeeAuthorization where appAuthID = @appID and EmployeeID = @teacherID))
		begin
			insert into tblSysMgrEmployeeAuthorization(appAuthID,EmployeeID,EmployeeName)
			values(@appID,@teacherID,@teacherName)
			
			select '完成授权！'
		end else begin
			select '已经被授权！'
		end
	end else begin
		select '教师代码或系统代码不存在！'
	end
end
go