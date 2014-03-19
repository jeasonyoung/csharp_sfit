<%--
//================================================================================
// FileName: frmSFITTeaClassList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITTeaClassList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITTeaClassList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<JWC:LabelEx id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITTeaClassEdit.aspx" PickerType="Modal" PickerWidth="480px" PickerHeight="560px" onclick="btnAdd_Click"/>
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
			<JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolName">ѧУ���ƣ�</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="168px" />
		</div>
	
		<div style="float:left;">
			<JWC:LabelEx ID="lbTeacher" runat="server" Style="float:left;" meta:resourcekey="SFIT_TeacherName">��ʦ���ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtTeacherName" runat="server" Width="128px" />
		</div>
		
		<div style="float:left;">
			<JWC:LabelEx ID="lbClass" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassName">�༶���ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtClassName" runat="server" Width="128px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--������ʾ����-->
	<JWC:DataGridView ID="dgfrmSFITTeaClassList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSFITTeaClassList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="TeacherID">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
			
			<JWC:BoundFieldEx DataField="SchoolName" HeaderText="ѧУ����" SortExpression="SchoolName" meta:resourcekey="SFIT_SchoolName">
				<HeaderStyle Width="25%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="TeacherCode" HeaderText="��ʦ����" SortExpression="TeacherCode" meta:resourcekey="SFIT_TeacherCode">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
						
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="480px" WinHeight="560px"
				DataNavigateUrlFormatString="frmSFITTeaClassEdit.aspx?TeacherID={0}" DataNavigateUrlField="TeacherID"
				HeaderText="��ʦ����" DataField="TeacherName" SortExpression="TeacherName" meta:resourcekey="SFIT_TeacherName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="ClassName" HeaderText="�༶" SortExpression="ClassName" meta:resourcekey="SFIT_ClassName">
				<HeaderStyle Width="55%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
