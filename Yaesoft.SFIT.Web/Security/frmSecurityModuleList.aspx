<%--
//================================================================================
// FileName: frmSecurityModuleList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSecurityModuleList.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityModuleList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
		    <span style="float:left;">
		        <JWC:ButtonEx ID="btnImport" runat="server" ButtonType="Import" PickerPage="frmSecurityModuleImport.aspx"  PickerType="Modal" PickerWidth="750px" PickerHeight="520px" onclick="btnAdd_Click" />
		    </span>
		    <span style="float:left;">|</span>
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSecurityModuleEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="260px" onclick="btnAdd_Click"/>
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
		    <JWC:LabelEx ID="lbModuleName" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleName">模块名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtModuleName" runat="server" Width="128px" />
		</div>
		
		<div style="float:left;">
		    <JWC:LabelEx ID="lbSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemID">所属系统：</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlSystemID" runat="server" ShowUnDefine="true" ShowTreeView="true" Width="128px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSecurityModuleList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSecurityModuleList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="ModuleID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="260px"
				DataNavigateUrlFormatString="frmSecurityModuleEdit.aspx?ModuleID={0}" DataNavigateUrlField="ModuleID"
				HeaderText="模块名称" DataField="ModuleName" SortExpression="ModuleName" meta:resourcekey="Sec_ModuleName">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemName" HeaderText="所属系统" SortExpression="SystemName" meta:resourcekey="Sec_SystemName">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="FullModuleName" HeaderText="模块全称" SortExpression="FullModuleName" meta:resourcekey="Sec_FullModuleName">
				<HeaderStyle Width="50%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			 
			
			<JWC:BoundFieldEx DataField="ModuleStatusName" HeaderText="状态" SortExpression="ModuleStatusName" meta:resourcekey="Sec_ModuleStatusName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
