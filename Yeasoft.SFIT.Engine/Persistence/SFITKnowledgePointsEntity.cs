//================================================================================
// FileName: SFITKnowledgePointsEntity.cs
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
	///SFITKnowledgePointsEntityʵ���ࡣ
	///</summary>
	internal class SFITKnowledgePointsEntity: DbModuleEntity<SFITKnowledgePoints>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SFITKnowledgePointsEntity()
		{

		}
		#endregion

        #region ���ݲ�����
        /// <summary>
        /// ��ȡ֪ʶ��˵����ݡ�
        /// </summary>
        /// <returns></returns>
        public DataTable GetKnowledgePointsMenuData()
        {
            DataTable dtSource = this.GetAllRecord("isnull(ParentPointID,'') = ''", "OrderNO");
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                return dtSource.Copy();
            }
            return null;
        }
        /// <summary>
        /// ��ȡĿ¼֪ʶ�㼯�ϡ�
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public List<SFITKnowledgePoints> GetCatalogKnowledgePoints(GUIDEx catalogID)
        {
            List<SFITKnowledgePoints> list = null;
            if (catalogID.IsValid)
            {
                DataTable dtSource = this.GetAllRecord(string.Format("PointID in (select PointID from tblSFITCatalogKnowledgePoints where CatalogID = '{0}')", catalogID));
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    list = new List<SFITKnowledgePoints>();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        list.Add(this.Assignment(row));
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// ��Ҫ�����ݡ�
        /// </summary>
        /// <returns></returns>
        public IListControlsTreeViewData BindKnowledgePoints()
        {
            return this.BindKnowledgePoints(string.Empty, string.Empty);
        }
        /// <summary>
        /// ��Ҫ�����ݡ�
        /// </summary>
        /// <param name="gradeID"></param>
        /// <param name="parentPointID"></param>
        /// <returns></returns>
        public IListControlsTreeViewData BindKnowledgePoints(GUIDEx gradeID, GUIDEx parentPointID)
        {
            const string sql = "exec spSFITBindKnowledgePoints '{0}','{1}'";
            DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, gradeID, parentPointID)).Tables[0];

            return new ListControlsTreeViewDataSource("PointNameCode", "PointID", "ParentPointID", "OrderNO", dtSource);
        }
        /// <summary>
        /// ��Ҫ�����ݡ�
        /// </summary>
        /// <param name="pointID"></param>
        /// <returns></returns>
        public IListControlsTreeViewData BindKnowledgePoints(GUIDEx pointID)
        {
            return this.BindKnowledgePoints(string.Empty, pointID);
        }
        /// <summary>
        /// ��Ҫ�����ݡ�
        /// </summary>
        /// <param name="pointID"></param>
        /// <returns></returns>
        public IListControlsTreeViewData BindNonKnowledgePoints(GUIDEx pointID)
        {
            DataTable dtSource = this.GetAllRecord(string.Format("PointID not in (select PointID from dbo.fnSFITKnowledgePointsGetOffSprings('','{0}',1))", pointID));
            if (dtSource != null)
            {
                dtSource.Columns.Add("PointNameCode", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["PointNameCode"] = string.Format("({0}){1}", row["PointCode"], row["PointName"]);
                }
                return new ListControlsTreeViewDataSource("PointNameCode", "PointID", "ParentPointID", "OrderNO", dtSource);
            }
            return null;
        }
        /// <summary>
        /// ��ȡ�б�����Դ��
        /// </summary>
        /// <param name="topPointID"></param>
        /// <param name="gradeID"></param>
        /// <param name="pointName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx topPointID, GUIDEx gradeID, string pointName)
        {
            const string sql = "exec spSFITKnowledgePointsListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, topPointID, gradeID, pointName)).Tables[0];
        }
        /// <summary>
        /// ɾ�����ݡ�
        /// </summary>
        /// <param name="pointID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteRecord(GUIDEx pointID, out string err)
        {
            const string sql = "exec spSFITDeleteKnowledgePoints '{0}'";
            string result = this.DatabaseAccess.ExecuteScalar(string.Format(sql, pointID)).ToString();
            string[] array = result.Split('|');
            err = array[1];
            return array[0] == "0";
        }
        /// <summary>
        /// ����Ŀ¼Ҫ�㡣
        /// </summary>
        /// <param name="cinfo"></param>
        /// <returns></returns>
        public bool LoadTeaSyncCatalogKnowledgePoint(ref Catalog cinfo)
        {
            bool result = false;
            List<SFITKnowledgePoints> list = this.LoadRecord(string.Format("PointID in (select PointID from tblSFITCatalogKnowledgePoints where CatalogID = '{0}')", cinfo.CatalogID));
            if (list != null && list.Count > 0)
            {
                foreach (SFITKnowledgePoints point in list)
                {
                    KnowledgePoint p = new KnowledgePoint();
                    p.PointID = point.PointID;
                    p.PointCode = point.PointCode;
                    p.PointName = point.PointName;
                    p.OrderNO = point.OrderNO;
                    p.Description = point.Description;
                    cinfo.Points.Add(p);
                    result = true;
                }
            }
            return result;
        }
        #endregion
    }

}
