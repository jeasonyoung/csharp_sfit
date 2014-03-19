//================================================================================
//  FileName: Form1.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-9-9
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
using System.Net;
using System.IO;
using System.Windows.Forms;

//using Yaesoft.SFIT.DataSync;
namespace Yaesoft.Furong.Test
{
    public partial class MainForm : Form
    {
        #region 成员变量,构造函数.
        //private IDataSync dataSync;
        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        static void WriteData(ref TextBox text, IListSource sources)
        {
            text.Text = "正在加载数据....";
            if (sources != null)
            {
                System.Collections.IList list = sources.GetList();
                if (list != null && list.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < list.Count; i++)
                    {
                        object obj = list[i];
                        if (obj != null)
                        {
                            sb.AppendLine(string.Format("{0}.{1}", i + 1, obj));
                        }
                    }
                    text.Text = sb.ToString();
                }
            }
        }
        static void WriteException(ref TextBox text,Exception e)
        {
            if (e != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(e.Message);
                sb.AppendLine(e.Source);
                sb.AppendLine(e.StackTrace);
                text.Text = sb.ToString();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.dataSync = new DataSyncFactory();
        }

        private void btn_loadUnit_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                SoapDataSyncFactory factory = new SoapDataSyncFactory();
                WriteData(ref this.txt_Unit, factory.SyncAllUnit());
            }
            catch (Exception ex)
            {
                WriteException(ref this.txt_Unit, ex);
            }
            finally
            {
                ((Button)sender).Enabled = true;
            }
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            try
            {
                SoapDataSyncFactory factory = new SoapDataSyncFactory();
                WriteData(ref this.txt_classes, factory.SyncAllTeachers(this.txtSchoolName.Text.Trim()));
            }
            catch (Exception ex)
            {
                WriteException(ref this.txt_classes, ex);
            }
            finally
            {
                ((Button)sender).Enabled = true;
            }
        }

        private void btnLoadStudents_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
               // WriteData(ref this.txt_students, this.dataSync.SyncAllStudents(this.txtUnitName.Text.Trim(), this.txtJoinYear.Text.Trim(), this.txtClassName.Text.Trim()));
            }
            catch (Exception ex)
            {
                WriteException(ref this.txt_students, ex);
            }
            finally
            {
                ((Button)sender).Enabled = true;
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                string url = this.txtPostUrl.Text.Trim();
                string data = this.txtPostData.Text.Trim();
                if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("Url");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";//请求方式。
                //request.ContentType = "text/xml; charset=utf-8";
                request.ContentType = "application/soap+xml; charset=utf-8";
                byte[] post = Encoding.UTF8.GetBytes(data);//编码方式.
                request.ContentLength = post.Length;
                //提交数据。
                using (Stream writer = request.GetRequestStream())
                {
                    writer.Write(post, 0, post.Length);
                }
                //获取返回数据。
                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
                {
                    HttpStatusCode status = resp.StatusCode;
                    if (status == HttpStatusCode.OK)
                    {
                        using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                        {
                            this.txtCallbackData.Text = reader.ReadToEnd();
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("状态码：{0}({1})", status, (int)status));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteException(ref this.txtCallbackData, ex);
            }
            finally
            {
                ((Button)sender).Enabled = true;
            }
        }
    }
}
