//================================================================================
// FileName: SFITCenterAccessEntity.cs
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
using System.Collections.Specialized;
using System.Text;
using System.Data;
	
using iPower;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;

using Yaesoft.SFIT;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITCenterAccessEntityʵ���ࡣ
	///</summary>
	internal class SFITCenterAccessEntity: DbModuleEntity<SFITCenterAccess>
	{
		#region ��Ա���������캯����
		///<summary>
		///���캯��
		///</summary>
		public SFITCenterAccessEntity()
		{

		}
		#endregion

        #region ���ݲ�����
        /// <summary>
        /// �б�����Դ��
        /// </summary>
        /// <param name="schoolName"></param>
        /// <returns></returns>
        public DataTable ListDataSource(string schoolName)
        {
            return this.GetAllRecord(string.Format("SchoolName like '%{0}%'", schoolName));
        }
        /// <summary>
        /// �������ݡ�
        /// </summary>
        /// <param name="schoolID">ѧУID��</param>
        /// <returns></returns>
        public SFITCenterAccess LoadRecord(GUIDEx schoolID)
        {
            DataTable dtSource = this.GetAllRecord(string.Format("SchoolID='{0}'", schoolID));
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                return this.Assignment(dtSource.Rows[0]);
            }
            return null;
        }
        /// <summary>
        /// ���ݽ�ʦID��ȡ������ԿID���ϡ�
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public string[] GetAccessID(GUIDEx employeeID)
        {
            const string sql = "exec spSFITCenterAccess '{0}'";
            DataTable dtSource = this.DatabaseAccess.ExecuteDataset(string.Format(sql, employeeID)).Tables[0];
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                List<string> list = new List<string>();
                foreach (DataRow row in dtSource.Rows)
                {
                    list.Add(Convert.ToString(row[0]));
                }
                string[] result = new string[list.Count];
                list.CopyTo(result);
                return result;
            }
            return null;
        }
        /// <summary>
        /// ����������Կ���ϡ�
        /// </summary>
        /// <param name="accessID"></param>
        /// <returns></returns>
        public CredentialsCollection CreateCredentialsCollection(string[] accessID, string serviceURL)
        {
            if (accessID != null && accessID.Length > 0)
            {
                DataTable dtSource = this.GetAllRecord(string.Format("AccessID in ('{0}')", string.Join("','", accessID)));
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    CredentialsCollection collection = new CredentialsCollection();
                    SFITSchools school = new SFITSchools();
                    foreach (DataRow row in dtSource.Rows)
                    {
                        SFITCenterAccess data = this.Assignment(row);
                        if (data != null)
                        {
                            school.SchoolID = data.SchoolID;
                            if (new SFITSchoolsEntity().LoadRecord(ref school))
                            {
                                Credentials c = new Credentials();
                                c.ServiceURL = serviceURL;
                                c.SchoolCode = school.SchoolCode;
                                c.SchoolID = data.SchoolID;
                                c.SchoolName = data.SchoolName;
                                c.AccessAccount = data.AccessAccount;
                                c.AccessPassword = data.AccessPassword;
                                c.Description = data.Description;
                                collection.Add(c);
                            }
                        }
                    }
                    return collection;
                }
            }
            return null;
        }
        #endregion
    }

}
