//================================================================================
// FileName: SFITCatalogEntity.cs
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
using Yaesoft.SFIT.Engine.Index;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///�γ�Ŀ¼ʵ���ࡣ
	///</summary>
	internal class SFITCatalogEntity: DbModuleEntity<SFITCatalog>
	{
		#region ��Ա���������캯����
        SFITKnowledgePointsEntity pointsEntity;
		///<summary>
		///���캯��
		///</summary>
		public SFITCatalogEntity()
		{
            this.pointsEntity = new SFITKnowledgePointsEntity();
		}
		#endregion

        #region ���ء�
        /// <summary>
        /// ���ؼ������ݡ�
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool LoadRecord(ref SFITCatalog entity)
        {
            bool result = false;
            if (result = base.LoadRecord(ref entity))
            {
                if (entity.SchoolID.IsValid)
                {
                    SFITSchools data = new SFITSchools();
                    data.SchoolID = entity.SchoolID;
                    if (new SFITSchoolsEntity().LoadRecord(ref data))
                    {
                        entity.SchoolName = data.SchoolName;
                    }
                }
            }
            return result;
        }
        #endregion

        #region ���ݴ���
        /// <summary>
        /// �󶨿γ�Ŀ¼���ݡ�
        /// </summary>
        /// <param name="unitID"></param>
        /// <param name="gradeID"></param>
        /// <returns></returns>
        public IListControlsData BindCatalogs(GUIDEx unitID, GUIDEx gradeID)
        {
            StringBuilder where = new StringBuilder();
            where.AppendFormat(" GradeID = '{0}' ", gradeID);
            if (unitID.IsValid)
            {
                where.AppendFormat(" and (isnull(SchoolID,'{0}') = '{0}' or SchoolID = '')", unitID);
            }
            DataTable dtSource = this.GetAllRecord(where.ToString(), "OrderNO");
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                foreach (DataRow row in dtSource.Rows)
                {
                    row["CatalogName"] = string.Format("{0}({1})", row["CatalogName"], this.GetEnumMemberName(typeof(EnumCatalogType), Convert.ToInt32(row["CatalogType"])));
                }

                return new ListControlsDataSource("CatalogName", "CatalogID", dtSource);
            }
            return null;
        }
        /// <summary>
        /// ��ȡ�б����ݡ�
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="gradeID"></param>
        /// <param name="catalogName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string schoolName, string gradeID, string catalogName)
        {
            const string sql = "exec spSFITCatalogListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, schoolName, gradeID, catalogName)).Tables[0].Copy();
        }
        /// <summary>
        /// ��ȡ�б�����Դ��
        /// </summary>
        /// <param name="unitID"></param>
        /// <param name="gradeID"></param>
        /// <param name="catalogName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx unitID, string gradeID, string catalogName)
        {
            const string sql = "exec spSFITCatalogByUnitListView '{0}','{1}','{2}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitID, gradeID, catalogName)).Tables[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitID"></param>
        /// <param name="gradeID"></param>
        /// <returns></returns>
        public DataTable LoadIndexAllCatalogs(GUIDEx unitID,GUIDEx gradeID)
        {
            const string sql = "exec spSFITIndexAllCatalog '{0}','{1}'";
            return this.DatabaseAccess.ExecuteDataset(string.Format(sql, unitID, gradeID)).Tables[0];
        }
        /// <summary>
        /// ɾ�����ݡ�
        /// </summary>
        /// <param name="catalogID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteRecord(GUIDEx catalogID, out string err)
        {
            const string sql = "exec spSFITDeleteCatalog '{0}'";
            string result = this.DatabaseAccess.ExecuteScalar(string.Format(sql, catalogID)).ToString();
            string[] array = result.Split('|');
            err = array[1];
            return array[0] == "0";
        }
    
        /// <summary>
        /// ����Ŀ¼����Ҫ�㡣
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public bool LoadTeaSyncCatalogKnowledgePoints(Grade grade, GUIDEx schoolID)
        {
            bool result = false;
            if (grade != null && schoolID.IsValid)
            {
                List<SFITCatalog> catalogs = this.LoadRecord(string.Format("(GradeID = '{0}') and (isnull(SchoolID,'{1}') = '{1}' or SchoolID = '')", grade.GradeID, schoolID));
                if (catalogs != null && catalogs.Count > 0)
                {
                    for (int i = 0; i < catalogs.Count; i++)
                    {
                        SFITCatalog c = catalogs[i];
                        if (c != null)
                        {
                            //Ŀ¼��
                            Catalog item = new Catalog();
                            item.CatalogID = c.CatalogID;
                            item.CatalogCode = c.CatalogCode;
                            item.CatalogName = c.CatalogName;
                            item.TypeName = this.GetEnumMemberName(typeof(EnumCatalogType), c.CatalogType);
                            item.OrderNO = c.OrderNO;
                            //Ҫ�㡣
                            if (this.pointsEntity != null)
                            {
                                this.pointsEntity.LoadTeaSyncCatalogKnowledgePoint(ref item);
                            }
                            //�����꼶�С�
                            grade.Catalogs.Add(item);
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region ��ҳ�������ݡ�
        public IndexDataResult<IndexDatas> LoadIndexCatalogData(string schoolId, string gradeId,int pageSize, int pageIndex)
        {
            bool isGrade = !string.IsNullOrEmpty(gradeId);
            StringBuilder builder = new StringBuilder();
            builder.Append("select CatalogID,CatalogName,GradeName from vwSFITCatalogs ");
            if (!string.IsNullOrEmpty(schoolId) || !string.IsNullOrEmpty(gradeId))
            {
                bool flag = false;
                builder.Append(" where ");
                if ((flag = !string.IsNullOrEmpty(schoolId)))
                {
                    builder.AppendFormat(" isnull(SchoolID,'{0}') = '{0}'", schoolId);
                }
                if (!string.IsNullOrEmpty(gradeId))
                {
                    if (flag)
                    {
                        builder.Append(" and ");
                    }
                    string[] array = gradeId.Split(',');
                    builder.AppendFormat(" (GradeID in ('{0}')) ", string.Join("','", array));
                }
            }
            builder.Append(" order by GradeOrderNo,OrderNO ");
            int pindex = 0, psize = 0, pcount = 0, rcount = 0;
            DataTable dtSource = this.LoadPagingData(builder.ToString(), pageIndex, pageSize, out pindex, out psize, out pcount, out rcount);
            if (dtSource != null)
            {
                IndexDatas collection = new IndexDatas();
                foreach (DataRow row in dtSource.Rows)
                {
                    IndexData data = new IndexData();
                    data.ID = string.Format("{0}", row["CatalogID"]);
                    data.Name = string.Format("{0}", row["CatalogName"]);
                    //if (isGrade)
                    //{
                    //    data.Name = string.Format("{0}", row["CatalogName"]);
                    //}
                    //else
                    //{
                    //    data.Name = string.Format("[{0}]({1})", row["GradeName"], row["CatalogName"]);
                    //}
                    collection.Add(data);
                }
                return new IndexDataResult<IndexDatas>(psize, pindex, pcount, rcount, collection);
            }
            return null;
        }
        #endregion
    }
}