<%--
//================================================================================
//  FileName: frmSFITHobbyGroupList.aspx
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
//--%>
<%@ Page Language="C#" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" AutoEventWireup="true" CodeBehind="frmSFITGroupList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITGroupList" %>
<%@ Register Assembly="iPower.Web" Namespace="iPower.Web.UI" TagPrefix="JWC" %>
<asp:Content ID="ContentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
<!--标题-->
<div class="TitleBar">
    <span class="LabelTitle" style="float: left;">
        <JWC:LabelEx ID="lbTitle" runat="server" />
    </span>
    <div style="float:right;">
		<span style="float:left;">
			<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITGroupEdit.aspx?Type=0&IsUnit=0" PickerType="Modal" PickerWidth="560px" PickerHeight="600px" onclick="btnAdd_Click"/>
		</span>
		<span style="float:left;">|</span>
		<span style="float:left;">
			<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
		</span>
	</div>
</div>
<!--查询区域-->
<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
    <div style="float: left;">
        <JWC:LabelEx ID="lbSchoolName" runat="server" Style="float: left;" meta:resourcekey="SFIT_SchoolName">所属学校：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="168px" />
    </div>
    
    <div style="float: left;">
        <JWC:LabelEx ID="lbGroupName" runat="server" Style="float: left;" meta:resourcekey="SFIT_GroupName">分组名称：</JWC:LabelEx>
        <JWC:TextBoxEx ID="txtGroupName" runat="server" Width="168px" />
    </div>
    
    <div style="float: right;">
        <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" OnClick="btnSearch_Click" />
        <JWC:ServerAlert ID="errMessage" runat="server" />
    </div>
</asp:Panel>

<JWC:DataGridView ID="dgfrmSFITGroupList" runat="server" CssClass="DataGrid"
    Width="98%" ShowFooter="true" AllowSorting="true" AllowPaging="true" AllowExport="false"
    MouseoverCssClass="DataGridHighLight" PageSize="15" OnBuildDataSource="dgfrmSFITGroupList_BuildDataSource">
    <PagerSettings Mode="NextPreviousFirstLast" />
    <AlternatingRowStyle CssClass="DataGridAlter" />
    <HeaderStyle CssClass="DataGridHeader" />
    <FooterStyle CssClass="DataGridFooter" />
    <RowStyle CssClass="DataGridItem" />
    <Columns>
        <JWC:CheckBoxFieldEx DataField="GroupID">
			<HeaderStyle Width="8px" />
		</JWC:CheckBoxFieldEx>
		
        <JWC:BoundFieldEx DataField="UnitName" HeaderText="所属学校" SortExpression="UnitName"  meta:resourcekey="SFIT_DGV_UnitName">
            <HeaderStyle Width="20%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
        <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="560px" WinHeight="600px"
			DataNavigateUrlFormatString="frmSFITGroupEdit.aspx?GroupID={0}&Type={1}&IsUnit={2}" DataNavigateUrlField="GroupID,GroupType,IsUnit"
			HeaderText="分组名称" DataField="GroupName" SortExpression="GroupName" meta:resourcekey="SFIT_DGV_GroupName">
			<HeaderStyle Width="20%" />
			<ItemStyle HorizontalAlign="Left" />
		</JWC:MultiQueryStringFieldEx>
        
        <JWC:BoundFieldEx DataField="Description" HeaderText="描述说明" CharCount="20" SortExpression="Description" ShowToolTip="true" ToolTipField="Description" meta:resourcekey="SFIT_DGV_Description">
            <HeaderStyle Width="36%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
         <JWC:BoundFieldEx DataField="LastModifyEmployeeName" HeaderText="创建/修改人" SortExpression="LastModifyEmployeeName"  meta:resourcekey="SFIT_DGV_LastModifyEmployeeName">
            <HeaderStyle Width="10%" />
            <ItemStyle HorizontalAlign="Left" />
        </JWC:BoundFieldEx>
        
         <JWC:BoundFieldEx DataField="LastModifyTime" HeaderText="创建/修改时间" SortExpression="LastModifyTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"  meta:resourcekey="SFIT_DGV_LastModifyTime">
            <HeaderStyle Width="14%" />
            <ItemStyle HorizontalAlign="Center" />
        </JWC:BoundFieldEx>
        
    </Columns>
</JWC:DataGridView></asp:Content>
