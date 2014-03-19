//================================================================================
//  FileName: StudentAttachmentPresenter.cs
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
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 学生作品附件界面接口。
    /// </summary>
    public interface IStudentAttachmentView : IModuleView
    {
        /// <summary>
        /// 获取或设置附件集合。
        /// </summary>
        Attachments WorkAttachments { get; set; }
        /// <summary>
        /// 加载附件数据。
        /// </summary>
        /// <param name="workID"></param>
        void LoadData(GUIDEx workID);
    }
    /// <summary>
    /// 学生作品附件行为类。
    /// </summary>
    public class StudentAttachmentPresenter: ModulePresenter<IStudentAttachmentView>
    {
        #region 成员变量，构造函数。
        SFITStudentAttachmentEntity studentAttachmentEntity;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="view"></param>
        public StudentAttachmentPresenter(IStudentAttachmentView view)
            : base(view)
        {
            this.studentAttachmentEntity = new SFITStudentAttachmentEntity();
        }
        #endregion

        #region  数据操作。
        /// <summary>
        /// 加载附件。
        /// </summary>
        /// <param name="workID"></param>
        public void LoadAttachments(GUIDEx workID)
        {
            Attachments attachments = null;
            List<SFITAccessories> list = this.studentAttachmentEntity.LoadAccessories(workID);
            if (list != null && list.Count > 0)
            {
                 attachments = new Attachments();
                 foreach (SFITAccessories att in list)
                 {
                     AttachmentInfo info = new AttachmentInfo();
                     info.FileID = att.AccessoriesID;
                     info.FileName = att.AccessoriesName;
                     info.CheckCode = att.CheckCode;
                     info.LastModify = att.LastModify;
                     attachments.Add(info);
                 }
            }
            this.View.WorkAttachments = attachments;
        }
        #endregion
    }
    /// <summary>
    ///附件信息。
    /// </summary>
    [Serializable]
    public class AttachmentInfo
    {
        /// <summary>
        /// 获取或设置文件ID。
        /// </summary>
        public string FileID { get; set; }
        /// <summary>
        /// 获取或设置文件。
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 获取或设置校验码。
        /// </summary>
        public string CheckCode { get; set; }
        /// <summary>
        /// 获取或设置最后修改时间。
        /// </summary>
        internal DateTime LastModify { get; set; }
    }
    /// <summary>
    /// 附件集合。
    /// </summary>
    [Serializable]
    public class Attachments: BaseCollection<AttachmentInfo>
    {
        public override AttachmentInfo this[string fileID]
        {
            get
            {
                if (!string.IsNullOrEmpty(fileID))
                {
                    AttachmentInfo result = this.Items.Find(new Predicate<AttachmentInfo>(delegate(AttachmentInfo sender)
                    {
                        return (sender != null) && (sender.FileID == fileID);
                    }));
                    return result;
                }
                return null;
            }
        }

        public override int Compare(AttachmentInfo x, AttachmentInfo y)
        {
            return DateTime.Compare(x.LastModify, y.LastModify);
        }
    }
}
