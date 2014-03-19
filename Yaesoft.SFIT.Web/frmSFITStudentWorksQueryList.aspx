<%--
//================================================================================
//  FileName: frmSFITStudentWorksQueryList.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/13
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
//--%>
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITStudentWorksQueryList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITStudentWorksQueryList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
 <!--标题-->
<div class="TitleBar">
    <span class="LabelTitle" style="float: left;">
        <JWC:LabelEx ID="lbTitle" runat="server" />
    </span>
</div>
<!--查询区域-->
<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
    <div style="float:left; width:100%;">
    
        <div style="float: left;">
            <JWC:LabelEx ID="lbSchoolName" runat="server" Style="float: left;" meta:resourcekey="SFIT_SchoolName">所属学校：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="168px" />
        </div>
        
        <div style="float: left;">
            <JWC:LabelEx ID="lbGrade" runat="server" Style="float: left;" meta:resourcekey="SFIT_Grade">所属年级：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtGradeName" runat="server" Width="168px" />
        </div>
        
        <div style="float: left;">
            <JWC:LabelEx ID="lbClassName" runat="server" Style="float: left;" meta:resourcekey="SFIT_ClassName">所属班级：</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtClassName" runat="server" Width="168px" />
        </div>
    
    </div>
    
    <div style="float: left;">
        <JWC:LabelEx ID="lbCatalogName" runat="server" Style="float: left;" meta:resourcekey="SFIT_CatalogName">所属目录：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtCatalogName" runat="server" Width="168px" />
    </div>
    
    <div style="float: left;">
        <JWC:LabelEx ID="lbWorkName" runat="server" Style="float: left;" meta:resourcekey="SFIT_WorkName">作品名称：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtWorkName" runat="server" Width="168px" />
    </div>
    
    <div style="float: left;">
        <JWC:LabelEx ID="lbWorkStatus" runat="server" Style="float: left;" meta:resourcekey="SFIT_WorkStatus">作品状态：</JWC:LabelEx>
        <JWC:DropDownListEx ID="ddlWorkStatus" runat="server" ShowUnDefine="true" Width="168px" />
    </div>
    
    <div style="float: right;">
        <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_Click" />
        <JWC:ServerAlert ID="errMessage" runat="server" />
    </div>
</asp:Panel>

<!--数据显示区域-->
<JWC:DataGridView ID="dgfrmSFITStudentWorksQueryList" runat="server" CssClass="DataGrid"
    Width="98%" ShowFooter="true" AllowSorting="true" AllowPaging="true" AllowExport="false"
    MouseoverCssClass="DataGridHighLight" PageSize="15" OnBuildDataSource="dgfrmSFITStudentWorksQueryList_BuildDataSource">
    <PagerSettings Mode="NextPreviousFirstLast" />
    <AlternatingRowStyle CssClass="DataGridAlter" />
    <HeaderStyle CssClass="DataGridHeader" />
    <FooterStyle CssClass="DataGridFooter" />
    <RowStyle CssClass="DataGridItem" />
    <Columns>
        
        <JWC:BoundFieldEx DataField="SchoolName" HeaderText="所属学校" SortExpression="SchoolName"  meta:resourcekey="SFIT_DGV_SchoolName">
            <HeaderStyle Width="15%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="GradeName" HeaderText="所属年级" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
            <HeaderStyle Width="8%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
                    
        <JWC:BoundFieldEx DataField="ClassName" HeaderText="所属班级" SortExpression="ClassName" meta:resourcekey="SFIT_DGV_ClassName">
            <HeaderStyle Width="10%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="640px" WinHeight="560px"
			DataNavigateUrlFormatString="frmSFITStudentWorksQueryEdit.aspx?WorkID={0}" DataNavigateUrlField="WorkID"
			HeaderText="作品名称" DataField="WorkName" SortExpression="WorkName" meta:resourcekey="SFIT_DGV_WorkName">
			<HeaderStyle Width="29%" />
			<ItemStyle HorizontalAlign="Left" />
		</JWC:MultiQueryStringFieldEx>
                
        <JWC:BoundFieldEx DataField="ReviewValue" HeaderText="教师评阅" SortExpression="ReviewValue" meta:resourcekey="SFIT_DGV_ReviewValue">
            <HeaderStyle Width="8%" />
            <ItemStyle HorizontalAlign="Right" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="WorkStatusName" HeaderText="作品状态" SortExpression="WorkStatusName" meta:resourcekey="SFIT_DGV_WorkStatusName">
            <HeaderStyle Width="20%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:BoundFieldEx DataField="CreateDateTime" HeaderText="处理时间" SortExpression="CreateDateTime" meta:resourcekey="SFIT_DGV_CreateDateTime"
             DataFormatString="{0:yyyy-MM-dd}">
            <HeaderStyle Width="10%" />
            <ItemStyle HorizontalAlign="Center" />
        </JWC:BoundFieldEx>
    </Columns>
</JWC:DataGridView>
</asp:Content>
