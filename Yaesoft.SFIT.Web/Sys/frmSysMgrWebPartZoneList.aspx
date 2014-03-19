<%--
//================================================================================
// FileName: frmSysMgrWebPartZoneList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSysMgrWebPartZoneList.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrWebPartZoneList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSysMgrWebPartZoneEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="280px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbZoneName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartZoneName">����λ�����ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtZoneName" runat="server" ShowUnDefine="true" Width="128px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--������ʾ����-->
	<JWC:DataGridView ID="dgfrmSysMgrWebPartZoneList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
		PageSize="10" onbuilddatasource="dgfrmSysMgrWebPartZoneList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="ZoneID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemName" HeaderText="����ϵͳ" SortExpression="SystemName" meta:resourcekey="Sys_SystemName">
				<HeaderStyle Width="45%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="280px"
				DataNavigateUrlFormatString="frmSysMgrWebPartZoneEdit.aspx?ZoneID={0}" DataNavigateUrlField="ZoneID"
				HeaderText="����λ������" DataField="ZoneName" SortExpression="ZoneName" meta:resourcekey="Sys_ZoneName">
				<HeaderStyle Width="35%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="ZoneModeName" HeaderText="��ʾλ��" SortExpression="ZoneMode" meta:resourcekey="Sys_ZoneMode">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="ZoneLength" HeaderText="�����ʾ��Ŀ" SortExpression="ZoneLength" meta:resourcekey="Sys_ZoneLength">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Right" />
			</JWC:BoundFieldEx>
			
		</Columns>
	</JWC:DataGridView>
</asp:Content>
