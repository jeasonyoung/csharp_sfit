<%--
//================================================================================
// FileName: frmSecurityRoleRightList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSecurityRoleRightList.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRoleRightList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSecurityRoleRightEdit.aspx" PickerType="Modal" PickerWidth="440px" PickerHeight="560px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbRoleName" runat="server" Style="float:left;" meta:resourcekey="Sec_RoleName">��ɫ���ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtRoleName" runat="server" Width="128px" />
		</div>
		<div style="float:left;">
			<JWC:LabelEx ID="lbModuleRoleName" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleRoleName">ģ��Ȩ�ޣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtModuleRoleName" runat="server" Width="128px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--������ʾ����-->
	<div style="float:left;width:98%;height:495px;overflow:auto;">
	    <JWC:DataGridView ID="dgfrmSecurityRoleRightList" runat="server" CssClass="DataGrid" Width="96%" ShowFooter="true"
		    AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		    PageSize="15" onbuilddatasource="dgfrmSecurityRoleRightList_BuildDataSource">
		    <PagerSettings Mode="NextPreviousFirstLast" />
		    <AlternatingRowStyle CssClass="DataGridAlter" />
		    <HeaderStyle CssClass="DataGridHeader" />
		    <FooterStyle CssClass="DataGridFooter" />
		    <RowStyle CssClass="DataGridItem" />
		    <Columns>
			    <JWC:CheckBoxFieldEx DataField="RoleID">
				    <HeaderStyle Width="8px" />
			    </JWC:CheckBoxFieldEx>
    			
			    <JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="440px" WinHeight="560px"
				    DataNavigateUrlFormatString="frmSecurityRoleRightEdit.aspx?RoleID={0}" DataNavigateUrlField="RoleID"
				    HeaderText="��ɫ����" DataField="RoleName" SortExpression="RoleName" meta:resourcekey="Sec_RoleName">
				    <HeaderStyle Width="15%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:MultiQueryStringFieldEx>
    			
			    <JWC:BoundFieldEx DataField="RightNames" HeaderText="����Ȩ��" SortExpression="RightNames" meta:resourcekey="Sec_RightNames">
				    <HeaderStyle Width="85%" />
				    <ItemStyle HorizontalAlign="Left" />
			    </JWC:BoundFieldEx>
		    </Columns>
	    </JWC:DataGridView>
	</div>
</asp:Content>
