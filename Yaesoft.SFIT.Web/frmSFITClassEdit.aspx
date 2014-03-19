<%--
//================================================================================
// FileName: frmSFITClassEdit.aspx
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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Share/ModuleNormalMasterPage.Master" CodeBehind="frmSFITClassEdit.aspx.cs" Inherits="Yaesoft.SFIT.Web.frmSFITClassEdit" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<asp:Content ID="contentWorkPlace" ContentPlaceHolderID="workPlace" runat="server">
	<JWC:ValidationSummaryEx id="vsfrmSFITClassEdit" runat="server"  ShowMessageBox="true" ShowSummary="false"/>
	<!--����¼������-->
	<div class="TableSearch">
	    <div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbSchool" runat="server" Style="float:left;" meta:resourcekey="SFIT_School">����ѧУ��</JWC:LabelEx>
		    <JWC:PickerBase ID="pbSchool" runat="server" Width="370px" PickerPage="frmSFITSchoolPicker.aspx" PickerHeight="400px" PickerWidth="300px" MultiSelect="false"
			      IsRequired="true" ErrorMessage="ѧУ���Ʋ���Ϊ�գ�" />
		</div>
		
        <div style="float:left;width:100%;">
            <JWC:LabelEx ID="lbGrade" runat="server" Style="float:left;" meta:resourcekey="SFIT_Grade">�����꼶��</JWC:LabelEx>
            <JWC:DropDownListEx ID="ddlGrade" runat="server" ShowUnDefine="true" Width="168px" IsRequired="true" ErrorMessage="�����꼶����Ϊ�գ�"  />
        </div>
			    
	    <div style="float:left; width:100%;">
		    <JWC:LabelEx ID="lbClassCode" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassCode">�༶���룺</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtClassCode" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="�༶���벻��Ϊ�գ�" />
	    </div>
		
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbClassName" runat="server" Style="float:left;" meta:resourcekey="SFIT_ClassName">�༶���ƣ�</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtClassName" runat="server" Width="198px" IsRequired="true" RequiredErrorMessage="�༶���Ʋ���Ϊ�գ�"  />
	    </div>
	    
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbJoinYear" runat="server" Style="float:left;" meta:resourcekey="SFIT_JoinYear">��ѧ��ݣ�</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtJoinYear" runat="server" Width="80px" OnlyNumber="true" IsRequired="true" RequiredErrorMessage="��ѧ��ݲ���Ϊ�գ�"  />
	    </div>
	    		
	    <div style="float:left;width:100%;">
		    <JWC:LabelEx ID="lbOrderNO" runat="server" Style="float:left;" meta:resourcekey="SFIT_OrderNO">��&nbsp;&nbsp;��&nbsp;&nbsp;�ţ�</JWC:LabelEx>
		    <JWC:TextBoxEx ID="txtOrderNO" runat="server" Width="80px" CssClass="NumberTextBoxFlat" Text="1" IsRequired="true" RequiredErrorMessage="����Ų���Ϊ�գ�"  />
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
