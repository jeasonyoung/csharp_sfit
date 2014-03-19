//================================================================================
// FileName: SFITEvaluateEntity.cs
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
	///SFITEvaluateEntity实体类。
	///</summary>
	internal class SFITEvaluateEntity: DbModuleEntity<SFITEvaluate>
	{
		#region 成员变量，构造函数。
        SFITEvaluateItemsEntity evaluateItemsEntity = null;
		///<summary>
		///构造函数
		///</summary>
		public SFITEvaluateEntity()
		{
            this.evaluateItemsEntity = new SFITEvaluateItemsEntity();
		}
		#endregion

        #region 数据处理。
        /// <summary>
        /// 绑定客观评价数据。
        /// </summary>
        public IListControlsData BindEvaluate
        {
            get
            {
                return new ListControlsDataSource("EvaluateName", "EvaluateID", this.GetAllRecord("", "OrderNO"));
            }
        }
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        /// <param name="evaluateName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string evaluateName)
        {
            return this.GetAllRecord(string.Format("EvaluateName like '%{0}%'", evaluateName), "OrderNO desc");
        }
        /// <summary>
        /// 删除数据。
        /// </summary>
        /// <param name="evaluateID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteEvaluate(GUIDEx evaluateID, out string err)
        {
            const string sql = "exec spSFITDeleteEvaluate '{0}'";
            string result = this.DatabaseAccess.ExecuteScalar(string.Format(sql, evaluateID)).ToString();
            string[] array = result.Split('|');
            err = array[1];
            return array[0] == "0";
        }
        /// <summary>
        /// 加载同步的客观评价数据。
        /// </summary>
        /// <param name="info"></param>
        public void LoadTeaSyncEvaluate(Grade info)
        {
            const string sql = "exec spSFITeaSyncEvaluate '{0}'";
            if (info == null || string.IsNullOrEmpty(info.GradeID))
                return;
            DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, info.GradeID)).Tables[0];
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    Evaluate evaluate = new Evaluate();
                    evaluate.EvaluateID = Convert.ToString(row["EvaluateID"]);
                    evaluate.EvaluateName = Convert.ToString(row["EvaluateName"]);
                    evaluate.Type = (EnumEvaluateType)Convert.ToInt32(row["EvaluateType"]);
                    evaluate.MinValue = Convert.ToInt32(row["MinValue"]);
                    evaluate.MaxValue = Convert.ToInt32(row["MaxValue"]);

                    if (evaluate.Type == EnumEvaluateType.Hierarchy)
                    {
                        this.evaluateItemsEntity.LoadTeaSyncEvaluateItems(ref evaluate, evaluate.EvaluateID);
                    }
                    info.Evaluate = evaluate;
                    break;
                }
            }
        }
        #endregion
    }

}
