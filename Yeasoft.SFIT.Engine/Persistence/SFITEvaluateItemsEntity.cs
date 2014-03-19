//================================================================================
// FileName: SFITEvaluateItemsEntity.cs
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
using iPower.Data;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITEvaluateItemsEntityʵ���ࡣ
	///</summary>
	internal class SFITEvaluateItemsEntity: DbModuleEntity<SFITEvaluateItems>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SFITEvaluateItemsEntity()
		{

		}
		#endregion

        #region ���ݴ���
        /// <summary>
        /// �󶨿͹�������Ŀֵ��
        /// </summary>
        /// <param name="evaluateID">����ID��</param>
        /// <returns></returns>
        public IListControlsData BindEvaluateItemsValue(GUIDEx evaluateID)
        {
            return new ListControlsDataSource("ItemValue", "ItemValue", this.GetAllRecord(string.Format("EvaluateID = '{0}'", evaluateID)));
        }
        /// <summary>
        /// ��������ID��ȡ������Ŀ���ϡ�
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
        /// ���ؽ�ʦͬ��������Ŀ���ϡ�
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
        /// ����ɾ����Ŀ���ϡ�
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
