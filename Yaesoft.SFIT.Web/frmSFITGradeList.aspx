<%--
//================================================================================
// FileName: frmSFITGradeList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITGradeList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITGradeList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<JWC:LabelEx id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITGradeEdit.aspx" PickerType="Modal" PickerWidth="480px" PickerHeight="240px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbGradeName" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeName">年级：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtGradeName" runat="server" Width="168px" />
		</div>
		
		<div style="float:left;">
			<JWC:LabelEx ID="lbLearnLevel" runat="server" Style="float:left;" meta:resourcekey="SFIT_LearnLevel">学习阶段：</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlLearnLevel" runat="server" Width="128px" ShowUnDefine="true" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--年级数据-->
	<JWC:DataGridView ID="dgfrmSFITGradeList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSFITGradeList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="GradeID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
						
			<JWC:BoundFieldEx DataField="GradeCode" HeaderText="年级代码" SortExpression="GradeCode" meta:resourcekey="SFIT_DGV_GradeCode">
				<HeaderStyle Width="30%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="480px" WinHeight="240px"
				DataNavigateUrlFormatString="frmSFITGradeEdit.aspx?GradeID={0}" DataNavigateUrlField="GradeID"
				HeaderText="年级名称" DataField="GradeName" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
				<HeaderStyle Width="45%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			 
			<JWC:BoundFieldEx DataField="GradeValue" HeaderText="年级值" SortExpression="GradeValue" meta:resourcekey="SFIT_DGV_GradeValue">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="LearnLevelName" HeaderText="学习阶段" SortExpression="LearnLevelName" meta:resourcekey="SFIT_DGV_LearnLevelName">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
