<%--
//================================================================================
// FileName: frmSFITGradeEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITGradeEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITGradeEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITGradeEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--����¼������-->
	<div class="TableSearch">
	     	
	    <div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbGradeCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeCode">�꼶���룺</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtGradeCode" runat="server" Width="368px"  IsRequired="true" RequiredErrorMessage="�꼶���벻��Ϊ�գ�" />
	    </div>
		
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbGradeName" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeName">�꼶���ƣ�</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtGradeName" runat="server" Width="368px" IsRequired="true" RequiredErrorMessage="�꼶���Ʋ���Ϊ�գ�" />
	    </div>		    
	     
	    <div style="float:left; width:100%;">
            <JWC:LabelEx ID="lbGradeValue" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeValue">��&nbsp;&nbsp;��&nbsp;&nbsp;ֵ��</JWC:LabelEx>
            <JWC:TextBoxEx ID="txtGradeValue" runat="server" Width="80px" CssClass="NumberTextBoxFlat" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="�꼶ֵ����Ϊ�գ�" />
        </div>
	    
        <div style="float:left; width:100%;">
             <JWC:LabelEx ID="lbLearnLevelName" runat="server" Style="float:left;" meta:resourcekey="SFIT_LearnLevelName">ѧϰ�׶Σ�</JWC:LabelEx>
             <JWC:DropDownListEx ID="ddlLearnLevel" runat="server" Width="128px" ShowUnDefine="true" IsRequired="true" ErrorMessage="ѧϰ�׶β���Ϊ�գ�" />
        </div>
        
        <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">��&nbsp;&nbsp;��&nbsp;&nbsp;�ţ�</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="80px" CssClass="NumberTextBoxFlat" OnlyNumber="true" Text="1" IsRequired="true" RequiredErrorMessage="����Ų���Ϊ�գ�" />
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
