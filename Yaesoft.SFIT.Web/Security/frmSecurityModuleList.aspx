<%--
//================================================================================
// FileName: frmSecurityModuleList.aspx
// Desc:
// Called by
// Auth: �������ɴ����������Զ����ɡ�
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
	<!--����-->
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
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="��ȷ��Ҫɾ����ǰ��ѡ���������" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--��ѯ����-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
		<div style="float:left;">
		    <JWC:LabelEx ID="lbModuleName" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleName">ģ�����ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtModuleName" runat="server" Width="128px" />
		</div>
		
		<div style="float:left;">
		    <JWC:LabelEx ID="lbSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemID">����ϵͳ��</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlSystemID" runat="server" ShowUnDefine="true" ShowTreeView="true" Width="128px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--������ʾ����-->
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
				HeaderText="ģ������" DataField="ModuleName" SortExpression="ModuleName" meta:resourcekey="Sec_ModuleName">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemName" HeaderText="����ϵͳ" SortExpression="SystemName" meta:resourcekey="Sec_SystemName">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="FullModuleName" HeaderText="ģ��ȫ��" SortExpression="FullModuleName" meta:resourcekey="Sec_FullModuleName">
				<HeaderStyle Width="50%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			 
			
			<JWC:BoundFieldEx DataField="ModuleStatusName" HeaderText="״̬" SortExpression="ModuleStatusName" meta:resourcekey="Sec_ModuleStatusName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
