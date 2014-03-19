//================================================================================
//  FileName: SFITeaStudentWorksPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/11
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
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
    /// <summary>
    /// 教师学生作品接口。
    /// </summary>
    public interface ISFITeaStudentWorksListView : IModuleView
    {
        /// <summary>
        /// 获取学校单位ID。
        /// </summary>
        GUIDEx UnitID { get; }
        /// <summary>
        /// 获取任课班级ID.
        /// </summary>
        GUIDEx ClassID { get; }
        /// <summary>
        /// 获取学生姓名。
        /// </summary>
        string StudentName { get; }
        /// <summary>
        /// 获取作品名称。
        /// </summary>
        string WorkName { get; }
        /// <summary>
        /// 获取作品状态。
        /// </summary>
        GUIDEx WorkStatus { get; }
        /// <summary>
        /// 绑定学校单位数据。
        /// </summary>
        /// <param name="data"></param>
        void BindUnit(IListControlsData data);
        /// <summary>
        /// 绑定任课班级。
        /// </summary>
        /// <param name="data"></param>
        void BindClasses(IListControlsData data);
        /// <summary>
        /// 绑定作品状态。
        /// </summary>
        /// <param name="data"></param>
        void BindWorkStatus(IListControlsData data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }
    /// <summary>
    /// 
    /// </summary>
    public class SFITeaStudentWorksPresenter : ModulePresenter<ISFITeaStudentWorksListView>
    {
        #region 成员变量，构造函数。
        SFITStudentWorksEntity studentWorksEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public SFITeaStudentWorksPresenter(ISFITeaStudentWorksListView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.TeaStudentWorks_ModuleID;
            this.studentWorksEntity = new SFITStudentWorksEntity();
        }
        #endregion

        #region 重载。
        protected override void PreViewLoadData()
        {
            this.View.BindUnit(new SFITSchoolsEntity().BindSchools(this.View.CurrentUserID));
            this.View.BindClasses(new SFITClassEntity().BindClassByTeacher(this.View.CurrentUserID));
            this.View.BindWorkStatus(this.BindEnumWorkStatusData());
        }
        #endregion

         #region 数据操作函数。
        /// <summary>
        /// 列表数据源
        /// </summary>
        public DataTable ListDataScuore
        {
            get
            {
                DataTable dtSource = this.studentWorksEntity.ListDataSource(this.View.UnitID, this.View.ClassID, 
                    this.View.StudentName, this.View.WorkName, this.View.WorkStatus);
                if (dtSource != null)
                {
                    dtSource.Columns.Add("WorkStatusName", typeof(string));
                    foreach (DataRow row in dtSource.Rows)
                    {
                        row["WorkStatusName"] = this.GetEnumWorkStatusName((EnumWorkStatus)Convert.ToInt32(row["WorkStatus"]));
                    }
                    return dtSource;
                }
                return null;
            }
        }
        /// <summary>
        /// 批量删除。
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
