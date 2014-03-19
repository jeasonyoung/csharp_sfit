/*
//================================================================================
//  FileName: SFIT_InitializeSchoolReg.sql
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/9/27
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
insert into tblSFITCenterAccess(AccessID,AccessAccount,AccessPassword,AccessStatus,SchoolID,SchoolName)
select (replace(newid(),'-','')),data.SchoolCode,(replace(newid(),'-','')),1,data.SchoolID,data.SchoolName
from tblSFITSchools data
where  (data.SchoolType = 0x01) 
and (data.SchoolID not in (select SchoolID from tblSFITCenterAccess))