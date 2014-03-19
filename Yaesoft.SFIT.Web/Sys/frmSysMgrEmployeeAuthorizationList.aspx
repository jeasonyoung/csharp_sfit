<%--
//================================================================================
// FileName: frmSysMgrEmployeeAuthorizationList.aspx
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
//--%>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSysMgrEmployeeAuthorizationList.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrEmployeeAuthorizationList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSysMgrEmployeeAuthorizationEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="460px" onclick="btnAdd_Click"/>
			</span>
			<span style="float:left;">|</span>
			<span style="float:left;">
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--查询区域-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
		<div style="float:left;">
			<JWC:LabelEx ID="lbEmployeeName" runat="server" Style="float:left;" meta:resourcekey="Sys_EmployeeName">用户名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtEmployeeName" runat="server" Width="128px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSysMgrEmployeeAuthorizationList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
		PageSize="10" onbuilddatasource="dgfrmSysMgrEmployeeAuthorizationList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="EmployeeID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="460px"
				DataNavigateUrlFormatString="frmSysMgrEmployeeAuthorizationEdit.aspx?EmployeeID={0}" DataNavigateUrlField="EmployeeID"
				HeaderText="用户名称" DataField="EmployeeName" SortExpression="EmployeeName" meta:resourcekey="Sys_EmployeeName">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="AppSystemName" HeaderText="系统名称" SortExpression="AppSystemName" meta:resourcekey="Sys_AppSystemName">
				<HeaderStyle Width="85%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
