//================================================================================
// FileName: SFITEvaluateSetEntity.cs
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
	///SFITEvaluateSetEntity实体类。
	///</summary>
	internal class SFITEvaluateSetEntity: DbModuleEntity<SFITEvaluateSet>
	{
		#region 成员变量，构造函数。
        SFITEvaluateItemsEntity evaluateItemsEntity;
		///<summary>
		///构造函数
		///</summary>
		public SFITEvaluateSetEntity()
		{
            this.evaluateItemsEntity = new SFITEvaluateItemsEntity();
		}
		#endregion

        #region 数据处理。
        /// <summary>
        /// 绑定客观评价。
        /// </summary>
        /// <param name="gradeID"></param>
        /// <returns></returns>
        public IListControlsData BindEvaluateValues(GUIDEx gradeID)
        {
            const string sql = "select EvaluateID from {0} where GradeID='{1}' order by ModifyTime desc";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql, this.TableName, gradeID));
            if (obj != null)
            {
                return this.evaluateItemsEntity.BindEvaluateItemsValue(new GUIDEx(obj));
            }
            return null;
        }
        /// <summary>
        /// 获取列表数据。
        /// </summary>
        /// <param name="gradeID"></param>
        /// <param name="evaluateName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx gradeID, string evaluateName)
        {
            const string sql = "exec spSFITEvaluateSetListView '{0}','{1}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, gradeID, evaluateName)).Tables[0];
        }
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool UpdateRecord(SFITEvaluateSet entity)
        {
            if (entity == null)
                return false;

            this.DeleteRecord(string.Format("EvaluateID + '-' + GradeID = '{0}-{1}'", entity.EvaluateID, entity.GradeID));
            return base.UpdateRecord(entity);
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="primaryValues"></param>
        /// <returns></returns>
        public override bool DeleteRecord(StringCollection primaryValues)
        {
            if (primaryValues != null && primaryValues.Count > 0)
            {
                foreach (string p in primaryValues)
                    this.DeleteRecord(string.Format("EvaluateID + '-' + GradeID = '{0}'", p));
                return true;
            }
            return false;
        }
        #endregion
    }

}
