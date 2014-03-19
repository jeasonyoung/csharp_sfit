<%--
//================================================================================
// FileName: frmSysMgrRegWebPartTemplateList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSysMgrRegWebPartTemplateList.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrRegWebPartTemplateList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSysMgrRegWebPartTemplateEdit.aspx" PickerType="Modal" PickerWidth="560px" PickerHeight="460px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbWebPartTemplateName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartTemplateName">模板名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtWebPartTemplateName" runat="server" ShowUnDefine="true" Width="128px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSysMgrRegWebPartTemplateList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
		PageSize="10" onbuilddatasource="dgfrmSysMgrRegWebPartTemplateList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="WebPartTemplateID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="560px" WinHeight="460px"
				DataNavigateUrlFormatString="frmSysMgrRegWebPartTemplateEdit.aspx?WebPartTemplateID={0}" DataNavigateUrlField="WebPartTemplateID"
				HeaderText="模板名称" DataField="WebPartTemplateName" SortExpression="WebPartTemplateName" meta:resourcekey="Sys_WebPartTemplateName">
				<HeaderStyle Width="30%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="WebPartTemplatePath" HeaderText="模板地址" SortExpression="WebPartTemplatePath" meta:resourcekey="Sys_WebPartTemplatePath">
				<HeaderStyle Width="70%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
