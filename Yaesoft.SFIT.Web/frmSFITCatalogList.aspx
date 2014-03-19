<%--
//================================================================================
// FileName: frmSFITCatalogList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITCatalogList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITCatalogList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<JWC:LabelEx id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITCatalogEdit.aspx" PickerType="Modal" PickerWidth="800px" PickerHeight="600px" onclick="btnAdd_Click"/>
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
			<JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="128px" />
		</div>
		
		<div style="float:left;">
			<JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_Grade">�꼶��</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="128px" />
		</div>
		
		<div style="float:left;">
			<JWC:LabelEx ID="lbCatalogName" runat="server" Style="float:left;" meta:resourcekey="SFIT_CatalogName">Ŀ¼���ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtCatalogName" runat="server" Width="148px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--������ʾ����-->
	<JWC:DataGridView ID="dgfrmSFITCatalogList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSFITCatalogList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="CatalogID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:BoundFieldEx DataField="SchoolName" HeaderText="����ѧУ" SortExpression="SchoolName" meta:resourcekey="SFIT_DGV_SchoolName">
				<HeaderStyle Width="17%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="GradeName" HeaderText="�����꼶" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="CatalogCode" HeaderText="Ŀ¼����" SortExpression="CatalogCode" meta:resourcekey="SFIT_DGV_CatalogCode">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="800px" WinHeight="600px"
				DataNavigateUrlFormatString="frmSFITCatalogEdit.aspx?CatalogID={0}" DataNavigateUrlField="CatalogID"
				HeaderText="Ŀ¼����" DataField="CatalogName" SortExpression="CatalogName" meta:resourcekey="SFIT_DGV_CatalogName">
				<HeaderStyle Width="30%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="CatalogTypeName" HeaderText="Ŀ¼����" SortExpression="CatalogTypeName" meta:resourcekey="SFIT_DGV_CatalogTypeName">
				<HeaderStyle Width="8%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="CreateEmployeeName" HeaderText="������" SortExpression="CreateEmployeeName" meta:resourcekey="SFIT_DGV_CreateEmployeeName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="LastModifyTime" HeaderText="����ʱ��" SortExpression="LastModifyTime" meta:resourcekey="SFIT_DGV_LastModifyTime" DataFormatString="{0:yyyy-MM-dd}">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
