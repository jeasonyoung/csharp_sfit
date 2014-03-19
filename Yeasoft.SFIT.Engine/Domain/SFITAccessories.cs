//================================================================================
// FileName: SFITAccessories.cs
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
	///tblSFITAccessoriesӳ���ࡣ
	///</summary>
	[DbTable("tblSFITAccessories")]
	public class SFITAccessories
    {
        #region ��Ա���������캯����
        /// <summary>
        /// ���캯����
        /// </summary>
        public SFITAccessories()
        {
            this.LastModify = DateTime.Now;
        }
        #endregion

        #region ���ԡ�
        ///<summary>
		///��ȡ������AccessoriesID��
		///</summary>
        [DbField("AccessoriesID", DbFieldUsage.PrimaryKey)]
        public GUIDEx AccessoriesID { get; set; }
		///<summary>
		///��ȡ������AccessoriesName��
		///</summary>
        [DbField("AccessoriesName")]
        public string AccessoriesName { get; set; }
		///<summary>
		///��ȡ������ContentType��
		///</summary>
        [DbField("ContentType")]
        public string ContentType { get; set; }
		///<summary>
		///��ȡ������AccessoriesSize��
		///</summary>
        [DbField("AccessoriesSize")]
        public float AccessoriesSize { get; set; }
		///<summary>
		///��ȡ������Suffix��
		///</summary>
        [DbField("Suffix")]
        public string Suffix { get; set; }
		///<summary>
		///��ȡ������CheckCode��
		///</summary>
        [DbField("CheckCode")]
        public string CheckCode { get; set; }
		///<summary>
		///��ȡ������LastModify��
		///</summary>
        [DbField("LastModify")]
        public DateTime LastModify { get; set; }
		#endregion
	}
}