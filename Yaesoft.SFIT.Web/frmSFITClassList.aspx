<%--
//================================================================================
// FileName: frmSFITClassList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITClassList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITClassList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<JWC:LabelEx id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITClassEdit.aspx" PickerType="Modal" PickerWidth="540px" PickerHeight="270px" onclick="btnAdd_Click"/>
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
			    <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">所属学校：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="168px" />
    		</div>
    		
	        <div style="float:left;">
			    <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeName">年级名称：</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlGrade" runat="server" Width="128px" ShowUnDefine="true" />
		    </div>
		
		    <div style="float:left; width:268px;">
			    <JWC:LabelEx ID="lbClassName" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassName">班级名称：</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtClassName" runat="server" Width="128px" />
		    </div>
    	
		    <div style="float:right;">
			    <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			    <JWC:ServerAlert ID="errMessage" runat="server" />
		    </div>
	</asp:Panel>
	<!--班级数据显示区域-->
	<JWC:DataGridView ID="dgfrmSFITClassList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSFITClassList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="ClassID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:BoundFieldEx DataField="SchoolName" HeaderText="所属学校" SortExpression="SchoolName" meta:resourcekey="SFIT_DGV_School">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="GradeName" HeaderText="所属年级" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
				<HeaderStyle Width="13%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="ClassCode" HeaderText="班级代码" SortExpression="ClassCode" meta:resourcekey="SFIT_DGV_ClassCode">
				<HeaderStyle Width="22%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="270px"
				DataNavigateUrlFormatString="frmSFITClassEdit.aspx?ClassID={0}" DataNavigateUrlField="ClassID" ToolTipField="ClassToolTip" ShowToolTip="true"
				HeaderText="班级名称" DataField="ClassName" SortExpression="ClassName" meta:resourcekey="SFIT_DGV_ClassName">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="SyncStatusName" HeaderText="同步状态" SortExpression="SyncStatusName" meta:resourcekey="SFIT_DGV_SyncStatusName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="LastSyncTime" HeaderText="同步时间" SortExpression="LastSyncTime" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" 
			        meta:resourcekey="SFIT_DGV_LastSyncTime">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
