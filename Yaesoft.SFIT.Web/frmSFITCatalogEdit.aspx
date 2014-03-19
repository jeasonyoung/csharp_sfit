<%--
//================================================================================
// FileName: frmSFITCatalogEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITCatalogEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITCatalogEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.TreeView" tagprefix="JWC" %>

<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITCatalogEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	
	<div class="TableSearch">
	    <fieldset style="float:left;width:98%;">
	        <legend>Ŀ¼��Ϣ</legend>
	        <div style="float:left;width:100%;">
	            <div style="float:left;">
	                <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">����ѧУ��</JWC:LabelEx>
	                <JWC:PickerBase ID="pbSchool" runat="server" Width="198px" PickerPage="frmSFITSchoolPicker.aspx" PickerHeight="400px" PickerWidth="300px" MultiSelect="false"/>
                </div>    	    
                
                <div style="float:left; margin-left:17px;">
                    <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_GradeName">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</JWC:LabelEx>
                    <JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="�꼶����Ϊ�գ�" AutoPostBack="true" 
                         OnSelectedIndexChanged="ddlGrade_OnSelectedIndexChanged" />
                </div>
                
                <div style="float:left;margin-left:10px;">
	                <JWC:LabelEx ID="lbCatalogType" runat="server" Style="float:left;" meta:resourcekey="SFIT_CatalogType">Ŀ¼���ͣ�</JWC:LabelEx>
	                <JWC:DropDownListEx ID="ddlCatalogType" runat="server" Width="128px" IsRequired="true" ErrorMessage="Ŀ¼���Ͳ���Ϊ�գ�" />
                </div>
            </div>
            <div style="float:left;width:100%;">
                <div style="float:left;">
	                <JWC:LabelEx ID="lbCatalogCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_CatalogCode">Ŀ¼���룺</JWC:LabelEx>
	                <JWC:TextBoxEx ID="txtCatalogCode" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="Ŀ¼���벻��Ϊ�գ�"/>
                </div>
                <div style="float:left;margin-left:2px;">
	                <JWC:LabelEx ID="lbCatalogName" runat="server" Style="float:left;" meta:resourcekey="SFIT_CatalogName">Ŀ¼���ƣ�</JWC:LabelEx>
	                <JWC:TextBoxEx ID="txtCatalogName" runat="server" Width="168px"  IsRequired="true" RequiredErrorMessag="Ŀ¼���Ʋ���Ϊ�գ�" />
                </div>
                <div style="float:left;margin-left:8px;">
	                <JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">��&nbsp;&nbsp;��&nbsp;&nbsp;�ţ�</JWC:LabelEx>
	                <JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="128px" Text="1" CssClass="NumberTextBoxFlat" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="����Ų���Ϊ�գ�" />
                </div>
            </div>
        </fieldset>
    	
    	<fieldset style="float:left;width:98%;">
    	    <legend>֪ʶ����Ҫ��</legend>
    	    <div style="float:left; width:100%; height:430px; overflow:auto;">
    	        <JWC:TreeView ID="tvKnowledgePoints" runat="server" ExpandAllLevel="true" CheckType="CheckBox" ShowScrollBar="true" />
    	    </div>
    	</fieldset>
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
