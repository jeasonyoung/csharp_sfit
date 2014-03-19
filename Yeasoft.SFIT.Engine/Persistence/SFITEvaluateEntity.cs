//================================================================================
// FileName: SFITEvaluateEntity.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
	///SFITEvaluateEntityʵ���ࡣ
	///</summary>
	internal class SFITEvaluateEntity: DbModuleEntity<SFITEvaluate>
	{
		#region ��Ա���������캯����
        SFITEvaluateItemsEntity evaluateItemsEntity = null;
		///<summary>
		///���캯��
		///</summary>
		public SFITEvaluateEntity()
		{
            this.evaluateItemsEntity = new SFITEvaluateItemsEntity();
		}
		#endregion

        #region ���ݴ���
        /// <summary>
        /// �󶨿͹��������ݡ�
        /// </summary>
        public IListControlsData BindEvaluate
        {
            get
            {
                return new ListControlsDataSource("EvaluateName", "EvaluateID", this.GetAllRecord("", "OrderNO"));
            }
        }
        /// <summary>
        /// ��ȡ�б�����Դ��
        /// </summary>
        /// <param name="evaluateName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string evaluateName)
        {
            return this.GetAllRecord(string.Format("EvaluateName like '%{0}%'", evaluateName), "OrderNO desc");
        }
        /// <summary>
        /// ɾ�����ݡ�
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
        /// ����ͬ���Ŀ͹��������ݡ�
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
