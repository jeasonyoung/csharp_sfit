//================================================================================
//  FileName: StudentEx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/1
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
using Yaesoft.SFIT;
using Yaesoft.SFIT.Client.TeaHost.Controls;
namespace Yaesoft.SFIT.Client.TeaHost.Data
{
    /// <summary>
    /// 学生数据扩展。
    /// </summary>
    public class StudentEx : Student
    {
        #region 成员变量，构造函数。
        /// <summary>
        ///构造函数。
        /// </summary>
        public StudentEx(Student student)
        {
            if (student != null)
            {
                this.StudentID = student.StudentID;
                this.StudentCode = student.StudentCode;
                this.StudentName = student.StudentName;
            }
            this.Status = StudentControl.EnumStudentState.Offline;
        }
        #endregion

        /// <summary>
        /// 获取或设置学生电脑名称。
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// 获取或设置学生IP地址。
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 获取或设置状态。
        /// </summary>
        public StudentControl.EnumStudentState Status { get; set; }
        /// <summary>
        /// 转换为可序列化学生信息。
        /// </summary>
        /// <returns></returns>
        public Student ToStudent()
        {
            return this;
        }
    }

    /// <summary>
    /// 学生数据扩展集合。
    /// </summary>
    public class StudentsEx : BaseCollection<StudentEx>
    {
        #region 成员变量，构造函数。
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="students"></param>
        public StudentsEx(Students students)
        {
            this.Items.Clear();
            if (students != null && students.Count > 0)
            {
                foreach (Student stu in students)
                {
                    this.Items.Add(new StudentEx(stu));
                }
            }
        }
        #endregion

        #region 重载。
        public override StudentEx this[string studentID]
        {
            get
            {
                StudentEx stu = this.Items.Find(new Predicate<StudentEx>(delegate(StudentEx sender)
                {
                    return (sender != null) && (sender.StudentID == studentID);
                }));
                return stu;
            }
        }

        public override int Compare(StudentEx x, StudentEx y)
        {
            int sort = string.Compare(x.MachineName, y.MachineName);
            if (sort == 0)
                sort = string.Compare(x.StudentCode, y.StudentCode);
            return sort;
        }
        #endregion

        /// <summary>
        /// 更新成员变量。
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public void Update(StudentEx item)
        {
            if (item != null)
            {
                int index = this.Items.FindIndex(new Predicate<StudentEx>(delegate(StudentEx sender)
                {
                    return (sender != null) && (sender.StudentID == item.StudentID);
                }));
                if (index > -1)
                {
                    this.Items[index] = item;
                }
                else
                {
                    this.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// 设置成员离线状态。
        /// </summary>
        public void SetOfflineStatus()
        {
            if (this.Items != null && this.Items.Count > 0)
            {
                List<StudentEx> list = this.Items.FindAll(new Predicate<StudentEx>(delegate(StudentEx sender)
                {
                    return (sender != null) && ((sender.Status & StudentControl.EnumStudentState.Online) == StudentControl.EnumStudentState.Online);
                }));
                if (list != null && list.Count > 0)
                {
                    foreach (StudentEx stu in list)
                    {
                        if ((stu.Status & StudentControl.EnumStudentState.Online) == StudentControl.EnumStudentState.Online)
                        {
                            stu.Status &= ~StudentControl.EnumStudentState.Online;
                        }
                        stu.Status |= StudentControl.EnumStudentState.Offline;
                    }
                }
            }
        }
        /// <summary>
        /// 转换为可序列化学生信息。
        /// </summary>
        /// <returns></returns>
        public Students ToStudents()
        {
            if (this.Items != null && this.Items.Count > 0)
            {
                Students collection = new Students();
                foreach (StudentEx stu in this.Items)
                {
                    Student s = stu.ToStudent();
                    if (s != null)
                        collection.Add(s);
                }
                return collection;
            }
            return null;
        }
    }
}
