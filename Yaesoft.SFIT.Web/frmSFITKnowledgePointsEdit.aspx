<%--
//================================================================================
// FileName: frmSFITKnowledgePointsEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITKnowledgePointsEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITKnowledgePointsEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITKnowledgePointsEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--����¼������-->
	<div class="TableSearch">
	    <asp:Panel ID="panelParentPoint" runat="server" Visible="false" Width="100%">
			<JWC:LabelEx ID="lbParentPointID" runat="server" Style="float:left;" meta:resourcekey="SFIT_ParentPointID">�ϼ�Ҫ�㣺</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlParentPointID" runat="server" ShowTreeView="true" ShowUnDefine="true" Width="368px" IsRequired="true" ErrorMessage="�ϼ�Ҫ�㲻��Ϊ�գ�" />
		</asp:Panel>
		
		<asp:Panel ID="panelGrade" runat="server" Width="100%">
		    <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_ParentPointID">�����꼶��</JWC:LabelEx>
			<JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="�����꼶����Ϊ�գ�" />
		</asp:Panel>
				
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbPointCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_PointCode">Ҫ����룺</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtPointCode" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="Ҫ����벻��Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbPointName" runat="server" Style="float:left;" meta:resourcekey="SFIT_PointName">Ҫ�����ƣ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtPointName" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="Ҫ�����Ʋ���Ϊ�գ�" />
		</div>
				
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">��&nbsp;&nbsp;��&nbsp;&nbsp;�ţ�</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="80px" CssClass="NumberTextBoxFlat" Text="1" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="����Ų���Ϊ�գ�" />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbDescription" runat="server" Style="float:left;" meta:resourcekey="SFIT_Description">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtDescription" runat="server" Width="368px" TextMode="MultiLine" Rows="3" />
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
