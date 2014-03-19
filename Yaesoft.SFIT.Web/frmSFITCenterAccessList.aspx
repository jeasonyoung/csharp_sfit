<%--
//================================================================================
// FileName: frmSFITCenterAccessList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITCenterAccessList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITCenterAccessList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<JWC:LabelEx id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
		    <span style="float:left;">
		        <JWC:ButtonEx ID="btnBuild" runat="server" Text="������Կ" ShowConfirmMsg="true" ConfirmMsg="��ȷ��Ҫ������Կ��" OnClick="btnBuild_OnClick"/>
		    </span>
		    <span style="float:left;">|</span>
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITCenterAccessEdit.aspx" PickerType="Modal" PickerWidth="480px" PickerHeight="230px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbSchoolName" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolName">ѧУ���ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="168px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--������ʾ����-->
	<JWC:DataGridView ID="dgfrmSFITCenterAccessList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSFITCenterAccessList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="AccessID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="480px" WinHeight="230px"
				DataNavigateUrlFormatString="frmSFITCenterAccessEdit.aspx?AccessID={0}" DataNavigateUrlField="AccessID"
				HeaderText="ѧУ����" DataField="SchoolName" SortExpression="SchoolName" meta:resourcekey="SFIT_SchoolName">
				<HeaderStyle Width="30%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="AccessAccount" HeaderText="�����˺�" SortExpression="AccessAccount" meta:resourcekey="SFIT_AccessAccount">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="AccessPassword" HeaderText="��������" SortExpression="AccessPassword" meta:resourcekey="SFIT_AccessPassword">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
						
			<JWC:BoundFieldEx DataField="AccessStatusName" HeaderText="����״̬" SortExpression="AccessStatusName" meta:resourcekey="SFIT_AccessStatusName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="Description" HeaderText="����" SortExpression="Description" 
			    ToolTipField="Description" ShowToolTip="true" CharCount="50" meta:resourcekey="SFIT_Description" >
				<HeaderStyle Width="35%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
