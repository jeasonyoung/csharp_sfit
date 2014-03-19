//================================================================================
// FileName: SFITTeaClassPresenter.cs
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
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using iPower.Platform.Engine.DataSource;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Persistence;
namespace Yaesoft.SFIT.Engine.Service
{
	///<summary>
	/// ISFITTeaClassView接口。
	///</summary>
	public interface ISFITTeaClassView: IModuleView
	{
        /// <summary>
        /// 显示消息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg);
	}
    /// <summary>
    /// 列表页面接口。
    /// </summary>
    public interface ISFITTeaClassListView : ISFITTeaClassView
    {
        /// <summary>
        /// 获取学校名称。
        /// </summary>
        string SchoolName { get; }
        /// <summary>
        /// 获取教师名称。
        /// </summary>
        string TearcherName { get; }
        /// <summary>
        /// 获取班级名称。
        /// </summary>
        string ClassName { get; }
       
    }
    /// <summary>
    /// 编辑页面接口
    /// </summary>
    public interface ISFITTeaClassEditView : ISFITTeaClassView
    {
        /// <summary>
        /// 获取教师ID。
        /// </summary>
        GUIDEx TeacherID { get; }
        /// <summary>
        /// 绑定班级数据。
        /// </summary>
        /// <param name="data"></param>
        void BindClasses(IListControlsData data);
    }
	///<summary>
	/// SFITTeaClassPresenter行为类。
	///</summary>
	public class SFITTeaClassPresenter: ModulePresenter<ISFITTeaClassView>
	{
		#region 成员变量，构造函数。
        SFITClassEntity classEntity = null;
        TeaClassPresenterExtend<ISFITTeaClassView> extend = null;
		///<summary>
		///构造函数。
		///</summary>
		public SFITTeaClassPresenter(ISFITTeaClassView view)
		: base(view)
		{
            this.View.SecurityID = ModuleConstants.TeaClass_ModuleID;
            this.classEntity = new SFITClassEntity();
            this.extend = new TeaClassPresenterExtend<ISFITTeaClassView>(this.View);
		}
		#endregion

        #region 重载。
        /// <summary>
        /// 
        /// </summary>
        protected override void PreViewLoadData()
        {
            base.PreViewLoadData();
        }
        #endregion

        #region 数据操作函数。
        /// <summary>
        /// 获取列表数据。
        /// </summary>
        public DataTable ListDataSource
        {
            get
            {
                return this.extend.ListDataSource;
            }
        }
        ///<summary>
		///编辑页面加载数据。
		///</summary>
        public void LoadEntityData(EventHandler<EntityEventArgs<SchoolTeacherInfo>> handler)
		{
            this.extend.LoadEntityData(handler);
		}
        /// <summary>
        /// 批量删除数据。
        /// </summary>
        /// <param name="priCollection"></param>
        /// <returns></returns>
        public bool BatchDeleteTeaClass(StringCollection priCollection)
        {
            return this.extend.BatchDeleteTeaClass(priCollection);
        }
        /// <summary>
        /// 保存数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateTeaClass(SchoolTeacherInfo data)
        {
            return this.extend.UpdateTeaClass(data);
        }
        /// <summary>
        /// 变更学校数据。
        /// </summary>
        public void ChangeSchool(GUIDEx schoolID)
        {
            ISFITTeaClassEditView editView = this.View as ISFITTeaClassEditView;
            if (editView != null)
            {
                editView.BindClasses(this.classEntity.BindClass(schoolID));
            }
        }
		#endregion
    }
}
