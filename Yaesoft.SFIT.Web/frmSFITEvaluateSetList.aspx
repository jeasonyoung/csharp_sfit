<%--
//================================================================================
// FileName: frmSFITEvaluateSetList.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleFrameSetMasterPage.Master" CodeBehind="frmSFITEvaluateSetList.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITEvaluateSetList" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<!--����-->
	<div class="TitleBar">
		<span class="LabelTitle" style="float:left;">
			<JWC:LabelEx id="lbTitle" runat="server"/>
		</span>
		<div style="float:right;">
			<span style="float:left;">
				<JWC:ButtonEx ID="btnAdd" runat="server" ButtonType="Add" PickerPage="frmSFITEvaluateSetEdit.aspx" PickerType="Modal" PickerWidth="440px" PickerHeight="210px" onclick="btnAdd_Click"/>
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
	         <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_Grade">�����꼶��</JWC:LabelEx>
	        <JWC:DropDownListEx ID="ddlGrade" runat="server" Width="168px" ShowUnDefine="true" />
        </div>
        
        <div style="float:left;">
			<JWC:LabelEx ID="lbEvaluateName" runat="server" Style="float:left;" meta:resourcekey="SFIT_EvaluateName">���۹������ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtEvaluateName" runat="server" Width="128px" />
		</div>
		
		<div style="float:right;">
			<JWC:ButtonEx ID="btnSearch" runat="server" ButtonType="Search" CausesValidation="true" onclick="btnSearch_Click"/>
			<JWC:ServerAlert ID="errMessage" runat="server" />
		</div>
	</asp:Panel>
	<!--������ʾ����-->
	<JWC:DataGridView ID="dgfrmSFITEvaluateSetList" runat="server" CssClass="DataGrid" Width="98%" ShowFooter="true"
		AllowSorting="true" AllowPaging="true" AllowExport="false" MouseoverCssClass="DataGridHighLight"
		PageSize="15" onbuilddatasource="dgfrmSFITEvaluateSetList_BuildDataSource">
		<PagerSettings Mode="NextPreviousFirstLast" />
		<AlternatingRowStyle CssClass="DataGridAlter" />
		<HeaderStyle CssClass="DataGridHeader" />
		<FooterStyle CssClass="DataGridFooter" />
		<RowStyle CssClass="DataGridItem" />
		<Columns>
			<JWC:CheckBoxFieldEx DataField="EvaluateID,GradeID" DataFormatString="{0}-{1}">
				<HeaderStyle Width="8px" />
			</JWC:CheckBoxFieldEx>
						
			<JWC:BoundFieldEx DataField="GradeName" HeaderText="�꼶" SortExpression="GradeName" meta:resourcekey="SFIT_DGV_GradeName">
				<HeaderStyle Width="25%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:MultiQueryStringFieldEx PopupWin="true" WinType="Modal" WinWidth="440px" WinHeight="210px"
				DataNavigateUrlFormatString="frmSFITEvaluateSetEdit.aspx?EvaluateID={0}&GradeID={1}" DataNavigateUrlField="EvaluateID,GradeID"
				HeaderText="���۹�������" DataField="EvaluateName" SortExpression="EvaluateName" meta:resourcekey="SFIT_DGV_EvaluateName">
				<HeaderStyle Width="50%" />
				<ItemStyle HorizontalAlign="Left" />
			</JWC:MultiQueryStringFieldEx>
			
			<JWC:BoundFieldEx DataField="EvaluateTypeName" HeaderText="��������" SortExpression="EvaluateTypeName" meta:resourcekey="SFIT_DGV_EvaluateType">
				<HeaderStyle Width="10%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
			
			<JWC:BoundFieldEx DataField="ModifyTime" HeaderText="����ʱ��" SortExpression="ModifyTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" meta:resourcekey="SFIT_DGV_ModifyTime">
				<HeaderStyle Width="15%" />
				<ItemStyle HorizontalAlign="Center" />
			</JWC:BoundFieldEx>
		</Columns>
	</JWC:DataGridView>
</asp:Content>
