<%--
//================================================================================
// FileName: frmSysMgrSettingList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSysMgrSettingList.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrSettingList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSysMgrSettingEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="260px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbSystemName" runat="server" Style="float:left;" meta:resourcekey="Sys_SystemName">系统名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSystemName" runat="server" ShowUnDefine="true" Width="128px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSysMgrSettingList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSysMgrSettingList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="SettingID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemName" HeaderText="所属系统" SortExpression="AppAuthID" meta:resourcekey="Sys_AppAuthID">
			    <HeaderStyle Width="30%" />
			    <ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="260px"
			     DataNavigateUrlFormatString="frmSysMgrSettingEdit.aspx?SettingID={0}" DataNavigateUrlField="SettingID"
			     HeaderText="参数名" DataField="SettingSign" SortExpression="SettingSign" meta:resourcekey="Sys_SettingSign">
				<HeaderStyle Width="30%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="DefaultValue" HeaderText="默认值" SortExpression="DefaultValue" meta:resourcekey="Sys_DefaultValue">
				<HeaderStyle Width="30%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="SettingTypeName" HeaderText="类型" SortExpression="SettingType"  meta:resourcekey="Sys_SettingType">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
