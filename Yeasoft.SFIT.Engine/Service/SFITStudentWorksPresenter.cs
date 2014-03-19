//================================================================================
// FileName: SFITStudentWorksCollectPresenter.cs
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
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;

using Yaesoft.SFIT;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
	///<summary>
	/// ISFITStudentWorksView�ӿڡ�
	///</summary>
    public interface ISFITStudentWorksView : IModuleView
    {
        /// <summary>
        /// ��ʾ��Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// �б�ӿڡ�
    /// </summary>
    public interface ISFITStudentWorksListView : ISFITStudentWorksView
    {
        /// <summary>
        /// ��ȡѧУ���ơ�
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// ��ȡ�꼶ID��
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// ��ȡ�༶���ơ�
        /// </summary>
        string ClassName { get; }
        /// <summary>
        /// ��ȡѧ�����ơ�
        /// </summary>
        string StudentName { get; }
        /// <summary>
        /// ��ȡ��Ʒ���ơ�
        /// </summary>
        string WorkName { get; }
        /// <summary>
        /// ��ȡ��Ʒ״̬��
        /// </summary>
        GUIDEx WorkStatusID { get; }
        /// <summary>
        /// ���꼶���ݡ�
        /// </summary>
        /// <param name="data"></param>
        void BindGrade(IListControlsData data);
        /// <summary>
        /// ����Ʒ״̬��
        /// </summary>
        /// <param name="data"></param>
        void BindWorkStatus(IListControlsData data);
    }
    /// <summary>
    /// �༭�ӿڡ�
    /// </summary>
    public interface ISFITStudentWorksEditView : ISFITStudentWorksView
    {
        /// <summary>
        /// ��ȡ��ƷID��
        /// </summary>
        GUIDEx WorkID { get; }
    }
	///<summary>
	/// SFITStudentWorksCollectPresenter��Ϊ�ࡣ
	///</summary>
    public class SFITStudentWorksPresenter : ModulePresenter<ISFITStudentWorksView>
    {
        #region ��Ա���������캯����
        SFITStudentWorksEntity studentWorksEntity = null;
        ///<summary>
        ///���캯����
        ///</summary>
        public SFITStudentWorksPresenter(ISFITStudentWorksView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.StudentWorks_ModuleID;
            this.studentWorksEntity = new SFITStudentWorksEntity();
        }
        #endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            ISFITStudentWorksListView listView = this.View as ISFITStudentWorksListView;
            if (listView != null)
            {
                listView.BindGrade(new SFITGradeEntity().BindGrade);
                listView.BindWorkStatus(this.BindEnumWorkStatusData());
            }
        }
        #endregion

        #region ���ݲ���������
        /// <summary>
        /// �б�����Դ
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                ISFITStudentWorksListView listView = this.View as ISFITStudentWorksListView;
                if (listView != null)
                {
                    DataTable dtSource = this.studentWorksEntity.ListDataSource(listView.SchoolName, listView.GradeID, listView.ClassName, 
                        listView.StudentName, listView.WorkName, listView.WorkStatusID);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("WorkStatusName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["WorkStatusName"] = this.GetEnumWorkStatusName((EnumWorkStatus)Convert.ToInt32(row["WorkStatus"]));
                        }
                        return dtSource;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// ����ɾ����
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteEntityData(StringCollection priCollection)
        {
            bool result = false;
            try
            {
                if (priCollection != null && priCollection.Count > 0)
                    result = this.studentWorksEntity.DeleteRecord(priCollection);
            }
            catch (Exception x)
            {
                this.View.ShowMessage(x.Message);
            }
            return result;
        }
        #endregion
    }
}
