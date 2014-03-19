//================================================================================
// FileName: SFITClassPresenter.cs
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
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
	///<summary>
	/// ISFITClassView接口。
	///</summary>
	public interface ISFITClassView: IModuleView
	{
        /// <summary>
        ///  显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
        /// <summary>
        /// 绑定年级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindGrades(IListControlsData data);
	}

    /// <summary>
    /// 列表页面接口。
    /// </summary>
    public interface ISFITClassListView : ISFITClassView
    {
        /// <summary>
        /// 获取年级ID。
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// 获取班级名称。
        /// </summary>
        string ClassName { get; }
    }
    /// <summary>
    /// 编辑页面接口。
    /// </summary>
    public interface ISFITClassEditView : ISFITClassView
    {
        /// <summary>
        /// 获取班级ID。
        /// </summary>
        GUIDEx ClassID { get; }
        /// <summary>
        /// 绑定同步状态数据。
        /// </summary>
        /// <param name="data"></param>
        void BindSyncStatus(IListControlsData data);
    }
	///<summary>
	/// SFITClassPresenter行为类。
	///</summary>
	public class SFITClassPresenter: ModulePresenter<ISFITClassView>
	{
		#region 成员变量，构造函数。
        SFITClassEntity classEntity = null;
		///<summary>
		///构造函数。
		///</summary>
		public SFITClassPresenter(ISFITClassView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.Class_ModuleID;
            this.classEntity = new SFITClassEntity();
		}
		#endregion

        #region 重载。
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
            ISFITClassView view = this.View as ISFITClassView;
            if (view != null)
            {
                view.BindGrades(new SFITGradeEntity().BindGrade);
            }
            ISFITClassEditView editView = this.View as ISFITClassEditView;
            if (editView != null)
            {
                editView.BindSyncStatus(this.EnumDataSource(typeof(EnumSyncStatus)));
            }
        }
        #endregion

        #region 数据操作函数。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                ISFITClassListView listView = this.View as ISFITClassListView;
                if (listView != null)
                {
                    DataTable dtSource = this.classEntity.ListDataSource(listView.SchoolName, listView.GradeID, listView.ClassName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("SyncStatusName", typeof(string));
                        dtSource.Columns.Add("ClassToolTip", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["SyncStatusName"] = this.GetEnumMemberName(typeof(EnumSyncStatus), Convert.ToInt32(row["SyncStatus"]));
                            row["ClassToolTip"] = string.Format("入学年份：{0}，当前年级：{1}，学习阶段：{2}", row["JoinYear"], row["GradeValue"],
                                                   this.GetEnumMemberName(typeof(EnumLearnLevel), Convert.ToInt32(row["LearnLevel"])));
                        }
                    }
                    return dtSource;
                }
                return null;
            }
        }
        ///<summary>
		///编辑页面加载数据。
		///</summary>
		///<param name="handler"></param>
		public void LoadEntityData(EventHandler<EntityEventArgs<SFITClass>> handler)
		{
            ISFITClassEditView editView = this.View as ISFITClassEditView;
            if (handler != null && editView != null && editView.ClassID.IsValid)
            {
                SFITClass data = new SFITClass();
                data.ClassID = editView.ClassID;
                if (this.classEntity.LoadRecord(ref data))
                {
                    handler(this, new EntityEventArgs<SFITClass>(data));
                }
            }
		}
        /// <summary>
        /// 更新数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateClass(SFITClass data)
        {
            try
            {
                if (data != null && !string.IsNullOrEmpty(data.GradeID))
                {
                    SFITGrade grade = new SFITGrade();
                    grade.GradeID = data.GradeID.Split(',')[0];
                    if (new SFITGradeEntity().LoadRecord(ref grade))
                    {
                        data.GradeValue = grade.GradeValue;
                        data.LearnLevel = grade.LearnLevel;
                        return this.classEntity.UpdateRecord(data);
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                this.View.ShowMessage(e.Message);
                return false;
            }
        }
        /// <summary>
        ///  批量删除数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteClass(StringCollection priCollection)
        {
            bool result = false;
            try
            {
                if (priCollection != null && priCollection.Count > 0)
                {
                    string err = null;
                    foreach (string p in priCollection)
                    {
                        if (!(result = this.classEntity.DeleteRecord(p, out err)))
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
