<%--
//================================================================================
//  FileName: frmSFITTeaClassByUnitList.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2012/4/9
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
//--%>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITTeaClassByUnitList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITTeaClassByUnitList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--标题-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<JWC:LabelEx id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITTeaClassByUnitEdit.aspx" PickerType="Modal" PickerWidth="480px" PickerHeight="560px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolName">学校名称：</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlSchool" runat="server" Width="168px" />
		</div>
	
		<div style="float:left;">
			<JWC:LabelEx ID="lbTeacher" runat="server" Style="float:left;" meta:resourcekey="SFIT_TeacherName">教师名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtTeacherName" runat="server" Width="128px" />
		</div>
		
		<div style="float:left;">
			<JWC:LabelEx ID="lbClass" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassName">班级名称：</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtClassName" runat="server" Width="128px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--数据显示区域-->
	<JWC:DataGridView ID="dgfrmSFITTeaClassByUnitList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSFITTeaClassByUnitList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="TeacherID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:BoundFieldEx DataField="SchoolName" HeaderText="学校名称" SortExpression="SchoolName" meta:resourcekey="SFIT_SchoolName">
				<HeaderStyle Width="25%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="TeacherCode" HeaderText="教师代码" SortExpression="TeacherCode" meta:resourcekey="SFIT_TeacherCode">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
						
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="480px" WinHeight="560px"
				DataNavigateUrlFormatString="frmSFITTeaClassByUnitEdit.aspx?TeacherID={0}" DataNavigateUrlField="TeacherID"
				HeaderText="教师名称" DataField="TeacherName" SortExpression="TeacherName" meta:resourcekey="SFIT_TeacherName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="ClassName" HeaderText="班级" SortExpression="ClassName" meta:resourcekey="SFIT_ClassName">
				<HeaderStyle Width="55%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>