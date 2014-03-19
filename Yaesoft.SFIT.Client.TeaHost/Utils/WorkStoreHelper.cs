//================================================================================
//  FileName: WorkStoreHelper.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-6-13
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
//using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using Yaesoft.SFIT.Client.Utils;
using Yaesoft.SFIT.Client.Net.MSG;
using Yaesoft.SFIT.Client.TeaHost.Data;
using Yaesoft.SFIT.Client.TeaHost.Net;
using Yaesoft.SFIT.Client.TeaHost.Controls;
namespace Yaesoft.SFIT.Client.TeaHost.Utils
{
    /// <summary>
    /// 作业存储帮助类。
    /// </summary>
    internal static class WorkStoreHelper
    {
        #region 成员变量。
        /// <summary>
        /// 计时器启动时间（毫秒）。
        /// </summary>
        private static readonly int DUE_TIME = 1000;
        /// <summary>
        /// 计时器间隔时间（毫秒）。
        /// </summary>
        private static readonly int PERIOD_TIME = 1000;
        /// <summary>
        /// 线程休眠时间（毫秒，避免资源被耗尽）。
        /// </summary>
        private static readonly int THREAD_SLEEP_TIME = 200;
        /// <summary>
        /// 自动丢弃的重复实体次数。
        /// </summary>
        private static readonly int AUTO_DISCARD_MINICOUNT = 5;
        #endregion

        #region 添加作业到存储。
        /// <summary>
        /// 添加作业存储队列。
        /// </summary>
        private static Queue QUEUE_WORK_STORE_ADD = Queue.Synchronized(new Queue());
        /// <summary>
        /// 添加作业消息到存储队列。
        /// </summary>
        /// <param name="entity"></param>
        public static void AddWorkToQueueStore(WorkAddQueueEntity entity)
        {
            if (entity == null) return;
            QUEUE_WORK_STORE_ADD.Enqueue(entity);
        }
        /// <summary>
        /// 添加作业存储队列操作计时器。
        /// </summary>
        private static readonly Timer timer_add_work_store_queue = new Timer(new TimerCallback(delegate(object sender)
        {
            //循环队列。
            while (QUEUE_WORK_STORE_ADD != null && QUEUE_WORK_STORE_ADD.Count > 0)
            {
                try
                {
                    #region 循环队列。
                    //获取队列头。
                    WorkAddQueueEntity entity = QUEUE_WORK_STORE_ADD.Dequeue() as WorkAddQueueEntity;
                    if (entity != null && entity.Count < AUTO_DISCARD_MINICOUNT && entity.Data != null)
                    {
                        UploadFileMSG data = entity.Data;
                        StudentEx stu = Program.STUDENTS[data.Student.StudentID];
                        if (stu == null)
                        {
                            entity.RaiseChanged(string.Format("学生[{0},{1},{2}]在当前上课班级中不存在，自动丢弃上传作业！", data.Student.StudentName, data.Student.StudentCode, data.WorkName));
                            continue;
                        }
                        LocalStudent ls = null;
                        LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(entity.TeacherID, data.CatalogID, entity.ClassID);
                        if (store != null && (ls = store.Students[data.Student.StudentID]) != null)
                        {
                            if (ls.Work != null && entity.Count > 0 && (ls.Work.Time.Ticks > entity.Ticks))
                            {
                                entity.RaiseChanged(string.Format("[{0},{1},{2}]在存储的作业新，所以放弃【重新排队[{3}]次】！",
                                        ls.StudentName, ls.StudentCode, data.WorkName, entity.Count));
                                continue;
                            }
                            ls.Work = new LocalStudentWork();
                            ls.Work.WorkID = data.WorkID;
                            ls.Work.WorkName = data.WorkName;
                            ls.Work.Description = data.Description;
                            ls.Work.Status = EnumWorkStatus.Recive;
                            ls.Work.Type = data.WorkType;
                            ls.Work.Time = DateTime.Now;
                            ls.Work.UploadIP = data.UIP;
                            //保存文件数据。
                            ls.Work.SaveFiles(store, ls, data.Files);
                            //保存数据。
                            if (!Serializer(ref store))
                            {
                                entity.RaiseChanged(string.Format("[{0},{1},{2}]文件被占用，等待重新排队处理！", ls.StudentName, ls.StudentCode, ls.Work.WorkName));
                                entity.Restart();
                                //重新加入队列。
                                AddWorkToQueueStore(entity);
                                continue;
                            }
                            //
                            entity.RaiseChanged(string.Format("[{0},{1},{2}]作业已持久化保存[{3}]！", ls.StudentName, ls.StudentCode, ls.Work.WorkName, entity.Count));
                            //更新状态。
                            #region 更新状态。
                            if (stu != null)
                            {
                                stu.Status |= StudentControl.EnumStudentState.Upload;
                                if ((stu.Status & StudentControl.EnumStudentState.Offline) == StudentControl.EnumStudentState.Offline)
                                {
                                    stu.Status &= ~StudentControl.EnumStudentState.Offline;
                                    stu.Status |= StudentControl.EnumStudentState.Online;
                                }
                                if ((stu.Status & StudentControl.EnumStudentState.Review) == StudentControl.EnumStudentState.Review)
                                {
                                    stu.Status &= ~StudentControl.EnumStudentState.Review;
                                }
                                entity.OnUpdateControls(stu);
                                entity.RaiseChanged(string.Format("[{0},{1}]状态[{2}]", ls.StudentName, ls.StudentCode, stu.Status));
                            }
                            #endregion
                        }

                    }
                    #endregion                   
                }
                catch (Exception e)
                {
                    UtilTools.OnExceptionRecord(e, typeof(WorkStoreHelper));
                }
                finally
                {
                    //避免资源被耗尽，线程休眠时间
                    Thread.Sleep(THREAD_SLEEP_TIME);
                }
            }

        }), null, DUE_TIME, PERIOD_TIME * new Random().Next(1, 10)); 
        #endregion

        #region 作业批阅存储。
        /// <summary>
        /// 作业批阅存储队列。
        /// </summary>
        private static Queue QUEUE_WORK_STORE_REVIEW = Queue.Synchronized(new Queue());
        /// <summary>
        /// 添加批阅到存储队列。
        /// </summary>
        /// <param name="entity"></param>
        public static void ReviewWorkToQueueStore(WorkReviewQueueEntity entity)
        {
            if (entity == null) return;
            QUEUE_WORK_STORE_REVIEW.Enqueue(entity);
        }
        /// <summary>
        /// 作业批阅存储队列处理定时器。
        /// </summary>
        private static readonly Timer timer_review_work_store_queue = new Timer(new TimerCallback(delegate(object sender)
        {
            //循环队列。
            while (QUEUE_WORK_STORE_REVIEW != null && QUEUE_WORK_STORE_REVIEW.Count > 0)
            {
                try
                {
                    #region 循环队列。
                    WorkReviewQueueEntity entity = QUEUE_WORK_STORE_REVIEW.Dequeue() as WorkReviewQueueEntity;
                    if (entity != null && entity.Count < AUTO_DISCARD_MINICOUNT && File.Exists(entity.StoreFilePath))
                    {

                        LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(entity.StoreFilePath);
                        if (store != null && store.Students != null && store.Students.Count > 0)
                        {
                            LocalStudent ls = store.Students[entity.StudentID];
                            if (ls != null && ls.Work != null && (ls.Work.WorkID == entity.WorkID))
                            {
                                bool serial = false;
                                if (entity.Review != null)
                                {
                                    ls.Work.Review = entity.Review;
                                    serial = true;
                                }

                                if ((ls.Work.Status & entity.Status) != entity.Status)
                                {
                                    ls.Work.Status |= entity.Status;
                                    serial = true;
                                }

                                if (!serial) continue;

                                if (!Serializer(ref store))
                                {
                                    entity.Restart();
                                    //重新加入队列。
                                    ReviewWorkToQueueStore(entity);
                                    continue;
                                }
                                entity.RaiseChanged(string.Format("作业[{0},{1}]批阅保存成功！", ls.StudentName, ls.Work.WorkName));
                            }
                        }

                    }
                    #endregion  
                }
                catch (Exception e)
                {
                    UtilTools.OnExceptionRecord(e, typeof(WorkStoreHelper));
                }
                finally
                {
                    //避免资源被耗尽，线程休眠时间
                    Thread.Sleep(THREAD_SLEEP_TIME);
                }
            }
        }), null, DUE_TIME, PERIOD_TIME * new Random().Next(1, 10));
        #endregion

        #region 更新作业状态存储。
        /// <summary>
        /// 更新作业状态存储。
        /// </summary>
        /// <param name="entity"></param>
        public static void UpdateWorkStatusToQueueStore(WorkReviewQueueEntity entity)
        {
            if (entity == null) return;
            QUEUE_WORK_STORE_REVIEW.Enqueue(entity);
        }
        #endregion

        #region 更新作业信息。
        /// <summary>
        /// 作业更新队列。
        /// </summary>
        private static Queue QUEUE_WORK_STORE_UPDATE = Queue.Synchronized(new Queue());
        /// <summary>
        /// 更新作业信息存储队列。
        /// </summary>
        /// <param name="entity"></param>
        public static void UpdateWorkInfoToQueueStore(UpdateWorkInfoQueueEntity entity)
        {
            if (entity != null && entity.Work != null)
            {
                QUEUE_WORK_STORE_UPDATE.Enqueue(entity);
            }
        }
        /// <summary>
        /// 作业更新队列处理定时器。
        /// </summary>
        private static readonly Timer timer_update_work_store_queue = new Timer(new TimerCallback(delegate(object sender) {
            //循环队列。
            while (QUEUE_WORK_STORE_UPDATE != null && QUEUE_WORK_STORE_UPDATE.Count > 0)
            {
                try
                {
                    #region 循环处理。
                    UpdateWorkInfoQueueEntity entity = QUEUE_WORK_STORE_UPDATE.Dequeue() as UpdateWorkInfoQueueEntity;
                    if (entity != null && entity.Count < AUTO_DISCARD_MINICOUNT && File.Exists(entity.StoreFilePath) && entity.Work != null)
                    {
                        LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(entity.StoreFilePath);
                        if (store != null && store.Students != null && store.Students.Count > 0)
                        {
                            LocalStudent ls = store.Students[entity.StudentID];
                            if (ls != null && ls.Work != null && (ls.Work.WorkID == entity.Work.WorkID))
                            {
                                ls.Work.WorkName = entity.Work.WorkName;
                                ls.Work.Type = entity.Work.Type;
                                ls.Work.Time = entity.Work.Time;
                                ls.Work.Review = entity.Work.Review;
                                ls.Work.Status = entity.Work.Status;
                                ls.Work.Description = entity.Work.Description;

                                if (!Serializer(ref store))
                                {
                                    entity.Restart();
                                    //重新加入队列。
                                    UpdateWorkInfoToQueueStore(entity);
                                    continue;
                                }

                                //信息提示。
                                entity.RaiseChanged(string.Format("[{0}]作品[{1}]保存成功！", ls.StudentName, ls.Work.WorkName));

                                #region 更新状态。
                                StudentEx stu = Program.STUDENTS[ls.StudentID];
                                if (stu != null)
                                {
                                    if (((stu.Status & StudentControl.EnumStudentState.Review) != StudentControl.EnumStudentState.Review) &&
                                        (entity.Work.Review != null && (entity.Work.Status & EnumWorkStatus.Review) != EnumWorkStatus.Review))
                                    {
                                        stu.Status |= StudentControl.EnumStudentState.Review;
                                    }
                                    else if ((stu.Status & StudentControl.EnumStudentState.Review) == StudentControl.EnumStudentState.Review)
                                    {
                                        stu.Status &= ~StudentControl.EnumStudentState.Review;
                                    }
                                    entity.OnUpdateComplete(stu);
                                    entity.RaiseChanged(string.Format("[{0},{1}]状态[{2}]", ls.StudentName, ls.StudentCode, stu.Status));
                                }
                                #endregion
                            }
                        }

                    }
                    #endregion
                }
                catch (Exception e)
                {
                    UtilTools.OnExceptionRecord(e, typeof(WorkStoreHelper));
                }
                finally
                {
                    //避免资源被耗尽，线程休眠时间
                    Thread.Sleep(THREAD_SLEEP_TIME);
                }
            }
        }), null, DUE_TIME, PERIOD_TIME * new Random().Next(1, 10));
        #endregion

        #region 删除作业到存储。
        /// <summary>
        /// 作业删除队列。
        /// </summary>
        private static Queue QUEUE_WORK_STORE_DELETE = Queue.Synchronized(new Queue());
        /// <summary>
        /// 删除作业存储队列。
        /// </summary>
        /// <param name="entity"></param>
        public static void DeleteWorkToQueueStore(DeleteWorkQueueEntity entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.WorkID)) return;
            QUEUE_WORK_STORE_DELETE.Enqueue(entity);
        }
        /// <summary>
        /// 作业删除队列处理定时器。
        /// </summary>
        private static readonly Timer timer_delete_work_store_queue = new Timer(new TimerCallback(delegate(object sender)
        {
            //循环队列。
            while (QUEUE_WORK_STORE_DELETE != null && QUEUE_WORK_STORE_DELETE.Count > 0)
            {
                try
                {
                    #region 循环处理。
                    DeleteWorkQueueEntity entity = QUEUE_WORK_STORE_DELETE.Dequeue() as DeleteWorkQueueEntity;
                    if (entity != null && entity.Count < AUTO_DISCARD_MINICOUNT && File.Exists(entity.StoreFilePath))
                    {
                        LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(entity.StoreFilePath);
                        if (store != null && store.Students != null && store.Students.Count > 0)
                        {
                            LocalStudent ls = store.Students[entity.StudentID];
                            if (ls != null && ls.Work != null && ls.Work.WorkID == entity.WorkID)
                            {
                                string workName = ls.Work.WorkName;
                                if (ls.Work.DeleteFiles(store, ls))
                                {
                                    ls.Work = null;

                                    if (!Serializer(ref store))
                                    {
                                        entity.Restart();
                                        //重新加入队列。
                                        DeleteWorkToQueueStore(entity);
                                        continue;
                                    }

                                    entity.RaiseChanged(string.Format("删除作业[{0},{1}]成功！", ls.StudentName, workName));
                                    #region 更新状态。
                                    StudentEx stu = Program.STUDENTS[ls.StudentID];
                                    if (stu != null)
                                    {
                                        if ((stu.Status & StudentControl.EnumStudentState.Upload) == StudentControl.EnumStudentState.Upload)
                                        {
                                            stu.Status &= ~StudentControl.EnumStudentState.Upload;
                                        }
                                        if ((stu.Status & StudentControl.EnumStudentState.Review) == StudentControl.EnumStudentState.Review)
                                        {
                                            stu.Status &= ~StudentControl.EnumStudentState.Review;
                                        }
                                        entity.OnUpdateControls(stu);
                                        entity.RaiseChanged(string.Format("[{0},{1}]状态[{2}]", ls.StudentName, ls.StudentCode, stu.Status));
                                    }
                                    #endregion
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(1000);
                                    //重新加入队列。
                                    entity.Restart();
                                    DeleteWorkToQueueStore(entity);
                                }
                            }
                        }

                    }
                    #endregion
                }
                catch (Exception e)
                {
                    UtilTools.OnExceptionRecord(e, typeof(WorkStoreHelper));
                }
                finally
                {
                    //避免资源被耗尽，线程休眠时间
                    Thread.Sleep(THREAD_SLEEP_TIME);
                }
            }
        }), null, DUE_TIME, PERIOD_TIME * new Random().Next(1, 10));
        #endregion

        #region 删除学生到存储。
        /// <summary>
        /// 删除学生队列。
        /// </summary>
        private static Queue QUEUE_STUDENT_STORE_DELETE = Queue.Synchronized(new Queue());
        /// <summary>
        /// 删除学生存储队列。
        /// </summary>
        /// <param name="entity"></param>
        public static void DeleteStudentToQueueStore(DeleteStudentQueueEntity entity)
        {
            if (entity == null) return;
            QUEUE_STUDENT_STORE_DELETE.Enqueue(entity);
        }
        /// <summary>
        /// 删除学生处理定时器。
        /// </summary>
        private static readonly Timer timer_delete_student_work_store_queue = new Timer(new TimerCallback(delegate(object sender)
        {
            //循环队列。
            while (QUEUE_STUDENT_STORE_DELETE != null && QUEUE_STUDENT_STORE_DELETE.Count > 0)
            {
                try
                {
                    #region 循环处理。
                    DeleteStudentQueueEntity entity = QUEUE_STUDENT_STORE_DELETE.Dequeue() as DeleteStudentQueueEntity;
                    if (entity != null && entity.Count < AUTO_DISCARD_MINICOUNT && File.Exists(entity.StoreFilePath))
                    {
                        LocalStudentWorkStore store = LocalStudentWorkStore.DeSerializer(entity.StoreFilePath);
                        if (store != null && store.Students != null && store.Students.Count > 0)
                        {
                            LocalStudent ls = store.Students[entity.StudentID];
                            string studentName = (ls != null) ? ls.StudentName : "";
                            if (ls != null && store.Students.Remove(ls))
                            {
                                if (!Serializer(ref store))
                                {
                                    entity.Restart();
                                    //重新加入队列。
                                    DeleteStudentToQueueStore(entity);
                                    continue;
                                }
                                entity.RaiseChanged("删除学生[" + studentName + "]成功！");
                            }
                        }
                    }
                    #endregion
                }
                catch (Exception e)
                {
                    UtilTools.OnExceptionRecord(e, typeof(WorkStoreHelper));
                }
                finally
                {
                    //避免资源被耗尽，线程休眠时间
                    Thread.Sleep(THREAD_SLEEP_TIME);
                }
            }
        }), null, DUE_TIME, PERIOD_TIME * new Random().Next(1, 10));
        #endregion

        #region 作业文件序列化。
        /// <summary>
        /// 作业文件是否在读写状态（用户读写冲突检测）。
        /// </summary>
        private static Hashtable WORKSTORE_ISWRITE_CACHE = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 序列化作业存储。
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static bool Serializer(ref LocalStudentWorkStore store)
        {
            lock (store)
            {
                string key = store.StoreKeyID(), path = store.FileSavePath();
                try
                {
                    //如果写入被占用。
                    if (WORKSTORE_ISWRITE_CACHE.ContainsKey(key))
                    {
                        return false;
                    }
                    //写入占用标示。
                    WORKSTORE_ISWRITE_CACHE[store.StoreKeyID()] = true;
                    //序列化写入文件。
                    UtilTools.Serializer<LocalStudentWorkStore>(store, path);
                }
                finally
                {
                    //移除写入标示。
                    WORKSTORE_ISWRITE_CACHE.Remove(key);
                }
                return true;
            }
        }
        #endregion

        #region 内置类。
        /// <summary>
        /// 队列实体基础类。
        /// </summary>
        public abstract class BaseQueueEntity
        {
            /// <summary>
            /// 构造函数。
            /// </summary>
            public BaseQueueEntity()
            {
                this.Count = 0;
                this.Ticks = DateTime.Now.Ticks;
            }
            /// <summary>
            /// 获取作业接收时间值。
            /// </summary>
            public long Ticks { get; private set; }
            /// <summary>
            /// 获取排队次数(从0开始)。
            /// </summary>
            public int Count { get; private set; }
            /// <summary>
            /// 重新排队。
            /// </summary>
            public void Restart()
            {
                this.Count++;
            }
            /// <summary>
            /// 通知外部消息。
            /// </summary>
            public event RaiseChangedHandler Changed;
            /// <summary>
            /// 触发通知外部消息。
            /// </summary>
            /// <param name="content"></param>
            public void RaiseChanged(string content)
            {
                RaiseChangedHandler handler = this.Changed;
                if (handler != null)
                    handler(content);
            }
        }
        /// <summary>
        /// 作业添加队列实体。
        /// </summary>
        public class WorkAddQueueEntity : BaseQueueEntity
        {
            /// <summary>
            /// 构造函数。
            /// </summary>
            /// <param name="teacherId"></param>
            /// <param name="classId"></param>
            /// <param name="data"></param>
            public WorkAddQueueEntity(string teacherId, string classId, UploadFileMSG data)
                : base()
            {
                this.TeacherID = teacherId;
                this.ClassID = classId;
                this.Data = data;
            }
            /// <summary>
            /// 获取教师ID。
            /// </summary>
            public string TeacherID { get; private set; }
            /// <summary>
            /// 获取班级ID。
            /// </summary>
            public string ClassID { get; private set; }
            /// <summary>
            /// 获取作业数据。
            /// </summary>
            public UploadFileMSG Data { get; private set; }
           
            #region 事件处理。
            /// <summary>
            /// 更新学生状态事件。
            /// </summary>
            public event UpdateStudentControlsHandler UpdateControls;
            /// <summary>
            /// 触发更新学生状态事件。
            /// </summary>
            /// <param name="students"></param>
            public void OnUpdateControls(StudentEx student)
            {
                UpdateStudentControlsHandler handler = this.UpdateControls;
                if (handler != null && student != null)
                    handler(student);
            }
            #endregion
        }
        /// <summary>
        /// 队列实体抽象类。
        /// </summary>
        public abstract class QueueEntity : BaseQueueEntity
        {
            /// <summary>
            /// 构造函数。
            /// </summary>
            public QueueEntity()
                : base()
            {
            }
            /// <summary>
            /// 获取学生ID。
            /// </summary>
            public string StudentID { get; protected set; }
            /// <summary>
            /// 获取作业文件路径。
            /// </summary>
            public string StoreFilePath { get; protected set; }
        }
        /// <summary>
        /// 作业批阅队列实体。
        /// </summary>
        public class WorkReviewQueueEntity : QueueEntity
        {
            /// <summary>
            /// 构造函数。
            /// </summary>
            /// <param name="sid">学生ID。</param>
            /// <param name="wid">作业ID。</param>
            /// <param name="status">作业状态。</param>
            /// <param name="review">作业批阅。</param>
            /// <param name="path">作业存储路径。</param>
            public WorkReviewQueueEntity(string sid, string wid, EnumWorkStatus status, LocalWorkReview review, string path)
                : base()
            {
                this.StudentID = sid;
                this.WorkID = wid;
                this.Status = status;
                this.Review = review;
                this.StoreFilePath = path;
            }
            /// <summary>
            /// 获取学生ID。
            /// </summary>
            public string WorkID { get; private set; }
            /// <summary>
            /// 获取作业状态。
            /// </summary>
            public EnumWorkStatus Status { get; private set; }
            /// <summary>
            /// 获取作业评价。
            /// </summary>
            public LocalWorkReview Review { get; private set; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <param name="isUploadToServer"></param>
        public delegate void UpdateWorkInfoCompleteHandler(StudentEx student, bool isUploadToServer);
        /// <summary>
        /// 更新学生信息队列实体。
        /// </summary>
        public class UpdateWorkInfoQueueEntity : QueueEntity
        {
            /// <summary>
            /// 构造函数。
            /// </summary>
            /// <param name="sid"></param>
            /// <param name="work"></param>
            /// <param name="path"></param>
            public UpdateWorkInfoQueueEntity(string sid, IStudentWork work, string path, bool isUploadToServer)
                : base()
            {
                this.IsUploadToServer = isUploadToServer;
                this.StudentID = sid;
                this.Work = work;
                this.StoreFilePath = path;
            }
            /// <summary>
            /// 获取或设置作业。
            /// </summary>
            public IStudentWork Work { get; private set; }
            /// <summary>
            /// 获取是否上传到服务器。
            /// </summary>
            protected bool IsUploadToServer { get; private set; }

            #region 事件处理。
            /// <summary>
            /// 更新学生信息完成事件。
            /// </summary>
            public event UpdateWorkInfoCompleteHandler UpdateComplete;
            /// <summary>
            /// 触发更新学生状态事件。
            /// </summary>
            /// <param name="student"></param>
            public void OnUpdateComplete(StudentEx student)
            {
                UpdateWorkInfoCompleteHandler handler = this.UpdateComplete;
                if (handler != null && student != null)
                    handler(student, this.IsUploadToServer);
            }
            #endregion
        }
        /// <summary>
        /// 删除作业队列实体。
        /// </summary>
        public class DeleteWorkQueueEntity : QueueEntity
        {
            /// <summary>
            /// 构造函数。
            /// </summary>
            /// <param name="sid"></param>
            /// <param name="wid"></param>
            /// <param name="path"></param>
            public DeleteWorkQueueEntity(string sid, string wid, string path)
                : base()
            {
                this.StudentID = sid;
                this.WorkID = wid;
                this.StoreFilePath = path;
            }
            /// <summary>
            /// 获取作业ID。
            /// </summary>
            public string WorkID { get; private set; }

            #region 事件处理。
            /// <summary>
            /// 更新学生状态事件。
            /// </summary>
            public event UpdateStudentControlsHandler UpdateControls;
            /// <summary>
            /// 触发更新学生状态事件。
            /// </summary>
            /// <param name="students"></param>
            public void OnUpdateControls(StudentEx student)
            {
                UpdateStudentControlsHandler handler = this.UpdateControls;
                if (handler != null && student != null)
                    handler(student);
            }
            #endregion
        }
        /// <summary>
        /// 删除学生队列实体。
        /// </summary>
        public class DeleteStudentQueueEntity : QueueEntity
        {
            /// <summary>
            /// 构造函数。
            /// </summary>
            /// <param name="sid"></param>
            /// <param name="path"></param>
            public DeleteStudentQueueEntity(string sid, string path)
                : base()
            {
                this.StudentID = sid;
                this.StoreFilePath = path;
            }
        }
        #endregion
    }
}