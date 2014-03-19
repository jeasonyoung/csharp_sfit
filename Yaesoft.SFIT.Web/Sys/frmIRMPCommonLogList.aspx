<%--
//================================================================================
// FileName: frmIRMPCommonLogList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmIRMPCommonLogList.aspx.cs" Inherits="iPower.IRMP.SysMgr.Web.frmIRMPCommonLogList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
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
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="您确定要删除当前所选择的数据吗？" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--查询区域-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemName" runat="server" Style="float:left;" meta:resourcekey="Sys_SystemName">系统名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSystemName" runat="server" Width="128px" />
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbEmployeeName" runat="server" Style="float:left;" meta:resourcekey="Sys_EmployeeName">用户名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtEmployeeName" runat="server" Width="128px" />
		    </div>
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbCreateDate" runat="server" Style="float:left;" meta:resourcekey="Sys_CreateDate">创建时间：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtCreateDate" runat="server" Width="86px" />
		    </div>
		</div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbLogContext" runat="server" Style="float:left;" meta:resourcekey="Sys_LogContext">日志内容：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtLogContext" runat="server" Width="480px" />
		    </div>
		    <div style="float:right;">
			    <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			    <JWC:ServerAlert ID="errMessage" runat="server" />
		    </div>
		</div>
	</asp:Panel>
	<!--数据显示区域-->
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
				HeaderText="创建时间" DataField="CreateDate" SortExpression="CreateDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" meta:resourcekey="Sys_CreateDate">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="SystemName" HeaderText="系统名称" SortExpression="SystemName" meta:resourcekey="Sys_SystemName">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
						
			<JWC:BoundFieldEx DataField="CreateEmployeeName" HeaderText="用户名称" SortExpression="CreateEmployeeName" meta:resourcekey="Sys_CreateEmployeeName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="RelationTable" HeaderText="操作" SortExpression="RelationTable" meta:resourcekey="Sys_RelationTable">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="LogContext" HeaderText="日志内容" SortExpression="LogContext" CharCount="60" meta:resourcekey="Sys_LogContext">
				<HeaderStyle Width="50%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
		</Columns>
	</JWC:DataGridView>
</asp:Content>
