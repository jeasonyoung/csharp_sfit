<%--
//================================================================================
// FileName: frmSysMgrWebPartPersonalList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSysMgrWebPartPersonalList.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSysMgrWebPartPersonalList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSysMgrWebPartPersonalEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="210px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbWebPartName" runat="server" Style="float:left;" meta:resourcekey="Sys_WebPartName">部件名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtWebPartName" runat="server" ShowUnDefine="true" Width="168px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSysMgrWebPartPersonalList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
		PageSize="10" onbuilddatasource="dgfrmSysMgrWebPartPersonalList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="PersonalWebPartID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="210px"
				DataNavigateUrlFormatString="frmSysMgrWebPartPersonalEdit.aspx?PersonalWebPartID={0}" DataNavigateUrlField="PersonalWebPartID"
				HeaderText="部件名称" DataField="WebPartName" SortExpression="WebPartName" meta:resourcekey="Sys_WebPartName">
				<HeaderStyle Width="35%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="EmployeeName" HeaderText="所属用户" SortExpression="EmployeeName" meta:resourcekey="Sys_EmployeeName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="ZoneName" HeaderText="显示位置" SortExpression="ZoneName" meta:resourcekey="Sys_ZoneName">
				<HeaderStyle Width="35%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="OrderNo" HeaderText="呈现顺序" SortExpression="OrderNo" meta:resourcekey="Sys_OrderNo">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Right" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="WebPartStatusName" HeaderText="状态" SortExpression="WebPartStatusName" meta:resourcekey="Sys_WebPartStatus">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
