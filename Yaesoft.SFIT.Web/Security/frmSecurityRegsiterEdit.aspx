<%--
//================================================================================
// FileName: frmSecurityRegsiterEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityRegsiterEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityRegsiterEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityRegsiterEdit" runat="server"  ShowMessageBox="true" ShowSummary="false" />
	<!--����¼������-->
	<div class="TableSearch">
	     <div style="float:left;width:100%;">
	            <JWC:LabelEx ID="lbSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemID">ϵͳ��ţ�</JWC:LabelEx>
	            <JWC:TextBoxEx ID="txtSystemID" runat="server" Width="416px"  MaxLength="32" IsRequired="true" RequiredErrorMessage="ϵͳ��Ų���Ϊ�գ�" />
            </div>
		
	        <div style="float:left;width:100%;">
			    <JWC:LabelEx ID="lbParentSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_ParentSystemID">�ϼ�ϵͳ��</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlParentSystemID" runat="server" ShowUnDefine="true"  ShowTreeView="true" Width="168px"  />
		    </div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemSign" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemSign">ϵͳ��ʶ��</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSystemSign" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="ϵͳ��ʶ����Ϊ�գ�" />
		    </div>
    		
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemName" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemName">ϵͳ���ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtSystemName" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="ϵͳ���Ʋ���Ϊ�գ�" />
		    </div>
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSystemURL" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemURL">ϵͳURL��</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSystemURL" runat="server" Width="416px"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbSecurityURL" runat="server" Style="float:left;" meta:resourcekey="Sec_SecurityURL">��ȫURL��</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSecurityURL" runat="server" Width="416px"  />
		</div>
		
		<div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbPatchURL" runat="server" Style="float:left;" meta:resourcekey="Sec_PatchURL">����URL��</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtPatchURL" runat="server" Width="416px"  />
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbModuleConfigURL" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleConfigURL">�˵�URL��</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtModuleConfigURL" runat="server" Width="416px"  />
		</div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemType" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemType">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�ͣ�</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlSystemType" runat="server" Width="168px" ShowUnDefine="true" IsRequired="true" ErrorMessage="���Ͳ���Ϊ�գ�" />
		    </div>
		    
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbSystemStatus" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemStatus">״&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;̬��</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlSystemStatus" runat="server" Width="168px" ShowUnDefine="true" IsRequired="true" ErrorMessage="״̬����Ϊ�գ�" />
		    </div>
		</div>
		
		<div style="float:left; width:100%;">
			<JWC:LabelEx ID="lbSystemDescription" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemDescription">ϵͳ������</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtSystemDescription" runat="server" Width="416px" TextMode="MultiLine" Rows="3"  />
		</div>
	</div>
	<!--���ݿ�������-->
	<div class="TableControl">
		<div style="margin:0 auto; text-align:center; width:100%;">
		    <JWC:ServerAlert ID="errMsg" runat="server" />
			<JWC:ButtonEx ID="btnSave" runat="server" ButtonType="Save" onclick="btnSave_Click" CausesValidation="true" ConfirmMsg="��ȷ���������ݣ�" ShowConfirmMsg="true"/>
			<JWC:ButtonEx ID="btnBatch" runat="server" ButtonType="Batch" Visible="false" LeftSpace="2" OnClick="btnBatch_Click" CausesValidation="true" ConfirmMsg="��ȷ��Ҫ��ʼ��ģ��Ȩ�ޣ�" ShowConfirmMsg="true" />
			<JWC:ButtonEx ID="btnCancel" runat="server" ButtonType="Cancel" LeftSpace="2" beforeclickscript='window.returnValue="";window.close();return false;'/>
		</div>
	</div>
</asp:Content>
