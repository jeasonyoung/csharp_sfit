//================================================================================
//  FileName: UCWorksCommentsPresenter.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/10
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
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Data;

using iPower;
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;

namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUCWorksCommentsView : IModuleView
    {
       
    }
    /// <summary>
    /// 作品评论视图接口。
    /// </summary>
    public interface IUCWorksCommentsListView : IUCWorksCommentsView
    {
        /// <summary>
        /// 获取或设置作品ID。
        /// </summary>
        GUIDEx WorkID { get; set; }
        /// <summary>
        /// 加载作品评论数据。
        /// </summary>
        /// <param name="workID"></param>
        /// <param name="showDeleteButtom"></param>
        void LoadData(GUIDEx workID, bool showDeleteButtom);
    }
     /// <summary>
    /// 作品评论视图接口。
    /// </summary>
    public interface IUCWorksCommentsEditView : IUCWorksCommentsView
    {
        /// <summary>
        /// 获取用户名。
        /// </summary>
        string Username { get; }
        /// <summary>
        /// 获取评论。
        /// </summary>
        string Comments { get; }
        /// <summary>
        /// 加载数据。
        /// </summary>
        /// <param name="workID"></param>
        void LoadData(GUIDEx workID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }
    /// <summary>
    /// 作品评论用户控件行为类。
    /// </summary>
    public class UCWorksCommentsPresenter : ModulePresenter<IUCWorksCommentsView>
    {
        #region 成员变量，构造函数。
        SFITWorksCommentsEntity worksCommentsEntity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public UCWorksCommentsPresenter(IUCWorksCommentsView view)
            : base(view)
        {
            this.worksCommentsEntity = new SFITWorksCommentsEntity();
        }
        #endregion

        #region 数据处理。
        /// <summary>
        /// 获取列表数据源。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                IUCWorksCommentsListView listView = this.View as IUCWorksCommentsListView;
                if (listView != null)
                    return this.worksCommentsEntity.ListDataSource(listView.WorkID);
                return null;
            }
        }
        public bool SaveData(GUIDEx workID, string userName, string comments, string clientIP)
        {
            bool result = false;
            if (workID.IsValid)
            {
                SFITWorksComments data = new SFITWorksComments();
                data.CommentID = GUIDEx.New;
                data.UserName = userName;
                data.Comment = comments;
                data.ClientIP = clientIP;
                data.WorkID = workID;
                data.Status = (int)EnumCommentStatus.Hide;
                data.CreateDateTime = DateTime.Now;

                result = this.worksCommentsEntity.UpdateRecord(data);
            }
            return result;
        }
        /// <summary>
        /// 批量删除评论。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteComents(StringCollection priCollection)
        {
            return this.worksCommentsEntity.DeleteRecord(priCollection);
        }
        #endregion
    }
}
