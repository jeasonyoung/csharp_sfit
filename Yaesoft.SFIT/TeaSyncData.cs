//================================================================================
//  FileName: TeaSyncData.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2011/11/25
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
using System.IO;
using System.Xml.Serialization;
namespace Yaesoft.SFIT
{
    /// <summary>
    /// 教师同步数据本地保存。
    /// </summary>
    [Serializable]
    public class TeaSyncData
    {
        #region 成员变量，构造函数。
        School school;
        DateTime time;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public TeaSyncData()
        {
            this.time = DateTime.Now;
            this.school = new School();
        }
        #endregion

        #region 属性。
        /// <summary>
        /// 获取或设置生成时间。
        /// </summary>
        public DateTime Time
        {
            get { return this.time; }
            set { this.time = value; }
        }
        /// <summary>
        /// 获取或设置学校信息。
        /// </summary>
        public School School
        {
            get { return this.school; }
            set { this.school = value; }
        }
        #endregion.

        #region 函数。
        /// <summary>
        /// 查找目录信息。
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public Catalog FindCatalog(string catalogID)
        {
            if (string.IsNullOrEmpty(catalogID))
                return null;

            Grades gs = this.School.Teacher.Grades;
            if (gs != null)
            {
                Catalog c = null;
                foreach (Grade g in gs)
                {
                    c = g.Catalogs[catalogID];
                    if (c != null)
                        return c;
                }
            }
            return null;
        }
        #endregion

        #region 静态序列化与序列化函数。
        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="sync"></param>
        /// <param name="saveFile"></param>
        public static void Serialize(TeaSyncData sync, string saveFile)
        {
            lock (typeof(TeaSyncData))
            {
                if (sync == null)
                    throw new ArgumentNullException("sync");
                if (string.IsNullOrEmpty(saveFile))
                    throw new ArgumentNullException("saveFile");

                using (FileStream stream = new FileStream(saveFile, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TeaSyncData));
                    serializer.Serialize(stream, sync);
                }
            }
        }
        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <param name="loadFile"></param>
        /// <returns></returns>
        public static TeaSyncData DeSerialize(string loadFile)
        {
            lock (typeof(TeaSyncData))
            {
                TeaSyncData sync = null;
                if (File.Exists(loadFile))
                {
                    using (FileStream stream = new FileStream(loadFile, FileMode.Open, FileAccess.Read))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(TeaSyncData));
                        sync = serializer.Deserialize(stream) as TeaSyncData;
                    }
                }
                return sync;
            }
        }
        #endregion
    }
}
