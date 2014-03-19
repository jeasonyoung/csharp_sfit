//================================================================================
//  FileName: IndexDetails.aspx.cs
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2013-1-21
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
using Yaesoft.SFIT.Engine.Service;
namespace Yaesoft.SFIT.Web
{
    /// <summary>
    /// 
    /// </summary>
    public partial class IndexDetails : ModuleBasePage, IIndexDetailsView
    {
        #region 成员变量，构造函数。
        IndexDetailsPresenter presenter = null;
        /// <summary>
        /// 
        /// </summary>
        public IndexDetails()
        {
            this.presenter = new IndexDetailsPresenter(this);
        }
        #endregion

        #region  事件处理。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.presenter.InitializeComponent();
            }
        }
        #endregion

        #region IIndexDetailsView 成员

        public GUIDEx WorkID
        {
            get { return this.RequestGUIEx("WorkID"); }
        }

        public string SchoolName
        {
            get
            {
                object o = this.ViewState["SchoolName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["SchoolName"] = value;
            }
        }

        public string GradeName
        {
            get
            {
                object o = this.ViewState["GradeName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["GradeName"] = value;
            }
        }

        public string ClassName
        {
            get
            {
                object o = this.ViewState["ClassName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["ClassName"] = value;
            }
        }

        public string CatalogName
        {
            get
            {
                object o = this.ViewState["CatalogName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["CatalogName"] = value;
            }
        }

        public string StudentName
        {
            get
            {
                object o = this.ViewState["StudentName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["StudentName"] = value;
            }
        }

        public string WorkName
        {
            get
            {
                object o = this.ViewState["WorkName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["WorkName"] = value;
            }
        }

        public string WorkStatus
        {
            get
            {
                object o = this.ViewState["WorkStatus"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["WorkStatus"] = value;
            }
        }

        public string WorkDescription
        {
            get
            {
                object o = this.ViewState["WorkDescription"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["WorkDescription"] = value;
            }
        }

        public string CheckCode
        {
            get
            {
                object o = this.ViewState["CheckCode"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["CheckCode"] = value;
            }
        }

        public string WorkValue
        {
            get
            {
                object o = this.ViewState["WorkValue"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["WorkValue"] = value;
            }
        }

        public string WorkSubRev
        {
            get
            {
                object o = this.ViewState["WorkSubRev"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["WorkSubRev"] = value;
            }
        }

        public string WorkTeaName
        {
            get
            {
                object o = this.ViewState["WorkTeaName"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                this.ViewState["WorkTeaName"] = value;
            }
        }

        public int Hits
        {
            get
            {
                object o = this.ViewState["Hits"];
                return o == null ? 0 : int.Parse(o.ToString());
            }
            set
            {
                this.ViewState["Hits"] = value;
            }
        }

        #endregion
    }
}