<%--
//================================================================================
// FileName: frmSecurityActionList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSecurityActionList.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityActionList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
		     <span style="float:left;">
		        <JWC:ButtonEx ID="btnImport" runat="server" ButtonType="Import" PickerPage="frmSecurityActionImport.aspx"  PickerType="Modal" PickerWidth="750px" PickerHeight="520px" onclick="btnAdd_Click" />
		    </span>
		    <span style="float:left;">|</span>
		    <span style="float:left;">
		        <JWC:ButtonEx ID="btnExport" runat="server" ButtonType="Export" PickerPage="frmSecurityActionExport.aspx"  PickerType="Modal" PickerWidth="750px" PickerHeight="520px" onclick="btnAdd_Click" />
		    </span>
		    <span style="float:left;">|</span>
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSecurityActionEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="260px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbActionName" runat="server" Style="float:left;" meta:resourcekey="Sec_ActionName">元操作名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtActionName" runat="server" Width="128px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSecurityActionList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSecurityActionList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="ActionID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="260px"
				DataNavigateUrlFormatString="frmSecurityActionEdit.aspx?ActionID={0}" DataNavigateUrlField="ActionID"
				HeaderText="元操作编号" DataField="ActionID" SortExpression="ActionID" meta:resourcekey="Sec_ActionID">
				<HeaderStyle Width="25%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="ActionSign" HeaderText="元操作标识" SortExpression="ActionSign" meta:resourcekey="Sec_ActionSign">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="ActionTypeName" HeaderText="元操作类型" SortExpression="ActionTypeName" meta:resourcekey="Sec_ActionTypeName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="ActionName" HeaderText="元操作名称" SortExpression="ActionName" meta:resourcekey="Sec_ActionName">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="ActionDescription" HeaderText="描述" SortExpression="ActionDescription" meta:resourcekey="Sec_ActionDescription">
				<HeaderStyle Width="25%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
