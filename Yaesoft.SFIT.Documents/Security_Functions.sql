/*
//================================================================================
//  FileName: Security_Functions.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/3/29
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
----------------------------------------------------------------------------------------------------------------
--返回指定的数据表(tblSecurityRegsiter，tblSecurityModule，tblSecurityRole)中，具有上下级关系的所有子孙。
if exists(select 0 from sysobjects where xtype = 'tf' and name = 'fnSecurityGetOffSprings')
begin
	print 'drop function fnSecurityGetOffSprings'
	drop function fnSecurityGetOffSprings
end
go
	print 'create function fnSecurityGetOffSprings'
go
create function fnSecurityGetOffSprings
(
	@TableName		nvarchar(384),--数据表名称。
	@FieldValue		nvarchar(100),--项目值。
	@IncludeSelf	bit = 0,--是否包含自己。
	@Seperator		nvarchar(10) = '-'--名称连接字符。
)
returns @tableResult table
			(
				FieldID		nvarchar(32) primary key,
				FieldName	nvarchar(256),
				FullName	nvarchar(2048),
				LevelNum	int
			)
as
begin
	declare @v_table table
				(
					FieldID		nvarchar(32) primary key,
					FieldName	nvarchar(256),
					FullName	nvarchar(1024) default null,
					LevelNum	int,
					No			int identity(1,1)
				)
	declare @v_Level int
	set @v_Level = 0
	
	--应用系统注册
	if(@TableName = 'tblSecurityRegsiter')
	begin
		--插入自己（或所有同等级的）。
		insert into @v_table(FieldID,FieldName,FullName,LevelNum)
		select SystemID,SystemName,SystemName,@v_Level
		from tblSecurityRegsiter
		where (SystemID = @FieldValue) or
			  (isnull(@FieldValue,'') = '' and isnull(ParentSystemID,'') = '')
		--循环插入自己的子孙。
		while(@@rowcount > 0)
		begin
			set @v_Level = @v_Level + 1
			
			insert into @v_table(FieldID,FieldName,FullName,LevelNum)
			select data.SystemID,data.SystemName,tmp.FullName + @Seperator + data.SystemName,@v_Level
			from tblSecurityRegsiter data
			inner join @v_table tmp
			on tmp.FieldID = data.ParentSystemID
			where not exists(select 0
						     from @v_table tmp2
						     where tmp2.FieldID = data.SystemID)
		end
	end
	--功能模块
	if(@TableName = 'tblSecurityModule')
	begin
		--插入自己（或所有同等级的）。
		insert into @v_table(FieldID,FieldName,FullName,LevelNum)
		select ModuleID,ModuleName,ModuleName,@v_Level
		from tblSecurityModule
		where (ModuleID = @FieldValue) or
			  (isnull(@FieldValue,'') = '' and isnull(ParentModuleID,'') = '')
		--循环插入自己的子孙。
		while(@@rowcount > 0)
		begin
			set @v_Level = @v_Level + 1
			
			insert into @v_table(FieldID,FieldName,FullName,LevelNum)
			select data.ModuleID,data.ModuleName,tmp.FullName + @Seperator + data.ModuleName,@v_Level
			from tblSecurityModule data
			inner join @v_table tmp
			on tmp.FieldID = data.ParentModuleID
			where not exists(select 0
						     from @v_table tmp2
						     where tmp2.FieldID = data.ModuleID)
		end
	end
	--角色定义
	if(@TableName = 'tblSecurityRole')
	begin
		--插入自己（或所有同等级的）。
		insert into @v_table(FieldID,FieldName,FullName,LevelNum)
		select RoleID,RoleName,RoleName,@v_Level
		from tblSecurityRole
		where (RoleID = @FieldValue) or
			  (isnull(@FieldValue,'') = '' and isnull(ParentRoleID,'') = '')
		--循环插入自己的子孙。
		while(@@rowcount > 0)
		begin
			set @v_Level = @v_Level + 1
			
			insert into @v_table(FieldID,FieldName,FullName,LevelNum)
			select data.RoleID,data.RoleName,tmp.FullName + @Seperator + data.RoleName,@v_Level
			from tblSecurityRole data
			inner join @v_table tmp
			on tmp.FieldID = data.ParentRoleID
			where not exists(select 0
						     from @v_table tmp2
						     where tmp2.FieldID = data.RoleID)
		end
	end
	---
	--剔除自己。
	if(@IncludeSelf = 0)
		delete from @v_table where (FieldID = @FieldValue) or (isnull(@FieldValue,'') = '' and isnull(FieldID,'') = '')
	
	--返回结果数据。
	insert into @tableResult(FieldID,FieldName,FullName,LevelNum)
	select FieldID,FieldName,FullName,LevelNum
	from @v_table
	order by LevelNum,No
	
	return
end
go
----------------------------------------------------------------------------------------------------------------
--叠加角色下的系统名称
if exists(select 0 from sysobjects where xtype = 'fn' and name = 'fnSecurityStackRoleSystemName')
begin
	print 'drop function fnSecurityStackRoleSystemName'
	drop function fnSecurityStackRoleSystemName
end
go
	print 'create function fnSecurityStackRoleSystemName'
go
create function fnSecurityStackRoleSystemName
(
	@RoleID	nvarchar(32) --角色ID。
)
returns nvarchar(2048)
as
begin
	declare @strResult nvarchar(2048)
	declare @strValue nvarchar(256)
	
	declare Role_Cursor cursor for
	select distinct b.SystemName
	from tblSecurityRoleSystem a
	inner join tblSecurityRegsiter b
	on b.SystemID = a.SystemID
	where a.RoleID = @RoleID
 	
	open Role_Cursor 
	fetch next from Role_Cursor into @strValue
	
	while(@@fetch_status = 0)
	begin
		if(isnull(@strResult,'') = '')
			set @strResult = @strValue
		else
			set @strResult = @strResult + ','+ @strValue
		fetch next from Role_Cursor into @strValue
	end
	close Role_Cursor
	deallocate Role_Cursor
	
	return(@strResult)
end
go
----------------------------------------------------------------------------------------------------------------
--获取指定系统和用户下的角色。
if exists(select 0 from sysobjects where xtype = 'tf' and name = 'fnSecurityGetEmployeeRoles')
begin
	print 'drop function fnSecurityGetEmployeeRoles'
	drop function fnSecurityGetEmployeeRoles
end
go
	print 'create function fnSecurityGetEmployeeRoles'
go
create function fnSecurityGetEmployeeRoles
(
	@SystemID	nvarchar(32),--系统ID。
	@EmployeeID	nvarchar(32), --用户ID。
	@DepartmentID	nvarchar(32),--用户的部门ID。
	@RankID			nvarchar(32),--用户的岗位级别ID。
	@PostID			nvarchar(32) --用户的岗位ID。
)
returns @tableResult table
			(
				RoleID			nvarchar(32) primary key,--角色ID。
				RoleName		nvarchar(256),--角色名称。
				ParentRoleID	nvarchar(32) null--上级角色。
			)
as
begin
	--定义角色存储。
	declare @v_Role Table(RoleID	nvarchar(32))
	--用户下的角色。
	insert into @v_Role(RoleID)
	select distinct RoleID
	from tblSecurityRoleEmployee
	where EmployeeID = @EmployeeID
	--用户部门下的角色。
	if(isnull(@DepartmentID,'') <> '')
	begin
		insert into @v_Role(RoleID)
		select distinct RoleID
		from tblSecurityRoleDepartment data
		where (data.DepartmentID = @DepartmentID)
		and (not exists(select 0 
						from @v_Role tmp
						where tmp.RoleID = data.RoleID))
	end
	--用户岗位下的角色。
	if(isnull(@PostID,'') <> '')
	begin
		insert into @v_Role(RoleID)
		select distinct RoleID
		from tblSecurityRolePost data
		where (data.PostID = @PostID)
		and (not exists(select 0 
						from @v_Role tmp
						where tmp.RoleID = data.RoleID))
	end
	--用户岗位级别下的角色。
	if(isnull(@RankID,'') <> '')
	begin
		insert into @v_Role(RoleID)
		select distinct RoleID
		from tblSecurityRoleRank data
		where (data.RankID = @RankID)
		and (not exists(select 0 
						from @v_Role tmp
						where tmp.RoleID = data.RoleID))
	end
	--删除不属于当前系统的角色。
	if(isnull(@SystemID,'') <> '')
	begin
		delete from @v_Role 
		where RoleID not in (select RoleID 
							 from tblSecurityRoleSystem 
							 where SystemID = @SystemID)
	end
	
	--返回结果数据集。
	insert into @tableResult(RoleID,RoleName,ParentRoleID)
	select	RoleID,RoleName,ParentRoleID
	from tblSecurityRole
	where RoleStatus = 1 and (RoleID in (select RoleID from @v_Role))
	
	return
end
go
----------------------------------------------------------------------------------------------------------------
