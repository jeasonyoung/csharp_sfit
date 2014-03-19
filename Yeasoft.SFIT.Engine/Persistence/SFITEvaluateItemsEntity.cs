//================================================================================
// FileName: SFITEvaluateItemsEntity.cs
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
using iPower.Data;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITEvaluateItemsEntity实体类。
	///</summary>
	internal class SFITEvaluateItemsEntity: DbModuleEntity<SFITEvaluateItems>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITEvaluateItemsEntity()
		{

		}
		#endregion

        #region 数据处理。
        /// <summary>
        /// 绑定客观评价项目值。
        /// </summary>
        /// <param name="evaluateID">评价ID。</param>
        /// <returns></returns>
        public IListControlsData BindEvaluateItemsValue(GUIDEx evaluateID)
        {
            return new ListControlsDataSource("ItemValue", "ItemValue", this.GetAllRecord(string.Format("EvaluateID = '{0}'", evaluateID)));
        }
        /// <summary>
        /// 根据评价ID获取评价项目集合。
        /// </summary>
        /// <param name="evaluateID"></param>
        /// <returns></returns>
        public EvaluateItems GetAllEvaluateItems(GUIDEx evaluateID)
        {
            if (evaluateID.IsValid)
            {
                DataTable dtSource = this.GetAllRecord(string.Format("EvaluateID = '{0}'", evaluateID), "ItemValue");
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    EvaluateItems collection = new EvaluateItems();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        EvaluateItem item = new EvaluateItem();
                        item.ItemID = Convert.ToString(row["ItemID"]);
                        item.ItemName = Convert.ToString(row["ItemName"]);
                        item.ItemValue = Convert.ToString(row["ItemValue"]);
                        collection.Add(item);
                    }
                    return collection;
                }
            }
            return null;
        }
        /// <summary>
        /// 加载教师同步评价项目集合。
        /// </summary>
        /// <param name="data"></param>
        public void LoadTeaSyncEvaluateItems(ref Evaluate data, GUIDEx evaluateID)
        {
            if (data != null && evaluateID.IsValid)
            {
                data.Items = this.GetAllEvaluateItems(evaluateID);
            }
        }
        /// <summary>
        /// 批量删除项目集合。
        /// </summary>
        /// <param name="evaluateID"></param>
        /// <returns></returns>
        public bool BatchDeleteEvaluateItems(GUIDEx evaluateID)
        {
            bool result = false;
            if (evaluateID.IsValid)
            {
                result = this.DeleteRecord(string.Format("EvaluateID = '{0}'", evaluateID));
            }
            return result;
        }
        #endregion
    }
}
