//================================================================================
//  FileName: TeaClassPresenterExtend.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/9
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
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 教师班级行为扩展。
    /// </summary>
    internal class TeaClassPresenterExtend<T>
        where T: IModuleView
    {
        #region 成员变量，构造函数。
        T theView;
        SFITTeaClassEntity teaClassEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public TeaClassPresenterExtend(T view)
        {
            this.theView = view;
            this.teaClassEntity = new SFITTeaClassEntity();
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                if (this.theView is ISFITTeaClassListView)
                {
                    return this.teaClassEntity.ListDataSource(((ISFITTeaClassListView)this.theView).SchoolName,
                                                              ((ISFITTeaClassListView)this.theView).TearcherName, 
                                                              ((ISFITTeaClassListView)this.theView).ClassName);
                }
                else if (this.theView is ISFITTeaClassByUnitListView)
                {
                    return this.teaClassEntity.ListDataSource(((ISFITTeaClassByUnitListView)this.theView).UnitID,
                                                              ((ISFITTeaClassByUnitListView)this.theView).TeacherName,
                                                              ((ISFITTeaClassByUnitListView)this.theView).ClassName);
                }
                return null;
            }
        }
        /// <summary>
        ///加载数据。
        /// </summary>
        /// <param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SchoolTeacherInfo>> handler)
        {
            if (this.theView is ISFITTeaClassEditView)
            {
                if (((ISFITTeaClassEditView)this.theView).TeacherID.IsValid)
                {
                    SFITeachers data = new SFITeachers();
                    data.TeacherID = ((ISFITTeaClassEditView)this.theView).TeacherID;
                    if (new SFITeachersEntity().LoadRecord(ref data))
                    {
                        SchoolTeacherInfo info = new SchoolTeacherInfo();
                        info.SchoolID = data.SchoolID;
                        info.SchoolName = data.SchoolName;
                        info.TeacherID = data.TeacherID;
                        info.TeacherName = data.TeacherName;
                        info.ClassIDCollection = this.teaClassEntity.GetClassByTeacher(info.TeacherID);

                        handler(this, new EntityEventArgs<SchoolTeacherInfo>(info));
                    }
                }
            }
            else if (this.theView is ISFITTeaClassByUnitEditView)
            {
                if (((ISFITTeaClassByUnitEditView)this.theView).TeacherID.IsValid)
                {
                    SFITeachers data = new SFITeachers();
                    data.TeacherID = ((ISFITTeaClassByUnitEditView)this.theView).TeacherID;
                    if (new SFITeachersEntity().LoadRecord(ref data))
                    {
                        SchoolTeacherInfo info = new SchoolTeacherInfo();
                        info.SchoolID = data.SchoolID;
                        info.SchoolName = data.SchoolName;
                        info.TeacherID = data.TeacherID;
                        info.TeacherName = data.TeacherName;
                        info.ClassIDCollection = this.teaClassEntity.GetClassByTeacher(info.TeacherID);

                        handler(this, new EntityEventArgs<SchoolTeacherInfo>(info));
                    }
                }
            }
        }
        /// <summary>
        /// 保存数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateTeaClass(SchoolTeacherInfo data)
        {
            bool result = false;
            if (data != null && data.TeacherID.IsValid)
            {
                this.teaClassEntity.DeleteRecord(data.TeacherID);
                if (data.ClassIDCollection != null && data.ClassIDCollection.Count > 0)
                {
                    foreach (string classID in data.ClassIDCollection)
                    {
                        if (!string.IsNullOrEmpty(classID))
                        {
                            SFITTeaClass tc = new SFITTeaClass();
                            tc.ClassID = classID;
                            tc.TeacherID = data.TeacherID;
                            tc.TeacherName = data.TeacherName;
                            tc.CreateEmployeeID = this.theView.CurrentUserID;
                            tc.CreateEmployeeName = this.theView.CurrentUserName;
                            tc.LastModifyTime = DateTime.Now;
                            result = this.teaClassEntity.UpdateRecord(tc);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 批量删除数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteTeaClass(StringCollection priCollection)
        {
            return this.teaClassEntity.DeleteRecord(priCollection);
        }
        #endregion
    }

    /// <summary>
    /// 学校教师信息。
    /// </summary>
    public class SchoolTeacherInfo
    {
        /// <summary>
        /// 获取或设置学校ID。
        /// </summary>
        public GUIDEx SchoolID { get; set; }
        /// <summary>
        /// 获取或设置学校名称。
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 获取或设置教师ID。
        /// </summary>
        public GUIDEx TeacherID { get; set; }
        /// <summary>
        /// 获取或设置教师名称。
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 获取或设置班级ID集合。
        /// </summary>
        public StringCollection ClassIDCollection { get; set; }
    }
}
