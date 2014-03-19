/*
//================================================================================
//  FileName: SFIT_AlterSysMgr_Authentication.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/5/7
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
---------------------------------------------------------------------------------------------------------------
--用户验证。
if exists(select 0 from sysobjects where xtype = 'p' and name = 'spSysMgrEmployeeAuthentication')
begin
	print 'drop procedure spSysMgrEmployeeAuthentication'
	drop procedure spSysMgrEmployeeAuthentication
end
go
	print 'create procedure spSysMgrEmployeeAuthentication'
go
create procedure spSysMgrEmployeeAuthentication
(
	@EmployeeID	GUIDEx,--用户ID。
	@SystemID	GUIDEx,--系统ID。
	@ClientIP	nvarchar(20)--IP地址。
)
as
begin
	declare @result nvarchar(256)
	declare @resultCode int
	set @resultCode = 0
	set @result = '用户已被系统授权。'
	------------------------------------------------------------------------------
	--tblSysMgrAppAuthorization 获取系统访问授权ID
	declare @AppAuthID nvarchar(32)--访问授权ID。
	declare @SystemName nvarchar(256)--系统名称。
	------------------------------------------------------------------------------
	select top 1 @AppAuthID = AppAuthID,@SystemName = SystemName 
	from tblSysMgrAppAuthorization 
	where SystemID = @SystemID
	------------------------------------------------------------------------------
	if not exists(select 0 from tblSysMgrAppAuthorization where SystemID = @SystemID and AuthStatus = 1)
	begin
		set @resultCode = -1
		set @result = '该系统[系统ID：'+@SystemID+']未被访问授权！'
	end
	--tblSysMgrEmployeeAuthorization
	if(@resultCode = 0 and (@SystemID <> 'PAS00000000000000000000000000000')  and (not exists(select 0 from tblSysMgrEmployeeAuthorization where AppAuthID = @AppAuthID and EmployeeID = @EmployeeID)))
	begin
		set @resultCode = -1
		set @result = '用户未被授权访问['+@SystemName+']系统！'
	end
	--tblSysMgrLimitRefusedIPAddr
 	if(@resultCode = 0 and exists(select 0 from tblSysMgrLimitRefusedIPAddr where RefusedIPAddr = @ClientIP and dbo.fnIRMPFieldIsNullOrEmpty(EmployeeID,@EmployeeID) = @EmployeeID))
	begin
		set @resultCode = -1
		set @result = '用户IP地址['+@EmployeeID+']访问被拒绝！'
	end
	--tblSysMgrLimitBindIPAddr
	if(@resultCode = 0 and exists(select 0 from tblSysMgrLimitBindIPAddr where dbo.fnIRMPFieldIsNullOrEmpty(EmployeeID,@EmployeeID) = @EmployeeID))
	begin
		--绑定IP地址。
		if not exists(select 0 from tblSysMgrLimitBindIPAddr where  dbo.fnIRMPFieldIsNullOrEmpty(EmployeeID,@EmployeeID) = @EmployeeID and BindIPAddr = @ClientIP)
		begin
			set @resultCode = -1
			set @result = '用户IP地址未在绑定的IP地址列表中！'
		end
	end
	--tblSysMgrLimitSpecifyTimeZone
	if(@resultCode = 0 and exists(select 0 from tblSysMgrLimitSpecifyTimeZone where dbo.fnIRMPFieldIsNullOrEmpty(EmployeeID,@EmployeeID) = @EmployeeID))
	begin
		--时间区间。
		if exists(select 0 from tblSysMgrLimitSpecifyTimeZone where dbo.fnIRMPFieldIsNullOrEmpty(EmployeeID,@EmployeeID) = @EmployeeID and (getdate() between StartTime and EndTime) and AuthStatus = 0)
		begin
			set @resultCode = -1
			set @result = '用户在被限制的时间区间内！'
		end else if(exists(select 0 from tblSysMgrLimitSpecifyTimeZone where dbo.fnIRMPFieldIsNullOrEmpty(EmployeeID,@EmployeeID) = @EmployeeID and (getdate() > EndTime) and AuthStatus = 1))
		begin
			set @resultCode = -1
			set @result = '用户不在被授权使用的时间区间内！'
		end
	end
	--tblSysMgrLimitLogin
	if(@resultCode = 0 and exists(select 0 from tblSysMgrLimitLogin where dbo.fnIRMPFieldIsNullOrEmpty(EmployeeID,@EmployeeID) = @EmployeeID))
	begin
		set @resultCode = -1
		set @result = '用户被限制登录！'
	end
	------------------------------------------------------------------------------
	select cast(@resultCode as nvarchar(2)) + '|' + @result
end
go
-------------------------------------------------------