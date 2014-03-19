//================================================================================
//  FileName: AccessoriesDownloadService.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-10
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

using iPower;
using iPower.FileStorage;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
    /// <summary>
    /// 作业附件下载服务。
    /// </summary>
    public class WorkDownloadService
    {
        #region 成员变量，构造函数。
        SFITAccessoriesEntity entity = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public WorkDownloadService()
        {
            this.entity = new SFITAccessoriesEntity();
        }
        #endregion

        /// <summary>
        /// 下载附件数据。
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="fullFileName"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public byte[] Download(GUIDEx fileID, out string fullFileName, out string contentType)
        {
            lock (this)
            {
                fullFileName = contentType = null;
                if (fileID.IsValid)
                {
                    SFITAccessories entity = null;
                    byte[] data = this.entity.LoadAccessories(fileID, out entity);
                    if (data != null)
                    {
                        fullFileName = entity.AccessoriesName;
                        contentType = entity.ContentType;
                        return data;
                    }
                }
                return null;
            }
        }

    }
}