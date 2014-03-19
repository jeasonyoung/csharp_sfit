//================================================================================
//  FileName: AccessoriesUtilsWin.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-11
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
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace Yaesoft.SFIT.AccessoriesUtils
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AccessoriesUtilsWin : Form
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 
        /// </summary>
        public AccessoriesUtilsWin()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        private void AccessoriesUtilsWin_Load(object sender, EventArgs e)
        {
            this.lbMessage.Visible = this.progressBar.Visible = false;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            if (this.folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtWorkRoot.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                #region 验证输入
                this.errorProvider.Clear();
                string strConn = this.txtConn.Text.Trim();
                if (string.IsNullOrEmpty(strConn))
                {
                    this.errorProvider.SetError(this.txtConn, "数据库链接字符串不能为空！");
                    return;
                }
                string root = this.txtWorkRoot.Text.Trim();
                if (string.IsNullOrEmpty(root))
                {
                    this.errorProvider.SetError(this.txtWorkRoot, "作业附件根目录不能为空！");
                    return;
                }
                if (!Directory.Exists(root))
                {
                    this.errorProvider.SetError(this.txtWorkRoot, "作业附件根目录不存在！");
                    return;
                }
                this.progressBar.Visible = false;
                #endregion

                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
                {
                    //
                    this.SafeThreadMethod(this.btnUpdate, new MethodInvoker(delegate()
                    {
                        this.btnUpdate.Enabled = false;
                    }));
                    try
                    {
                        #region 处理数据。
                        this.ShowMessage("开始链接数据库...");
                        const string cmd = "select AccessoriesID,AccessoriesName,CheckCode from tblSFITAccessories order by LastModify desc";
                        const string updateSql = "update tblSFITAccessories set CheckCode = '{0}' where AccessoriesID = '{1}'";
                        using (SqlConnection conn = new SqlConnection(strConn))
                        {
                            SqlDataAdapter ada = new SqlDataAdapter(cmd, conn);
                            DataSet set = new DataSet();
                            if (ada.Fill(set) > 0)
                            {
                                DataTable dtSource = set.Tables[0].Copy();
                                int len = 0;
                                if (dtSource != null && (len = dtSource.Rows.Count) > 0)
                                {
                                    #region 设置进度条。
                                    this.SafeThreadMethod(this.progressBar, new MethodInvoker(delegate()
                                    {
                                        this.progressBar.Minimum = 0;
                                        this.progressBar.Maximum = len;
                                        this.progressBar.Value = 0;
                                        this.progressBar.Visible = true;
                                    }));
                                    #endregion

                                    DirectoryInfo dirInfo = new DirectoryInfo(root);
                                    if (!dirInfo.Exists)
                                    {
                                        this.ShowMessage("目录不存在：" + root, true);
                                    }
                                    Regex regex = new Regex(@"^(?<WorkID>[0-9|a-f]+)_(?<CheckCode>[0-9|a-f]+)\.zip$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                    Queue<string> updateSqlQueue = new Queue<string>(), bakSqlQueue = new Queue<string>();

                                    #region 生成数据。
                                    foreach (DataRow row in dtSource.Rows)
                                    {
                                        #region 进度条。
                                        this.SafeThreadMethod(this.progressBar, new MethodInvoker(delegate()
                                        {
                                            this.progressBar.PerformStep();
                                        }));
                                        #endregion
                                        FileInfo[] files = dirInfo.GetFiles(string.Format("{0}_*", row["AccessoriesID"]), SearchOption.TopDirectoryOnly);
                                        if (files == null || files.Length == 0)
                                        {
                                            this.ShowMessage(string.Format("不存在文件：[{0}]{1}", row["AccessoriesID"], row["AccessoriesName"]), true);
                                        }
                                        else 
                                        {
                                            if (files.Length > 1)
                                            {
                                                StringBuilder sb = new StringBuilder();
                                                sb.AppendFormat("{0}个文件[", files.Length);
                                                for (int i = 0; i < files.Length; i++)
                                                {
                                                    sb.AppendFormat("{0}.{1}", i + 1, files[i].Name);
                                                }
                                                sb.Append("]");
                                                this.ShowMessage(string.Format("发现多个文件：[{0}]{1},{2}", row["AccessoriesID"], row["AccessoriesName"], sb.ToString()), true);
                                            }
                                            string strFileName = files[0].Name;
                                            this.ShowMessage("发现文件：" + strFileName, true);
                                            Match match = regex.Match(strFileName);
                                            if (match.Success)
                                            {
                                                string wid = match.Groups["WorkID"].Value;
                                                string code = match.Groups["CheckCode"].Value;
                                                this.ShowMessage(string.Format("文件名解析：{0},{1}", wid, code), true);
                                                string oldCode = string.Format("{0}", row["CheckCode"]);
                                                if (code != oldCode)
                                                {
                                                    this.ShowMessage(string.Format("校验码不一致({0} -> {1})", oldCode, code), true);
                                                    this.ShowMessage("准备更新数据库中的校验码");
                                                    bakSqlQueue.Enqueue(string.Format(updateSql, row["CheckCode"], row["AccessoriesID"]));
                                                    string sql = string.Format(updateSql, code, row["AccessoriesID"]);
                                                    this.ShowMessage("生成：" + sql);
                                                    //更新数据库。
                                                    updateSqlQueue.Enqueue(sql);
                                                }
                                                else
                                                {
                                                    this.ShowMessage(string.Format("校验码一致({0}={1})", oldCode, code), true);
                                                }
                                            }
                                            else
                                            {
                                                this.ShowMessage(string.Format("无法解析文件名：{0}({1})", strFileName, regex.ToString()), true);
                                            }
                                        }
                                        Thread.Sleep(10);
                                    }
                                    #endregion

                                    #region 备份。
                                    if (bakSqlQueue.Count > 0)
                                    {
                                        
                                        this.ShowMessage("生成备份数据脚本...", true);
                                        this.SafeThreadMethod(this.progressBar, new MethodInvoker(delegate()
                                        {
                                            this.progressBar.Minimum = 0;
                                            this.progressBar.Maximum = bakSqlQueue.Count;
                                            this.progressBar.Value = 0;
                                        }));
                                        while (bakSqlQueue.Count > 0)
                                        {
                                            #region 进度条。
                                            this.SafeThreadMethod(this.progressBar, new MethodInvoker(delegate()
                                            {
                                                this.progressBar.PerformStep();
                                            }));
                                            #endregion
                                            string bakSql = bakSqlQueue.Dequeue();
                                            this.ShowMessage("备份生成：" + bakSql, true);
                                            Thread.Sleep(10);
                                        }
                                    }
                                    #endregion
                                    
                                    #region 执行.
                                    if (updateSqlQueue.Count > 0)
                                    {
                                        this.SafeThreadMethod(this.progressBar, new MethodInvoker(delegate()
                                        {
                                            this.progressBar.Minimum = 0;
                                            this.progressBar.Maximum = bakSqlQueue.Count;
                                            this.progressBar.Value = 0;
                                        }));
                                        
                                        this.ShowMessage("准备执行脚本...", true);
                                        while (updateSqlQueue.Count > 0)
                                        {
                                            #region 进度条。
                                            this.SafeThreadMethod(this.progressBar, new MethodInvoker(delegate()
                                            {
                                                this.progressBar.PerformStep();
                                            }));
                                            #endregion

                                            StringBuilder sb = new StringBuilder();
                                            try
                                            {
                                                conn.Open();
                                                string run = updateSqlQueue.Dequeue();
                                                SqlCommand sqlCmd = new SqlCommand(run, conn);
                                                sb.AppendFormat("执行：{0} ", run);
                                                int result = sqlCmd.ExecuteNonQuery();
                                                sb.AppendFormat("【{0}({1})】", result > 0 ? "成功" : "失败", result);
                                            }
                                            catch (Exception c)
                                            {
                                                sb.AppendFormat("[{0}]", c.Message);
                                            }
                                            finally
                                            {
                                                conn.Close();
                                                this.ShowMessage(sb.ToString(), true);
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }

                        this.ShowMessage("处理完成!");
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        this.ShowMessage("发生异常：" + ex.Message);
                    }
                    finally
                    {
                        this.SafeThreadMethod(this.btnUpdate, new MethodInvoker(delegate()
                        {
                            this.btnUpdate.Enabled = true;
                        }));
                    }
                }));
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                this.ShowMessage("发生异常：" + x.Message);
                this.btnUpdate.Enabled = true;
            }
        }
        #endregion

        #region 辅助函数。
        private void SafeThreadMethod(Control ctrl, MethodInvoker method)
        {
            if (ctrl != null)
            {
                if (ctrl.InvokeRequired)
                {
                    if (method != null)
                    {
                        ctrl.Invoke(method);
                    }
                }
                else
                {
                    if (method != null)
                    {
                        method.Invoke();
                    }
                }
            }
        }
        private void ShowMessage(string message)
        {
            this.ShowMessage(message, false);
        }
        private void ShowMessage(string message, bool toLog)
        {
            this.SafeThreadMethod(this.lbMessage, new MethodInvoker(delegate()
            {
                this.lbMessage.Visible = true;
                this.lbMessage.Text = message;
                if (toLog)
                {
                    string path = Path.GetFullPath(string.Format("{0}\\AccessoriesUtils_{1:yyyyMMdd}.log", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now));
                    using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        sw.WriteLine(string.Format("[{0:yyyy-MM-dd HH:mm:ss}]{1}", DateTime.Now, message));
                        sw.Flush();
                    }
                }
            }));
        }
        #endregion
    }
}