//================================================================================
//  FileName: WorkUploadWindow.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/23
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Net;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Utils;
namespace Yaesoft.SFIT.ClientStudent
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WorkUploadWindow : BaseWindow
    {
        #region 成员变量，构造函数。
        private FileUploadItems fileUploadItems = null;
        private Catalog catalog = null;
        private bool bUploadComplete = false;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="items"></param>
        public WorkUploadWindow(ICoreService service, FileUploadItems items)
            : base(service)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.fileUploadItems = items;
        }
        #endregion

        #region  事件处理。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkUploadWindow_Load(object sender, EventArgs e)
        {
            this.bUploadComplete = true;
            this.CoreService.ForceQuit = false;
            this.catalog = this.CoreService["catalog"] as Catalog;
            if (this.catalog != null)
            {
                this.txtWorkName.Text = this.catalog.CatalogName;
                this.txtCatalogName.Text = string.Format("{0}({1})", this.catalog.CatalogName, this.catalog.TypeName);
                this.OnToolTipEvent(this.txtCatalogName, string.Format("课程目录：{0}({1})\r\n课程代码：{2}\r\n课程ID：{3}\r\n知识要点：{4}",
                    this.catalog.CatalogName, this.catalog.TypeName, this.catalog.CatalogCode, this.catalog.CatalogID, Utilities.BuildKnowledgePointsToolTip(this.catalog.Points)));                
            }
            this.OnMessageEvent(MessageType.Normal, string.Empty);
            int len = 0;
            if (this.fileUploadItems != null && (len = this.fileUploadItems.Count) > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < len; i++)
                {
                    sb.AppendFormat("{0}.{1}\r\n", i + 1, this.fileUploadItems[i].FileName);
                }
                this.txtUploadFiles.Text = sb.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            string oldbtnText = this.btnUpload.Text;
            try
            {
                if (!this.btnUpload.Enabled) return;
                this.bUploadComplete = false;
                if (this.catalog == null) return;
                this.btnUpload.Text = "开始上传..";
                this.btnUpload.Enabled = false;
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(delegate(object o)
                {
                    UploadFileMSG msg = new UploadFileMSG();
                    msg.CatalogID = this.catalog.CatalogID;
                    msg.Student = this.CoreService["student"] as Student;
                    if (msg.Student != null)
                        msg.UID = msg.Student.StudentID;
                    msg.WorkID = Guid.NewGuid().ToString().Replace("-", "");
                    msg.WorkName = this.txtWorkName.Text.Trim();

                    this.OnClearErrorEvent();
                    if (string.IsNullOrEmpty(msg.WorkName))
                    {
                        this.OnSetErrorEvent(this.txtWorkName, "作品名称不能为空！");
                        return;
                    }
                    this.OnMessageEvent(MessageType.Normal, "开始上传数据准备...");
                    msg.WorkType = this.chkPublic.Checked ? EnumWorkType.Public : EnumWorkType.Protected;
                    msg.Description = this.txtDescription.Text;
                    msg.Time = DateTime.Now;
                    if (this.fileUploadItems == null || this.fileUploadItems.Count == 0)
                    {
                        this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, "未选择上传的作品附件！");
                        return;
                    }
                    msg.Files = new StudentWorkFiles();
                    #region 装载文件数据。
                    string path = null;
                    for (int i = 0; i < this.fileUploadItems.Count; i++)
                    {
                        if (File.Exists(path = this.fileUploadItems[i].Path))
                        {
                            StudentWorkFile swf = new StudentWorkFile();
                            swf.FileID = Guid.NewGuid().ToString().Replace("-", "");
                            swf.FileName = this.fileUploadItems[i].FileName;
                            swf.FileExt = this.fileUploadItems[i].Ext;
                            swf.ContentType = "application/octet-stream";
                            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                            {
                                byte[] buf = new byte[512];
                                swf.Size = stream.Length;
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    int len = 0;
                                    while ((len = stream.Read(buf, 0, buf.Length)) > 0)
                                    {
                                        ms.Write(buf, 0, len);
                                    }
                                    swf.Data = ms.ToArray();
                                }
                            }
                            msg.Files.Add(swf);
                        }
                    }
                    #endregion

                    PortSettings ports = this.CoreService["portsettings"] as PortSettings;
                    IPAddress hostIP = IPAddress.Parse(string.Format("{0}", this.CoreService["host_ip"]));
                    this.OnMessageEvent(MessageType.Normal, "上传数据准备完成，开始连接教师机主机...");
                    bool result = false;
                    using (TcpClientService tcs = new WorkUpTcpClient(new IPEndPoint(hostIP, ports.FileUpTransfer), ports.MaxFileSize))
                    {
                        tcs.Changed += new Yaesoft.SFIT.Client.RaiseChangedHandler(delegate(string content)
                        {
                            this.OnMessageEvent(MessageType.Normal, content);
                        });
                        result = tcs.Upload(msg);
                    }
                    System.Threading.Thread.Sleep(700);
                    this.ThreadSafeMethod(new MethodInvoker(delegate()
                    {
                        if (result) this.DialogResult = DialogResult.Yes;
                    }));
                    this.OnMessageEvent(MessageType.Normal | MessageType.PopupInfo, result ? "作品上传成功" : "作品上传失败，请重新上传！");
                    this.bUploadComplete = true;
                    this.ThreadSafeMethod(new MethodInvoker(delegate()
                    {
                        this.btnUpload.Text = oldbtnText;
                        this.btnUpload.Enabled = true;
                    }));
                }));
            }
            catch (Exception x)
            {
                this.OnMessageEvent(MessageType.Normal | MessageType.PopupWarn, "系统异常：" + x.Message);
                this.btnUpload.Text = oldbtnText;
                this.btnUpload.Enabled = true;
            }
        }
        #endregion

        #region 重载。
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!this.bUploadComplete) 
            {
                MessageBox.Show("正在上传作业，请稍等...", "系统提示", MessageBoxButtons.OK);
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        protected override void OnMessageEvent(MessageType type, string content)
        {
            content = content.Replace("\r\n", string.Empty);
            if ((type & MessageType.Normal) == MessageType.Normal)
            {
                this.ThreadSafeMethod(new MethodInvoker(delegate()
                {
                    this.lbMessage.Text = content;
                }));
            }
            base.OnMessageEvent(type, content);
        }
        #endregion
    }
}