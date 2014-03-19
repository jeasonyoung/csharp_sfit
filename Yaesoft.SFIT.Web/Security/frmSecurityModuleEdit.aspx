<%--
//================================================================================
// FileName: frmSecurityModuleEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSecurityModuleEdit.aspx.cs" Inherits="iPower.IRMP.Security.Web.frmSecurityModuleEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSecurityModuleEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<!--����¼������-->
	<div class="TableSearch">
        <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbSystemID" runat="server" Style="float:left;" meta:resourcekey="Sec_SystemID">����ϵͳ��</JWC:LabelEx>
		    <JWC:DropDownListEx ID="ddlSystemID" runat="server" ShowUnDefine="true" ShowTreeView="true" Width="168px" AutoPostBack="true" OnSelectedIndexChanged="ddlSystemID_OnSelectedIndexChanged"
		     IsRequired="true" ErrorMessage="����ϵͳ����Ϊ�գ�" />
	    </div>
	
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbModuleID" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleID">ģ���ţ�</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtModuleID" runat="server" Width="418px"  MaxLength="32" IsRequired="true" RequiredErrorMessage="ģ���Ų���Ϊ�գ�" />
	    </div>
 		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbModuleName" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleName">ģ�����ƣ�</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtModuleName" runat="server" Width="168px" IsRequired="true" RequiredErrorMessage="ģ�����Ʋ���Ϊ�գ�" />
		    </div>
		    
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbParentModuleID" runat="server" Style="float:left;" meta:resourcekey="Sec_ParentModuleID">�ϼ�ģ�飺</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlParentModuleID" runat="server" ShowUnDefine="true" ShowTreeView="true" Width="168px"  />
		    </div>	
		</div>
		
		<div style="float:left; width:100%;">
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbModuleStatus" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleStatus">״&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;̬��</JWC:LabelEx>
			    <JWC:DropDownListEx ID="ddlModuleStatus" runat="server" Width="168px" ShowUnDefine="true" IsRequired="true" ErrorMessage="״̬����Ϊ�գ�" />
		    </div>
    		
		    <div style="float:left;">
			    <JWC:LabelEx ID="lbOrderNo" runat="server" Style="float:left;" meta:resourcekey="Sec_OrderNo">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��</JWC:LabelEx>
			    <JWC:TextBoxEx ID="txtOrderNo" runat="server" Width="168px" OnlyNumber="true" Text="0" />
		    </div>
		</div>
		
		<div style="float:left;width:100%;">
			<JWC:LabelEx ID="lbModuleDescription" runat="server" Style="float:left;" meta:resourcekey="Sec_ModuleDescription">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
			<JWC:TextBoxEx ID="txtModuleDescription" runat="server" TextMode="MultiLine" Rows="3" Width="418px"  />
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
