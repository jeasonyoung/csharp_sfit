<%--
//================================================================================
// FileName: frmSecurityRegsiterList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSecurityRegsiterList.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRegsiterList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
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
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="��ȷ��Ҫɾ����ǰ��ѡ���������" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--��ѯ����-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
		<div style="float:left;">
			<JWC:LabelEx ID="lbSystemName" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemName">ϵͳ���ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSystemName" runat="server" Width="128px" />
		</div>
		
		<div style="float:left;">
		     <JWC:LabelEx ID="lbParentSystem" runat="server" Style="float:left;" meta:resourcekey="Sec_ParentSystem">�ϼ�ϵͳ��</JWC:LabelEx>
		     <JWC:DropDownListEx ID="ddlParentSystem" runat="server" ShowUnDefine="true" ShowTreeView="true" Width="128px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--������ʾ����-->
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
				HeaderText="ϵͳ��ʶ" DataField="SystemSign" SortExpression="SystemSign" meta:resourcekey="Sec_SystemSign">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			��
			<JWC:BoundFieldEx DataField="SystemName" HeaderText="ϵͳ����" SortExpression="SystemName" meta:resourcekey="Sec_SystemName">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="FullSystemName" HeaderText="ϵͳȫ��" SortExpression="FullSystemName" meta:resourcekey="Sec_FullSystemName">
				<HeaderStyle Width="50%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemTypeName" HeaderText="ϵͳ����" SortExpression="SystemTypeName" meta:resourcekey="Sec_SystemTypeName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemStatusName" HeaderText="״̬" SortExpression="SystemStatusName" meta:resourcekey="Sec_SystemStatusName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			��
		</Columns>
	</JWC:DataGridView>
</asp:Content>
