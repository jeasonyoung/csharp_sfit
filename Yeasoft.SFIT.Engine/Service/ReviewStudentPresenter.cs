//================================================================================
//  FileName: ReviewStudentPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/2/29
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
    /// 教师评阅视图接口。
    /// </summary>
    public interface IReviewStudentView : IModuleView
    {
        /// <summary>
        /// 加载评阅数据。
        /// </summary>
        /// <param name="workID"></param>
        void LoadData(GUIDEx workID);
        /// <summary>
        /// 保存评阅数据。
        /// </summary>
        /// <param name="workID"></param>
        void SaveData(GUIDEx workID);
        /// <summary>
        /// 绑定评阅数据。
        /// </summary>
        /// <param name="data"></param>
        void BindReviewValue(IListControlsData data);
    }
    /// <summary>
    /// 教师评阅行为类。
    /// </summary>
    public class ReviewStudentPresenter : ModulePresenter<IReviewStudentView>
    {
        #region 成员变量，构造函数。
        SFITeaReviewStudentEntity teaReviewStudentEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public ReviewStudentPresenter(IReviewStudentView view)
            : base(view)
        {
            this.teaReviewStudentEntity = new SFITeaReviewStudentEntity();
        }
        #endregion

        #region 数据操作。
        /// <summary>
        /// 加载教师评阅。
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        public void LoadReviewsData(GUIDEx workID, EventHandler<EntityEventArgs<SFITeaReviewStudent>> handler)
        {
            if (workID.IsValid)
            {
                SFITeaReviewStudent data = new SFITeaReviewStudent();
                data.WorkID = workID;
                if (this.teaReviewStudentEntity.LoadRecord(ref data))
                {
                    if (data.EvaluateType == (int)EnumEvaluateType.Hierarchy)
                    {
                        SFITStudentWorks stuWork = new SFITStudentWorks();
                        stuWork.WorkID = data.WorkID;

                        if (new SFITStudentWorksEntity().LoadRecord(ref stuWork))
                        {
                            this.View.BindReviewValue(new SFITEvaluateSetEntity().BindEvaluateValues(stuWork.GradeID));
                        }
                    }

                    handler(this, new EntityEventArgs<SFITeaReviewStudent>(data));
                }
            }
         }
        /// <summary>
        /// 更新教师评阅。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateReviews(SFITeaReviewStudent data)
        {
            if (data != null && data.WorkID.IsValid)
            {
                SFITeaReviewStudent old = new SFITeaReviewStudent();
                old.WorkID = data.WorkID;
                if (this.teaReviewStudentEntity.LoadRecord(ref old))
                {
                    data.EvaluateType = old.EvaluateType;
                    data.TeacherID = old.TeacherID;
                    data.TeacharName = old.TeacharName;
                }
                return this.teaReviewStudentEntity.UpdateRecord(data);
            }
            return false;
        }
        #endregion
    }
}
