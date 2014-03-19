//================================================================================
// FileName: SFITGradePresenter.cs
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
	/// ISFITGradeView�ӿڡ�
	///</summary>
	public interface ISFITGradeView: IModuleView
	{
        /// <summary>
        /// ��ѧϰ�׶Ρ�
        /// </summary>
        /// <param name="data"></param>
        void BindLearnLevel(IListControlsData data);
        /// <summary>
        /// ��ʾ���ݡ�
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// �б����ݽӿڡ�
    /// </summary>
    public interface ISFITGradeListView : ISFITGradeView
    {
        /// <summary>
        /// ��ȡѧϰ�׶�ID��
        /// </summary>
        GUIDEx LearnLevelID { get; }
        /// <summary>
        /// ��ȡ�꼶���ơ�
        /// </summary>
        string GradeName { get; }
    }
    /// <summary>
    /// �༭����ӿڡ�
    /// </summary>
    public interface ISFITGradeEditView : ISFITGradeView
    {
        /// <summary>
        /// ��ȡ�꼶ID��
        /// </summary>
        GUIDEx GradeID { get; }
    }
	///<summary>
	/// SFITGradePresenter��Ϊ�ࡣ
	///</summary>
	public class SFITGradePresenter: ModulePresenter<ISFITGradeView>
	{
		#region ��Ա���������캯����
        SFITGradeEntity gradeEntity = null;
		///<summary>
		///���캯����
		///</summary>
		public SFITGradePresenter(ISFITGradeView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.Grade_ModuleID;
            this.gradeEntity = new SFITGradeEntity();
		}
		#endregion

        #region ���ء�
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITGradeView view = this.View as ISFITGradeView;
            if (view != null)
            {
                view.BindLearnLevel(this.EnumDataSource(typeof(EnumLearnLevel)));
            }
        }
        #endregion

        #region ���ݲ���������
        /// <summary>
        /// ��ȡ�б�����Դ��
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                ISFITGradeListView listView = this.View as ISFITGradeListView;
                if (listView != null)
                {
                    DataTable dtSource = this.gradeEntity.ListDataSource(listView.LearnLevelID, listView.GradeName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("LearnLevelName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["LearnLevelName"] = this.GetEnumMemberName(typeof(EnumLearnLevel), Convert.ToInt32(row["LearnLevel"]));
                        }
                    }
                    return dtSource;
                }
                return null;
            }
        }
		///<summary>
		///�༭ҳ��������ݡ�
		///</summary>
		///<param name="handler"></param>
		public void LoadEntityData(EventHandler<EntityEventArgs<SFITGrade>> handler)
		{
            ISFITGradeEditView editView = this.View as ISFITGradeEditView;
            if (handler != null && editView != null && editView.GradeID.IsValid)
            {
                SFITGrade data = new SFITGrade();
                data.GradeID = editView.GradeID;
                if (this.gradeEntity.LoadRecord(ref data))
                    handler(this, new EntityEventArgs<SFITGrade>(data));
            }
		}
        /// <summary>
        /// �������ݡ�
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateSFITGrade(SFITGrade data)
        {
            try
            {
                return this.gradeEntity.UpdateRecord(data);
            }
            catch (Exception e)
            {
                this.View.ShowMessage(e.Message);
            }
            return false;
        }
        /// <summary>
        /// ����ɾ�����ݡ�
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteGrade(StringCollection priCollection)
        {
            bool result = false;
            try
            {
                if (priCollection != null && priCollection.Count > 0)
                {
                    string err= null;
                    foreach (string p in priCollection)
                    {
                        if (!(result = this.gradeEntity.DeleteRecord(p, out err)))
                        {
                            this.View.ShowMessage(err);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                this.View.ShowMessage(e.Message);
            }
            return result;
        }
		#endregion

	}

}
