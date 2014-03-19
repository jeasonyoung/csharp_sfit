<%--
//================================================================================
// FileName: frmSysMgrWebPartList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSysMgrWebPartList.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrWebPartList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSysMgrWebPartEdit.aspx" PickerType="Modal" PickerWidth="560px" PickerHeight="460px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbWebPartName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartName">�������ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtWebPartName" runat="server" ShowUnDefine="true" Width="128px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--������ʾ����-->
	<JWC:DataGridView ID="dgfrmSysMgrWebPartList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
		PageSize="10" onbuilddatasource="dgfrmSysMgrWebPartList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="WebPartID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="560px" WinHeight="460px"
				DataNavigateUrlFormatString="frmSysMgrWebPartEdit.aspx?WebPartID={0}" DataNavigateUrlField="WebPartID"
				HeaderText="��������" DataField="WebPartName" SortExpression="WebPartName" meta:resourcekey="Sys_WebPartName">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="WebPartTemplateName" HeaderText="����ģ��" SortExpression="WebPartTemplateName" meta:resourcekey="Sys_WebPartTemplateName">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="DataAssemblyName" HeaderText="���ݳ���" SortExpression="DataAssemblyName" meta:resourcekey="Sys_DataAssemblyName">
				<HeaderStyle Width="25%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="DataClassName" HeaderText="�ӿ�������" SortExpression="DataClassName" meta:resourcekey="Sys_DataClassName">
				<HeaderStyle Width="35%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="WebPartStatusName" HeaderText="״̬" SortExpression="WebPartStatus"  meta:resourcekey="Sys_WebPartStatus">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
