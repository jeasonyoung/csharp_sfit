<%--
//================================================================================
// FileName: frmSSOTicketList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSSOTicketList.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmSSOTicketList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<asp:Label id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--查询区域-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
		<div style="float:left;">
			<JWC:LabelEx ID="lbUserData" runat="server" Style="float:left;" meta:resourcekey="Sys_UserData">用户信息：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtUserData" runat="server" Width="128px" />
		</div>
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSSOTicketList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="true" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSSOTicketList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="Token">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="260px"
				DataNavigateUrlFormatString="frmSSOTicketEdit.aspx?Token={0}" DataNavigateUrlField="Token"
				HeaderText="令牌" DataField="Token" SortExpression="Token" meta:resourcekey="Sys_Token">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="UserData" HeaderText="用户信息" SortExpression="UserData" meta:resourcekey="Sys_UserData">
				<HeaderStyle Width="32%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="IssueDate" HeaderText="创建时间" SortExpression="IssueDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" meta:resourcekey="Sys_IssueDate">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="Expiration" HeaderText="失效时间" SortExpression="Expiration" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" meta:resourcekey="Sys_Expiration">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="IssueClientIP" HeaderText="创建IP" SortExpression="IssueClientIP" meta:resourcekey="Sys_IssueClientIP">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="HasValidName" HeaderText="是否有效" SortExpression="HasValidName" meta:resourcekey="Sys_HasValidName">
				<HeaderStyle Width="8%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
