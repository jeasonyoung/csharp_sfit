//================================================================================
// FileName: SFITSchoolSetCatalogEntity.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
	
using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITSchoolSetCatalogEntity实体类。
	///</summary>
	internal class SFITSchoolSetCatalogEntity: DbModuleEntity<SFITSchoolSetCatalog>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITSchoolSetCatalogEntity()
		{

		}
		#endregion


        /// <summary>
        /// 验证作品上传是否超过规定的时间。
        /// </summary>
        /// <param name="schoolID"></param>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public bool ValidWorkUploadExpired(GUIDEx schoolID, GUIDEx catalogID)
        {
            bool result = false;
            if (schoolID.IsValid && catalogID.IsValid)
            {
                SFITSchoolSetCatalog data = new SFITSchoolSetCatalog();
                data.CatalogID = catalogID;
                data.SchoolID = schoolID;
                if (this.LoadRecord(ref data))
                {
                    DateTime dtCurrent = DateTime.Now;

                    if ((dtCurrent < data.StartTime) || (dtCurrent > data.EndTime))
                        result = true;
                }
            }
            return result;
        }
	}

}
