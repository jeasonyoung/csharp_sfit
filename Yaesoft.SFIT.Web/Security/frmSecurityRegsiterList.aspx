<%--
//================================================================================
// FileName: frmSecurityRegsiterList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSecurityRegsiterList.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRegsiterList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
		    <span style="float:left;">
		        <JWC:ButtonEx ID="btnImport" runat="server" ButtonType="Import" PickerPage="frmSecurityRegsiterImport.aspx"  PickerType="Modal" PickerWidth="750px" PickerHeight="520px" onclick="btnImport_Click" />
		    </span>
		    <span style="float:left;">|</span>
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSecurityRegsiterEdit.aspx" PickerType="Modal" PickerWidth="520px" PickerHeight="340px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbSystemName" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemName">系统名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSystemName" runat="server" Width="128px" />
		</div>
		
		<div style="float:left;">
		     <JWC:LabelEx ID="lbParentSystem" runat="server" Style="float:left;" meta:resourcekey="Sec_ParentSystem">上级系统：</JWC:LabelEx>
		     <JWC:DropDownListEx ID="ddlParentSystem" runat="server" ShowUnDefine="true" ShowTreeView="true" Width="128px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSecurityRegsiterList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSecurityRegsiterList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="SystemID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="520px" WinHeight="340px"
				DataNavigateUrlFormatString="frmSecurityRegsiterEdit.aspx?SystemID={0}" DataNavigateUrlField="SystemID"
				HeaderText="系统标识" DataField="SystemSign" SortExpression="SystemSign" meta:resourcekey="Sec_SystemSign">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			　
			<JWC:BoundFieldEx DataField="SystemName" HeaderText="系统名称" SortExpression="SystemName" meta:resourcekey="Sec_SystemName">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="FullSystemName" HeaderText="系统全称" SortExpression="FullSystemName" meta:resourcekey="Sec_FullSystemName">
				<HeaderStyle Width="50%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemTypeName" HeaderText="系统类型" SortExpression="SystemTypeName" meta:resourcekey="Sec_SystemTypeName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemStatusName" HeaderText="状态" SortExpression="SystemStatusName" meta:resourcekey="Sec_SystemStatusName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			　
		</Columns>
	</JWC:DataGridView>
</asp:Content>
