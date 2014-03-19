//================================================================================
//  FileName: mainForm.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-11-18
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
using System.Windows.Forms;
using System.IO;
namespace FileStorageTransferTools
{
    /// <summary>
    /// 
    /// </summary>
    public partial class mainForm : Form
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public mainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        private void mainForm_Load(object sender, EventArgs e)
        {
            this.progressBar.Visible = false;
        }

        private void txtPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtPath.Text = this.folderBrowserDialog.SelectedPath;
            }

        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            try
            {
                this.errorProvider.Clear();
                this.txtConn.ReadOnly = this.txtPath.ReadOnly = true;
                this.btnTrans.Enabled = false;
                string conn = this.txtConn.Text.Trim(), path = this.txtPath.Text.Trim();
                if (!Directory.Exists(path))
                {
                    this.errorProvider.SetError(this.txtPath, "目录路径不存在！");
                    return;
                }
                this.showMessage("开始查询数据...");
                string sql = "select LastModify,AccessoriesID,CheckCode,AccessoriesName from tblSFITAccessories order by LastModify desc,AccessoriesName";
                DataSet ds = new DataSet();
                using (System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(sql, conn))
                {
                    adapter.Fill(ds);
                }
                int count = 0;
                if (ds == null || ds.Tables.Count == 0 || (count = ds.Tables[0].Rows.Count) == 0)
                {
                    this.showMessage("没有数据！");
                    return;
                }

                this.progressBar.Visible = true;
                this.progressBar.Minimum = this.progressBar.Value = 0;
                this.progressBar.Maximum = count;
                this.progressBar.Step = 1;
                this.showMessage("查询到[" + ds.Tables[0].Rows.Count + "]条数据记录，准备开始移动文件...");

                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(delegate(object o)
                {
                    int index = 0;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        try
                        {
                            string accessoriesID = string.Format("{0}", row["AccessoriesID"]),
                                   accessoriesName = string.Format("{0}", row["AccessoriesName"]),
                                   checkCode = string.Format("{0}", row["CheckCode"]);

                            this.showMessage((index + 1) + ".准备移动文件：" + accessoriesName);
                            string oldFilePath = Path.GetFullPath(string.Format("{0}\\{1}_{2}{3}", path, accessoriesID, checkCode, Path.GetExtension(accessoriesName))),
                                   newFilePath = Path.GetFullPath(string.Format("{0}\\{1:yyyy-MM}\\{2}_{3}{4}", path, row["LastModify"], accessoriesID, checkCode, Path.GetExtension(accessoriesName)));

                            string newRootDir = Path.GetDirectoryName(newFilePath);
                            if (!Directory.Exists(newRootDir))
                            {
                                Directory.CreateDirectory(newRootDir);
                                this.showMessage("创建目录：" + newRootDir);
                            }

                            if (File.Exists(oldFilePath))
                            {
                                this.showMessage((index + 1) + ".找到文件：" + oldFilePath);
                                try
                                {
                                    File.Copy(oldFilePath, newFilePath);
                                    this.showMessage("移动到=>" + newFilePath);
                                    System.Threading.Thread.Sleep(50);
                                    File.Delete(oldFilePath);
                                    this.showMessage("移动成功！");
                                }
                                catch (Exception exc)
                                {
                                    this.showMessage(exc.Message);
                                }
                            }
                            else
                            {
                                this.showMessage((index + 1) + ".未找到文件：" + oldFilePath);
                            }
                            index++;

                            this.showProccess(index, count);

                            this.ThreadSafeMethod(this.progressBar, new MethodInvoker(delegate()
                            {
                                this.progressBar.PerformStep();
                            }));
                            
                            System.Threading.Thread.Sleep(200);
                        }
                        catch (Exception ex)
                        {
                            Program.OnExceptionRecord(ex, this.GetType());
                        }
                    }
                    this.txtConn.ReadOnly = this.txtPath.ReadOnly = false;
                    this.btnTrans.Enabled = true;
                }));
            }
            catch (Exception ex)
            {
                this.txtConn.ReadOnly = this.txtPath.ReadOnly = false;
                this.btnTrans.Enabled = true;
                Program.OnExceptionRecord(ex, this.GetType());
                MessageBox.Show(ex.Message);
            }
        }
        private void showMessage(string message)
        {
            this.ThreadSafeMethod(this.lbMessage, new MethodInvoker(delegate()
            {
                this.lbMessage.Text = message;
                this.lbMessage.Update();
            }));
        }

        private void showProccess(int index, int count)
        {
            string p = string.Format("{0}/{1} {2}%", index, count, Math.Round((index / (float)count) * 100, 2));

            this.ThreadSafeMethod(this.lbProccess, new MethodInvoker(delegate()
            {
                this.lbProccess.Text = p;
                this.lbProccess.Update();
            }));
        }
        /// <summary>
        /// 线程安全方法调用。
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="method"></param>
        private void ThreadSafeMethod(Control ctrl, MethodInvoker method)
        {
            if (ctrl != null && method != null)
            {
                if (ctrl.InvokeRequired)
                    ctrl.Invoke(method);
                else
                    method.Invoke();
            }
        }
        #endregion
    }
}