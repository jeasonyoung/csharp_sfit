<%--
//================================================================================
// FileName: frmSFITEvaluateSetEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITEvaluateSetEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITEvaluateSetEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITEvaluateSetEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--����¼������-->
	<div class="TableSearch">	    
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeName">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="�꼶����Ϊ�գ�" />
	    </div>
	
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbEvaluate" runat="server" Style="float:left;" meta:resourcekey="SFIT_EvaluateName">���۹���</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlEvaluate" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="���۹�����Ϊ�գ�" />
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
