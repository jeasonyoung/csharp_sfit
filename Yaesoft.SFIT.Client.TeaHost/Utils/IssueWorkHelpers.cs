//================================================================================
//  FileName: IssueWorkHelpers.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-26
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
using System.Windows.Forms;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.TeaHost.Net;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Controls;
namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// 作品分发帮助类。
    /// </summary>
    internal class IssueWorkHelpers
    {
        #region 成员变量，构造函数。
        private Panel panelWork;
        private HostNetService netService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="panelWork"></param>
        public IssueWorkHelpers(ICoreService service, Panel panelWork)
        {
            this.panelWork = panelWork;
            this.netService = HostNetService.Instance(service);
        }
        #endregion

        #region 公开函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="handler"></param>
        public void Issue(LocalStudentWorkStore store,RaiseChangedHandler handler)
        {
            lock (this)
            {
                if (store == null || store.Students == null)
                {
                    this.RaiseChanged(handler, "没有作品分发！");
                    MessageBox.Show("没有作品分发！");
                    return;
                }
                else if(this.netService != null && this.panelWork != null && this.panelWork.Controls != null)
                {
                    bool flag = false;
                    for (int i = 0; i < this.panelWork.Controls.Count; i++)
                    {
                        StudentControl sc = this.panelWork.Controls[i] as StudentControl;
                        if (sc != null && sc.UserInfo != null && ((sc.State & StudentControl.EnumStudentState.Online) == StudentControl.EnumStudentState.Online))
                        {
                            flag = true;
                            this.IssueWorkData(store,store.Students[sc.UserInfo.UserID], handler);
                        }
                    }
                    if (!flag)
                    {
                        string msg = "没有在线学生可分发作品数据！";
                        this.RaiseChanged(handler, msg);
                        MessageBox.Show(msg);
                    }
                }
            }
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="ls"></param>
        /// <param name="handler"></param>
        private void IssueWorkData(LocalStudentWorkStore store,LocalStudent ls, RaiseChangedHandler handler)
        {
            lock (this)
            {
                if (store != null && ls != null && ls.HasWork())
                {
                    LocalStudentWork lsw = ls.Work;
                    int len = 0;
                    if (lsw.WorkFiles != null && (len = lsw.WorkFiles.Count) > 0)
                    {
                        this.RaiseChanged(handler, string.Format("下发[{0},{1}]作品数据{2}", ls.StudentName, ls.StudentCode, lsw.WorkName));
                        string[] filePaths = new string[len];
                        for (int i = 0; i < len; i++)
                        {
                            filePaths[i] = lsw.StudentWorkFilePath(store, ls, lsw.WorkFiles[i]);
                        }
                        byte[] data = ZipUtils.Zip(filePaths);
                        if (data != null && data.Length > 0)
                        {
                            IssueWorkFile issue = new IssueWorkFile();
                            issue.StudentID = ls.StudentID;
                            issue.WorkName = lsw.WorkName;
                            issue.UID = store.TeacherID;
                            issue.Time = DateTime.Now;
                            issue.Data = data;
                            this.netService.SendIssueWork(issue);
                        }
                        else
                        {
                            this.RaiseChanged(handler, string.Format("压缩数据文件失败！[{0},{1}]", ls.StudentName, lsw.WorkName));
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        private void RaiseChanged(RaiseChangedHandler handler, string message)
        {
            if (handler != null)
            {
                handler(message);
            }
        }
        #endregion
    }
}