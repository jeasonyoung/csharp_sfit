<%--
//================================================================================
// FileName: frmSFITClassList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITClassList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITClassList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
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
				<JWC:ButtonEx ID="btnDelete" runat="server" ButtonType="Del" ShowConfirmMsg="true" ConfirmMsg="��ȷ��Ҫɾ����ǰ��ѡ���������" onclick="btnDelete_Click" />
			</span>
		</div>
	</div>
	<!--��ѯ����-->
	<asp:Panel ID="panelSearch" runat="server" CssClass="TableSearch" DefaultButton="btnSearch">
	    
	       <div style="float:left;">
			    <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">����ѧУ��</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="168px" />
    		</div>
    		
	        <div style="float:left;">
			    <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeName">�꼶���ƣ�</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlGrade" runat="server" Width="128px" ShowUnDefine="true" />
		    </div>
		
		    <div style="float:left; width:268px;">
			    <JWC:LabelEx ID="lbClassName" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassName">�༶���ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtClassName" runat="server" Width="128px" />
		    </div>
    	
		    <div style="float:right;">
			    <JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			    <JWC:ServerAlert ID="errMessage" runat="server" />
		    </div>
	</asp:Panel>
	<!--�༶������ʾ����-->
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
			
			<JWC:BoundFieldEx DataField="SchoolName" HeaderText="����ѧУ" SortExpression="SchoolName" meta:resourcekey="SFIT_DGV_School">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="GradeName" HeaderText="�����꼶" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
				<HeaderStyle Width="13%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="ClassCode" HeaderText="�༶����" SortExpression="ClassCode" meta:resourcekey="SFIT_DGV_ClassCode">
				<HeaderStyle Width="22%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:BoundFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="540px" WinHeight="270px"
				DataNavigateUrlFormatString="frmSFITClassEdit.aspx?ClassID={0}" DataNavigateUrlField="ClassID" ToolTipField="ClassToolTip" ShowToolTip="true"
				HeaderText="�༶����" DataField="ClassName" SortExpression="ClassName" meta:resourcekey="SFIT_DGV_ClassName">
				<HeaderStyle Width="20%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="SyncStatusName" HeaderText="ͬ��״̬" SortExpression="SyncStatusName" meta:resourcekey="SFIT_DGV_SyncStatusName">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="LastSyncTime" HeaderText="ͬ��ʱ��" SortExpression="LastSyncTime" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" 
			        meta:resourcekey="SFIT_DGV_LastSyncTime">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
