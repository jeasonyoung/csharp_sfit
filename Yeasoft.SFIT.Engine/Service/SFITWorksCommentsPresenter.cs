//================================================================================
// FileName: SFITWorksCommentsPresenter.cs
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
	/// ISFITWorksCommentsView接口。
	///</summary>
    public interface ISFITWorksCommentsView : IModuleView
    {
        /// <summary>
        /// 错误消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITWorksCommentsListView : ISFITWorksCommentsView
    {
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string UnitName { get; }
        /// <summary>
        /// 获取年级ID。
        /// </summary>
        GUIDEx GradeID { get; }
        /// <summary>
        /// 获取班级名称。
        /// </summary>
        string ClassName { get; }
        /// <summary>
        /// 获取课程目录。
        /// </summary>
        string CatalogName { get; }
        /// <summary>
        /// 获取学生姓名。
        /// </summary>
        string StudentName { get; }
        /// <summary>
        /// 获取作品名称。
        /// </summary>
        string WorkName { get; }
        /// <summary>
        /// 绑定年级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindGrades(IListControlsData data);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISFITWorksCommentsEditView : ISFITWorksCommentsView
    {
        /// <summary>
        /// 获取评论ID。
        /// </summary>
        GUIDEx CommentID { get; }
        /// <summary>
        /// 绑定评论状态数据。
        /// </summary>
        /// <param name="data"></param>
        void BindCommentStatus(IListControlsData data);
    }
		
	///<summary>
	/// SFITWorksCommentsPresenter行为类。
	///</summary>
    public class SFITWorksCommentsPresenter : ModulePresenter<ISFITWorksCommentsView>
    {
        #region 成员变量，构造函数。
        SFITWorksCommentsExtend<ISFITWorksCommentsView> extend = null;
        ///<summary>
        ///构造函数。
        ///</summary>
        public SFITWorksCommentsPresenter(ISFITWorksCommentsView view)
            : base(view)
        {
            this.View.SecurityID = ModuleConstants.WorksComments_ModuleID;
            this.extend = new SFITWorksCommentsExtend<ISFITWorksCommentsView>(this.View);
        }
        #endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            ISFITWorksCommentsListView listView = this.View as ISFITWorksCommentsListView;
            if (listView != null)
            {
                listView.BindGrades(new SFITGradeEntity().BindGrade);
            }
            ISFITWorksCommentsEditView editView = this.View as ISFITWorksCommentsEditView;
            if (editView != null)
            {
                editView.BindCommentStatus(this.EnumDataSource(typeof(EnumCommentStatus)));
            }
        }
        #endregion

        #region 数据操作函数。
        ///<summary>
        ///编辑页面加载数据。
        ///</summary>
        ///<param name="handler"></param>
        public void LoadEntityData(EventHandler<EntityEventArgs<SFITWorksComments>> handler)
        {
            this.extend.LoadEntityData(handler);
        }
        /// <summary>
        /// 更新更新评论状态。
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateCommentsStatus(int status)
        {
            return this.extend.UpdateCommentsStatus(status);
        }
        /// <summary>
        /// 列表数据源
        /// </summary>
        public DataTable listDataSource
        {
            get { return this.extend.ListDataSource; }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteWorksComments(StringCollection priCollection)
        {
            return this.extend.BatchDeleteWorksComments(priCollection);
        }
        #endregion
    }
}
