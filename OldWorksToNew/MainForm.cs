//================================================================================
//  FileName: MainForm.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-4-28
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
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
namespace OldWorksToNew
{
    public partial class MainForm : Form
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件处理。
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.lbMessage.Text = string.Empty;
        }

        private void btnOldBowser_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtOldPath.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void btnBrowserRoot_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtNewRoot.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                this.errorProvider.Clear();
                if (!Directory.Exists(this.txtOldPath.Text))
                {
                    string err = "旧版备份HostData目录不存在！";
                    this.errorProvider.SetError(this.txtOldPath, err);
                    this.WriteMessage(err);
                    return;
                }
                if (!Directory.Exists(this.txtNewRoot.Text))
                {
                    string err = "目前版本HostData目录不存在！";
                    this.errorProvider.SetError(this.txtNewRoot, err);
                    this.WriteMessage(err);
                    return;
                }
                this.btnRun.Enabled = false;
                string old_seachPattern = "TeaStudentWorks_*.xml";
                this.WriteMessage("查找旧版索引文件[" + old_seachPattern + "]...");
                FileInfo[] oldIndexFiles = this.findFile(this.txtOldPath.Text, old_seachPattern);
                if (oldIndexFiles == null || oldIndexFiles.Length == 0)
                {
                    this.WriteMessage("没有在目录[" + this.txtOldPath.Text + "]及其子目录中找到索引文件[" + old_seachPattern + "],升级无法进行，请确认旧版目录！");
                    return;
                }
                this.WriteMessage("加载旧版索引文件：" + oldIndexFiles[0].FullName);
                string old_dir = Path.GetDirectoryName(oldIndexFiles[0].FullName);
                this.WriteMessage("获取旧版索引目录：" + old_dir);
                XmlDocument old_doc = null;
                using (FileStream fs = oldIndexFiles[0].Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    old_doc = new XmlDocument();
                    old_doc.Load(fs);
                }
                string techerId = this.loadXmlValue(old_doc.DocumentElement, "./TeacherID");
                this.WriteMessage("获取教师ID：" + techerId);
                string new_dir = this.findDir(this.txtNewRoot.Text, techerId);
                if (string.IsNullOrEmpty(new_dir))
                {
                    new_dir = Path.GetFullPath(this.txtNewRoot.Text + "//" + techerId);
                    Directory.CreateDirectory(new_dir);
                }
                this.WriteMessage("新版作业数据根目录：" + new_dir);
                XmlNodeList oldNodeList = old_doc.SelectNodes("//StudentWorkTeaStorage");
                if (oldNodeList == null || oldNodeList.Count == 0)
                {
                    this.WriteMessage("没有作业数据！");
                    return;
                }
                string old_UserSyncData_file_pattern = "UserSyncData_*.xml";
                this.WriteMessage("查找旧版同步文件[" + old_UserSyncData_file_pattern + "]...");
                FileInfo[] oldSyncFiles = this.findFile(old_dir, old_UserSyncData_file_pattern);
                XmlDocument oldSync_doc = null;
                if (oldSyncFiles == null || oldSyncFiles.Length == 0)
                {
                    this.WriteMessage("没有在目录[" + old_dir + "]及其子目录中找到同步文件[" + old_UserSyncData_file_pattern + "],则无法新建新版索引文件！");
                }
                else
                {
                    using (FileStream fs = oldSyncFiles[0].Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        oldSync_doc = new XmlDocument();
                        oldSync_doc.Load(fs);
                    }
                }
                for (int i = 0; i < oldNodeList.Count; i++)
                {
                    XmlElement element = oldNodeList[i] as XmlElement;
                    if (element == null)
                    {
                        this.WriteMessage(string.Format("第{0}条数据不是有效的作业信息！", i + 1));
                        continue;
                    }
                    this.WriteMessage("开始转换第[" + (i + 1) + "]个作业...");
                    try
                    {
                        this.TransWorks(old_dir, new_dir, element, oldSync_doc);
                    }
                    catch (Exception ex)
                    {
                        this.WriteMessage("发生异常："+ ex.Message);
                        this.WriteMessage("Source:" + ex.Source);
                        this.WriteMessage("StackTrace:" + ex.StackTrace);
                    }
                }
                this.WriteMessage("转换完毕！");
            }
            catch (Exception x)
            {
                this.WriteMessage(x.Message);
                MessageBox.Show(x.Message, "发生异常！");
            }
            finally
            {
                this.btnRun.Enabled = true;
            }
        }
        #endregion

        
        #region 辅助函数。
        private void TransWorks(string old_dir, string new_dir, XmlElement element,XmlDocument oldSync_doc)
        {
            string workId = this.loadXmlValue(element, "./WorkID");
            string workName = this.loadXmlValue(element, "./WorkName");
            string gradeId = this.loadXmlValue(element, "./GradeID");
            string classId = this.loadXmlValue(element, "./ClassID");
            string status = this.loadXmlValue(element, "./Status");
            string catalogId = this.loadXmlValue(element, "./CatalogID");
            string catalogName = this.loadXmlValue(element, "./CatalogName");
            string checkCode = this.loadXmlValue(element, "./CheckCode");
            string type = this.loadXmlValue(element, "./Type");
            string studentId = this.loadXmlValue(element, "./Student/StudentID");
            string studentCode = this.loadXmlValue(element, "./Student/StudentCode");
            string studentName = this.loadXmlValue(element, "./Student/StudentName");
            string time = this.loadXmlValue(element, "./Time");
            string description = this.loadXmlValue(element, "./Description");
            string workPath = this.loadXmlValue(element, "./WorkPath");
            string fileExt = this.loadXmlValue(element, "./FileExt");
            string uploadIP = this.loadXmlValue(element, "./UploadIP");
            string teacherID = this.loadXmlValue(element, "./Review/TeacherID");
            string teacherName = this.loadXmlValue(element, "./Review/TeacherName");
            string evaluateType = this.loadXmlValue(element, "./Review/EvaluateType");
            string reviewValue = this.loadXmlValue(element, "./Review/ReviewValue");
            string subjectiveReviews = this.loadXmlValue(element, "./Review/SubjectiveReviews");

            string new_root = Path.GetFullPath(string.Format("{0}\\{1}_{2}", new_dir, classId, catalogId));
            this.WriteMessage("新作业根目录：" + new_root);
            if (!Directory.Exists(new_root))
            {
                Directory.CreateDirectory(new_root);
                this.WriteMessage("创建目录成功！");
            }
            string new_index_file = Path.GetFullPath(string.Format("{0}\\TSW_{1}_{2}.cfg.xml", new_root, classId, catalogId));
            XmlDocument new_index_doc = null;
        
            #region 创建或获取索引文件。
            if (File.Exists(new_index_file))
            {
                using (FileStream fs = new FileStream(new_index_file, FileMode.Open, FileAccess.Read))
                {
                    new_index_doc = new XmlDocument();
                    new_index_doc.Load(fs);
                }
            }
            else
            {
                if (oldSync_doc == null)
                {
                    this.WriteMessage("没有旧版同步文件，无法创建新版索引文件！");
                    return;
                }
                XmlElement oldSync_doc_root = oldSync_doc.DocumentElement;
                new_index_doc = new XmlDocument();
                new_index_doc.LoadXml("<LocalStudentWorkStore/>");
                XmlElement root = new_index_doc.DocumentElement;
                this.createElement(ref new_index_doc, root, "TeacherID", teacherID);
                this.createElement(ref new_index_doc, root, "TeacherName", teacherName);
                this.createElement(ref new_index_doc, root, "GradeID", gradeId);
                string gradeName = this.loadXmlValue(oldSync_doc_root, "//Grade[GradeID='" + gradeId + "']/GradeName");
                this.WriteMessage(string.Format("获取年级名称：id:{0}=>name:{1}", gradeId, gradeName));
                this.createElement(ref new_index_doc, root, "GradeName", gradeName);
                this.createElement(ref new_index_doc, root, "CatalogID", catalogId);
                this.createElement(ref new_index_doc, root, "CatalogName", catalogName);
                this.createElement(ref new_index_doc, root, "ClassID", classId);
                string className = this.loadXmlValue(oldSync_doc_root, "//Class[ClassID='" + classId + "']/ClassName");
                this.WriteMessage(string.Format("获取班级名称：id:{0}=>name:{1}", classId, className));
                this.createElement(ref new_index_doc, root, "ClassName", className);
                this.createEvaluate(ref new_index_doc, root);
                this.createElement(ref new_index_doc, root, "Students", null);
            }
            #endregion

            //获取或设置学生节点。
            XmlElement worksEl, el = new_index_doc.SelectSingleNode("//LocalStudent[StudentID='" + studentId + "']") as XmlElement;
            #region 创建学生节点。
            this.WriteMessage("创建学生节点...");
            if (el == null)
            {
                el = this.createElement(ref new_index_doc, "LocalStudent", null);
                this.createElement(ref new_index_doc, el, "StudentID", studentId);
                this.createElement(ref new_index_doc, el, "StudentCode", studentCode);
                this.createElement(ref new_index_doc, el, "StudentName", studentName);
                worksEl = this.createElement(ref new_index_doc, el, "Works", null);

                XmlElement s = new_index_doc.SelectSingleNode(".//Students") as XmlElement;
                if (s != null)
                {
                    s.AppendChild(el);
                }
            }
            else
            {
                worksEl = el.SelectSingleNode("./Works ") as XmlElement;
                if (worksEl == null)
                {
                    worksEl = this.createElement(ref new_index_doc, el, "Works", null);
                }
            }
            #endregion


            XmlElement workEl = worksEl.SelectSingleNode("./LocalStudentWork[WorkID='" + workId + "']") as XmlElement;
            this.WriteMessage("创建作业节点...");
            #region 创建作业节点。
            if (workEl != null)
            {
                workEl.RemoveAll();
            }
            else
            {
                workEl = this.createElement(ref new_index_doc, worksEl, "LocalStudentWork", null);
            }
            this.createElement(ref new_index_doc, workEl, "WorkID", workId);
            this.createElement(ref new_index_doc, workEl, "WorkName", workName);
            XmlElement filesEl = this.createElement(ref new_index_doc, workEl, "WorkFiles", null);
            this.createElement(ref new_index_doc, workEl, "FileExt", fileExt);
            this.createElement(ref new_index_doc, workEl, "UploadIP", uploadIP);
            this.createElement(ref new_index_doc, workEl, "CheckCode", checkCode);
            this.createElement(ref new_index_doc, workEl, "Status", status);
            this.createElement(ref new_index_doc, workEl, "Type", type);
            this.createElement(ref new_index_doc, workEl, "Time", time);
            this.createCDATAElement(ref new_index_doc, workEl, "Description", description);
            XmlElement reviewEl = this.createElement(ref new_index_doc, workEl, "Review", null);
            this.createElement(ref new_index_doc, reviewEl, "TeacherID", teacherID);
            this.createElement(ref new_index_doc, reviewEl, "TeacherName", teacherName);
            this.createElement(ref new_index_doc, reviewEl, "ReviewValue", reviewValue);
            this.createCDATAElement(ref new_index_doc, reviewEl, "SubjectiveReviews", subjectiveReviews);
            #endregion

            //文件处理。
            string new_file_dir = Path.GetFullPath(string.Format("{0}\\{1}", new_root, studentId));
            this.WriteMessage("新作业存储目录："+ new_file_dir);
            if (!Directory.Exists(new_file_dir))
            {
                Directory.CreateDirectory(new_file_dir);
                this.WriteMessage("创建目录成功！");
            }

            string old_file_path = Path.GetFullPath(string.Format("{0}\\{1}", old_dir, workPath));
            this.WriteMessage("查找旧作业文件：" + old_file_path);
            if (File.Exists(old_file_path))
            {
                this.WriteMessage("找到旧作业文件，开始解压文件...");
                #region 解压文件。
                using (FileStream fs = new FileStream(old_file_path, FileMode.Open, FileAccess.Read))
                {
                    using (ZipInputStream inputStream = new ZipInputStream(fs))
                    {
                        ZipEntry entry = null;
                        while ((entry = inputStream.GetNextEntry()) != null)
                        {
                            string fName = Path.GetFileName(entry.Name);
                            if (!string.IsNullOrEmpty(fName) && (entry.CompressedSize > 0))
                            {
                                byte[] buffer = new byte[2048];
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    int count = 0;
                                    while ((count = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        ms.Write(buffer, 0, count);
                                    }
                                    ms.Position = 0;
                                    string new_fName = this.signStream(ms);
                                    string new_file_path = Path.GetFullPath(string.Format("{0}\\{1}{2}", new_file_dir, new_fName, Path.GetExtension(fName)));
                                    long length = 0;
                                    using (FileStream output = new FileStream(new_file_path, FileMode.Create, FileAccess.Write))
                                    {
                                        ms.Position = 0;
                                        while ((count = ms.Read(buffer, 0, buffer.Length)) > 0)
                                        {
                                            output.Write(buffer, 0, count);
                                            length += count;
                                        }
                                        output.Close();
                                    }
                                    ms.Close();

                                    XmlElement fEl = filesEl.SelectSingleNode("./LocalStudentWorkFile[FileID='" + new_fName + "']") as XmlElement;
                                    if (fEl == null)
                                    {
                                        fEl = this.createElement(ref new_index_doc, filesEl, "LocalStudentWorkFile", null);
                                    }
                                    else
                                    {
                                        fEl.RemoveAll();
                                    }
                                    this.createElement(ref new_index_doc, fEl, "FileID", new_fName);
                                    this.createElement(ref new_index_doc, fEl, "FileName",  Path.GetFileNameWithoutExtension(fName));
                                    this.createElement(ref new_index_doc, fEl, "FileExt", Path.GetExtension(fName));
                                    this.createElement(ref new_index_doc, fEl, "Size", length.ToString());
                                }
                            }
                        }
                        inputStream.Close();
                    }
                    fs.Close();
                }
                #endregion
            }
            else
            {
                this.WriteMessage("旧作业文件不存在！");
            }

            //保存新索引文件。
            if (new_index_doc != null)
            {
                new_index_doc.Save(new_index_file);
            }
            System.Threading.Thread.Sleep(200);
        }
        private void WriteMessage(string content)
        {
            this.lbMessage.Text = content;
            this.rtbLog.Text = "[" + DateTime.Now.ToString("HH:mm:ss.fff") + "]" + content + "\r\n" + this.rtbLog.Text;
            Application.DoEvents();
        }
        private FileInfo[] findFile(string dir,string seachPattern)
        {
            dir = Path.GetFullPath(dir);
            if (Directory.Exists(dir))
            {
                DirectoryInfo dinfo = new DirectoryInfo(dir);
                FileInfo[] files = dinfo.GetFiles(seachPattern);
                if (files == null || files.Length == 0)
                {
                    DirectoryInfo[] dirs = dinfo.GetDirectories();
                    if (dirs != null && dirs.Length > 0)
                    {
                        foreach (DirectoryInfo di in dirs)
                        {
                            files = this.findFile(di.FullName, seachPattern);
                            if (files != null && files.Length > 0)
                            {
                                break;
                            }
                        }
                    }
                }
                return files;
            }
            return null;
        }
        private string findDir(string root, string seachPattern)
        {
            root = Path.GetFullPath(root);
            string result = null;
            if (Directory.Exists(root))
            {
                DirectoryInfo info = new DirectoryInfo(root);
                DirectoryInfo[] dirs = info.GetDirectories(seachPattern);
                if (dirs == null || dirs.Length == 0)
                {
                    DirectoryInfo[] childs = info.GetDirectories();
                    if (childs != null && childs.Length > 0)
                    {
                        foreach (DirectoryInfo di in childs)
                        {
                            result = this.findDir(di.FullName, seachPattern);
                            if (!string.IsNullOrEmpty(result))
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    result = dirs[0].FullName;
                }
            }
            return result;
        }
        private string loadXmlValue(XmlElement e, string xpath)
        {
            if (e != null && !string.IsNullOrEmpty(xpath))
            {
                XmlNode node = e.SelectSingleNode(xpath);
                if (node != null)
                {
                    return node.InnerText;
                }
            }
            return null;
        }

        private XmlElement createElement(ref XmlDocument doc, string elementName, string value)
        {
            XmlElement e = doc.CreateElement(elementName);
            if (!string.IsNullOrEmpty(value))
            {
                e.AppendChild(doc.CreateTextNode(value));
            }
            return e;
        }
        private XmlElement createCDATAElement(ref XmlDocument doc, string elementName, string value)
        {
            XmlElement e = doc.CreateElement(elementName);
            e.AppendChild(doc.CreateCDataSection(value));
            return e;
        }
        private XmlElement createElement(ref XmlDocument doc, XmlElement root, string elementName, string value)
        {
            XmlElement e = this.createElement(ref doc, elementName, value);
            if (root != null)
            {
                root.AppendChild(e);
            }
            return e;
        }
        private XmlElement createCDATAElement(ref XmlDocument doc,XmlElement root, string elementName, string value)
        {
            XmlElement e = this.createCDATAElement(ref doc, elementName, value);
            if (root != null)
            {
                root.AppendChild(e);
            }
            return e;
        }
        private void createEvaluate(ref XmlDocument doc, XmlElement root)
        {
            XmlElement e = this.createElement(ref doc, "Evaluate", null);
            this.createElement(ref doc, e, "EvaluateID", "b6f23d6148a44941874cd43ed9b25971");
            this.createElement(ref doc, e, "EvaluateName", "四级等级制");
            this.createElement(ref doc, e, "Type", "Hierarchy");
            this.createElement(ref doc, e, "MaxValue", "0");
            this.createElement(ref doc, e, "MinValue", "0");

            XmlElement items = this.createElement(ref doc, e, "Items", null);

            XmlElement itemA = this.createElement(ref doc, items, "EvaluateItem", null);
            this.createElement(ref doc, itemA, "ItemID", "bd7e04a4734f40ac87d0313497da56a6");
            this.createElement(ref doc, itemA, "ItemName", "A");
            this.createElement(ref doc, itemA, "ItemValue", "A");

            XmlElement itemB = this.createElement(ref doc, items, "EvaluateItem", null);
            this.createElement(ref doc, itemB, "ItemID", "5886e078d9644765b997155b12dd7eaa");
            this.createElement(ref doc, itemB, "ItemName", "B");
            this.createElement(ref doc, itemB, "ItemValue", "B");

            XmlElement itemC = this.createElement(ref doc, items, "EvaluateItem", null);
            this.createElement(ref doc, itemC, "ItemID", "6108498519cf427e903be371a290d47e");
            this.createElement(ref doc, itemC, "ItemName", "C");
            this.createElement(ref doc, itemC, "ItemValue", "C");

            XmlElement itemD = this.createElement(ref doc, items, "EvaluateItem", null);
            this.createElement(ref doc, itemD, "ItemID", "a9e267e8d3504d9cbc79d8292161fac5");
            this.createElement(ref doc, itemD, "ItemName", "D");
            this.createElement(ref doc, itemD, "ItemValue", "D");
        }

        private string signStream(Stream stream)
        {
            string result = string.Empty;
            if (stream != null)
            {
                byte[] data = System.Security.Cryptography.MD5.Create().ComputeHash(stream);
                if (data != null && data.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sb.Append(data[i].ToString("x2", System.Globalization.CultureInfo.InvariantCulture));
                    }
                    result = sb.ToString();
                }
            }
            return result;
        }
        #endregion 
    }
}