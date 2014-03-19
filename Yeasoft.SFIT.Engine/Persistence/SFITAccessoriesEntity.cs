//================================================================================
// FileName: SFITAccessoriesEntity.cs
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
using iPower.FileStorage;
using iPower.Platform.Engine;
using iPower.Platform.Engine.DataSource;
using iPower.Platform.Engine.Persistence;
using Yaesoft.SFIT.Engine.Domain;
namespace Yaesoft.SFIT.Engine.Persistence
{
	///<summary>
	///SFITAccessoriesEntityʵ���ࡣ
	///</summary>
	internal class SFITAccessoriesEntity: DbModuleEntity<SFITAccessories>
	{
        #region ���ݲ�����
        /// <summary>
        /// ���ظ������ݡ�
        /// </summary>
        /// <param name="accessoriesID">����ID��</param>
        /// <param name="entity">������Ϣ��</param>
        /// <returns>�������ݡ�</returns>
        public byte[] LoadAccessories(GUIDEx accessoriesID, out SFITAccessories entity)
        {
            IFileStorageFactory factory = null; entity = null;
            if (accessoriesID.IsValid && (factory = this.ModuleConfig.FileStorageFactory) != null)
            {
                entity = new SFITAccessories();
                entity.AccessoriesID = accessoriesID;
                if (this.LoadRecord(ref entity))
                {
                    string fileName = this.createAccessoriesName(entity);
                    return factory.Download(fileName);
                }
            }
            return null;
        }
        /// <summary>
        /// ɾ��������
        /// </summary>
        /// <param name="accessoriesID"></param>
        /// <returns></returns>
        public bool DeleteAccessories(GUIDEx accessoriesID)
        {
            bool result = false;
            IFileStorageFactory factory = null;
            if (accessoriesID.IsValid && (factory = this.ModuleConfig.FileStorageFactory) != null)
            {
                SFITAccessories entity = new SFITAccessories();
                entity.AccessoriesID = accessoriesID;
                if (this.LoadRecord(ref entity))
                {
                    string fileName = this.createAccessoriesName(entity);
                    if (result = factory.DeleteFile(fileName))
                    {
                        result = this.DeleteRecord(entity);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// �ϴ������ļ����ݡ�
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateRecord(SFITAccessories entity, long offSet, byte[] data)
        {
            bool result = false;
            IFileStorageFactory factory = null;
            if (entity != null && (factory = this.ModuleConfig.FileStorageFactory) != null && data != null && data.Length > 0)
            {
                string fileName = this.createAccessoriesName(entity);
                if ((result = factory.Upload(fileName, offSet, data)) && (offSet == 0))
                {
                    result = base.UpdateRecord(entity);
                }
            }
            return result;
        }
        #endregion

        #region ����������
        /// <summary>
        /// �����������ơ�
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string createAccessoriesName(SFITAccessories entity)
        {
            return string.Format("{0:yyyy-MM}\\{1}_{2}{3}", entity.LastModify, entity.AccessoriesID, entity.CheckCode, System.IO.Path.GetExtension(entity.AccessoriesName));
        }
        #endregion
    }
}