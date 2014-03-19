//================================================================================
//  FileName: frmSFITGroupEdit.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/17
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iPower;
using iPower.Web.UI;
using iPower.Platform;
using iPower.Platform.Engine;
using iPower.Platform.Engine.Service;
using Yaesoft.SFIT.Engine.Domain;
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmSFITGroupEdit : ModuleBasePage, ISFITGroupEditView
    {
        #region 成员变量，构造函数。
        SFITGroupPresenter presenter = null;
        /// <summary>
        /// 构造函数。
        /// </summary>
        public frmSFITGroupEdit()
        {
            this.presenter = new SFITGroupPresenter(this);
        }
        #endregion

        #region 事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.IsUnit)
                {
                    this.ddlUnit.ShowUnDefine = false;
                    this.ddlUnit.IsRequired = true;
                }
                this.presenter.InitializeComponent();
            }
        }

        protected void dgGroupCatalog_BuildDataSource(object sender, EventArgs e)
        {
            this.dgGroupCatalog.DataSource = this.GroupCatalogs;
        }

        protected void dgGroupStudents_BuildDataSource(object sender, EventArgs e)
        {
            this.dgGroupStudents.DataSource = this.GroupStudents;
        }
        
        protected void btnAddCatalog_OnClick(object sender, EventArgs e)
        {
            this.LoadGroupDataSource();
        }

        protected void hiddenCatalogValue_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                string strValue = this.hiddenCatalogValue.Value;
                if (!string.IsNullOrEmpty(strValue))
                {
                    bool add = false;
                    List<GroupCatalogItem> list = this.GroupCatalogs;
                    if (list == null)
                        list = new List<GroupCatalogItem>();
                    foreach (string s in strValue.Split('|'))
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            string[] arr = s.Split('#');
                            if (arr != null && arr.Length == 4)
                            {
                                GroupCatalogItem item = new GroupCatalogItem();
                                item.CatalogID = arr[0];
                                item.CatalogName = arr[1];
                                item.UnitName = arr[2];
                                item.GradeName = arr[3];



                                int index = list.FindIndex(new Predicate<GroupCatalogItem>(delegate(GroupCatalogItem o)
                                {
                                    return (o != null) && (o.CatalogID == item.CatalogID);
                                }));

                                if (index > -1)
                                {
                                    list[index] = item;
                                }
                                else
                                {
                                    list.Add(item);
                                }
                                add = true;
                            }
                        }
                    }

                    if (add)
                    {
                        this.GroupCatalogs = list;
                        this.hiddenCatalogValue.Value = string.Empty;
                    }
                }
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);   
            }
        }

        protected void btnAddStudents_OnClick(object sender, EventArgs e)
        {
            this.LoadGroupDataSource();
        }

        protected void hiddenStudentsValue_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                 string strValue = this.hiddenStudentsValue.Value;
                 if (!string.IsNullOrEmpty(strValue))
                 {
                     bool add = false;
                     List<GroupStudentsItem> list = this.GroupStudents;
                     if (list == null)
                         list = new List<GroupStudentsItem>();
                     foreach (string s in strValue.Split('|'))
                     {
                         if (!string.IsNullOrEmpty(s))
                         {
                             string[] arr = s.Split('#');
                             if (arr != null && arr.Length == 5)
                             {
                                 GroupStudentsItem item = new GroupStudentsItem();
                                 item.StudentID = arr[0];
                                 item.StudentName = arr[1];
                                 item.StudentCode = arr[2];
                                 item.UnitName = arr[3];
                                 item.ClassName = arr[4];

                                 int index = list.FindIndex(new Predicate<GroupStudentsItem>(delegate(GroupStudentsItem o)
                                 {
                                     return (o != null) && (o.StudentID == item.StudentID);
                                 }));

                                 if (index > -1)
                                 {
                                     list[index] = item;
                                 }
                                 else
                                 {
                                     list.Add(item);
                                 }
                                 add = true;
                             }
                         }
                     }

                     if (add)
                     {
                         this.GroupStudents = list;
                         this.hiddenStudentsValue.Value = string.Empty;
                     }
                 }
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }

        protected void btnDeleteCatalog_OnClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                if (btn != null)
                {
                    DataControlFieldCellEx fieldCellEx = btn.Parent as DataControlFieldCellEx;
                    if (fieldCellEx != null)
                    {
                        DataGridViewRow row = fieldCellEx.Parent as DataGridViewRow;
                        if (row != null)
                        {
                            List<GroupCatalogItem> list = this.GroupCatalogs;
                            if (list != null && list.Count > 0)
                            {
                                list.RemoveAt(row.RowIndex);
                                this.LoadGroupDataSource();
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message); 
            }
        }

        protected void btnDeleteStudents_OnClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                if (btn != null)
                {
                    DataControlFieldCellEx fieldCellEx = btn.Parent as DataControlFieldCellEx;
                    if (fieldCellEx != null)
                    {
                        DataGridViewRow row = fieldCellEx.Parent as DataGridViewRow;
                        if (row != null)
                        {
                            List<GroupStudentsItem> list = this.GroupStudents;
                            if (list != null && list.Count > 0)
                            {
                                list.RemoveAt(row.RowIndex);
                                this.LoadGroupDataSource();
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SFITGroup data = new SFITGroup();
                data.GroupID = this.GroupID.IsValid ? this.GroupID : GUIDEx.New;
                data.GroupName = this.txtGroupName.Text.Trim();
                data.UnitID = this.ddlUnit.SelectedValue;
                data.Description = this.txtDescription.Text.Trim();
                data.OrderNO = int.Parse(this.txtOrderNO.Text);
                data.GroupType = this.GroupType;
                data.LastModifyEmployeeID = this.CurrentUserID;
                data.LastModifyEmployeeName = this.CurrentUserName;
                data.LastModifyTime = DateTime.Now;

                if (this.presenter.UpdateEntityData(data))
                    this.SaveData();
            }
            catch (Exception x)
            {
                this.ShowMessage(x.Message);
            }
        }
        #endregion

        #region  辅助函数。
        void LoadGroupDataSource()
        {
            this.dgGroupCatalog.InvokeBuildDataSource();
            this.dgGroupStudents.InvokeBuildDataSource();
        }
        #endregion

        #region 重载。
        public override void LoadData()
        {
            this.presenter.LoadEntityData(new EventHandler<EntityEventArgs<SFITGroup>>(delegate(object sender, EntityEventArgs<SFITGroup> e)
            {
                if (e.Entity != null)
                {
                    this.txtGroupName.Text = e.Entity.GroupName;
                    this.ddlUnit.SelectedValue = e.Entity.UnitID;
                    this.txtDescription.Text = e.Entity.Description;
                    this.txtOrderNO.Text = e.Entity.OrderNO.ToString();
                }
            }));
            this.LoadGroupDataSource();
        }
        #endregion

        #region ISFITGroupEditView 成员

        public GUIDEx GroupID
        {
            get { return this.RequestGUIEx("GroupID"); }
        }

        public int GroupType
        {
            get
            {
                int result = 0;
                try
                {
                    string str = this.Request["Type"];
                    if (!string.IsNullOrEmpty(str))
                    {
                        result = int.Parse(str);
                    }
                }
                catch (Exception) { }
                return result;
            }
        }

        public bool IsUnit
        {
            get
            {
                bool result = false;
                try
                {
                    string str = this.Request["IsUnit"];
                    if (!string.IsNullOrEmpty(str))
                        result = bool.Parse(str);
                }
                catch (Exception) { }
                return result;
            }
        }

        public List<GroupCatalogItem> GroupCatalogs
        {
            get
            {
                return this.ViewState["GroupCatalogs"] as List<GroupCatalogItem>;
            }
            set
            {
                if (value != null)
                    this.ViewState["GroupCatalogs"] = value;
            }
        }

        public List<GroupStudentsItem> GroupStudents
        {
            get
            {
                return this.ViewState["GroupStudents"] as List<GroupStudentsItem>;
             }
            set
            {
                if (value != null)
                    this.ViewState["GroupStudents"] = value;
            }
        }

        public void BindUnit(iPower.Platform.Engine.DataSource.IListControlsData data)
        {
            this.ListControlsDataSourceBind(this.ddlUnit, data);
        }
 
        public void ShowMessage(string msg)
        {
            this.errMessage.Message = msg;
        }

        #endregion
    }
}
