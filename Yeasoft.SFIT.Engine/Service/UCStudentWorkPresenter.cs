//================================================================================
//  FileName: UCStudentWorkPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/10
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
using System.Text;

using iPower;
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 界面接口。
    /// </summary>
    public interface IUCStudentWorkView : IModuleView
    {
        /// <summary>
        /// 绑定作品状态。
        /// </summary>
        /// <param name="data"></param>
        void BindWorkStatus(IListControlsData data);
        /// <summary>
        /// 绑定作品类型。
        /// </summary>
        /// <param name="data"></param>
        void BindWorkType(IListControlsData data);
        /// <summary>
        /// 加载学生作品信息。
        /// </summary>
        /// <param name="workID"></param>
        bool LoadData(GUIDEx workID);
        /// <summary>
        /// 保存学生作品信息。
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        bool SaveData(GUIDEx workID);
    }
    /// <summary>
    /// 学生作品行为类。
    /// </summary>
    public  class UCStudentWorkPresenter : ModulePresenter<IUCStudentWorkView>
    {
        #region 成员变量，构造函数。
        SFITStudentWorksEntity studentWorksEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public UCStudentWorkPresenter(IUCStudentWorkView view)
            : base(view)
        {
            this.studentWorksEntity = new SFITStudentWorksEntity();
        }
        #endregion

        #region 重载。
        protected override void PreViewLoadData()
        {
            IUCStudentWorkView workView = this.View as IUCStudentWorkView;
            if (workView != null)
            {
                workView.BindWorkStatus(this.BindEnumWorkStatusData());
                workView.BindWorkType(this.EnumDataSource(typeof(EnumWorkType)));
            }
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        public SFITStudentWorks LoadEntityData(GUIDEx workID)
        {
            if (workID.IsValid)
            {
                SFITStudentWorks data = new SFITStudentWorks();
                data.WorkID = workID;
                if (this.studentWorksEntity.LoadRecord(ref data))
                    return data;
            }
            return null;
        }
        /// <summary>
        ///  更新数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateEntityData(SFITStudentWorks data)
        {
            bool result = false;
            if (data != null && data.WorkID.IsValid)
            {
                SFITStudentWorks old = new SFITStudentWorks();
                old.WorkID = data.WorkID;
                if (this.studentWorksEntity.LoadRecord(ref old))
                {
                    data.CheckCode = old.CheckCode;

                    data.SchoolID = old.SchoolID;
                    data.SchoolName = old.SchoolName;

                    data.GradeID = old.GradeID;
                    data.GradeName = old.GradeName;

                    data.ClassID = old.ClassID;
                    data.ClassName = old.ClassName;

                    data.StudentID = old.StudentID;
                    data.StudentName = old.StudentName;

                    data.CatalogID = old.CatalogID;
                    data.CatalogName = old.CatalogName;

                    result = this.studentWorksEntity.UpdateRecord(data);
                }
            }
            return result;
        }
        #endregion
    }
}
