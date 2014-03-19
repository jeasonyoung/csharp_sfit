//================================================================================
// FileName: SFITStudentAttachmentEntity.cs
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
using iPower.Utility;
using iPower.Cryptography;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITStudentAttachmentEntityʵ���ࡣ
	///</summary>
	internal class SFITStudentAttachmentEntity: DbModuleEntity<SFITStudentAttachment>
	{
		#region ��Ա���������캯����
        SFITAccessoriesEntity accessoriesEntity = null;
		///<summary>
		///���캯��
		///</summary>
		public SFITStudentAttachmentEntity()
		{
            this.accessoriesEntity = new SFITAccessoriesEntity();
		}
		#endregion

        #region ���ݴ���
        /// <summary>
        /// ��ȡ��Ʒ�µ����ݸ�����
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        public List<SFITAccessories> LoadAccessories(GUIDEx workID)
        {
            List<SFITAccessories> list = new List<SFITAccessories>();
            if (workID.IsValid)
            {
                DataTable dtSource = this.GetAllRecord(string.Format("WorkID = '{0}'", workID), "CreateDateTime desc");
                if (dtSource != null && dtSource.Rows.Count > 0)
                {
                    foreach (DataRow row in dtSource.Rows)
                    {
                        SFITAccessories temp = new SFITAccessories();
                        temp.AccessoriesID = new GUIDEx(row["AccessoriesID"]);
                        if (this.accessoriesEntity.LoadRecord(ref temp))
                        {
                            list.Add(temp);
                        }
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// �ϴ���������
        /// </summary>
        /// <param name="workID">��ҵID��</param>
        /// <param name="checkCode">��ҵУ���롣</param>
        /// <param name="file">��ҵ������</param>
        /// <param name="createEmployeeID"></param>
        /// <param name="createEmployeeName"></param>
        /// <returns></returns>
        public bool UploadStudentAttachment(GUIDEx workID, string checkCode, StudentWorkFile file, GUIDEx createEmployeeID, string createEmployeeName)
        {
            bool result = false;
            if (workID.IsValid && file != null && file.Data != null && file.Data.Length > 0)
            {
                SFITAccessories entity = new SFITAccessories();
                entity.AccessoriesID = file.FileID;

                if (file.OffSet == 0)
                {
                    entity.AccessoriesName = file.FileName;
                    entity.AccessoriesSize = (float)file.Size;
                    entity.ContentType = file.ContentType;
                    entity.CheckCode = checkCode;
                    entity.Suffix = file.FileExt;
                    entity.LastModify = DateTime.Now;

                    if (entity.AccessoriesName.IndexOf('.') == -1)
                        entity.AccessoriesName += ".zip";
                }
                else if (!this.accessoriesEntity.LoadRecord(ref entity))
                {
                    return result;
                }

                //�ϴ�������
                if (result = this.accessoriesEntity.UpdateRecord(entity, file.OffSet, file.Data))
                {
                    if (file.OffSet == 0)
                    {
                        SFITStudentAttachment attachment = new SFITStudentAttachment();
                        attachment.WorkID = workID;
                        attachment.AccessoriesID = entity.AccessoriesID;

                        attachment.CreateEmployeeID = createEmployeeID;
                        attachment.CreateEmployeeName = createEmployeeName;
                        attachment.CreateDateTime = entity.LastModify;

                        result = this.UpdateRecord(attachment);
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// �����б�����Դ��
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        public DataTable ListDataSource(GUIDEx workID)
        {
            const string sql = "exec spSFITStudentAttachmentListView '{0}' ";
            string strSql = string.Format(sql, workID);
            return this.DatabaseAccess.ExecuteDataset(strSql).Tables[0].Copy();
        }
        /// <summary>
        /// ɾ������.
        /// </summary>
        /// <param name="workIDs"></param>
        /// <returns></returns>
        public bool DeleteRecordByWorkID(StringCollection workIDs)
        {
            if (workIDs != null && workIDs.Count > 0)
            {
                foreach (string workId in workIDs)
                {
                    List<SFITAccessories> list = this.LoadAccessories(workId);
                    if (list != null && list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (this.accessoriesEntity.DeleteAccessories(list[i].AccessoriesID))
                            {
                                this.DeleteRecord(string.Format("WorkID='{0}' and AccessoriesID='{1}'", workId, list[i].AccessoriesID));
                            }
                        }
                    }
                }
            }
            return true;
        }
        #endregion
    }
}