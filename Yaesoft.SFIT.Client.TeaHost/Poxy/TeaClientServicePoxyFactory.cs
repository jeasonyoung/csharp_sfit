//================================================================================
//  FileName: TeaClientServicePoxyFactory.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/3/30
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using Yaesoft.SFIT.Client.Data;
using Yaesoft.SFIT.Client.Forms;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Utils;
namespace Yaesoft.SFIT.Client.TeaHost.Poxy
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userInfo"></param>
    /// <param name="e"></param>
    public delegate void UserAuthenticationHandler(LocalUserInfo userInfo, Exception e);
    /// <summary>
    ///  Web代理工厂类。
    /// </summary>
    internal class TeaClientServicePoxyFactory : IDisposable
    {
        #region 成员变量，构造函数。
        Credentials cert = null;
        Impl.TeaClientServicePoxy poxy;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="cert"></param>
        private TeaClientServicePoxyFactory(Credentials cert)
        {
            this.cert = cert;
            Impl.CredentialSoapHeader header = new Impl.CredentialSoapHeader();
            header.SchoolID = this.cert.SchoolID;
            header.AccessAccount = this.cert.AccessAccount;
            header.AccessPassword = this.cert.AccessPassword;

            this.poxy = new Impl.TeaClientServicePoxy();
            this.poxy.Url = cert.ServiceURL;
            this.poxy.CredentialSoapHeaderValue = header;
        }
        #endregion

        #region 单例处理。
        private static Hashtable PoxyCache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 创建静态实例。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="Changed"></param>
        /// <returns></returns>
        public static TeaClientServicePoxyFactory Instance(ICoreService service, RaiseChangedHandler changed)
        {
            lock (typeof(TeaClientServicePoxyFactory))
            {
                Credentials cert = service["credentials"] as Credentials;
                if (cert == null)
                {
                    throw new Exception("容器中密钥丢失！请关闭系统后重新登录！");
                }
                TeaClientServicePoxyFactory factory = PoxyCache[cert] as TeaClientServicePoxyFactory;
                if (factory == null)
                {
                    factory = new TeaClientServicePoxyFactory(cert);
                    PoxyCache[cert] = factory;
                }
                factory.Changed = changed;
                return factory;
            }
        }
        #endregion

        #region 事件处理。
        /// <summary>
        /// 通知外部消息。
        /// </summary>
        protected event RaiseChangedHandler Changed;
        /// <summary>
        /// 触发通知外部消息。
        /// </summary>
        /// <param name="message"></param>
        protected void RaiseChanged(string message)
        {
            RaiseChangedHandler handler = this.Changed;
            if (handler != null)
            {
                handler(message);
            }
        }
        #endregion

        /// <summary>
        /// 身份验证。
        /// </summary>
        /// <param name="authen"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void Authentication(EnumUserAuthen authen, string account, string password, UserAuthenticationHandler handler)
        {
            try
            {
                if (string.IsNullOrEmpty(account))
                    throw new ArgumentNullException("account", "账号为空！");
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentNullException("password", "密码为空！");
                this.RaiseChanged("开始连接服务器，请稍后...");
                this.poxy.BeginVerifyUserIdentity((int)authen, account, password, new AsyncCallback(delegate(IAsyncResult callback)
                {
                    this.RaiseChanged("等待服务器返回，请稍后...");
                    try
                    {
                        Impl.CallResult callResult = this.poxy.EndVerifyUserIdentity(callback);
                        this.RaiseChanged("已返回数据，开始分析...");
                        if (callResult.ResultCode == 0)
                        {
                            if (handler != null)
                            {
                                string[] arr = callResult.ResultMessage.Split(',');
                                if (arr != null && arr.Length >= 3)
                                {
                                    LocalUserInfo info = new LocalUserInfo();
                                    info.SchoolID = this.cert.SchoolID;
                                    info.UserAccount = account;
                                    info.Password = password;
                                    info.UserID = arr[0];
                                    info.UserCode = arr[1];
                                    info.UserName = arr[2];
                                    handler(info, null);
                                }
                            }
                            this.RaiseChanged("身份验证通过...");
                        }
                        else
                        {
                            string err = "身份验证失败，" + callResult.ResultMessage;
                            handler(null, new Exception(err));
                        }
                    }
                    catch (Exception)
                    {
                        this.RaiseChanged("发生异常");
                        handler(null, new Exception("发生网络异常"));
                    }
                }), null);
            }
            catch (Exception e)
            {
                this.RaiseChanged("发生异常：" + e.Message);
                handler(null, new Exception("发生网络异常"));
            }
        }
        /// <summary>
        /// 下载同步数据。
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="complete"></param>
        public void TeaDownSync(string teacherID, EventHandler complete)
        {
            lock (this)
            {
                this.RaiseChanged("【准备下载同步数据...】");
                try
                {
                    this.RaiseChanged("【开始下载同步数据...】");
                    this.poxy.BeginDownloadTeaSyncData(teacherID, new AsyncCallback(delegate(IAsyncResult callback)
                    {
                        this.RaiseChanged("【正在下载同步数据，请稍候...】");
                        Impl.GeneralCallResultOfTeaSyncData result = this.poxy.EndDownloadTeaSyncData(callback);
                        if (result != null)
                        {
                            this.RaiseChanged("【下载同步数据完成，开始分析数据...】");
                            if (result.ResultCode == 0 && result.Data != null)
                            {
                                this.RaiseChanged("【开始装载数据...】");
                                TeaSyncData sync = new TeaSyncData();
                                sync.Time = DateTime.Now;
                                #region 同步学校信息。
                                Impl.School school = result.Data.School;
                                if (school != null)
                                {
                                    sync.School.SchoolID = school.SchoolID;
                                    sync.School.SchoolCode = school.SchoolCode;
                                    sync.School.SchoolName = school.SchoolName;
                                    sync.School.SchoolType = (EnumSchoolType)((int)school.SchoolType);
                                    this.RaiseChanged("【已装载学校数据：" + sync.School + "】");

                                    #region 同步教师信息。
                                    Impl.Teacher teacher = school.Teacher;
                                    if (teacher != null)
                                    {
                                        sync.School.Teacher.TeacherID = teacher.TeacherID;
                                        sync.School.Teacher.TeacherCode = teacher.TeacherCode;
                                        sync.School.Teacher.TeacherName = teacher.TeacherName;
                                        #region 同步年级。
                                        Impl.Grade[] grades = teacher.Grades;
                                        if (grades != null && grades.Length > 0)
                                        {
                                            foreach (Impl.Grade grade in grades)
                                            {
                                                this.RaiseChanged(string.Format("【开始装载年级数据[{0}]..】", grade.GradeName));
                                                Grade g = new Grade();
                                                g.GradeID = grade.GradeID;
                                                g.GradeCode = grade.GradeCode;
                                                g.GradeName = grade.GradeName;
                                                g.OrderNO = grade.OrderNO;

                                                #region 客观评价。
                                                Impl.Evaluate evaluate = grade.Evaluate;
                                                if (evaluate != null)
                                                {
                                                    this.RaiseChanged(string.Format("【开始装载年级[{0}]下客观评价[{1}]数据..】", grade.GradeName, evaluate.EvaluateName));
                                                    g.Evaluate.EvaluateID = evaluate.EvaluateID;
                                                    g.Evaluate.EvaluateName = evaluate.EvaluateName;
                                                    g.Evaluate.Type = (EnumEvaluateType)((int)evaluate.Type);
                                                    g.Evaluate.MinValue = evaluate.MinValue;
                                                    g.Evaluate.MaxValue = evaluate.MaxValue;

                                                    Impl.EvaluateItem[] items = evaluate.Items;
                                                    if (items != null && items.Length > 0)
                                                    {
                                                        for (int i = 0; i < items.Length; i++)
                                                        {
                                                            EvaluateItem item = new EvaluateItem();
                                                            item.ItemID = items[i].ItemID;
                                                            item.ItemName = items[i].ItemName;
                                                            item.ItemValue = items[i].ItemValue;
                                                            g.Evaluate.Items.Add(item);
                                                        }
                                                    }
                                                }
                                                #endregion

                                                #region 目录。
                                                Impl.Catalog[] catalogs = grade.Catalogs;
                                                if (catalogs != null && catalogs.Length > 0)
                                                {
                                                    for (int i = 0; i < catalogs.Length; i++)
                                                    {
                                                        Catalog catalog = new Catalog();
                                                        catalog.CatalogID = catalogs[i].CatalogID;
                                                        catalog.CatalogCode = catalogs[i].CatalogCode;
                                                        catalog.CatalogName = catalogs[i].CatalogName;
                                                        catalog.TypeName = catalogs[i].TypeName;
                                                        catalog.OrderNO = catalogs[i].OrderNO;

                                                        this.RaiseChanged(string.Format("【开始装载年级[{0}]下科目[{1}]数据..】", grade.GradeName, catalogs[i].CatalogName));

                                                        #region 知识要点。
                                                        Impl.KnowledgePoint[] points = catalogs[i].Points;
                                                        if (points != null && points.Length > 0)
                                                        {
                                                            this.RaiseChanged(string.Format("【开始装载年级[{0}]下科目[{1}]下知识要点数据..】", grade.GradeName, catalogs[i].CatalogName));
                                                            for (int j = 0; j < points.Length; j++)
                                                            {
                                                                KnowledgePoint point = new KnowledgePoint();
                                                                point.PointID = points[j].PointID;
                                                                point.PointCode = points[j].PointCode;
                                                                point.PointName = points[j].PointName;
                                                                point.Description = points[j].Description;
                                                                point.OrderNO = points[j].OrderNO;

                                                                catalog.Points.Add(point);
                                                            }
                                                        }
                                                        #endregion

                                                        g.Catalogs.Add(catalog);
                                                    }
                                                }
                                                #endregion

                                                #region 班级。
                                                Impl.Class[] classes = grade.Classes;
                                                if (classes != null && classes.Length > 0)
                                                {
                                                    for (int i = 0; i < classes.Length; i++)
                                                    {
                                                        Class c = new Class();
                                                        c.ClassID = classes[i].ClassID;
                                                        c.ClassCode = classes[i].ClassCode;
                                                        c.ClassName = classes[i].ClassName;
                                                        c.OrderNO = classes[i].OrderNO;

                                                        this.RaiseChanged(string.Format("【开始装载年级[{0}]下班级[{1}]数据..】", grade.GradeName, classes[i].ClassName));

                                                        #region 学生。
                                                        Impl.Student[] students = classes[i].Students;
                                                        if (students != null && students.Length > 0)
                                                        {
                                                            for (int k = 0; k < students.Length; k++)
                                                            {
                                                                Student s = new Student();
                                                                s.StudentID = students[k].StudentID;
                                                                s.StudentCode = students[k].StudentCode;
                                                                s.StudentName = students[k].StudentName;
                                                                c.Students.Add(s);

                                                                this.RaiseChanged(string.Format("{0}.{1}[{2},{3}]", k + 1, s.StudentName, classes[i].ClassName, grade.GradeName));
                                                            }
                                                        }
                                                        #endregion

                                                        g.Classes.Add(c);
                                                    }
                                                }
                                                #endregion

                                                sync.School.Teacher.Grades.Add(g);
                                                this.RaiseChanged("【已装载完成年级数据：" + g.ToString() + "】");
                                            }
                                        }
                                        else
                                            this.RaiseChanged("同步年级信息失败！");
                                        #endregion
                                    }
                                    else
                                        this.RaiseChanged("同步教师信息失败！");
                                    #endregion
                                }
                                else
                                    this.RaiseChanged("同步学校信息失败！");
                                #endregion

                                this.RaiseChanged("【已完成装载数据，保存数据到本地存储...】");
                                TeaSyncData.Serialize(sync, FolderStructure.UserSyncDataFile(callback.AsyncState.ToString()));
                                this.RaiseChanged("【完成数据同步！】");
                                if (complete != null)
                                    complete(null, EventArgs.Empty);
                            }
                            else
                            {
                                this.RaiseChanged("【数据发生异常：" + result.ResultMessage + "】");
                            }
                        }
                    }), teacherID);
                }
                catch (Exception e)
                {
                    this.RaiseChanged("【下载同步数据发生异常】" + e.Message);
                }

            }
        }

        #region 上传学生作业。
        /// <summary>
        /// 上传学生作业。
        /// </summary>
        /// <param name="swp"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UploadStudentWorks(WorkUploadToServer.StudentWorkUpload swp, out string err)
        {
            err = null;
            bool result = false;
            try
            {
                string msg = null;
                this.RaiseChanged(msg = "开始装载上传学生作业...");
                swp.Progress.UpdateProgressToolTipMessage(msg);

                #region 装载上传作业。
                
                Impl.StudentWorkTeaUpload upload = new Impl.StudentWorkTeaUpload();
                upload.Student = new Impl.Student();
                upload.Student.StudentID = swp.Student.StudentID;
                upload.Student.StudentCode = swp.Student.StudentCode;
                upload.Student.StudentName = swp.Student.StudentName;

                upload.WorkID = swp.Student.Work.WorkID;
                upload.WorkName = swp.Student.Work.WorkName;

                upload.Type = (Impl.EnumWorkType)((int)swp.Student.Work.Type);
                upload.Time = DateTime.Now;
                upload.Status = (Impl.EnumWorkStatus)((int)swp.Student.Work.Status);

                if (swp.Student.Work.Review != null)
                {
                    upload.Review = new Impl.TeacherReview();
                    upload.Review.TeacherID = swp.Student.Work.Review.TeacherID;
                    upload.Review.TeacherName = swp.Student.Work.Review.TeacherName;
                    upload.Review.EvaluateType = (Impl.EnumEvaluateType)((int)swp.Store.Evaluate.Type);
                    upload.Review.ReviewValue = swp.Student.Work.Review.ReviewValue;
                    upload.Review.SubjectiveReviews = swp.Student.Work.Review.SubjectiveReviews;

                    if ((upload.Status & Impl.EnumWorkStatus.Review) != Impl.EnumWorkStatus.Review)
                    {
                        upload.Status |= Impl.EnumWorkStatus.Review;
                        this.RaiseChanged(msg = "标记作业已批阅");
                        swp.Progress.UpdateProgressToolTipMessage(msg);
                    }
                }

                upload.GradeID = swp.Store.GradeID;
                upload.ClassID = swp.Store.ClassID;

                upload.CatalogID = swp.Store.CatalogID;
                upload.CatalogName = swp.Store.CatalogName;

                upload.Files = new Impl.StudentWorkFile();
                upload.Files.ContentType = "application/x-zip-compressed";
                upload.Files.FileID = upload.WorkID;
                upload.Files.FileName = upload.WorkName + ".zip";
                upload.Files.FileExt = ".zip";

                byte[] data = swp.LoadZipFiles(out err);
                if (data == null || data.Length == 0)
                {
                    if (string.IsNullOrEmpty(err)) err = "获取作业数据时发生未知异常！";
                    this.RaiseChanged(err);
                    return result;
                }

                upload.CheckCode = UtilTools.SummaryEncry(data);
                this.RaiseChanged(msg = "完成上传作业装载.");
                swp.Progress.UpdateProgressToolTipMessage(msg);
                #endregion

                swp.Progress.ProgressMaximum = data.Length;
                upload.Files.OffSet = 0;
                string info = string.Format("[{0},{1}]", upload.Student.StudentName, upload.WorkName);
                this.RaiseChanged(msg = info + "开始分段上传作业,请稍后...");
                swp.Progress.UpdateProgressToolTipMessage(msg);
                using (MemoryStream ms = new MemoryStream(data))
                {
                    result = true;
                    byte[] buf = new byte[1024];
                    int count = 0;
                    while ((count = ms.Read(buf, 0, buf.Length)) > 0)
                    {
                        if (count < buf.Length)
                        {
                            byte[] array = new byte[count];
                            Array.Copy(buf, array, count);
                            upload.Files.Data = array;
                        }
                        else
                        {
                            upload.Files.Data = buf;
                        }
                        Impl.CallResult callback = this.poxy.UploadStudentWorks(upload);
                        if (callback == null || callback.ResultCode < 0)
                        {
                            err = callback == null ? "服务无响应！" : callback.ResultMessage;
                            result = false;
                            swp.Progress.UploadFailure(err);
                            break;
                        }
                        swp.Progress.UpdateProgress(count);
                        upload.Files.OffSet += count;
                        System.Threading.Thread.Sleep(20);
                        ms.Seek(upload.Files.OffSet, SeekOrigin.Begin);
                    }
                }
                this.RaiseChanged(msg = info + "分段上传完成[" + (result ? "成功" : "失败[" + err + "]") + "]");
                swp.Progress.UpdateProgressToolTipMessage(msg);
            }
            catch (Exception e)
            {
                result = false;
                swp.Progress.UploadFailure(err = e.Message);
            }
            return result;
        }
        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 释放资源。
        /// </summary>
        public void Dispose()
        {
            if (this.poxy != null)
                this.poxy.Dispose();
        }

        #endregion

        #region 辅助函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        private void RecordUploadException(string exception)
        {
            if (!string.IsNullOrEmpty(exception))
            {
                UtilTools.OnExceptionRecord(new Exception(exception), typeof(TeaClientServicePoxyFactory));
            }
        }
        #endregion
    }
    /// <summary>
    /// 用户身份。
    /// </summary>
    public enum EnumUserAuthen
    {
        /// <summary>
        /// 教师。
        /// </summary>
        Teacher = 1,
        /// <summary>
        /// 学生。
        /// </summary>
        Student = 2
    }
}
