//================================================================================
// FileName: SFITCatalogKnowledgePointsEntity.cs
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
	///SFITCatalogKnowledgePointsEntity实体类。
	///</summary>
	internal class SFITCatalogKnowledgePointsEntity: DbModuleEntity<SFITCatalogKnowledgePoints>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITCatalogKnowledgePointsEntity()
		{

		}
		#endregion

        #region 数据操作。
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="catalogID"></param>
        /// <param name="chkPoints"></param>
        /// <returns></returns>
        public bool UpdateCatalogKnowledgePoints(GUIDEx catalogID, StringCollection chkPoints)
        {
            bool result = false;
            if (catalogID.IsValid)
            {
                this.DeleteRecord(string.Format("CatalogID = '{0}'", catalogID));
                if (chkPoints != null && chkPoints.Count > 0)
                {
                    SFITCatalogKnowledgePoints data = new SFITCatalogKnowledgePoints();
                    foreach (string p in chkPoints)
                    {
                        if (!string.IsNullOrEmpty(p))
                        {
                            data.CatalogID = catalogID;
                            data.PointID = p;

                            result = this.UpdateRecord(data);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取目录下要点集合。
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public StringCollection GetCatalogKnowledgePoints(GUIDEx catalogID)
        {
            StringCollection collection = null;
            if (catalogID.IsValid)
            {
                DataTable dtSource = this.GetAllRecord(string.Format("CatalogID = '{0}'",catalogID));
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    collection = new StringCollection();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        collection.Add(Convert.ToString(row["PointID"]));
                    }
                }
            }
            return collection;
        }
        #endregion
    }

}
