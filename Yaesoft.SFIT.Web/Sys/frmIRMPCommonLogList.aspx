<%--
//================================================================================
// FileName: frmIRMPCommonLogList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmIRMPCommonLogList.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmIRMPCommonLogList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmIRMPCommonLogEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="260px" onclick="btnAdd_Click"/>
			</span>
			<span style="float:left;">|</span>
			<span style="float:left;">
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="��ȷ��Ҫɾ����ǰ��ѡ���������" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--��ѯ����-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemName" runat="server" Style="float:left;" meta:resourcekey="Sys_SystemName">ϵͳ���ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSystemName" runat="server" Width="128px" />
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbEmployeeName" runat="server" Style="float:left;" meta:resourcekey="Sys_EmployeeName">�û����ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtEmployeeName" runat="server" Width="128px" />
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbCreateDate" runat="server" Style="float:left;" meta:resourcekey="Sys_CreateDate">����ʱ�䣺</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtCreateDate" runat="server" Width="86px" />
		    </div>
		</div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbLogContext" runat="server" Style="float:left;" meta:resourcekey="Sys_LogContext">��־���ݣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtLogContext" runat="server" Width="480px" />
		    </div>
		    <div style="float:right;">
			    <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			    <JWC:ServerAlert ID="errMessage" runat="server" />
		    </div>
		</div>
	</asp:Panel>
	<!--������ʾ����-->
	<JWC:DataGridView ID="dgfrmIRMPCommonLogList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmIRMPCommonLogList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="LogID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="260px"
				DataNavigateUrlFormatString="frmIRMPCommonLogEdit.aspx?LogID={0}" DataNavigateUrlField="LogID"
				HeaderText="����ʱ��" DataField="CreateDate" SortExpression="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" meta:resourcekey="Sys_CreateDate">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemName" HeaderText="ϵͳ����" SortExpression="SystemName" meta:resourcekey="Sys_SystemName">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
						
			<JWC:BoundFieldEx DataField="CreateEmployeeName" HeaderText="�û�����" SortExpression="CreateEmployeeName" meta:resourcekey="Sys_CreateEmployeeName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="RelationTable" HeaderText="����" SortExpression="RelationTable" meta:resourcekey="Sys_RelationTable">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="LogContext" HeaderText="��־����" SortExpression="LogContext" CharCount="60" meta:resourcekey="Sys_LogContext">
				<HeaderStyle Width="50%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
		</Columns>
	</JWC:DataGridView>
</asp:Content>
