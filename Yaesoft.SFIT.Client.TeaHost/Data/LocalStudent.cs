//================================================================================
//  FileName: LocalStudent.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-10-16
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

namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 本地学生信息。
    /// </summary>
    [Serializable]
    public class LocalStudent : Student
    {
        #region 构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        public LocalStudent()
        {
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="s"></param>
        public LocalStudent(StudentEx s)
        {
            if (s != null)
            {
                this.StudentID = s.StudentID;
                this.StudentCode = s.StudentCode;
                this.StudentName = s.StudentName;
            }
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="s"></param>
        public LocalStudent(Student s)
        {
            if (s != null)
            {
                this.StudentID = s.StudentID;
                this.StudentCode = s.StudentCode;
                this.StudentName = s.StudentName;
            }
        }
        #endregion

        /// <summary>
        /// 获取或设置作品信息。
        /// </summary>
        public LocalStudentWork Work { get; set; }
        /// <summary>
        ///  获取是否有作业数据。
        /// </summary>
        /// <returns></returns>
        public bool HasWork()
        {
            return (this.Work != null && this.Work.WorkFiles != null && this.Work.WorkFiles.Count > 0);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LocalStudents : BaseCollection<LocalStudent>
    {
        /// <summary>
        /// 添加学生。
        /// </summary>
        /// <param name="item"></param>
        public override void Add(LocalStudent item)
        {
            if (item != null && !string.IsNullOrEmpty(item.StudentID))
            {
                if (this[item.StudentID] == null)
                {
                    base.Add(item);
                }
            }
        }
        /// <summary>
        /// 排序。
        /// </summary>
        public void Sort()
        {
            this.Items.Sort(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] ToStudentIDs()
        {
            if (this.Items.Count == 0) return null;
            List<string> list = new List<string>();
            foreach (LocalStudent ls in this.Items)
            {
                if (ls != null) list.Add(ls.StudentID);
            }
            return list.ToArray();
        }
        /// <summary>
        /// 获取学生索引。
        /// </summary>
        /// <param name="studentID">学生ID。</param>
        /// <returns></returns>
        public int FindIndex(string studentID)
        {
            int result = -1;
            if (!string.IsNullOrEmpty(studentID) && this.Items != null && this.Items.Count > 0)
            {
                this.Items.Sort(this);
                result = this.Items.FindIndex(new Predicate<LocalStudent>(delegate(LocalStudent sender)
                {
                    return (sender != null) && (sender.StudentID == studentID);
                }));
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public override LocalStudent this[string studentID]
        {
            get
            {
                LocalStudent ls = this.Items.Find(new Predicate<LocalStudent>(delegate(LocalStudent sender)
                {
                    return (sender != null) && (sender.StudentID.Equals(studentID, StringComparison.InvariantCultureIgnoreCase));
                }));
                return ls;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override LocalStudent this[int index]
        {
            get
            {
                if ((index > -1) && (index < this.Count))
                {
                    return base[index];
                }
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(LocalStudent x, LocalStudent y)
        {
            if (x.HasWork() && y.HasWork())
            {
                return -DateTime.Compare(x.Work.Time, y.Work.Time);
            }
            return string.Compare(x.StudentName, y.StudentName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public LocalStudents FindStudents(string studentName)
        {
            if (!string.IsNullOrEmpty(studentName))
            {
                this.Items.Sort(this);
                List<LocalStudent> list = this.Items.FindAll(new Predicate<LocalStudent>(delegate(LocalStudent sender)
                {
                    return (sender != null) && (sender.StudentName.ToLower().IndexOf(studentName.ToLower()) > -1);
                }));
                if (list != null && list.Count > 0)
                {
                    LocalStudents students = new LocalStudents();
                    list.Sort(this);
                    foreach (LocalStudent ls in list)
                    {
                        students.Add(ls);
                    }
                    return students;
                }
            }
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public LocalStudents FindStudents(string workName, EnumWorkStatus status)
        {
            LocalStudents students = new LocalStudents();
            this.Items.Sort(this);
            foreach (LocalStudent ls in this.Items)
            {
                if (ls.HasWork() && ((ls.Work.Status & status) == status))
                {
                    students.Add(ls);
                }
            }
            return students;
        }
        /// <summary>
        /// 删除学生作品。
        /// </summary>
        /// <param name="studentID"></param>
        public bool RemoveWorks(string studentID)
        {
            lock (this)
            {
                bool result = false;
                if (!string.IsNullOrEmpty(studentID))
                {
                    LocalStudent ls = this[studentID];
                    if (ls != null && ls.HasWork())
                    {
                        ls.Work = null;
                        result = true;
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 移除全部学生作品。
        /// </summary>
        /// <param name="store"></param>
        public void RemoveAllWorks()
        {
            if (this.Count > 0)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    LocalStudent ls = this[i];
                    if (ls != null && ls.HasWork())
                    {
                        ls.Work = null;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        public void Remove(LocalStudent[] students)
        {
            if (students != null && students.Length > 0)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    this.Items.Remove(students[i]);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (index > -1 && index < this.Count)
            {
                this.Items.RemoveAt(index);
            }
        }
    }
}