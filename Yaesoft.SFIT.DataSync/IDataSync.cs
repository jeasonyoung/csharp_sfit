//================================================================================
//  FileName: IDataSync.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-12
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

namespace Yaesoft.SFIT.DataSync
{
    /// <summary>
    /// 数据同步接口。
    /// </summary>
    public interface IDataSync
    {
        /// <summary>
        /// 同步全部单位数据。
        /// </summary>
        /// <returns>单位数据集合。</returns>
        SyncUnits SyncAllUnit();
        /// <summary>
        /// 同步学校名称下的教师数据。
        /// </summary>
        /// <param name="unitName">单位名称。</param>
        /// <returns>教师数据集合。</returns>
        SyncTeachers SyncAllTeachers(string unitName);
        /// <summary>
        ///  获取学校名称下的班级数据。
        /// </summary>
        /// <param name="unitName">单位名称。</param>
        /// <returns>班级数据集合。</returns>
        SyncClasses SyncAllClasses(string unitName);
        /// <summary>
        /// 获取学校名称下的学生数据。
        /// </summary>
        /// <param name="unitName">单位学校名称。</param>
        /// <param name="joinYear">入学年份。</param>
        /// <param name="className">班级名称。</param>
        /// <returns>学生数据集合。</returns>
        SyncStudents SyncAllStudents(string unitName, string joinYear, string className);
    }
}