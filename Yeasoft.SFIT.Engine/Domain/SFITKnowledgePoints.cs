//================================================================================
// FileName: SFITKnowledgePoints.cs
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
    ///֪ʶҪ��ӳ���ࡣ
	///</summary>
    [DbTable("tblSFITKnowledgePoints")]
    public class SFITKnowledgePoints
    {
        #region ��Ա���������캯����
        ///<summary>
        ///���캯����
        ///</summary>
        public SFITKnowledgePoints()
        {

        }
        #endregion

        #region ���ԡ�
        ///<summary>
        ///��ȡ�����ø�֪ʶҪ��ID��
        ///</summary>
        [DbField("ParentPointID")]
        public GUIDEx ParentPointID
        {
            get;
            set;
        }
        /// <summary>
        /// ��ȡ�������꼶ID��
        /// </summary>
        [DbField("GradeID")]
        public GUIDEx GradeID
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������֪ʶҪ��ID��
        ///</summary>
        [DbField("PointID", DbFieldUsage.PrimaryKey)]
        public GUIDEx PointID
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������֪ʶҪ����롣
        ///</summary>
        [DbField("PointCode")]
        public string PointCode
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������֪ʶҪ�����ơ�
        ///</summary>
        [DbField("PointName")]
        public string PointName
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ������������
        ///</summary>
        [DbField("Description")]
        public string Description
        {
            get;
            set;
        }
        ///<summary>
        ///��ȡ����������
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
