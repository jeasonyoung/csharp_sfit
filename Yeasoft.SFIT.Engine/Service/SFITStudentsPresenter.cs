//================================================================================
// FileName: SFITStudentsPresenter.cs
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
	/// ISFITStudentsView接口。
	///</summary>
	public interface ISFITStudentsView: IModuleView
	{ 
        /// <summary>
        /// 显示信息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 列表页面接口。
    /// </summary>
    public interface ISFITStudentsListView : ISFITStudentsView
    {
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// 获取年级名称。
        /// </summary>
        string GradeName { get; }
        /// <summary>
        /// 获取班级名称。
        /// </summary>
        string ClassName { get; }
        /// <summary>
        /// 获取学生名称。
        /// </summary>
        string StudentName { get; }
    }
    /// <summary>
    /// 编辑页面接口。
    /// </summary>
    public interface ISFITStudentsEditView : ISFITStudentsView
    {
        /// <summary>
        /// 获取班级ID。
        /// </summary>
        GUIDEx ClassID { get; }
        /// <summary>
        /// 获取学生ID。
        /// </summary>
        GUIDEx StudentID { get; }
        /// <summary>
        /// 绑定年级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindGrade(IListControlsData data);
        /// <summary>
        /// 绑定班级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindClass(IListControlsData data);
        /// <summary>
        /// 绑定性别数据。
        /// </summary>
        /// <param name="data"></param>
        void BindGender(IListControlsData data);
        /// <summary>
        /// 绑定同步状态数据。
        /// </summary>
        /// <param name="data"></param>
        void BindSyncStatus(IListControlsData data);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITStudentsPickerView : ISFITStudentsView
    {
        /// <summary>
        /// 获取所属学校ID。
        /// </summary>
        GUIDEx UnitID { get; }
        /// <summary>
        /// 获取所属班级名称。
        /// </summary>
        string ClassName { get; }
        /// <summary>
        /// 获取学生名称。
        /// </summary>
        string StudentName { get; }
        /// <summary>
        /// 
        /// </summary>
        bool IsUnit { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void BindUnits(IListControlsData data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void BindQueryResult(IListControlsData data);
    }
	///<summary>
	/// SFITStudentsPresenter行为类。
	///</summary>
    public class SFITStudentsPresenter : ModulePresenter<ISFITStudentsView>
    {
        #region 成员变量，构造函数。
        SFITClassEntity classEntity = null;
        SFITStudentsEntity studentsEntity = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public SFITStudentsPresenter(ISFITStudentsView view)
            : base(view)
        {
            if (view is ISFITStudentsPickerView)
            {
                this.View.SecurityID = GUIDEx.Null;
            }
            else
            {
                this.View.SecurityID = ModuleConstants.Students_ModuleID;
            }
            this.classEntity = new SFITClassEntity();
            this.studentsEntity = new SFITStudentsEntity();
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();

            ISFITStudentsEditView editView = this.View as ISFITStudentsEditView;
            if (editView != null)
            {
                editView.BindGrade(new SFITGradeEntity().BindGrade);
                editView.BindGender(this.EnumDataSource(typeof(EnumGender)));
                editView.BindSyncStatus(this.EnumDataSource(typeof(EnumSyncStatus)));
            }

            ISFITStudentsPickerView pickerView = this.View as ISFITStudentsPickerView;
            if (pickerView != null)
            {
                if (pickerView.IsUnit)
                    pickerView.BindUnits(new SFITSchoolsEntity().BindSchools(pickerView.CurrentUserID));
                else
                    pickerView.BindUnits(new SFITSchoolsEntity().BindSchools());
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
                ISFITStudentsListView listView = this.View as ISFITStudentsListView;
                if (listView != null)
                {
                    DataTable dtSource = this.studentsEntity.ListDataSource(listView.SchoolName, listView.GradeName, listView.ClassName, listView.StudentName);
                    if (dtSource != null)
                    {
                        dtSource.Columns.Add("SyncStatusName", typeof(string));
                        dtSource.Columns.Add("GenderName", typeof(string));
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["SyncStatusName"] = this.GetEnumMemberName(typeof(EnumSyncStatus), Convert.ToInt32(row["SyncStatus"]));
                            row["GenderName"] = this.GetEnumMemberName(typeof(EnumGender), Convert.ToInt32(row["Gender"]));
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
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITStudents>> handler)
        {
            ISFITStudentsEditView editView = this.View as ISFITStudentsEditView;
            if (handler != null && editView != null && editView.StudentID.IsValid)
            {
                SFITStudents data = new SFITStudents();
                data.ClassID = editView.ClassID;
                data.StudentID = editView.StudentID;
                if (this.studentsEntity.LoadRecord(ref data))
                {
                    this.ChangeGrade(data.SchoolID, data.GradeID);
                    handler(this, new EntityEventArgs<SFITStudents>(data));
                }
            }
        }

        /// <summary>
        /// 加载学生数据。
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public SFITStudents LoadStudents(GUIDEx studentID)
        {
            if (studentID.IsValid)
            {
                SFITStudents data = new SFITStudents();
                data.StudentID = studentID;
                if (this.studentsEntity.LoadRecord(ref data))
                    return data;
            }
            return null;
        }
        /// <summary>
        /// 更新学生数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateStudents(SFITStudents data)
        {
            try
            {
                return this.studentsEntity.UpdateRecord(data);
            }
            catch (Exception e)
            {
                this.View.ShowMessage(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 批量删除学生数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteStudents(StringCollection priCollection)
        {
            bool result = false;
            try
            {
                if (priCollection != null && priCollection.Count > 0)
                {
                    string err = null;
                    foreach (string p in priCollection)
                    {
                        if (!(result = this.studentsEntity.DeleteRecord(p, out err)))
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

        /// <summary>
        /// 改变年级重置班级数据。
        /// </summary>
        /// <param name="schoolID">学校ID。</param>
        /// <param name="gradeID">年级ID。</param>
        public void ChangeGrade(GUIDEx schoolID, GUIDEx gradeID)
        {
            ISFITStudentsEditView editView = this.View as ISFITStudentsEditView;
            if (editView != null)
                editView.BindClass(this.classEntity.BindClass(schoolID, gradeID));
        }
        /// <summary>
        /// 
        /// </summary>
        public void QueryResult()
        {
            ISFITStudentsPickerView pickerView = this.View as ISFITStudentsPickerView;
            if (pickerView != null)
            {
                DataTable dtSource = this.studentsEntity.PickerListDataSource(pickerView.UnitID, pickerView.ClassName, pickerView.StudentName);
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    dtSource.Columns.Add("FullName", typeof(string));
                    dtSource.Columns.Add("FullValue", typeof(string));
                    int index = 0;
                    foreach (DataRow row in dtSource.Rows)
                    {
                        row["FullName"] = string.Format("{0}.{1}[{2}],{3},{4}-{5}", ++index, row["StudentName"], row["StudentCode"],
                                            this.GetEnumMemberName(typeof(EnumGender), Convert.ToInt32(row["Gender"])),
                                            row["SchoolName"], row["ClassName"]);
                        row["FullValue"] = string.Format("{0}#{1}#{2}#{3}#{4}", row["StudentID"], row["StudentName"], row["StudentCode"],
                                            row["SchoolName"], row["ClassName"]);
                    }
                    pickerView.BindQueryResult(new ListControlsDataSource("FullName", "FullValue", dtSource));
                }
            }
        }
        #endregion
    }

}
