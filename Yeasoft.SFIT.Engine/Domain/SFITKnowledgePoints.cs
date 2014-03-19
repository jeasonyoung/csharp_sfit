//================================================================================
// FileName: SFITKnowledgePoints.cs
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
using System.Text;
	
using iPower;
using iPower.Data;
using iPower.Data.ORM;
namespace Yaesoft.SFIT.Engine.Domain
{
	///<summary>
    ///知识要点映射类。
	///</summary>
    [DbTable("tblSFITKnowledgePoints")]
    public class SFITKnowledgePoints
    {
        #region 成员变量，构造函数。
        ///<summary>
        ///构造函数。
        ///</summary>
        public SFITKnowledgePoints()
        {

        }
        #endregion

        #region 属性。
        ///<summary>
        ///获取或设置父知识要点ID。
        ///</summary>
        [DbField("ParentPointID")]
        public GUIDEx ParentPointID
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置年级ID。
        /// </summary>
        [DbField("GradeID")]
        public GUIDEx GradeID
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置知识要点ID。
        ///</summary>
        [DbField("PointID", DbFieldUsage.PrimaryKey)]
        public GUIDEx PointID
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置知识要点代码。
        ///</summary>
        [DbField("PointCode")]
        public string PointCode
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置知识要点名称。
        ///</summary>
        [DbField("PointName")]
        public string PointName
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置描述。
        ///</summary>
        [DbField("Description")]
        public string Description
        {
            get;
            set;
        }
        ///<summary>
        ///获取或设置排序。
        ///</summary>
        [DbField("OrderNO")]
        public int OrderNO
        {
            get;
            set;
        }
        #endregion
    }
}
