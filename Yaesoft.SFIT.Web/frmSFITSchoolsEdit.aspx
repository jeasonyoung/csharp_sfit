<%--
//================================================================================
// FileName: frmSFITSchoolsEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITSchoolsEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITSchoolsEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITSchoolsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--����¼������-->
	<div class="TableSearch">
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSchoolCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolCode">ѧУ���룺</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSchoolCode" runat="server" Width="286px"  IsRequired="true" RequiredErrorMessage="ѧУ���벻��Ϊ�գ�"/>
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSchoolName" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolName">ѧУ���ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSchoolName" runat="server" Width="286px"  IsRequired="true" RequiredErrorMessage="ѧУ���Ʋ���Ϊ�գ�"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSchoolType" runat="server" Style="float:left;" meta:resourcekey="SFIT_SchoolTypeName">ѧУ���ͣ�</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSchoolType" runat="server" Width="80px" IsRequired="true" ErrorMessage="ѧУ���Ͳ���Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">��&nbsp;&nbsp;��&nbsp;&nbsp;�ţ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtOrderNO" runat="server"  CssClass="NumberTextBoxFlat" OnlyNumber="true" Width="80px" Text="1" IsRequired="true" RequiredErrorMessage="����Ų���Ϊ�գ�"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSyncStatus" runat="server" Style="float:left;" meta:resourcekey="SFIT_SyncStatus">ͬ��״̬��</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlSyncStatus" runat="server" Width="80px" IsRequired="true" ErrorMessage="ͬ��״̬����Ϊ�գ�" />
		</div>
		
	</div>
	<!--���ݿ�������-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
			<JWC:ServerAlert ID="errMessage" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="��ȷ���������ݣ�" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
