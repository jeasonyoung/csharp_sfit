//================================================================================
//  FileName: IndexDataService.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012-12-26
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
using System.Data;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Index
{
    /// <summary>
    /// 
    /// </summary>
    public class IndexDataService
    {
        #region 成员变量，构造函数。
        SFITSchoolsEntity schools = null;
        SFITCatalogEntity catalogs = null;
        SFITClassEntity classes = null;
        SFITStudentWorksEntity works = null;
        SFITWorksCommentsEntity comments = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public IndexDataService()
        {
            this.schools = new SFITSchoolsEntity();
            this.catalogs = new SFITCatalogEntity();
            this.classes = new SFITClassEntity();
            this.works = new SFITStudentWorksEntity();
            this.comments = new SFITWorksCommentsEntity();
        }
        #endregion

        #region 公开函数。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="unitId"></param>
        /// <param name="classId"></param>
        /// <param name="catalogId"></param>
        /// <param name="workTime">YYYY-mm</param>
        /// <param name="page"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public CallAjaxResult Run(string type, string unitId,string gradeId, string classId,string catalogId,string workTime, int page, int index, string sort,string order)
        {
            CallAjaxResult result = null;
            if (!string.IsNullOrEmpty(type))
            {
                switch (type.ToLower())
                {
                    case "unit"://按单位。
                        result = this.LoadUnitData(page, index);
                        break;
                    case "class":
                        result = this.LoadClssesData(unitId, page, index);
                        break;
                    case "time"://按时间。
                        result = this.loadTimeData(unitId, classId, page, index);
                        break;
                    case "catalog"://按册次。
                        result = this.loadCatalogData(unitId, gradeId, page, index);
                        break;
                    case "newwork"://最新作品。
                        result = this.LoadNewWorks(unitId, classId, catalogId, workTime, page, index);
                        break;
                    case "hotwork"://最热作品。
                        result = this.LoadHotWorks(unitId, classId, catalogId, workTime, page, index);
                        break;
                    case "bestwork"://最优作品。
                        result = this.LoadBestWorks(unitId, classId, catalogId, workTime, page, index);
                        break;
                    case "allwork"://全部作品。
                        result = this.LoadAllWorks(unitId, classId, catalogId, workTime, page, index);
                        break;
                    case "search"://搜索作品。
                        result = this.LoadSearchWorks(unitId, classId, catalogId, workTime, page, index);
                        break;
                    case "comment"://加载评论数据。
                        result = this.LoadCommentData(unitId, page, index);
                        break;
                    case "post"://提交评论。
                        result = this.PostComment(unitId, gradeId, classId, catalogId);
                        break;
                    case "rpt"://报表数据。
                        result = this.LoadRptData(unitId, classId, gradeId, catalogId, workTime, page, index, sort, order);
                        break;
                }
            }
            return result;
        }
        #endregion

        #region 辅助函数。
        /// <summary>
        /// 加载单位数据。
        /// </summary>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private CallAjaxResult LoadUnitData(int size, int index)
        {
            return new CallAjaxResult(this.schools.LoadIndexUnitData(size, index));
        }
        /// <summary>
        /// 加载册次数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="gid"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private CallAjaxResult loadCatalogData(string uid, string gid, int size, int index)
        {
            return new CallAjaxResult(this.catalogs.LoadIndexCatalogData(uid, gid, size, index));
        }
        /// <summary>
        /// 加载时间数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private CallAjaxResult loadTimeData(string uid, string cid, int size, int index)
        {
            return new CallAjaxResult(this.works.LoadWorksTime(uid, cid, size, index));
        }
        /// <summary>
        /// 加载学校下班级数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private CallAjaxResult LoadClssesData(string uid, int size, int index)
        {
            return new CallAjaxResult(this.classes.LoadIndexUnitClasses(uid, size, index));
        }
        /// <summary>
        /// 加载最新作品数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="st"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private CallAjaxResult LoadNewWorks(string uid,string cid, string sid,string st, int size, int index)
        {
            return new CallAjaxResult(this.works.LoadNewWorks(uid, cid, sid, st, size, index));
        }
        /// <summary>
        /// 加载最热作品数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private CallAjaxResult LoadHotWorks(string uid,string cid,string sid,string st, int size, int index)
        {
            return new CallAjaxResult(this.works.LoadHotWorks(uid, cid, sid, st, size, index));
        }
        /// <summary>
        /// 加载最优作品数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private CallAjaxResult LoadBestWorks(string uid,string cid,string sid,string st, int size, int index)
        {
            return new CallAjaxResult(this.works.LoadBestWorks(uid, cid, sid, st, size, index));
        }
        /// <summary>
        /// 加载全部作品数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private CallAjaxResult LoadAllWorks(string uid, string cid, string sid,string st, int size, int index)
        {
            return new CallAjaxResult(this.works.LoadAllWorks(uid, cid, sid, st, size, index));
        }
        /// <summary>
        /// 加载搜索作品数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="st"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private CallAjaxResult LoadSearchWorks(string uid, string cid, string sid, string st, int size, int index)
        {
            return new CallAjaxResult(this.works.LoadSearchWorks(uid, cid, sid, st, size, index));
        }
        /// <summary>
        /// 加载评论数据。
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        private CallAjaxResult LoadCommentData(string workId, int size, int index)
        {
            return new CallAjaxResult(this.comments.LoadCommentsData(workId, size, index));
        }
        /// <summary>
        /// 提交评论。
        /// </summary>
        /// <param name="workId"></param>
        /// <param name="ip"></param>
        /// <param name="employee"></param>
        /// <param name="comment"></param>
        private CallAjaxResult PostComment(string workId, string ip, string employee, string comment)
        {
            CallAjaxResult result = new CallAjaxResult();
            if (!string.IsNullOrEmpty(workId) && !string.IsNullOrEmpty(comment))
            {
                SFITWorksComments data = new SFITWorksComments();
                data.CommentID = iPower.GUIDEx.New;
                data.ClientIP = ip;
                data.WorkID = workId;
                data.UserName = employee;
                data.Comment = comment;
                data.Status = 0;
                data.CreateDateTime = DateTime.Now;
                if (this.comments.UpdateRecord(data))
                {
                    result.Success = true;
                    result.Message = "评论提交成功！";
                }
                else
                {
                    result.Message = "评论提交失败！";
                }
            }
            return result;
        }
        /// <summary>
        /// 加载报表数据。
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <param name="sid"></param>
        /// <param name="st"></param>
        /// <param name="page"></param>
        /// <param name="index"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private CallAjaxDataGridResult<IndexReport> LoadRptData(string uid, string cid, string stuid, string sid, string st, int page, int index, string sort, string order)
        {
            return this.works.LoadRptData(uid, cid, stuid, sid, st, page, index, sort, order);
        }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CallAjaxResult
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public CallAjaxResult()
        {
            this.Data = this.Message = string.Empty;
        }
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="data"></param>
        public CallAjaxResult(object data)
            : this()
        {
            if (!(this.Success = ((this.Data = data) != null)))
            {
                this.Message = "没有返回数据！";
            }
        }
        /// <summary>
        /// 获取或设置是否成功。
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 获取或设置数据。
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 获取或设置消息。
        /// </summary>
        public string Message { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CallAjaxDataGridResult<T> : CallAjaxResult
    {
        /// <summary>
        /// 
        /// </summary>
        public int total = 0;
        /// <summary>
        /// 
        /// </summary>
        public T[] rows;
    }
}