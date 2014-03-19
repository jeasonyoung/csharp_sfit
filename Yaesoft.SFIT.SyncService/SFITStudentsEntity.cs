//================================================================================
// FileName: SFITStudentsEntity.cs
// Desc:
// Called by
// Auth: 本代码由代码生成器自动生成。
// Date:
//================================================================================
// Change History
//================================================================================
// Date  Author  Description
// ----  ------  -----------
//
//================================================================================
// Copyright (C) 2009-2010 Jeason Young Corporation
//================================================================================
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;

using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.SFIT.SyncService
{
    ///<summary>
    ///学生信息映射类。
    ///</summary>
    [DbTable("tblSFITStudents")]
    internal class SFITStudents
    {
        #region 属性。
        ///<summary>
        ///获取或设置学生ID。
        ///</summary>
        [DbField("StudentID", DbFieldUsage.PrimaryKey)]
        public GUIDEx StudentID
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置学生学号。
        ///</summary>
        [DbField("StudentCode", DbFieldUsage.UniqueKey)]
        public string StudentCode
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置姓名。
        ///</summary>
        [DbField("StudentName")]
        public string StudentName
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置性别。
        /// </summary>
        [DbField("Gender")]
        public int Gender
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置入学年份。
        /// </summary>
        [DbField("JoinYear")]
        public int JoinYear
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置身份证号。
        /// </summary>
        [DbField("IDNumber")]
        public string IDNumber
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置SyncStatus。
        ///</summary>
        [DbField("SyncStatus")]
        public int SyncStatus
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置LastSyncTime。
        ///</summary>
        [DbField("LastSyncTime", DbFieldUsage.EmptyOrNullNotUpdate)]
        public DateTime LastSyncTime
        {
            get;
            set;
        }
        #endregion
    }
	///<summary>
	///SFITStudentsEntity实体类。
	///</summary>
	internal class SFITStudentsEntity: DbModuleEntity<SFITStudents>
	{
		#region 成员变量，构造函数。
		///<summary>
		///构造函数
		///</summary>
		public SFITStudentsEntity()
		{

		}
		#endregion

        #region 数据操作。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="syncStudentIDs"></param>
        /// <param name="log"></param>
        /// <param name="count"></param>
        public void StopSync(GUIDEx classID, List<GUIDEx> syncStudentIDs, ref StringBuilder log, ref int count)
        {
            if (classID.IsValid)
            {
                List<GUIDEx> hiddens = new List<GUIDEx>();

                #region 获取须隐藏的学生ID。
                List<GUIDEx> allStudentIDs = new SFITClassStudentsEntity().GetStudents(classID);
                if (allStudentIDs != null && allStudentIDs.Count > 0)
                {
                    if (syncStudentIDs == null || syncStudentIDs.Count == 0)
                    {
                        hiddens = allStudentIDs;
                    }
                    else
                    {
                        for (int i = 0; i < allStudentIDs.Count; i++)
                        {
                            bool result = syncStudentIDs.Exists(new Predicate<GUIDEx>(delegate(GUIDEx sender)
                            {
                                return (sender.IsValid) && (sender == allStudentIDs[i]);
                            }));
                            if (!result)
                            {
                                hiddens.Add(allStudentIDs[i]);
                            }
                        }

                    }
                }
                #endregion

                if (hiddens.Count > 0)
                {
                    for (int j = 0; j < hiddens.Count; j++)
                    {
                        SFITStudents data = new SFITStudents();
                        data.StudentID = hiddens[j];
                        if (this.LoadRecord(ref data))
                        {
                            data.SyncStatus = 0x00;
                            if (this.UpdateRecord(data))
                            {
                                log.AppendLine();
                                log.AppendFormat("(学生ID：{0})[学号：{1}][名称：{2}][性别：{3}][入学年份：{4}][身份证号：{5}] 将被隐藏；",
                                            data.StudentID, data.StudentCode, data.StudentName, data.Gender, data.JoinYear, data.IDNumber);
                                count++;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 根据学号获取学生代码。
        /// </summary>
        /// <param name="stuCode"></param>
        /// <returns></returns>
        public GUIDEx GetStudentIDByCode(string stuCode)
        {
            const string sql = "select StudentID from {0} where StudentCode = '{1}'";
            object obj = this.DatabaseAccess.ExecuteScalar(string.Format(sql,this.TableName, stuCode));
            return obj == null ? GUIDEx.Null : new GUIDEx(obj);
        }
        #endregion
    }
}